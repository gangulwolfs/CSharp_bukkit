using System.Collections.Generic;
using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayOutPosition : IPacket
    {
        private readonly double _x, _y, _z;
        private readonly float _pitch, _yaw;
        private byte _flags;
        private readonly int _teleportAwait;
        
        public PlayOutPosition(double x, double y, double z, float pitch, float yaw, IEnumerable<TeleportFlags> flags, int teleportAwait)
        {
            _x = x;
            _y = y;
            _z = z;
            _pitch = pitch;
            _yaw = yaw;

            _flags = 0;
            foreach (TeleportFlags flag in flags)
            {
                _flags |= (byte) flag;
            }

            _teleportAwait = teleportAwait;
        }

        public void Write(ByteBuf buf, ProtocolVersion protocol)
        {
            buf.WriteVarInt(GetPacketId(protocol));
            
            buf.WriteDouble(_x);
            buf.WriteDouble(_y);
            buf.WriteDouble(_z);
            
            buf.WriteFloat(_yaw);
            buf.WriteFloat(_pitch);
            
            buf.WriteByte(_flags);
            if(protocol >= ProtocolVersion.v1_9)
                buf.WriteVarInt(_teleportAwait);
        }
    
        public int GetPacketId(ProtocolVersion protocol)
        {
            return protocol switch
            {
                > ProtocolVersion.v1_16_5 => 56,
                > ProtocolVersion.v1_15_2 => 52,
                > ProtocolVersion.v1_14_3_CT => 54,
                > ProtocolVersion.v1_13_2 => 53,
                > ProtocolVersion.v1_12_2 => 50,
                > ProtocolVersion.v1_11_2 => 47,
                >= ProtocolVersion.v1_9 => 46,
                _ => 8
            };
        }
    }

    public enum TeleportFlags
    {
        X = 0,
        Y = 2,
        Z = 4,
        YRot = 8,
        XRot = 16
    }
}