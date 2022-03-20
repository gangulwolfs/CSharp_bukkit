﻿using System;

namespace NiaBukkit.API.Cryptography
{
    public static class AesModule
    {
        private static readonly byte[] SBox =
        {
            //0     1    2      3     4    5     6     7      8    9     A      B    C     D     E     F
            0x63, 0x7c, 0x77, 0x7b, 0xf2, 0x6b, 0x6f, 0xc5, 0x30, 0x01, 0x67, 0x2b, 0xfe, 0xd7, 0xab, 0x76, //0
            0xca, 0x82, 0xc9, 0x7d, 0xfa, 0x59, 0x47, 0xf0, 0xad, 0xd4, 0xa2, 0xaf, 0x9c, 0xa4, 0x72, 0xc0, //1
            0xb7, 0xfd, 0x93, 0x26, 0x36, 0x3f, 0xf7, 0xcc, 0x34, 0xa5, 0xe5, 0xf1, 0x71, 0xd8, 0x31, 0x15, //2
            0x04, 0xc7, 0x23, 0xc3, 0x18, 0x96, 0x05, 0x9a, 0x07, 0x12, 0x80, 0xe2, 0xeb, 0x27, 0xb2, 0x75, //3
            0x09, 0x83, 0x2c, 0x1a, 0x1b, 0x6e, 0x5a, 0xa0, 0x52, 0x3b, 0xd6, 0xb3, 0x29, 0xe3, 0x2f, 0x84, //4
            0x53, 0xd1, 0x00, 0xed, 0x20, 0xfc, 0xb1, 0x5b, 0x6a, 0xcb, 0xbe, 0x39, 0x4a, 0x4c, 0x58, 0xcf, //5
            0xd0, 0xef, 0xaa, 0xfb, 0x43, 0x4d, 0x33, 0x85, 0x45, 0xf9, 0x02, 0x7f, 0x50, 0x3c, 0x9f, 0xa8, //6
            0x51, 0xa3, 0x40, 0x8f, 0x92, 0x9d, 0x38, 0xf5, 0xbc, 0xb6, 0xda, 0x21, 0x10, 0xff, 0xf3, 0xd2, //7
            0xcd, 0x0c, 0x13, 0xec, 0x5f, 0x97, 0x44, 0x17, 0xc4, 0xa7, 0x7e, 0x3d, 0x64, 0x5d, 0x19, 0x73, //8
            0x60, 0x81, 0x4f, 0xdc, 0x22, 0x2a, 0x90, 0x88, 0x46, 0xee, 0xb8, 0x14, 0xde, 0x5e, 0x0b, 0xdb, //9
            0xe0, 0x32, 0x3a, 0x0a, 0x49, 0x06, 0x24, 0x5c, 0xc2, 0xd3, 0xac, 0x62, 0x91, 0x95, 0xe4, 0x79, //A
            0xe7, 0xc8, 0x37, 0x6d, 0x8d, 0xd5, 0x4e, 0xa9, 0x6c, 0x56, 0xf4, 0xea, 0x65, 0x7a, 0xae, 0x08, //B
            0xba, 0x78, 0x25, 0x2e, 0x1c, 0xa6, 0xb4, 0xc6, 0xe8, 0xdd, 0x74, 0x1f, 0x4b, 0xbd, 0x8b, 0x8a, //C
            0x70, 0x3e, 0xb5, 0x66, 0x48, 0x03, 0xf6, 0x0e, 0x61, 0x35, 0x57, 0xb9, 0x86, 0xc1, 0x1d, 0x9e, //D
            0xe1, 0xf8, 0x98, 0x11, 0x69, 0xd9, 0x8e, 0x94, 0x9b, 0x1e, 0x87, 0xe9, 0xce, 0x55, 0x28, 0xdf, //E
            0x8c, 0xa1, 0x89, 0x0d, 0xbf, 0xe6, 0x42, 0x68, 0x41, 0x99, 0x2d, 0x0f, 0xb0, 0x54, 0xbb, 0x16  //F
        };

