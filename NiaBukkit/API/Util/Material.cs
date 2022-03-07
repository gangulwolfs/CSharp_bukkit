using System.Text;

namespace NiaBukkit.API.Util
{
    public enum Material
    {
        [MaterialAttribute(9648, 0, 0)]
        Air,
        [MaterialAttribute(22948,1)]
        Stone,
        [MaterialAttribute(21091,1, 1)]
        Granite,
        [MaterialAttribute(5477,1, 2)]
        PolishedGranite,
        [MaterialAttribute(24688,1, 3)]
        Diorite,
        [MaterialAttribute(31615,1, 4)]
        PolishedDiorite,
        [MaterialAttribute(25975,1, 5)]
        Andesite,
        [MaterialAttribute(8335,1, 6)]
        PolishedAndesite,
        [MaterialAttribute(28346,2)]
        GrassBlock,
        [MaterialAttribute(10580,3)]
        Dirt,
        [MaterialAttribute(15411,3, 1)]
        CoarseDirt,
        [MaterialAttribute(24068,3, 2)]
        Podzol,
        [MaterialAttribute(18139)]
        CrimsonNylium,
        [MaterialAttribute(26396)]
        WarpedNylium,
        [MaterialAttribute(32147,4)]
        Cobblestone,
        [MaterialAttribute(14905,5)]
        OakPlanks,
        [MaterialAttribute(14593,5, 1)]
        SprucePlanks,
        [MaterialAttribute(29322,5, 2)]
        BirchPlanks,
        [MaterialAttribute(26445,5, 3)]
        JunglePlanks,
        [MaterialAttribute(31312,5, 4)]
        AcaciaPlanks,
        [MaterialAttribute(20869,5, 5)]
        DarkOakPlanks,
        [MaterialAttribute(18812, 5)]
        CrimsonPlanks,
        [MaterialAttribute(16045,5)]
        WarpedPlanks,
        [MaterialAttribute(9636,6)]
        OakSapling,
        [MaterialAttribute(19874,6, 1)]
        SpruceSapling,
        [MaterialAttribute(31533,6, 2)]
        BirchSapling,
        [MaterialAttribute(17951,6, 3)]
        JungleSapling,
        [MaterialAttribute(20806,6, 4)]
        AcaciaSapling,
        [MaterialAttribute(14933,6, 5)]
        DarkOakSapling,
        [MaterialAttribute(23130,7)]
        Bedrock,
        [MaterialAttribute(11542,12)]
        Sand,
        [MaterialAttribute(16279,12, 1)]
        RedSand,
        [MaterialAttribute(7804,13)]
        Gravel,
        [MaterialAttribute(32625,14)]
        GoldOre,
        [MaterialAttribute(19834,15)]
        IronOre,
        [MaterialAttribute(30965,16)]
        CoalOre,
        [MaterialAttribute(4185,14)]
        NetherGoldOre,
        [MaterialAttribute(26723,17)]
        OakLog,
        [MaterialAttribute(9726,17, 1)]
        SpruceLog,
        [MaterialAttribute(26727,17, 2)]
        BirchLog,
        [MaterialAttribute(20721,17, 3)]
        JungleLog,
        [MaterialAttribute(8385,162)]
        AcaciaLog,
        [MaterialAttribute(14831,162, 1)]
        DarkOakLog,
        [MaterialAttribute(27920,17)]
        CrimsonStem,
        [MaterialAttribute(28920,17)]
        WarpedStem,
        [MaterialAttribute(20523,17)]
        StrippedOakLog,
        [MaterialAttribute(6140,17, 1)]
        StrippedSpruceLog,
        [MaterialAttribute(8838,17, 2)]
        StrippedBirchLog,
        [MaterialAttribute(15476,17, 3)]
        StrippedJungleLog,
        [MaterialAttribute(18167,162)]
        StrippedAcaciaLog,
        [MaterialAttribute(6492,162, 1)]
        StrippedDarkOakLog,
        [MaterialAttribute(16882,17)]
        StrippedCrimsonStem,
        [MaterialAttribute(15627,17)]
        StrippedWarpedStem,
        [MaterialAttribute(31455,17)]
        StrippedOakWood,
        [MaterialAttribute(6467,17, 1)]
        StrippedSpruceWood,
        [MaterialAttribute(22350,17, 2)]
        StrippedBirchWood,
        [MaterialAttribute(30315,17, 3)]
        StrippedJungleWood,
        [MaterialAttribute(27193,162)]
        StrippedAcaciaWood,
        [MaterialAttribute(16000,162, 1)]
        StrippedDarkOakWood,
        [MaterialAttribute(27488,17)]
        StrippedCrimsonHyphae,
        [MaterialAttribute(7422,17)]
        StrippedWarpedHyphae,
        [MaterialAttribute(7378,17)]
        OakWood,
        [MaterialAttribute(32328,17, 1)]
        SpruceWood,
        [MaterialAttribute(20913,17, 2)]
        BirchWood,
        [MaterialAttribute(10341,17, 3)]
        JungleWood,
        [MaterialAttribute(9541,162)]
        AcaciaWood,
        [MaterialAttribute(16995,162, 1)]
        DarkOakWood,
        [MaterialAttribute(6550,17)]
        CrimsonHyphae,
        [MaterialAttribute(18439,17)]
        WarpedHyphae,
        [MaterialAttribute(4385,18)]
        OakLeaves,
        [MaterialAttribute(20039,18, 1)]
        SpruceLeaves,
        [MaterialAttribute(12601,18, 2)]
        BirchLeaves,
        [MaterialAttribute(5133,18, 3)]
        JungleLeaves,
        [MaterialAttribute(16606,161)]
        AcaciaLeaves,
        [MaterialAttribute(22254,161, 1)]
        DarkOakLeaves,
        [MaterialAttribute(15860,19)]
        Sponge,
        [MaterialAttribute(9043,19, 1)]
        WetSponge,
        [MaterialAttribute(6195,10)]
        Glass,
        [MaterialAttribute(22934,21)]
        LapisOre,
        [MaterialAttribute(14485,22)]
        LapisBlock,
        [MaterialAttribute(20871,23)]
        Dispenser,
        [MaterialAttribute(13141,24)]
        Sandstone,
        [MaterialAttribute(31763,24, 1)]
        ChiseledSandstone,
        [MaterialAttribute(6118,24, 2)]
        CutSandStone,
        [MaterialAttribute(20979,25)]
        NoteBlock,
        [MaterialAttribute(11064,27)]
        PoweredRail,
        [MaterialAttribute(13475,28)]
        DetectorRail,
        [MaterialAttribute(18127,29)]
        StickyPiston,
        [MaterialAttribute(9469,30)]
        Cobweb,
        [MaterialAttribute(6155,31, 1)]
        Grass,
        [MaterialAttribute(15794,31, 2)]
        Fern,
        [MaterialAttribute(22888,32)]
        DeadBush,
        [MaterialAttribute(23942,31, 1)]
        Seagrass,
        [MaterialAttribute(19562,31, 2)]
        SeaPickle,
        [MaterialAttribute(21130,33)]
        Piston,
        [MaterialAttribute(8624,35)]
        WhiteWool,
        [MaterialAttribute(23957,35, 1)]
        OrangeWool,
        [MaterialAttribute(11853,35, 2)]
        MagentaWool,
        [MaterialAttribute(21073,35, 3)]
        LightBlueWool,
        [MaterialAttribute(29507,35, 4)]
        YellowWool,
        [MaterialAttribute(10443,35, 5)]
        LimeWool,
        [MaterialAttribute(7611,35, 6)]
        PinkWool,
        [MaterialAttribute(27209,35, 7)]
        GrayWool,
        [MaterialAttribute(22936,35, 8)]
        LightGrayWool,
        [MaterialAttribute(12221,35, 9)]
        CyanWool,
        [MaterialAttribute(11922,35, 10)]
        PurpleWool,
        [MaterialAttribute(15738,35, 11)]
        BlueWool,
        [MaterialAttribute(32638,35, 12)]
        BrownWool,
        [MaterialAttribute(25085,35, 13)]
        GreenWool,
        [MaterialAttribute(11621,35, 14)]
        RedWool,
        [MaterialAttribute(16693,35, 15)]
        BlackWool,
        [MaterialAttribute(30558, 37)]
        Dandelion,
        [MaterialAttribute(12851, 38)]
        Poppy,
        [MaterialAttribute(13432, 38, 1)]
        BlueOrchid,
        [MaterialAttribute(6871,38, 2)]
        Allium,
        [MaterialAttribute(17608,38, 3)]
        AzureBluet,
        [MaterialAttribute(16781,38, 4)]
        RedTulip,
        [MaterialAttribute(26038,38, 5)]
        OrangeTulip,
        [MaterialAttribute(31495,38, 6)]
        WhiteTulip,
        [MaterialAttribute(27319,38, 7)]
        PinkTulip,
        [MaterialAttribute(11709,38, 8)]
        OxeyeDaisy,
        [MaterialAttribute(15405,38, 1)]
        Cornflower,
        [MaterialAttribute(7185, 38, 8)]
        LilyOfTheValley,
        [MaterialAttribute(8619,38)]
        WitherRose,
        [MaterialAttribute(9665,39)]
        BrownMushroom,
        [MaterialAttribute(19728,40)]
        RedMushRoom,
        [MaterialAttribute(26268, 38)]
        CrimsonFungus,
        [MaterialAttribute(19799, 38, 3)]
        WarpedFungus,
        [MaterialAttribute(14064, 31, 1)]
        CrimsonRoots,
        [MaterialAttribute(13932,31, 1)]
        WarpedRoots,
        [MaterialAttribute(10431, 31, 1)]
        NetherSprouts,
        [MaterialAttribute(29267, 106)]
        WeepingVines,
        [MaterialAttribute(27283,106)]
        TwistingVines,
        [MaterialAttribute(7726,338)]
        SugarCane,
        [MaterialAttribute(21916, 338)]
        Kelp,
        [MaterialAttribute(18728, 338)]
        Bamboo,
        [MaterialAttribute(27392, 41)]
        GoldBlock,
        [MaterialAttribute(24754,42)]
        IronBlock,
        [MaterialAttribute(12002,126)]
        OakSlab,
        [MaterialAttribute(28798,126, 1)]
        SpruceSlab,
        [MaterialAttribute(13807,126, 2)]
        BirchSlab,
        [MaterialAttribute(19117,126, 3)]
        JungleSlab,
        [MaterialAttribute(23730,126, 4)]
        AcaciaSlab,
        [MaterialAttribute(28852,126, 5)]
        DarkOakSlab,
        [MaterialAttribute(4691,126)]
        CrimsonSlab,
        [MaterialAttribute(27150,126)]
        WarpedSlab,
        [MaterialAttribute(19838,44)]
        StoneSlab,
        [MaterialAttribute(24129,44)]
        SmoothStoneSlab,
        [MaterialAttribute(29830,44, 1)]
        SandstoneSlab,
        [MaterialAttribute(30944, 44, 1)]
        CutSandstoneSlab,
        [MaterialAttribute(18658, 126)]
        PetrifiedOakSlab,
        [MaterialAttribute(6340,44, 3)]
        CobblestoneSlab,
        [MaterialAttribute(26333,44, 4)]
        BrickSlab,
        [MaterialAttribute(19676,44, 5)]
        StoneBrickSlab,
        [MaterialAttribute(26586,44, 6)]
        NetherBrickSlab,
        [MaterialAttribute(4423,44, 7)]
        QuartzSlab,
        [MaterialAttribute(17550, 182)]
        RedSandstoneSlab,
        [MaterialAttribute(7220,182)]
        CutRedSandstoneSlab,
        [MaterialAttribute(11487,205)]
        PurpurSlab,
        [MaterialAttribute(31323,44, 3)]
        PrismarineSlab,
        [MaterialAttribute(25624,44, 3)]
        PrismarineBrickSlab,
        [MaterialAttribute(7577,44, 3)]
        DarkPrismarineSlab,
        [MaterialAttribute(14415, 155)]
        SmoothQuartz,
        [MaterialAttribute(25180,179, 2)]
        SmoothRedSandstone,
        [MaterialAttribute(30039,179)]
        SmoothSandstone,
        [MaterialAttribute(21910,1)]
        SmoothStone,
        [MaterialAttribute(14165,45)]
        Bricks,
        [MaterialAttribute(7896,46)]
        Tnt,
        [MaterialAttribute(10069,47)]
        Bookshelf,
        [MaterialAttribute(21900, 48)]
        MossyCobblestone,
        [MaterialAttribute(32723,49)]
        Obsidian,
        [MaterialAttribute(6063, 50)]
        Torch,
        [MaterialAttribute(24832, 50)]
        EndRod,
        [MaterialAttribute(28243, 28243)]
        ChorusPlant,
        [MaterialAttribute(28542,28542)]
        ChorusFlower,
        [MaterialAttribute(7538,201)]
        PurpurBlock,
        [MaterialAttribute(26718,202)]
        PurpurPillar,
        [MaterialAttribute(8921,203)]
        PurpurStairs,
        [MaterialAttribute(7018,52)]
        Spawner,
        [MaterialAttribute(5449,53)]
        OakStairs,
        [MaterialAttribute(22969, 54)]
        Chest,
        [MaterialAttribute(9292,56)]
        DiamondOre,
        [MaterialAttribute(5944, 57)]
        DiamondBlock,
        [MaterialAttribute(20706, 58)]
        CraftingTable,
        [MaterialAttribute(31166, 60)]
        Farmland,
        [MaterialAttribute(8133,61)]
        Furnace,
        [MaterialAttribute(23599,65)]
        Ladder,
        [MaterialAttribute(13285,66)]
        Rail,
        [MaterialAttribute(24715,67)]
        CobblestoneStairs,
        [MaterialAttribute(15319,69)]
        Lever,
        [MaterialAttribute(22591,70)]
        StonePressurePlate,
        [MaterialAttribute(20108,72)]
        OakPressurePlate,
        [MaterialAttribute(15932,72)]
        SprucePressurePlate,
        [MaterialAttribute(9664,72)]
        BirchPressurePlate,
        [MaterialAttribute(11376,72)]
        JunglePressurePlate,
        [MaterialAttribute(17586,72)]
        AcaciaPressurePlate,
        [MaterialAttribute(31375,72)]
        DarkOakPressurePlate,
        [MaterialAttribute(18316,72)]
        CrimsonPressurePlate,
        [MaterialAttribute(29516,72)]
        WarpedPressurePlate,
        [MaterialAttribute(32340,70)]
        PolishedBlackstonePressurePlate,
        [MaterialAttribute(10887,73)]
        RedstoneOre,
        [MaterialAttribute(22547,76)]
        RedstoneTorch,
        [MaterialAttribute(14146,78)]
        Snow,
        [MaterialAttribute(30428,79)]
        Ice,
        [MaterialAttribute(19913, 80)]
        SnowBlock,
        [MaterialAttribute(12191,81)]
        Cactus,
        [MaterialAttribute(27880,82)]
        Clay,
        [MaterialAttribute(19264,84)]
        Jukebox,
        [MaterialAttribute(6442,85)]
        OakFence,
        [MaterialAttribute(25416,188)]
        SpruceFence,
        [MaterialAttribute(17347,189)]
        BirchFence,
        [MaterialAttribute(14358,190)]
        JungleFence,
        [MaterialAttribute(4569,192)]
        AcaciaFence,
        [MaterialAttribute(21767,191)]
        DarkOakFence,
        [MaterialAttribute(21075,85)]
        CrimsonFence,
        [MaterialAttribute(18438,85)]
        WarpedFence,
        [MaterialAttribute(19170, 86)]
        Pumpkin,
        [MaterialAttribute(25833,86)]
        CarvedPumpkin,
        [MaterialAttribute(23425,87)]
        NetherRack,
        [MaterialAttribute(16841,88)]
        SoulSand,
        [MaterialAttribute(31140,88)]
        SoulSoil,
        [MaterialAttribute(28478, 1)]
        Basalt,
        [MaterialAttribute(11659,1, 6)]
        PolishedBasalt,
        [MaterialAttribute(14292,50)]
        SoulTorch,
        [MaterialAttribute(32713, 89)]
        Glowstone,
        [MaterialAttribute(13758,91)]
        JackOLantern,
        [MaterialAttribute(16927, 96)]
        OakTrapdoor,
        [MaterialAttribute(10289,96)]
        SpruceTrapdoor,
        [MaterialAttribute(32585,96)]
        BirchTrapdoor,
        [MaterialAttribute(8626,96)]
        JungleTrapdoor,
        [MaterialAttribute(18343,96)]
        AcaciaTrapdoor,
        [MaterialAttribute(10355,96)]
        DarkOakTrapdoor,
        [MaterialAttribute(25056,96)]
        CrimsonTrapdoor,
        [MaterialAttribute(7708,96)]
        WarpedTrapdoor,
        [MaterialAttribute(18440, 97)]
        InfestedStone,
        [MaterialAttribute(4348,97, 1)]
        InfestedCobblestone,
        [MaterialAttribute(19749,97, 2)]
        InfestedStoneBricks,
        [MaterialAttribute(9850,97, 3)]
        InfestedMossyStoneBricks,
        [MaterialAttribute(7476,97, 4)]
        InfestedCrackedStoneBricks,
        [MaterialAttribute(4728,97, 5)]
        InfestedChiseledStoneBricks,
        [MaterialAttribute(6962,98)]
        StoneBricks,
        [MaterialAttribute(16415,98, 1)]
        MossyStoneBricks,
        [MaterialAttribute(27869,98, 2)]
        CrackedStoneBricks,
        [MaterialAttribute(9087,98, 3)]
        ChiseledStoneBricks,
        [MaterialAttribute(6291,99)]
        BrownMushroomBlock,
        [MaterialAttribute(20766,100)]
        RedMushroomBlock,
        [MaterialAttribute(16543,99)]
        MushroomStem,
        [MaterialAttribute(9378,101)]
        IronBars,
        [MaterialAttribute(28265,101)]
        Chain,
        [MaterialAttribute(5709,102)]
        GlassPane,
        [MaterialAttribute(25172,103)]
        Melon,
        [MaterialAttribute(14564,106)]
        Vine,
        [MaterialAttribute(16689,107)]
        OakFenceGate,
        [MaterialAttribute(26423,183)]
        SpruceFenceGate,
        [MaterialAttribute(6322,184)]
        BirchFenceGate,
        [MaterialAttribute(21360,185)]
        JungleFenceGate,
        [MaterialAttribute(14145,187)]
        AcaciaFenceGate,
        [MaterialAttribute(10679,186)]
        DarkOakFenceGate,
        [MaterialAttribute(15602,107)]
        CrimsonFenceGate,
        [MaterialAttribute(11115,107)]
        WarpedFenceGate,
        [MaterialAttribute(21534,108)]
        BrickStairs,
        [MaterialAttribute(27032,109)]
        StoneBrickStairs,
        [MaterialAttribute(9913,110)]
        Mycelium,
        [MaterialAttribute(19271,111)]
        LilyPad,
        [MaterialAttribute(27802,112)]
        NetherBricks,
        [MaterialAttribute(10888,112)]
        CrackedNetherBricks,
        [MaterialAttribute(21613,112)]
        ChiseledNetherBricks,
        [MaterialAttribute(5286,113)]
        NetherBrickFence,
        [MaterialAttribute(12085,114)]
        NetherBrickStairs,
        [MaterialAttribute(16255,116)]
        EnchantingTable,
        [MaterialAttribute(15480,120)]
        EndPortalFrame,
        [MaterialAttribute(29686,121)]
        EndStone,
        [MaterialAttribute(20314,121)]
        EndStoneBricks,
        [MaterialAttribute(29946,122)]
        DragonEgg,
        [MaterialAttribute(8217,123)]
        RedstoneLamp,
        [MaterialAttribute(18474,128)]
        SandstoneStairs,
        [MaterialAttribute(16630,129)]
        EmeraldOre,
        [MaterialAttribute(32349,130)]
        EnderChest,
        [MaterialAttribute(8130,131)]
        TripwireHook,
        [MaterialAttribute(9914,133)]
        EmeraldBlock,
        [MaterialAttribute(11192,134)]
        SpruceStairs,
        [MaterialAttribute(7657,135)]
        BirchStairs,
        [MaterialAttribute(20636,136)]
        JungleStairs,
        [MaterialAttribute(32442,53)]
        CrimsonStairs,
        [MaterialAttribute(17721,53)]
        WarpedStairs,
        [MaterialAttribute(4355, 137)]
        CommandBlock,
        [MaterialAttribute(6608,138)]
        Beacon,
        [MaterialAttribute(12616,139)]
        CobblestoneWall,
        [MaterialAttribute(11536,139, 1)]
        MossyCobblestoneWall,
        [MaterialAttribute(18995,139)]
        BrickWall,
        [MaterialAttribute(18184,139)]
        PrismarineWall,
        [MaterialAttribute(4753,139)]
        RedSandstoneWall,
        [MaterialAttribute(18259,139)]
        MossyStoneBrickWall,
        [MaterialAttribute(23279,139)]
        GraniteWall,
        [MaterialAttribute(29073,139)]
        StoneBrickWall,
        [MaterialAttribute(10398,139)]
        NetherBrickWall,
        [MaterialAttribute(14938,139)]
        AndesiteWall,
        [MaterialAttribute(4580,139)]
        RedNetherBrickWall,
        [MaterialAttribute(18470,139)]
        SandstoneWall,
        [MaterialAttribute(27225,139)]
        EndStoneBrickWall,
        [MaterialAttribute(17412,139)]
        DioriteWall,
        [MaterialAttribute(17327,139)]
        BlackstoneWall,
        [MaterialAttribute(15119,139)]
        PolishedBlackstoneWall,
        [MaterialAttribute(9540,139)]
        PolishedBlackstoneBrickWall,
        [MaterialAttribute(12279,77)]
        StoneButton,
        [MaterialAttribute(13510,148)]
        OakButton,
        [MaterialAttribute(23281,148)]
        SpruceButton,
        [MaterialAttribute(26934,148)]
        BirchButton,
        [MaterialAttribute(25317,148)]
        JungleButton,
        [MaterialAttribute(13993,148)]
        AcaciaButton,
        [MaterialAttribute(6214,148)]
        DarkOakButton,
        [MaterialAttribute(26799,148)]
        CrimsonButton,
        [MaterialAttribute(25264,148)]
        WarpedButton,
        [MaterialAttribute(20760,148)]
        PolishedBlackstoneButton,
        [MaterialAttribute(18718,145)]
        Anvil,
        [MaterialAttribute(10623,145, 1)]
        ChippedAnvil,
        [MaterialAttribute(10274,145, 2)]
        DamagedAnvil,
        [MaterialAttribute(18970,146)]
        TrappedChest,
        [MaterialAttribute(14875,147)]
        LightWeightedPressurePlate,
        [MaterialAttribute(16970,148)]
        HeavyWeightedPressurePlate,
        [MaterialAttribute(8864,151)]
        DaylightDetector,
        [MaterialAttribute(19496,152)]
        RedstoneBlock,
        [MaterialAttribute(4807,153)]
        NetherQuartzOre,
        [MaterialAttribute(31974,154)]
        Hopper,
        [MaterialAttribute(30964,155, 1)]
        ChiseledQuartzBlock,
        [MaterialAttribute(11987,155)]
        QuartzBlock,
        [MaterialAttribute(23358,155)]
        QuartzBricks,
        [MaterialAttribute(16452,155, 2)]
        QuartzPillar,
        [MaterialAttribute(24079,156)]
        QuartzStairs,
        [MaterialAttribute(5834,157)]
        ActivatorRail,
        [MaterialAttribute(31273,158)]
        Dropper,
        [MaterialAttribute(20975,159)]
        WhiteTerracotta,
        [MaterialAttribute(18684,159, 1)]
        OrangeTerracotta,
        [MaterialAttribute(25900,159, 2)]
        MagentaTerracotta,
        [MaterialAttribute(31779,159, 3)]
        LightBlueTerracotta,
        [MaterialAttribute(32129,159, 4)]
        YellowTerracotta,
        [MaterialAttribute(24013,159, 5)]
        LimeTerracotta,
        [MaterialAttribute(23727,159, 6)]
        PinkTerracotta,
        [MaterialAttribute(18004,159, 7)]
        GrayTerracotta,
        [MaterialAttribute(26388,159, 8)]
        LightGrayTerracotta,
        [MaterialAttribute(25940,159, 9)]
        CyanTerracotta,
        [MaterialAttribute(10387,159, 10)]
        PurpleTerracotta,
        [MaterialAttribute(5236,159, 11)]
        BlueTerracotta,
        [MaterialAttribute(23664,159, 12)]
        BrownTerracotta,
        [MaterialAttribute(4105,159, 13)]
        GreenTerracotta,
        [MaterialAttribute(5086,159, 14)]
        RedTerracotta,
        [MaterialAttribute(26691,159, 15)]
        BlackTerracotta,
        [MaterialAttribute(26453,166)]
        Barrier,
        [MaterialAttribute(17095,167)]
        IronTrapdoor,
        [MaterialAttribute(17461,170)]
        HayBlock,
        [MaterialAttribute(15117,171)]
        WhiteCarpet,
        [MaterialAttribute(24752,171, 1)]
        OrangeCarpet,
        [MaterialAttribute(6180,171, 2)]
        MagentaCarpet,
        [MaterialAttribute(21194,171, 3)]
        LightBlueCarpet,
        [MaterialAttribute(18149,171, 4)]
        YellowCarpet,
        [MaterialAttribute(15443,171, 5)]
        LimeCarpet,
        [MaterialAttribute(27381,171, 6)]
        PinkCarpet,
        [MaterialAttribute(26991,171, 7)]
        GrayCarpet,
        [MaterialAttribute(11317,171, 8)]
        LightGrayCarpet,
        [MaterialAttribute(9742,171, 9)]
        CyanCarpet,
        [MaterialAttribute(5574,171, 10)]
        PurpleCarpet,
        [MaterialAttribute(13292,171, 11)]
        BlueCarpet,
        [MaterialAttribute(23352,171, 12)]
        BrownCarpet,
        [MaterialAttribute(7780,171, 13)]
        GreenCarpet,
        [MaterialAttribute(5424,171, 14)]
        RedCarpet,
        [MaterialAttribute(6056,171, 15)]
        BlackCarpet,
        [MaterialAttribute(16544, 172)]
        Terracotta,
        [MaterialAttribute(27968,173)]
        CoalBlock,
        [MaterialAttribute(28993,174)]
        PackedIce,
        [MaterialAttribute(17453,163)]
        AcaciaStairs,
        [MaterialAttribute(22921,164)]
        DarkOakStairs,
        [MaterialAttribute(31892,165)]
        SlimeBlock,
        [MaterialAttribute(8604,208)]
        GrassPath,
        [MaterialAttribute(7408,175)]
        Sunflower,
        [MaterialAttribute(22837,175, 1)]
        Lilac,
        [MaterialAttribute(6080,175, 4)]
        RoseBush,
        [MaterialAttribute(21155,175, 5)]
        Peony,
        [MaterialAttribute(21559,175, 2)]
        TallGrass,
        [MaterialAttribute(30177,175, 3)]
        LargeFern,
        [MaterialAttribute(31190,95)]
        WhiteStainedGlass,
        [MaterialAttribute(25142,95, 1)]
        OrangeStainedGlass,
        [MaterialAttribute(26814,95, 2)]
        MagentaStainedGlass,
        [MaterialAttribute(17162,95, 3)]
        LightBlueStainedGlass,
        [MaterialAttribute(12182,95, 4)]
        YellowStainedGlass,
        [MaterialAttribute(24266,95, 5)]
        LimeStainedGlass,
        [MaterialAttribute(16164,95, 6)]
        PinkStainedGlass,
        [MaterialAttribute(29979,95, 7)]
        GrayStainedGlass,
        [MaterialAttribute(5843,95, 8)]
        LightGrayStainedGlass,
        [MaterialAttribute(30604,95, 9)]
        CyanStainedGlass,
        [MaterialAttribute(21845,95, 10)]
        PurpleStainedGlass,
        [MaterialAttribute(7107,95, 11)]
        BlueStainedGlass,
        [MaterialAttribute(20945,95, 12)]
        BrownStainedGlass,
        [MaterialAttribute(22503,95, 13)]
        GreenStainedGlass,
        [MaterialAttribute(9717,95, 14)]
        RedStainedGlass,
        [MaterialAttribute(13941,95, 15)]
        BlackStainedGlass,
        [MaterialAttribute(10557,160)]
        WhiteStainedGlassPane,
        [MaterialAttribute(21089,160, 1)]
        OrangeStainedGlassPane,
        [MaterialAttribute(14082, 160, 2)]
        MagentaStainedGlassPane,
        [MaterialAttribute(18721,160, 3)]
        LightBlueStainedGlassPane,
        [MaterialAttribute(20298,160, 4)]
        YellowStainedGlassPane,
        [MaterialAttribute(10610,160, 5)]
        LimeStainedGlassPane,
        [MaterialAttribute(24637,160, 6)]
        PinkStainedGlassPane,
        [MaterialAttribute(25272,160, 7)]
        GrayStainedGlassPane,
        [MaterialAttribute(19008,160, 8)]
        LightGrayStainedGlassPane,
        [MaterialAttribute(11784,160, 9)]
        CyanStainedGlassPane,
        [MaterialAttribute(10948,160, 10)]
        PurpleStainedGlassPane,
        [MaterialAttribute(28484,160, 11)]
        BlueStainedGlassPane,
        [MaterialAttribute(17557,160, 12)]
        BrownStainedGlassPane,
        [MaterialAttribute(4767,160, 13)]
        GreenStainedGlassPane,
        [MaterialAttribute(8630,160, 14)]
        RedStainedGlassPane,
        [MaterialAttribute(13201,160, 15)]
        BlackStainedGlassPane,
        [MaterialAttribute(7539,168)]
        Prismarine,
        [MaterialAttribute(29118,168, 1)]
        PrismarineBricks,
        [MaterialAttribute(19940,168, 2)]
        DarkPrismarine,
        [MaterialAttribute(19217,67)]
        PrismarineStairs,
        [MaterialAttribute(15445,67)]
        PrismarineBrickStairs,
        [MaterialAttribute(26511,67)]
        DarkPrismarineStairs,
        [MaterialAttribute(20780,169)]
        SeaLantern,
        [MaterialAttribute(9092,179)]
        RedSandstone,
        [MaterialAttribute(15529,179, 1)]
        ChiseledRedSandstone,
        [MaterialAttribute(26842,179)]
        CutRedSandstone,
        [MaterialAttribute(25466,180)]
        RedSandstoneStairs,
        [MaterialAttribute(12405,210)]
        RepeatingCommandBlock,
        [MaterialAttribute(26798,211)]
        ChainCommandBlock,
        [MaterialAttribute(25927,113)]
        MagmaBlock,
        [MaterialAttribute(15486,214)]
        NetherWartBlock,
        [MaterialAttribute(15463,214)]
        WarpedWartBlock,
        [MaterialAttribute(18056,215)]
        RedNetherBricks,
        [MaterialAttribute(17312,216)]
        BoneBlock,
        [MaterialAttribute(30806,217)]
        StructureVoid,
        [MaterialAttribute(10726, 218)]
        Observer,
        [MaterialAttribute(7776, 229)]
        ShulkerBox,
        [MaterialAttribute(31750,219)]
        WhiteShulkerBox,
        [MaterialAttribute(21673,220)]
        OrangeShulkerBox,
        [MaterialAttribute(21566,221)]
        MagentaShulkerBox,
        [MaterialAttribute(18226,222)]
        LightBlueShulkerBox,
        [MaterialAttribute(28700,223)]
        YellowShulkerBox,
        [MaterialAttribute(28360,224)]
        LimeShulkerBox,
        [MaterialAttribute(24968,225)]
        PinkShulkerBox,
        [MaterialAttribute(12754,226)]
        GrayShulkerBox,
        [MaterialAttribute(21345,227)]
        LightGrayShulkerBox,
        [MaterialAttribute(28123,228)]
        CyanShulkerBox,
        [MaterialAttribute(10373,229)]
        PurpleShulkerBox,
        [MaterialAttribute(11476,230)]
        BlueShulkerBox,
        [MaterialAttribute(24230,231)]
        BrownShulkerBox,
        [MaterialAttribute(9377,232)]
        GreenShulkerBox,
        [MaterialAttribute(32448,233)]
        RedShulkerBox,
        [MaterialAttribute(24076,234)]
        BlackShulkerBox,
        [MaterialAttribute(11326,235)]
        WhiteGlazedTerracotta,
        [MaterialAttribute(27451,236)]
        OrangeGlazedTerracotta,
        [MaterialAttribute(8067,237)]
        MagentaGlazedTerracotta,
        [MaterialAttribute(4336,238)]
        LightBlueGlazedTerracotta,
        [MaterialAttribute(10914,239)]
        YellowGlazedTerracotta,
        [MaterialAttribute(13861,240)]
        LimeGlazedTerracotta,
        [MaterialAttribute(10260,241)]
        PinkGlazedTerracotta,
        [MaterialAttribute(6256,242)]
        GrayGlazedTerracotta,
        [MaterialAttribute(10707,243)]
        LightGrayGlazedTerracotta,
        [MaterialAttribute(9550,244)]
        CyanGlazedTerracotta,
        [MaterialAttribute(4818,245)]
        PurpleGlazedTerracotta,
        [MaterialAttribute(23823,246)]
        BlueGlazedTerracotta,
        [MaterialAttribute(5655,247)]
        BrownGlazedTerracotta,
        [MaterialAttribute(6958,248)]
        GreenGlazedTerracotta,
        [MaterialAttribute(24989,249)]
        RedGlazedTerracotta,
        [MaterialAttribute(29678,250)]
        BlackGlazedTerracotta,
        [MaterialAttribute(6281,251)]
        WhiteConcrete,
        [MaterialAttribute(19914,251, 1)]
        OrangeConcrete,
        [MaterialAttribute(20591,251, 2)]
        MagentaConcrete,
        [MaterialAttribute(29481,251, 3)]
        LightBlueConcrete,
        [MaterialAttribute(15722,251, 4)]
        YellowConcrete,
        [MaterialAttribute(5863,251, 5)]
        LimeConcrete,
        [MaterialAttribute(5227,251, 6)]
        PinkConcrete,
        [MaterialAttribute(13959,251, 7)]
        GrayConcrete,
        [MaterialAttribute(14453,251, 8)]
        LightGrayConcrete,
        [MaterialAttribute(26522,251, 9)]
        CyanConcrete,
        [MaterialAttribute(20623,251, 10)]
        PurpleConcrete,
        [MaterialAttribute(18756,251, 11)]
        BlueConcrete,
        [MaterialAttribute(19006,251, 12)]
        BrownConcrete,
        [MaterialAttribute(17949,251, 13)]
        GreenConcrete,
        [MaterialAttribute(8032,251, 14)]
        RedConcrete,
        [MaterialAttribute(13338,251, 15)]
        BlackConcrete,
        [MaterialAttribute(10363,252)]
        WhiteConcretePowder,
        [MaterialAttribute(30159,252, 1)]
        OrangeConcretePowder,
        [MaterialAttribute(8272,252, 2)]
        MagentaConcretePowder,
        [MaterialAttribute(31206,252, 3)]
        LightBlueConcretePowder,
        [MaterialAttribute(10655,252, 4)]
        YellowConcretePowder,
        [MaterialAttribute(28859,252, 5)]
        LimeConcretePowder,
        [MaterialAttribute(6421,252, 6)]
        PinkConcretePowder,
        [MaterialAttribute(13031,252, 7)]
        GrayConcretePowder,
        [MaterialAttribute(21589,252, 8)]
        LightGrayConcretePowder,
        [MaterialAttribute(15734,252, 9)]
        CyanConcretePowder,
        [MaterialAttribute(26808,252, 10)]
        PurpleConcretePowder,
        [MaterialAttribute(17773,252, 11)]
        BlueConcretePowder,
        [MaterialAttribute(21485,252, 12)]
        BrownConcretePowder,
        [MaterialAttribute(6904,252, 13)]
        GreenConcretePowder,
        [MaterialAttribute(13286,252, 14)]
        RedConcretePowder,
        [MaterialAttribute(16150,252, 15)]
        BlackConcretePowder,
        [MaterialAttribute(32101)]
        TurtleEgg,
        [MaterialAttribute(28350)]
        DeadTubeCoralBlock,
        [MaterialAttribute(12979)]
        DeadBrainCoralBlock,
        [MaterialAttribute(28220)]
        DeadBubbleCoralBlock,
        [MaterialAttribute(5307)]
        DeadFireCoralBlock,
        [MaterialAttribute(15103)]
        DeadHornCoralBlock,
        [MaterialAttribute(23723)]
        TubeCoralBlock,
        [MaterialAttribute(30618)]
        BrainCoralBlock,
        [MaterialAttribute(15437)]
        BubbleCoralBlock,
        [MaterialAttribute(12119)]
        FireCoralBlock,
        [MaterialAttribute(19958)]
        HornCoralBlock,
        [MaterialAttribute(23048)]
        TubeCoral,
        [MaterialAttribute(31316)]
        BrainCoral,
        [MaterialAttribute(12464)]
        BubbleCoral,
        [MaterialAttribute(29151)]
        FireCoral,
        [MaterialAttribute(19511)]
        HornCoral,
        [MaterialAttribute(9116)]
        DeadBrainCoral,
        [MaterialAttribute(30583)]
        DeadBubbleCoral,
        [MaterialAttribute(8365)]
        DeadFireCoral,
        [MaterialAttribute(5755)]
        DeadHornCoral,
        [MaterialAttribute(18028)]
        DeadTubeCoral,
        [MaterialAttribute(19929)]
        TubeCoralFan,
        [MaterialAttribute(13849)]
        BrainCoralFan,
        [MaterialAttribute(10795)]
        BubbleCoralFan,
        [MaterialAttribute(11112)]
        FireCoralFan,
        [MaterialAttribute(13610)]
        HornCoralFan,
        [MaterialAttribute(17628)]
        DeadTubeCoralFan,
        [MaterialAttribute(26150)]
        DeadBrainCoralFan,
        [MaterialAttribute(17322)]
        DeadBubbleCoralFan,
        [MaterialAttribute(27073)]
        DeadFireCoralFan,
        [MaterialAttribute(11387)]
        DeadHornCoralFan,
        [MaterialAttribute(22449,174)]
        BlueIce,
        [MaterialAttribute(5148)]
        Conduit,
        [MaterialAttribute(29588,67)]
        PolishedGraniteStairs,
        [MaterialAttribute(17561,180)]
        SmoothRedSandstoneStairs,
        [MaterialAttribute(27578,109)]
        MossyStoneBrickStairs,
        [MaterialAttribute(4625,67)]
        PolishedDioriteStairs,
        [MaterialAttribute(29210,67)]
        MossyCobblestoneStairs,
        [MaterialAttribute(28831,67)]
        EndStoneBrickStairs,
        [MaterialAttribute(23784,67)]
        StoneStairs,
        [MaterialAttribute(21183, 128)]
        SmoothSandstoneStairs,
        [MaterialAttribute(19560,156)]
        SmoothQuartzStairs,
        [MaterialAttribute(21840,67)]
        GraniteStairs,
        [MaterialAttribute(17747,67)]
        AndesiteStairs,
        [MaterialAttribute(26374,114)]
        RedNetherBrickStairs,
        [MaterialAttribute(7573,67)]
        PolishedAndesiteStairs,
        [MaterialAttribute(13134,67)]
        DioriteStairs,
        [MaterialAttribute(4521, 44, 3)]
        PolishedGraniteSlab,
        [MaterialAttribute(16304,182)]
        SmoothRedSandstoneSlab,
        [MaterialAttribute(14002, 44, 5)]
        MossyStoneBrickSlab,
        [MaterialAttribute(18303, 44, 3)]
        PolishedDioriteSlab,
        [MaterialAttribute(12139,44, 3)]
        MossyCobblestoneSlab,
        [MaterialAttribute(23239,44, 3)]
        EndStoneBrickSlab,
        [MaterialAttribute(9030,44, 1)]
        SmoothSandstoneSlab,
        [MaterialAttribute(26543,44, 7)]
        SmoothQuartzSlab,
        [MaterialAttribute(10901,44, 3)]
        GraniteSlab,
        [MaterialAttribute(32124,44, 3)]
        AndesiteSlab,
        [MaterialAttribute(12462,44, 6)]
        RedNetherBrickSlab,
        [MaterialAttribute(24573,44, 3)]
        PolishedAndesiteSlab,
        [MaterialAttribute(10715,44, 3)]
        DioriteSlab,
        [MaterialAttribute(15757)]
        Scaffolding,
        [MaterialAttribute(4788,330)]
        IronDoor,
        [MaterialAttribute(20341, 324)]
        OakDoor,
        [MaterialAttribute(10642,427)]
        SpruceDoor,
        [MaterialAttribute(14759,428)]
        BirchDoor,
        [MaterialAttribute(28163,429)]
        JungleDoor,
        [MaterialAttribute(23797,430)]
        AcaciaDoor,
        [MaterialAttribute(10669,431)]
        DarkOakDoor,
        [MaterialAttribute(19544,324)]
        CrimsonDoor,
        [MaterialAttribute(15062,324)]
        WarpedDoor,
        [MaterialAttribute(28823,356)]
        Repeater,
        [MaterialAttribute(18911,404)]
        Comparator,
        [MaterialAttribute(26831,255)]
        StructureBlock,
        [MaterialAttribute(17398)]
        Jigsaw,
        [MaterialAttribute(30120)]
        TurtleHelmet,
        [MaterialAttribute(11914)]
        Scute,
        [MaterialAttribute(28620,259)]
        FlintAndSteel,
        [MaterialAttribute(7720,260)]
        Apple,
        [MaterialAttribute(8745,261)]
        Bow,
        [MaterialAttribute(31091,262)]
        Arrow,
        [MaterialAttribute(29067,263)]
        Coal,
        [MaterialAttribute(5390,263, 1)]
        Charcoal,
        [MaterialAttribute(20865,264)]
        Diamond,
        [MaterialAttribute(24895,265)]
        IronIngot,
        [MaterialAttribute(28927,266)]
        GoldIngot,
        [MaterialAttribute(32457)]
        NetheriteIngot,
        [MaterialAttribute(29331)]
        NetheriteScrap,
        [MaterialAttribute(7175,268)]
        WoodenSword,
        [MaterialAttribute(28432,269)]
        WoodenShovel,
        [MaterialAttribute(12792,270)]
        WoodenPickaxe,
        [MaterialAttribute(6292,271)]
        WoodenAxe,
        [MaterialAttribute(16043,290)]
        WoodenHoe,
        [MaterialAttribute(25084,272)]
        StoneSword,
        [MaterialAttribute(9520,273)]
        StoneShovel,
        [MaterialAttribute(14611,274)]
        StonePickaxe,
        [MaterialAttribute(6338,275)]
        StoneAxe,
        [MaterialAttribute(22855,291)]
        StoneHoe,
        [MaterialAttribute(10505,283)]
        GoldenSword,
        [MaterialAttribute(15597,284)]
        GoldenShovel,
        [MaterialAttribute(25898,285)]
        GoldenPickaxe,
        [MaterialAttribute(4878,286)]
        GoldenAxe,
        [MaterialAttribute(19337,294)]
        GoldenHoe,
        [MaterialAttribute(10904,267)]
        IronSword,
        [MaterialAttribute(30045,256)]
        IronShovel,
        [MaterialAttribute(8842,257)]
        IronPickaxe,
        [MaterialAttribute(15894,258)]
        IronAxe,
        [MaterialAttribute(11339,292)]
        IronHoe,
        [MaterialAttribute(27707,276)]
        DiamondSword,
        [MaterialAttribute(25415,277)]
        DiamondShovel,
        [MaterialAttribute(24291,278)]
        DiamondPickaxe,
        [MaterialAttribute(27277,279)]
        DiamondAxe,
        [MaterialAttribute(24050,293)]
        DiamondHoe,
        [MaterialAttribute(23871,276)]
        NetheriteSword,
        [MaterialAttribute(29728,277)]
        NetheriteShovel,
        [MaterialAttribute(9930,278)]
        NetheritePickaxe,
        [MaterialAttribute(29533,279)]
        NetheriteAxe,
        [MaterialAttribute(27385,293)]
        NetheriteHoe,
        [MaterialAttribute(9773,280)]
        Stick,
        [MaterialAttribute(32661,281)]
        Bowl,
        [MaterialAttribute(16336,282)]
        MushroomStew,
        [MaterialAttribute(12806,287)]
        String,
        [MaterialAttribute(30548,288)]
        Feather,
        [MaterialAttribute(29974,289)]
        Gunpowder,
        [MaterialAttribute(28742,295)]
        WheatSeeds,
        [MaterialAttribute(27709,296)]
        Wheat,
        [MaterialAttribute(32049,297)]
        Bread,
        [MaterialAttribute(11624,298)]
        LeatherHelmet,
        [MaterialAttribute(29275,299)]
        LeatherChestplate,
        [MaterialAttribute(28210, 300)]
        LeatherLeggings,
        [MaterialAttribute(15282,301)]
        LeatherBoots,
        [MaterialAttribute(26114,302)]
        ChainmailHelmet,
        [MaterialAttribute(23602,303)]
        ChainmailChestplate,
        [MaterialAttribute(19087,304)]
        ChainmailLeggings,
        [MaterialAttribute(17953,305)]
        ChainmailBoots,
        [MaterialAttribute(12025,306)]
        IronHelmet,
        [MaterialAttribute(28112,307)]
        IronChestplate,
        [MaterialAttribute(18951,308)]
        IronLeggings,
        [MaterialAttribute(8531,309)]
        IronBoots,
        [MaterialAttribute(10755,310)]
        DiamondHelmet,
        [MaterialAttribute(32099,311)]
        DiamondChestplate,
        [MaterialAttribute(11202,312)]
        DiamondLeggings,
        [MaterialAttribute(16522,313)]
        DiamondBoots,
        [MaterialAttribute(7945,314)]
        GoldenHelmet,
        [MaterialAttribute(4507,315)]
        GoldenChestplate,
        [MaterialAttribute(21002,316)]
        GoldenLeggings,
        [MaterialAttribute(7859,317)]
        GoldenBoots,
        [MaterialAttribute(15907,310)]
        NetheriteHelmet,
        [MaterialAttribute(6106,311)]
        NetheriteChestplate,
        [MaterialAttribute(25605,312)]
        NetheriteLeggings,
        [MaterialAttribute(8923,313)]
        NetheriteBoots,
        [MaterialAttribute(23596,318)]
        Flint,
        [MaterialAttribute(30896,319)]
        Porkchop,
        [MaterialAttribute(27231,320)]
        CookedPorkchop,
        [MaterialAttribute(23945,321)]
        Painting,
        [MaterialAttribute(27732,322)]
        GoldenApple,
        [MaterialAttribute(8280,322, 1)]
        EnchantedGoldenApple,
        [MaterialAttribute(8192,323)]
        OakSign,
        [MaterialAttribute(21502,323)]
        SpruceSign,
        [MaterialAttribute(11351,323)]
        BirchSign,
        [MaterialAttribute(24717,323)]
        JungleSign,
        [MaterialAttribute(29808,323)]
        AcaciaSign,
        [MaterialAttribute(15127,323)]
        DarkOakSign,
        [MaterialAttribute(12162,323)]
        CrimsonSign,
        [MaterialAttribute(10407,323)]
        WarpedSign,
        [MaterialAttribute(15215,325)]
        Bucket,
        [MaterialAttribute(8802,326)]
        WaterBucket,
        [MaterialAttribute(9228,327)]
        LavaBucket,
        [MaterialAttribute(14352,328)]
        Minecart,
        [MaterialAttribute(30206,329)]
        Saddle,
        [MaterialAttribute(11233,331)]
        Redstone,
        [MaterialAttribute(19487,332)]
        Snowball,
        [MaterialAttribute(17570,333)]
        OakBoat,
        [MaterialAttribute(16414,334)]
        Leather,
        [MaterialAttribute(9680,335)]
        MilkBucket,
        [MaterialAttribute(8861,326)]
        PufferfishBucket,
        [MaterialAttribute(31427,326)]
        SalmonBucket,
        [MaterialAttribute(28601,326)]
        CodBucket,
        [MaterialAttribute(29995,326)]
        TropicalFishBucket,
        [MaterialAttribute(6820,336)]
        Brick,
        [MaterialAttribute(24603,337)]
        ClayBall,
        [MaterialAttribute(12966)]
        DriedKelpBlock,
        [MaterialAttribute(9923,339)]
        Paper,
        [MaterialAttribute(23097,340)]
        Book,
        [MaterialAttribute(5242,341)]
        SlimeBall,
        [MaterialAttribute(4497,342)]
        ChestMinecart,
        [MaterialAttribute(14196,343)]
        FurnaceMinecart,
        [MaterialAttribute(21603,344)]
        Egg,
        [MaterialAttribute(24139,345)]
        Compass,
        [MaterialAttribute(4167,346)]
        FishingRod,
        [MaterialAttribute(14980,347)]
        Clock,
        [MaterialAttribute(6665,348)]
        GlowstoneDust,
        [MaterialAttribute(24691,349)]
        Cod,
        [MaterialAttribute(18516,349, 1)]
        Salmon,
        [MaterialAttribute(24879,349, 2)]
        TropicalFish,
        [MaterialAttribute(8115,349, 3)]
        Pufferfish,
        [MaterialAttribute(9681,350)]
        CookedCod,
        [MaterialAttribute(5615,350, 1)]
        CookedSalmon,
        [MaterialAttribute(7184,351)]
        InkSac,
        [MaterialAttribute(30186, 351, 3)]
        CocoaBeans,
        [MaterialAttribute(11075,351, 4)]
        LapisLazuli,
        [MaterialAttribute(10758, 351, 15)]
        WhiteDye,
        [MaterialAttribute(13866, 351, 14)]
        OrangeDye,
        [MaterialAttribute(11788,351, 13)]
        MagentaDye,
        [MaterialAttribute(28738,351, 12)]
        LightBlueDye,
        [MaterialAttribute(5952,351, 11)]
        YellowDye,
        [MaterialAttribute(6147,351, 10)]
        LimeDye,
        [MaterialAttribute(31151,351, 9)]
        PinkDye,
        [MaterialAttribute(9184,351, 8)]
        GrayDye,
        [MaterialAttribute(27643,351, 7)]
        LightGrayDye,
        [MaterialAttribute(8043,351, 6)]
        CyanDye,
        [MaterialAttribute(6347,351, 5)]
        PurpleDye,
        [MaterialAttribute(11588,351, 4)]
        BlueDye,
        [MaterialAttribute(7648,351, 3)]
        BrownDye,
        [MaterialAttribute(23215,351, 2)]
        GreenDye,
        [MaterialAttribute(5728,351, 1)]
        RedDye,
        [MaterialAttribute(6202,351)]
        BlackDye,
        [MaterialAttribute(32458,351, 15)]
        BoneMeal,
        [MaterialAttribute(5686,352)]
        Bone,
        [MaterialAttribute(30638,353)]
        Sugar,
        [MaterialAttribute(27048,354)]
        Cake,
        [MaterialAttribute(8185,355)]
        WhiteBed,
        [MaterialAttribute(11194,355, 1)]
        OrangeBed,
        [MaterialAttribute(20061,355, 2)]
        MagentaBed,
        [MaterialAttribute(20957,355, 3)]
        LightBlueBed,
        [MaterialAttribute(30410,355, 4)]
        YellowBed,
        [MaterialAttribute(27860,355, 5)]
        LimeBed,
        [MaterialAttribute(13795,355, 6)]
        PinkBed,
        [MaterialAttribute(15745,355, 7)]
        GrayBed,
        [MaterialAttribute(5090,355, 8)]
        LightGrayBed,
        [MaterialAttribute(16746,355, 9)]
        CyanBed,
        [MaterialAttribute(29755,355, 10)]
        PurpleBed,
        [MaterialAttribute(12714,355, 11)]
        BlueBed,
        [MaterialAttribute(26672,355, 12)]
        BrownBed,
        [MaterialAttribute(13797,355, 13)]
        GreenBed,
        [MaterialAttribute(30910,355, 14)]
        RedBed,
        [MaterialAttribute(20490,355, 15)]
        BlackBed,
        [MaterialAttribute(27431,357)]
        Cookie,
        [MaterialAttribute(23504,358)]
        FilledMap,
        [MaterialAttribute(27971,359)]
        Shears,
        [MaterialAttribute(5347,360)]
        MelonSlice,
        [MaterialAttribute(21042)]
        DriedKelp,
        [MaterialAttribute(28985,361)]
        PumpkinSeeds,
        [MaterialAttribute(18340,362)]
        MelonSeeds,
        [MaterialAttribute(4803,363)]
        Beef,
        [MaterialAttribute(21595,364)]
        CookedBeef,
        [MaterialAttribute(17281,365)]
        Chicken,
        [MaterialAttribute(16984,366)]
        CookedChicken,
        [MaterialAttribute(21591,367)]
        RottenFlesh,
        [MaterialAttribute(5259,368)]
        EnderPearl,
        [MaterialAttribute(8289,369)]
        BlazeRod,
        [MaterialAttribute(18222,370)]
        GhastTear,
        [MaterialAttribute(28814,371)]
        GoldNugget,
        [MaterialAttribute(29227,372)]
        NetherWart,
        [MaterialAttribute(24020,373)]
        Potion,
        [MaterialAttribute(6116,374)]
        GlassBottle,
        [MaterialAttribute(9318,375)]
        SpiderEye,
        [MaterialAttribute(19386,376)]
        FermentedSpiderEye,
        [MaterialAttribute(18941,377)]
        BlazePowder,
        [MaterialAttribute(25097,378)]
        MagmaCream,
        [MaterialAttribute(14539,379)]
        BrewingStand,
        [MaterialAttribute(26531,380)]
        Cauldron,
        [MaterialAttribute(24860,381)]
        EnderEye,
        [MaterialAttribute(20158,382)]
        GlisteringMelonSlice,
        [MaterialAttribute(14607,383)]
        BatSpawnEgg,
        [MaterialAttribute(22924,383)]
        BeeSpawnEgg,
        [MaterialAttribute(4759,383)]
        BlazeSpawnEgg,
        [MaterialAttribute(29583,383)]
        CatSpawnEgg,
        [MaterialAttribute(23341,383)]
        CaveSpiderSpawnEgg,
        [MaterialAttribute(5462,383)]
        ChickenSpawnEgg,
        [MaterialAttribute(27248,383)]
        CodSpawnEgg,
        [MaterialAttribute(14761,383)]
        CowSpawnEgg,
        [MaterialAttribute(9653,383)]
        CreeperSpawnEgg,
        [MaterialAttribute(20787,383)]
        DolphinSpawnEgg,
        [MaterialAttribute(14513,383)]
        DonkeySpawnEgg,
        [MaterialAttribute(19368,383)]
        DrownedSpawnEgg,
        [MaterialAttribute(11418,383)]
        ElderGuardianSpawnEgg,
        [MaterialAttribute(29488,383)]
        EndermanSpawnEgg,
        [MaterialAttribute(16617,383)]
        EndermiteSpawnEgg,
        [MaterialAttribute(21271,383)]
        EvokerSpawnEgg,
        [MaterialAttribute(22376,383)]
        FoxSpawnEgg,
        [MaterialAttribute(9970,383)]
        GhastSpawnEgg,
        [MaterialAttribute(20113,383)]
        GuardianSpawnEgg,
        [MaterialAttribute(14088,383)]
        HoglinSpawnEgg,
        [MaterialAttribute(25981,383)]
        HorseSpawnEgg,
        [MaterialAttribute(20178,383)]
        HuskSpawnEgg,
        [MaterialAttribute(23640,383)]
        LlamaSpawnEgg,
        [MaterialAttribute(26638,383)]
        MagmaCubeSpawnEgg,
        [MaterialAttribute(22125,383)]
        MooshroomSpawnEgg,
        [MaterialAttribute(11229,383)]
        MuleSpawnEgg,
        [MaterialAttribute(30080,383)]
        OcelotSpawnEgg,
        [MaterialAttribute(23759,383)]
        PandaSpawnEgg,
        [MaterialAttribute(23614,383)]
        ParrotSpawnEgg,
        [MaterialAttribute(24648, 383)]
        PhantomSpawnEgg,
        [MaterialAttribute(22584,383)]
        PigSpawnEgg,
        [MaterialAttribute(16193,383)]
        PiglinSpawnEgg,
        [MaterialAttribute(30230,383)]
        PiglinBruteSpawnEgg,
        [MaterialAttribute(28659,383)]
        PillagerSpawnEgg,
        [MaterialAttribute(17015,383)]
        PolarBearSpawnEgg,
        [MaterialAttribute(24570,383)]
        PufferfishSpawnEgg,
        [MaterialAttribute(26496,383)]
        RabbitSpawnEgg,
        [MaterialAttribute(8726,383)]
        RavagerSpawnEgg,
        [MaterialAttribute(18739,383)]
        SalmonSpawnEgg,
        [MaterialAttribute(24488,383)]
        SheepSpawnEgg,
        [MaterialAttribute(31848,383)]
        ShulkerSpawnEgg,
        [MaterialAttribute(14537,383)]
        SilverfishSpawnEgg,
        [MaterialAttribute(15261,383)]
        SkeletonSpawnEgg,
        [MaterialAttribute(21356,383)]
        SkeletonHorseSpawnEgg,
        [MaterialAttribute(17196,383)]
        SlimeSpawnEgg,
        [MaterialAttribute(14984,383)]
        SpiderSpawnEgg,
        [MaterialAttribute(10682,383)]
        SquidSpawnEgg,
        [MaterialAttribute(30153,383)]
        StraySpawnEgg,
        [MaterialAttribute(6203,383)]
        StriderSpawnEgg,
        [MaterialAttribute(8439,383)]
        TraderLlamaSpawnEgg,
        [MaterialAttribute(19713, 383)]
        TropicalFishSpawnEgg,
        [MaterialAttribute(17324,383)]
        TurtleSpawnEgg,
        [MaterialAttribute(27751,383)]
        VexSpawnEgg,
        [MaterialAttribute(30348,383)]
        VillagerSpawnEgg,
        [MaterialAttribute(25324,383)]
        VindicatorSpawnEgg,
        [MaterialAttribute(17904,383)]
        WanderingTraderSpawnEgg,
        [MaterialAttribute(11837,383)]
        WitchSpawnEgg,
        [MaterialAttribute(10073,383)]
        WitherSkeletonSpawnEgg,
        [MaterialAttribute(21692,383)]
        WolfSpawnEgg,
        [MaterialAttribute(7442,383)]
        ZoglinSpawnEgg,
        [MaterialAttribute(5814,383)]
        ZombieSpawnEgg,
        [MaterialAttribute(4275,383)]
        ZombieHorseSpawnEgg,
        [MaterialAttribute(10311, 383)]
        ZombieVillagerSpawnEgg,
        [MaterialAttribute(6626,383)]
        ZombifiedPiglinSpawnEgg,
        [MaterialAttribute(12858, 384)]
        ExperienceBottle,
        [MaterialAttribute(4842,385)]
        FireCharge,
        [MaterialAttribute(13393,386)]
        WritableBook,
        [MaterialAttribute(24164,387)]
        WrittenBook,
        [MaterialAttribute(5654,388)]
        Emerald,
        [MaterialAttribute(27318,389)]
        ItemFrame,
        [MaterialAttribute(30567,390)]
        FlowerPot,
        [MaterialAttribute(22824,391)]
        Carrot,
        [MaterialAttribute(21088,392)]
        Potato,
        [MaterialAttribute(14624,393)]
        BakedPotato,
        [MaterialAttribute(32640,394)]
        PoisonousPotato,
        [MaterialAttribute(21655,395)]
        Map,
        [MaterialAttribute(5300,396)]
        GoldenCarrot,
        [MaterialAttribute(13270,397)]
        SkeletonSkull,
        [MaterialAttribute(31487,397, 1)]
        WitherSkeletonSkull,
        [MaterialAttribute(21174,397, 2)]
        PlayerHead,
        [MaterialAttribute(9304,397, 3)]
        ZombieHead,
        [MaterialAttribute(29146,397, 4)]
        CreeperHead,
        [MaterialAttribute(20084,397, 5)]
        DragonHead,
        [MaterialAttribute(27809,398)]
        CarrotOnAStick,
        [MaterialAttribute(11706, 398)]
        WarpedFungusOnAStick,
        [MaterialAttribute(12469,399)]
        NetherStar,
        [MaterialAttribute(28725,400)]
        PumpkinPie,
        [MaterialAttribute(23841,401)]
        FireworkRocket,
        [MaterialAttribute(12190,402)]
        FireworkStar,
        [MaterialAttribute(11741,403)]
        EnchantedBook,
        [MaterialAttribute(19996,405)]
        NetherBrick,
        [MaterialAttribute(23608,406)]
        Quartz,
        [MaterialAttribute(4277,407)]
        TntMinecart,
        [MaterialAttribute(19024,408)]
        HopperMinecart,
        [MaterialAttribute(10993,409)]
        PrismarineShard,
        [MaterialAttribute(31546,410)]
        PrismarineCrystals,
        [MaterialAttribute(23068,411)]
        Rabbit,
        [MaterialAttribute(4454,412)]
        CookedRabbit,
        [MaterialAttribute(10611,413)]
        RabbitStew,
        [MaterialAttribute(13864,414)]
        RabbitFoot,
        [MaterialAttribute(12467,415)]
        RabbitHide,
        [MaterialAttribute(12852,416)]
        ArmorStand,
        [MaterialAttribute(30108,417)]
        IronHorseArmor,
        [MaterialAttribute(7996,418)]
        GoldenHorseArmor,
        [MaterialAttribute(10321,419)]
        DiamondHorseArmor,
        [MaterialAttribute(30667,418)]
        LeatherHorseArmor,
        [MaterialAttribute(29539,420)]
        Lead,
        [MaterialAttribute(30731,421)]
        NameTag,
        [MaterialAttribute(7992,422)]
        CommandBlockMinecart,
        [MaterialAttribute(4792,423)]
        Mutton,
        [MaterialAttribute(31447,424)]
        CookedMutton,
        [MaterialAttribute(17562,425, 15)]
        WhiteBanner,
        [MaterialAttribute(4839,425, 14)]
        OrangeBanner,
        [MaterialAttribute(15591,425, 13)]
        MagentaBanner,
        [MaterialAttribute(18060,425, 12)]
        LightBlueBanner,
        [MaterialAttribute(30382,425, 11)]
        YellowBanner,
        [MaterialAttribute(18887,425, 10)]
        LimeBanner,
        [MaterialAttribute(19439,425, 9)]
        PinkBanner,
        [MaterialAttribute(12053,425, 8)]
        GrayBanner,
        [MaterialAttribute(11417,425, 7)]
        LightGrayBanner,
        [MaterialAttribute(9839,425, 6)]
        CyanBanner,
        [MaterialAttribute(29027,425, 5)]
        PurpleBanner,
        [MaterialAttribute(18481,425, 4)]
        BlueBanner,
        [MaterialAttribute(11481,425, 3)]
        BrownBanner,
        [MaterialAttribute(10698,425, 2)]
        GreenBanner,
        [MaterialAttribute(26961,425, 1)]
        RedBanner,
        [MaterialAttribute(9365,425)]
        BlackBanner,
        [MaterialAttribute(19090,426)]
        EndCrystal,
        [MaterialAttribute(7652,432)]
        ChorusFruit,
        [MaterialAttribute(27844,433)]
        PoppedChorusFruit,
        [MaterialAttribute(23305,434)]
        Beetroot,
        [MaterialAttribute(21282,435)]
        BeetrootSeeds,
        [MaterialAttribute(16036,436)]
        BeetrootSoup,
        [MaterialAttribute(20154,437)]
        DragonBreath,
        [MaterialAttribute(30248,438)]
        SplashPotion,
        [MaterialAttribute(4568, 439)]
        SpectralArrow,
        [MaterialAttribute(25164,440)]
        TippedArrow,
        [MaterialAttribute(25857,441)]
        LingeringPotion,
        [MaterialAttribute(29943,442)]
        Shield,
        [MaterialAttribute(23829,443)]
        Elytra,
        [MaterialAttribute(9606,444)]
        SpruceBoat,
        [MaterialAttribute(28104,445)]
        BirchBoat,
        [MaterialAttribute(4495,446)]
        JungleBoat,
        [MaterialAttribute(27326,447)]
        AcaciaBoat,
        [MaterialAttribute(28618,448)]
        DarkOakBoat,
        [MaterialAttribute(10139,449)]
        TotemOfUndying,
        [MaterialAttribute(27848,450)]
        ShulkerShell,
        [MaterialAttribute(13715,452)]
        IronNugget,
        [MaterialAttribute(12646, 453)]
        KnowledgeBook,
        [MaterialAttribute(24562, 280)]
        DebugStick,
        [MaterialAttribute(16359,2256)]
        MusicDisc13,
        [MaterialAttribute(16246,2257)]
        MusicDiscCat,
        [MaterialAttribute(26667,2258)]
        MusicDiscBlocks,
        [MaterialAttribute(19436,2259)]
        MusicDiscChirp,
        [MaterialAttribute(13823,2260)]
        MusicDiscFar,
        [MaterialAttribute(11517,2261)]
        MusicDiscMall,
        [MaterialAttribute(26117,2262)]
        MusicDiscMellohi,
        [MaterialAttribute(14989,2263)]
        MusicDiscStal,
        [MaterialAttribute(16785,2264)]
        MusicDiscStrad,
        [MaterialAttribute(24026, 2265)]
        MusicDiscWard,
        [MaterialAttribute(27426,2266)]
        MusicDisc11,
        [MaterialAttribute(26499,2267)]
        MusicDiscWait,
        [MaterialAttribute(21323)]
        MusicDiscPigstep,
        [MaterialAttribute(7534)]
        Trident,
        [MaterialAttribute(18398)]
        PhantomMembrane,
        [MaterialAttribute(19989)]
        NautilusShell,
        [MaterialAttribute(11807)]
        HeartOfTheSea,
        [MaterialAttribute(4340, 261)]
        Crossbow,
        [MaterialAttribute(8173,282)]
        SuspiciousStew,
        [MaterialAttribute(14276)]
        Loom,
        [MaterialAttribute(5762)]
        FlowerBannerPattern,
        [MaterialAttribute(15774)]
        CreeperBannerPattern,
        [MaterialAttribute(7680)]
        SkullBannerPattern,
        [MaterialAttribute(11903)]
        MojangBannerPattern,
        [MaterialAttribute(27753)]
        GlobeBannerPattern,
        [MaterialAttribute(22028)]
        PiglinBannerPattern,
        [MaterialAttribute(31247)]
        Composter,
        [MaterialAttribute(22396)]
        Barrel,
        [MaterialAttribute(24781)]
        Smoker,
        [MaterialAttribute(31157)]
        BlastFurnace,
        [MaterialAttribute(28529)]
        CartographyTable,
        [MaterialAttribute(30838)]
        FletchingTable,
        [MaterialAttribute(26260)]
        Grindstone,
        [MaterialAttribute(23490)]
        Lectern,
        [MaterialAttribute(9082)]
        SmithingTable,
        [MaterialAttribute(25170)]
        Stonecutter,
        [MaterialAttribute(20000)]
        Bell,
        [MaterialAttribute(5992)]
        Lantern,
        [MaterialAttribute(27778)]
        SoulLantern,
        [MaterialAttribute(19747)]
        SweetBerries,
        [MaterialAttribute(8488)]
        Campfire,
        [MaterialAttribute(4238)]
        SoulCampfire,
        [MaterialAttribute(20424)]
        Shroomlight,
        [MaterialAttribute(9482)]
        Honeycomb,
        [MaterialAttribute(8825)]
        BeeNest,
        [MaterialAttribute(11830)]
        Beehive,
        [MaterialAttribute(22927)]
        HoneyBottle,
        [MaterialAttribute(30615)]
        HoneyBlock,
        [MaterialAttribute(28780)]
        HoneycombBlock,
        [MaterialAttribute(23127)]
        Lodestone,
        [MaterialAttribute(6527)]
        NetheriteBlock,
        [MaterialAttribute(18198)]
        AncientDebris,
        [MaterialAttribute(22637)]
        Target,
        [MaterialAttribute(31545,49)]
        CryingObsidian,
        [MaterialAttribute(7354,4)]
        Blackstone,
        [MaterialAttribute(11948,44, 3)]
        BlackstoneSlab,
        [MaterialAttribute(14646,67)]
        BlackstoneStairs,
        [MaterialAttribute(8498, 4)]
        GildedBlackstone,
        [MaterialAttribute(18144,1)]
        PolishedBlackstone,
        [MaterialAttribute(23430, 44)]
        PolishedBlackstoneSlab,
        [MaterialAttribute(8653,109)]
        PolishedBlackstoneStairs,
        [MaterialAttribute(21942, 98, 3)]
        ChiseledPolishedBlackstone,
        [MaterialAttribute(19844,98)]
        PolishedBlackstoneBricks,
        [MaterialAttribute(12219,44, 5)]
        PolishedBlackstoneBrickSlab,
        [MaterialAttribute(17983,109)]
        PolishedBlackstoneBrickStairs,
        [MaterialAttribute(16846,98, 2)]
        CrackedPolishedBlackstoneBricks,
        [MaterialAttribute(4099)]
        RespawnAnchor,
        [MaterialAttribute(24998,8)]
        Water,
        [MaterialAttribute(9)]
        StationaryWater,
        [MaterialAttribute(8415,10)]
        Lava,
        [MaterialAttribute(11)]
        StationaryLava,
        [MaterialAttribute(27189,175, 2)]
        TallSeagrass,
        [MaterialAttribute(30226, 34)]
        PistonHead,
        [MaterialAttribute(13831)]
        MovingPiston,
        [MaterialAttribute(25890, 50)]
        WallTorch,
        [MaterialAttribute(16396,51)]
        Fire,
        [MaterialAttribute(30163,51)]
        SoulFire,
        [MaterialAttribute(25984, 55)]
        RedstoneWire,
        [MaterialAttribute(12984,68)]
        OakWallSign,
        [MaterialAttribute(7352,68)]
        SpruceWallSign,
        [MaterialAttribute(9887,68)]
        BirchWallSign,
        [MaterialAttribute(20316,68)]
        AcaciaWallSign,
        [MaterialAttribute(29629,68)]
        JungleWallSign,
        [MaterialAttribute(9508,68)]
        DarkOakWallSign,
        [MaterialAttribute(7595, 76)]
        RedstoneWallTorch,
        [MaterialAttribute(27500)]
        SoulWallTorch,
        [MaterialAttribute(19469,90)]
        NetherPortal,
        [MaterialAttribute(12724, 104)]
        AttachedPumpkinStem,
        [MaterialAttribute(30882,105)]
        AttachedMelonStem,
        [MaterialAttribute(19021,104)]
        PumpkinStem,
        [MaterialAttribute(8247,105)]
        MelonStem,
        [MaterialAttribute(16782,119)]
        EndPortal,
        [MaterialAttribute(29709,127)]
        Cocoa,
        [MaterialAttribute(8810,132)]
        Tripwire,
        [MaterialAttribute(11905, 390)]
        PottedOakSapling,
        [MaterialAttribute(29498,390)]
        PottedSpruceSapling,
        [MaterialAttribute(32484,390)]
        PottedBirchSapling,
        [MaterialAttribute(7525,390)]
        PottedJungleSapling,
        [MaterialAttribute(14096,390)]
        PottedAcaciaSapling,
        [MaterialAttribute(6486,390)]
        PottedDarkOakSapling,
        [MaterialAttribute(23315,390)]
        PottedFern,
        [MaterialAttribute(9727,390)]
        PottedDandelion,
        [MaterialAttribute(7457,390)]
        PottedPoppy,
        [MaterialAttribute(6599,390)]
        PottedBlueOrchid,
        [MaterialAttribute(13184,390)]
        PottedAllium,
        [MaterialAttribute(8754,390)]
        PottedAzureBluet,
        [MaterialAttribute(28594,390)]
        PottedRedTulip,
        [MaterialAttribute(28807,390)]
        PottedOrangeTulip,
        [MaterialAttribute(24330,390)]
        PottedWhiteTulip,
        [MaterialAttribute(10089,390)]
        PottedPinkTulip,
        [MaterialAttribute(19707,390)]
        PottedOxeyeDaisy,
        [MaterialAttribute(28917,390)]
        PottedCornflower,
        [MaterialAttribute(9364,390)]
        PottedLilyOfTheValley,
        [MaterialAttribute(26876,390)]
        PottedWitherRose,
        [MaterialAttribute(22881,390)]
        PottedRedMushroom,
        [MaterialAttribute(14481,390)]
        PottedBrownMushroom,
        [MaterialAttribute(13020,390)]
        PottedDeadBush,
        [MaterialAttribute(8777,390)]
        PottedCactus,
        [MaterialAttribute(17258, 141)]
        Carrots,
        [MaterialAttribute(10879,142)]
        Potatoes,
        [MaterialAttribute(31650,397)]
        SkeletonWallSkull,
        [MaterialAttribute(9326,397, 1)]
        WitherSkeletonWallSkull,
        [MaterialAttribute(16296,397, 2)]
        ZombieWallHead,
        [MaterialAttribute(13164,397, 3)]
        PlayerWallHead,
        [MaterialAttribute(30123,397, 4)]
        CreeperWallHead,
        [MaterialAttribute(19818,397, 5)]
        DragonWallHead,
        [MaterialAttribute(15967,425, 15)]
        WhiteWallBanner,
        [MaterialAttribute(9936,425, 14)]
        OrangeWallBanner,
        [MaterialAttribute(23291,425, 13)]
        MagentaWallBanner,
        [MaterialAttribute(12011,425, 12)]
        LightBlueWallBanner,
        [MaterialAttribute(32004,425, 11)]
        YellowWallBanner,
        [MaterialAttribute(21422,425, 10)]
        LimeWallBanner,
        [MaterialAttribute(9421,425, 9)]
        PinkWallBanner,
        [MaterialAttribute(24275,425, 8)]
        GrayWallBanner,
        [MaterialAttribute(31088,425, 7)]
        LightGrayWallBanner,
        [MaterialAttribute(10889,425, 6)]
        CyanWallBanner,
        [MaterialAttribute(14298,425, 5)]
        PurpleWallBanner,
        [MaterialAttribute(17757,425, 4)]
        BlueWallBanner,
        [MaterialAttribute(14731,425, 3)]
        BrownWallBanner,
        [MaterialAttribute(15046,425, 2)]
        GreenWallBanner,
        [MaterialAttribute(4378,425, 1)]
        RedWallBanner,
        [MaterialAttribute(4919,425)]
        BlackWallBanner,
        [MaterialAttribute(22075,207)]
        Beetroots,
        [MaterialAttribute(26605,209)]
        EndGateway,
        [MaterialAttribute(21814, 212)]
        FrostedIce,
        [MaterialAttribute(29697)]
        KelpPlant,
        [MaterialAttribute(5128)]
        DeadTubeCoralWallFan,
        [MaterialAttribute(23718)]
        DeadBrainCoralWallFan,
        [MaterialAttribute(18453)]
        DeadBubbleCoralWallFan,
        [MaterialAttribute(23375)]
        DeadFireCoralWallFan,
        [MaterialAttribute(27550)]
        DeadHornCoralWallFan,
        [MaterialAttribute(25282)]
        TubeCoralWallFan,
        [MaterialAttribute(22685)]
        BrainCoralWallFan,
        [MaterialAttribute(20382)]
        BubbleCoralWallFan,
        [MaterialAttribute(20100)]
        FireCoralWallFan,
        [MaterialAttribute(28883)]
        HornCoralWallFan,
        [MaterialAttribute(8478)]
        BambooSapling,
        [MaterialAttribute(22542, 390)]
        PottedBamboo,
        [MaterialAttribute(13668)]
        VoidAir,
        [MaterialAttribute(17422)]
        CaveAir,
        [MaterialAttribute(31612)]
        BubbleColumn,
        [MaterialAttribute(11958)]
        SweetBerryBush,
        [MaterialAttribute(19437)]
        WeepingVinesPlant,
        [MaterialAttribute(25338)]
        TwistingVinesPlant,
        [MaterialAttribute(19242, 68)]
        CrimsonWallSign,
        [MaterialAttribute(13534,68)]
        WarpedWallSign,
        [MaterialAttribute(5548,390)]
        PottedCrimsonFungus,
        [MaterialAttribute(30800,390)]
        PottedWarpedFungus,
        [MaterialAttribute(13852,390)]
        PottedCrimsonRoots,
        [MaterialAttribute(6403,390)]
        PottedWarpedRoots,
    }

