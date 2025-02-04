﻿using System.Text;
using NiaBukkit.API.Util;
using NiaBukkit.Network;

namespace NiaBukkit.API.NBT
{
    public class NBTTagByteArray : NBTBase
    {
        public byte[] Data { get; private set; }

        public override NBTType NBTType => NBTType.ByteArray;
        internal override void Load(ByteBuf buf, int id)
        {
            Data = buf.Read(buf.ReadInt());
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", Data)}]";
        }
    }
}