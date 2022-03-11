using NiaBukkit.API.Blocks;

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

        public BlockData GetBlockData() => World.GetBlock(X, Y, Z);
        public byte GetLightLevel() => World.GetLightLevel(X, Y, Z);

        public BlockPosition Down(int amount = 1)
        {
            return new BlockPosition(World, X, Y - amount, Z);
        }

        public BlockPosition Up(int amount = 1)
        {
            return new BlockPosition(World, X, Y + amount, Z);
        }

        public BlockPosition North(int amount = 1)
        {
            return new BlockPosition(World, X, Y, Z - amount);
        }

        public BlockPosition South(int amount = 1)
        {
            return new BlockPosition(World, X, Y, Z + amount);
        }

        public BlockPosition West(int amount = 1)
        {
            return new BlockPosition(World, X - amount, Y, Z);
        }

        public BlockPosition East(int amount = 1)
        {
            return new BlockPosition(World, X + amount, Y, Z);
        }
    }
}