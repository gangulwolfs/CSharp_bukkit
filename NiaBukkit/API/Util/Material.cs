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
        Andestie,
        [MaterialAttribute(8335,1, 6)]
        PolishedAndestie,
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
        
        //TODO: old Id
        [MaterialAttribute(11542,1, 2)]
        Sand,
        [MaterialAttribute(16279,1, 2)]
        RedSand,
        [MaterialAttribute(7804,1, 2)]
        Gravel,
        [MaterialAttribute(32625,1, 2)]
        GoldOre,
        [MaterialAttribute(19834,1, 2)]
        IronOre,
        [MaterialAttribute(30965,1, 2)]
        CoalOre,
        [MaterialAttribute(4185,1, 2)]
        NetherGoldOre,
        [MaterialAttribute(26723,1, 2)]
        OakLog,
        [MaterialAttribute(9726,1, 2)]
        SpruceLog,
        [MaterialAttribute(26727,1, 2)]
        BirchLog,
        [MaterialAttribute(20721,1, 2)]
        JungleLog,
        [MaterialAttribute(8385,1, 2)]
        AcaciaLog,
        [MaterialAttribute(14831,1)]
        DarkOakLog,
        [MaterialAttribute(27920,1)]
        CrimsonStem,
        [MaterialAttribute(28920,1)]
        WarpedStem,
        [MaterialAttribute(20523,1)]
        StrippedOakLog,
        [MaterialAttribute(6140,1)]
        StrippedSpruceLog,
        [MaterialAttribute(8838,1)]
        StrippedBirchLog,
        [MaterialAttribute(15476,1)]
        StrippedJungleLog,
        [MaterialAttribute(18167,1)]
        StrippedAcaciaLog,
        [MaterialAttribute(6492,1)]
        StrippedDarkOakLog,
        [MaterialAttribute(16882,1)]
        StrippedCrimsonStem,
        [MaterialAttribute(15627,1)]
        StrippedWarpedStem,
        [MaterialAttribute(31455,1)]
        StrippedOakWood,
        [MaterialAttribute(6467,1)]
        StrippedSpruceWood,
        [MaterialAttribute(22350,1)]
        StrippedBirchWood,
        [MaterialAttribute(30315,1)]
        StrippedJungleWood,
        [MaterialAttribute(27193,1)]
        StrippedAcaciaWood,
        [MaterialAttribute(16000,1)]
        StrippedDarkOakWood,
        [MaterialAttribute(27488,1)]
        StrippedCrimsonHyphae,
        [MaterialAttribute(7422,1)]
        StrippedWarpedHyphae,
        [MaterialAttribute(7378,1)]
        OakWood,
        [MaterialAttribute(32328,1)]
        SpruceWood,
        [MaterialAttribute(20913,1)]
        BirchWood,
        [MaterialAttribute(10341,1)]
        JungleWood,
        [MaterialAttribute(9541,1)]
        AcaciaWood,
        [MaterialAttribute(16995,1)]
        DarkOakWood,
        [MaterialAttribute(6550,1)]
        CrimsonHyphae,
        [MaterialAttribute(18439,1)]
        WarpedHyphae,
        [MaterialAttribute(4385,1)]
        OakLeaves,
        [MaterialAttribute(20039,1)]
        SpruceLeaves,
        [MaterialAttribute(12601,1)]
        BirchLeaves,
        [MaterialAttribute(5133,1)]
        JungleLeaves,
        [MaterialAttribute(16606,1)]
        AcaciaLeaves,
        [MaterialAttribute(22254,1)]
        DarkOakLeaves,
        [MaterialAttribute(15860,1)]
        Sponge,
        [MaterialAttribute(9043,1)]
        WetSponge,
        [MaterialAttribute(6195,1)]
        Glass,
        [MaterialAttribute(22934,1)]
        LapisOre,
        [MaterialAttribute(14485,1)]
        LapisBlock,
        [MaterialAttribute(20871,1)]
        Dispenser,
        [MaterialAttribute(13141,1)]
        Sandstone,
        [MaterialAttribute(31763,1)]
        ChiseledSandstone,
        [MaterialAttribute(6118,1)]
        CutSandStone,
        [MaterialAttribute(20979,1)]
        NNoteBlock,
        [MaterialAttribute(11064,1)]
        PoweredRail,
        [MaterialAttribute(13475,1)]
        DetectorRail,
        [MaterialAttribute(18127,1)]
        StickyPiston,
        [MaterialAttribute(9469,1)]
        Cobweb,
        [MaterialAttribute(6155,1)]
        Grass,
        [MaterialAttribute(15794,1)]
        Fern,
        [MaterialAttribute(22888,1)]
        DeadBush,
        [MaterialAttribute(23942,1)]
        Seagrass,
        [MaterialAttribute(19562,1)]
        SeaPickle,
        [MaterialAttribute(21130,1)]
        Piston,
        [MaterialAttribute(8624,1)]
        WhiteWool,
        [MaterialAttribute(23957,1)]
        OrangeWool,
        [MaterialAttribute(11853,1)]
        MagentaWool,
        [MaterialAttribute(21073,1)]
        LightBlueWool,
        [MaterialAttribute(29507,1)]
        YellowWool,
        [MaterialAttribute(10443,1)]
        LimeWool,
        [MaterialAttribute(7611,1)]
        PinkWool,
        [MaterialAttribute(27209,1)]
        GrayWool,
        [MaterialAttribute(22936,1)]
        LightGrayWool,
        [MaterialAttribute(12221,1)]
        CyanWool,
        [MaterialAttribute(11922,1)]
        PurpleWool,
        [MaterialAttribute(15738,1)]
        BlueWool,
        [MaterialAttribute(32638,1)]
        BrownWool,
        [MaterialAttribute(25085,1)]
        GreenWool,
        [MaterialAttribute(11621,1)]
        RedWool,
        [MaterialAttribute(16693,1)]
        BlackWool,
        [MaterialAttribute(30558,1)]
        Dandelion,
        [MaterialAttribute(12851,1)]
        Poppy,
        [MaterialAttribute(13432,1)]
        BlueOrchid,
        [MaterialAttribute(6871,1)]
        Allium,
        [MaterialAttribute(17608,1)]
        AzureBluet,
        [MaterialAttribute(16781,1)]
        RedTulip,
        [MaterialAttribute(26038,1)]
        OrangeTulip,
        [MaterialAttribute(31495,1)]
        WhiteTulip,
        [MaterialAttribute(27319,1)]
        PinkTulip,
        [MaterialAttribute(11709,1)]
        OxeyeDaisy,
        [MaterialAttribute(15405,1)]
        Cornflower,
        [MaterialAttribute(7185,1)]
        LilyOfTheValley,
        [MaterialAttribute(8619,1)]
        WhiteRose,
        [MaterialAttribute(9665,1)]
        BrownMushroom,
        [MaterialAttribute(19728,1)]
        RedMushRoom,
        [MaterialAttribute(26268,1)]
        CrimsonFungus,
        [MaterialAttribute(19799,1)]
        WarpedFungus,
        [MaterialAttribute(14064,1)]
        CrimsonRoots,
        [MaterialAttribute(13932,1)]
        WarpedRoots,
        [MaterialAttribute(10431,1)]
        NetherSprouts,
        [MaterialAttribute(29267,1)]
        WeepingVines,
        [MaterialAttribute(27283,1)]
        TwistingVines,
        [MaterialAttribute(7726,1)]
        SugarCane,
        [MaterialAttribute(21916,1)]
        Kelp,
        [MaterialAttribute(18728,1)]
        Bamboo,
        [MaterialAttribute(27392,1)]
        GoldBlock,
        [MaterialAttribute(24754,1)]
        IronBlock,
        [MaterialAttribute(12002,1)]
        OakSlab,
        [MaterialAttribute(28798,1)]
        SpruceSlab,
        [MaterialAttribute(13807,1)]
        BirchSlab,
        [MaterialAttribute(19117,1)]
        JungleSlab,
        [MaterialAttribute(23730,1)]
        AcaciaSlab,
        [MaterialAttribute(28852,1)]
        DarkOakSlab,
        [MaterialAttribute(4691,1)]
        CrimsonSlab,
        [MaterialAttribute(27150,1)]
        WarpedSlab,
        [MaterialAttribute(19838,1)]
        StoneSlab,
        [MaterialAttribute(24129,1)]
        SmoothStoneSlab,
        [MaterialAttribute(29830,1)]
        SandstoneSlab,
        [MaterialAttribute(30944,1)]
        CutSandstoneSlab,
        [MaterialAttribute(18658,1)]
        PerifiedOakSlab,
        [MaterialAttribute(6340,1)]
        CobblestoneSlab,
        [MaterialAttribute(26333,1)]
        BirckSlab,
        [MaterialAttribute(19676,1)]
        StoneBrickSlab,
        [MaterialAttribute(26586,1)]
        NetherBrickSlab,
        [MaterialAttribute(4423,1)]
        QuartzSlab,
        [MaterialAttribute(17550,1)]
        RedSandstoneSlab,
        [MaterialAttribute(7220,1)]
        CutRedSandstoneSlab,
        [MaterialAttribute(11487,1)]
        PurpurSlab,
        [MaterialAttribute(31323,1)]
        PrismarineSlab,
        [MaterialAttribute(25624,1)]
        PrismarineBrickSlab,
        [MaterialAttribute(7577,1)]
        DarkPrismarineSlab,
        [MaterialAttribute(14415,1)]
        SmoothQuartz,
        [MaterialAttribute(25180,1)]
        SmoothRedSandstone,
        [MaterialAttribute(30039,1)]
        SmoothSandstone,
        [MaterialAttribute(21910,1)]
        SmoothStone,
        [MaterialAttribute(14165,1)]
        Bricks,
        [MaterialAttribute(7896,1)]
        Tnt,
        [MaterialAttribute(10069,1)]
        Bookshelf,
        [MaterialAttribute(21900,1)]
        MossyCobblestone,
        [MaterialAttribute(32723,1)]
        Obsidian,
        [MaterialAttribute(6063,1)]
        Torch,
        [MaterialAttribute(24832,1)]
        EndRod,
        [MaterialAttribute(28243,1)]
        ChorusPlant,
        [MaterialAttribute(28542,1)]
        ChorusFlower,
        [MaterialAttribute(7538,1)]
        PurpurBlock,
        [MaterialAttribute(26718,1)]
        PurpurPillar,
        [MaterialAttribute(8921,1)]
        PurpurStairs,
        [MaterialAttribute(7018,1)]
        Spawner,
        [MaterialAttribute(5449,1)]
        OakStairs,
        [MaterialAttribute(22969,1)]
        Chest,
        [MaterialAttribute(9292,1)]
        DiamondOre,
        [MaterialAttribute(5944,1)]
        DiamondBlock,
        [MaterialAttribute(20706,1)]
        CraftingTable,
        [MaterialAttribute(31166,1)]
        Farmland,
        [MaterialAttribute(8133,1)]
        Furnace,
        [MaterialAttribute(23599,1)]
        Ladder,
        [MaterialAttribute(13285,1)]
        Rail,
        [MaterialAttribute(24715,1)]
        CobblestoneStairs,
        [MaterialAttribute(15319,1)]
        Lever,
        [MaterialAttribute(22591,1)]
        StonePressurePlate,
        [MaterialAttribute(20108,1)]
        OakPressurePlate,
        [MaterialAttribute(15932,1)]
        SprucePressurePlate,
        [MaterialAttribute(9664,1)]
        BirchPressurePlate,
        [MaterialAttribute(11376,1)]
        JunglePressurePlate,
        [MaterialAttribute(17586,1)]
        AcaciaPressurePlate,
        [MaterialAttribute(31375,1)]
        DarkOakPressurePlate,
        [MaterialAttribute(18316,1)]
        CrimsonPressurePlate,
        [MaterialAttribute(29516,1)]
        WarpedPressurePlate,
        [MaterialAttribute(32340,1)]
        PolishedBlackstonePressurePlate,
        [MaterialAttribute(10887,1)]
        RedstoneOre,
        [MaterialAttribute(22547,1)]
        RedstoneTorch,
        [MaterialAttribute(14146,1)]
        Snow,
        [MaterialAttribute(30428,1)]
        Ice,
        [MaterialAttribute(19913,1)]
        SnowBlock,
        [MaterialAttribute(12191,1)]
        Cactus,
        [MaterialAttribute(27880,1)]
        Clay,
        [MaterialAttribute(19264,1)]
        Jukebox,
        [MaterialAttribute(6442,1)]
        OakFence,
        [MaterialAttribute(25416,1)]
        SpruceFence,
        [MaterialAttribute(17347,1)]
        BirchFence,
        [MaterialAttribute(14358,1)]
        JungleFence,
        [MaterialAttribute(4569,1)]
        AcaciaFence,
        [MaterialAttribute(21767,1)]
        DarkOakFence,
        [MaterialAttribute(21075,1)]
        CrimsonFence,
        [MaterialAttribute(18438,1)]
        WarpedFence,
        [MaterialAttribute(19170,1)]
        Pumpkin,
        [MaterialAttribute(25833,1)]
        CarvedPumpkin,
        [MaterialAttribute(23425,1)]
        NetherRack,
        [MaterialAttribute(16841,1)]
        SoulSand,
        [MaterialAttribute(31140,1)]
        SoulSoil,
        [MaterialAttribute(28478,1)]
        Basalt,
        [MaterialAttribute(11659,1)]
        PolishedBasalt,
        [MaterialAttribute(14292,1)]
        SoulTorch,
        [MaterialAttribute(32713,1)]
        Glowstone,
        [MaterialAttribute(13758,1)]
        JackOLantern,
        [MaterialAttribute(16927,1)]
        OakTrapdoor,
        [MaterialAttribute(10289,1)]
        SpruceTrapdoor,
        [MaterialAttribute(32585,1)]
        BirchTrapdoor,
        [MaterialAttribute(8626,1)]
        JungleTrapdoor,
        [MaterialAttribute(18343,1)]
        AcaciaTrapdoor,
        [MaterialAttribute(10355,1)]
        DarkOakTrapdoor,
        [MaterialAttribute(25056,1)]
        CrimsonTrapdoor,
        [MaterialAttribute(7708,1)]
        WarpedTrapdoor,
        [MaterialAttribute(18440,1)]
        InfestedStone,
        [MaterialAttribute(4348,1)]
        InfestedCobblestone,
        [MaterialAttribute(19749,1)]
        InfestedStoneBricks,
        [MaterialAttribute(9850,1)]
        InfestedMossyStoneBricks,
        [MaterialAttribute(7476,1)]
        InfestedCrackedStoneBricks,
        [MaterialAttribute(4728,1)]
        InfestedChiseledStoneBricks,
        [MaterialAttribute(6962,1)]
        StoneBricks,
        [MaterialAttribute(16415,1)]
        MossyStoneBricks,
        [MaterialAttribute(27869,1)]
        CrackedStoneBricks,
        [MaterialAttribute(9087,1)]
        ChiseledStoneBricks,
        [MaterialAttribute(6291,1)]
        BrownMushroomBlock,
        [MaterialAttribute(20766,1)]
        RedMushroomBlock,
        [MaterialAttribute(16543,1)]
        MushroomStem,
        [MaterialAttribute(9378,1)]
        IronBars,
        [MaterialAttribute(28265,1)]
        Chain,
        [MaterialAttribute(5709,1)]
        GlassPane,
        [MaterialAttribute(25172,1)]
        Melon,
        [MaterialAttribute(14564,1)]
        Vine,
        [MaterialAttribute(16689,1)]
        OakFenceGate,
        [MaterialAttribute(26423,1)]
        SpruceFenceGate,
        [MaterialAttribute(6322,1)]
        BirchFenceGate,
        [MaterialAttribute(21360,1)]
        JungleFenceGate,
        [MaterialAttribute(14145,1)]
        AcaciaFenceGate,
        [MaterialAttribute(10679,1)]
        DarkOakFenceGate,
        [MaterialAttribute(15602,1)]
        CrimsonFenceGate,
        [MaterialAttribute(11115,1)]
        WarpedFenceGate,
        [MaterialAttribute(21534,1)]
        BrickStairs,
        [MaterialAttribute(27032,1)]
        StoneBrickStairs,
        [MaterialAttribute(9913,1)]
        Mycelium,
        [MaterialAttribute(19271,1)]
        LilyPad,
        [MaterialAttribute(27802,1)]
        NetherBricks,
        [MaterialAttribute(10888,1)]
        CrackedNetherBricks,
        [MaterialAttribute(21613,1)]
        ChiseledNetherBricks,
        [MaterialAttribute(5286,1)]
        NetherBrickFence,
        [MaterialAttribute(12085,1)]
        NetherBrickStairs,
        [MaterialAttribute(16255,1)]
        EnchantingTable,
        [MaterialAttribute(15480,1)]
        EndPortalFrame,
        [MaterialAttribute(29686,1)]
        EndStone,
        [MaterialAttribute(20314,1)]
        EndStoneBricks,
        [MaterialAttribute(29946,1)]
        DragonEgg,
        [MaterialAttribute(8217,1)]
        RedstoneLamp,
        [MaterialAttribute(18474,1)]
        SandstoneStairs,
        [MaterialAttribute(16630,1)]
        EmeraldOre,
        [MaterialAttribute(32349,1)]
        EnderChest,
        [MaterialAttribute(8130,1)]
        TripwireHook,
        [MaterialAttribute(9914,1)]
        EmeraldBlock,
        [MaterialAttribute(11192,1)]
        SpruceStairs,
        [MaterialAttribute(7657,1)]
        BirchStairs,
        [MaterialAttribute(20636,1)]
        JungleStairs,
        [MaterialAttribute(32442,1)]
        CrimsonStairs,
        [MaterialAttribute(17721,1)]
        WarpedStairs,
        [MaterialAttribute(4355,1)]
        CommandBlock,
        [MaterialAttribute(6608,1)]
        Beacon,
        [MaterialAttribute(12616,1)]
        CobblestoneWall,
        [MaterialAttribute(11536,1)]
        MossyCobblestoneWall,
        [MaterialAttribute(18995,1)]
        BrickWall,
        [MaterialAttribute(18184,1)]
        PrismarineWall,
        [MaterialAttribute(4753,1)]
        RedSandstoneWall,
        [MaterialAttribute(18259,1)]
        MossyStoneBrickWall,
        [MaterialAttribute(23279,1)]
        GraniteWall,
        [MaterialAttribute(29073,1)]
        StoneBrickWall,
        [MaterialAttribute(10398,1)]
        NetherBrickWall,
        [MaterialAttribute(14938,1)]
        AndesiteWall,
        [MaterialAttribute(4580,1)]
        RedNetherBrickWall,
        [MaterialAttribute(18470,1)]
        SandstoneWall,
        [MaterialAttribute(27225,1)]
        EndStoneBrickWall,
        [MaterialAttribute(17412,1)]
        DioriteWall,
        [MaterialAttribute(17327,1)]
        BlackstoneWall,
        [MaterialAttribute(15119,1)]
        PolishedBlackstoneWall,
        [MaterialAttribute(9540,1)]
        PolishedBlackstoneBrickWall,
        [MaterialAttribute(12279,1)]
        StoneButton,
        [MaterialAttribute(13510,1)]
        OakButton,
        [MaterialAttribute(23281,1)]
        SpruceButton,
        [MaterialAttribute(26934,1)]
        BirchButton,
        [MaterialAttribute(25317,1)]
        JungleButton,
        [MaterialAttribute(13993,1)]
        AcaciaButton,
        [MaterialAttribute(6214,1)]
        DarkOakButton,
        [MaterialAttribute(26799,1)]
        CrimsonButton,
        [MaterialAttribute(25264,1)]
        WarpedButton,
        [MaterialAttribute(20760,1)]
        PolishedBlackstoneButton,
        [MaterialAttribute(18718,1)]
        Anvil,
        [MaterialAttribute(10623,1)]
        ChippedAnvil,
        [MaterialAttribute(10274,1)]
        DamagedAnvil,
        [MaterialAttribute(18970,1)]
        TrappedChest,
        [MaterialAttribute(14875,1)]
        LightWeightedPressurePlate,
        [MaterialAttribute(16970,1)]
        HeavyWeightedPressurePlate,
        [MaterialAttribute(8864,1)]
        DaylightDetector,
        [MaterialAttribute(19496,1)]
        RedstoneBlock,
        [MaterialAttribute(4807,1)]
        NetherQuartzOre,
        [MaterialAttribute(31974,1)]
        Hopper,
        [MaterialAttribute(30964,1)]
        ChiseledQuartzBlock,
        [MaterialAttribute(11987,1)]
        QuartzBlock,
        [MaterialAttribute(23358,1)]
        QuartzBricks,
        [MaterialAttribute(16452,1)]
        QuartzPillar,
        [MaterialAttribute(24079,1)]
        QuartzStairs,
        [MaterialAttribute(5834,1)]
        ActivatorRail,
        [MaterialAttribute(31273,1)]
        Dropper,
        [MaterialAttribute(20975,1)]
        WhiteTerracotta,
        [MaterialAttribute(18684,1)]
        OrangeTerracotta,
        [MaterialAttribute(25900,1)]
        MagentaTerracotta,
        [MaterialAttribute(31779,1)]
        LightBlueTerracotta,
        [MaterialAttribute(32129,1)]
        YellowTerracotta,
        [MaterialAttribute(24013,1)]
        LimeTerracotta,
        [MaterialAttribute(23727,1)]
        PinkTerracotta,
        [MaterialAttribute(18004,1)]
        GrayTerracotta,
        [MaterialAttribute(26388,1)]
        LightGrayTerracotta,
        [MaterialAttribute(25940,1)]
        CyanTerracotta,
        [MaterialAttribute(10387,1)]
        PurpleTerracotta,
        [MaterialAttribute(5236,1)]
        BlueTerracotta,
        [MaterialAttribute(23664,1)]
        BrownTerracotta,
        [MaterialAttribute(4105,1)]
        GreenTerracotta,
        [MaterialAttribute(5086,1)]
        RedTerracotta,
        [MaterialAttribute(26691,1)]
        BlackTerracotta,
        [MaterialAttribute(26453,1)]
        Barrier,
        [MaterialAttribute(17095,1)]
        IronTrapdoor,
        [MaterialAttribute(17461,1)]
        HayBlock,
        [MaterialAttribute(15117,1)]
        WhiteCarpet,
        [MaterialAttribute(24752,1)]
        OrangeCarpet,
        [MaterialAttribute(6180,1)]
        MagentaCarpet,
        [MaterialAttribute(21194,1)]
        LightBlueCarpet,
        [MaterialAttribute(18149,1)]
        YellowCarpet,
        [MaterialAttribute(15443,1)]
        LimeCarpet,
        [MaterialAttribute(27381,1)]
        PinkCarpet,
        [MaterialAttribute(26991,1)]
        GrayCarpet,
        [MaterialAttribute(11317,1)]
        LightGrayCarpet,
        [MaterialAttribute(9742,1)]
        CyanCarpet,
        [MaterialAttribute(5574,1)]
        PurpleCarpet,
        [MaterialAttribute(13292,1)]
        BlueCarpet,
        [MaterialAttribute(23352,1)]
        BrownCarpet,
        [MaterialAttribute(7780,1)]
        GreenCarpet,
        [MaterialAttribute(5424,1)]
        RedCarpet,
        [MaterialAttribute(6056,1)]
        BlackCarpet,
        [MaterialAttribute(16544,1)]
        Terracotta,
        [MaterialAttribute(27968,1)]
        CoalBlock,
        [MaterialAttribute(28993,1)]
        PackedIce,
        [MaterialAttribute(17453,1)]
        AcaciaStairs,
        [MaterialAttribute(22921,1)]
        DarkOakStairs,
        [MaterialAttribute(31892,1)]
        SlimeBlock,
        [MaterialAttribute(8604,1)]
        GrassPath,
        [MaterialAttribute(7408,1)]
        Sunflower,
        [MaterialAttribute(22837,1)]
        Lilac,
        [MaterialAttribute(6080,1)]
        RoseBush,
        [MaterialAttribute(21155,1)]
        Peony,
        [MaterialAttribute(21559,1)]
        TallGrass,
        [MaterialAttribute(30177,1)]
        LargeFern,
        [MaterialAttribute(31190,1)]
        WhiteStainedGlass,
        [MaterialAttribute(25142,1)]
        OrangeStainedGlass,
        [MaterialAttribute(26814,1)]
        MagentaStainedGlass,
        [MaterialAttribute(17162,1)]
        LightBlueStainedGlass,
        [MaterialAttribute(12182,1)]
        YellowStainedGlass,
        [MaterialAttribute(24266,1)]
        LimeStainedGlass,
        [MaterialAttribute(16164,1)]
        PinkStainedGlass,
        [MaterialAttribute(29979,1)]
        GrayStainedGlass,
        [MaterialAttribute(5843,1)]
        LightGrayStainedGlass,
        [MaterialAttribute(30604,1)]
        CyanStainedGlass,
        [MaterialAttribute(21845,1)]
        PurpleStainedGlass,
        [MaterialAttribute(7107,1)]
        BlueStainedGlass,
        [MaterialAttribute(20945,1)]
        BrownStainedGlass,
        [MaterialAttribute(22503,1)]
        GreenStainedGlass,
        [MaterialAttribute(9717,1)]
        RedStainedGlass,
        [MaterialAttribute(13941,1)]
        BlackStainedGlass,
        [MaterialAttribute(10557,1)]
        WhiteStainedGlassPane,
        [MaterialAttribute(21089,1)]
        OrangeStainedGlassPane,
        [MaterialAttribute(14082,1)]
        MagentaStainedGlassPane,
        [MaterialAttribute(18721,1)]
        LightBlueStainedGlassPane,
        [MaterialAttribute(20298,1)]
        YellowStainedGlassPane,
        [MaterialAttribute(10610,1)]
        LimeStainedGlassPane,
        [MaterialAttribute(24637,1)]
        PinkStainedGlassPane,
        [MaterialAttribute(25272,1)]
        GrayStainedGlassPane,
        [MaterialAttribute(19008,1)]
        LightGrayStainedGlassPane,
        [MaterialAttribute(11784,1)]
        CyanStainedGlassPane,
        [MaterialAttribute(10948,1)]
        PurpleStainedGlassPane,
        [MaterialAttribute(28484,1)]
        BlueStainedGlassPane,
        [MaterialAttribute(17557,1)]
        BrownStainedGlassPane,
        [MaterialAttribute(4767,1)]
        GreenStainedGlassPane,
        [MaterialAttribute(8630,1)]
        RedStainedGlassPane,
        [MaterialAttribute(13201,1)]
        BlackStainedGlassPane,
        [MaterialAttribute(7539,1)]
        Prismarine,
        [MaterialAttribute(29118,1)]
        PrismarineBricks,
        [MaterialAttribute(19940,1)]
        DarkPrismarine,
        
        
        [MaterialAttribute(9)]
        StationaryWater,
        [MaterialAttribute(11)]
        StationaryLava,
    }

    internal class MaterialAttribute : System.Attribute
    {
        public readonly int Id;
        public readonly int OldId;
        
        public readonly int MaxStack;
        public readonly short Durability;

        public readonly byte SubId;

        public MaterialAttribute(int id, int oldId, byte subId, int stack, short durability)
        {
            Id = id;
            OldId = oldId;
            SubId = subId;
            MaxStack = stack;
            Durability = durability;
        }
        public MaterialAttribute(int id, int oldId, byte subId, int stack) : this(id, oldId, subId, stack, 0) {}
        public MaterialAttribute(int id, int oldId, byte subId) : this(id, oldId, subId, 64, 0) {}
        public MaterialAttribute(int id, int oldId) : this(id, oldId, 0, 64, 0) {}

        public MaterialAttribute(int id) : this(id, id, 0, 64, 0) {}
    }

    public static class MaterialExtensions
    {
        public static int GetId(this Material m)
        {
            MaterialAttribute[] attributes =
                (MaterialAttribute[]) m.GetType().GetField(m.ToString())!.GetCustomAttributes(typeof(MaterialAttribute), false);
            if (attributes.Length > 0)
                return attributes[0].Id;

            return -1;
        }
        
        public static int GetOldId(this Material m)
        {
            MaterialAttribute[] attributes =
                (MaterialAttribute[]) m.GetType().GetField(m.ToString())!.GetCustomAttributes(typeof(MaterialAttribute),
                    false);
            if (attributes.Length > 0)
                return attributes[0].OldId;

            return -1;
        }
        
        public static int GetOldSubId(this Material m)
        {
            MaterialAttribute[] attributes =
                (MaterialAttribute[]) m.GetType().GetField(m.ToString())!.GetCustomAttributes(typeof(MaterialAttribute),
                    false);
            if (attributes.Length > 0)
                return attributes[0].SubId;

            return -1;
        }
        
        public static int GetMaxStack(this Material m)
        {
            MaterialAttribute[] attributes =
                (MaterialAttribute[]) m.GetType().GetField(m.ToString())!.GetCustomAttributes(typeof(MaterialAttribute),
                    false);
            if (attributes.Length > 0)
                return attributes[0].MaxStack;

            return -1;
        }
        
        public static int GetDurability(this Material m)
        {
            MaterialAttribute[] attributes =
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
            }

            return false;
        }
    }
}