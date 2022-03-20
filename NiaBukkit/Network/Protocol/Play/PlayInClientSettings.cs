using NiaBukkit.API.Entities;
using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Play
{
    public class 
        PlayInClientSettings : IPacket
    {
        public void Read(NetworkManager networkManager, ByteBuf buf)
        {
            //TODO: Version Add
            // if (networkManager.Protocol > ProtocolVersion.v1_16_5) ;
            Read_V1_12(networkManager, buf);
        }

        private static void Read_V1_12(NetworkManager networkManager, ByteBuf buf)
        {
            var player = networkManager.Player;

            player.Locate = buf.ReadString();
            player.ViewDistance = (byte) buf.ReadByte();
            player.ChatMode = (ChatMode) buf.ReadVarInt();
            player.ChatColor = buf.ReadBool();
            player.SkinPart = buf.ReadByte();
            
            if(networkManager.Protocol > ProtocolVersion.v1_8_9)
                player.MainHand = (MainHand) buf.ReadVarInt();
        }

        public int GetPacketId(ProtocolVersion protocol)
        {
            return protocol switch
            {
                > ProtocolVersion.v1_13_2 => 5,
                >= ProtocolVersion.v1_9 => 4,
                _ => 21
            };
        }
    }
}