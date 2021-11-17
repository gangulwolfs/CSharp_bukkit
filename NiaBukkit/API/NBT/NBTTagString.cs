using NiaBukkit.Network;

namespace NiaBukkit.API.NBT
{
    public class NBTTagString : NBTBase
    {
        public string Data { get; private set; }
        public override NBTType NBTType => NBTType.String;
        public NBTTagString() {}

        public NBTTagString(string data)
        {
            Data = data;
        }

        internal override void Load(ByteBuf buf, int id)
        {
            Data = buf.ReadUtf();
        }

        internal override void Write(ByteBuf buf)
        {
            buf.WriteUtf(Data);
        }

        public override string ToString()
        {
            return $"\"{Data}\"";
        }
    }
}