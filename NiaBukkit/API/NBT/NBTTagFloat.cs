using System;
using NiaBukkit.Network;

namespace NiaBukkit.API.NBT
{
    public class NBTTagFloat : NBTBase
    {
        public float Data { get; private set; }

        public override NBTType NBTType => NBTType.Float;

        public NBTTagFloat()
        {
        }

        public NBTTagFloat(float data)
        {
            Data = data;
        }

        internal override void Load(ByteBuf buf, int id)
        {
            Data = buf.ReadFloat();
        }

        public override string ToString()
        {
            return Data.ToString("F");
        }
    }
}