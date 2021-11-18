using System;
using NiaBukkit.API.World.Chunks;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayOutChunkData : Packet
    {
        private readonly Chunk _chunk;
        private const byte MaxBitsBlock = 13;
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
            var mask = _chunk.GetBitMask();
            buf.WriteVarInt(mask);

            var data = new ByteBuf();
            for (var i = 0; i < _chunk.ChunkSections.Length; i++)
            {
                if ((mask & 1 << i) == 0) continue;
                var section = _chunk.ChunkSections[i];

                var bitsPerBlock = GetBitsPerBlock(section);
                // byte bitsPerBlock = MaxBitsBlock;
                data.WriteByte(bitsPerBlock);

                if (bitsPerBlock != MaxBitsBlock)
                {
                    data.WriteVarInt(section.PaletteSize);
                    for (var k = 0; k < section.PaletteSize; k++)
                    {
                        data.WriteVarInt(section.GetOldPaletteData(k));
                    }
                }
                else
                    data.WriteVarInt(0);
                
                var chunkArray = ChunkDataVersionUtil.CreateCompactArray(bitsPerBlock,
                    bitsPerBlock == MaxBitsBlock ? section.GetLegacyBlockData : section.GetPaletteIndex);
                data.WriteVarInt(chunkArray.Length);

                foreach (var d in chunkArray)
                    data.WriteLong(d);

                _chunk.ChunkSections[i].WriteBlockLight(data);
                if (_chunk.ChunkSections[i].HasSkyLight())
                    _chunk.ChunkSections[i].WriteSkyLight(data);
            }

            if (_chunk.IsFullChunk())
                _chunk.WriteBiomes(data);

            var ch = new long[data.WriteLength / 8];
            var ori = data.GetBytes();
            for (var i = 0; i < data.WriteLength - 7; i += 8)
            {
                ch[i / 8] = BitConverter.ToInt64(ori, i);
            }

            buf.WriteVarInt(data.WriteLength);
            buf.Write(data.GetBytes());
        }

        private void WriteOld(ByteBuf buf)
        {
            ushort mask = _chunk.GetBitMask();
            buf.WriteUShort((ushort) ~mask);
            
            ByteBuf data = new ByteBuf();

            for (int i = 0; i < _chunk.ChunkSections.Length; i++)
            {
                if ((mask & 1 << i) == 0) continue;
                
                for(int k = 0; k < ChunkSection.Size; k++)
                    data.WriteUShort((ushort) _chunk.ChunkSections[i].GetLegacyBlockData(k));
            }
            
            for (var i = 0; i < _chunk.ChunkSections.Length; i++)
            {
                if ((mask & 1 << i) == 0) continue;
                _chunk.ChunkSections[i].WriteBlockLight(data);
            }
            
            for (var i = 0; i < _chunk.ChunkSections.Length; i++)
            {
                if ((mask & 1 << i) == 0) continue;
                if(_chunk.ChunkSections[i].HasSkyLight())
                    _chunk.ChunkSections[i].WriteSkyLight(data);
            }
            
            if(_chunk.IsFullChunk())
                _chunk.WriteBiomes(data);

            var chunkData = data.GetBytes();
            buf.WriteVarInt(chunkData.Length);
            buf.Write(chunkData);
        }

        private static byte GetBitsPerBlock(ChunkSection section)
        {
            byte bitsPerBlock = 4;
            while (section.PaletteSize > 1 << bitsPerBlock)
                bitsPerBlock++;

            if (bitsPerBlock > 8)
                bitsPerBlock = MaxBitsBlock;

            return bitsPerBlock;
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