using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockSeagrass : BlockPlant
    {
        public BlockSeagrass(Material type) : base(type)
        {
        }

        internal override bool CanPlace(BlockPosition position) => false;
    }
}