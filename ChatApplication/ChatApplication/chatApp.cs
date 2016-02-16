using System;
using System.Net;
using System.Windows.Forms;

namespace ChatApplication
{
    public partial class chatApp : Form
    {
        private Client client;
        private int port = 9000;

        public chatApp()
        {
            InitializeComponent();
        }

        private void _BtnListen_Click(Object sender, EventArgs e)
        {
            Server server = new Server(port);
            server.Start();
            _addTextToLstChat("Listening for a client.");

            server.ReceiveData(_addTextToLstChat);
        }

        private void _BtnConnect_Click(Object sender, EventArgs e)
        {
            _addTextToLstChat("Connecting...");

            client = new Client(IPAddress.Parse(txtServerIP.Text), port, _addTextToLstChat);
        }

        private void _BtnSend_Click(Object sender, EventArgs e)
        {
            client.SendMessage(txtMessage.Text);
            txtMessage.Text = "";
            this.ActiveControl = txtMessage;
        }

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
