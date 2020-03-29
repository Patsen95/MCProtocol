namespace MC_ProtocolTool
{
	partial class Form1
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
			if(disposing && (components != null))
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
			this.Btn_ClientStartStop = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.TB_ClientPort = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.TB_ClientPassword = new System.Windows.Forms.TextBox();
			this.Btn_ClientPingServer = new System.Windows.Forms.Button();
			this.TB_ClientUsername = new System.Windows.Forms.TextBox();
			this.CB_ClientAddress = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.Btn_RandLogin = new System.Windows.Forms.Button();
			this.TB_Password = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.Btn_ClientConsoleClear = new System.Windows.Forms.Button();
			this.Lbl_Bytes = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.TB_ClientConsole = new System.Windows.Forms.TextBox();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.TB_Chatbox = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.PG_ServerProperties = new System.Windows.Forms.PropertyGrid();
			this.Btn_ServerStartStop = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.Btn_ServerConsoleSend = new System.Windows.Forms.Button();
			this.TB_ServerConsoleOut = new System.Windows.Forms.TextBox();
			this.Btn_ServerConsoleClear = new System.Windows.Forms.Button();
			this.TB_ServerConsoleIn = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// Btn_ClientStartStop
			// 
			this.Btn_ClientStartStop.Location = new System.Drawing.Point(32, 144);
			this.Btn_ClientStartStop.Name = "Btn_ClientStartStop";
			this.Btn_ClientStartStop.Size = new System.Drawing.Size(80, 40);
			this.Btn_ClientStartStop.TabIndex = 0;
			this.Btn_ClientStartStop.Text = "Start";
			this.Btn_ClientStartStop.UseVisualStyleBackColor = true;
			this.Btn_ClientStartStop.Click += new System.EventHandler(this.Btn_ClientStartStop_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Address";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(26, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Port";
			// 
			// TB_ClientPort
			// 
			this.TB_ClientPort.Location = new System.Drawing.Point(32, 40);
			this.TB_ClientPort.Name = "TB_ClientPort";
			this.TB_ClientPort.Size = new System.Drawing.Size(72, 20);
			this.TB_ClientPort.TabIndex = 4;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel2);
			this.groupBox1.Location = new System.Drawing.Point(4, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(268, 230);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Connection";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.TB_ClientPassword);
			this.panel2.Controls.Add(this.Btn_ClientPingServer);
			this.panel2.Controls.Add(this.Btn_ClientStartStop);
			this.panel2.Controls.Add(this.TB_ClientPort);
			this.panel2.Controls.Add(this.TB_ClientUsername);
			this.panel2.Controls.Add(this.CB_ClientAddress);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.Btn_RandLogin);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.TB_Password);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Location = new System.Drawing.Point(12, 22);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(244, 194);
			this.panel2.TabIndex = 12;
			// 
			// TB_ClientPassword
			// 
			this.TB_ClientPassword.Location = new System.Drawing.Point(64, 101);
			this.TB_ClientPassword.Name = "TB_ClientPassword";
			this.TB_ClientPassword.Size = new System.Drawing.Size(128, 20);
			this.TB_ClientPassword.TabIndex = 10;
			this.TB_ClientPassword.UseSystemPasswordChar = true;
			// 
			// Btn_ClientPingServer
			// 
			this.Btn_ClientPingServer.Location = new System.Drawing.Point(136, 144);
			this.Btn_ClientPingServer.Name = "Btn_ClientPingServer";
			this.Btn_ClientPingServer.Size = new System.Drawing.Size(80, 40);
			this.Btn_ClientPingServer.TabIndex = 0;
			this.Btn_ClientPingServer.Text = "Ping server";
			this.Btn_ClientPingServer.UseVisualStyleBackColor = true;
			this.Btn_ClientPingServer.Click += new System.EventHandler(this.Btn_ClientPingServer_Click);
			// 
			// TB_ClientUsername
			// 
			this.TB_ClientUsername.Location = new System.Drawing.Point(44, 69);
			this.TB_ClientUsername.Name = "TB_ClientUsername";
			this.TB_ClientUsername.Size = new System.Drawing.Size(128, 20);
			this.TB_ClientUsername.TabIndex = 8;
			// 
			// CB_ClientAddress
			// 
			this.CB_ClientAddress.FormattingEnabled = true;
			this.CB_ClientAddress.Location = new System.Drawing.Point(52, 7);
			this.CB_ClientAddress.Name = "CB_ClientAddress";
			this.CB_ClientAddress.Size = new System.Drawing.Size(136, 21);
			this.CB_ClientAddress.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(33, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Login";
			// 
			// Btn_RandLogin
			// 
			this.Btn_RandLogin.Location = new System.Drawing.Point(179, 67);
			this.Btn_RandLogin.Name = "Btn_RandLogin";
			this.Btn_RandLogin.Size = new System.Drawing.Size(56, 23);
			this.Btn_RandLogin.TabIndex = 8;
			this.Btn_RandLogin.Text = "Random";
			this.Btn_RandLogin.UseVisualStyleBackColor = true;
			this.Btn_RandLogin.Click += new System.EventHandler(this.Btn_RandLogin_Click);
			// 
			// TB_Password
			// 
			this.TB_Password.AutoSize = true;
			this.TB_Password.Location = new System.Drawing.Point(8, 104);
			this.TB_Password.Name = "TB_Password";
			this.TB_Password.Size = new System.Drawing.Size(53, 13);
			this.TB_Password.TabIndex = 9;
			this.TB_Password.Text = "Password";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.panel1);
			this.groupBox2.Controls.Add(this.TB_ClientConsole);
			this.groupBox2.Location = new System.Drawing.Point(8, 442);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(831, 192);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Console";
			// 
			// panel1
			// 
			this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.panel1.Controls.Add(this.Btn_ClientConsoleClear);
			this.panel1.Controls.Add(this.Lbl_Bytes);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Location = new System.Drawing.Point(735, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(96, 176);
			this.panel1.TabIndex = 8;
			// 
			// Btn_ClientConsoleClear
			// 
			this.Btn_ClientConsoleClear.Location = new System.Drawing.Point(0, 152);
			this.Btn_ClientConsoleClear.Name = "Btn_ClientConsoleClear";
			this.Btn_ClientConsoleClear.Size = new System.Drawing.Size(80, 23);
			this.Btn_ClientConsoleClear.TabIndex = 5;
			this.Btn_ClientConsoleClear.Text = "Clear";
			this.Btn_ClientConsoleClear.UseVisualStyleBackColor = true;
			this.Btn_ClientConsoleClear.Click += new System.EventHandler(this.Btn_ClientConsoleClear_Click);
			// 
			// Lbl_Bytes
			// 
			this.Lbl_Bytes.AutoSize = true;
			this.Lbl_Bytes.Location = new System.Drawing.Point(0, 24);
			this.Lbl_Bytes.Name = "Lbl_Bytes";
			this.Lbl_Bytes.Size = new System.Drawing.Size(35, 13);
			this.Lbl_Bytes.TabIndex = 7;
			this.Lbl_Bytes.Text = "label4";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(0, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Bytes received:";
			// 
			// TB_ClientConsole
			// 
			this.TB_ClientConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.TB_ClientConsole.Location = new System.Drawing.Point(8, 16);
			this.TB_ClientConsole.Multiline = true;
			this.TB_ClientConsole.Name = "TB_ClientConsole";
			this.TB_ClientConsole.ReadOnly = true;
			this.TB_ClientConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TB_ClientConsole.Size = new System.Drawing.Size(719, 168);
			this.TB_ClientConsole.TabIndex = 5;
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPage1);
			this.tabControl.Controls.Add(this.tabPage2);
			this.tabControl.Location = new System.Drawing.Point(8, 8);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(854, 677);
			this.tabControl.TabIndex = 7;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage1.Controls.Add(this.groupBox3);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(846, 651);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Client";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.groupBox4);
			this.groupBox3.Location = new System.Drawing.Point(304, 40);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(512, 328);
			this.groupBox3.TabIndex = 8;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Player";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.TB_Chatbox);
			this.groupBox4.Location = new System.Drawing.Point(8, 280);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(496, 40);
			this.groupBox4.TabIndex = 11;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Chat";
			// 
			// TB_Chatbox
			// 
			this.TB_Chatbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TB_Chatbox.Location = new System.Drawing.Point(8, 16);
			this.TB_Chatbox.Name = "TB_Chatbox";
			this.TB_Chatbox.Size = new System.Drawing.Size(480, 20);
			this.TB_Chatbox.TabIndex = 11;
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage2.Controls.Add(this.groupBox6);
			this.tabPage2.Controls.Add(this.groupBox5);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(846, 651);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Server [Java]";
			// 
			// groupBox6
			// 
			this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox6.Controls.Add(this.PG_ServerProperties);
			this.groupBox6.Controls.Add(this.Btn_ServerStartStop);
			this.groupBox6.Location = new System.Drawing.Point(8, 8);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(832, 360);
			this.groupBox6.TabIndex = 5;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Configuration";
			// 
			// PG_ServerProperties
			// 
			this.PG_ServerProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.PG_ServerProperties.HelpVisible = false;
			this.PG_ServerProperties.Location = new System.Drawing.Point(8, 24);
			this.PG_ServerProperties.Name = "PG_ServerProperties";
			this.PG_ServerProperties.Size = new System.Drawing.Size(392, 328);
			this.PG_ServerProperties.TabIndex = 1;
			this.PG_ServerProperties.ToolbarVisible = false;
			this.PG_ServerProperties.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PG_ServerProperties_PropertyValueChanged);
			// 
			// Btn_ServerStartStop
			// 
			this.Btn_ServerStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Btn_ServerStartStop.Location = new System.Drawing.Point(776, 304);
			this.Btn_ServerStartStop.Name = "Btn_ServerStartStop";
			this.Btn_ServerStartStop.Size = new System.Drawing.Size(48, 48);
			this.Btn_ServerStartStop.TabIndex = 0;
			this.Btn_ServerStartStop.Text = "Start";
			this.Btn_ServerStartStop.UseVisualStyleBackColor = true;
			this.Btn_ServerStartStop.Click += new System.EventHandler(this.Btn_ServerStartStop_Click);
			// 
			// groupBox5
			// 
			this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox5.Controls.Add(this.Btn_ServerConsoleSend);
			this.groupBox5.Controls.Add(this.TB_ServerConsoleOut);
			this.groupBox5.Controls.Add(this.Btn_ServerConsoleClear);
			this.groupBox5.Controls.Add(this.TB_ServerConsoleIn);
			this.groupBox5.Location = new System.Drawing.Point(8, 379);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(832, 264);
			this.groupBox5.TabIndex = 4;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Terminal";
			// 
			// Btn_ServerConsoleSend
			// 
			this.Btn_ServerConsoleSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Btn_ServerConsoleSend.Location = new System.Drawing.Point(656, 230);
			this.Btn_ServerConsoleSend.Name = "Btn_ServerConsoleSend";
			this.Btn_ServerConsoleSend.Size = new System.Drawing.Size(75, 23);
			this.Btn_ServerConsoleSend.TabIndex = 4;
			this.Btn_ServerConsoleSend.Text = "Send";
			this.Btn_ServerConsoleSend.UseVisualStyleBackColor = true;
			// 
			// TB_ServerConsoleOut
			// 
			this.TB_ServerConsoleOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.TB_ServerConsoleOut.Location = new System.Drawing.Point(8, 24);
			this.TB_ServerConsoleOut.Multiline = true;
			this.TB_ServerConsoleOut.Name = "TB_ServerConsoleOut";
			this.TB_ServerConsoleOut.ReadOnly = true;
			this.TB_ServerConsoleOut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TB_ServerConsoleOut.Size = new System.Drawing.Size(814, 192);
			this.TB_ServerConsoleOut.TabIndex = 1;
			// 
			// Btn_ServerConsoleClear
			// 
			this.Btn_ServerConsoleClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Btn_ServerConsoleClear.Location = new System.Drawing.Point(742, 230);
			this.Btn_ServerConsoleClear.Name = "Btn_ServerConsoleClear";
			this.Btn_ServerConsoleClear.Size = new System.Drawing.Size(75, 23);
			this.Btn_ServerConsoleClear.TabIndex = 3;
			this.Btn_ServerConsoleClear.Text = "Clear";
			this.Btn_ServerConsoleClear.UseVisualStyleBackColor = true;
			this.Btn_ServerConsoleClear.Click += new System.EventHandler(this.Btn_ServerConsoleClear_Click);
			// 
			// TB_ServerConsoleIn
			// 
			this.TB_ServerConsoleIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TB_ServerConsoleIn.Location = new System.Drawing.Point(8, 232);
			this.TB_ServerConsoleIn.Name = "TB_ServerConsoleIn";
			this.TB_ServerConsoleIn.Size = new System.Drawing.Size(632, 20);
			this.TB_ServerConsoleIn.TabIndex = 2;
			this.TB_ServerConsoleIn.WordWrap = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(871, 694);
			this.Controls.Add(this.tabControl);
			this.DoubleBuffered = true;
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button Btn_ClientStartStop;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox TB_ClientPort;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox TB_ClientConsole;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label Lbl_Bytes;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button Btn_ClientConsoleClear;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ComboBox CB_ClientAddress;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label TB_Password;
		private System.Windows.Forms.TextBox TB_ClientPassword;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox TB_ClientUsername;
		private System.Windows.Forms.Button Btn_RandLogin;
		private System.Windows.Forms.TextBox TB_Chatbox;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button Btn_ServerStartStop;
		private System.Windows.Forms.TextBox TB_ServerConsoleOut;
		private System.Windows.Forms.TextBox TB_ServerConsoleIn;
		private System.Windows.Forms.Button Btn_ServerConsoleClear;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Button Btn_ServerConsoleSend;
		private System.Windows.Forms.PropertyGrid PG_ServerProperties;
		private System.Windows.Forms.Button Btn_ClientPingServer;
	}
}

