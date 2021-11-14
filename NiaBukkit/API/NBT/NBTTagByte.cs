using NiaBukkit.Network;

namespace NiaBukkit.API.NBT
{
    public class NBTTagByte : NBTBase
    {
        public byte Data { get; private set; }

        internal override void Load(ByteBuf buf, int id)
        {
            Data = (byte) buf.ReadByte();
        }
    }
}