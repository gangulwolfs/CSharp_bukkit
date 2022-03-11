using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockBed : BlockData
    {
        public PropertyBedPart Part { get; private set; }
        public Direction Facing { get; private set; }
        public bool Occupied { get; private set; }

        public BlockBed(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockBed(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            var o = (BlockBed) block;
            o.Part = properties.GetState(PropertyBedPart.Head);
            o.Facing = properties.GetState(Direction.East);
            o.Occupied = properties.GetBool("occupied");
            return base.GetBlockData(block, properties);
        }

        public static bool operator ==(BlockBed o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockBed o) return false;

            return o1.Part == o.Part && o1.Facing == o.Facing && o1.Occupied == o.Occupied && (BlockData) o1 == o;
        }

        public static bool operator !=(BlockBed o1, BlockData o2) => !(o1 == o2);
        
        public override bool Equals(object obj)
        {
            if (obj is not BlockBed data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("part", new NBTTagString(Part.ToString().ToLower()));
            properties.Set("facing", new NBTTagString(Facing.ToString().ToLower()));
            properties.Set("occupied", new NBTTagString(Occupied.ToString().ToLower()));
            
            return tag;
        }

        public override int GetFlatId()
        {
            var baseCode = Type.GetBlockId() << 4 | Part.GetMeta() << 3 | Facing.GetMetaSWNE();
            baseCode |= Part == PropertyBedPart.Head
                ? Occupied.ToInt() << 2
                : 0;

            return baseCode;
        }
    }
}