using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockFence : BlockWaterlogged
    {
        public bool East { get; private set; }
        public bool South { get; private set; }
        public bool North { get; private set; }
        public bool West { get; private set; }

        internal BlockFence(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockFence(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            var fence = (BlockFence) block;
            fence.East = bool.Parse(properties.GetString("east"));
            fence.South = bool.Parse(properties.GetString("south"));
            fence.North = bool.Parse(properties.GetString("north"));
            fence.West = bool.Parse(properties.GetString("west"));
            
            return base.GetBlockData(block, properties);
        }

        public static bool operator ==(BlockFence o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            
            if (o2 is not BlockFence fence) return false;
            return fence.East == o1.East && fence.South == o1.South && fence.North == o1.North &&
                   fence.West == o1.West && fence.Waterlogged == o1.Waterlogged && fence.Type == o1.Type;
        }

        public static bool operator !=(BlockFence o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            if (obj is not BlockFence data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetCompound("Properties");
            properties.Set("east", new NBTTagString(East.ToString().ToLower()));
            properties.Set("south", new NBTTagString(South.ToString().ToLower()));
            properties.Set("north", new NBTTagString(North.ToString().ToLower()));
            properties.Set("west", new NBTTagString(West.ToString().ToLower()));
            properties.Set("waterlogged", new NBTTagString(Waterlogged.ToString().ToLower()));
            
            return tag;
        }

        public override string ToString()
        {
            return ToNBT().ToString();
        }
    }
}