using NiaBukkit.API.Entities;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayOutPlayerInfo : Packet
    {
        private readonly EnumPlayerInfoAction _action;
        private readonly EntityPlayer _player;
        public PlayOutPlayerInfo(EnumPlayerInfoAction action, EntityPlayer player)
        {
            _action = action;
            _player = player;
        }
        
        internal override void Write(ByteBuf buf, ProtocolVersion protocol)
        {
            buf.WriteVarInt(GetPacketId(protocol));
            buf.WriteVarInt((int) _action);

            buf.WriteVarInt(1); // 보낼 엔티티 플레이어 수
            buf.WriteUuid(_player.Uuid);
            switch (_action)
            {
                case EnumPlayerInfoAction.AddPlayer:
                    buf.WriteString(_player.Name);
                    
                    //TODO: Player Property Send
                    buf.WriteVarInt(0); // Property Length
                    
                    buf.WriteVarInt((int) _player.GameMode);
                    buf.WriteVarInt(_player.Ping); // PING

                    if (_player.ListName == null)
                    {
                        buf.WriteBool(false);
                        break;
                    }
                    buf.WriteBool(true);
                    buf.WriteString(_player.ListName);
                    break;
                case EnumPlayerInfoAction.UpdateGameMode:
                    buf.WriteVarInt((int) _player.GameMode);
                    break;
                case EnumPlayerInfoAction.UpdateLatency:
                    buf.WriteVarInt(_player.Ping);
                    break;
                case EnumPlayerInfoAction.UpdateDisplayName:
                    if (_player.ListName == null)
                    {
                        buf.WriteBool(false);
                        break;
                    }
                    buf.WriteBool(true);
                    buf.WriteString(_player.ListName);
                    break;
                case EnumPlayerInfoAction.RemovePlayer:
                    break;
            }
        }

        private static int GetPacketId(ProtocolVersion protocol)
        {
            if (protocol > ProtocolVersion.v1_16_5)
                return 54;
            if (protocol > ProtocolVersion.v1_15_2)
                return 50;
            if (protocol > ProtocolVersion.v1_14_3_CT)
                return 52;
            if (protocol > ProtocolVersion.v1_13_2)
                return 51;
            if (protocol > ProtocolVersion.v1_12_2)
                return 48;
            if (protocol > ProtocolVersion.v1_11_2)
                return 46;
            if (protocol >= ProtocolVersion.v1_9)
                return 45;
            return 56;
        }
        
        public enum EnumPlayerInfoAction
        {
            AddPlayer,
            UpdateGameMode,
            UpdateLatency,
            UpdateDisplayName,
            RemovePlayer,
        }
    }
}