        private static readonly uint[] T0 = 
        {
      2774754246U, 2222750968U, 2574743534U, 2373680118U, 234025727U, 3177933782U, 2976870366U, 1422247313U,
      1345335392U, 50397442U, 2842126286U, 2099981142U, 436141799U, 1658312629U, 3870010189U, 2591454956U,
      1170918031U, 2642575903U, 1086966153U, 2273148410U, 368769775U, 3948501426U, 3376891790U, 200339707U,
      3970805057U, 1742001331U, 4255294047U, 3937382213U, 3214711843U, 4154762323U, 2524082916U, 1539358875U,
      3266819957U, 486407649U, 2928907069U, 1780885068U, 1513502316U, 1094664062U, 49805301U, 1338821763U,
      1546925160U, 4104496465U, 887481809U, 150073849U, 2473685474U, 1943591083U, 1395732834U, 1058346282U,
      201589768U, 1388824469U, 1696801606U, 1589887901U, 672667696U, 2711000631U, 251987210U, 3046808111U,
      151455502U, 907153956U, 2608889883U, 1038279391U, 652995533U, 1764173646U, 3451040383U, 2675275242U,
      453576978U, 2659418909U, 1949051992U, 773462580U, 756751158U, 2993581788U, 3998898868U, 4221608027U,
      4132590244U, 1295727478U, 1641469623U, 3467883389U, 2066295122U, 1055122397U, 1898917726U, 2542044179U,
      4115878822U, 1758581177U, 0U, 753790401U, 1612718144U, 536673507U, 3367088505U, 3982187446U, 3194645204U,
      1187761037U, 3653156455U, 1262041458U, 3729410708U, 3561770136U, 3898103984U, 1255133061U, 1808847035U,
      720367557U, 3853167183U, 385612781U, 3309519750U, 3612167578U, 1429418854U, 2491778321U, 3477423498U,
      284817897U, 100794884U, 2172616702U, 4031795360U, 1144798328U, 3131023141U, 3819481163U, 4082192802U,
      4272137053U, 3225436288U, 2324664069U, 2912064063U, 3164445985U, 1211644016U, 83228145U, 3753688163U,
      3249976951U, 1977277103U, 1663115586U, 806359072U, 452984805U, 250868733U, 1842533055U, 1288555905U,
      336333848U, 890442534U, 804056259U, 3781124030U, 2727843637U, 3427026056U, 957814574U, 1472513171U,
      4071073621U, 2189328124U, 1195195770U, 2892260552U, 3881655738U, 723065138U, 2507371494U, 2690670784U,
      2558624025U, 3511635870U, 2145180835U, 1713513028U, 2116692564U, 2878378043U, 2206763019U, 3393603212U,
      703524551U, 3552098411U, 1007948840U, 2044649127U, 3797835452U, 487262998U, 1994120109U, 1004593371U,
      1446130276U, 1312438900U, 503974420U, 3679013266U, 168166924U, 1814307912U, 3831258296U, 1573044895U,
      1859376061U, 4021070915U, 2791465668U, 2828112185U, 2761266481U, 937747667U, 2339994098U, 854058965U,
      1137232011U, 1496790894U, 3077402074U, 2358086913U, 1691735473U, 3528347292U, 3769215305U, 3027004632U,
      4199962284U, 133494003U, 636152527U, 2942657994U, 2390391540U, 3920539207U, 403179536U, 3585784431U,
      2289596656U, 1864705354U, 1915629148U, 605822008U, 4054230615U, 3350508659U, 1371981463U, 602466507U,
      2094914977U, 2624877800U, 555687742U, 3712699286U, 3703422305U, 2257292045U, 2240449039U, 2423288032U,
      1111375484U, 3300242801U, 2858837708U, 3628615824U, 84083462U, 32962295U, 302911004U, 2741068226U,
      1597322602U, 4183250862U, 3501832553U, 2441512471U, 1489093017U, 656219450U, 3114180135U, 954327513U,
      335083755U, 3013122091U, 856756514U, 3144247762U, 1893325225U, 2307821063U, 2811532339U, 3063651117U,
      572399164U, 2458355477U, 552200649U, 1238290055U, 4283782570U, 2015897680U, 2061492133U, 2408352771U,
      4171342169U, 2156497161U, 386731290U, 3669999461U, 837215959U, 3326231172U, 3093850320U, 3275833730U,
      2962856233U, 1999449434U, 286199582U, 3417354363U, 4233385128U, 3602627437U, 974525996U
    };

