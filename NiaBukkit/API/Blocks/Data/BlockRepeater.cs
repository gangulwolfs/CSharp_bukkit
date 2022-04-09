using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockRepeater : BlockData
    {
        //Properties=NBTTagCompound(delay="3", powered="true", facing="north", locked="true")
        public int Delay { get; private set; }
        public bool Powered { get; private set; }
        public Direction Facing { get; private set; }
        public bool Locked { get; private set; }
        
        public BlockRepeater(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockRepeater(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            var o = (BlockRepeater) block;
            o.Delay = properties.GetInt("delay");
            o.Powered = properties.GetBool("powered");
            o.Facing = properties.GetState(Direction.South);
            o.Locked = properties.GetBool("locked");
            return base.GetBlockData(block, properties);
        }

        public static bool operator ==(BlockRepeater o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockRepeater o) return false;

            return o1.Delay == o.Delay && o1.Powered == o.Powered && o1.Facing == o.Facing && o1.Locked == o.Locked && (BlockData)o1 == o;
        }

        public static bool operator !=(BlockRepeater o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            if (obj is not BlockRepeater data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("delay", new NBTTagString(Delay.ToString()));
            properties.Set("powered", new NBTTagString(Powered.ToString()));
            properties.Set("facing", new NBTTagString(Facing.ToString().Name2Minecraft()));
            properties.Set("locked", new NBTTagString(Locked.ToString()));

            return tag;
        }
        public override int GetFlatId() => base.GetFlatId() | (Delay - 1) << 2 | Facing.GetMetaSWNE();
    }
}