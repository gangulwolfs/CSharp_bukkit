using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    class BlockPoweredRail : BlockRail
    {
        //Properties=NBTTagCompound(powered="false", shape="ascending_south")
        public bool Powered { get; private set; }
        public BlockPoweredRail(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockPoweredRail(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            ((BlockPoweredRail)block).Powered = properties.GetBool("powered");
            return base.GetBlockData(block, properties);
        }

        public static bool operator ==(BlockPoweredRail o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockPoweredRail o) return false;

            return o1.Powered == o.Powered && (BlockRail)o1 == o;
        }

        public static bool operator !=(BlockPoweredRail o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            if (obj is not BlockPoweredRail data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("powered", new NBTTagString(Powered.ToString()));

            return tag;
        }

        public override int GetFlatId() => base.GetFlatId() | Powered.ToInt() << 3;
    }
}
