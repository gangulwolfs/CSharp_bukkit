using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockSlab : BlockWaterlogged
    {
        public PropertySlabType SlabType { get; private set; }

        public BlockSlab(Material type) : base(type)
        {
        }
        

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockSlab(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            ((BlockSlab) block).SlabType = properties.GetState(PropertySlabType.Bottom);
            return base.GetBlockData(block, properties);
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("type", new NBTTagString(SlabType.ToString().ToLower()));
            
            return tag;
        }

        public override int GetFlatId()
        {
            return SlabType == PropertySlabType.Double
                ? Type.GetBlockId() - 1 << 4 | Type.GetMetaData()
                : base.GetFlatId() | SlabType.GetMeta() << 3;
        } 

        public static bool operator ==(BlockSlab o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            
            if (o2 is not BlockSlab o) return false;
            return o1.SlabType == o.SlabType && (BlockWaterlogged) o1 == o;
        }

        public static bool operator !=(BlockSlab o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            if (obj is not BlockSlab data) return false;
            return this == data;
        }
    }
}