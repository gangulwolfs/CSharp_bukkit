namespace NiaBukkit.API.Util
{
    public class Location
    {
        public World.World World { get; internal set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        
        public Location(World.World world, double x, double y, double z)
        {
            World = world;
            X = x;
            Y = y;
            Z = z;
        }
    }
}