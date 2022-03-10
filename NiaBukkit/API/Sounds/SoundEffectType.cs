namespace NiaBukkit.API.Sounds
{
    public class SoundEffectType
    {
        public static readonly SoundEffectType GrassEffect = new(1, 1, SoundEffects.BlockGrassBreak,
            SoundEffects.BlockGrassStep, SoundEffects.BlockGrassPlace, SoundEffects.BlockGrassHit,
            SoundEffects.BlockGrassFall);

        public static readonly SoundEffectType DirtEffect = new(1, 1, SoundEffects.BlockGravelBreak,
            SoundEffects.BlockGravelStep, SoundEffects.BlockGravelPlace, SoundEffects.BlockGravelHit,
            SoundEffects.BlockGravelFall);

        public static readonly SoundEffectType WoodEffect = new(1, 1, SoundEffects.BlockWoodBreak,
            SoundEffects.BlockWoodStep, SoundEffects.BlockWoodPlace, SoundEffects.BlockWoodHit,
            SoundEffects.BlockWoodFall);

        public static readonly SoundEffectType WoolEffect = new(1, 1, SoundEffects.BlockWoolBreak,
            SoundEffects.BlockWoolStep, SoundEffects.BlockWoolPlace, SoundEffects.BlockWoolHit,
            SoundEffects.BlockWoolFall);

        public static readonly SoundEffectType GlassEffect = new(1, 1, SoundEffects.BlockGlassBreak,
            SoundEffects.BlockGlassStep, SoundEffects.BlockGlassPlace, SoundEffects.BlockGlassHit,
            SoundEffects.BlockGlassFall);

        public static readonly SoundEffectType MetalEffect = new(1, 1.5F, SoundEffects.BlockMetalBreak,
            SoundEffects.BlockMetalStep, SoundEffects.BlockMetalPlace, SoundEffects.BlockMetalHit,
            SoundEffects.BlockMetalFall);

        public static readonly SoundEffectType GravelEffect = new(1, 1, SoundEffects.BlockGravelBreak,
            SoundEffects.BlockGravelStep, SoundEffects.BlockGravelPlace, SoundEffects.BlockGravelHit,
            SoundEffects.BlockGravelFall);

        public static readonly SoundEffectType NetherBricksEffect = new(1, 1, SoundEffects.BlockNetherBricksBreak,
            SoundEffects.BlockNetherBricksStep, SoundEffects.BlockNetherBricksPlace, SoundEffects.BlockNetherBricksHit,
            SoundEffects.BlockNetherBricksFall);

        public static readonly SoundEffectType WartEffect = new(1, 1, SoundEffects.BlockWartBlockBreak,
            SoundEffects.BlockWartBlockStep, SoundEffects.BlockWartBlockPlace, SoundEffects.BlockWartBlockHit,
            SoundEffects.BlockWartBlockFall);




        public readonly float Volume, Pitch;
        public readonly SoundEffect BreakSound, StepSound, PlaceSound, HitSound, FallSound;

        public SoundEffectType(float volume, float pitch, SoundEffect breakSound, SoundEffect stepSound,
            SoundEffect placeSound, SoundEffect hitSound, SoundEffect fallSound)
        {
            Volume = volume;
            Pitch = pitch;
            BreakSound = breakSound;
            StepSound = stepSound;
            PlaceSound = placeSound;
            HitSound = hitSound;
            FallSound = fallSound;
        }
    }
}