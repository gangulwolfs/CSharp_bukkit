using NiaBukkit.API.Entities;
using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Play
{
    public class 
        PlayInClientSettings : PlayInPacket
    {
        internal override void Read(NetworkManager networkManager, ByteBuf buf)
        {
            //TODO: Version Add
            // if (networkManager.Protocol > ProtocolVersion.v1_16_5) ;
            Read_V1_12(networkManager, buf);
        }

        private static void Read_V1_12(NetworkManager networkManager, ByteBuf buf)
        {
            var player = (EntityPlayer) networkManager.Player;

            player.Locate = buf.ReadString();
            player.ViewDistance = (byte) buf.ReadByte();
            player.ChatMode = (ChatMode) buf.ReadVarInt();
            player.ChatColor = buf.ReadBool();
            player.SkinPart = buf.ReadByte();
            
            if(networkManager.Protocol > ProtocolVersion.v1_8_9)
                player.MainHand = (MainHand) buf.ReadVarInt();
        }

        internal override int GetPacketId(ProtocolVersion protocol)
        {
            if (protocol > ProtocolVersion.v1_13_2)
                return 5;
            if (protocol >= ProtocolVersion.v1_9)
                return 4;

            return 21;
        }
    }
}