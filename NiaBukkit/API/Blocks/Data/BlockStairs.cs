using System;
using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockStairs : BlockWaterlogged
    {
        public Direction Facing { get; private set; }
        public PropertyHalf Half { get; private set; }
        public PropertyShape Shape { get; private set; }
        internal BlockStairs(BlockData data, Material type) : base(type)
        {
            SetBlockData(data);
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockStairs(this, Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            var stairs = (BlockStairs) block;
            stairs.Facing = Enum.Parse<Direction>(properties.GetString("facing").Minecraft2Name());
            stairs.Half = Enum.Parse<PropertyHalf>(properties.GetString("half").Minecraft2Name());
            stairs.Shape = Enum.Parse<PropertyShape>(properties.GetString("shape").Minecraft2Name());
            
            return base.GetBlockData(block, properties);
        }

        public static bool operator ==(BlockStairs o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockStairs o) return false;
            return o1.Facing == o.Facing && o1.Half == o.Half && o1.Shape == o.Shape && o1.Type == o.Type;
        }

        public static bool operator !=(BlockStairs o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            if (obj is not BlockStairs data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetCompound("Properties");
            properties.Set("half", new NBTTagString(Half.ToString().ToLower()));
            properties.Set("shape", new NBTTagString(Shape.ToString().ToLower()));
            properties.Set("facing", new NBTTagString(Facing.ToString().ToLower()));
            
            return tag;
        }

        public override string ToString()
        {
            return ToNBT().ToString();
        }
    }
}