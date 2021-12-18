using System.Collections.Generic;

namespace NiaBukkit.API.Sounds
{
    public class SoundEffect
    {
        internal static readonly Dictionary<string, SoundEffect> SoundEffects = new();
        public string Code { get; private set; }

        internal SoundEffect(string code)
        {
            Code = code;
        }

        public static SoundEffect GetSoundEffectByName(string name)
        {
            SoundEffects.TryGetValue(name, out var effect);
            return effect;
        }
    }
}