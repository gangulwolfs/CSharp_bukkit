﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using NiaBukkit.API.Util;

namespace NiaBukkit.Network
{
    public class ByteBuf
    {
        private byte[] readBuf;
        private List<byte> buf = new List<byte>();

        private int pos = 0;

        public bool Available => buf.Count > 0;
        public int Length => readBuf.Length - pos;
        public int WriteLength => buf.Count;
        public int Position => pos;

        public ByteBuf(byte[] data)
        {
            readBuf = data;
        }
        public ByteBuf() {}

        public static byte[] GetVarInt(int integer)
        {
            List<byte> buf = new List<byte>();
            while ((integer & -128) != 0)
            {
                buf.Add((byte) (integer & 127 | 128));
                integer = (int) ((uint) integer >> 7);
            }
            
            buf.Add((byte) integer);
            return buf.ToArray();
        }
        
        public static int ReadVarInt(NetworkStream stream)
        {
            var value = 0;
            var size = 0;
            int b;

            while (((b = stream.ReadByte()) & 0x80) == 0x80)
            {
                value |= (b & 0x7F) << (size++ * 7);
                if (size > 5)
                {
                    throw new IOException("VarInt too long.");
                }
            }

            return value | ((b & 0x7F) << (size * 7));
        }
        
        public static int ReadVarInt(byte[] data)
        {
            var value = 0;
            var size = 0;
            int b;

            while (((b = data[size]) & 0x80) == 0x80)
            {
                value |= (b & 0x7F) << (size++ * 7);
                if (size > 5)
                {
                    throw new IOException("VarInt too long.");
                }
            }

            return value | ((b & 0x7F) << (size * 7));
        }

        public int ReadByte()
        {
            return readBuf[pos++];
        }

        public byte[] Read(int length)
        {
            var buffer = new byte[length];
            Array.Copy(readBuf, pos, buffer, 0, length);
            pos += length;
            
            return buffer;
        }

        public bool ReadBool()
        {
            return ReadByte() != 0;
        }
        
        public int ReadVarInt()
        {
            var value = 0;
            var size = 0;
            int b;

            while (((b = ReadByte()) & 0x80) == 0x80)
            {
                value |= (b & 0x7F) << (size++ * 7);
                if (size > 5)
                {
                    throw new IOException("VarInt too long.");
                }
            }

            return value | ((b & 0x7F) << (size * 7));
        }

        public string ReadString()
        {
            return Encoding.UTF8.GetString(Read(ReadVarInt()));
        }

        public long ReadLong()
        {
            return IPAddress.NetworkToHostOrder(BitConverter.ToInt64(Read(8), 0));
        }

        public short ReadShort()
        {
            return IPAddress.NetworkToHostOrder(BitConverter.ToInt16(Read(2), 0));
        }

        public float ReadFloat()
        {
            return NetworkToHostOrder(BitConverter.ToSingle(Read(4), 0));
        }

        public double ReadDouble()
        {
            return NetworkToHostOrder(Read(8));
        }

        public Uuid ReadUuid()
        {
            return new Uuid(ReadLong(), ReadLong());
        }

        public void Write(byte[] data)
        {
            buf.AddRange(data);
        }

        public void WriteByte(byte b)
        {
            buf.Add(b);
        }

        public void WriteVarInt(int integer)
        {
            buf.AddRange(GetVarInt(integer));
        }

        public void WriteInt(int data)
        {
            buf.AddRange(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(data)));
        }

        public void WriteString(string data)
        {
            byte[] stringData = Encoding.UTF8.GetBytes(data);
            WriteVarInt(stringData.Length);
            buf.AddRange(stringData);
        }

        public void WriteShort(short data)
        {
            buf.AddRange(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(data)));
        }

        public void WriteUShort(ushort data)
        {
            buf.AddRange(BitConverter.GetBytes(data));
        }

        public void WriteBool(bool data)
        {
            buf.AddRange(BitConverter.GetBytes(data));
        }

        public void WriteDouble(double data)
        {
            buf.AddRange(HostToNetworkOrder(data));
        }

        public void WriteFloat(float data)
        {
            buf.AddRange(BitConverter.GetBytes(data));
            // buf.AddRange(HostToNetworkOrder(data));
        }

        public void WriteLong(long data)
        {
            // buf.AddRange(BitConverter.GetBytes(data));
            buf.AddRange(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(data)));
        }

        public void WriteUuid(Uuid uuid)
        {
            WriteLong(uuid.GetMostSignificantBits());
            WriteLong(uuid.GetLeastSignificantBits());
        }

        private byte[] HostToNetworkOrder(double d)
        {
            byte[] data = BitConverter.GetBytes(d);
            if(BitConverter.IsLittleEndian)
                Array.Reverse(data);

            return data;
        }

        private float NetworkToHostOrder(float host)
        {
            byte[] data = BitConverter.GetBytes(host);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);

            return BitConverter.ToSingle(data, 0);
        }

        private double NetworkToHostOrder(byte[] data)
        {
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(data);
            }
            return BitConverter.ToDouble(data, 0);
        }

        public byte[] Flush()
        {
            buf.InsertRange(0, GetVarInt(buf.Count));
            byte[] data = buf.ToArray();

            readBuf = null;
            buf.Clear();

            return data;
        }

        public byte[] GetBytes()
        {
            return buf.ToArray();
        }
    }
}