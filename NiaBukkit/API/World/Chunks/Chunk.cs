using System.Linq;
using NiaBukkit.API.Util;
using NiaBukkit.Network;

namespace NiaBukkit.API.World.Chunks
{
    public class Chunk
    {
        public readonly ChunkCoord Coord;
        private ChunkSection[] _sections;
        public ChunkSection[] ChunkSections => _sections;
        
        private byte[] _biomes = Enumerable.Repeat<byte>(1, 256).ToArray();
        public byte[] Biomes => _biomes;

        private readonly bool _isFullChunk;

        public Chunk(World world, int x, int z, bool isFullChunk = true)
        {
            Coord = new ChunkCoord(world, x, z);
            _sections = new ChunkSection[16];

            _isFullChunk = isFullChunk;

            // for (int i = 0; i < _sections.Length; i++)
            //     GetOrCreateSection(i);
        }

        public void SetBlockLight(int x, int y, int z, byte data)
        {
            GetOrCreateSection(y >> 4).SetBlockLight(x, y % 16, z, data);
        }

        public void SetSkyLight(int x, int y, int z, byte data)
        {
            GetOrCreateSection(y >> 4).SetSkyLight(x, y % 16, z, data);
        }

        public void SetBlock(int x, int y, int z, Material material)
        {
            GetOrCreateSection(y >> 4).SetBlock(x, y % 16, z, material);
        }

        public ushort GetBitMask()
        {
            ushort mask = 0;
            for (int i = _sections.Length - 1; i >= 0; i--)
            {
                mask <<= 1;
                
                if (_sections[i] != null)
                    mask += 1;
            }

            return mask;
        }

        public void WriteBiomes(ByteBuf buf)
        {
            buf.Write(_biomes);
        }

        private ChunkSection GetOrCreateSection(int index)
        {
            if (_sections[index] == null)
                _sections[index] = new ChunkSection();

            return _sections[index];
        }

        public bool IsFullChunk() => _isFullChunk;
    }
}