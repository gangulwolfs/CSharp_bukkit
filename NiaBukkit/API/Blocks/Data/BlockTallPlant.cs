using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockTallPlant : BlockPlant
    {
        public PropertyDoubleBlockHalf Half { get; private set; }
        
        public BlockTallPlant(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockTallPlant(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            ((BlockTallPlant) block).Half = properties.GetState(PropertyDoubleBlockHalf.Upper);
            
            return base.GetBlockData(block, properties);
        }

        public static bool operator ==(BlockTallPlant o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockTallPlant o) return false;

            return o1.Half == o.Half && (BlockPlant) o1 == o;
        }

        public static bool operator !=(BlockTallPlant o1, BlockData o2) => !(o1 == o2);
        
        public override bool Equals(object obj)
        {
            if (obj is not BlockTallPlant data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("half", new NBTTagString(Half.ToString().ToLower()));
            
            return tag;
        }

        public override int GetFlatId()
        {
            return Type.GetBlockId() << 4 | Half.GetMeta() << 3 | (Half == PropertyDoubleBlockHalf.Upper
                ? 0
                : Type.GetMetaData());
        }
    }
}