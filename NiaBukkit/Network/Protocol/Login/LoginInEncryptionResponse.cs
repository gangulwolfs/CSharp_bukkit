using NiaBukkit.API;
using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Login
{
	public class LoginInEncryptionResponse
	{
        internal static void Read(NetworkManager networkManager, ByteBuf buf)
        {
	        //TODO: Encrpypion
	        var sharedSecret = buf.Read(buf.ReadVarInt());
	        var verifyToken = buf.Read(buf.ReadVarInt());
	        
	        networkManager.EncryptionResponse(Bukkit.MinecraftServer.Cryptography.Decrypt(sharedSecret), Bukkit.MinecraftServer.Cryptography.Decrypt(verifyToken));
        }
	}
}