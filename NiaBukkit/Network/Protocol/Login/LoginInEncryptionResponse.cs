using System.Linq;
using System.Security.Cryptography;
using NiaBukkit.API;
using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Login
{
	public class LoginInEncryptionResponse
	{
        internal static void Read(NetworkManager networkManager, ByteBuf buf)
        {
	        //TODO: Encrpypion
	        byte[] sharedSecret = buf.Read(buf.ReadVarInt());
	        byte[] vertifyToken = buf.Read(buf.ReadVarInt());
	        
	        Bukkit.ConsoleSender.SendMessage(sharedSecret.Length);

	        byte[] sharedKey = SelfCryptography.Decrypt(sharedSecret);

	        RijndaelManaged recv = SelfCryptography.GenerateAes(sharedKey);
	        RijndaelManaged send = SelfCryptography.GenerateAes(sharedKey);

	        byte[] packetToken = SelfCryptography.Decrypt(vertifyToken);

	        if (!packetToken.SequenceEqual(SelfCryptography.VertifyToken))
	        {
		        Bukkit.ConsoleSender.SendWarnMessage(networkManager.Host + ":" + networkManager.Port + "Wrong token");
		        return;
	        }

	        networkManager.Decrypter = recv.CreateDecryptor();
	        networkManager.Encrypter = send.CreateEncryptor();
        }
	}
}