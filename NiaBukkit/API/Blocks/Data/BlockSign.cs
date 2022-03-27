using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    class BlockSign : BlockWaterlogged
    {
        //Properties=NBTTagCompound(waterlogged="false", rotation="15")
        public int Rotation { get; private set; }

        public BlockSign(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockSign(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            ((BlockSign)block).Rotation = properties.GetInt("rotation");
            return base.GetBlockData(block, properties);
        }

        internal override bool CanPlace(BlockPosition position)
        {
            return !position.Down().GetBlockData().Type.IsTransparent();
        }

        public static bool operator ==(BlockSign o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockSign o) return false;

            return o1.Rotation == o.Rotation && (BlockWaterlogged)o1 == o;
        }

        public static bool operator !=(BlockSign o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            if (obj is not BlockSign data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("rotation", new NBTTagString(Rotation.ToString()));

            return tag;
        }
        public override int GetFlatId() => base.GetFlatId() | Rotation;
    }
}
