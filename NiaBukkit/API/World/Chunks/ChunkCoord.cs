using System;

namespace NiaBukkit.API.World.Chunks
{
    public class ChunkCoord
    {
        public readonly World World;
        public readonly int X, Z;

        public ChunkCoord(World world, int x, int z)
        {
            World = world;
            X = x;
            Z = z;
        }
        
        public static bool operator ==(ChunkCoord c1, ChunkCoord c2)
        {
            if (c1 is null || c2 is null) return c1 is null && c2 is null;

            return c1.World == c2.World && c1.X == c2.X && c1.Z == c2.Z;
        }

        public static bool operator !=(ChunkCoord c1, ChunkCoord c2) => !(c1 == c2);

        #nullable enable
        public override bool Equals(object? obj)
        {
            if (obj is not ChunkCoord coord) return false;
            return coord == this;
        }

        public override int GetHashCode()
        {
            int hash = 3;

            hash = 13 * hash + World.GetHashCode();
            hash = 19 * hash + X | X << 6;
            hash = 19 * hash + Z | Z << 6;

            return HashCode.Combine(World, X, Z);
        }

        public override string ToString()
        {
            return $"ChunkCoord({World.Name}, {X}, {Z})";
        }

        public int DistancePow(ChunkCoord coord)
        {
            return (int) (Math.Pow(coord.X - X, 2) + Math.Pow(coord.Z - Z, 2));
        }
    }
}