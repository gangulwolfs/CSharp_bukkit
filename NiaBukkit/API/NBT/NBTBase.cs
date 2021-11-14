using NiaBukkit.Network;

namespace NiaBukkit.API.NBT
{
    public class NBTBase
    {
        internal static NBTBase CreateTag(byte b)
        {
            return b switch
            {
                1 => new NBTTagByte(),
                3 => new NBTTagInt(),
                4 => new NBTTagLong(),
                7 => new NBTTagByteArray(),
                9 => new NBTTagList(),
                10 => new NBTTagCompound(),
                11 => new NBTTagIntArray(),
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