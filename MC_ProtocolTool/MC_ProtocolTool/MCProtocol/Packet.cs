using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.IO;


namespace MCProtocol
{
	public class Packet : IDisposable
	{
		private List<byte> dataBuffer;
		private int dataOffset;
		private int id;
		private bool disposedValue = false;

		public int Size { get { return dataBuffer.Count; } }
		public int Length { get; set; }

		////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////
		public Packet()
		{
			dataBuffer = new List<byte>();
			dataOffset = 0;
		}

		public Packet(int id)
		{
			dataBuffer = new List<byte>();
			dataOffset = 0;
			this.id = id;
		}

		public Packet(byte[] data)
		{
			dataBuffer = new List<byte>();
			dataOffset = 0;

			dataBuffer.AddRange(data);
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
			while(((tmp = ReadByte()) & 0x80) != 0)
			{
				val |= (tmp & 0x7F) << (sz++ * 7);
				if(sz > 5)
					throw new Exception("This VarInt is too big!");
			}
			return val | ((tmp & 0x7F) << (sz * 7));
		}

		public long ReadLong()
		{
			long tmp;
			long val = 0;
			int sz = 0;
			while(((tmp = ReadByte()) & 0x80) != 0)
			{
				val |= (tmp & 0x7F) << (sz++ * 7);
				if(sz > 10)
					throw new Exception("This VarLong is too big!");
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

		public void SetID(int id)
		{
			this.id = id;
		}

		public byte[] ToArray()
		{
			return dataBuffer.ToArray();
		}

		public void Clear()
		{
			dataBuffer.Clear();
			dataOffset = 0;
		}

		protected virtual void Dispose(bool disposing)
		{
			if(!disposedValue)
			{
				if(disposing)
				{
					dataBuffer = null;
					dataOffset = 0;
				}
				disposedValue = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
