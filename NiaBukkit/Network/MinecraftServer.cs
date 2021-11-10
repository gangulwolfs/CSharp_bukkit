using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading;
using NiaBukkit.API;
using NiaBukkit.API.Util;
using NiaBukkit.API.Config;
using NiaBukkit.API.Entity;
using NiaBukkit.API.World;
using NiaBukkit.Network.Protocol;

namespace NiaBukkit.Network
{
    public class MinecraftServer
    {
        public ProtocolVersion Protocol { get; internal set; } = ProtocolVersion.v15w33b;
        // public ProtocolVersion Protocol { get; internal set; } = ProtocolVersion.v1_12_2;
		internal RSAParameters ServerKey;
        
        private TcpListener _listener;
        private const int Timeout = 25000;
        
        public bool IsAvilable { get; private set; }
        private readonly ConcurrentQueue<NetworkManager> _destroySockets = new ConcurrentQueue<NetworkManager>();

        internal MinecraftServer()
        {
			Init();
			SocketStart();
        }
		
		private void Init()
		{
            IsAvilable = true;
			
            _listener = new TcpListener(IPAddress.Any, ServerProperties.Port);
            _listener.Server.NoDelay = true;
            _listener.Server.SendTimeout = 500;
			
            ServerKey = SelfCryptography.GenerateKeyPair();
		}
		
		private void SocketStart()
		{
            try
            {
                _listener.Start();
            }
            catch (SocketException e)
            {
                Bukkit.ConsoleSender.SendWarnMessage("Failed to start the minecraft server");
                throw e;
            }
            
            ThreadFactory.LaunchThread(new Thread(AcceptSocketWorker), false).Name = "Client Bind Thread";
            ThreadFactory.LaunchThread(new Thread(ClientUpdateWorker), false).Name = "Client Thread";
            ThreadFactory.LaunchThread(new Thread(ClientDestroyWorker), false).Name = "Client Destroy Thread";
		}

        internal void AddDestroySocket(NetworkManager networkManager)
        {
            _destroySockets.Enqueue(networkManager);
        }

        private void AcceptSocketWorker()
        {
            while (IsAvilable)
            {
                new NetworkManager(_listener.AcceptTcpClient());
            }
        }

        private void ClientUpdateWorker()
        {
            while (IsAvilable)
            {
                long currentTimeMillis = TimeManager.CurrentTimeMillis;
                foreach (var networkManager in NetworkManager.NetworkManagers)
                {
                    if (networkManager == null || !networkManager.IsAvilable)
                        continue;
                    
                    if (networkManager.Client is not {Connected: true} || currentTimeMillis - networkManager.LastPacketMillis > Timeout)
                    {
                        networkManager.Disconnect();
                        continue;
                    }
                    
                    networkManager.Update();
                }
            }
        }

        private void ClientDestroyWorker()
        {
            while (IsAvilable)
            {
                while(!_destroySockets.IsEmpty)
                {
                    NetworkManager networkManager;
                    if(!_destroySockets.TryDequeue(out networkManager)) continue;
                    
                    if(networkManager.Client != null && networkManager.Client.Connected) networkManager.Client.Close();
                    NetworkManager.NetworkManagers.Remove(networkManager);
                }
            }
        }

        public string GetServerModName()
        {
            return "NiaBukkit";
        }

        internal static void BroadcastInWorld(Player sender, World world, Packet packet, bool me = true)
        {
            foreach (Player player in world.Players)
            {
                if(player == sender && !me) continue;
                ((EntityPlayer) player).NetworkManager.SendPacket(packet);
            }
        }
    }
}