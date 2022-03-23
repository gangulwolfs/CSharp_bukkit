using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    class BlockSapling : BlockPlant
    {
        //NBTTagCompound(Properties=NBTTagCompound(stage="0"), Name="minecraft:spruce_sapling")
        public int Stage { get; private set; }
        public BlockSapling(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockSapling(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            ((BlockSapling)block).Stage = properties.GetInt("stage");
            return base.GetBlockData(block, properties);
        }

        public static bool operator ==(BlockSapling o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockSapling o) return false;

            return o1.Stage == o.Stage && (BlockPlant)o1 == o;
        }

        public static bool operator !=(BlockSapling o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            if (obj is not BlockSapling data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("stage", new NBTTagString(Stage.ToString()));
            return base.ToNBT();
        }

        public override int GetFlatId() => base.GetFlatId() | Stage << 3;
    }
}
