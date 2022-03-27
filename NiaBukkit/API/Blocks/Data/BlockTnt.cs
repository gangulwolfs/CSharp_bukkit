using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    class BlockTnt : BlockData
    {
        //Properties=NBTTagCompound(unstable="false")
        public bool Unstable { get; private set; }

        public BlockTnt(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockTnt(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            ((BlockTnt)block).Unstable = properties.GetBool("unstable");
            return base.GetBlockData(block, properties);
        }

        public static bool operator ==(BlockTnt o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockTnt o) return false;

            return o1.Unstable == o.Unstable && (BlockData)o1 == o;
        }

        public static bool operator !=(BlockTnt o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            if (obj is not BlockTnt data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("unstable", new NBTTagString(Unstable.ToString().ToLower()));

            return tag;
        }
        public override int GetFlatId() => base.GetFlatId() | Unstable.ToInt();
    }
}
