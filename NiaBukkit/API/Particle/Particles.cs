using NiaBukkit.API.Particle.Data;

namespace NiaBukkit.API.Particle
{
    public class Particles
    {
        public static readonly ParticleType AmbientEntityEffect = Init("ambient_entity_effect", false);
        public static readonly ParticleType AngryVillager = Init("angry_villager", false);
        public static readonly ParticleType Barrier = Init("barrier", false);
        public static readonly ParticleType Block = Init("block", new ParticleParamBlock());
        public static readonly ParticleType Bubble = Init("bubble", false);
        public static readonly ParticleType Cloud = Init("cloud", false);
        public static readonly ParticleType Crit = Init("crit", false);
        public static readonly ParticleType DamageIndicator = Init("damage_indicator", true);
        public static readonly ParticleType DragonBreath = Init("dragon_breath", false);
        public static readonly ParticleType DrippingLava = Init("dripping_lava", false);
        public static readonly ParticleType FallingLava = Init("falling_lava", false);
        public static readonly ParticleType LandingLava = Init("landing_lava", false);
        public static readonly ParticleType DrippingWater = Init("dripping_water", false);
        public static readonly ParticleType FallingWater = Init("falling_water", false);
        public static readonly ParticleType Dust = Init("dust", new ParticleParamRGB());
        public static readonly ParticleType Effect = Init("effect", false);
        public static readonly ParticleType ElderGuardian = Init("elder_guardian", true);
        public static readonly ParticleType EnchantedHit = Init("enchanted_hit", false);
        public static readonly ParticleType Enchant = Init("enchant", false);
        public static readonly ParticleType EndRod = Init("end_rod", false);
        public static readonly ParticleType EntityEffect = Init("entity_effect", false);
        public static readonly ParticleType ExplosionEmitter = Init("explosion_emitter", true);
        public static readonly ParticleType Explosion = Init("explosion", true);
        public static readonly ParticleType FallingDust = Init("falling_dust", new ParticleParamBlock());
        public static readonly ParticleType Firework = Init("firework", false);
        public static readonly ParticleType Fishing = Init("fishing", false);
        public static readonly ParticleType Flame = Init("flame", false);
        public static readonly ParticleType SoulFireFlame = Init("soul_fire_flame", false);
        public static readonly ParticleType Soul = Init("soul", false);
        public static readonly ParticleType Flash = Init("flash", false);
        public static readonly ParticleType HappyVillager = Init("happy_villager", false);
        public static readonly ParticleType Composter = Init("composter", false);
        public static readonly ParticleType Heart = Init("heart", false);
        public static readonly ParticleType InstantEffect = Init("instant_effect", false);
        public static readonly ParticleType Item = Init("item", new ParticleParamItem());
        public static readonly ParticleType ITEM_SLIME = Init("item_slime", false);
        public static readonly ParticleType ITEM_SNOWBALL = Init("item_snowball", false);
        public static readonly ParticleType LARGE_SMOKE = Init("large_smoke", false);
        public static readonly ParticleType Lava = Init("lava", false);
        public static readonly ParticleType MYCELIUM = Init("mycelium", false);
        public static readonly ParticleType NOTE = Init("note", false);
        public static readonly ParticleType POOF = Init("poof", true);
        public static readonly ParticleType PORTAL = Init("portal", false);
        public static readonly ParticleType RAIN = Init("rain", false);
        public static readonly ParticleType SMOKE = Init("smoke", false);
        public static readonly ParticleType SNEEZE = Init("sneeze", false);
        public static readonly ParticleType SPIT = Init("spit", true);
        public static readonly ParticleType SQUID_INK = Init("squid_ink", true);
        public static readonly ParticleType SWEEP_ATTACK = Init("sweep_attack", true);
        public static readonly ParticleType TOTEM_OF_UNDYING = Init("totem_of_undying", false);
        public static readonly ParticleType UNDERWATER = Init("underwater", false);
        public static readonly ParticleType SPLASH = Init("splash", false);
        public static readonly ParticleType WITCH = Init("witch", false);
        public static readonly ParticleType BUBBLE_POP = Init("bubble_pop", false);
        public static readonly ParticleType CURRENT_DOWN = Init("current_down", false);
        public static readonly ParticleType BUBBLE_COLUMN_UP = Init("bubble_column_up", false);
        public static readonly ParticleType NAUTILUS = Init("nautilus", false);
        public static readonly ParticleType DOLPHIN = Init("dolphin", false);
        public static readonly ParticleType CAMPFIRE_COSY_SMOKE = Init("campfire_cosy_smoke", true);
        public static readonly ParticleType CAMPFIRE_SIGNAL_SMOKE = Init("campfire_signal_smoke", true);
        public static readonly ParticleType DRIPPING_HONEY = Init("dripping_honey", false);
        public static readonly ParticleType FALLING_HONEY = Init("falling_honey", false);
        public static readonly ParticleType LANDING_HONEY = Init("landing_honey", false);
        public static readonly ParticleType FALLING_NECTAR = Init("falling_nectar", false);
        public static readonly ParticleType ASH = Init("ash", false);
        public static readonly ParticleType CRIMSON_SPORE = Init("crimson_spore", false);
        public static readonly ParticleType WARPED_SPORE = Init("warped_spore", false);
        public static readonly ParticleType DrippingObsidianTear = Init("dripping_obsidian_tear", false);
        public static readonly ParticleType FallingObsidianTear = Init("falling_obsidian_tear", false);
        public static readonly ParticleType LANDING_OBSIDIAN_TEAR = Init("landing_obsidian_tear", false);
        public static readonly ParticleType REVERSE_PORTAL = Init("reverse_portal", false);
        public static readonly ParticleType WHITE_ASH = Init("white_ash", false);

        public static ParticleType Init(string code, bool a)
        {
            var particle = new ParticleType(code, a);
            ParticleType.ParticleTypes.Add(code, particle);
            return particle;
        }

        public static ParticleType Init(string code, IParticleParam param)
        {
            var particle = new ParticleType(code, param);
            ParticleType.ParticleTypes.Add(code, particle);
            return particle;
        }
    }
}