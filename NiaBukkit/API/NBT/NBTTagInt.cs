using NiaBukkit.Network;

namespace NiaBukkit.API.NBT
{
    public class NBTTagInt : NBTBase
    {
        public int Data { get; private set; }
        internal override void Load(ByteBuf buf, int id)
        {
            Data = buf.ReadInt();
        }
    }
}