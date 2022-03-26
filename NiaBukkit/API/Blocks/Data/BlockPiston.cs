using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    class BlockPiston : BlockData
    {
        //Properties=NBTTagCompound(facing="up", extended="true")
        public bool Sticky { get; }
        public Direction Facing { get; private set; }
        public bool Extended { get; private set; }
        public BlockPiston(Material type, bool sticky) : base(type)
        {
            Sticky = sticky;
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockPiston(Type, Sticky), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            var o = (BlockPiston)block;
            o.Facing = properties.GetState(Direction.Down);
            o.Extended = properties.GetBool("extended");

            return base.GetBlockData(block, properties);
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("facing", new NBTTagString(Facing.ToString().ToLower()));
            properties.Set("extended", new NBTTagString(Extended.ToString().ToLower()));

            return tag;
        }

        public static bool operator ==(BlockPiston o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockPiston o) return false;
            return o1.Facing == o.Facing && o1.Extended == o.Extended && o1.Sticky == o.Sticky && (BlockData)o1 == o;
        }

        public static bool operator !=(BlockPiston o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            if (obj is not BlockPiston data) return false;
            return this == data;
        }

        public override int GetFlatId() => base.GetFlatId() | Extended.ToInt() << 3 | Facing.GetMeta();
    }
}
