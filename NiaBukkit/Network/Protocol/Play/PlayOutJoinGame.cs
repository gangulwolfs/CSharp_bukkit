using NiaBukkit.API.Config;
using NiaBukkit.API.Util;
using NiaBukkit.API.World;

namespace NiaBukkit.Network.Protocol.Play
{
    /**
     * <summary>Player Game Start</summary>
     */
    public class PlayOutJoinGame : IPacket
    {
        private Player _player;
        public PlayOutJoinGame(Player player)
        {
            _player = player;
        }
        
        public void Write(ByteBuf buf, ProtocolVersion protocol)
        {
            // buf.WriteInt(_player.EntityId);
            //
            // if(protocol > ProtocolVersion.v1_15_2)
            //     buf.WriteBool(_player.World.IsHardCore);
            //
            // buf.WriteByte((byte) _player.GameMode);
            //
            // if(protocol > ProtocolVersion.v1_15_2)
            //     buf.WriteByte((byte) _player.GameMode); // 이전 게임 모드
            //
            // if(protocol <= ProtocolVersion.v1_15_2 && protocol > ProtocolVersion.v1_8_9)
            //     buf.WriteVarInt(_player.World.Dimension);
            // else if (protocol > ProtocolVersion.v1_5_2)
            // {
            //     //TODO: 월드 갯수, 월드 이름들, 차원 코덱 2개
            // }
            // else
            //     buf.WriteByte(_player.World.Dimension);
            //
            // if(protocol <= ProtocolVersion.v1_15_2 && protocol > ProtocolVersion.v1_14_3_CT)
            //     buf.WriteLong(_player.World.Seed);
            //
            // buf.WriteByte((byte) _player.World.Difficulty);
            // buf.WriteString(_player.World.WorldType.GetName()); // 1.16 부터 변했을 수 있음
            //
            // if (protocol > ProtocolVersion.v1_15_2)
            // {
            //     buf.WriteLong(_player.World.Seed);
            //     buf.WriteVarInt(ServerProperties.MaxPlayers);
            // }
            //
            // buf.WriteVarInt(2); // 렌더 거리
            //
            // if (protocol > ProtocolVersion.v1_15_2)
            // {
            //     buf.WriteBool(true); // 디버그 최소화
            //     buf.WriteBool(false); // 리스폰 화면 킬건지
            // }
            //
            // buf.WriteBool(false);
            //
            // if(protocol > ProtocolVersion.v1_14_3_CT)
            //     buf.WriteBool(_player.World.WorldType == WorldType.Flat);
            
            //TODO: Other Version
            buf.WriteVarInt(GetPacketId(protocol));
            buf.WriteInt(_player.EntityId);
            
            if (protocol >= ProtocolVersion.v1_9_1)
                Write_V1_9_1(buf);
            else
                WriteOld(buf);
        }

        private void Write_V1_9_1(ByteBuf buf)
        {
            var gameMode = (int) _player.GameMode;
            
            if (_player.World.IsHardCore)
                gameMode |= 0x8;
            buf.WriteByte((byte) gameMode);
            
            buf.WriteInt((int) _player.World.Dimension);
            buf.WriteByte((byte) _player.World.Difficulty);
            buf.WriteByte((byte) ServerProperties.MaxPlayers);
            buf.WriteString(_player.World.WorldType.GetName());
            buf.WriteBool(false); // 정보 최소화
        }

        private void WriteOld(ByteBuf buf)
        {
            var gameMode = (int) _player.GameMode;
            
            if (_player.World.IsHardCore)
                gameMode |= 0x8;
            buf.WriteByte((byte) gameMode);
            buf.WriteByte((byte) _player.World.Dimension);
            buf.WriteByte((byte) _player.World.Difficulty);
            buf.WriteByte((byte) ServerProperties.MaxPlayers);
            buf.WriteString(_player.World.WorldType.GetName());
            buf.WriteBool(false); // 정보 최소화
        }

        public int GetPacketId(ProtocolVersion protocol)
        {
            return protocol switch
            {
                > ProtocolVersion.v1_16_5 => 38,
                > ProtocolVersion.v1_15_2 => 36,
                > ProtocolVersion.v1_14_3_CT => 38,
                > ProtocolVersion.v1_12_2 => 37,
                >= ProtocolVersion.v1_9 => 35,
                _ => 1
            };
        }
    }
}