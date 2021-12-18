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
    }
}