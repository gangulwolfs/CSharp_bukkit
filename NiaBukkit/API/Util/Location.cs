using System;

namespace NiaBukkit.API.Util
{
    public class Location : ICloneable
    {
        internal bool Changeable = true;

        private World.World _world;
        private double _x, _y, _z;
        private float _yaw, _pitch;

        public World.World World
        {
            get => _world;
            set
            {
                if (Changeable)
                    _world = value;
            }
        }

        public double X
        {
            get => _x;
            set
            {
                if(Changeable)
                    _x = value;
            }
        }

        public double Y
        {
            get => _y;
            set
            {
                if (Changeable)
                    _y = value;
            }
        }

        public double Z
        {
            get => _z;
            set
            {
                if (Changeable)
                    _z = value;
            }
        }

        public float Yaw
        {
            get => _yaw;
            set
            {
                if (Changeable)
                    _yaw = value;
            }
        }

        public float Pitch
        {
            get => _pitch;
            set
            {
                if (Changeable)
                    _pitch = value;
            }
        }

        public Location(World.World world, double x, double y, double z, float yaw, float pitch)
        {
            World = world;
            X = x;
            Y = y;
            Z = z;
            Yaw = yaw;
            Pitch = pitch;
        }
        public Location(World.World world, double x, double y, double z)
        {
            World = world;
            X = x;
            Y = y;
            Z = z;
            Yaw = 0;
            Pitch = 0;
        }

        public object Clone()
        {
            return new Location(World, X, Y, Z, Yaw, Pitch);
        }

        public static bool operator ==(Location loc1, Location loc2)
        {
            if (loc1 is null || loc2 is null) return loc1 is null && loc2 is null;

            return loc1.World == loc2.World && loc1.X == loc2.X && loc1.Y == loc2.Y && loc1.Z == loc2.Z && loc1.Yaw == loc2.Yaw && loc1.Pitch == loc2.Pitch;
        }

        public static bool operator !=(Location loc1, Location loc2) => !(loc1 == loc2);

        public override string ToString()
        {
            return $"Location{{{World.Name}, x={X}, y={Y}, z={Z}}}";
        }
    }
}