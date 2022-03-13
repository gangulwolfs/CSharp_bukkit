using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockFenceGate : BlockData
    {
        public bool InWall { get; private set; }
        public bool Powered { get; private set; }
        public Direction Facing { get; private set; }
        public bool Open { get; private set; }

        public BlockFenceGate(Material type) : base(type)
        {
        }
        

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockFenceGate(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            var o = (BlockFenceGate) block;
            o.InWall = properties.GetBool("in_wall");
            o.Powered = properties.GetBool("powered");
            o.Facing = properties.GetState(Direction.South);
            o.Open = properties.GetBool("open");
            
            return base.GetBlockData(block, properties);
        }

        public static bool operator ==(BlockFenceGate o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockFenceGate o) return false;

            return o1.InWall == o.InWall && o1.Facing == o.Facing && o1.Powered == o.Powered && o1.Open == o.Open && (BlockData) o1 == o;
        }

        public static bool operator !=(BlockFenceGate o1, BlockData o2) => !(o1 == o2);
        
        public override bool Equals(object obj)
        {
            if (obj is not BlockFenceGate data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("in_wall", new NBTTagString(InWall.ToString().ToLower()));
            properties.Set("powered", new NBTTagString(Powered.ToString()));
            properties.Set("facing", new NBTTagString(Facing.ToString()));
            properties.Set("open", new NBTTagString(Open.ToString()));
            
            return tag;
        }

        public override int GetFlatId() =>
            base.GetFlatId() | Powered.ToInt() << 3 | Open.ToInt() << 2 | Facing.GetMetaSWNE();
    }
}