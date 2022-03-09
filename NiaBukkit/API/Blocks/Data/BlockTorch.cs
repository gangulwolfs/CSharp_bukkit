using NiaBukkit.API.NBT;
using NiaBukkit.API.Particle;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockTorch : BlockData
    {
        public ParticleType ParticleType { get; private set; }
        internal BlockTorch(Material type, ParticleType particleType) : base(type)
        {
            ParticleType = particleType;
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockTorch(Type, ParticleType), properties);
        }

        public static bool operator ==(BlockTorch o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockTorch o) return false;
            return o1.ParticleType == o.ParticleType && (BlockData) o1 == o;
        }

        public static bool operator !=(BlockTorch o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            if (obj is not BlockTorch data) return false;
            return this == data;
        }
    }
}