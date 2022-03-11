using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockTall : BlockWaterlogged
    {
        public bool East { get; private set; }
        public bool South { get; private set; }
        public bool North { get; private set; }
        public bool West { get; private set; }
        
        public BlockTall(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockTall(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            var tall = (BlockTall) block;
            tall.East = properties.GetBool("east");
            tall.South = properties.GetBool("south");
            tall.North = properties.GetBool("north");
            tall.West = properties.GetBool("west");
            
            return base.GetBlockData(block, properties);
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("east", new NBTTagString(East.ToString().ToLower()));
            properties.Set("south", new NBTTagString(South.ToString().ToLower()));
            properties.Set("north", new NBTTagString(North.ToString().ToLower()));
            properties.Set("west", new NBTTagString(West.ToString().ToLower()));
            
            return tag;
        }

        public static bool operator ==(BlockTall o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            
            if (o2 is not BlockTall o) return false;
            return o.East == o1.East && o.South == o1.South && o.North == o1.North &&
                   o.West == o1.West && (BlockWaterlogged) o1 == o;
        }

        public static bool operator !=(BlockTall o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            return obj is BlockData data && this == data;
        }
    }
}