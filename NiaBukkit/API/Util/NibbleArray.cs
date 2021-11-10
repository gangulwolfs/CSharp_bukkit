using NiaBukkit.API.World.Chunks;

namespace NiaBukkit.API.Util
{
    public class NibbleArray
    {
        private readonly byte[] _data;
        public byte[] Data => _data;
        public int Length => _data.Length * 2;

        public NibbleArray(int length)
        {
            _data = new byte[length / 2];
        }

        public byte this[int i]
        {
            get => (byte) (_data[i/2] >> (i % 2 * 4) & 0xF);
            set
            {
                value &= 0xF;
                _data[i / 2] &= (byte) (0xF << ((i + 1) % 2 * 4));
                _data[i / 2] |= (byte) (value << (i % 2 * 4));
            }
        }

        public byte this[int x, int y, int z]
        {
            get => this[ChunkSection.Index(x, y, z)];
            set => this[ChunkSection.Index(x, y, z)] = value;
        }

        public static explicit operator byte[](NibbleArray nibbleArray) => nibbleArray._data;
    }
}