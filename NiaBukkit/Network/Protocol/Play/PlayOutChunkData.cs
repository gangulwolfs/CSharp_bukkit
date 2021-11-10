using System;
using NiaBukkit.API;
using NiaBukkit.API.Util;
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
            ushort mask = _chunk.GetBitMask();
            buf.WriteVarInt(mask);

            ByteBuf data = new ByteBuf();
            for (int i = 0; i < _chunk.ChunkSections.Length; i++)
            {
                if ((mask & 1 << i) == 0) continue;
                ChunkSection section = _chunk.ChunkSections[i];

                byte bitsPerBlock = GetBitsPerBlock(section);
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
                
                long[] chunkArray = ChunkDataVersionUtil.ChunkCompactArray(bitsPerBlock,
                    bitsPerBlock == MaxBitsBlock ? section.GetOldBlockData : section.GetPaletteIndex);
                data.WriteVarInt(chunkArray.Length);

                foreach (long d in chunkArray)
                    data.WriteLong(d);

                _chunk.ChunkSections[i].WriteBlockLight(data);
                if (_chunk.ChunkSections[i].HasSkyLight())
                    _chunk.ChunkSections[i].WriteSkyLight(data);
            }

            if (_chunk.IsFullChunk())
                _chunk.WriteBiomes(data);

            long[] ch = new long[data.WriteLength / 8];
            byte[] ori = data.GetBytes();
            for (int i = 0; i < data.WriteLength - 7; i += 8)
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
                    data.WriteUShort((ushort) _chunk.ChunkSections[i].GetOldBlockData(k));
            }
            
            for (int i = 0; i < _chunk.ChunkSections.Length; i++)
            {
                if ((mask & 1 << i) == 0) continue;
                _chunk.ChunkSections[i].WriteBlockLight(data);
            }
            
            for (int i = 0; i < _chunk.ChunkSections.Length; i++)
            {
                if ((mask & 1 << i) == 0) continue;
                if(_chunk.ChunkSections[i].HasSkyLight())
                    _chunk.ChunkSections[i].WriteSkyLight(data);
            }
            
            if(_chunk.IsFullChunk())
                _chunk.WriteBiomes(data);

            byte[] chunkData = data.GetBytes();
            buf.WriteVarInt(chunkData.Length);
            buf.Write(chunkData);
        }

        private byte GetBitsPerBlock(ChunkSection section)
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
            if (protocol > ProtocolVersion.v1_16_5)
                return 34;
            if (protocol > ProtocolVersion.v1_15_2)
                return 32;
            if (protocol > ProtocolVersion.v1_14_3_CT)
                return 34;
            if (protocol > ProtocolVersion.v1_13_2)
                return 33;
            if (protocol > ProtocolVersion.v1_12_2)
                return 34;
            if (protocol >= ProtocolVersion.v1_9)
                return 32;
            
            return 33;
        }
    }
}