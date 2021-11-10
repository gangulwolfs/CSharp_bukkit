using NiaBukkit.API.Util;
using NiaBukkit.API.World.Chunks;

namespace NiaBukkit.API.World.Provider
{
    public class WorldProviderFlat : WorldProvider
    {
        private readonly World _world;
        private readonly byte _height;

        public WorldProviderFlat(World world, byte height = 4)
        {
            _world = world;
            _height = height;
        }
        
        public Chunk GetChunk(int posX, int posZ)
        {
            Chunk chunk = new Chunk(_world, posX, posZ);
            for (int x = 0; x < 16; x++)
            {
                for (int z = 0; z < 16; z++)
                {
                    for (int y = 0; y < 16; y++)
                    {
                        if (y == 0)
                            chunk.SetBlock(x, y, z, Material.Bedrock);
                        else if (y < _height - 1)
                            chunk.SetBlock(x, y, z, Material.Dirt);
                        else if(y == _height - 1)
                            chunk.SetBlock(x, y, z, Material.GrassBlock);
                        else
                            chunk.SetSkyLight(x, y, z, 15);
                    }
                }
            }

            return chunk;
        }
    }
}