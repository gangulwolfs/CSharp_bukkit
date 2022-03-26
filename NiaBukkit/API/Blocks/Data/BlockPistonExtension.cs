using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    class BlockPistonExtension : BlockData
    {
        //Properties=NBTTagCompound(facing="east", short="true", type="sticky")
        public Direction Facing { get; private set; }
        public bool Short { get; private set; }
        public PropertyPistionType PistionType { get; private set; }
        public BlockPistonExtension(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockPistonExtension(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            var o = (BlockPistonExtension)block;
            o.Facing = properties.GetState(Direction.Down);
            o.Short = properties.GetBool("short");
            o.PistionType = properties.GetState(PropertyPistionType.Normal);

            return base.GetBlockData(block, properties);
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("facing", new NBTTagString(Facing.ToString().ToLower()));
            properties.Set("short", new NBTTagString(Short.ToString().ToLower()));
            properties.Set("type", new NBTTagString(PistionType.ToString().ToLower()));

            return tag;
        }

        public static bool operator ==(BlockPistonExtension o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockPistonExtension o) return false;
            return o1.Facing == o.Facing && o1.Short == o.Short && o1.PistionType == o.PistionType && (BlockData)o1 == o;
        }

        public static bool operator !=(BlockPistonExtension o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            if (obj is not BlockPistonExtension data) return false;
            return this == data;
        }

        public override int GetFlatId() => base.GetFlatId() | PistionType.GetMeta() << 3 | Facing.GetMeta();
    }
}
