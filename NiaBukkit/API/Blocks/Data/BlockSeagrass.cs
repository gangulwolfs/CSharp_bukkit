using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockSeagrass : BlockPlant
    {
        public BlockSeagrass(Material type) : base(type)
        {
        }

        internal override bool CanPlace(BlockPosition position) => false;

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockSeagrass(Type), properties);
        }
    }
}