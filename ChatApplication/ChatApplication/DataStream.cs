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

        private bool _clientKilled = false;
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
                while (true)
                {
                    if (listen)
                    {
                        var i = stream.Read(byteArray, 0, byteArray.Length);

                        // Translate data bytes to a ASCII string.
                        data = Encoding.ASCII.GetString(byteArray);

                        // Send the data to every client that is connected except the client where the data came from
                        foreach (var clientItem in Server.Clients)
                        {
                            if (client != clientItem)
                            {
                                var streamItem = clientItem.GetStream();
                                streamItem.Write(byteArray, 0, byteArray.Length);
                            }
                        }

                        // When the data (What the user types) is "bye" it will stop listening
                        var cleaned = data.Replace("\0", string.Empty);
                        if (cleaned == "bye")
                        {
                            listen = false;
                        }

                        // Printing the message to the user that has been received
                        _printTextDelegate(">> " + cleaned);

                        // Clearing the variable for the next data
                        Array.Clear(byteArray, 0, byteArray.Length);
                    }
                    else
                    {
                        // Removing the client from the server
                        Server.Clients.Remove(client);
                        _printTextDelegate("Connection closed.");
                        listen = true;
                    }
                }
            });
            t.Start();
        }

        /// <summary>
        /// Sending a message to the stream. This message will be send to other users and printed out to the current client
        /// </summary>
        /// <param name="stream">The network stream the message should be send to.</param>
        /// <param name="message">The actual message that has to be send.</param>
        public void sendMessage(NetworkStream stream, string message)
        {
            // Check if the client has not a closed connection
            if (!_clientKilled)
            {
                var byteArray = new byte[message.Length];

                // Encoding the message to bytes for transportation
                byteArray = Encoding.ASCII.GetBytes(message);
                // Writing the bytes to the 
                stream.Write(byteArray, 0, byteArray.Length);
                // Printing out the message to the current user
                _printTextDelegate("<< " + message);
            }
            // If message is "bye" we will close the connection and prevent the user from sending data
            if (message == "bye")
            {
                _clientKilled = true;
            }
        }
    }
}
