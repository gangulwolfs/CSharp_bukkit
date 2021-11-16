using System.Collections.Generic;
using System.Collections.ObjectModel;
using NiaBukkit.Network;

namespace NiaBukkit.API.NBT
{
    public class NBTTagList : NBTBase
    {
        private List<NBTBase> _data;
        public ReadOnlyCollection<NBTBase> Data => new(_data);
        public byte Type { get; private set; }
        public int Length => Data.Count;
        public override NBTType NBTType => NBTType.List;

        public NBTBase this[int i]
        {
            get => _data[i];
        }
        
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
    }
}