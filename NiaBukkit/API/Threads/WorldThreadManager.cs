using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NiaBukkit.API.Entities;
using NiaBukkit.API.World.Chunks;
using NiaBukkit.Network.Protocol;
using NiaBukkit.Network.Protocol.Play;

namespace NiaBukkit.API.Threads
{
    public static class WorldThreadManager
    {
        private static readonly ConcurrentQueue<ChunkCoord> NeedLoadingChunk = new ConcurrentQueue<ChunkCoord>();

        private static readonly ConcurrentDictionary<ChunkCoord, ConcurrentBag<EntityPlayer>> ChunkSendPlayers =
            new ConcurrentDictionary<ChunkCoord, ConcurrentBag<EntityPlayer>>();
        [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: NiaBukkit.API.Util.MaterialAttribute")]
        [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: System.Reflection.CustomAttributeRecord[]")]
        [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: System.RuntimeMethodInfoStub")]
        [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: NiaBukkit.API.Util.Material")]
        [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: NiaBukkit.API.Util.MaterialAttribute[]")]
        [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: System.Byte[]")]
        internal static void Worker()
        {
            while (Bukkit.MinecraftServer.IsAvilable)
            {
                while (!NeedLoadingChunk.IsEmpty)
                {
                    NeedLoadingChunk.TryDequeue(out var target);
                    if(target == null)
                        continue;

                    ChunkSendPlayers.TryRemove(target, out var players);

                    if (players == null)
                        continue;

                    Chunk chunk = target.World.GetChunk(target.X, target.Z);
                    target.World.AddChunk(chunk);

                    Packet packet = new PlayOutChunkData(chunk);
                    foreach (var player in players)
                    {
                        if(player?.NetworkManager == null || !player.NetworkManager.IsAvailable || player.World != target.World)
                            continue;
                        
                        player.NetworkManager.SendPacket(packet);
                        player.ChunkLoaded(target);
                    }
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
            ChunkSendPlayers.GetOrAdd(coord, chunkCoord => new ConcurrentBag<EntityPlayer>()).Add(player);
            
            if(!NeedLoadingChunk.Contains(coord))
                NeedLoadingChunk.Enqueue(coord);
        }
    }
}