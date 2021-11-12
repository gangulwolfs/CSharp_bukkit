using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayOutChatMessage : Packet
    {
        private readonly string _message;
        private readonly ChatMessageType _type;
        private readonly Uuid _uuid;
        public PlayOutChatMessage(string message, ChatMessageType type, Uuid uuid)
        {
            _message = message;
            _type = type;
            _uuid = uuid;
        }

        internal override void Write(ByteBuf buf, ProtocolVersion protocol)
        {
            buf.WriteVarInt(GetPacketId(protocol));
            buf.WriteString(new JsonBuilder().Add("text", _message).ToString());
            buf.WriteByte((byte) _type);
            if(protocol >= ProtocolVersion.v1_16)
                buf.WriteUuid(_uuid);
        }

        private static int GetPacketId(ProtocolVersion protocol)
        {
            if (protocol > ProtocolVersion.v1_16_5)
                return 15;
            if (protocol > ProtocolVersion.v1_15_2)
                return 14;
            if (protocol > ProtocolVersion.v1_13_2)
                return 15;
            if (protocol > ProtocolVersion.v1_12_2)
                return 14;
            if (protocol >= ProtocolVersion.v1_9)
                return 15;
            return 2;
        }
    }
}