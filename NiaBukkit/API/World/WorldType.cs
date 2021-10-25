using NiaBukkit.Network;

namespace NiaBukkit.API.World
{
    public enum WorldType
    {
        Default,
        Flat,
        LargeBiomes,
        Amplified
    }

    public static class WorldTypeExtensions
    {
        public static string GetName(this WorldType type)
        {
            return type.ToString().ToUpper();
        }
    }
}