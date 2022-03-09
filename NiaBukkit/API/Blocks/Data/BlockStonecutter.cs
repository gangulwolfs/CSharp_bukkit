using System;
using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockStonecutter : BlockData
    {
        public Direction Facing { get; private set; }
        internal BlockStonecutter(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockStonecutter(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            ((BlockStonecutter) block).Facing = Enum.Parse<Direction>(properties.GetString("facing").Minecraft2Name());
            return base.GetBlockData(block, properties);
        }

        public static bool operator ==(BlockStonecutter o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockStonecutter o) return false;
            return o1.Facing == o.Facing && (BlockData) o1 == o;
        }

        public static bool operator !=(BlockStonecutter o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            if (obj is not BlockStonecutter data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            tag.GetOrCreateCompound("Properties").Set("facing", new NBTTagString(Facing.ToString().ToLower()));
            
            return tag;
        }
    }
}