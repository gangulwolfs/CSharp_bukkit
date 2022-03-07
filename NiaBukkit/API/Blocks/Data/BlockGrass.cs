using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockGrass : BlockDirtSnow
    {
        public BlockGrass(Material material) : base(material)
        {
        }

        public override bool Equals(object obj)
        {
            if (obj is not BlockGrass data) return false;
            return this == data;
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockGrass(Type), properties);
        }
    }
}