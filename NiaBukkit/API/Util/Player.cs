using NiaBukkit.API.Command;

namespace NiaBukkit.API.Util
{
    public class Player : Entity.Entity, CommandSender
    {
        public GameMode GameMode { get; internal set; }
        public string Locate { get; internal set; }
        public byte ViewDistance { get; internal set; }
        public MainHand MainHand { get; internal set; } = MainHand.Right;
        public int HeldItemSlot { get; internal set; }

        public readonly Uuid Uuid;
        public string Name { get; internal set; }
        public string ListName { get; internal set; }
        public readonly GameProfile Profile;

        public Player(GameProfile profile, World.World world, GameMode gameMode) : base(world)
        {
            Profile = profile;
            GameMode = gameMode;
        }

        public virtual void SendMessage(object obj) {}
    }
}