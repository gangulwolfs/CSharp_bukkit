using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockDirtSnow : BlockData
    {
        public bool Snowy { get; private set; }
        internal BlockDirtSnow(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockDirtSnow(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            ((BlockDirtSnow) block).Snowy = properties.GetBool("snowy");
            return base.GetBlockData(block, properties);
        }

        public static bool operator ==(BlockDirtSnow o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockDirtSnow o) return false;
            return o1.Snowy == o.Snowy && (BlockData) o1 == o;
        }

        public static bool operator !=(BlockDirtSnow o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            if (obj is not BlockDirtSnow data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            tag.GetOrCreateCompound("Properties").Set("snowy", new NBTTagString(Snowy.ToString().ToLower()));
            
            return tag;
        }
    }
}