using System;
using NiaBukkit.Network;

namespace NiaBukkit.API.NBT
{
    public class NBTTagLong : NBTBase
    {
        public long Data { get; private set; }
        internal override void Load(ByteBuf buf, int id)
        {
            Data = BitConverter.ToInt64(buf.Read(8));
        }
    }
}