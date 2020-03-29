using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.IO;
using System.Globalization;

using MCProtocol;


namespace MC_ProtocolTool
{
	public partial class Form1 : Form
	{
		bool isRunning;
		ServerProperties props;


		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.Text = "Minecraft Protocol Tool [1.0]";
			this.MinimumSize = this.Size;
			Btn_ClientStartStop.Text = "Start";
			CB_ClientAddress.Items.Add("localhost");
			CB_ClientAddress.Items.Add("156.17.230.23");
			CB_ClientAddress.SelectedIndex = 0;
			TB_ClientPort.Text = "25565";
			Lbl_Bytes.Text = "0";
			//tabControl.SelectedIndex = 1;
			isRunning = false;

			// Add tab page "Server [Ultra-simple emulation]"

			MCClient.AttatchTerminal = TB_ClientConsole;

			Packet p = new Packet();

			try
			{
				props = new ServerProperties();
				props.Load("bin/server.properties");
				PG_ServerProperties.PropertySort = PropertySort.Alphabetical;
				PG_ServerProperties.SelectedObject = props;
				Btn_ServerStartStop.Enabled = true;
			} catch(Exception ex)
			{
				Btn_ServerStartStop.Enabled = false;
				MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			MCClient.CloseConnection();
		}
		#region Client
		private void Btn_ClientStartStop_Click(object sender, EventArgs e)
		{
			if(CB_ClientAddress.Text == string.Empty || TB_ClientPort.Text == string.Empty)
			{
				MessageBox.Show("Wrong server IP address or port number.", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if(!MCClient.IsConnected)
			{
				Btn_ClientStartStop.Text = "Stop";
				MCClient.Connect(CB_ClientAddress.SelectedText, Convert.ToInt32(TB_ClientPort.Text));
				Lbl_Bytes.Text = MCClient.ReceivedBytes.ToString();
			}
			else
			{
				Btn_ClientStartStop.Text = "Start";
				MCClient.CloseConnection();
			}
		}

		private void Btn_ClientPingServer_Click(object sender, EventArgs e)
		{
			if(!MCClient.IsConnected)
				return;
			MCClient.Ping();
		}

		private void Btn_ClientConsoleClear_Click(object sender, EventArgs e)
		{
			TB_ClientConsole.Clear();
		}

		private void Btn_RandLogin_Click(object sender, EventArgs e)
		{
			Random rand = new Random((int)DateTime.Now.Ticks);
			TB_ClientUsername.Text = "Player" + rand.Next(1000, 9999);
		}
		#endregion
		#region Server - vanilla
		private void Btn_ServerStartStop_Click(object sender, EventArgs e)
		{
			// F:/Dysk Google/Projects/Programming/Visual/MC_ServerTest/MC_ServerTest/srv/
			//string _thisPath = AppDomain.CurrentDomain.BaseDirectory;
			string _thisPath = AppDomain.CurrentDomain.BaseDirectory + @"bin\";
			Process proc = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					WorkingDirectory = _thisPath,
					FileName = _thisPath + "StartServer.bat",
					UseShellExecute = false,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					//RedirectStandardInput = true,
					CreateNoWindow = true
				}
			};
			try
			{
				//proc.Start();

				// https://docs.microsoft.com/pl-pl/dotnet/standard/threading/creating-threads-and-passing-data-at-start-time

				ThreadStart ths = new ThreadStart(() => {
					proc.Start();

					TB_ServerConsoleOut.AppendText(proc.StandardOutput.ReadToEnd());
					TB_ServerConsoleOut.AppendText(proc.StandardError.ReadToEnd());
				});
				Thread th = new Thread(ths);
				th.Start();
				
				//proc.WaitForExit();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void Btn_ServerConsoleSend_Click(object sender, EventArgs e)
		{

		}

		private void Btn_ServerConsoleClear_Click(object sender, EventArgs e)
		{
			TB_ServerConsoleOut.Clear();
		}

		private void PG_ServerProperties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
		{
			props.Save("bin/server.properties");
		}
		#endregion
	}
}
