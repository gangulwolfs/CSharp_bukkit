using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockLeaves : BlockData
    {
        public int Distance { get; private set; }
        public bool Persistent { get; private set; }
        internal BlockLeaves(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockLeaves(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            var o = (BlockLeaves) block;
            o.Distance = properties.GetInt("distance");
            o.Persistent = properties.GetBool("persistent");
            
            return base.GetBlockData(block, properties);
        }

        internal override bool CanPlace(BlockPosition position)
        {
            return !position.Down().GetBlockData().Type.IsTransparent();
        }

        public static bool operator ==(BlockLeaves o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockLeaves o) return false;

            return o1.Distance == o.Distance && o1.Persistent == o.Persistent && (BlockData) o1 == o;
        }

        public static bool operator !=(BlockLeaves o1, BlockData o2) => !(o1 == o2);
        
        public override bool Equals(object obj)
        {
            if (obj is not BlockLeaves data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("distance", new NBTTagString(Distance.ToString()));
            properties.Set("persistent", new NBTTagString(Persistent.ToString().ToLower()));
            
            return tag;
        }

        public override int GetFlatId() => base.GetFlatId() | Persistent.ToInt() << 2;
    }
}