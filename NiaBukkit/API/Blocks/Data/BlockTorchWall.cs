using System;
using NiaBukkit.API.NBT;
using NiaBukkit.API.Particle;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockTorchWall : BlockTorch
    {
        public Direction Facing { get; private set; }
        
        internal BlockTorchWall(Material type, ParticleType particleType) : base(type, particleType)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockTorchWall(Type, ParticleType), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            ((BlockTorchWall) block).Facing = Enum.Parse<Direction>(properties.GetString("facing").Minecraft2Name());
            return base.GetBlockData(block, properties);
        }

        public static bool operator ==(BlockTorchWall o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockTorchWall o) return false;
            return o1.ParticleType == o.ParticleType && o1.Facing == o.Facing && o1.Type == o.Type;
        }

        public static bool operator !=(BlockTorchWall o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            if (obj is not BlockTorchWall data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            tag.GetCompound("Properties").Set("facing", new NBTTagString(Facing.ToString().ToLower()));
            
            return tag;
        }

        public override string ToString()
        {
            return ToNBT().ToString();
        }
    }
}