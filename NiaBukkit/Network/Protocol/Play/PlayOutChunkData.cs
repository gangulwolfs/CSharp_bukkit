using NiaBukkit.API;
using NiaBukkit.API.World;
using NiaBukkit.API.World.Chunks;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayOutChunkData : Packet
    {
        private readonly Chunk _chunk;
        public PlayOutChunkData(Chunk chunk)
        {
            _chunk = chunk;
        }
        
        internal override void Write(ByteBuf buf, ProtocolVersion protocol)
        {
            buf.WriteVarInt(GetPacketId(protocol));
            buf.WriteInt(_chunk.Coord.X);
            buf.WriteInt(_chunk.Coord.Z);
            buf.WriteBool(_chunk.IsFullChunk()); //청크가 완전한지

            if (protocol >= ProtocolVersion.v1_9)
                Write_V_9(buf);
            else
                WriteOld(buf);

            if (protocol >= ProtocolVersion.v1_9_1)
            {
                buf.WriteVarInt(0); //NBTTag 갯수
                //TODO: NBTTag
            }
        }

        private void Write_V_9(ByteBuf buf)
        {
            const byte maxBitsBlock = 13;
            var mask = _chunk.GetBitMask();

            buf.WriteVarInt(mask);

            var data = new ByteBuf();
            for (var i = 0; i < _chunk.ChunkSections.Length; i++)
            {
                //30476 19968
                if ((mask >> i & 1) == 0) continue;
                var section = _chunk.ChunkSections[i];

                // var bitsPerBlock = ChunkDataVersionUtil.GetBitsPerBlock(section.PaletteSize, maxBitsBlock);
                var bitsPerBlock = maxBitsBlock;
                data.WriteByte(bitsPerBlock);

                if (bitsPerBlock != maxBitsBlock)
                {
                    var size = section.PaletteSize;
                    data.WriteVarInt(size);
                    for (var k = 0; k < size; k++)
                    {
                        data.WriteVarInt(section.GetFlatIdFromPalette(k));
                    }
                }
                else
                    data.WriteVarInt(0);
                
                var array = ChunkDataVersionUtil.CreateCompactArray(bitsPerBlock,
                    bitsPerBlock == maxBitsBlock ? section.GetFlatId : section.GetPaletteIndex);
                
                data.WriteLongArray(array);
                // Bukkit.ConsoleSender.SendMessage(array.Length * 8 + ChunkSection.Size);

                section.WriteBlockLight(data);
                
                if (_chunk.Coord.World.Dimension == Dimention.OverWorld)
                    if (section.HasSkyLight())
                        section.WriteSkyLight(data);
                    else
                        data.Write(new byte[ChunkSection.Size / 2]);
            }

            if (_chunk.IsFullChunk())
                _chunk.WriteBiomes(data);

            buf.Write(data.Flush());
        }

        private void WriteOld(ByteBuf buf)
        {
            var mask = _chunk.GetBitMask();
            buf.WriteUShort(mask);
            
            var data = new ByteBuf();

            for (var i = 0; i < _chunk.ChunkSections.Length; i++)
            {
                if ((mask & 1 << i) == 0) continue;
                
                for(var k = 0; k < ChunkSection.Size; k++)
                    data.WriteUShort((ushort) _chunk.ChunkSections[i].GetFlatId(k));
            }
            
            for (var i = 0; i < _chunk.ChunkSections.Length; i++)
            {
                if ((mask & 1 << i) == 0) continue;
                _chunk.ChunkSections[i].WriteBlockLight(data);
            }
            
            for (var i = 0; i < _chunk.ChunkSections.Length; i++)
            {
                if ((mask & 1 << i) == 0) continue;
                var section = _chunk.ChunkSections[i];
                if (section.HasSkyLight())
                    section.WriteSkyLight(data);
                else
                    data.Write(new byte[ChunkSection.Size / 2]);
            }
            
            if(_chunk.IsFullChunk())
                _chunk.WriteBiomes(data);

            buf.Write(data.Flush());
        }

        private static int GetPacketId(ProtocolVersion protocol)
        {
            return protocol switch
            {
                > ProtocolVersion.v1_16_5 => 34,
                > ProtocolVersion.v1_15_2 => 32,
                > ProtocolVersion.v1_14_3_CT => 34,
                > ProtocolVersion.v1_13_2 => 33,
                > ProtocolVersion.v1_12_2 => 34,
                >= ProtocolVersion.v1_9 => 32,
                _ => 33
            };
        }
    }
}