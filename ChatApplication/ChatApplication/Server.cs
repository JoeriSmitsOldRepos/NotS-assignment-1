using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace ChatApplication
{
    internal class Server
    {
        private readonly IPAddress _ipAddress = IPAddress.Any;
        private readonly TcpListener _server;
        private DataStream _dataStream;
        public static List<TcpClient> Clients = new List<TcpClient>();
        public delegate void PrintTextDelegate(string input);
        private readonly PrintTextDelegate _printTextDelegate;

        /// <summary>
        /// Constructor Server
        /// Greating a new IPEndpoint based on the ipAddress and port.
        /// It will also create a new TcpListener to listen for any TCP clients
        /// </summary>
        /// <param name="port">Port number the server will be running on</param>
        /// <param name="printTextDelegate">The print delegate to print out any messages to the user</param>
        public Server(int port, PrintTextDelegate printTextDelegate)
        {
            this._printTextDelegate = printTextDelegate;
            var endpoint = new IPEndPoint(_ipAddress, port);
            _server = new TcpListener(endpoint);
        }

        /// <summary>
        /// Starting up the server.
        /// We will also create a new dataStream for the server so that the user that is hosting will be able to chat
        /// </summary>
        public void Start()
        {
            // Trying if the server can be started
            try {
                _server.Start();
                _printTextDelegate("Listening for a client.");
                var t = new Thread(delegate ()
                {
                    var looping = true;
                    while(looping)
                    {
                        // Try if the server is accessible
                        try
                        {
                            // Determines if there are pending connection requests.
                            if (!_server.Pending()) continue;
                            var client = _server.AcceptTcpClient();
                            Clients.Add(client);

                            // Set-up a dataStream for every client connected to the server
                            foreach (var clientItem in Clients)
                            {
                                _dataStream = new DataStream(clientItem, delegate(string input)
                                {
                                    _printTextDelegate(input);
                                });
                            }
                        }
                        // If not then we will let the user know
                        catch (ObjectDisposedException)
                        {
                            looping = false;
                            _printTextDelegate("You have lost connection with the server.");
                        }
                    }
                });
                t.Start();
            }
            // Catching any SocketExceptions if there is already a server running on the port
            catch(SocketException e)
            {
                _printTextDelegate("Cannot create a server, because there is already a server running.");
                Console.Write(e);
                _server.Stop();
            }
        }

        /// <summary>
        /// Method to let the server (TCPListener) stop
        /// </summary>
        public void Stop()
        {
            _server.Stop();
        }

        /// <summary>
        /// Sending a message to the stream. This message will be send to other users and printed out to the current client
        /// </summary>
        /// <param name="message">The message that has to be transported</param>
        public void SendMessage(string message)
        {
            // Send the message for each client connected to the server.
            foreach (var stream in Clients.Select(client => client.GetStream()))
            {
                _dataStream.SendMessage(stream, message, true);
            }
            _printTextDelegate("<< " + message);
        }
    }
}
