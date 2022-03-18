using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NiaBukkit.API;
using NiaBukkit.API.Config;
using NiaBukkit.API.Util;
using NiaBukkit.Network;

namespace NiaBukkit.Minecraft
{
    public class MojangAuth
    {
        private const string BaseURL = "https://sessionserver.mojang.com/session/minecraft/";
		
		
        internal static Task<KeyValuePair<bool, JsonBuilder>> IsAuthenticate(NetworkManager networkManager, byte[] sharedKey)
        {
            return Task.Run(() =>
            {
                try
                {
                    using var ms = new MemoryStream();

                    var ascii = Encoding.ASCII.GetBytes("");
                    ms.Write(ascii, 0, ascii.Length);
                    ms.Write(sharedKey, 0, 16);
                    ms.Write(Bukkit.MinecraftServer.Cryptography.PublicKey);
                    
                    var serverHash = SelfCryptography.JavaHexDigest(ms.ToArray());

                    var sb = new StringBuilder();
                    sb.Append(BaseURL).Append("hasJoined?");
                    sb.AppendFormat("username={0}", networkManager.Name);
                    sb.AppendFormat("&serverId={0}", serverHash);

                    if (ServerSettings.IsPreventProxyConnections)
                        sb.AppendFormat("&ip={0}", networkManager.Host);
                    
                    var address = sb.ToString();
                    
                    var request = WebRequest.CreateHttp(address);
                    request.Timeout = 15000;
                    request.ReadWriteTimeout = 15000;

                    using var response = (HttpWebResponse) request.GetResponse();
                    using var stream = response.GetResponseStream();
                    using var reader = new StreamReader(stream);

                    var auth = reader.ReadToEnd();
					
                    return new KeyValuePair<bool, JsonBuilder>(auth.Length > 10, JsonBuilder.Parse(auth));
                }
                catch(Exception e)
                {
                    Console.Error.WriteLine(e);
                }

                return new KeyValuePair<bool, JsonBuilder>(false, null);
            });
        }
    }
}