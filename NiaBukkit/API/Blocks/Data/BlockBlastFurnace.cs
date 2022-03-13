using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockBlastFurnace : BlockFurnace
    {
        public BlockBlastFurnace(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockBlastFurnace(Type), properties);
        }
    }
}