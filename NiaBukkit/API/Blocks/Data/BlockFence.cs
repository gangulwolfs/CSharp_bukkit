using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockFence : BlockTall
    {

        internal BlockFence(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockFence(Type), properties);
        }

        public static bool operator ==(BlockFence o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            
            if (o2 is not BlockFence o) return false;
            return (BlockTall) o1 == o;
        }

        public static bool operator !=(BlockFence o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            if (obj is not BlockFence data) return false;
            return this == data;
        }
    }
}