    internal class MaterialAttribute : System.Attribute
    {
        public readonly int Id;
        public readonly int LegacyId;
        
        public readonly int MaxStack;
        public readonly short Durability;

        public readonly byte SubId;

        public MaterialAttribute(int id, int legacyId, byte subId = 0, int stack = 64, short durability = 0)
        {
            Id = id;
            LegacyId = legacyId;
            SubId = subId;
            MaxStack = stack;
            Durability = durability;
        }
        public MaterialAttribute(int id) : this(id, id) {}
    }

    public static class MaterialExtensions
    {
        public static int GetId(this Material m)
        {
            var attributes =
                (MaterialAttribute[]) m.GetType().GetField(m.ToString())!.GetCustomAttributes(typeof(MaterialAttribute), false);
            if (attributes.Length > 0)
                return attributes[0].Id;

            return -1;
        }
        
        public static int GetLegacyId(this Material m)
        {
            var attributes =
                (MaterialAttribute[]) m.GetType().GetField(m.ToString())!.GetCustomAttributes(typeof(MaterialAttribute),
                    false);
            if (attributes.Length > 0)
                return attributes[0].LegacyId;

            return -1;
        }
        
        public static int GetLegacySubId(this Material m)
        {
            var attributes =
                (MaterialAttribute[]) m.GetType().GetField(m.ToString())!.GetCustomAttributes(typeof(MaterialAttribute),
                    false);
            if (attributes.Length > 0)
                return attributes[0].SubId;

            return -1;
        }
        
