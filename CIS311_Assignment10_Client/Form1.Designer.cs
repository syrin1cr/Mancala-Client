namespace CIS311_Assignment10_Client
{
    partial class ClientForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label3 = new Label();
            txtMessages = new TextBox();
            txtServerIPAddress = new TextBox();
            txtServerPort = new TextBox();
            label4 = new Label();
            cmdDisconnectFromServer = new Button();
            cmdConnectToServer = new Button();
            label5 = new Label();
            btn0 = new Button();
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btn4 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btn7 = new Button();
            btn8 = new Button();
            btn9 = new Button();
            btn10 = new Button();
            btn11 = new Button();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 158);
            label3.Name = "label3";
            label3.Size = new Size(128, 15);
            label3.TabIndex = 2;
            label3.Text = "Server Status Messages";
            // 
            // txtMessages
            // 
            txtMessages.Location = new Point(12, 176);
            txtMessages.Multiline = true;
            txtMessages.Name = "txtMessages";
            txtMessages.ReadOnly = true;
            txtMessages.ScrollBars = ScrollBars.Vertical;
            txtMessages.Size = new Size(484, 134);
            txtMessages.TabIndex = 5;
            // 
            // txtServerIPAddress
            // 
            txtServerIPAddress.Location = new Point(6, 46);
            txtServerIPAddress.Name = "txtServerIPAddress";
            txtServerIPAddress.Size = new Size(166, 23);
            txtServerIPAddress.TabIndex = 6;
            txtServerIPAddress.Text = "127.0.0.1";
            // 
            // txtServerPort
            // 
            txtServerPort.Location = new Point(6, 90);
            txtServerPort.Name = "txtServerPort";
            txtServerPort.Size = new Size(166, 23);
            txtServerPort.TabIndex = 7;
            txtServerPort.Text = "1000";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 28);
            label4.Name = "label4";
            label4.Size = new Size(97, 15);
            label4.TabIndex = 8;
            label4.Text = "Server IP Address";
            // 
            // cmdDisconnectFromServer
            // 
            cmdDisconnectFromServer.Location = new Point(6, 148);
            cmdDisconnectFromServer.Name = "cmdDisconnectFromServer";
            cmdDisconnectFromServer.Size = new Size(166, 23);
            cmdDisconnectFromServer.TabIndex = 9;
            cmdDisconnectFromServer.Text = "Disconnect";
            cmdDisconnectFromServer.UseVisualStyleBackColor = true;
            cmdDisconnectFromServer.Click += cmdDisconnectFromServer_Click;
            // 
            // cmdConnectToServer
            // 
            cmdConnectToServer.Location = new Point(6, 119);
            cmdConnectToServer.Name = "cmdConnectToServer";
            cmdConnectToServer.Size = new Size(166, 23);
            cmdConnectToServer.TabIndex = 10;
            cmdConnectToServer.Text = "ConnectToServer";
            cmdConnectToServer.UseVisualStyleBackColor = true;
            cmdConnectToServer.Click += cmdConnectToServer_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 72);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 13;
            label5.Text = "Server Port";
            // 
            // btn0
            // 
            btn0.Location = new Point(82, 12);
            btn0.Name = "btn0";
            btn0.Size = new Size(64, 64);
            btn0.TabIndex = 14;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = true;
            btn0.Click += btn0_Click;
            // 
            // btn1
            // 
            btn1.Location = new Point(152, 13);
            btn1.Name = "btn1";
            btn1.Size = new Size(64, 64);
            btn1.TabIndex = 15;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += btn1_Click;
            // 
            // btn2
            // 
            btn2.Location = new Point(222, 12);
            btn2.Name = "btn2";
            btn2.Size = new Size(64, 64);
            btn2.TabIndex = 16;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += btn2_Click;
            // 
            // btn3
            // 
            btn3.Location = new Point(292, 12);
            btn3.Name = "btn3";
            btn3.Size = new Size(64, 64);
            btn3.TabIndex = 17;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += btn3_Click;
            // 
            // btn4
            // 
            btn4.Location = new Point(362, 12);
            btn4.Name = "btn4";
            btn4.Size = new Size(64, 64);
            btn4.TabIndex = 18;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += btn4_Click;
            // 
            // btn5
            // 
            btn5.Location = new Point(432, 12);
            btn5.Name = "btn5";
            btn5.Size = new Size(64, 134);
            btn5.TabIndex = 19;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = true;
            btn5.Click += btn5_Click;
            // 
            // btn6
            // 
            btn6.Location = new Point(362, 84);
            btn6.Name = "btn6";
            btn6.Size = new Size(64, 64);
            btn6.TabIndex = 20;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = true;
            btn6.Click += btn6_Click;
            // 
            // btn7
            // 
            btn7.Location = new Point(292, 84);
            btn7.Name = "btn7";
            btn7.Size = new Size(64, 64);
            btn7.TabIndex = 21;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = true;
            btn7.Click += btn7_Click;
            // 
            // btn8
            // 
            btn8.Location = new Point(222, 84);
            btn8.Name = "btn8";
            btn8.Size = new Size(64, 64);
            btn8.TabIndex = 22;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += btn8_Click;
            // 
            // btn9
            // 
            btn9.Location = new Point(152, 83);
            btn9.Name = "btn9";
            btn9.Size = new Size(64, 64);
            btn9.TabIndex = 23;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = true;
            btn9.Click += btn9_Click;
            // 
            // btn10
            // 
            btn10.Location = new Point(82, 84);
            btn10.Name = "btn10";
            btn10.Size = new Size(64, 64);
            btn10.TabIndex = 24;
            btn10.Text = "10";
            btn10.UseVisualStyleBackColor = true;
            btn10.Click += btn10_Click;
            // 
            // btn11
            // 
            btn11.Location = new Point(12, 12);
            btn11.Name = "btn11";
            btn11.Size = new Size(64, 134);
            btn11.TabIndex = 25;
            btn11.Text = "11";
            btn11.UseVisualStyleBackColor = true;
            btn11.Click += btn11_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtServerIPAddress);
            groupBox1.Controls.Add(txtServerPort);
            groupBox1.Controls.Add(cmdDisconnectFromServer);
            groupBox1.Controls.Add(cmdConnectToServer);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(502, 13);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(189, 184);
            groupBox1.TabIndex = 26;
            groupBox1.TabStop = false;
            groupBox1.Text = "Network Settings";
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(698, 323);
            Controls.Add(groupBox1);
            Controls.Add(btn11);
            Controls.Add(btn10);
            Controls.Add(btn9);
            Controls.Add(btn8);
            Controls.Add(btn7);
            Controls.Add(btn6);
            Controls.Add(btn5);
            Controls.Add(btn4);
            Controls.Add(btn3);
            Controls.Add(btn2);
            Controls.Add(btn1);
            Controls.Add(btn0);
            Controls.Add(txtMessages);
            Controls.Add(label3);
            Name = "ClientForm";
            Text = "Client";
            Load += ClientForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label3;
        private TextBox txtMessages;
        private TextBox txtServerIPAddress;
        private TextBox txtServerPort;
        private Label label4;
        private Button cmdDisconnectFromServer;
        private Button cmdConnectToServer;
        private Label label5;
        private Button btn0;
        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Button btn4;
        private Button btn5;
        private Button btn6;
        private Button btn7;
        private Button btn8;
        private Button btn9;
        private Button btn10;
        private Button btn11;
        private GroupBox groupBox1;
    }
}
