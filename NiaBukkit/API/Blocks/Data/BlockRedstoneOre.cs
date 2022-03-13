using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockRedstoneOre : BlockOre
    {
        public bool Lit { get; private set; }
        
        public BlockRedstoneOre(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockRedstoneOre(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            ((BlockRedstoneOre) block).Lit = properties.GetBool("lit");
            
            return base.GetBlockData(block, properties);
        }

        public static bool operator ==(BlockRedstoneOre o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockRedstoneOre o) return false;

            return o1.Lit == o.Lit && (BlockOre) o1 == o;
        }

        public static bool operator !=(BlockRedstoneOre o1, BlockData o2) => !(o1 == o2);
        
        public override bool Equals(object obj)
        {
            if (obj is not BlockRedstoneOre data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("lit", new NBTTagString(Lit.ToString().ToLower()));
            
            return tag;
        }
    }
}