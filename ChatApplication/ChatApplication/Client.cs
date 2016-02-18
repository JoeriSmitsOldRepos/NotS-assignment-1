using System;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace ChatApplication
{
    internal class Client
    {
        private NetworkStream _stream;
        public delegate void PrintTextDelegate(string input);
        private readonly PrintTextDelegate _printTextDelegate;

        /// <summary>
        /// Constructor for Client
        /// Everytime a client has been newed it will connect the client to user defined address
        /// It will also start a DataStream for this user so he is able to see any chat messages
        /// </summary>
        /// <param name="ipAddress">ipAddress used to connect the client to the server</param>
        /// <param name="port">port used to connect the client to the server</param>
        /// <param name="printTextDelegate">The print delegate to print out any messages to the user</param>
        public Client(IPAddress ipAddress, int port, PrintTextDelegate printTextDelegate)
        {
            this._printTextDelegate = printTextDelegate;

            // Combining the ipAddress and the port together in a endpoint
            var endpoint = new IPEndPoint(ipAddress, port);

            // Start a new Thread to make a connection with the server
            var t = new Thread(delegate ()
            {
                // Try to connect to the server.
                try
                {
                    var client = new TcpClient();
                    client.Connect(endpoint);
                    _stream = client.GetStream();

                    // Create a dataStream when a connection have been made
                    var dataStream = new DataStream(client, delegate(string input)
                    {
                        printTextDelegate(input);
                    });
                }
                // Cannot connect to the server we will throw a message to the user and log the error.
                catch (SocketException e)
                {
                    _printTextDelegate("We cannot connect to that server, make sure there is a server running on that IP.");
                    Console.Write(e);
                }
            });
            t.Start();
        }

        /// <summary>
        /// Sending a message to the stream. This message will be send to other users and printed out to the current client
        /// </summary>
        /// <param name="message">The message that has to be transported</param>
        public void SendMessage(string message)
        {
            var byteArray = new byte[message.Length];

            // Encoding the message to bytes for transportation
            byteArray = Encoding.ASCII.GetBytes(message);
            // Writing the bytes to the stream
            _stream.Write(byteArray, 0, byteArray.Length);
            // Printing out the message to the current user
            _printTextDelegate("<< " + message);
        }
    }
}
