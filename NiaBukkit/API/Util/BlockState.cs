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

    public enum PropertySlabType
    {
        Top,
        Bottom,
        Double
    }

    public enum PropertyChestType
    {
        Single,
        Left,
        Right
    }

    public enum PropertyBedPart
    {
        Head,
        Foot
    }

    public enum PropertyBellAttach
    {
        Floor,
        Ceiling,
        SingleWall,
        DoubleWall
    }

    public enum PropertyWallHeight
    {
        None,
        Low,
        Tall
    }

    public enum PropertyTrackPosition
    {
        NorthSouth,
        EastWest,
        AscendingEast,
        AscendingWest,
        AscendingNorth,
        AscendingSouth,
        SouthEast,
        SouthWest,
        NorthWest,
        NorthEast
    }

    public enum PropertyInstrument
    {
        Harp,
        Basedrum,
        Snare,
        Hat,
        Bass,
        Flute,
        Bell,
        Guitar,
        Chime,
        Xylophone,
        IronXylophone,
        CowBell,
        Didgeridoo,
        Bit,
        Banjo,
        Pling
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

        public static byte GetMetaSWNE(this Direction data) => data switch
        {
            Direction.South => 0,
            Direction.West => 1,
            Direction.North => 2,
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
        public static byte GetMeta(this PropertySlabType data) => data switch
        {
            PropertySlabType.Bottom => 0,
            _ => 1
        };
        
        public static byte GetMeta(this PropertyChestType data) => data switch
        {
            PropertyChestType.Single => 0,
            PropertyChestType.Right => 1,
            PropertyChestType.Left => 2,
            _ => 0
        };

        public static byte GetMeta(this PropertyBedPart data) => data switch
        {
            PropertyBedPart.Foot => 0,
            PropertyBedPart.Head => 1,
            _ => 0
        };

        public static byte GetMeta(this PropertyWallHeight data) => (byte) data;
        public static byte GetMeta(this PropertyTrackPosition data) => (byte) data;


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


        public static PropertySlabType GetState(this NBTTagCompound properties, PropertySlabType defaultValue)
        {
            var data = properties?.GetString("type");
            return data == null ? defaultValue : Enum.Parse<PropertySlabType>(data.Minecraft2Name());
        }


        public static PropertyChestType GetState(this NBTTagCompound properties, PropertyChestType defaultValue)
        {
            var data = properties?.GetString("type");
            return data == null ? defaultValue : Enum.Parse<PropertyChestType>(data.Minecraft2Name());
        }


        public static PropertyBedPart GetState(this NBTTagCompound properties, PropertyBedPart defaultValue)
        {
            var data = properties?.GetString("part");
            return data == null ? defaultValue : Enum.Parse<PropertyBedPart>(data.Minecraft2Name());
        }


        public static PropertyBellAttach GetState(this NBTTagCompound properties, PropertyBellAttach defaultValue)
        {
            var data = properties?.GetString("attachment");
            return data == null ? defaultValue : Enum.Parse<PropertyBellAttach>(data.Minecraft2Name());
        }


        public static PropertyWallHeight GetState(this NBTTagCompound properties, string key)
        {
            var data = properties?.GetString(key);
            return data == null ? PropertyWallHeight.None : Enum.Parse<PropertyWallHeight>(data.Minecraft2Name());
        }


        public static PropertyTrackPosition GetState(this NBTTagCompound properties, PropertyTrackPosition defaultValue)
        {
            var data = properties?.GetString("shape");
            return data == null ? defaultValue : Enum.Parse<PropertyTrackPosition>(data.Minecraft2Name());
        }


        public static PropertyInstrument GetState(this NBTTagCompound properties, PropertyInstrument defaultValue)
        {
            var data = properties?.GetString("instrument");
            return data == null ? defaultValue : Enum.Parse<PropertyInstrument>(data.Minecraft2Name());
        }
    }
}