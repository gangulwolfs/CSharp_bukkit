using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockCobbleWall : BlockWaterlogged
    {
        public PropertyWallHeight East { get; private set; }
        public PropertyWallHeight North { get; private set; }
        public PropertyWallHeight South { get; private set; }
        public PropertyWallHeight West { get; private set; }
        public bool Up { get; private set; }
        
        public BlockCobbleWall(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockCobbleWall(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            var o = (BlockCobbleWall) block;
            o.East = properties.GetState("east");
            o.North = properties.GetState("north");
            o.South = properties.GetState("south");
            o.West = properties.GetState("west");
            o.Up = properties.GetBool("up");
            
            return base.GetBlockData(block, properties);
        }

        internal override bool CanPlace(BlockPosition position)
        {
            return !position.Down().GetBlockData().Type.IsTransparent();
        }

        public static bool operator ==(BlockCobbleWall o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockCobbleWall o) return false;

            return o1.Up == o.Up && (BlockWaterlogged) o1 == o;
        }

        public static bool operator !=(BlockCobbleWall o1, BlockData o2) => !(o1 == o2);
        
        public override bool Equals(object obj)
        {
            if (obj is not BlockCobbleWall data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("east", new NBTTagString(East.ToString().ToLower()));
            properties.Set("north", new NBTTagString(North.ToString().ToLower()));
            properties.Set("south", new NBTTagString(South.ToString().ToLower()));
            properties.Set("west", new NBTTagString(West.ToString().ToLower()));
            properties.Set("up", new NBTTagString(Up.ToString().ToLower()));
            
            return tag;
        }
    }
}