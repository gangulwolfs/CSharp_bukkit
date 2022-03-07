using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockGrassPath : BlockData
    {
        internal BlockGrassPath(Material type) : base(type)
        {
        }

        public override bool Equals(object obj)
        {
            if (obj is not BlockGrassPath data) return false;
            return this == data;
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockGrassPath(Type), properties);
        }
    }
}