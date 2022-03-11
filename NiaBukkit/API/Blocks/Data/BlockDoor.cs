using System;
using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockDoor : BlockData
    {
        public Direction Facing { get; private set; }
        public PropertyDoubleBlockHalf Half { get; private set; }
        public PropertyHinge Hinge { get; private set; }
        public bool Open { get; private set; }
        public bool Powered { get; private set; }
        
        internal BlockDoor(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockDoor(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            var door = (BlockDoor) block;
            door.Facing = properties.GetState(Direction.East);
            door.Half = properties.GetState(PropertyDoubleBlockHalf.Lower);
            door.Hinge = properties.GetState(PropertyHinge.Left);
            door.Open = properties.GetBool("open");
            door.Powered = properties.GetBool("powered");
            
            return base.GetBlockData(block, properties);
        }

        public static bool operator ==(BlockDoor o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockDoor o) return false;

            return o1.Facing == o.Facing && o1.Half == o.Half && o1.Hinge == o.Hinge && o1.Open == o.Open &&
                   o1.Powered == o.Powered && (BlockData) o1 == o;
        }

        public static bool operator !=(BlockDoor o1, BlockData o2) => !(o1 == o2);
        
        public override bool Equals(object obj)
        {
            if (obj is not BlockDoor data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("facing", new NBTTagString(Facing.ToString().ToLower()));
            properties.Set("half", new NBTTagString(Half.ToString().ToLower()));
            properties.Set("hinge", new NBTTagString(Hinge.ToString().ToLower()));
            properties.Set("open", new NBTTagString(Open.ToString().ToLower()));
            properties.Set("powered", new NBTTagString(Powered.ToString().ToLower()));
            
            return tag;
        }

        public override int GetFlatId()
        {
            var baseCode = base.GetFlatId() | Half.GetMeta() << 3;
            baseCode |= Half == PropertyDoubleBlockHalf.Upper
                ? Powered.ToInt() << 1 | Hinge.GetMeta()
                : Open.ToInt() << 2 | Facing.GetMetaESWN();
            
            return baseCode;
        }
        // public override int GetFlatId() => base.GetFlatId() | Half.GetMeta() << 3 | Open.ToInt() << 2 | Powered.ToInt() << 1 | Hinge.GetMeta();
    }
}