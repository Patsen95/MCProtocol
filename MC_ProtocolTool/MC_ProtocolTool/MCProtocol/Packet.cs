using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.IO;


namespace MCProtocol
{
	public class Packet
	{
		private List<byte> dataBuffer;
		private int dataOffset;

		public int ID { get; set; }
		public int Size { get { return dataBuffer.Count; } }
		public byte[] Data { get { return dataBuffer.ToArray(); } }

		////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////
		public Packet()
		{
			dataBuffer = new List<byte>();
		}

		////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////
		public void WriteByte(byte value)
		{
			dataBuffer.Add(value);
		}

		public void WriteShort(short value)
		{
			dataBuffer.AddRange(BitConverter.GetBytes(value));
		}

		public void WriteInt(int value)
		{
			while((value & 0x80) != 0)
			{
				dataBuffer.Add((byte)((value & 0x7F) | 0x80));
				value = (int)((uint)value) >> 7;
			}
			dataBuffer.Add((byte)value);
		}

		public void WriteLong(long value)
		{
			while((value & 0x80) != 0)
			{
				dataBuffer.Add((byte)((value & 0x7F) | 0x80));
				value = (long)((ulong)value) >> 7;
			}
			dataBuffer.Add((byte)value);
		}

		public void WriteString(string value)
		{
			var buffer = Encoding.UTF8.GetBytes(value);
			WriteInt(buffer.Length);
			dataBuffer.AddRange(buffer);
		}
		
		public byte ReadByte()
		{
			byte buff = dataBuffer[dataOffset];
			dataOffset++;
			return buff;
		}

		public int ReadInt()
		{
			int tmp;
			int val = 0;
			int sz = 0;
			while((tmp = ReadByte() & 0x80) == 0x80)
			{
				val |= (tmp & 0x7F) << (sz++ * 7);
				if(sz > 5)
					throw new Exception("This VarInt is an imposter!");
			}
			return val | ((tmp & 0x7F) << (sz * 7));
		}

		public long ReadLong()
		{
			long tmp;
			long val = 0;
			int sz = 0;
			while((tmp = ReadByte() & 0x80) == 0x80)
			{
				val |= (tmp & 0x7F) << (sz++ * 7);
				if(sz > 10)
					throw new Exception("This VarLong is an imposter!");
			}
			return val | ((tmp & 0x7F) << (sz * 7));
		}

		public string ReadString(int length)
		{
			byte[] buff = new byte[length];
			Array.Copy(dataBuffer.ToArray(), dataOffset, buff, 0, length);
			dataOffset += length;
			return Encoding.UTF8.GetString(buff);
		}

		public void Send(NetworkStream stream)
		{
			if(dataBuffer == null || dataBuffer.Count == 0)
				throw new Exception("Data buffer is empty.");
			if(stream == null)
				throw new ArgumentNullException("stream");
			// https://stackoverflow.com/questions/30768091/java-sending-handshake-packets-to-minecraft-server
		}

		public void Read()
		{

		}
	}
}
