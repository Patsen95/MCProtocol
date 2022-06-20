using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.IO;


namespace MCProtocol
{
	/*
	 * Minectaft Protocole Wiki - https://wiki.vg/Protocol
	 * 
	 * SLP - https://wiki.vg/Server_List_Ping
	 * 
	 * List of packet IDs - https://github.com/ammaraskar/MinecraftPacketNames/blob/master/packets.json
	 * 
	 * Ping example - https://gist.github.com/csh/2480d14fbbb33b4bbae3
	 * 
	 * In-game debug screen - https://minecraft.gamepedia.com/Debug_screen
	 * 
	 * "Debug Stick" - https://minecraft.gamepedia.com/Debug_Stick
	 * 
	 */

	public static class MCClient
	{
		private static TcpClient tcpClient = new TcpClient();
		private static NetworkStream netStream;
		private static Task task;
		private static string hostAddress;
		private static int portNumber;

		private static TextBox terminal;

		////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////
		public enum ClientState
		{
			NotConnected = -1,
			Connecting,
			Connected,
		}

		public static int DefaultPort
		{
			get { return 25565; }
		}

		public static bool IsConnected
		{
			get
			{
				if(State == ClientState.Connected)
					return true;
				return false;
			}
		}

		public static int ReceivedBytes { get; private set; }

		public static ClientState State { get; private set; } = ClientState.NotConnected;

		public static TextBox AttatchTerminal
		{
			set { terminal = value; }
		}

		////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////
		public static void TerminalWrite(bool clientSide, string prefix, string msg)
		{
			if(clientSide)
				terminal.AppendText("[" + DateTime.UtcNow.ToLongTimeString() + "] [Client] [" + prefix + "]  " + msg);
			else
				terminal.AppendText("[" + DateTime.UtcNow.ToLongTimeString() + "] [Server] [" + prefix + "]  " + msg);
			terminal.AppendText(Environment.NewLine);
		}

