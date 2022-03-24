using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    class BlockDispenser : BlockData
    {
        //NBTTagCompound(Properties=NBTTagCompound(triggered="true", facing="north"), Name="minecraft:dispenser")
        public Direction Facing { get; private set; }
        public bool Triggered { get; private set; }

        public BlockDispenser(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockDispenser(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            var o = (BlockDispenser)block;
            o.Facing = properties.GetState(Direction.Down);
            o.Triggered = properties.GetBool("triggered");
            return base.GetBlockData(block, properties);
        }

        public static bool operator ==(BlockDispenser o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockDispenser o) return false;

            return o1.Facing == o.Facing && o1.Triggered == o.Triggered && (BlockData)o1 == o;
        }

        public static bool operator !=(BlockDispenser o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            if (obj is not BlockDispenser data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("facing", new NBTTagString(Facing.ToString().ToLower()));
            properties.Set("triggered", new NBTTagString(Triggered.ToString().ToLower()));

            return tag;
        }

        public override int GetFlatId() => base.GetFlatId() | Triggered.ToInt() << 3 | Facing.GetMeta();
    }
}
