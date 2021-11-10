using System.Collections.Generic;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayOutPosition : Packet
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

        internal override void Write(ByteBuf buf, ProtocolVersion protocol)
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
    
        private static int GetPacketId(ProtocolVersion protocol)
        {
            if (protocol > ProtocolVersion.v1_16_5)
                return 56;
            if (protocol > ProtocolVersion.v1_15_2)
                return 52;
            if (protocol > ProtocolVersion.v1_14_3_CT)
                return 54;
            if (protocol > ProtocolVersion.v1_13_2)
                return 53;
            if (protocol > ProtocolVersion.v1_12_2)
                return 50;
            if (protocol > ProtocolVersion.v1_11_2)
                return 47;
            if (protocol >= ProtocolVersion.v1_9)
                return 46;
            return 8;
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