using System;
using System.Globalization;
using NiaBukkit.Network;

namespace NiaBukkit.API.NBT
{
    public class NBTTagDouble : NBTBase
    {
        public double Data { get; private set; }

        public override NBTType NBTType => NBTType.Double;
        
        public NBTTagDouble() {}

        public NBTTagDouble(double data)
        {
            Data = data;
        }

        internal override void Load(ByteBuf buf, int id)
        {
            // Data = BitConverter.ToDouble(buf.Read(8));
            Data = buf.ReadDouble();
        }

        public override string ToString()
        {
            return Data.ToString("F");
        }
    }
}