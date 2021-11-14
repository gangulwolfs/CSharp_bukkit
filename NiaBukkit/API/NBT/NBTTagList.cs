using System.Collections.Generic;
using System.Collections.ObjectModel;
using NiaBukkit.Network;

namespace NiaBukkit.API.NBT
{
    public class NBTTagList : NBTBase
    {
        private List<NBTBase> _data;
        public ReadOnlyCollection<NBTBase> Data => new(_data);
        private byte _type;
        internal override void Load(ByteBuf buf, int id)
        {
            _type = (byte) buf.ReadByte();
            var length = buf.ReadInt();

            _data = new List<NBTBase>(length);
            for (var i = 0; i < length; i++)
            {
                var nbt = CreateTag(_type);
                nbt.Load(buf, id + 1);
                _data.Add(nbt);
            }
        }
    }
}