        public static int GetMaxStack(this Material m)
        {
            var attributes =
                (MaterialAttribute[]) m.GetType().GetField(m.ToString())!.GetCustomAttributes(typeof(MaterialAttribute),
                    false);
            if (attributes.Length > 0)
                return attributes[0].MaxStack;

            return -1;
        }
        
        public static int GetDurability(this Material m)
        {
            var attributes =
                (MaterialAttribute[]) m.GetType().GetField(m.ToString())!.GetCustomAttributes(typeof(MaterialAttribute),
                    false);
            if (attributes.Length > 0)
                return attributes[0].Durability;

            return -1;
        }

        public static bool IsBlock(this Material m)
        {
            switch (m)
            {
                case Material.Air: case Material.Stone: case Material.Granite: case Material.PolishedGranite: case Material.Diorite:
                case Material.PolishedDiorite: case Material.Andesite: case Material.PolishedAndesite: case Material.GrassBlock:
                case Material.Dirt: case Material.CoarseDirt: case Material.Podzol: case Material.CrimsonNylium: case Material.WarpedNylium:
                case Material.Cobblestone: case Material.OakPlanks: case Material.SprucePlanks: case Material.BirchPlanks: case Material.JunglePlanks:
                case Material.AcaciaPlanks: case Material.DarkOakPlanks: case Material.CrimsonPlanks: case Material.WarpedPlanks: case Material.OakSapling:
                case Material.SpruceSapling: case Material.BirchSapling: case Material.JungleSapling: case Material.AcaciaSapling: case Material.DarkOakSapling:
                case Material.Bedrock: case Material.Sand: case Material.RedSand: case Material.Gravel: case Material.GoldOre: case Material.IronOre:
                case Material.CoalOre: case Material.NetherGoldOre: case Material.OakLog: case Material.SpruceLog: case Material.BirchLog: case Material.JungleLog:
                case Material.AcaciaLog: case Material.DarkOakLog: case Material.CrimsonStem: case Material.WarpedStem: case Material.StrippedOakLog:
                case Material.StrippedSpruceLog: case Material.StrippedBirchLog: case Material.StrippedJungleLog: case Material.StrippedAcaciaLog:
                case Material.StrippedDarkOakLog: case Material.StrippedCrimsonStem: case Material.StrippedWarpedStem: case Material.StrippedOakWood:
                case Material.StrippedSpruceWood: case Material.StrippedBirchWood: case Material.StrippedJungleWood: case Material.StrippedAcaciaWood:
                case Material.StrippedDarkOakWood: case Material.StrippedCrimsonHyphae: case Material.StrippedWarpedHyphae: case Material.OakWood:
                case Material.SpruceWood: case Material.BirchWood: case Material.JungleWood: case Material.AcaciaWood: case Material.DarkOakWood:
                case Material.CrimsonHyphae: case Material.WarpedHyphae: case Material.OakLeaves: case Material.SpruceLeaves: case Material.BirchLeaves:
                case Material.JungleLeaves: case Material.AcaciaLeaves: case Material.DarkOakLeaves: case Material.Sponge: case Material.WetSponge:
                case Material.Glass: case Material.LapisOre: case Material.LapisBlock: case Material.Dispenser: case Material.Sandstone: case Material.ChiseledSandstone:
                case Material.CutSandStone: case Material.NoteBlock: case Material.PoweredRail: case Material.DetectorRail: case Material.StickyPiston: case Material.Cobweb:
                case Material.Grass: case Material.Fern: case Material.DeadBush: case Material.Seagrass: case Material.SeaPickle: case Material.Piston: case Material.WhiteWool:
                case Material.OrangeWool: case Material.MagentaWool: case Material.LightBlueWool: case Material.YellowWool: case Material.LimeWool: case Material.PinkWool:
                case Material.GrayWool: case Material.LightGrayWool: case Material.CyanWool: case Material.PurpleWool: case Material.BlueWool: case Material.BrownWool:
                case Material.GreenWool: case Material.RedWool: case Material.BlackWool: case Material.Dandelion: case Material.Poppy: case Material.BlueOrchid: case Material.Allium:
                case Material.AzureBluet: case Material.RedTulip: case Material.OrangeTulip: case Material.WhiteTulip: case Material.PinkTulip: case Material.OxeyeDaisy: case Material.Cornflower:
                case Material.LilyOfTheValley: case Material.WitherRose: case Material.BrownMushroom: case Material.RedMushRoom: case Material.CrimsonFungus: case Material.WarpedFungus:
                case Material.CrimsonRoots: case Material.WarpedRoots: case Material.NetherSprouts: case Material.WeepingVines: case Material.TwistingVines: case Material.SugarCane:
                case Material.Kelp: case Material.Bamboo: case Material.GoldBlock: case Material.IronBlock: case Material.OakSlab: case Material.SpruceSlab: case Material.BirchSlab:
                case Material.JungleSlab: case Material.AcaciaSlab: case Material.DarkOakSlab: case Material.CrimsonSlab: case Material.WarpedSlab: case Material.StoneSlab: case Material.SmoothStoneSlab:
                case Material.SandstoneSlab: case Material.CutSandstoneSlab: case Material.PetrifiedOakSlab: case Material.CobblestoneSlab: case Material.BrickSlab: case Material.StoneBrickSlab:
                case Material.NetherBrickSlab: case Material.QuartzSlab: case Material.RedSandstoneSlab: case Material.CutRedSandstoneSlab: case Material.PurpurSlab: case Material.PrismarineSlab:
                case Material.PrismarineBrickSlab: case Material.DarkPrismarineSlab: case Material.SmoothQuartz: case Material.SmoothRedSandstone: case Material.SmoothSandstone:
                case Material.SmoothStone: case Material.Bricks: case Material.Tnt: case Material.Bookshelf: case Material.MossyCobblestone: case Material.Obsidian: case Material.Torch:
                case Material.EndRod: case Material.ChorusPlant: case Material.ChorusFlower: case Material.PurpurBlock: case Material.PurpurPillar: case Material.PurpurStairs: case Material.Spawner:
                case Material.OakStairs: case Material.Chest: case Material.DiamondOre: case Material.DiamondBlock: case Material.CraftingTable: case Material.Farmland: case Material.Furnace:
                case Material.Ladder: case Material.Rail: case Material.CobblestoneStairs: case Material.Lever: case Material.StonePressurePlate: case Material.OakPressurePlate:
                case Material.SprucePressurePlate: case Material.BirchPressurePlate: case Material.JunglePressurePlate: case Material.AcaciaPressurePlate: case Material.DarkOakPressurePlate:
                case Material.CrimsonPressurePlate: case Material.WarpedPressurePlate: case Material.PolishedBlackstonePressurePlate: case Material.RedstoneOre: case Material.RedstoneTorch:
                case Material.Snow: case Material.Ice: case Material.SnowBlock: case Material.Cactus: case Material.Clay: case Material.Jukebox: case Material.OakFence: case Material.SpruceFence:
                case Material.BirchFence: case Material.JungleFence: case Material.AcaciaFence: case Material.DarkOakFence: case Material.CrimsonFence: case Material.WarpedFence: case Material.Pumpkin:
                case Material.CarvedPumpkin: case Material.NetherRack: case Material.SoulSand: case Material.SoulSoil: case Material.Basalt: case Material.PolishedBasalt: case Material.SoulTorch:
                case Material.Glowstone: case Material.JackOLantern: case Material.OakTrapdoor: case Material.SpruceTrapdoor: case Material.BirchTrapdoor: case Material.JungleTrapdoor: case Material.AcaciaTrapdoor:
                case Material.DarkOakTrapdoor: case Material.CrimsonTrapdoor: case Material.WarpedTrapdoor: case Material.InfestedStone: case Material.InfestedCobblestone: case Material.InfestedStoneBricks:
                case Material.InfestedMossyStoneBricks: case Material.InfestedCrackedStoneBricks: case Material.InfestedChiseledStoneBricks: case Material.StoneBricks: case Material.MossyStoneBricks:
                case Material.CrackedStoneBricks: case Material.ChiseledStoneBricks: case Material.BrownMushroomBlock: case Material.RedMushroomBlock: case Material.MushroomStem: case Material.IronBars:
                case Material.Chain: case Material.GlassPane: case Material.Melon: case Material.Vine: case Material.OakFenceGate: case Material.SpruceFenceGate: case Material.BirchFenceGate:
                case Material.JungleFenceGate: case Material.AcaciaFenceGate: case Material.DarkOakFenceGate: case Material.CrimsonFenceGate: case Material.WarpedFenceGate: case Material.BrickStairs:
                case Material.StoneBrickStairs: case Material.Mycelium: case Material.LilyPad: case Material.NetherBricks: case Material.CrackedNetherBricks: case Material.ChiseledNetherBricks:
                case Material.NetherBrickFence: case Material.NetherBrickStairs: case Material.EnchantingTable: case Material.EndPortalFrame: case Material.EndStone: case Material.EndStoneBricks:
                case Material.DragonEgg: case Material.RedstoneLamp: case Material.SandstoneStairs: case Material.EmeraldOre: case Material.EnderChest: case Material.TripwireHook: case Material.EmeraldBlock:
                case Material.SpruceStairs: case Material.BirchStairs: case Material.JungleStairs: case Material.CrimsonStairs: case Material.WarpedStairs: case Material.CommandBlock: case Material.Beacon:
                case Material.CobblestoneWall: case Material.MossyCobblestoneWall: case Material.BrickWall: case Material.PrismarineWall: case Material.RedSandstoneWall: case Material.MossyStoneBrickWall:
                case Material.GraniteWall: case Material.StoneBrickWall: case Material.NetherBrickWall: case Material.AndesiteWall: case Material.RedNetherBrickWall: case Material.SandstoneWall:
                case Material.EndStoneBrickWall: case Material.DioriteWall: case Material.BlackstoneWall: case Material.PolishedBlackstoneWall: case Material.PolishedBlackstoneBrickWall:
                case Material.StoneButton: case Material.OakButton: case Material.SpruceButton: case Material.BirchButton: case Material.JungleButton: case Material.AcaciaButton: case Material.DarkOakButton:
                case Material.CrimsonButton: case Material.WarpedButton: case Material.PolishedBlackstoneButton: case Material.Anvil: case Material.ChippedAnvil: case Material.DamagedAnvil: case Material.TrappedChest:
                case Material.LightWeightedPressurePlate: case Material.HeavyWeightedPressurePlate: case Material.DaylightDetector: case Material.RedstoneBlock: case Material.NetherQuartzOre: case Material.Hopper:
                case Material.ChiseledQuartzBlock: case Material.QuartzBlock: case Material.QuartzBricks: case Material.QuartzPillar: case Material.QuartzStairs: case Material.ActivatorRail: case Material.Dropper:
                case Material.WhiteTerracotta: case Material.OrangeTerracotta: case Material.MagentaTerracotta: case Material.LightBlueTerracotta: case Material.YellowTerracotta: case Material.LimeTerracotta:
                case Material.PinkTerracotta: case Material.GrayTerracotta: case Material.LightGrayTerracotta: case Material.CyanTerracotta: case Material.PurpleTerracotta: case Material.BlueTerracotta:
                case Material.BrownTerracotta: case Material.GreenTerracotta: case Material.RedTerracotta: case Material.BlackTerracotta: case Material.Barrier: case Material.IronTrapdoor: case Material.HayBlock:
                case Material.WhiteCarpet: case Material.OrangeCarpet: case Material.MagentaCarpet: case Material.LightBlueCarpet: case Material.YellowCarpet: case Material.LimeCarpet: case Material.PinkCarpet:
                case Material.GrayCarpet: case Material.LightGrayCarpet: case Material.CyanCarpet: case Material.PurpleCarpet: case Material.BlueCarpet: case Material.BrownCarpet: case Material.GreenCarpet:
                case Material.RedCarpet: case Material.BlackCarpet: case Material.Terracotta: case Material.CoalBlock: case Material.PackedIce: case Material.AcaciaStairs: case Material.DarkOakStairs: case Material.SlimeBlock:
                case Material.GrassPath: case Material.Sunflower: case Material.Lilac: case Material.RoseBush: case Material.Peony: case Material.TallGrass: case Material.LargeFern: case Material.WhiteStainedGlass:
                case Material.OrangeStainedGlass: case Material.MagentaStainedGlass: case Material.LightBlueStainedGlass: case Material.YellowStainedGlass: case Material.LimeStainedGlass: case Material.PinkStainedGlass:
                case Material.GrayStainedGlass: case Material.LightGrayStainedGlass: case Material.CyanStainedGlass: case Material.PurpleStainedGlass: case Material.BlueStainedGlass: case Material.BrownStainedGlass:
                case Material.GreenStainedGlass: case Material.RedStainedGlass: case Material.BlackStainedGlass: case Material.WhiteStainedGlassPane: case Material.OrangeStainedGlassPane: case Material.MagentaStainedGlassPane:
                case Material.LightBlueStainedGlassPane: case Material.YellowStainedGlassPane: case Material.LimeStainedGlassPane: case Material.PinkStainedGlassPane: case Material.GrayStainedGlassPane: case Material.LightGrayStainedGlassPane:
                case Material.CyanStainedGlassPane: case Material.PurpleStainedGlassPane: case Material.BlueStainedGlassPane: case Material.BrownStainedGlassPane: case Material.GreenStainedGlassPane:
                case Material.RedStainedGlassPane: case Material.BlackStainedGlassPane: case Material.Prismarine: case Material.PrismarineBricks: case Material.DarkPrismarine: case Material.PrismarineStairs:
                case Material.PrismarineBrickStairs: case Material.DarkPrismarineStairs: case Material.SeaLantern: case Material.RedSandstone: case Material.ChiseledRedSandstone: case Material.CutRedSandstone:
                case Material.RedSandstoneStairs: case Material.RepeatingCommandBlock: case Material.ChainCommandBlock: case Material.MagmaBlock: case Material.NetherWartBlock: case Material.WarpedWartBlock:
                case Material.RedNetherBricks: case Material.BoneBlock: case Material.StructureVoid: case Material.Observer: case Material.ShulkerBox: case Material.WhiteShulkerBox: case Material.OrangeShulkerBox:
                case Material.MagentaShulkerBox: case Material.LightBlueShulkerBox: case Material.YellowShulkerBox: case Material.LimeShulkerBox: case Material.PinkShulkerBox: case Material.GrayShulkerBox:
                case Material.LightGrayShulkerBox: case Material.CyanShulkerBox: case Material.PurpleShulkerBox: case Material.BlueShulkerBox: case Material.BrownShulkerBox: case Material.GreenShulkerBox:
                case Material.RedShulkerBox: case Material.BlackShulkerBox: case Material.WhiteGlazedTerracotta: case Material.OrangeGlazedTerracotta: case Material.MagentaGlazedTerracotta: case Material.LightBlueGlazedTerracotta:
                case Material.YellowGlazedTerracotta: case Material.LimeGlazedTerracotta: case Material.PinkGlazedTerracotta: case Material.GrayGlazedTerracotta: case Material.LightGrayGlazedTerracotta: case Material.CyanGlazedTerracotta:
                case Material.PurpleGlazedTerracotta: case Material.BlueGlazedTerracotta: case Material.BrownGlazedTerracotta: case Material.GreenGlazedTerracotta: case Material.RedGlazedTerracotta:
                case Material.BlackGlazedTerracotta: case Material.WhiteConcrete: case Material.OrangeConcrete: case Material.MagentaConcrete: case Material.LightBlueConcrete: case Material.YellowConcrete:
                case Material.LimeConcrete: case Material.PinkConcrete: case Material.GrayConcrete: case Material.LightGrayConcrete: case Material.CyanConcrete: case Material.PurpleConcrete: case Material.BlueConcrete:
                case Material.BrownConcrete: case Material.GreenConcrete: case Material.RedConcrete: case Material.BlackConcrete: case Material.WhiteConcretePowder: case Material.OrangeConcretePowder:
                case Material.MagentaConcretePowder: case Material.LightBlueConcretePowder: case Material.YellowConcretePowder: case Material.LimeConcretePowder: case Material.PinkConcretePowder: case Material.GrayConcretePowder:
                case Material.LightGrayConcretePowder: case Material.CyanConcretePowder: case Material.PurpleConcretePowder: case Material.BlueConcretePowder: case Material.BrownConcretePowder: case Material.GreenConcretePowder:
                case Material.RedConcretePowder: case Material.BlackConcretePowder: case Material.TurtleEgg: case Material.DeadTubeCoralBlock: case Material.DeadBrainCoralBlock: case Material.DeadBubbleCoralBlock:
                case Material.DeadFireCoralBlock: case Material.DeadHornCoralBlock: case Material.TubeCoralBlock: case Material.BrainCoralBlock: case Material.BubbleCoralBlock: case Material.FireCoralBlock: case Material.HornCoralBlock:
                case Material.TubeCoral: case Material.BrainCoral: case Material.BubbleCoral: case Material.FireCoral: case Material.HornCoral: case Material.DeadBrainCoral: case Material.DeadBubbleCoral: case Material.DeadFireCoral:
                case Material.DeadHornCoral: case Material.DeadTubeCoral: case Material.TubeCoralFan: case Material.BrainCoralFan: case Material.BubbleCoralFan: case Material.FireCoralFan: case Material.HornCoralFan:
                case Material.DeadTubeCoralFan: case Material.DeadBrainCoralFan: case Material.DeadBubbleCoralFan: case Material.DeadFireCoralFan: case Material.DeadHornCoralFan: case Material.BlueIce: case Material.Conduit:
                case Material.PolishedGraniteStairs: case Material.SmoothRedSandstoneStairs: case Material.MossyStoneBrickStairs: case Material.PolishedDioriteStairs: case Material.MossyCobblestoneStairs: case Material.EndStoneBrickStairs:
                case Material.StoneStairs: case Material.SmoothSandstoneStairs: case Material.SmoothQuartzStairs: case Material.GraniteStairs: case Material.AndesiteStairs: case Material.RedNetherBrickStairs:
                case Material.PolishedAndesiteStairs: case Material.DioriteStairs: case Material.PolishedGraniteSlab: case Material.SmoothRedSandstoneSlab: case Material.MossyStoneBrickSlab: case Material.PolishedDioriteSlab:
                case Material.MossyCobblestoneSlab: case Material.EndStoneBrickSlab: case Material.SmoothSandstoneSlab: case Material.SmoothQuartzSlab: case Material.GraniteSlab: case Material.AndesiteSlab: case Material.RedNetherBrickSlab:
                case Material.PolishedAndesiteSlab: case Material.DioriteSlab: case Material.Scaffolding: case Material.IronDoor: case Material.OakDoor: case Material.SpruceDoor: case Material.BirchDoor: case Material.JungleDoor: case Material.AcaciaDoor:
                case Material.DarkOakDoor: case Material.CrimsonDoor: case Material.WarpedDoor: case Material.Repeater: case Material.Comparator: case Material.StructureBlock: case Material.Jigsaw: case Material.Wheat:
                case Material.OakSign: case Material.SpruceSign: case Material.BirchSign: case Material.JungleSign: case Material.AcaciaSign: case Material.DarkOakSign: case Material.CrimsonSign: case Material.WarpedSign:
                case Material.DriedKelpBlock: case Material.Cake: case Material.WhiteBed: case Material.OrangeBed: case Material.MagentaBed: case Material.LightBlueBed: case Material.YellowBed: case Material.LimeBed:
                case Material.PinkBed: case Material.GrayBed: case Material.LightGrayBed: case Material.CyanBed: case Material.PurpleBed: case Material.BlueBed: case Material.BrownBed: case Material.GreenBed: case Material.RedBed:
                case Material.BlackBed: case Material.NetherWart: case Material.BrewingStand: case Material.Cauldron: case Material.FlowerPot: case Material.SkeletonSkull: case Material.WitherSkeletonSkull: case Material.PlayerHead:
                case Material.ZombieHead: case Material.CreeperHead: case Material.DragonHead: case Material.WhiteBanner: case Material.OrangeBanner: case Material.MagentaBanner: case Material.LightBlueBanner: case Material.YellowBanner: 
                case Material.LimeBanner: case Material.PinkBanner: case Material.GrayBanner: case Material.LightGrayBanner: case Material.CyanBanner: case Material.PurpleBanner: case Material.BlueBanner: case Material.BrownBanner: case Material.GreenBanner:
                case Material.RedBanner: case Material.BlackBanner: case Material.Loom: case Material.Composter: case Material.Barrel: case Material.Smoker: case Material.BlastFurnace: case Material.CartographyTable: case Material.FletchingTable:
                case Material.Grindstone: case Material.Lectern: case Material.SmithingTable: case Material.Stonecutter: case Material.Bell: case Material.Lantern: case Material.SoulLantern: case Material.Campfire: case Material.SoulCampfire:
                case Material.Shroomlight: case Material.BeeNest: case Material.Beehive: case Material.HoneyBlock: case Material.HoneycombBlock: case Material.Lodestone: case Material.NetheriteBlock: case Material.AncientDebris:
                case Material.Target: case Material.CryingObsidian: case Material.Blackstone: case Material.BlackstoneSlab: case Material.BlackstoneStairs: case Material.GildedBlackstone: case Material.PolishedBlackstone:
                case Material.PolishedBlackstoneSlab: case Material.PolishedBlackstoneStairs: case Material.ChiseledPolishedBlackstone: case Material.PolishedBlackstoneBricks: case Material.PolishedBlackstoneBrickSlab:
                case Material.PolishedBlackstoneBrickStairs: case Material.CrackedPolishedBlackstoneBricks: case Material.RespawnAnchor:
                case Material.Water: case Material.Lava: case Material.StationaryWater: case Material.StationaryLava: case Material.TallSeagrass: case Material.PistonHead: case Material.MovingPiston: case Material.WallTorch: case Material.Fire: case Material.SoulFire: case Material.RedstoneWire: case Material.OakWallSign:
                case Material.SpruceWallSign: case Material.BirchWallSign: case Material.AcaciaWallSign: case Material.JungleWallSign: case Material.DarkOakWallSign: case Material.RedstoneWallTorch: case Material.SoulWallTorch:
                case Material.NetherPortal: case Material.AttachedPumpkinStem: case Material.AttachedMelonStem: case Material.PumpkinStem: case Material.MelonStem: case Material.EndPortal: case Material.Cocoa:
                case Material.Tripwire: case Material.PottedOakSapling: case Material.PottedSpruceSapling: case Material.PottedBirchSapling: case Material.PottedJungleSapling: case Material.PottedAcaciaSapling: case Material.PottedDarkOakSapling: case Material.PottedFern:
                case Material.PottedDandelion: case Material.PottedPoppy: case Material.PottedBlueOrchid: case Material.PottedAllium: case Material.PottedAzureBluet: case Material.PottedRedTulip: case Material.PottedOrangeTulip:
                case Material.PottedWhiteTulip: case Material.PottedPinkTulip: case Material.PottedOxeyeDaisy: case Material.PottedCornflower: case Material.PottedLilyOfTheValley: case Material.PottedWitherRose: case Material.PottedRedMushroom:
                case Material.PottedBrownMushroom: case Material.PottedDeadBush: case Material.PottedCactus: case Material.Carrots: case Material.Potatoes: case Material.SkeletonWallSkull: case Material.WitherSkeletonWallSkull:
                case Material.ZombieWallHead: case Material.PlayerWallHead: case Material.CreeperWallHead: case Material.DragonWallHead: case Material.WhiteWallBanner: case Material.OrangeWallBanner: case Material.MagentaWallBanner:
                case Material.LightBlueWallBanner: case Material.YellowWallBanner: case Material.LimeWallBanner: case Material.PinkWallBanner: case Material.GrayWallBanner: case Material.LightGrayWallBanner: case Material.CyanWallBanner:
                case Material.PurpleWallBanner: case Material.BlueWallBanner: case Material.BrownWallBanner: case Material.GreenWallBanner: case Material.RedWallBanner: case Material.BlackWallBanner: case Material.Beetroots:
                case Material.EndGateway: case Material.FrostedIce: case Material.KelpPlant: case Material.DeadTubeCoralWallFan: case Material.DeadBrainCoralWallFan: case Material.DeadBubbleCoralWallFan: case Material.DeadFireCoralWallFan:
                case Material.DeadHornCoralWallFan: case Material.TubeCoralWallFan: case Material.BrainCoralWallFan: case Material.BubbleCoralWallFan: case Material.FireCoralWallFan: case Material.HornCoralWallFan: case Material.BambooSapling:
                case Material.PottedBamboo: case Material.VoidAir: case Material.CaveAir: case Material.BubbleColumn: case Material.SweetBerryBush: case Material.WeepingVinesPlant: case Material.TwistingVinesPlant: case Material.CrimsonWallSign:
                case Material.WarpedWallSign: case Material.PottedCrimsonFungus: case Material.PottedWarpedFungus: case Material.PottedCrimsonRoots: case Material.PottedWarpedRoots:
                    return true;
            }

            return false;
        }

