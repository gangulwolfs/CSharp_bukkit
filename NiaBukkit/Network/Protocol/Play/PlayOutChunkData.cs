using NiaBukkit.API;
using NiaBukkit.API.Util;
using NiaBukkit.API.World;
using NiaBukkit.API.World.Chunks;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayOutChunkData : IPacket
    {
        private byte[] _data;
        private readonly Chunk _chunk;
        public PlayOutChunkData(Chunk chunk)
        {
            _chunk = chunk;
        }

        public PlayOutChunkData(Chunk chunk, ProtocolVersion version) : this(chunk)
        {
            var buf = new ByteBuf();
            WritePre(buf, version);
            _data = buf.GetBytes();
        }
        
        public void Write(ByteBuf buf, ProtocolVersion protocol)
        {
            if(_data == null)
                WritePre(buf, protocol);
            else
            {
                buf.Write(_data);
            }
        }

        private void WritePre(ByteBuf buf, ProtocolVersion protocol)
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

                var bitsPerBlock = ChunkDataVersionUtil.GetBitsPerBlock(section.PaletteSize, maxBitsBlock);
                // var bitsPerBlock = maxBitsBlock;
                data.WriteByte(bitsPerBlock);

                /*data.WriteVarInt(4);
                data.WriteVarInt(0);
                data.WriteVarInt(7 << 4);
                data.WriteVarInt(2 << 4);
                data.WriteVarInt(6 << 4 | 1 | 1 << 3);*/

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

                ChunkDataVersionUtil.CreateCompactArray(data, bitsPerBlock,
                    bitsPerBlock == maxBitsBlock ? section.GetFlatId : section.GetPaletteIndex);
                
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
            buf.WriteUShort((ushort) ~mask);
            
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

        public int GetPacketId(ProtocolVersion protocol)
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