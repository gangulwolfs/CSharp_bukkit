using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Status
{
    /**
     * <summary>Client Request Ping Speed</summary>
     */
    public class StatusInPing
    {
        internal static void Read(NetworkManager networkManager, ByteBuf buf)
        {
			networkManager.SendPacket(new StatusOutPong(buf.ReadLong()));
        }
    }
}