        public static bool IsEdible(this Material m)
        {
            switch (m)
            {
                case Material.Apple: case Material.MushroomStew: case Material.Bread: case Material.Porkchop: case Material.CookedPorkchop: case Material.GoldenApple:
                case Material.EnchantedGoldenApple: case Material.Cod: case Material.Salmon: case Material.TropicalFish: case Material.Pufferfish: case Material.CookedCod:
                case Material.CookedSalmon: case Material.Cookie: case Material.MelonSlice: case Material.DriedKelp: case Material.Beef: case Material.CookedBeef:
                case Material.Chicken: case Material.CookedChicken: case Material.RottenFlesh: case Material.SpiderEye: case Material.Carrot: case Material.Potato:
                case Material.BakedPotato: case Material.PoisonousPotato: case Material.GoldenCarrot: case Material.PumpkinPie: case Material.Rabbit: case Material.CookedRabbit:
                case Material.RabbitStew: case Material.Mutton: case Material.CookedMutton: case Material.ChorusFruit: case Material.Beetroot: case Material.BeetrootSoup:
                case Material.SuspiciousStew: case Material.SweetBerries: case Material.HoneyBottle:
                    return true;
            }

            return false;
        }

        public static bool IsRecord(this Material m)
        {
            switch (m)
            {
                case Material.MusicDisc13: case Material.MusicDiscCat: case Material.MusicDiscBlocks: case Material.MusicDiscChirp:
                case Material.MusicDiscFar: case Material.MusicDiscMall: case Material.MusicDiscMellohi: case Material.MusicDiscStal:
                case Material.MusicDiscStrad: case Material.MusicDiscWard: case Material.MusicDisc11: case Material.MusicDiscWait:
                case Material.MusicDiscPigstep:
                    return true;
            }

            return false;
        }

