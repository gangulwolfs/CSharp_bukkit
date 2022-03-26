using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    class BlockRedstoneWire : BlockData
    {
        //Properties=NBTTagCompound(east="up", south="up", north="up", west="none", power="0")
        public PropertyRedstoneSide East { get; private set; }
        public PropertyRedstoneSide South { get; private set; }
        public PropertyRedstoneSide North { get; private set; }
        public PropertyRedstoneSide West { get; private set; }
        public int Power { get; private set; }
        public BlockRedstoneWire(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockRedstoneWire(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            var o = (BlockRedstoneWire)block;
            o.East = properties.GetRedstoneState("east");
            o.South = properties.GetRedstoneState("south");
            o.North = properties.GetRedstoneState("north");
            o.West = properties.GetRedstoneState("west");
            o.Power = properties.GetInt("power");

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
            properties.Set("power", new NBTTagString(Power.ToString()));

            return tag;
        }

        public static bool operator ==(BlockRedstoneWire o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockRedstoneWire o) return false;
            return o1.East == o.East && o1.South == o.South && o1.North == o.North && o1.West == o.West && o1.Power == o.Power && (BlockData)o1 == o;
        }

        public static bool operator !=(BlockRedstoneWire o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            if (obj is not BlockRedstoneWire data) return false;
            return this == data;
        }

        public override int GetFlatId() => base.GetFlatId() | Power;
    }
}
