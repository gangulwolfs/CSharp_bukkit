using NiaBukkit.API.Util;
using NiaBukkit.Network;

namespace NiaBukkit.API.NBT
{
    public class NBTTagInt : NBTBase
    {
        public int Data { get; private set; }
        public override NBTType NBTType => NBTType.Int;
        internal override void Load(ByteBuf buf, int id)
        {
            Data = buf.ReadInt();
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}