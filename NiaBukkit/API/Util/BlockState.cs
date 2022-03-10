using System;
using NiaBukkit.API.NBT;

namespace NiaBukkit.API.Util
{
    public enum Direction
    {
        Down,
        Up,
        North,
        South,
        West,
        East
    }
    public enum Axis
    {
        X,
        Y,
        Z
    }

    public enum PropertyHalf
    {
        Top,
        Bottom
    }

    public enum PropertyShape
    {
        Straight,
        InnerLeft,
        InnerRight,
        OuterLeft,
        OuterRight
    }

    public enum PropertyHinge
    {
        Left,
        Right
    }

    public enum PropertyDoubleBlockHalf
    {
        Upper,
        Lower
    }

    public static class BlockStateExtensions
    {

        public static byte GetMeta3(this Direction data) => (byte) (data - Direction.South);
        
        public static byte GetMetaEWSN(this Direction data) => data switch
        {
            Direction.East => 0,
            Direction.West => 1,
            Direction.South => 2,
            Direction.North => 3,
            _ => 0
        };
        public static byte GetMetaESWN(this Direction data) => data switch
        {
            Direction.East => 0,
            Direction.South => 1,
            Direction.West => 2,
            Direction.North => 3,
            _ => 0
        };

        public static byte GetMetaNSWE(this Direction data) => data switch
        {
            Direction.North => 0,
            Direction.South => 1,
            Direction.West => 2,
            Direction.East => 3,
            _ => 0
        };

        public static byte GetMeta(this Direction data) => (byte) data;

        public static byte GetMeta(this PropertyHalf data) => data switch
        {
            PropertyHalf.Bottom => 0,
            _ => 1
        };

        public static byte GetMeta(this Axis data) => data switch
        {
            Axis.Y => 0,
            Axis.X => 1,
            _ => 2
        };
        public static byte GetMeta(this PropertyHinge data) => (byte) data;
        public static byte GetMeta(this PropertyDoubleBlockHalf data) => data switch
        {
            PropertyDoubleBlockHalf.Lower => 0,
            _ => 1
        };


        public static Direction GetState(this NBTTagCompound properties, Direction defaultValue)
        {
            var data = properties?.GetString("facing");
            return data == null ? defaultValue : Enum.Parse<Direction>(data.Minecraft2Name());
        }


        public static Axis GetState(this NBTTagCompound properties, Axis defaultValue)
        {
            var data = properties?.GetString("axis");
            return data == null ? defaultValue : Enum.Parse<Axis>(data.Minecraft2Name());
        }


        public static PropertyHalf GetState(this NBTTagCompound properties, PropertyHalf defaultValue)
        {
            var data = properties?.GetString("half");
            return data == null ? defaultValue : Enum.Parse<PropertyHalf>(data.Minecraft2Name());
        }


        public static PropertyShape GetState(this NBTTagCompound properties, PropertyShape defaultValue)
        {
            var data = properties?.GetString("shape");
            return data == null ? defaultValue : Enum.Parse<PropertyShape>(data.Minecraft2Name());
        }


        public static PropertyHinge GetState(this NBTTagCompound properties, PropertyHinge defaultValue)
        {
            var data = properties?.GetString("hinge");
            return data == null ? defaultValue : Enum.Parse<PropertyHinge>(data.Minecraft2Name());
        }


        public static PropertyDoubleBlockHalf GetState(this NBTTagCompound properties, PropertyDoubleBlockHalf defaultValue)
        {
            var data = properties?.GetString("half");
            return data == null ? defaultValue : Enum.Parse<PropertyDoubleBlockHalf>(data.Minecraft2Name());
        }


        public static bool GetState(this NBTTagCompound properties, string tag)
        {
            var data = properties?.GetString(tag);
            return data != null && bool.Parse(data);
        }
    }
}