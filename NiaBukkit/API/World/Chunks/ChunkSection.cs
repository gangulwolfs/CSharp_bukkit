using System;
using System.Collections.Generic;
using NiaBukkit.API.Blocks;
using NiaBukkit.API.Util;
using NiaBukkit.Network;

namespace NiaBukkit.API.World.Chunks
{
    public class ChunkSection
    {
        public const int Size = 16 * 16 * 16;
        private readonly int[] _blocks = new int[Size];//Enumerable.Repeat<int>(-1, Size).ToArray();
        private readonly List<BlockData> _palette = new();
        private readonly Dictionary<BlockData, int> _inversePalette = new();

        private NibbleArray _blockLight = new(Size);
        private NibbleArray _skyLight;

        public byte YPos { get; private set; }
        
        internal static int Index(int x, int y, int z) => (y << 8) | (z << 4) | x;

        public int PaletteSize => _palette.Count;

        public ChunkSection()
        {
            GetOrCreatePaletteIndex(BlockFactory.Air);
        }

        public ChunkSection(byte yPos) : this()
        {
            YPos = yPos;
        }

        public void SetBlockLight(int x, int y, int z, byte data)
        {
            _blockLight[x, y, z] = data;
        }

        public void SetSkyLight(int x, int y, int z, byte data)
        {
            if (_skyLight == null)
                _skyLight = new NibbleArray(Size);
            
            _skyLight[x, y, z] = data;
        }

        public void SetBlockLight(byte[] data)
        {
            if (Size / 2 != data.Length)
                throw new Exception($"Block Light Length Error {data.Length} != {_blockLight.Length}");

            _blockLight = new NibbleArray(data);
        }

        public void SetSkyLight(byte[] data)
        {
            if (Size / 2 != data.Length)
                throw new Exception($"Block Light Length Error {data.Length} != {_blockLight.Length}");

            _skyLight = new NibbleArray(data);
        }

        internal void SetPaletteData(int index, BlockData data)
        {
            _palette[index] = data;
        }

        public BlockData GetPaletteFromIndex(int index)
        {
            return _palette[index];
        }
        public int GetFlatIdFromPalette(int i) => GetPaletteFromIndex(i).GetFlatId();

        public int GetOrCreatePaletteIndex(BlockData block)
        {
            var index = _inversePalette.GetValueOrDefault(block, -1);
            if (index != -1) return index;
            index = _palette.Count;
            _palette.Add(block);
            _inversePalette.Add(block, index);

            return index;
        }

        public void SetBlock(int x, int y, int z, Material block)
        {
            _blocks[Index(x, y, z)] = GetOrCreatePaletteIndex(BlockData.GetBlockDataByName(block.GetName()).GetBlockData(new NBT.NBTTagCompound()));
        }

        internal void SetBlock(int x, int y, int z, int id)
        {
            _blocks[Index(x, y, z)] = id;
        }

        internal void SetBlock(int index, int id)
        {
            _blocks[index] = id;
        }

        public byte GetLightLevel(int x, int y, int z)
        {
            var point = Index(x, y, z);

            return _skyLight != null
                ? Math.Max(_skyLight[point], _blockLight[point])
                : _blockLight[point];
        }

        public BlockData GetBlock(int x, int y, int z)
        {
            return GetBlock(Index(x, y, z));
        }

        public BlockData GetBlock(int i)
        {
            var index = _blocks[i];
            return index < 0 || index >= _palette.Count ? BlockFactory.Air : _palette[index];
        }

        internal int GetFlatId(int i) => GetBlock(i).GetFlatId();

        public int GetPaletteIndex(int x, int y, int z) => GetPaletteIndex(Index(x, y, z));

        public int GetPaletteIndex(int i)
        {
            return _blocks[i];
        }

        public void WriteBlockLight(ByteBuf buf)
        {
            buf.Write(_blockLight.Data);
        }

        public void WriteSkyLight(ByteBuf buf)
        {
            buf.Write(_skyLight.Data);
        }

        public bool HasSkyLight() => _skyLight != null;
    }
}