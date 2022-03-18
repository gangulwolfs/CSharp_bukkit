using System;
using NiaBukkit.API.Util;
using NiaBukkit.Network;

namespace NiaBukkit.API.NBT
{
    public class NBTTagLong : NBTBase
    {
        public long Data { get; private set; }
        public override NBTType NBTType => NBTType.Long;
        internal override void Load(ByteBuf buf, int id)
        {
            Data = buf.ReadLong();
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}