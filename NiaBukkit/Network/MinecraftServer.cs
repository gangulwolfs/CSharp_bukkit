using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading;
using NiaBukkit.API;
using NiaBukkit.API.Util;
using NiaBukkit.API.Config;
using NiaBukkit.API.Entities;
using NiaBukkit.API.Threads;
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
        
        internal static readonly ConcurrentBag<NetworkManager> NetworkManagers = new();
        
        public bool IsAvailable { get; private set; }
        private readonly ConcurrentQueue<NetworkManager> _destroySockets = new();

        internal MinecraftServer()
        {
			Init();
			SocketStart();
        }
		
		private void Init()
		{
            IsAvailable = true;
			
            _listener = new TcpListener(IPAddress.Any, ServerProperties.Port)
            {
                Server =
                {
                    NoDelay = true,
                    SendTimeout = 500
                }
            };

            ServerKey = SelfCryptography.GenerateKeyPair();
		}
		
		private void SocketStart()
		{
            try
            {
                _listener.Start();
            }
            catch (SocketException)
            {
                Bukkit.ConsoleSender.SendWarnMessage("Failed to start the minecraft server");
                throw;
            }
            
            ThreadFactory.LaunchThread(new Thread(AcceptSocketWorker), false).Name = "Client Bind Thread";
            ThreadFactory.LaunchThread(new Thread(ClientUpdateWorker), false).Name = "Client Thread";
            ThreadFactory.LaunchThread(new Thread(ClientDestroyWorker), false).Name = "Client Destroy Thread";

            ThreadFactory.LaunchThread(new Thread(WorldThreadManager.Worker), false).Name = "World Generator";
            ThreadFactory.LaunchThread(new Thread(EntityThreadManager.Worker), false).Name = "Entity Thread";
        }

        private void AcceptSocketWorker()
        {
            while (IsAvailable)
            {
                NetworkManagers.Add(new NetworkManager(_listener.AcceptTcpClient()));
            }
        }

        [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: Enumerator[NiaBukkit.Network.NetworkManager]")]
        [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: NiaBukkit.Network.NetworkManager[]")]
        private void ClientUpdateWorker()
        {
            while (IsAvailable)
            {
                var currentTimeMillis = TimeManager.CurrentTimeMillis;
                foreach (var networkManager in NetworkManagers)
                {
                    if (networkManager is not {IsAvailable: true})
                    {
                        if(!_destroySockets.Contains(networkManager))
                            _destroySockets.Enqueue(networkManager);
                        continue;
                    }

                    if (networkManager.Client is not {Connected: true} || currentTimeMillis - networkManager.LastPacketMillis > Timeout)
                    {
                        networkManager.Disconnect();
                        _destroySockets.Enqueue(networkManager);
                        continue;
                    }
                    
                    networkManager.Update();
                }
            }
        }

        private void ClientDestroyWorker()
        {
            while (IsAvailable)
            {
                while(!_destroySockets.IsEmpty)
                {
                    if(!_destroySockets.TryDequeue(out var networkManager)) continue;
                    
                    if(networkManager.Client is {Connected: true}) networkManager.Client.Close();
                    NetworkManagers.Remove(networkManager);
                }
            }
        }

        public string GetServerModName()
        {
            return "NiaBukkit";
        }

        internal static void BroadcastInWorld(Player sender, World world, Packet packet, bool me = true)
        {
            foreach (var player in world.Players)
            {
                if(player == sender && !me) continue;
                ((EntityPlayer) player).NetworkManager.SendPacket(packet);
            }
        }

        internal static void Broadcast(Packet packet)
        {
            foreach (var player in Bukkit.OnlinePlayers)
            {
                ((EntityPlayer) player).NetworkManager.SendPacket(packet);
            }
        }
    }
}