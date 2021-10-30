using NiaBukkit.API.Command;

namespace NiaBukkit.API.Util
{
    public interface Player : CommandSender, Entity.Entity
    {
        public GameMode GameMode { get; }
        public string Locate { get; }
        public byte ViewDistance { get; }
        public MainHand MainHand { get; }
        public int HeldItemSlot { get; }
    }
}