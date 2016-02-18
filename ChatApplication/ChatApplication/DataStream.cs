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
        private readonly TcpClient _client;

        /// <summary>
        /// DataStream constructor set's the readOnly fields and calls ReceiveData()
        /// </summary>
        /// <param name="client">The Client we would like to connect to the DataStream</param>
        /// <param name="printTextDelegate">The print delegate to print out any messages to the user</param>
        public DataStream(TcpClient client, PrintTextDelegate printTextDelegate)
        {
            this._client = client;
            this._printTextDelegate = printTextDelegate;

            ReceiveData();
        }

        /// <summary>
        /// Listens for data in a seperate Thread. When data is received it will print out the data to the user
        /// When the user types "bye" it should stop listening and close the stream.
        /// </summary>
        public void ReceiveData()
        {
            var byteArray = new byte[1024];
            string data;
            var t = new Thread(delegate ()
            {
                var stream = _client.GetStream();
                _printTextDelegate("Connected!");

                var listen = true;
                // Listening for any data from the stream.
                while (listen)
                {
                    var i = stream.Read(byteArray, 0, byteArray.Length);

                    // Translate data bytes to a ASCII string.
                    data = Encoding.ASCII.GetString(byteArray);

                    // When the data (What the user types) is "bye" it will stop listening
                    if (data == "bye")
                    {
                        listen = false;
                    }

                    _printTextDelegate(data);

                    // Clearing the variables for the next data
                    data = null;
                    Array.Clear(byteArray, 0, byteArray.Length);
                }
                
                // Closing process (Send "bye" to the user)
                byteArray = Encoding.ASCII.GetBytes("bye");
                stream.Write(byteArray, 0, byteArray.Length);

                stream.Close();
                _client.Close();
                _printTextDelegate("Connection closed.");
            });
            t.Start();
        }
    }
}
