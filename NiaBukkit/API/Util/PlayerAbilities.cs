namespace NiaBukkit.API.Util
{
    public class PlayerAbilities
    {
        public bool IsInvulnerable { get; internal set; } = false;
        public bool IsFly { get; internal set; } = false;
        public bool CanFly { get; internal set; } = true;
        public bool CanInstantlyBuild { get; internal set; } = false;

        public float FlySpeed { get; internal set; } = 1f;
        public float WalkSpeed { get; internal set; } = 1f;
    }
}