        public static bool IsSolid(this Material m)
        {
            if (!IsBlock(m))
                return false;
            switch (m)
            {
                case Material.Stone: case Material.Granite: case Material.PolishedGranite: case Material.Diorite: case Material.PolishedDiorite: case Material.Andesite:
                case Material.PolishedAndesite: case Material.GrassBlock: case Material.Dirt: case Material.CoarseDirt: case Material.Podzol: case Material.CrimsonNylium:
                case Material.WarpedNylium: case Material.Cobblestone: case Material.OakPlanks: case Material.SprucePlanks: case Material.BirchPlanks: case Material.JunglePlanks:
                case Material.AcaciaPlanks: case Material.DarkOakPlanks: case Material.CrimsonPlanks: case Material.WarpedPlanks: case Material.Bedrock: case Material.Sand:
                case Material.RedSand: case Material.Gravel: case Material.GoldOre: case Material.IronOre: case Material.CoalOre: case Material.NetherGoldOre: case Material.OakLog:
                case Material.SpruceLog: case Material.BirchLog: case Material.JungleLog: case Material.AcaciaLog: case Material.DarkOakLog: case Material.CrimsonStem: case Material.WarpedStem:
                case Material.StrippedOakLog: case Material.StrippedSpruceLog: case Material.StrippedBirchLog: case Material.StrippedJungleLog: case Material.StrippedAcaciaLog:
                case Material.StrippedDarkOakLog: case Material.StrippedCrimsonStem: case Material.StrippedWarpedStem: case Material.StrippedOakWood: case Material.StrippedSpruceWood:
                case Material.StrippedBirchWood: case Material.StrippedJungleWood: case Material.StrippedAcaciaWood: case Material.StrippedDarkOakWood: case Material.StrippedCrimsonHyphae:
                case Material.StrippedWarpedHyphae: case Material.OakWood: case Material.SpruceWood: case Material.BirchWood: case Material.JungleWood: case Material.AcaciaWood:
                case Material.DarkOakWood: case Material.CrimsonHyphae: case Material.WarpedHyphae: case Material.OakLeaves: case Material.SpruceLeaves: case Material.BirchLeaves:
                case Material.JungleLeaves: case Material.AcaciaLeaves: case Material.DarkOakLeaves: case Material.Sponge: case Material.WetSponge: case Material.Glass: case Material.LapisOre:
                case Material.LapisBlock: case Material.Dispenser: case Material.Sandstone: case Material.ChiseledSandstone: case Material.CutSandStone: case Material.NoteBlock:
                case Material.StickyPiston: case Material.Piston: case Material.WhiteWool: case Material.OrangeWool: case Material.MagentaWool: case Material.LightBlueWool:
                case Material.YellowWool: case Material.LimeWool: case Material.PinkWool: case Material.GrayWool: case Material.LightGrayWool: case Material.CyanWool: case Material.PurpleWool:
                case Material.BlueWool: case Material.BrownWool: case Material.GreenWool: case Material.RedWool: case Material.BlackWool: case Material.Bamboo: case Material.GoldBlock:
                case Material.IronBlock: case Material.OakSlab: case Material.SpruceSlab: case Material.BirchSlab: case Material.JungleSlab: case Material.AcaciaSlab: case Material.DarkOakSlab:
                case Material.CrimsonSlab: case Material.WarpedSlab: case Material.StoneSlab: case Material.SmoothStoneSlab: case Material.SandstoneSlab: case Material.CutSandstoneSlab:
                case Material.PetrifiedOakSlab: case Material.CobblestoneSlab: case Material.BrickSlab: case Material.StoneBrickSlab: case Material.NetherBrickSlab: case Material.QuartzSlab:
                case Material.RedSandstoneSlab: case Material.CutRedSandstoneSlab: case Material.PurpurSlab: case Material.PrismarineSlab: case Material.PrismarineBrickSlab: case Material.DarkPrismarineSlab:
                case Material.SmoothQuartz: case Material.SmoothRedSandstone: case Material.SmoothSandstone: case Material.SmoothStone: case Material.Bricks: case Material.Tnt: case Material.Bookshelf:
                case Material.MossyCobblestone: case Material.Obsidian: case Material.PurpurBlock: case Material.PurpurPillar: case Material.PurpurStairs: case Material.Spawner: case Material.OakStairs:
                case Material.Chest: case Material.DiamondOre: case Material.DiamondBlock: case Material.CraftingTable: case Material.Farmland: case Material.Furnace: case Material.CobblestoneStairs:
                case Material.StonePressurePlate: case Material.OakPressurePlate: case Material.SprucePressurePlate: case Material.BirchPressurePlate: case Material.JunglePressurePlate: case Material.AcaciaPressurePlate:
                case Material.DarkOakPressurePlate: case Material.CrimsonPressurePlate: case Material.WarpedPressurePlate: case Material.PolishedBlackstonePressurePlate: case Material.RedstoneOre: case Material.Ice:
                case Material.SnowBlock: case Material.Cactus: case Material.Clay: case Material.Jukebox: case Material.OakFence: case Material.SpruceFence: case Material.BirchFence: case Material.JungleFence:
                case Material.AcaciaFence: case Material.DarkOakFence: case Material.CrimsonFence: case Material.WarpedFence: case Material.Pumpkin: case Material.CarvedPumpkin: case Material.NetherRack:
                case Material.SoulSand: case Material.SoulSoil: case Material.Basalt: case Material.PolishedBasalt: case Material.Glowstone: case Material.JackOLantern: case Material.OakTrapdoor: case Material.SpruceTrapdoor:
                case Material.BirchTrapdoor: case Material.JungleTrapdoor: case Material.AcaciaTrapdoor: case Material.DarkOakTrapdoor: case Material.CrimsonTrapdoor: case Material.WarpedTrapdoor: case Material.InfestedStone:
                case Material.InfestedCobblestone: case Material.InfestedStoneBricks: case Material.InfestedMossyStoneBricks: case Material.InfestedCrackedStoneBricks: case Material.InfestedChiseledStoneBricks:
                case Material.StoneBricks: case Material.MossyStoneBricks: case Material.CrackedStoneBricks: case Material.ChiseledStoneBricks: case Material.BrownMushroomBlock: case Material.RedMushroomBlock:
                case Material.MushroomStem: case Material.IronBars: case Material.Chain: case Material.GlassPane: case Material.Melon: case Material.OakFenceGate: case Material.SpruceFenceGate: case Material.BirchFenceGate:
                case Material.JungleFenceGate: case Material.AcaciaFenceGate: case Material.DarkOakFenceGate: case Material.CrimsonFenceGate: case Material.WarpedFenceGate: case Material.BrickStairs: case Material.StoneBrickStairs:
                case Material.Mycelium: case Material.NetherBricks: case Material.CrackedNetherBricks: case Material.ChiseledNetherBricks: case Material.NetherBrickFence: case Material.NetherBrickStairs: case Material.EnchantingTable:
                case Material.EndPortalFrame: case Material.EndStone: case Material.EndStoneBricks: case Material.DragonEgg: case Material.RedstoneLamp: case Material.SandstoneStairs: case Material.EmeraldOre: case Material.EnderChest:
                case Material.EmeraldBlock: case Material.SpruceStairs: case Material.BirchStairs: case Material.JungleStairs: case Material.CrimsonStairs: case Material.WarpedStairs: case Material.CommandBlock: case Material.Beacon:
                case Material.CobblestoneWall: case Material.MossyCobblestoneWall: case Material.BrickWall: case Material.PrismarineWall: case Material.RedSandstoneWall: case Material.MossyStoneBrickWall: case Material.GraniteWall:
                case Material.StoneBrickWall: case Material.NetherBrickWall: case Material.AndesiteWall: case Material.RedNetherBrickWall: case Material.SandstoneWall: case Material.EndStoneBrickWall: case Material.DioriteWall:
                case Material.BlackstoneWall: case Material.PolishedBlackstoneWall: case Material.PolishedBlackstoneBrickWall: case Material.Anvil: case Material.ChippedAnvil: case Material.DamagedAnvil: case Material.TrappedChest:
                case Material.LightWeightedPressurePlate: case Material.HeavyWeightedPressurePlate: case Material.DaylightDetector: case Material.RedstoneBlock: case Material.NetherQuartzOre: case Material.Hopper:
                case Material.ChiseledQuartzBlock: case Material.QuartzBlock: case Material.QuartzBricks: case Material.QuartzPillar: case Material.QuartzStairs: case Material.Dropper: case Material.WhiteTerracotta:
                case Material.OrangeTerracotta: case Material.MagentaTerracotta: case Material.LightBlueTerracotta: case Material.YellowTerracotta: case Material.LimeTerracotta: case Material.PinkTerracotta: case Material.GrayTerracotta:
                case Material.LightGrayTerracotta: case Material.CyanTerracotta: case Material.PurpleTerracotta: case Material.BlueTerracotta: case Material.BrownTerracotta: case Material.GreenTerracotta: case Material.RedTerracotta:
                case Material.BlackTerracotta: case Material.Barrier: case Material.IronTrapdoor: case Material.HayBlock: case Material.Terracotta: case Material.CoalBlock: case Material.PackedIce: case Material.AcaciaStairs:
                case Material.DarkOakStairs: case Material.SlimeBlock: case Material.GrassPath: case Material.WhiteStainedGlass: case Material.OrangeStainedGlass: case Material.MagentaStainedGlass: case Material.LightBlueStainedGlass:
                case Material.YellowStainedGlass: case Material.LimeStainedGlass: case Material.PinkStainedGlass: case Material.GrayStainedGlass: case Material.LightGrayStainedGlass: case Material.CyanStainedGlass: case Material.PurpleStainedGlass:
                case Material.BlueStainedGlass: case Material.BrownStainedGlass: case Material.GreenStainedGlass: case Material.RedStainedGlass: case Material.BlackStainedGlass: case Material.WhiteStainedGlassPane: case Material.OrangeStainedGlassPane:
                case Material.MagentaStainedGlassPane: case Material.LightBlueStainedGlassPane: case Material.YellowStainedGlassPane: case Material.LimeStainedGlassPane: case Material.PinkStainedGlassPane: case Material.GrayStainedGlassPane:
                case Material.LightGrayStainedGlassPane: case Material.CyanStainedGlassPane: case Material.PurpleStainedGlassPane: case Material.BlueStainedGlassPane: case Material.BrownStainedGlassPane: case Material.GreenStainedGlassPane:
                case Material.RedStainedGlassPane: case Material.BlackStainedGlassPane: case Material.Prismarine: case Material.PrismarineBricks: case Material.DarkPrismarine: case Material.PrismarineStairs: case Material.PrismarineBrickStairs:
                case Material.DarkPrismarineStairs: case Material.SeaLantern: case Material.RedSandstone: case Material.ChiseledRedSandstone: case Material.CutRedSandstone: case Material.RedSandstoneStairs: case Material.RepeatingCommandBlock:
                case Material.ChainCommandBlock: case Material.MagmaBlock: case Material.NetherWartBlock: case Material.WarpedWartBlock: case Material.RedNetherBricks: case Material.BoneBlock: case Material.Observer: case Material.ShulkerBox:
                case Material.WhiteShulkerBox: case Material.OrangeShulkerBox: case Material.MagentaShulkerBox: case Material.LightBlueShulkerBox: case Material.YellowShulkerBox: case Material.LimeShulkerBox: case Material.PinkShulkerBox:
                case Material.GrayShulkerBox: case Material.LightGrayShulkerBox: case Material.CyanShulkerBox: case Material.PurpleShulkerBox: case Material.BlueShulkerBox: case Material.BrownShulkerBox: case Material.GreenShulkerBox:
                case Material.RedShulkerBox: case Material.BlackShulkerBox: case Material.WhiteGlazedTerracotta: case Material.OrangeGlazedTerracotta: case Material.MagentaGlazedTerracotta: case Material.LightBlueGlazedTerracotta: case Material.YellowGlazedTerracotta:
                case Material.LimeGlazedTerracotta: case Material.PinkGlazedTerracotta: case Material.GrayGlazedTerracotta: case Material.LightGrayGlazedTerracotta: case Material.CyanGlazedTerracotta: case Material.PurpleGlazedTerracotta: case Material.BlueGlazedTerracotta:
                case Material.BrownGlazedTerracotta: case Material.GreenGlazedTerracotta: case Material.RedGlazedTerracotta: case Material.BlackGlazedTerracotta: case Material.WhiteConcrete: case Material.OrangeConcrete: case Material.MagentaConcrete:
                case Material.LightBlueConcrete: case Material.YellowConcrete: case Material.LimeConcrete: case Material.PinkConcrete: case Material.GrayConcrete: case Material.LightGrayConcrete: case Material.CyanConcrete: case Material.PurpleConcrete:
                case Material.BlueConcrete: case Material.BrownConcrete: case Material.GreenConcrete: case Material.RedConcrete: case Material.BlackConcrete: case Material.WhiteConcretePowder: case Material.OrangeConcretePowder: case Material.MagentaConcretePowder:
                case Material.LightBlueConcretePowder: case Material.YellowConcretePowder: case Material.LimeConcretePowder: case Material.PinkConcretePowder: case Material.GrayConcretePowder: case Material.LightGrayConcretePowder: case Material.CyanConcretePowder:
                case Material.PurpleConcretePowder: case Material.BlueConcretePowder: case Material.BrownConcretePowder: case Material.GreenConcretePowder: case Material.RedConcretePowder: case Material.BlackConcretePowder: case Material.TurtleEgg: case Material.DeadTubeCoralBlock:
                case Material.DeadBrainCoralBlock: case Material.DeadBubbleCoralBlock: case Material.DeadFireCoralBlock: case Material.DeadHornCoralBlock: case Material.TubeCoralBlock: case Material.BrainCoralBlock: case Material.BubbleCoralBlock: case Material.FireCoralBlock:
                case Material.HornCoralBlock: case Material.DeadBrainCoral: case Material.DeadBubbleCoral: case Material.DeadFireCoral: case Material.DeadHornCoral: case Material.DeadTubeCoral: case Material.DeadTubeCoralFan: case Material.DeadBrainCoralFan: case Material.DeadBubbleCoralFan:
                case Material.DeadFireCoralFan: case Material.DeadHornCoralFan: case Material.BlueIce: case Material.Conduit: case Material.PolishedGraniteStairs: case Material.SmoothRedSandstoneStairs: case Material.MossyStoneBrickStairs: case Material.PolishedDioriteStairs: case Material.MossyCobblestoneStairs:
                case Material.EndStoneBrickStairs: case Material.StoneStairs: case Material.SmoothSandstoneStairs: case Material.SmoothQuartzStairs: case Material.GraniteStairs: case Material.AndesiteStairs: case Material.RedNetherBrickStairs: case Material.PolishedAndesiteStairs:
                case Material.DioriteStairs: case Material.PolishedGraniteSlab: case Material.SmoothRedSandstoneSlab: case Material.MossyStoneBrickSlab: case Material.PolishedDioriteSlab: case Material.MossyCobblestoneSlab: case Material.EndStoneBrickSlab: case Material.SmoothSandstoneSlab:
                case Material.SmoothQuartzSlab: case Material.GraniteSlab: case Material.AndesiteSlab: case Material.RedNetherBrickSlab: case Material.PolishedAndesiteSlab: case Material.DioriteSlab: case Material.IronDoor: case Material.OakDoor: case Material.SpruceDoor: case Material.BirchDoor:
                case Material.JungleDoor: case Material.AcaciaDoor: case Material.DarkOakDoor: case Material.CrimsonDoor: case Material.WarpedDoor: case Material.StructureBlock: case Material.Jigsaw: case Material.OakSign: case Material.SpruceSign: case Material.BirchSign: case Material.JungleSign:
                case Material.AcaciaSign: case Material.DarkOakSign: case Material.CrimsonSign: case Material.WarpedSign: case Material.DriedKelpBlock: case Material.Cake: case Material.WhiteBed: case Material.OrangeBed: case Material.MagentaBed: case Material.LightBlueBed: case Material.YellowBed:
                case Material.LimeBed: case Material.PinkBed: case Material.GrayBed: case Material.LightGrayBed: case Material.CyanBed: case Material.PurpleBed: case Material.BlueBed: case Material.BrownBed: case Material.GreenBed: case Material.RedBed: case Material.BlackBed: case Material.BrewingStand:
                case Material.Cauldron: case Material.WhiteBanner: case Material.OrangeBanner: case Material.MagentaBanner: case Material.LightBlueBanner: case Material.YellowBanner: case Material.LimeBanner: case Material.PinkBanner: case Material.GrayBanner: case Material.LightGrayBanner: case Material.CyanBanner:
                case Material.PurpleBanner: case Material.BlueBanner: case Material.BrownBanner: case Material.GreenBanner: case Material.RedBanner: case Material.BlackBanner: case Material.Loom: case Material.Composter: case Material.Barrel: case Material.Smoker: case Material.BlastFurnace: case Material.CartographyTable:
                case Material.FletchingTable: case Material.Grindstone: case Material.Lectern: case Material.SmithingTable: case Material.Stonecutter: case Material.Bell: case Material.Lantern: case Material.SoulLantern: case Material.Campfire: case Material.SoulCampfire: case Material.Shroomlight: case Material.BeeNest: case Material.Beehive:
                case Material.HoneyBlock: case Material.HoneycombBlock: case Material.Lodestone: case Material.NetheriteBlock: case Material.AncientDebris: case Material.Target: case Material.CryingObsidian: case Material.Blackstone: case Material.BlackstoneSlab: case Material.BlackstoneStairs: case Material.GildedBlackstone: case Material.PolishedBlackstone:
                case Material.PolishedBlackstoneSlab: case Material.PolishedBlackstoneStairs: case Material.ChiseledPolishedBlackstone: case Material.PolishedBlackstoneBricks: case Material.PolishedBlackstoneBrickSlab: case Material.PolishedBlackstoneBrickStairs: case Material.CrackedPolishedBlackstoneBricks: case Material.RespawnAnchor:
                case Material.PistonHead: case Material.MovingPiston: case Material.OakWallSign: case Material.SpruceWallSign: case Material.BirchWallSign: case Material.AcaciaWallSign: case Material.JungleWallSign: case Material.DarkOakWallSign: case Material.WhiteWallBanner:
                case Material.OrangeWallBanner: case Material.MagentaWallBanner: case Material.LightBlueWallBanner: case Material.YellowWallBanner: case Material.LimeWallBanner: case Material.PinkWallBanner: case Material.GrayWallBanner: case Material.LightGrayWallBanner: case Material.CyanWallBanner:
                case Material.PurpleWallBanner: case Material.BlueWallBanner: case Material.BrownWallBanner: case Material.GreenWallBanner: case Material.RedWallBanner: case Material.BlackWallBanner: case Material.FrostedIce: case Material.DeadTubeCoralWallFan:
                case Material.DeadBrainCoralWallFan: case Material.DeadBubbleCoralWallFan: case Material.DeadFireCoralWallFan: case Material.DeadHornCoralWallFan: case Material.CrimsonWallSign: case Material.WarpedWallSign:
                    return true;
            }

            return false;
        }

