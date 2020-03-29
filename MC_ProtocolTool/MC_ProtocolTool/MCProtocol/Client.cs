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
	 * List of packet IDs - https://github.com/ammaraskar/MinecraftPacketNames/blob/master/packets.json
	 * 
	 * Ping example - https://gist.github.com/csh/2480d14fbbb33b4bbae3
	 * 
	 * In-game debug screen - https://minecraft.gamepedia.com/Debug_screen
	 * 
	 * Debug Stick - https://minecraft.gamepedia.com/Debug_Stick
	 * 
	 */

	public static class MCClient
	{
		private static TcpClient tcpClient;
		private static NetworkStream netStream;
		private static Task task;
		//private static List<byte> inputBuffer;
		//private static List<byte> outputBuffer;
		private static string hostAddress;
		private static int portNumber;
		//private static int dataOffset;

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

		public static ClientState State { get; private set; }

		public static TextBox AttatchTerminal
		{
			set { terminal = value; }
		}

		////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////
		public static void TerminalWrite(bool clientSide, string prefix, string msg)
		{
			if(terminal != null)
			{
				if(clientSide)
					terminal.AppendText("[" + DateTime.UtcNow.ToLongTimeString() + "] [Client] [" + prefix + "]  " + msg);
				else
					terminal.AppendText("[" + DateTime.UtcNow.ToLongTimeString() + "] [Server] [" + prefix + "]  " + msg);
				terminal.AppendText(Environment.NewLine);
			}
		}

		public static bool Connect(string host, int port)
		{
			if(terminal == null)
			{
				if(MessageBox.Show("Terminal is not attached.\nDo you still want to continue connecting to the server?", "Warning",
					MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
					return false;
			}
			if(State != ClientState.NotConnected)
				return false;

			hostAddress = host;
			portNumber = port;
			task = tcpClient.ConnectAsync(hostAddress, portNumber);
			State = ClientState.Connecting;

			TerminalWrite(true, "Info", "Connecting to Minecraft server..");

			while(!task.IsCompleted)
			{
				TerminalWrite(true, "Info", "Connecting..");
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
			//inputBuffer.Clear();
			//outputBuffer.Clear();
			tcpClient.Close();
			netStream.Close();
			netStream.Dispose();
		}

		public static void Ping()
		{
			if(State != ClientState.Connected)
				return;
			try
			{
				

				//TerminalWrite(true, "Info", "Handshaking server...");
				//byte[] _handshakeMsg = CreateHandshakeMsg();
				//WriteVarInt(_handshakeMsg.Length);
				//netStream.Write(_handshakeMsg, 0, _handshakeMsg.Length);

				//// request
				//netStream.WriteByte(0x01);
				//netStream.WriteByte(0x00);
				
				////byte[] buffer = new byte[short.MaxValue]; // If server has mods, use this
				//byte[] buffer = new byte[Int16.MaxValue];
				//netStream.Read(buffer, 0, buffer.Length);

				//// response
				//int sz = ReceivedBytes = ReadVarInt(buffer);
				//int packet = ReadVarInt(buffer);

				//if(packet == -1)
				//	throw new IOException("Premature end of stream");
				//if(packet != 0x00)
				//	throw new IOException("Invalid packet ID");

				//int len = ReadVarInt(buffer);

				//if(len == -1)
				//	throw new IOException("Premature end of stream");
				//if(len == 0x00)
				//	throw new IOException("Invalid string length");

				//TerminalWrite(false, "Info", "Received packet: ID = " + packet.ToString("X2") + ", length = " + len);

				//string json = ReadString(buffer, len);
				//TerminalWrite(false, "JSON data", json);

				//// ping
				//long ms = DateTime.Now.Millisecond;
				//netStream.WriteByte(0x09); // packed size
				//netStream.WriteByte(0x01); // ping
				//WriteVarLong(ms);

				// pong
				//ReadVarInt

				//inputBuffer.Clear();
			}
			catch(IOException ex)
			{
				TerminalWrite(true, "Error", ex.ToString());
			}
		}

		//private static byte[] CreateHandshakeMsg()
		{
			/* Handshake packet (ID = 0)
			 * Frame:
			 * +-----------|------------------------|---------------------|--------------|------------------+
			 * | Packet ID | Protocol Version [int] | IP address [string] | Port [short] | Next state [int] |
			 * +-----------|------------------------|---------------------|--------------|------------------+
			 */
			//netStream.WriteByte(0x00); // handshake ID
			//WriteVarInt(578);
			//WriteString(hostAddress);
			//WriteShort((short)portNumber);
			//WriteVarInt(1);

			//return inputBuffer.ToArray();
		}
		////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////
		/*
		#region Read / Write methods
		public static byte ReadByte(byte[] buffer)
		{
			var b = buffer[dataOffset];
			dataOffset++;
			return b;
		}

		public static byte[] Read(byte[] buffer, int length)
		{
			byte[] data = new byte[length];
			Array.Copy(buffer, dataOffset, data, 0, length);
			dataOffset += length;
			return data;
		}

		public static int ReadVarInt(byte[] buffer)
		{
			var value = 0;
			var size = 0;
			int b;
			while(((b = ReadByte(buffer)) & 0x80) == 0x80)
			{
				value |= (b & 0x7F) << (size++ * 7);
				if(size > 5)
					throw new Exception("This VarInt is an imposter!");
			}
			return value | ((b & 0x7F) << (size * 7));
		}

		public static long ReadVarLong(byte[] buffer)
		{
			var value = 0;
			var size = 0;
			int b;
			while(((b = ReadByte(buffer)) & 0x80) != 0)
			{
				value |= (b & 0x7F) << (size++ * 7);
				if(size > 10)
					throw new Exception("This VarLong  is an imposter!");
			} 
			return value |= (b & 0x7F) << (size++ * 7);
		}

		public static string ReadString(byte[] buffer, int length)
		{
			var data = Read(buffer, length);
			return Encoding.UTF8.GetString(data);
		}

		public static void WriteVarInt(int value)
		{
			while((value & 0x80) != 0)
			{
				inputBuffer.Add((byte)((value & 0x7F) | 0x80));
				value = (int)((uint)value) >> 7;
			}
			inputBuffer.Add((byte)value);
		}

		public static void WriteVarLong(long value)
		{
			while((value & 0x80) != 0)
			{
				inputBuffer.Add((byte)((value & 0x7F) | 0x80));
				value = (long)((ulong)value) >> 7;
			}
			inputBuffer.Add((byte)value);
		}

		public static void WriteShort(short value)
		{
			inputBuffer.AddRange(BitConverter.GetBytes(value));
		}

		public static void WriteString(string data)
		{
			var buffer = Encoding.UTF8.GetBytes(data);
			WriteVarInt(buffer.Length);
			inputBuffer.AddRange(buffer);
		}

		public static void WriteByte(byte b)
		{
			netStream.WriteByte(b);
		}

		public static void SendPacket(int id)
		{
			// https://stackoverflow.com/questions/30768091/java-sending-handshake-packets-to-minecraft-server
		}

		public static void Flush(int id = -1)
		{
			byte[] buffer = inputBuffer.ToArray();
			inputBuffer.Clear();

			var add = 0;
			var packetData = new[] { (byte)0x00 };
			if(id >= 0)
			{
				WriteVarInt(id);
				packetData = inputBuffer.ToArray();
				add = packetData.Length;
				inputBuffer.Clear();
			}

			WriteVarInt(buffer.Length + add);
			var bufferLength = inputBuffer.ToArray();
			inputBuffer.Clear();

			netStream.Write(bufferLength, 0, bufferLength.Length);
			netStream.Write(packetData, 0, packetData.Length);
			netStream.Write(buffer, 0, buffer.Length);
		}
		#endregion
		*/
		////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////
	}
}
