using System;
using System.Net;
using System.Windows.Forms;

namespace ChatApplication
{
    public partial class ChatApp : Form
    {
        private Client _client;
        private Server _server;
        private const int Port = 9000;

        /// <summary>
        /// Constructor ChatApp
        /// Initializing all the Form elements
        /// </summary>
        public ChatApp()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Listener for when the button is clicked to start a new server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _BtnListen_Click(object sender, EventArgs e)
        {
            _server = new Server(Port, _addTextToLstChat);
            _server.Start();
        }

        /// <summary>
        /// Listener for when the button is clicked to connect to a server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _BtnConnect_Click(object sender, EventArgs e)
        {
            // Print text to the user indicating that he is connecting to the server
            _addTextToLstChat("Connecting...");
            // Create a new client that will connect to the user defined server in txtServerIP
            _client = new Client(IPAddress.Parse(txtServerIP.Text), Port, _addTextToLstChat);
        }

        /// <summary>
        /// Listener for when the button is clicked to send a message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSend_Click(object sender, EventArgs e)
        {
            // If the server has hosted a server then we will send the message through the server's class
            // Otherwise we will send the message through the client class
            if(_server != null)
            {
                _server.SendMessage(txtMessage.Text);
            }
            else
            {
                _client.SendMessage(txtMessage.Text);
            }
            // Empty the textbox where the user can type the message after send
            txtMessage.Text = "";
            // Set the focus back on the text element to get continous typing
            this.ActiveControl = txtMessage;
        }

        /// <summary>
        /// When the user closes the form this method will be called
        /// It tries to stop the user (If there is one) and if this will not succeed due to a NullReferenceException error
        /// it will log this to the Console
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void ChatApp_Closing(object sender, FormClosingEventArgs eventArgs)
        {
            // Try to stop the server (_server cannot always be initialized)
            try
            {
                _server.Stop();
            }
            // If _server is not initialized it will log the error to the Console
            catch (NullReferenceException e)
            {
                Console.Write(e);
            }
        }

        /// <summary>
        /// If the user is focused on the TxtMessage box and hit enter this method is fired
        /// It will send the current message that is in txtMessage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtMessage_OnEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.BtnSend_Click(sender, e);
            }
        }

        /// <summary>
        /// Adds any input string to the lstChat form element. It will put every message on a seperate new line
        /// </summary>
        /// <param name="input">The input that will be printed</param>
        private void _addTextToLstChat(string input)
        {
            Invoke(new Action(() =>
            {
                lstChat.AppendText(input);
                lstChat.AppendText(Environment.NewLine);
            }));
        }
    }
}
