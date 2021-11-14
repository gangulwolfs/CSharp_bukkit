using System;
using System.Collections.Generic;
using NiaBukkit.Network;

namespace NiaBukkit.API.NBT
{
    public class NBTTagCompound : NBTBase
    {
        private Dictionary<string, NBTBase> _data = new ();
        internal override void Load(ByteBuf buf, int complexity)
        {
            if (complexity > 512)
                throw new OverflowException($"Tried to read NBT tag with too high complexity, {complexity} > 512");
            
            byte b;
            while ((b = (byte) buf.ReadByte()) != 0)
            {
                var tag = buf.ReadUtf();
                Bukkit.ConsoleSender.SendMessage($"TAG NAME: {tag}");
                var nbt = LoadData(b, tag, buf, complexity + 1);
                _data.Add(tag, nbt);
            }
        }

        private static NBTBase LoadData(byte id, string tag, ByteBuf buf, int complexity)
        {
            var nbt = CreateTag(id);
            nbt.Load(buf, complexity);

            return nbt;
        }
    }
}