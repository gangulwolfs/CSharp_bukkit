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

        public override bool Equals(object? obj)
        {
            if (obj is null || !(obj is ChunkCoord)) return false;
            return (ChunkCoord) obj == this;
        }

        public override int GetHashCode()
        {
            int hash = 3;

            hash = 13 * hash + World.GetHashCode();
            hash = 19 * hash + X | X << 6;
            hash = 19 * hash + Z | Z << 6;
            
            return hash;
        }
    }
}