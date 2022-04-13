using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockJukeBox : BlockData
    {
        public bool HasRecord { get; private set; }
        
        public BlockJukeBox(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockJukeBox(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            ((BlockJukeBox) block).HasRecord = properties.GetBool("has_record");
            return base.GetBlockData(block, properties);
        }

        public static bool operator ==(BlockJukeBox o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockJukeBox o) return false;

            return o1.HasRecord == o.HasRecord && (BlockData)o1 == o;
        }

        public static bool operator !=(BlockJukeBox o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            if (obj is not BlockJukeBox data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("has_record", new NBTTagString(HasRecord.ToString()));

            return tag;
        }
        public override int GetFlatId() => base.GetFlatId() | HasRecord.ToInt();
    }
}