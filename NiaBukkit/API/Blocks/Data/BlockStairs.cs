using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockStairs : BlockWaterlogged
    {
        public Direction Facing { get; private set; }
        public PropertyHalf Half { get; private set; }
        public PropertyShape Shape { get; private set; }
        internal BlockStairs(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockStairs(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            var stairs = (BlockStairs) block;
            stairs.Facing = properties.GetState(Direction.East);
            stairs.Half = properties.GetState(PropertyHalf.Bottom);
            stairs.Shape = properties.GetState(PropertyShape.Straight);

            return base.GetBlockData(block, properties);
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("half", new NBTTagString(Half.ToString().ToLower()));
            properties.Set("shape", new NBTTagString(Shape.ToString().Name2Minecraft()));
            properties.Set("facing", new NBTTagString(Facing.ToString().ToLower()));
            
            return tag;
        }

        public override int GetFlatId()
        {
            return Type.GetBlockId() << 4 | Half.GetMeta() << 2 | Facing.GetMetaEWSN();
        }

        public static bool operator ==(BlockStairs o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockStairs o) return false;
            return o1.Facing == o.Facing && o1.Half == o.Half && o1.Shape == o.Shape && (BlockWaterlogged) o1 == o;
        }

        public static bool operator !=(BlockStairs o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            if (obj is not BlockStairs data) return false;
            return this == data;
        }
    }
}