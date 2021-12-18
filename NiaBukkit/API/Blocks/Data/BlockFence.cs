using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockFence : BlockData
    {
        public bool East { get; private set; }
        public bool South { get; private set; }
        public bool North { get; private set; }
        public bool West { get; private set; }
        public bool Waterlogged { get; private set; }

        internal BlockFence(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            var fence = new BlockFence(Type)
            {
                East = bool.Parse(properties.GetString("east")),
                South = bool.Parse(properties.GetString("south")),
                North = bool.Parse(properties.GetString("north")),
                West = bool.Parse(properties.GetString("west")),
                Waterlogged = bool.Parse(properties.GetString("waterlogged"))
            };

            return base.GetBlockData(fence);
        }

        public static bool operator ==(BlockFence o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            
            if (o2 is not BlockFence fence) return false;
            return fence.East == o1.East && fence.South == o1.South && fence.North == o1.North &&
                   fence.West == o1.West && fence.Waterlogged == o1.Waterlogged && fence.Type == o1.Type;
        }

        public static bool operator !=(BlockFence o1, BlockData o2) => !(o1 == o2);
    }
}