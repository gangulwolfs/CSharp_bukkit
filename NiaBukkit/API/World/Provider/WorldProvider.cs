using NiaBukkit.API.World.Chunks;

namespace NiaBukkit.API.World.Provider
{
    public interface WorldProvider
    {
        Chunk GetChunk(int x, int z);
    }
}