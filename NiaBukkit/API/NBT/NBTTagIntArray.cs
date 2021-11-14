using NiaBukkit.Network;

namespace NiaBukkit.API.NBT
{
    public class NBTTagIntArray : NBTBase
    {
        public int[] Data { get; private set; }
        internal override void Load(ByteBuf buf, int id)
        {
            var length = buf.ReadInt();
            Data = new int[length];

            for (var i = 0; i < length; i++)
                Data[i] = buf.ReadInt();
        }
    }
}