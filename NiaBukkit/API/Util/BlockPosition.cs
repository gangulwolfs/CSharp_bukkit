namespace NiaBukkit.API.Util
{
    public class BlockPosition
    {
        public readonly World.World World;
        public readonly int X, Y, Z;

        public BlockPosition(World.World world, int x, int y, int z)
        {
            World = world;
            X = x;
            Y = y;
            Z = z;
        }
    }
}