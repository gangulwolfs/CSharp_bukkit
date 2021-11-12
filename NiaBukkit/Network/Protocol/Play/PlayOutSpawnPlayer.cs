using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayOutSpawnPlayer : Packet
    {
        private readonly Player _player;
        public PlayOutSpawnPlayer(Player player)
        {
            _player = player;
        }
        
        internal override void Write(ByteBuf buf, ProtocolVersion protocol)
        {
            buf.WriteVarInt(GetPacketId(protocol));
            buf.WriteVarInt(_player.EntityId);
            buf.WriteUuid(_player.Uuid);
            if (protocol < ProtocolVersion.v1_9)
            {
                buf.WriteInt((int) (_player.Location.X * 32));
                buf.WriteInt((int) (_player.Location.Y * 32));
                buf.WriteInt((int) (_player.Location.Z * 32));
            }
            else
            {
                buf.WriteDouble(_player.Location.X);
                buf.WriteDouble(_player.Location.Y);
                buf.WriteDouble(_player.Location.Z);
            }
            
            buf.WriteByte((byte) _player.Location.Yaw);
            buf.WriteByte((byte) _player.Location.Pitch);
			
            //TODO: DataWatcher
            if (protocol < ProtocolVersion.v1_9)
            {
                buf.WriteShort(0);
                buf.WriteByte(127);
            }
            else
                buf.WriteByte(255);
        }

        private static int GetPacketId(ProtocolVersion protocol)
        {
            if (protocol > ProtocolVersion.v1_15_2)
                return 4;
            if (protocol >= ProtocolVersion.v1_9)
                return 5;
            return 12;
        }
    }
}