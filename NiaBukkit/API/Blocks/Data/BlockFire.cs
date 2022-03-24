using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;
using System;

namespace NiaBukkit.API.Blocks.Data
{
    class BlockFire : BlockData
    {
        //NBTTagCompound(Properties=NBTTagCompound(east="true", south="false", north="false", west="true", up="false", age="8"), Name="minecraft:fire")
        public bool East { get; private set; }
        public bool South { get; private set; }
        public bool North { get; private set; }
        public bool West { get; private set; }
        public int Age { get; private set; }

        public BlockFire(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockFire(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            var o = (BlockFire)block;
            o.East = properties.GetBool("east");
            o.South = properties.GetBool("south");
            o.North = properties.GetBool("north");
            o.West = properties.GetBool("west");
            o.Age = properties.GetInt("age");
            return base.GetBlockData(block, properties);
        }

        public static bool operator ==(BlockFire o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockFire o) return false;

            return o.East == o1.East && o.South == o1.South && o.North == o1.North &&
                   o.West == o1.West && o.Age == o1.Age && (BlockData)o1 == o;
        }

        public static bool operator !=(BlockFire o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            if (obj is not BlockFire data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("east", new NBTTagString(East.ToString().ToLower()));
            properties.Set("south", new NBTTagString(South.ToString().ToLower()));
            properties.Set("north", new NBTTagString(North.ToString().ToLower()));
            properties.Set("west", new NBTTagString(West.ToString().ToLower()));
            properties.Set("age", new NBTTagString(Age.ToString()));

            return tag;
        }

        public override int GetFlatId() => base.GetFlatId() | Age;
    }
}
