using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public abstract class BlockWaterlogged : BlockData
    {
        public bool Waterlogged { get; private set; }
        internal BlockWaterlogged(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            ((BlockWaterlogged) block).Waterlogged = properties.GetState("waterlogged");
            return base.GetBlockData(block, properties);
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            tag.GetOrCreateCompound("Properties").Set("waterlogged", new NBTTagString(Waterlogged.ToString().ToLower()));
            
            return tag;
        }

        public static bool operator ==(BlockWaterlogged o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            
            if (o2 is not BlockWaterlogged o) return false;
            return o1.Waterlogged == o.Waterlogged && (BlockData) o1 == o;
        }

        public static bool operator !=(BlockWaterlogged o1, BlockData o2)
        {
            return !(o1 == o2);
        }
    }
}