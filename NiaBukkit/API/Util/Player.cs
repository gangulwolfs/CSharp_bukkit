using NiaBukkit.API.Command;
using NiaBukkit.API.Entities;

namespace NiaBukkit.API.Util
{
    public class Player : Entity, CommandSender
    {
        public GameMode GameMode { get; internal set; }
        public string Locate { get; internal set; }
        public byte ViewDistance { get; internal set; }
        public MainHand MainHand { get; internal set; } = MainHand.Right;
        public int HeldItemSlot { get; internal set; }
        public string Name => Profile.Name;
        public string ListName { get; internal set; }
        public readonly GameProfile Profile;

        public Player(GameProfile profile, World.World world, GameMode gameMode) : base(profile.Uuid, world)
        {
            Profile = profile;
            GameMode = gameMode;
        }

        public virtual void SendMessage(object obj) {}

        public virtual void SendMessage(string message) {}
        public virtual void SendMessage(Uuid sender, string message) {}
        public virtual void SendMessage(ChatMessageType position, string message) {}
        public virtual void SendMessage(Uuid sender, ChatMessageType position, string message) {}
    }
}