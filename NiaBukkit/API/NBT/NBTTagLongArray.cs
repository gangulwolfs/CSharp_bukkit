using NiaBukkit.Network;

namespace NiaBukkit.API.NBT
{
    public class NBTTagLongArray : NBTBase
    {
        public override NBTType NBTType => NBTType.LongArray;
        public long[] Data { get; private set; }

        public NBTTagLongArray()
        {
        }

        public NBTTagLongArray(long[] data)
        {
            Data = data;
        }

        internal override void Load(ByteBuf buf, int id)
        {
            var size = buf.ReadInt();
            
            Data = new long[size];
            for (var i = 0; i < size; i++)
            {
                Data[i] = buf.ReadLong();
            }
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", Data)}]";
        }
    }
}