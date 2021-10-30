using System;
using NiaBukkit.API;
using NiaBukkit.API.Entity;
using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayInClientSettings : PlayInPacket
    {
        internal override void Read(NetworkManager networkManager, ByteBuf buf)
        {
            if (networkManager.Protocol > ProtocolVersion.v1_16_5) ;
            Write_V1_12(networkManager, buf);
        }

        private static void Write_V1_12(NetworkManager networkManager, ByteBuf buf)
        {
            EntityPlayer player = (EntityPlayer) networkManager.Player;
            
            player.locate = buf.ReadString();
            player.viewDistance = (byte) buf.ReadByte();
            player.ChatMode = (ChatMode) buf.ReadVarInt();
            player.ChatColor = buf.ReadBool();
            player.SkinPart = buf.ReadByte();
            player.mainHand = (MainHand) buf.ReadVarInt();
        }

        internal override int GetPacketId(ProtocolVersion protocol)
        {
            if (protocol > ProtocolVersion.v1_13_2)
                return 5;
            if (protocol > ProtocolVersion.v1_8_9)
                return 4;

            return 21;
        }
    }
}