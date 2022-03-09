using System;
using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockRotatable : BlockData
    {
        public Axis Axis { get; private set; }
        
        internal BlockRotatable(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockRotatable(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            ((BlockRotatable) block).Axis = Enum.Parse<Axis>(properties.GetString("axis").ToUpper());
            return base.GetBlockData(block, properties);
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("axis", new NBTTagString(Axis.ToString().ToLower()));
            
            return tag;
        }

        public override int GetFlatId() => base.GetFlatId() | Axis.GetMeta() << 2;

        public static bool operator ==(BlockRotatable o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            
            if (o2 is not BlockRotatable o) return false;
            return o.Axis == o1.Axis && (BlockData) o1 == o;
        }

        public static bool operator !=(BlockRotatable o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            if (obj is not BlockRotatable data) return false;
            return this == data;
        }
    }
}