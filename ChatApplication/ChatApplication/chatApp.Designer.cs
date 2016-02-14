namespace ChatApplication
{
    partial class chatApp
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
            this.serverIpLabel = new System.Windows.Forms.Label();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.serverDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(705, 758);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 758);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(687, 20);
            this.txtMessage.TabIndex = 1;
            // 
            // lstChat
            // 
            this.lstChat.Location = new System.Drawing.Point(12, 12);
            this.lstChat.Multiline = true;
            this.lstChat.Name = "lstChat";
            this.lstChat.Size = new System.Drawing.Size(768, 740);
            this.lstChat.TabIndex = 2;
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(786, 12);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(315, 103);
            this.btnListen.TabIndex = 3;
            this.btnListen.Text = "btnListen";
            this.btnListen.UseVisualStyleBackColor = true;
            // 
            // serverDetails
            // 
            this.serverDetails.Controls.Add(this.btnConnect);
            this.serverDetails.Controls.Add(this.txtServerIP);
            this.serverDetails.Controls.Add(this.serverIpLabel);
            this.serverDetails.Location = new System.Drawing.Point(786, 121);
            this.serverDetails.Name = "serverDetails";
            this.serverDetails.Size = new System.Drawing.Size(315, 131);
            this.serverDetails.TabIndex = 4;
            this.serverDetails.TabStop = false;
            this.serverDetails.Text = "Connect to Server";
            // 
            // serverIpLabel
            // 
            this.serverIpLabel.AutoSize = true;
            this.serverIpLabel.Location = new System.Drawing.Point(11, 39);
            this.serverIpLabel.Name = "serverIpLabel";
            this.serverIpLabel.Size = new System.Drawing.Size(74, 13);
            this.serverIpLabel.TabIndex = 0;
            this.serverIpLabel.Text = "Chatserver IP:";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(157, 36);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(143, 20);
            this.txtServerIP.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(14, 72);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(286, 29);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "btnConnect";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // chatApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1113, 790);
            this.Controls.Add(this.serverDetails);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.lstChat);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSend);
            this.Name = "chatApp";
            this.Text = "NotS WI - Chat Applicatie";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.serverDetails.ResumeLayout(false);
            this.serverDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