        public static bool IsAir(this Material m)
        {
            switch (m)
            {
                case Material.Air: case Material.CaveAir: case Material.VoidAir:
                    return true;
            }

            return false;
        }

        public static bool IsTransparent(this Material m)
        {
            switch (m)
            {
                case Material.Air: case Material.OakSapling: case Material.SpruceSapling: case Material.BirchSapling: case Material.JungleSapling: case Material.AcaciaSapling: case Material.DarkOakSapling:
                case Material.PoweredRail: case Material.DetectorRail: case Material.Grass: case Material.Fern: case Material.DeadBush: case Material.Dandelion: case Material.Poppy: case Material.BlueOrchid:
                case Material.Allium: case Material.AzureBluet: case Material.RedTulip: case Material.OrangeTulip: case Material.WhiteTulip: case Material.PinkTulip: case Material.OxeyeDaisy: case Material.BrownMushroom:
                case Material.RedMushRoom: case Material.SugarCane: case Material.Torch: case Material.EndRod: case Material.ChorusPlant: case Material.ChorusFlower: case Material.Ladder: case Material.Rail:
                case Material.Lever: case Material.RedstoneTorch: case Material.Snow: case Material.Vine: case Material.LilyPad: case Material.TripwireHook: case Material.StoneButton: case Material.OakButton:
                case Material.SpruceButton: case Material.BirchButton: case Material.JungleButton: case Material.AcaciaButton: case Material.DarkOakButton: case Material.ActivatorRail: case Material.Barrier:
                case Material.WhiteCarpet: case Material.OrangeCarpet: case Material.MagentaCarpet: case Material.LightBlueCarpet: case Material.YellowCarpet: case Material.LimeCarpet: case Material.PinkCarpet:
                case Material.GrayCarpet: case Material.LightGrayCarpet: case Material.CyanCarpet: case Material.PurpleCarpet: case Material.BlueCarpet: case Material.BrownCarpet: case Material.GreenCarpet:
                case Material.RedCarpet: case Material.BlackCarpet: case Material.Sunflower: case Material.Lilac: case Material.RoseBush: case Material.Peony: case Material.TallGrass: case Material.LargeFern:
                case Material.StructureVoid: case Material.Repeater: case Material.Comparator: case Material.Wheat: case Material.NetherWart: case Material.FlowerPot: case Material.SkeletonSkull:
                case Material.WitherSkeletonSkull: case Material.PlayerHead: case Material.ZombieHead: case Material.CreeperHead: case Material.DragonHead: case Material.WallTorch: case Material.Fire:
                case Material.RedstoneWire: case Material.RedstoneWallTorch: case Material.NetherPortal: case Material.AttachedPumpkinStem: case Material.AttachedMelonStem: case Material.PumpkinStem:
                case Material.MelonStem: case Material.EndPortal: case Material.Cocoa: case Material.Tripwire: case Material.PottedOakSapling: case Material.PottedSpruceSapling: case Material.PottedBirchSapling:
                case Material.PottedJungleSapling: case Material.PottedAcaciaSapling: case Material.PottedDarkOakSapling: case Material.PottedFern: case Material.PottedDandelion: case Material.PottedPoppy:
                case Material.PottedBlueOrchid: case Material.PottedAllium: case Material.PottedAzureBluet: case Material.PottedRedTulip: case Material.PottedOrangeTulip: case Material.PottedWhiteTulip:
                case Material.PottedPinkTulip: case Material.PottedOxeyeDaisy: case Material.PottedRedMushroom: case Material.PottedBrownMushroom: case Material.PottedDeadBush: case Material.PottedCactus:
                case Material.Carrots: case Material.Potatoes: case Material.SkeletonWallSkull: case Material.WitherSkeletonWallSkull: case Material.ZombieWallHead: case Material.PlayerWallHead:
                case Material.CreeperWallHead: case Material.DragonWallHead: case Material.Beetroots: case Material.EndGateway: case Material.VoidAir: case Material.CaveAir:
                    return true;
            }

            return false;
        }

