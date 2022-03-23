using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    class BlockSponge : BlockData
    {
        internal BlockSponge(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockSponge(Type), properties);
        }

        public static bool operator ==(BlockSponge o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockSponge o) return false;
            return (BlockData)o1 == o;
        }

        public static bool operator !=(BlockSponge o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            if (obj is not BlockSponge data) return false;
            return this == data;
        }
    }
}
