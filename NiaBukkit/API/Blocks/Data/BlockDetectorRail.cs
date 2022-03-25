using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    class BlockDetectorRail : BlockRail
    {
        //Properties=NBTTagCompound(powered="true", shape="north_south")
        public bool Powered { get; private set; }
        public BlockDetectorRail(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockDetectorRail(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            ((BlockDetectorRail)block).Powered = properties.GetBool("powered");
            return base.GetBlockData(block, properties);
        }

        public static bool operator ==(BlockDetectorRail o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockDetectorRail o) return false;

            return o1.Powered == o.Powered && (BlockRail)o1 == o;
        }

        public static bool operator !=(BlockDetectorRail o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            if (obj is not BlockDetectorRail data) return false;
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