		public static bool Connect(string host, int port)
		{
			if(terminal == null)
			{
				if(MessageBox.Show("Terminal is not attached.\nDo you still want to continue connecting to the server?", "Warning",
					MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
					return false;
			}
			hostAddress = host;
			portNumber = port;
			tcpClient = new TcpClient();
			task = tcpClient.ConnectAsync(hostAddress, portNumber);
			State = ClientState.Connecting;

			TerminalWrite(true, "Info", "Connecting to Minecraft server..");

			while(!task.IsCompleted)
			{
				TerminalWrite(true, "Info", "Connecting...");
				Thread.Sleep(250);
			}

			if(!tcpClient.Connected)
			{
				TerminalWrite(true, "Info", "Unable to connect to the server");
				State = ClientState.NotConnected;
				tcpClient.Dispose();
				return false;
			}
			TerminalWrite(true, "Info", "Connection established");
			State = ClientState.Connected;
			netStream = tcpClient.GetStream();
			return true;
		}

		public static void CloseConnection()
		{
			if(State != ClientState.Connected)
				return;
			TerminalWrite(true, "Info", "Disconnected");
			State = ClientState.NotConnected;
			task.Dispose();
			tcpClient.Close();
			netStream.Close();
		}

		public static void Ping()
		{
			if(State != ClientState.Connected)
				return;
			//netStream = tcpClient.GetStream();
			try
			{
				/**
				TerminalWrite(true, "Info", "Handshaking server...");
				byte[] _handshakeMsg = CreateHandshakeMsg();
				WriteVarInt(_handshakeMsg.Length);
				netStream.Write(_handshakeMsg, 0, _handshakeMsg.Length);

				// request
				netStream.WriteByte(0x01);
				netStream.WriteByte(0x00);
				
				//byte[] buffer = new byte[short.MaxValue]; // If server has mods, use this
				byte[] buffer = new byte[Int16.MaxValue];
				netStream.Read(buffer, 0, buffer.Length);

				// response
				int sz = ReceivedBytes = ReadVarInt(buffer);
				int packet = ReadVarInt(buffer);

				if(packet == -1)
					throw new IOException("Premature end of stream");
				if(packet != 0x00)
					throw new IOException("Invalid packet ID");

				int len = ReadVarInt(buffer);

				if(len == -1)
					throw new IOException("Premature end of stream");
				if(len == 0x00)
					throw new IOException("Invalid string length");

				TerminalWrite(false, "Info", "Received packet: ID = " + packet.ToString("X2") + ", length = " + len);

				string json = ReadString(buffer, len);
				TerminalWrite(false, "JSON data", json);

				// ping
				long ms = DateTime.Now.Millisecond;
				netStream.WriteByte(0x09); // packed size
				netStream.WriteByte(0x01); // ping
				WriteVarLong(ms);

				// pong
				// ReadVarInt

				inputBuffer.Clear();
				*/

				/* Handshake packet (ID = 0)
				 * Frame:
				 * +------------------------|---------------------|--------------|------------------+
				 * | Protocol Version [int] | IP address [string] | Port [short] | Next state [int] |
				 * +------------------------|---------------------|--------------|------------------+
				 */

				// Handshaking
				Packet hsPacket = new Packet();
				hsPacket.WriteInt(578); // Procotol version
				hsPacket.WriteString(hostAddress); // IP address
				hsPacket.WriteShort((short)portNumber); // port number
				hsPacket.WriteInt(1); // State = 1 - status
				hsPacket.Send(netStream);

				// Request
				netStream.WriteByte(0x01); // size = 1 byte
				netStream.WriteByte(0x00); // ID = 0

				// Read server answer
				hsPacket.Read(netStream);
				int size = hsPacket.ReadInt();
				int packId = hsPacket.ReadInt();
				int strLen = hsPacket.ReadInt();
				string str = hsPacket.ReadString(strLen);

				hsPacket.Clear();
				hsPacket.SetID(0x01);
				hsPacket.WriteLong(123);
				hsPacket.Send(netStream);

				hsPacket.Read(netStream);
				long msSrv = hsPacket.ReadInt();
				
				TerminalWrite(true, "Info", "Size = " + size);
				TerminalWrite(true, "Info", "ID = " + packId);
				TerminalWrite(true, "Info", "Len = " + strLen);
				TerminalWrite(true, "Info", str);
				TerminalWrite(true, "Pong", hsPacket.ToString());
				
			}
			catch(IOException ex)
			{
				TerminalWrite(true, "Error", ex.ToString());
			}
		}


		public void Send(NetworkStream netStream)
		{
			if(netStream == null)
				throw new ArgumentNullException("stream");
			if(id < 0)
				throw new Exception("Unknown packet ID");

			// Packet data
			byte[] dataBuff = ToArray();
			dataBuffer.Clear();

			// Converting ID to VarInt
			WriteInt(id);
			byte[] idData = ToArray();
			dataBuffer.Clear();

			// Converting packet size to VarInt
			int packetLength = dataBuff.Length + idData.Length;
			WriteInt(packetLength);
			byte[] dataLength = ToArray();
			dataBuffer.Clear();

			// Sending data in order
			netStream.Write(dataLength, 0, dataLength.Length);
			netStream.Write(idData, 0, idData.Length);
			netStream.Write(dataBuff, 0, dataBuff.Length);
		}

		public void Read(NetworkStream netStream)
		{
			if(netStream == null)
				throw new ArgumentNullException("stream");

			byte[] data = new byte[bufferSize];
			netStream.Read(data, 0, dataBuffer.Capacity);
			dataBuffer = data.ToList();
		}

		// https://stackoverflow.com/questions/30768091/java-sending-handshake-packets-to-minecraft-server

		// https://github.com/tom-weiland/tcp-udp-networking/blob/tutorial-part2/GameServer/GameServer/Packet.cs
	}
}
