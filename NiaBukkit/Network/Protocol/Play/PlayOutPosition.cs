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
            buf.WriteVarInt(47);
            
            buf.WriteDouble(_x);
            buf.WriteDouble(_y);
            buf.WriteDouble(_z);
            
            buf.WriteFloat(_pitch);
            buf.WriteFloat(_yaw);
            
            buf.WriteByte(_flags);
            buf.WriteVarInt(_teleportAwait);
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