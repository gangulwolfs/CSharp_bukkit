namespace NiaBukkit.Network.Protocol
{
    public enum PacketMode
    {
        Ping = 0,
        Status = 1,
        Login = 2,
        Play = 3
    }

    public enum PingPacket
    {
		// Packet In
        Handshake = 0
    }

    public enum StatusPacket
    {
		// Packet In
        Request = 0,
        Ping = 1,
		
		// Packet Out
		Response = 0,
		Pong = 1,
    }
	
	public enum LoginPacket
	{
		// Packet In
		LoginStart = 0,
		EncryptionResponse = 1,
		
		// Packet Out
		EncryptionRequest = 1,
		LoginSuccess = 2,
		SetCompress = 0x03
	}

	public enum PlayPacket
	{
		// Packet In
		TeleportAccept = 1,
		
		// Packet Out
		// JoinGame = 0x26,
		JoinGame = 0x26,
		SpawnPosition = 0x4B,
	}
}