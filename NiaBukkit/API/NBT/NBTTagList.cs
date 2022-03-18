using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using NiaBukkit.API.Util;
using NiaBukkit.Network;

namespace NiaBukkit.API.NBT
{
    public class NBTTagList : NBTBase
    {
        private List<NBTBase> _data;
        public ReadOnlyCollection<NBTBase> Data => _data == null ? null : new ReadOnlyCollection<NBTBase>(_data);

        public byte Type { get; private set; }
        public int Length => _data?.Count ?? 0;
        public override NBTType NBTType => NBTType.List;

        public NBTBase this[int i] => _data[i];

        internal override void Load(ByteBuf buf, int id)
        {
            Type = (byte) buf.ReadByte();
            var length = buf.ReadInt();

            _data = new List<NBTBase>(length);
            for (var i = 0; i < length; i++)
            {
                var nbt = CreateTag(Type);
                nbt.Load(buf, id + 1);
                _data.Add(nbt);
            }
        }

        public override string ToString()
        {
            return $"{{{string.Join(", ", _data)}}}";
        }
    }
}