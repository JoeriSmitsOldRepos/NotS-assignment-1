using System;
using System.Windows.Forms;

namespace ChatApplication
{
    partial class ChatApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lstChat = new System.Windows.Forms.TextBox();
            this.btnListen = new System.Windows.Forms.Button();
            this.serverDetails = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.serverIpLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.serverDetails.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(1328, 6);
            this.btnSend.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(148, 48);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(6, 6);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(1306, 31);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtMessage_OnEnter);
            // 
            // lstChat
            // 
            this.lstChat.Location = new System.Drawing.Point(6, 6);
            this.lstChat.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lstChat.Multiline = true;
            this.lstChat.Name = "lstChat";
            this.lstChat.Size = new System.Drawing.Size(1478, 852);
            this.lstChat.TabIndex = 2;
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(6, 6);
            this.btnListen.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(659, 183);
            this.btnListen.TabIndex = 3;
            this.btnListen.Text = "Start a server";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this._BtnListen_Click);
            // 
            // serverDetails
            // 
            this.serverDetails.Controls.Add(this.btnConnect);
            this.serverDetails.Controls.Add(this.txtServerIP);
            this.serverDetails.Controls.Add(this.serverIpLabel);
            this.serverDetails.Location = new System.Drawing.Point(6, 201);
            this.serverDetails.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.serverDetails.Name = "serverDetails";
            this.serverDetails.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.serverDetails.Size = new System.Drawing.Size(659, 251);
            this.serverDetails.TabIndex = 4;
            this.serverDetails.TabStop = false;
            this.serverDetails.Text = "Connect to Server";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(46, 140);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(572, 56);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect to the server";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this._BtnConnect_Click);
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(332, 71);
            this.txtServerIP.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(282, 31);
            this.txtServerIP.TabIndex = 1;
            // 
            // serverIpLabel
            // 
            this.serverIpLabel.AutoSize = true;
            this.serverIpLabel.Location = new System.Drawing.Point(40, 77);
            this.serverIpLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.serverIpLabel.Name = "serverIpLabel";
            this.serverIpLabel.Size = new System.Drawing.Size(148, 25);
            this.serverIpLabel.TabIndex = 0;
            this.serverIpLabel.Text = "Chatserver IP:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.68687F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.31313F));
            this.tableLayoutPanel1.Controls.Add(this.lstChat, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 23);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.6F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(2178, 962);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 89.20378F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.79622F));
            this.tableLayoutPanel2.Controls.Add(this.txtMessage, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSend, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 894);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1482, 62);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.serverDetails, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnListen, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1501, 6);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.68293F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.31707F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(671, 458);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // ChatApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2210, 992);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "ChatApp";
            this.Text = "NotS WI - Chat Applicatie";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatApp_Closing);
            this.Load += new System.EventHandler(this.ChatApp_Load);
            this.serverDetails.ResumeLayout(false);
            this.serverDetails.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox lstChat;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.GroupBox serverDetails;
        private System.Windows.Forms.Label serverIpLabel;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}

