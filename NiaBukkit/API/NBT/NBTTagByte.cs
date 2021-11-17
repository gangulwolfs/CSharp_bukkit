using NiaBukkit.Network;

namespace NiaBukkit.API.NBT
{
    public class NBTTagByte : NBTBase
    {
        public byte Data { get; private set; }

        public override NBTType NBTType => NBTType.Byte;

        internal override void Load(ByteBuf buf, int id)
        {
            Data = (byte) buf.ReadByte();
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}