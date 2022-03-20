using NiaBukkit.API.Entities;
using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayOutPlayerInfo : IPacket
    {
        private readonly EnumPlayerInfoAction _action;
        private readonly EntityPlayer _player;
        public PlayOutPlayerInfo(EnumPlayerInfoAction action, EntityPlayer player)
        {
            _action = action;
            _player = player;
        }
        
        public void Write(ByteBuf buf, ProtocolVersion protocol)
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
                    buf.WriteVarInt(_player.Properties.Length); // Property Length

                    for(var i = 0; i < _player.Properties.Length; i++)
                    {
                        var property = (JsonBuilder) _player.Properties[i];
                        buf.WriteString(property.Get<string>("name"));
                        buf.WriteString(property.Get<string>("value"));
                        if (property.TryGetValue<string>("signature", out var signature))
                        {
                            buf.WriteBool(true);
                            buf.WriteString(signature);
                        }
                        else
                            buf.WriteBool(false);
                    }
                    
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

        public int GetPacketId(ProtocolVersion protocol)
        {
            return protocol switch
            {
                > ProtocolVersion.v1_16_5 => 54,
                > ProtocolVersion.v1_15_2 => 50,
                > ProtocolVersion.v1_14_3_CT => 52,
                > ProtocolVersion.v1_13_2 => 51,
                > ProtocolVersion.v1_12_2 => 48,
                > ProtocolVersion.v1_11_2 => 46,
                >= ProtocolVersion.v1_9 => 45,
                _ => 56
            };
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