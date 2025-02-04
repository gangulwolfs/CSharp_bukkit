﻿using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NiaBukkit.API.Entities;
using NiaBukkit.API.World.Chunks;
using NiaBukkit.Network.Protocol.Play;

namespace NiaBukkit.API.Threads
{
    public static class WorldThreadManager
    {
        private const int ThreadDelay = 500;
        private static readonly ConcurrentQueue<ChunkCoord> NeedLoadingChunk = new();

        private static readonly ConcurrentDictionary<ChunkCoord, ConcurrentBag<EntityPlayer>> ChunkSendPlayers = new();
        
        internal static void Worker()
        {
            while (Bukkit.MinecraftServer.IsAvailable)
            {
                if (NeedLoadingChunk.IsEmpty)
                {
                    Thread.Sleep(ThreadDelay);
                    continue;
                }
                
                NeedLoadingChunk.TryDequeue(out var target);
                if(target == null)
                    continue;

                ChunkSendPlayers.TryRemove(target, out var players);

                if (players == null)
                    continue;

                var chunk = target.World.GetChunk(target.X, target.Z);
                target.World.AddChunk(chunk);

                var packet = new PlayOutChunkData(chunk);

                foreach (var player in players)
                {
                    if (player?.NetworkManager == null || !player.NetworkManager.IsAvailable ||
                        player.World != target.World)
                        continue;

                    player.NetworkManager.SendPacket(packet);
                    player.ChunkLoaded(target);
                }
            }
        }

        internal static void AddRequireChunk(World.World world, int x, int z, EntityPlayer player)
        {
            var coord = new ChunkCoord(world, x, z);
            ChunkSendPlayers.GetOrAdd(coord, chunkCoord => new ConcurrentBag<EntityPlayer>()).Add(player);
            
            if(!NeedLoadingChunk.Contains(coord))
                NeedLoadingChunk.Enqueue(coord);
        }

        internal static void AddRequireChunk(ChunkCoord coord, EntityPlayer player)
        {
            if (player?.NetworkManager == null || !player.NetworkManager.IsAvailable ||
                player.World != coord.World) return;
            
            ChunkSendPlayers.GetOrAdd(coord, chunkCoord => new ConcurrentBag<EntityPlayer>()).Add(player);

            if (!NeedLoadingChunk.Contains(coord))
                NeedLoadingChunk.Enqueue(coord);
        }
    }
}