using System;

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
        
        public static byte GetMeta4(this Direction data) => data switch
        {
            Direction.East => 0,
            Direction.West => 1,
            Direction.South => 2,
            Direction.North => 3,
            _ => 4
        };
        public static byte GetMetaESWN(this Direction data) => data switch
        {
            Direction.East => 0,
            Direction.South => 1,
            Direction.West => 2,
            Direction.North => 3,
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
    }
}