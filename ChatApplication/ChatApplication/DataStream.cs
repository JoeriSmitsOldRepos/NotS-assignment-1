using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApplication
{
    internal class DataStream
    {
        public delegate void PrintTextDelegate(string input);
        private readonly PrintTextDelegate _printTextDelegate;
        /// <summary>
        /// DataStream constructor set's the readOnly fields and calls ReceiveData()
        /// </summary>
        /// <param name="client">The Client we would like to connect to the DataStream</param>
        /// <param name="printTextDelegate">The print delegate to print out any messages to the user</param>
        public DataStream(TcpClient client, PrintTextDelegate printTextDelegate)
        {
            this._printTextDelegate = printTextDelegate;

            ReceiveData(client);
        }

        /// <summary>
        /// Listens for data in a seperate Thread. When data is received it will print out the data to the user
        /// When the user types "bye" it should stop listening and close the stream.
        /// </summary>
        public void ReceiveData(TcpClient client)
        {
            var byteArray = new byte[256];
            string data;
            var t = new Thread(delegate ()
            {
                var stream = client.GetStream();
                _printTextDelegate("Connected!");

                var listen = true;
                // Listening for any data from the stream.
                while (listen)
                {
                    var i = stream.Read(byteArray, 0, byteArray.Length);

                    // Translate data bytes to a ASCII string.
                    data = Encoding.ASCII.GetString(byteArray);

                    // When the data (What the user types) is "bye" it will stop listening
                    var cleaned = data.Replace("\0", string.Empty);
                    if (cleaned == "bye")
                    {
                        listen = false;
                        Server.Clients.Remove(client);
                    }

                    // Send the data to every client that is connected except the client where the data came from
                    foreach(var clientItem in Server.Clients)
                    {
                        if (client != clientItem)
                        {
                            var streamItem = clientItem.GetStream();
                            streamItem.Write(byteArray, 0, byteArray.Length);
                        }
                    }

                    // Printing the message to the user that has been received
                    _printTextDelegate(">> " + cleaned);

                    // Clearing the variables for the next data
                    data = null;
                    cleaned = null;
                    Array.Clear(byteArray, 0, byteArray.Length);
                }
               
                stream.Close();
                client.Close();
                _printTextDelegate("Connection closed.");
            });
            t.Start();
        }

        public void sendMessage(NetworkStream stream, string message)
        {
            var byteArray = new byte[message.Length];

            // Encoding the message to bytes for transportation
            byteArray = Encoding.ASCII.GetBytes(message);
            // Writing the bytes to the 
            stream.Write(byteArray, 0, byteArray.Length);
            // Printing out the message to the current user
            _printTextDelegate("<< " + message);
        }
    }
}
