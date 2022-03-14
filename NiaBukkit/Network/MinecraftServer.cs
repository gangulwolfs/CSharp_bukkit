using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        public const string MinecraftKey = "minecraft:";
        // public ProtocolVersion Protocol { get; internal set; } = ProtocolVersion.v15w33b;
        public ProtocolVersion Protocol { get; internal set; } = ProtocolVersion.v1_12_2;
		internal RSAParameters ServerKey;
        
        private TcpListener _listener;

        private readonly ConcurrentBag<NetworkManager> _networkManagers = new();
        
        public bool IsAvailable { get; private set; }

        public const string ServerId = "";

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

            ThreadFactory.LaunchThread(new Thread(WorldThreadManager.Worker), false).Name = "World Generator";
            ThreadFactory.LaunchThread(new Thread(EntityThreadManager.Worker), false).Name = "Entity Thread";
        }

        private void AcceptSocketWorker()
        {
            while (IsAvailable)
            {
                _networkManagers.Add(new NetworkManager(_listener.AcceptTcpClient()));
            }
        }

        [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: Enumerator[NiaBukkit.Network.NetworkManager]")]
        [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: NiaBukkit.Network.NetworkManager[]")]
        private void ClientUpdateWorker()
        {
            while (IsAvailable)
            {
                var destroy = new Queue<NetworkManager>();
                ClientForEachUpdate(destroy);
                ClientForEachDestroy(destroy);
            }
        }

        private void ClientForEachUpdate(Queue<NetworkManager> destroy)
        {
            foreach (var networkManager in _networkManagers)
            {
                if (!(networkManager?.IsAvailable ?? false))
                {
                    destroy.Enqueue(networkManager);
                    continue;
                }
                networkManager.Update();
            }
        }

        private void ClientForEachDestroy(Queue<NetworkManager> destroy)
        {
            while(destroy.Count > 0)
            {
                var networkManager = destroy.Dequeue();
                
                networkManager.Close();
                _networkManagers.Remove(networkManager);
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