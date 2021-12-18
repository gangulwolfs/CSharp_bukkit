using System;
using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockRotatable : BlockData
    {
        public Direction Axis { get; private set; }
        
        internal BlockRotatable(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            var o = new BlockRotatable(Type)
            {
                Axis = Enum.Parse<Direction>(properties.GetString("axis").ToUpper()),
            };

            return base.GetBlockData(o);
        }

        public static bool operator ==(BlockRotatable o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            
            if (o2 is not BlockRotatable o) return false;
            return o.Axis == o1.Axis && o.Type == o1.Type;
        }

        public static bool operator !=(BlockRotatable o1, BlockData o2) => !(o1 == o2);
    }
}