using System.Collections.Generic;
using System.Collections.ObjectModel;
using NiaBukkit.API.Util;
using NiaBukkit.Network.Protocol.Ping;
using NiaBukkit.Network.Protocol.Status;
using NiaBukkit.Network.Protocol.Login;
using NiaBukkit.Network.Protocol.Play;

namespace NiaBukkit.Network.Protocol
{
    public static class PacketFactory
    {
        private static ReadOnlyCollection<IPacket> _playPackets;
        internal static void Handle(NetworkManager networkManager, ByteBuf buf, int packetId)
        {
            switch (networkManager.PacketMode)
            {
                case PacketMode.Ping:
                    PacketInPing(networkManager, buf, packetId);
                    break;
                case PacketMode.Status:
                    PacketInStatus(networkManager, buf, packetId);
                    break;
                case PacketMode.Login:
					PacketInLogin(networkManager, buf, packetId);
                    break;
                case PacketMode.Play:
                    PacketInPlay(networkManager, buf, packetId);
                    break;
            }
        }

        private static void PacketInPing(NetworkManager networkManager, ByteBuf buf, int packetId)
        {
            switch ((PingPacket) packetId)
            {
                case PingPacket.Handshake:
                    PingInHandshake.Read(networkManager, buf);
                    break;
            }
        }

        private static void PacketInStatus(NetworkManager networkManager, ByteBuf buf, int packetId)
        {
            switch ((StatusPacket) packetId)
            {
                case StatusPacket.Request:
                    StatusInRequest.Read(networkManager, buf);
                    break;
                case StatusPacket.Ping:
                    StatusInPing.Read(networkManager, buf);
                    break;
            }
        }

        private static void PacketInLogin(NetworkManager networkManager, ByteBuf buf, int packetId)
        {
            switch ((LoginPacket) packetId)
            {
                case LoginPacket.LoginStart:
                    LoginInStart.Read(networkManager, buf);
                    break;
                case LoginPacket.EncryptionResponse:
                    LoginInEncryptionResponse.Read(networkManager, buf);
                    break;
            }
        }

        private static void PacketInPlay(NetworkManager networkManager, ByteBuf buf, int packetId)
        {
            if (_playPackets == null)
                PlayPacketInit();
            
            foreach(var packet in _playPackets!)
            {
                if (packet.GetPacketId(networkManager.Protocol) != packetId) continue;
                packet.Read(networkManager, buf);
                return;
            }
        }

        private static void PlayPacketInit()
        {
            var packets = new List<IPacket>();
            packets.AddRange(new IPacket[]
            {
                new PlayInKeepAlive(),
                new PlayInClientSettings(),
                new PlayInLook(),
                new PlayInPositionLook(),
                new PlayInPosition(),
                new PlayInChatMessage(),
                new PlayInPlayerAbilities(),
            });

            _playPackets = new ReadOnlyCollection<IPacket>(packets);
        }
    }
}