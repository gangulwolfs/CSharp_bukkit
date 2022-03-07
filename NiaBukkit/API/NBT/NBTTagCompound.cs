using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using NiaBukkit.Network;

namespace NiaBukkit.API.NBT
{
    public class NBTTagCompound : NBTBase
    {
        private readonly Dictionary<string, NBTBase> _data = new ();
        public ReadOnlyDictionary<string, NBTBase> Data => new(_data);

        public override NBTType NBTType => NBTType.Compound;
        
        internal override void Load(ByteBuf buf, int complexity)
        {
            if (complexity > 512)
                throw new OverflowException($"Tried to read NBT tag with too high complexity, {complexity} > 512");
            
            byte b;
            while ((b = (byte) buf.ReadByte()) != 0)
            {
                var tag = buf.ReadUtf();
                // Bukkit.ConsoleSender.SendMessage(tag);
                var nbt = LoadData(b, buf, complexity + 1);
                _data.Add(tag, nbt);
            }
        }

        private static NBTBase LoadData(byte id, ByteBuf buf, int complexity)
        {
            var nbt = CreateTag(id);
            nbt.Load(buf, complexity);

            return nbt;
        }

        public bool HasKey(string tagName)
        {
            return _data.ContainsKey(tagName);
        }

        public bool HasKeyOfType(string tagName, NBTType type)
        {
            _data.TryGetValue(tagName, out var nbt);
            return nbt?.NBTType == type;
        }

        public bool Set(string tagName, NBTBase nbt)
        {
            return _data.TryAdd(tagName, nbt);
        }

        public NBTBase Get(string tagName)
        {
            _data.TryGetValue(tagName, out var nbt);
            return nbt;
        }

        public byte GetByte(string tagName)
        {
            _data.TryGetValue(tagName, out var nbt);
            return nbt is not NBTTagByte value ? (byte) 0 : value.Data;
        }

        public short GetShort(string tagName)
        {
            _data.TryGetValue(tagName, out var nbt);
            return nbt is not NBTTagShort value ? (short) 0 : value.Data;
        }

        public int GetInt(string tagName)
        {
            _data.TryGetValue(tagName, out var nbt);
            return nbt is not NBTTagInt value ? 0 : value.Data;
        }

        public long GetLong(string tagName)
        {
            _data.TryGetValue(tagName, out var nbt);
            return nbt is not NBTTagLong value ? 0 : value.Data;
        }

        public float GetFloat(string tagName)
        {
            _data.TryGetValue(tagName, out var nbt);
            return nbt is not NBTTagFloat value ? 0 : value.Data;
        }

        public double GetDouble(string tagName)
        {
            _data.TryGetValue(tagName, out var nbt);
            return nbt is not NBTTagDouble value ? 0 : value.Data;
        }

        public string GetString(string tagName)
        {
            _data.TryGetValue(tagName, out var nbt);
            return nbt is not NBTTagString value ? "" : value.Data;
        }

        public byte[] GetByteArray(string tagName)
        {
            _data.TryGetValue(tagName, out var nbt);
            return nbt is not NBTTagByteArray value ? Array.Empty<byte>() : value.Data;
        }

        public int[] GetIntArray(string tagName)
        {
            _data.TryGetValue(tagName, out var nbt);
            return nbt is not NBTTagIntArray value ? Array.Empty<int>() : value.Data;
        }

        public long[] GetLongArray(string tagName)
        {
            _data.TryGetValue(tagName, out var nbt);
            return nbt is not NBTTagLongArray value ? Array.Empty<long>() : value.Data;
        }

        public NBTTagCompound GetCompound(string tagName)
        {
            if (!_data.TryGetValue(tagName, out var nbt))
                _data.TryAdd(tagName, nbt = new NBTTagCompound());
            return nbt is not NBTTagCompound value ? null : value;
        }

        public NBTTagList GetList(string tagName)
        {
            _data.TryGetValue(tagName, out var nbt);
            return nbt is not NBTTagList value ? new NBTTagList() : value;
        }

        public bool GetBool(string tagName)
        {
            return GetByte(tagName) != 0;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("NBTTagCompound(");
            var isFirst = true;
            foreach (var (key, value) in _data)
            {
                if (!isFirst)
                    builder.Append(", ");
                
                isFirst = false;

                builder.Append(key);
                builder.Append('=');
                builder.Append(value);
            }
            builder.Append(')');

            return builder.ToString();
        }
    }
}