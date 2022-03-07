using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockLeaves : BlockData
    {
        internal BlockLeaves(Material type) : base(type)
        {
        }

        public override bool Equals(object obj)
        {
            if (obj is not BlockLeaves data) return false;
            return this == data;
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockLeaves(Type), properties);
        }
    }
}