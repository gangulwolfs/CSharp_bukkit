using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using NiaBukkit.API;
using NiaBukkit.API.Module;
using NiaBukkit.API.Config;

namespace NiaBukkit.Network
{
    public class MinecraftServer
    {
        public ProtocolVersion Protocol { get; internal set; } = ProtocolVersion.v1_17_1;
        
        private TcpListener listener;
        private const int Timeout = 30;
        
        public bool IsAvilable { get; private set; }
        private List<TcpClient> destroySockets = new List<TcpClient>();
        internal MinecraftServer()
        {
            IsAvilable = true;
            listener = new TcpListener(IPAddress.Any, ServerProperties.Port);
            listener.Server.NoDelay = true;
            listener.Server.SendTimeout = 500;

            try
            {
                listener.Start();
            }
            catch (SocketException e)
            {
                ConsoleSender.SendWarnMessage("Failed to start the minecraft server");
                throw e;
            }
            
            ThreadFactory.LaunchThread(new Thread(AcceptSocketWorker), false).Name = "Client Bind Thread";
            ThreadFactory.LaunchThread(new Thread(ClientUpdateWorker), false).Name = "Client Thread";
            ThreadFactory.LaunchThread(new Thread(ClientDestroyWorker), false).Name = "Client Destroy Thread";
        }

        private void AcceptSocketWorker()
        {
            while (IsAvilable)
            {
                new NetworkManager(listener.AcceptTcpClient());
            }
        }

        private void ClientUpdateWorker()
        {
            while (IsAvilable)
            {
                NetworkManager[] networkManagers = NetworkManager.networkManagers.ToArray();
                long currentTimeMillis = TimeManager.CurrentTimeMillis;
                foreach (var networkManager in networkManagers)
                {
                    if (networkManager == null)
                    {
                        NetworkManager manager = networkManager;
                        NetworkManager.networkManagers.TryPeek(out manager);
                        continue;
                    }
                    if (networkManager.client == null || !networkManager.client.Connected || networkManager.client.Available <= 0 &&
                        currentTimeMillis - networkManager.lastPacketMillis > Timeout)
                    {
                        networkManager.Disconnect();
                        destroySockets.Add(networkManager.client);
                        continue;
                    }

                    if (networkManager.client.Available > 0)
                        networkManager.Update();
                }
            }
        }

        private void ClientDestroyWorker()
        {
            while (IsAvilable)
            {
                TcpClient[] destroyList = destroySockets.ToArray();
                foreach (var client in destroyList)
                {
                    if(client != null) client.Close();
                    destroySockets.Remove(client);
                }
            }
        }
    }
}