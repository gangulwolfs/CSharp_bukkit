using System;
using System.Linq;
using NiaBukkit.API.Util;
using NiaBukkit.Network;

namespace NiaBukkit.API.World.Chunks
{
    public class Chunk
    {
        public readonly ChunkCoord Coord;
        public ChunkSection[] ChunkSections { get; private set; }

        public byte[] Biomes { get; private set; } = Enumerable.Repeat<byte>(1, 256).ToArray();

        private readonly bool _isFullChunk;

        private readonly int[] _heightMap;
        
        public bool Done { get; internal set; }
        public bool InhabitedTime { get; internal set; }

        public Chunk(World world, int x, int z, bool isFullChunk = true)
        {
            Coord = new ChunkCoord(world, x, z);
            ChunkSections = new ChunkSection[16];

            _isFullChunk = isFullChunk;
            _heightMap = new int[256];

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
            for (var i = ChunkSections.Length - 1; i >= 0; i--)
            {
                mask <<= 1;
                
                if (ChunkSections[i] != null)
                    mask += 1;
            }

            return mask;
        }

        public void WriteBiomes(ByteBuf buf)
        {
            buf.Write(Biomes);
        }

        private ChunkSection GetOrCreateSection(int index)
        {
            if (ChunkSections[index] == null)
                ChunkSections[index] = new ChunkSection();

            return ChunkSections[index];
        }

        public bool IsFullChunk() => _isFullChunk;

        public void SetHeightMap(int[] heightMap)
        {
            if (_heightMap.Length != heightMap.Length)
                throw new Exception($"Could not set level chunk heightmap, array length is {heightMap.Length} instead of {_heightMap.Length}");
            
            Buffer.BlockCopy(heightMap, 0, _heightMap, 0, heightMap.Length);
        }

        public void SetChunkSections(ChunkSection[] sections)
        {
            ChunkSections = sections;
        }
    }
}