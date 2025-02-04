﻿using NiaBukkit.Network;

namespace NiaBukkit.API.NBT
{
    public class NBTTagEnd : NBTBase
    {
        public override NBTType NBTType => NBTType.End;

        public override string ToString()
        {
            return "NBTTagEnd()";
        }
    }
}