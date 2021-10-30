using System;

namespace NiaBukkit.API.Util
{
    public class Location : ICloneable
    {
        public World.World World { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public float Yaw { get; set; }
        public float Pitch { get; set; }
        
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
    }
}