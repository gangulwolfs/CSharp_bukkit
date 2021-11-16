using NiaBukkit.Network;

namespace NiaBukkit.API.NBT
{
    public class NBTBase
    {
        public virtual NBTType NBTType { get; }
        internal static NBTBase CreateTag(byte b)
        {
            return b switch
            {
                (byte) NBTType.End => new NBTTagEnd(),
                (byte) NBTType.Byte => new NBTTagByte(),
                (byte) NBTType.Short => new NBTTagShort(),
                (byte) NBTType.Int => new NBTTagInt(),
                (byte) NBTType.Long => new NBTTagLong(),
                (byte) NBTType.Float => new NBTTagFloat(),
                (byte) NBTType.Double => new NBTTagDouble(),
                (byte) NBTType.ByteArray => new NBTTagByteArray(),
                (byte) NBTType.String => new NBTTagString(),
                (byte) NBTType.List => new NBTTagList(),
                (byte) NBTType.Compound => new NBTTagCompound(),
                (byte) NBTType.IntArray => new NBTTagIntArray(),
                (byte) NBTType.LongArray => new NBTTagLongArray(),
                _ => null
            };
        }

        internal virtual void Load(ByteBuf buf, int id)
        {
        }

        internal virtual void Write(ByteBuf buf)
        {
        }
    }
}