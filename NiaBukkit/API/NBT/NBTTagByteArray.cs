using NiaBukkit.Network;

namespace NiaBukkit.API.NBT
{
    public class NBTTagByteArray : NBTBase
    {
        public byte[] Data { get; private set; }
        internal override void Load(ByteBuf buf, int id)
        {
            Data = buf.Read(buf.ReadInt());
        }
    }
}