        public static bool IsFlammable(this Material m)
        {
            if (!IsBlock(m))
                return false;

            switch (m)
            {
                case Material.OakPlanks: case Material.SprucePlanks: case Material.BirchPlanks: case Material.JunglePlanks: case Material.AcaciaPlanks: case Material.DarkOakPlanks: case Material.OakLog: case Material.SpruceLog:
                case Material.BirchLog: case Material.JungleLog: case Material.AcaciaLog: case Material.DarkOakLog: case Material.StrippedOakLog: case Material.StrippedSpruceLog: case Material.StrippedBirchLog: case Material.StrippedJungleLog:
                case Material.StrippedAcaciaLog: case Material.StrippedDarkOakLog: case Material.StrippedOakWood: case Material.StrippedSpruceWood: case Material.StrippedBirchWood: case Material.StrippedJungleWood: case Material.StrippedAcaciaWood:
                case Material.StrippedDarkOakWood: case Material.OakWood: case Material.SpruceWood: case Material.BirchWood: case Material.JungleWood: case Material.AcaciaWood: case Material.DarkOakWood: case Material.OakLeaves: case Material.SpruceLeaves:
                case Material.BirchLeaves: case Material.JungleLeaves: case Material.AcaciaLeaves: case Material.DarkOakLeaves: case Material.NoteBlock: case Material.Grass: case Material.Fern: case Material.DeadBush: case Material.WhiteWool:
                case Material.OrangeWool: case Material.MagentaWool: case Material.LightBlueWool: case Material.YellowWool: case Material.LimeWool: case Material.PinkWool: case Material.GrayWool: case Material.LightGrayWool: case Material.CyanWool:
                case Material.PurpleWool: case Material.BlueWool: case Material.BrownWool: case Material.GreenWool: case Material.RedWool: case Material.BlackWool: case Material.Bamboo: case Material.OakSlab: case Material.SpruceSlab:
                case Material.BirchSlab: case Material.JungleSlab: case Material.AcaciaSlab: case Material.DarkOakSlab: case Material.Tnt: case Material.Bookshelf: case Material.OakStairs: case Material.Chest: case Material.CraftingTable:
                case Material.OakPressurePlate: case Material.SprucePressurePlate: case Material.BirchPressurePlate: case Material.JunglePressurePlate: case Material.AcaciaPressurePlate: case Material.DarkOakPressurePlate: case Material.Jukebox:
                case Material.OakFence: case Material.SpruceFence: case Material.BirchFence: case Material.JungleFence: case Material.AcaciaFence: case Material.DarkOakFence: case Material.OakTrapdoor: case Material.SpruceTrapdoor: case Material.BirchTrapdoor:
                case Material.JungleTrapdoor: case Material.AcaciaTrapdoor: case Material.DarkOakTrapdoor: case Material.BrownMushroomBlock: case Material.RedMushroomBlock: case Material.MushroomStem: case Material.Vine: case Material.OakFenceGate:
                case Material.SpruceFenceGate: case Material.BirchFenceGate: case Material.JungleFenceGate: case Material.AcaciaFenceGate: case Material.DarkOakFenceGate: case Material.SpruceStairs: case Material.BirchStairs: case Material.JungleStairs:
                case Material.TrappedChest: case Material.DaylightDetector: case Material.WhiteCarpet: case Material.OrangeCarpet: case Material.MagentaCarpet: case Material.LightBlueCarpet: case Material.YellowCarpet: case Material.LimeCarpet:
                case Material.PinkCarpet: case Material.GrayCarpet: case Material.LightGrayCarpet: case Material.CyanCarpet: case Material.PurpleCarpet: case Material.BlueCarpet: case Material.BrownCarpet: case Material.GreenCarpet: case Material.RedCarpet:
                case Material.BlackCarpet: case Material.AcaciaStairs: case Material.DarkOakStairs: case Material.Sunflower: case Material.Lilac: case Material.RoseBush: case Material.Peony: case Material.TallGrass: case Material.LargeFern: case Material.OakDoor:
                case Material.SpruceDoor: case Material.BirchDoor: case Material.JungleDoor: case Material.AcaciaDoor: case Material.DarkOakDoor: case Material.OakSign: case Material.SpruceSign: case Material.BirchSign: case Material.JungleSign:
                case Material.AcaciaSign: case Material.DarkOakSign: case Material.WhiteBed: case Material.OrangeBed: case Material.MagentaBed: case Material.LightBlueBed: case Material.YellowBed: case Material.LimeBed: case Material.PinkBed:
                case Material.GrayBed: case Material.LightGrayBed: case Material.CyanBed: case Material.PurpleBed: case Material.BlueBed: case Material.BrownBed: case Material.GreenBed: case Material.RedBed: case Material.BlackBed: case Material.WhiteBanner:
                case Material.OrangeBanner: case Material.MagentaBanner: case Material.LightBlueBanner: case Material.YellowBanner: case Material.LimeBanner: case Material.PinkBanner: case Material.GrayBanner: case Material.LightGrayBanner: case Material.CyanBanner:
                case Material.PurpleBanner: case Material.BlueBanner: case Material.BrownBanner: case Material.GreenBanner: case Material.RedBanner: case Material.BlackBanner: case Material.Loom: case Material.Composter: case Material.Barrel:
                case Material.CartographyTable: case Material.FletchingTable: case Material.Lectern: case Material.SmithingTable: case Material.Campfire: case Material.SoulCampfire: case Material.BeeNest: case Material.Beehive: case Material.OakWallSign:
                case Material.SpruceWallSign: case Material.BirchWallSign: case Material.AcaciaWallSign: case Material.JungleWallSign: case Material.DarkOakWallSign: case Material.WhiteWallBanner: case Material.OrangeWallBanner: case Material.MagentaWallBanner:
                case Material.LightBlueWallBanner: case Material.YellowWallBanner: case Material.LimeWallBanner: case Material.PinkWallBanner: case Material.GrayWallBanner: case Material.LightGrayWallBanner: case Material.CyanWallBanner: case Material.PurpleWallBanner:
                case Material.BlueWallBanner: case Material.BrownWallBanner: case Material.GreenWallBanner: case Material.RedWallBanner: case Material.BlackWallBanner: case Material.BambooSapling:
                    return true;
            }

            return false;
        }

