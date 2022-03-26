using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    class BlockMushroom : BlockPlant
    {
        public BlockMushroom(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockMushroom(Type), properties);
        }

        internal override bool CanPlace(BlockPosition position)
        {
            return position.GetLightLevel() < 13 && !position.Down().GetBlockData().Type.IsTransparent();
        }
    }
}
