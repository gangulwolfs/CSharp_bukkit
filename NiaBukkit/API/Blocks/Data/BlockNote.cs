using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiaBukkit.API.Blocks.Data
{
    class BlockNote : BlockData
    {

        //NBTTagCompound(Properties=NBTTagCompound(note="12", powered="false", instrument="bit"), Name="minecraft:note_block")
        public int Note { get; private set; }
        public bool Powered { get; private set; }
        public PropertyInstrument Instrument { get; private set; }

        public BlockNote(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockNote(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            var o = (BlockNote)block;
            o.Note = properties.GetInt("note");
            o.Powered = properties.GetBool("powered");
            o.Instrument = properties.GetState(PropertyInstrument.Harp);

            return base.GetBlockData(block, properties);
        }

        public static bool operator ==(BlockNote o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockNote o) return false;

            return o1.Note == o.Note && o1.Powered == o.Powered && o1.Instrument == o.Instrument && (BlockData)o1 == o;
        }

        public static bool operator !=(BlockNote o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            if (obj is not BlockNote data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("note", new NBTTagString(Note.ToString()));
            properties.Set("powered", new NBTTagString(Powered.ToString()));
            properties.Set("instrument", new NBTTagString(Instrument.ToString().Name2Minecraft()));

            return tag;
        }
    }
}
