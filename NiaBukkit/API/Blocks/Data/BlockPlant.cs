using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public abstract class BlockPlant : BlockData
    {
        internal BlockPlant(Material type) : base(type)
        {
        }

        internal override bool CanPlace(BlockPosition position)
        {
            return position.Down().GetBlockData().Type switch
            {
                Material.GrassBlock => true,
                Material.Dirt => true,
                Material.CoarseDirt => true,
                Material.Podzol => true,
                Material.Farmland => true,
                _ => false
            };
        }

        public static bool operator ==(BlockPlant o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockPlant o) return false;
            return (BlockData) o1 == o;
        }

        public static bool operator !=(BlockPlant o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            if (obj is not BlockPlant data) return false;
            return this == data;
        }
    }
}