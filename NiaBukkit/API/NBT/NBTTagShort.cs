using System;
using NiaBukkit.API.Util;
using NiaBukkit.Network;

namespace NiaBukkit.API.NBT
{
    public class NBTTagShort : NBTBase
    {
        public short Data { get; private set; }
        public override NBTType NBTType => NBTType.Short;

        public NBTTagShort()
        {
        }

        public NBTTagShort(short data)
        {
            Data = data;
        }

        internal override void Load(ByteBuf buf, int id)
        {
            Data = buf.ReadShort();
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}