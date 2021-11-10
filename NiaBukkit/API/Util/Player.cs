using NiaBukkit.API.Command;

namespace NiaBukkit.API.Util
{
    public interface Player : CommandSender, Entity.Entity
    {
        GameMode GameMode { get; }
        string Locate { get; }
        byte ViewDistance { get; }
        MainHand MainHand { get; }
        int HeldItemSlot { get; }
        
        Uuid Uuid { get; }
        string Name { get; }
        string ListName { get; }
    }
}