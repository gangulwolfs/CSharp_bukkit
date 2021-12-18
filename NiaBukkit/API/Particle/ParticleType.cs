using System.Collections.Generic;

namespace NiaBukkit.API.Particle
{
    public class ParticleType
    {
        internal static readonly Dictionary<string, ParticleType> ParticleTypes = new();
        public string Code { get; private set; }
        public bool WhatTheFuck { get; private set; }
        
        public IParticleParam ParticleParam { get; private set; }

        internal ParticleType(string code, bool a)
        {
            Code = code;
            WhatTheFuck = a;
        }

        internal ParticleType(string code, IParticleParam param)
        {
            Code = code;
            ParticleParam = param;
        }

        public static ParticleType GetSoundEffectByName(string name)
        {
            ParticleTypes.TryGetValue(name, out var effect);
            return effect;
        }
    }
}