        private static readonly byte[] RCon =
        {
            1, 2, 4, 8, 16, 32, 64, 128, 27, 54, 108, 216, 171, 77, 154, 47, 94, 188, 99, 198, 151, 53, 106, 212, 179, 125, 250, 239, 197, 145
        };

        internal static uint T(uint index) => T0[index];

        internal static uint ColumnToUInt(byte[] table, int column)
        {
            column <<= 2;
            return (uint) (table[column] | table[column + 1] << 8 |
                    table[column + 2] << 16 |
                    table[column + 2] << 24);
        }
        
        internal static byte[] ColumnsToBytes(uint c0, uint c1, uint c2, uint c3)
        {
            return new []
            {
                (byte) c0, (byte) (c0 >> 8), (byte) (c0 >> 16), (byte) (c0 >> 24),
                (byte) c1, (byte) (c1 >> 8), (byte) (c1 >> 16), (byte) (c1 >> 24),
                (byte) c2, (byte) (c2 >> 8), (byte) (c2 >> 16), (byte) (c2 >> 24),
                (byte) c3, (byte) (c3 >> 8), (byte) (c3 >> 16), (byte) (c3 >> 24)
            };
        }

        internal static uint Shift(uint data, int shift) => data << shift | data >> (32 - shift);

        internal static uint SubByte(uint data) => (uint) (SBox[data & byte.MaxValue] |
                                                           SBox[(data >> 8) & byte.MaxValue] << 8 |
                                                           SBox[(data >> 16) & byte.MaxValue] << 16 |
                                                           SBox[(data >> 24) & byte.MaxValue] << 24);



        internal static void GenerateRoundKey(uint[,] roundKey, byte[] key)
        {
            var C0 = ColumnToUInt(key, 0);
            var C1 = ColumnToUInt(key, 1);
            var C2 = ColumnToUInt(key, 2);
            var C3 = ColumnToUInt(key, 3);
            roundKey[0, 0] = C0;
            roundKey[0, 1] = C1;
            roundKey[0, 2] = C2;
            roundKey[0, 3] = C3;
            for (var i = 1; i <= 10; i++)
            {
                var e = SubByte(Shift(C3, 8)) ^ RCon[i - 1];
                roundKey[i, 0] = C0 ^= e;
                roundKey[i, 1] = C1 ^= C0;
                roundKey[i, 2] = C2 ^= C1;
                roundKey[i, 3] = C3 ^= C2;
            }
        }

        internal static uint SubAndShift(uint a, uint b, uint c, uint d)
        {
            return (uint) (SBox[a & byte.MaxValue] | (SBox[b & byte.MaxValue] << 8) | (SBox[c & byte.MaxValue] << 16) |
                           (SBox[d & byte.MaxValue] << 24));
        }

        internal static uint SubMixColumnHelper(uint a, uint b, uint c, uint d)
        {
            return T0[a & byte.MaxValue] ^ Shift(T0[b & byte.MaxValue], 24) ^ Shift(T0[c & byte.MaxValue], 16) ^
                   Shift(T0[d & byte.MaxValue], 8);
        }
    }
}