        public static bool IsFuel(this Material m)
        {
            switch (m)
            {
                case Material.OakPlanks: case Material.SprucePlanks: case Material.BirchPlanks: case Material.JunglePlanks: case Material.AcaciaPlanks: case Material.DarkOakPlanks: case Material.OakSapling: case Material.SpruceSapling:
                case Material.BirchSapling: case Material.JungleSapling: case Material.AcaciaSapling: case Material.DarkOakSapling: case Material.OakLog: case Material.SpruceLog: case Material.BirchLog: case Material.JungleLog:
                case Material.AcaciaLog: case Material.DarkOakLog: case Material.StrippedOakLog: case Material.StrippedSpruceLog: case Material.StrippedBirchLog: case Material.StrippedJungleLog: case Material.StrippedAcaciaLog:
                case Material.StrippedDarkOakLog: case Material.StrippedOakWood: case Material.StrippedSpruceWood: case Material.StrippedBirchWood: case Material.StrippedJungleWood: case Material.StrippedAcaciaWood: case Material.StrippedDarkOakWood:
                case Material.OakWood: case Material.SpruceWood: case Material.BirchWood: case Material.JungleWood: case Material.AcaciaWood: case Material.DarkOakWood: case Material.NoteBlock: case Material.DeadBush: case Material.WhiteWool:
                case Material.OrangeWool: case Material.MagentaWool: case Material.LightBlueWool: case Material.YellowWool: case Material.LimeWool: case Material.PinkWool: case Material.GrayWool: case Material.LightGrayWool: case Material.CyanWool:
                case Material.PurpleWool: case Material.BlueWool: case Material.BrownWool: case Material.GreenWool: case Material.RedWool: case Material.BlackWool: case Material.Bamboo: case Material.OakSlab: case Material.SpruceSlab:
                case Material.BirchSlab: case Material.JungleSlab: case Material.AcaciaSlab: case Material.DarkOakSlab: case Material.Bookshelf: case Material.OakStairs: case Material.Chest: case Material.CraftingTable: case Material.Ladder:
                case Material.OakPressurePlate: case Material.SprucePressurePlate: case Material.BirchPressurePlate: case Material.JunglePressurePlate: case Material.AcaciaPressurePlate: case Material.DarkOakPressurePlate: case Material.Jukebox:
                case Material.OakFence: case Material.SpruceFence: case Material.BirchFence: case Material.JungleFence: case Material.AcaciaFence: case Material.DarkOakFence: case Material.OakTrapdoor: case Material.SpruceTrapdoor: case Material.BirchTrapdoor:
                case Material.JungleTrapdoor: case Material.AcaciaTrapdoor: case Material.DarkOakTrapdoor: case Material.OakFenceGate: case Material.SpruceFenceGate: case Material.BirchFenceGate: case Material.JungleFenceGate: case Material.AcaciaFenceGate:
                case Material.DarkOakFenceGate: case Material.SpruceStairs: case Material.BirchStairs: case Material.JungleStairs: case Material.OakButton: case Material.SpruceButton: case Material.BirchButton: case Material.JungleButton: case Material.AcaciaButton:
                case Material.DarkOakButton: case Material.TrappedChest: case Material.DaylightDetector: case Material.WhiteCarpet: case Material.OrangeCarpet: case Material.MagentaCarpet: case Material.LightBlueCarpet: case Material.YellowCarpet:
                case Material.LimeCarpet: case Material.PinkCarpet: case Material.GrayCarpet: case Material.LightGrayCarpet: case Material.CyanCarpet: case Material.PurpleCarpet: case Material.BlueCarpet: case Material.BrownCarpet: case Material.GreenCarpet:
                case Material.RedCarpet: case Material.BlackCarpet: case Material.CoalBlock: case Material.AcaciaStairs: case Material.DarkOakStairs: case Material.Scaffolding: case Material.OakDoor: case Material.SpruceDoor: case Material.BirchDoor: case Material.JungleDoor:
                case Material.AcaciaDoor: case Material.DarkOakDoor: case Material.Bow: case Material.Coal: case Material.Charcoal: case Material.WoodenSword: case Material.WoodenShovel: case Material.WoodenPickaxe: case Material.WoodenAxe: case Material.WoodenHoe:
                case Material.Stick: case Material.Bowl: case Material.OakSign: case Material.SpruceSign: case Material.BirchSign: case Material.JungleSign: case Material.AcaciaSign: case Material.DarkOakSign: case Material.LavaBucket: case Material.OakBoat:
                case Material.DriedKelpBlock: case Material.FishingRod: case Material.BlazeRod: case Material.WhiteBanner: case Material.OrangeBanner: case Material.MagentaBanner: case Material.LightBlueBanner: case Material.YellowBanner: case Material.LimeBanner:
                case Material.PinkBanner: case Material.GrayBanner: case Material.LightGrayBanner: case Material.CyanBanner: case Material.PurpleBanner: case Material.BlueBanner: case Material.BrownBanner: case Material.GreenBanner: case Material.RedBanner:
                case Material.BlackBanner: case Material.SpruceBoat: case Material.BirchBoat: case Material.JungleBoat: case Material.DarkOakBoat: case Material.Crossbow: case Material.Loom: case Material.Composter: case Material.Barrel: case Material.CartographyTable:
                case Material.FletchingTable: case Material.Lectern: case Material.SmithingTable:
                    return true;
            }

            return false;
        }

        public static string GetName(this Material m)
        {
            return m.ToString().Name2Minecraft();
        }
    }
}