using System.Text;

namespace NiaBukkit.API.Util
{
    public enum Material
    {
        [MaterialAttribute(0, 0)]
        Air,
        [MaterialAttribute(1)]
        Stone,
        [MaterialAttribute(1, 1)]
        Granite,
        [MaterialAttribute(1, 2)]
        PolishedGranite,
        [MaterialAttribute(1, 3)]
        Diorite,
        [MaterialAttribute(1, 4)]
        PolishedDiorite,
        [MaterialAttribute(1, 5)]
        Andesite,
        [MaterialAttribute(1, 6)]
        PolishedAndesite,
        [MaterialAttribute(2)]
        GrassBlock,
        [MaterialAttribute(3)]
        Dirt,
        [MaterialAttribute(3, 1)]
        CoarseDirt,
        [MaterialAttribute(3, 2)]
        Podzol,
        
        //TODO : WHAT?
        [MaterialAttribute(18139)]
        CrimsonNylium,
        [MaterialAttribute(26396)]
        WarpedNylium,
        
        [MaterialAttribute(4)]
        Cobblestone,
        [MaterialAttribute(5)]
        OakPlanks,
        [MaterialAttribute(5, 1)]
        SprucePlanks,
        [MaterialAttribute(5, 2)]
        BirchPlanks,
        [MaterialAttribute(5, 3)]
        JunglePlanks,
        [MaterialAttribute(5, 4)]
        AcaciaPlanks,
        [MaterialAttribute(5, 5)]
        DarkOakPlanks,
        [MaterialAttribute( 5)]
        CrimsonPlanks,
        [MaterialAttribute(5)]
        WarpedPlanks,
        [MaterialAttribute(6)]
        OakSapling,
        [MaterialAttribute(6, 1)]
        SpruceSapling,
        [MaterialAttribute(6, 2)]
        BirchSapling,
        [MaterialAttribute(6, 3)]
        JungleSapling,
        [MaterialAttribute(6, 4)]
        AcaciaSapling,
        [MaterialAttribute(6, 5)]
        DarkOakSapling,
        [MaterialAttribute(7)]
        Bedrock,
        [MaterialAttribute(12)]
        Sand,
        [MaterialAttribute(12, 1)]
        RedSand,
        [MaterialAttribute(13)]
        Gravel,
        [MaterialAttribute(14)]
        GoldOre,
        [MaterialAttribute(15)]
        IronOre,
        [MaterialAttribute(16)]
        CoalOre,
        
        //TODO : WHAT?
        [MaterialAttribute(14)]
        NetherGoldOre,
        
        [MaterialAttribute(17)]
        OakLog,
        [MaterialAttribute(17, 1)]
        SpruceLog,
        [MaterialAttribute(17, 2)]
        BirchLog,
        [MaterialAttribute(17, 3)]
        JungleLog,
        [MaterialAttribute(162)]
        AcaciaLog,
        [MaterialAttribute(162, 1)]
        DarkOakLog,
        
        //TODO : WHAT?
        [MaterialAttribute(17)]
        CrimsonStem,
        [MaterialAttribute(17)]
        WarpedStem,
        [MaterialAttribute(17)]
        StrippedOakLog,
        [MaterialAttribute(17, 1)]
        StrippedSpruceLog,
        [MaterialAttribute(17, 2)]
        StrippedBirchLog,
        [MaterialAttribute(17, 3)]
        StrippedJungleLog,
        [MaterialAttribute(162)]
        StrippedAcaciaLog,
        [MaterialAttribute(162, 1)]
        StrippedDarkOakLog,
        [MaterialAttribute(17)]
        StrippedCrimsonStem,
        [MaterialAttribute(17)]
        StrippedWarpedStem,
        [MaterialAttribute(17)]
        StrippedOakWood,
        [MaterialAttribute(17, 1)]
        StrippedSpruceWood,
        [MaterialAttribute(17, 2)]
        StrippedBirchWood,
        [MaterialAttribute(17, 3)]
        StrippedJungleWood,
        [MaterialAttribute(162)]
        StrippedAcaciaWood,
        [MaterialAttribute(162, 1)]
        StrippedDarkOakWood,
        [MaterialAttribute(17)]
        StrippedCrimsonHyphae,
        [MaterialAttribute(17)]
        StrippedWarpedHyphae,
        [MaterialAttribute(17)]
        OakWood,
        [MaterialAttribute(17, 1)]
        SpruceWood,
        [MaterialAttribute(17, 2)]
        BirchWood,
        [MaterialAttribute(17, 3)]
        JungleWood,
        [MaterialAttribute(162)]
        AcaciaWood,
        [MaterialAttribute(162, 1)]
        DarkOakWood,
        [MaterialAttribute(17)]
        CrimsonHyphae,
        [MaterialAttribute(17)]
        WarpedHyphae,
        
        [MaterialAttribute(18)]
        OakLeaves,
        [MaterialAttribute(18, 1)]
        SpruceLeaves,
        [MaterialAttribute(18, 2)]
        BirchLeaves,
        [MaterialAttribute(18, 3)]
        JungleLeaves,
        [MaterialAttribute(161)]
        AcaciaLeaves,
        [MaterialAttribute(161, 1)]
        DarkOakLeaves,
        [MaterialAttribute(19)]
        Sponge,
        [MaterialAttribute(19, 1)]
        WetSponge,
        [MaterialAttribute(20)]
        Glass,
        [MaterialAttribute(21)]
        LapisOre,
        [MaterialAttribute(22)]
        LapisBlock,
        [MaterialAttribute(23)]
        Dispenser,
        [MaterialAttribute(24)]
        Sandstone,
        [MaterialAttribute(24, 1)]
        ChiseledSandstone,
        [MaterialAttribute(24, 2)]
        SmoothSandstone,
        
        //TODO: What?
        [MaterialAttribute(24, 2)]
        CutSandstone,
        
        [MaterialAttribute(25)]
        NoteBlock,
        [MaterialAttribute(26)]
        Bed,
        [MaterialAttribute(27)]
        PoweredRail,
        [MaterialAttribute(28)]
        DetectorRail,
        [MaterialAttribute(29)]
        StickyPiston,
        [MaterialAttribute(30)]
        Cobweb,
        [MaterialAttribute(31, 1)]
        Grass,
        [MaterialAttribute(31, 2)]
        Fern,
        [MaterialAttribute(32)]
        DeadBush,
        
        //TODO: WHAT?
        [MaterialAttribute(31)]
        Seagrass,
        [MaterialAttribute(31, 2)]
        SeaPickle,
        
        [MaterialAttribute(33)]
        Piston,
        [MaterialAttribute(35)]
        WhiteWool,
        [MaterialAttribute(35, 1)]
        OrangeWool,
        [MaterialAttribute(35, 2)]
        MagentaWool,
        [MaterialAttribute(35, 3)]
        LightBlueWool,
        [MaterialAttribute(35, 4)]
        YellowWool,
        [MaterialAttribute(35, 5)]
        LimeWool,
        [MaterialAttribute(35, 6)]
        PinkWool,
        [MaterialAttribute(35, 7)]
        GrayWool,
        [MaterialAttribute(35, 8)]
        LightGrayWool,
        [MaterialAttribute(35, 9)]
        CyanWool,
        [MaterialAttribute(35, 10)]
        PurpleWool,
        [MaterialAttribute(35, 11)]
        BlueWool,
        [MaterialAttribute(35, 12)]
        BrownWool,
        [MaterialAttribute(35, 13)]
        GreenWool,
        [MaterialAttribute(35, 14)]
        RedWool,
        [MaterialAttribute(35, 15)]
        BlackWool,
        [MaterialAttribute(37)]
        Dandelion,
        [MaterialAttribute(38)]
        Poppy,
        [MaterialAttribute(38, 1)]
        BlueOrchid,
        [MaterialAttribute(38, 2)]
        Allium,
        [MaterialAttribute(38, 3)]
        AzureBluet,
        [MaterialAttribute(38, 4)]
        RedTulip,
        [MaterialAttribute(38, 5)]
        OrangeTulip,
        [MaterialAttribute(38, 6)]
        WhiteTulip,
        [MaterialAttribute(38, 7)]
        PinkTulip,
        [MaterialAttribute(38, 8)]
        OxeyeDaisy,
        
        //TODO: WHAT?
        [MaterialAttribute(38, 1)]
        Cornflower,
        [MaterialAttribute( 38, 8)]
        LilyOfTheValley,
        [MaterialAttribute(38)]
        WitherRose,
        
        [MaterialAttribute(39)]
        BrownMushroom,
        [MaterialAttribute(40)]
        RedMushRoom,
        
        //TODO: WHAT?
        [MaterialAttribute( 38)]
        CrimsonFungus,
        [MaterialAttribute( 38, 3)]
        WarpedFungus,
        [MaterialAttribute( 31, 1)]
        CrimsonRoots,
        [MaterialAttribute(31, 1)]
        WarpedRoots,
        [MaterialAttribute( 31, 1)]
        NetherSprouts,
        [MaterialAttribute( 106)]
        WeepingVines,
        [MaterialAttribute(106)]
        TwistingVines,
        [MaterialAttribute(83)]
        SugarCane,
        
        //TODO: What
        [MaterialAttribute( 338)]
        Kelp,
        [MaterialAttribute( 338)]
        Bamboo,
        
        [MaterialAttribute( 41)]
        GoldBlock,
        [MaterialAttribute(42)]
        IronBlock,
        [MaterialAttribute(126)]
        OakSlab,
        [MaterialAttribute(126, 1)]
        SpruceSlab,
        [MaterialAttribute(126, 2)]
        BirchSlab,
        [MaterialAttribute(126, 3)]
        JungleSlab,
        [MaterialAttribute(126, 4)]
        AcaciaSlab,
        [MaterialAttribute(126, 5)]
        DarkOakSlab,
        
        //TODO: What?
        [MaterialAttribute(126)]
        CrimsonSlab,
        [MaterialAttribute(126)]
        WarpedSlab,
        [MaterialAttribute(44)]
        StoneSlab,
        [MaterialAttribute(44)]
        SmoothStoneSlab,
        
        [MaterialAttribute(44, 1)]
        SandstoneSlab,
        
        //TODO: What?
        [MaterialAttribute( 44, 1)]
        CutSandstoneSlab,
        [MaterialAttribute( 126)]
        PetrifiedOakSlab,
        
        [MaterialAttribute(44, 3)]
        CobblestoneSlab,
        [MaterialAttribute(44, 4)]
        BrickSlab,
        [MaterialAttribute(44, 5)]
        StoneBrickSlab,
        [MaterialAttribute(44, 6)]
        NetherBrickSlab,
        [MaterialAttribute(44, 7)]
        QuartzSlab,
        [MaterialAttribute(182)]
        RedSandstoneSlab,
        [MaterialAttribute(205)]
        PurpurSlab,
        
        //TODO: What?
        [MaterialAttribute(44, 3)]
        PrismarineSlab,
        [MaterialAttribute(44, 3)]
        PrismarineBrickSlab,
        [MaterialAttribute(44, 3)]
        DarkPrismarineSlab,
        [MaterialAttribute(182)]
        CutRedSandstoneSlab,
        [MaterialAttribute(182)]
        SmoothRedSandstoneSlab,
        
        [MaterialAttribute(155)]
        SmoothQuartz,
        [MaterialAttribute(179, 2)]
        SmoothRedSandstone,
        
        //TODO: What?
        [MaterialAttribute(1)]
        SmoothStone,
        
        [MaterialAttribute(45)]
        Bricks,
        [MaterialAttribute(46)]
        Tnt,
        [MaterialAttribute(47)]
        Bookshelf,
        [MaterialAttribute(48)]
        MossyCobblestone,
        [MaterialAttribute(49)]
        Obsidian,
        [MaterialAttribute(50, 5)]
        Torch,
        [MaterialAttribute(198)]
        EndRod,
        
        //TODO: What?
        [MaterialAttribute(199)]
        ChorusPlant,
        [MaterialAttribute(200)]
        ChorusFlower,
        
        [MaterialAttribute(201)]
        PurpurBlock,
        [MaterialAttribute(202)]
        PurpurPillar,
        [MaterialAttribute(203)]
        PurpurStairs,
        [MaterialAttribute(52)]
        Spawner,
        [MaterialAttribute(53)]
        OakStairs,
        [MaterialAttribute(54)]
        Chest,
        [MaterialAttribute(56)]
        DiamondOre,
        [MaterialAttribute(57)]
        DiamondBlock,
        [MaterialAttribute(58)]
        CraftingTable,
        [MaterialAttribute( 60)]
        Farmland,
        [MaterialAttribute(61)]
        Furnace,
        [MaterialAttribute(65)]
        Ladder,
        [MaterialAttribute(66)]
        Rail,
        [MaterialAttribute(67)]
        CobblestoneStairs,
        [MaterialAttribute(69)]
        Lever,
        [MaterialAttribute(70)]
        StonePressurePlate,
        [MaterialAttribute(72)]
        OakPressurePlate,
        [MaterialAttribute(72)]
        SprucePressurePlate,
        [MaterialAttribute(72)]
        BirchPressurePlate,
        [MaterialAttribute(72)]
        JunglePressurePlate,
        [MaterialAttribute(72)]
        AcaciaPressurePlate,
        [MaterialAttribute(72)]
        DarkOakPressurePlate,
        
        //TODO: What?
        [MaterialAttribute(72)]
        CrimsonPressurePlate,
        [MaterialAttribute(72)]
        WarpedPressurePlate,
        [MaterialAttribute(70)]
        PolishedBlackstonePressurePlate,
        
        [MaterialAttribute(73)]
        RedstoneOre,
        [MaterialAttribute(76)]
        RedstoneTorch,
        [MaterialAttribute(78)]
        Snow,
        [MaterialAttribute(79)]
        Ice,
        [MaterialAttribute( 80)]
        SnowBlock,
        [MaterialAttribute(81)]
        Cactus,
        [MaterialAttribute(82)]
        Clay,
        [MaterialAttribute(84)]
        Jukebox,
        [MaterialAttribute(85)]
        OakFence,
        [MaterialAttribute(188)]
        SpruceFence,
        [MaterialAttribute(189)]
        BirchFence,
        [MaterialAttribute(190)]
        JungleFence,
        [MaterialAttribute(192)]
        AcaciaFence,
        [MaterialAttribute(191)]
        DarkOakFence,
        
        //TODO: What?
        [MaterialAttribute(85)]
        CrimsonFence,
        [MaterialAttribute(85)]
        WarpedFence,
        [MaterialAttribute(86)]
        Pumpkin,
        [MaterialAttribute(86)]
        CarvedPumpkin,
        
        [MaterialAttribute(87)]
        NetherRack,
        [MaterialAttribute(88)]
        SoulSand,
        
        //TODO: What?
        [MaterialAttribute(88)]
        SoulSoil,
        [MaterialAttribute(1)]
        Basalt,
        [MaterialAttribute(1, 6)]
        PolishedBasalt,
        [MaterialAttribute(50)]
        SoulTorch,
        
        [MaterialAttribute(89)]
        Glowstone,
        [MaterialAttribute(91)]
        JackOLantern,
        [MaterialAttribute(96)]
        OakTrapdoor,
        
        //TODO: What?
        [MaterialAttribute(96)]
        SpruceTrapdoor,
        [MaterialAttribute(96)]
        BirchTrapdoor,
        [MaterialAttribute(96)]
        JungleTrapdoor,
        [MaterialAttribute(96)]
        AcaciaTrapdoor,
        [MaterialAttribute(96)]
        DarkOakTrapdoor,
        [MaterialAttribute(96)]
        CrimsonTrapdoor,
        [MaterialAttribute(7708,96)]
        WarpedTrapdoor,
        
        [MaterialAttribute(97)]
        InfestedStone,
        [MaterialAttribute(97, 1)]
        InfestedCobblestone,
        [MaterialAttribute(97, 2)]
        InfestedStoneBricks,
        [MaterialAttribute(97, 3)]
        InfestedMossyStoneBricks,
        [MaterialAttribute(97, 4)]
        InfestedCrackedStoneBricks,
        [MaterialAttribute(97, 5)]
        InfestedChiseledStoneBricks,
        [MaterialAttribute(98)]
        StoneBricks,
        [MaterialAttribute(98, 1)]
        MossyStoneBricks,
        [MaterialAttribute(98, 2)]
        CrackedStoneBricks,
        [MaterialAttribute(98, 3)]
        ChiseledStoneBricks,
        [MaterialAttribute(99)]
        BrownMushroomBlock,
        [MaterialAttribute(100)]
        RedMushroomBlock,
        [MaterialAttribute(99, 10)]
        MushroomStem,
        [MaterialAttribute(101)]
        IronBars,
        
        //TODO: What?
        [MaterialAttribute(28265,101)]
        Chain,
        
        [MaterialAttribute(102)]
        GlassPane,
        [MaterialAttribute(103)]
        Melon,
        [MaterialAttribute(106)]
        Vine,
        [MaterialAttribute(107)]
        OakFenceGate,
        [MaterialAttribute(183)]
        SpruceFenceGate,
        [MaterialAttribute(184)]
        BirchFenceGate,
        [MaterialAttribute(185)]
        JungleFenceGate,
        [MaterialAttribute(187)]
        AcaciaFenceGate,
        [MaterialAttribute(186)]
        DarkOakFenceGate,
        
        //TODO: What?
        [MaterialAttribute(107)]
        CrimsonFenceGate,
        [MaterialAttribute(107)]
        WarpedFenceGate,
        
        [MaterialAttribute(108)]
        BrickStairs,
        [MaterialAttribute(109)]
        StoneBrickStairs,
        [MaterialAttribute(110)]
        Mycelium,
        [MaterialAttribute(111)]
        LilyPad,
        [MaterialAttribute(112)]
        NetherBricks,
        
        //TODO: What?
        [MaterialAttribute(112)]
        CrackedNetherBricks,
        [MaterialAttribute(112)]
        ChiseledNetherBricks,
        
        [MaterialAttribute(113)]
        NetherBrickFence,
        [MaterialAttribute(114)]
        NetherBrickStairs,
        [MaterialAttribute(115)]
        NetherWart,
        [MaterialAttribute(116)]
        EnchantingTable,
        [MaterialAttribute(117)]
        BrewingStand,
        [MaterialAttribute(118)]
        Cauldron,
        [MaterialAttribute(120)]
        EndPortalFrame,
        [MaterialAttribute(121)]
        EndStone,
        
        //TODO: What?
        [MaterialAttribute(206)]
        EndStoneBricks,
        
        [MaterialAttribute(122)]
        DragonEgg,
        [MaterialAttribute(123)]
        RedstoneLamp,
        [MaterialAttribute(128)]
        SandstoneStairs,
        [MaterialAttribute(129)]
        EmeraldOre,
        [MaterialAttribute(130)]
        EnderChest,
        [MaterialAttribute(131)]
        TripwireHook,
        [MaterialAttribute(133)]
        EmeraldBlock,
        [MaterialAttribute(134)]
        SpruceStairs,
        [MaterialAttribute(135)]
        BirchStairs,
        [MaterialAttribute(136)]
        JungleStairs,
        
        //TODO: What?
        [MaterialAttribute(32442,53)]
        CrimsonStairs,
        [MaterialAttribute(17721,53)]
        WarpedStairs,
        
        [MaterialAttribute(137)]
        CommandBlock,
        [MaterialAttribute(138)]
        Beacon,
        [MaterialAttribute(139)]
        CobblestoneWall,
        [MaterialAttribute(139, 1)]
        MossyCobblestoneWall,
        
        //TODO: What?
        [MaterialAttribute(139)]
        BrickWall,
        [MaterialAttribute(139)]
        PrismarineWall,
        [MaterialAttribute(139)]
        RedSandstoneWall,
        [MaterialAttribute(139)]
        MossyStoneBrickWall,
        [MaterialAttribute(139)]
        GraniteWall,
        [MaterialAttribute(139)]
        StoneBrickWall,
        [MaterialAttribute(139)]
        NetherBrickWall,
        [MaterialAttribute(139)]
        AndesiteWall,
        [MaterialAttribute(139)]
        RedNetherBrickWall,
        [MaterialAttribute(139)]
        SandstoneWall,
        [MaterialAttribute(139)]
        EndStoneBrickWall,
        [MaterialAttribute(139)]
        DioriteWall,
        [MaterialAttribute(139)]
        BlackstoneWall,
        [MaterialAttribute(139)]
        PolishedBlackstoneWall,
        [MaterialAttribute(139)]
        PolishedBlackstoneBrickWall,
        
        [MaterialAttribute(77)]
        StoneButton,
        [MaterialAttribute(143)]
        OakButton,
        
        //TODO: What?
        [MaterialAttribute(143)]
        SpruceButton,
        [MaterialAttribute(143)]
        BirchButton,
        [MaterialAttribute(143)]
        JungleButton,
        [MaterialAttribute(143)]
        AcaciaButton,
        [MaterialAttribute(143)]
        DarkOakButton,
        [MaterialAttribute(143)]
        CrimsonButton,
        [MaterialAttribute(143)]
        WarpedButton,
        [MaterialAttribute(77)]
        PolishedBlackstoneButton,
        
        
        [MaterialAttribute(144)]
        SkeletonSkull,
        [MaterialAttribute(144, 1)]
        WitherSkeletonSkull,
        [MaterialAttribute(144, 2)]
        PlayerHead,
        [MaterialAttribute(144, 3)]
        ZombieHead,
        [MaterialAttribute(144, 4)]
        CreeperHead,
        [MaterialAttribute(144, 5)]
        DragonHead,
        [MaterialAttribute(145)]
        Anvil,
        [MaterialAttribute(145, 1)]
        ChippedAnvil,
        [MaterialAttribute(145, 2)]
        DamagedAnvil,
        [MaterialAttribute(146)]
        TrappedChest,
        [MaterialAttribute(147)]
        LightWeightedPressurePlate,
        [MaterialAttribute(148)]
        HeavyWeightedPressurePlate,
        [MaterialAttribute(151)]
        DaylightDetector,
        [MaterialAttribute(178)]
        DaylightDetectorInverted,
        [MaterialAttribute(152)]
        RedstoneBlock,
        [MaterialAttribute(153)]
        NetherQuartzOre,
        [MaterialAttribute(154)]
        Hopper,
        [MaterialAttribute(155, 1)]
        ChiseledQuartzBlock,
        [MaterialAttribute(155)]
        QuartzBlock,
        
        //TODO: What?
        [MaterialAttribute(155)]
        QuartzBricks,
        
        [MaterialAttribute(155, 2)]
        QuartzPillar,
        [MaterialAttribute(156)]
        QuartzStairs,
        [MaterialAttribute(157)]
        ActivatorRail,
        [MaterialAttribute(158)]
        Dropper,
        [MaterialAttribute(159)]
        WhiteTerracotta,
        [MaterialAttribute(159, 1)]
        OrangeTerracotta,
        [MaterialAttribute(159, 2)]
        MagentaTerracotta,
        [MaterialAttribute(159, 3)]
        LightBlueTerracotta,
        [MaterialAttribute(159, 4)]
        YellowTerracotta,
        [MaterialAttribute(159, 5)]
        LimeTerracotta,
        [MaterialAttribute(159, 6)]
        PinkTerracotta,
        [MaterialAttribute(159, 7)]
        GrayTerracotta,
        [MaterialAttribute(159, 8)]
        LightGrayTerracotta,
        [MaterialAttribute(159, 9)]
        CyanTerracotta,
        [MaterialAttribute(159, 10)]
        PurpleTerracotta,
        [MaterialAttribute(159, 11)]
        BlueTerracotta,
        [MaterialAttribute(159, 12)]
        BrownTerracotta,
        [MaterialAttribute(159, 13)]
        GreenTerracotta,
        [MaterialAttribute(159, 14)]
        RedTerracotta,
        [MaterialAttribute(159, 15)]
        BlackTerracotta,
        [MaterialAttribute(166)]
        Barrier,
        [MaterialAttribute(167)]
        IronTrapdoor,
        [MaterialAttribute(170)]
        HayBlock,
        [MaterialAttribute(171)]
        WhiteCarpet,
        [MaterialAttribute(171, 1)]
        OrangeCarpet,
        [MaterialAttribute(171, 2)]
        MagentaCarpet,
        [MaterialAttribute(171, 3)]
        LightBlueCarpet,
        [MaterialAttribute(171, 4)]
        YellowCarpet,
        [MaterialAttribute(171, 5)]
        LimeCarpet,
        [MaterialAttribute(171, 6)]
        PinkCarpet,
        [MaterialAttribute(171, 7)]
        GrayCarpet,
        [MaterialAttribute(171, 8)]
        LightGrayCarpet,
        [MaterialAttribute(171, 9)]
        CyanCarpet,
        [MaterialAttribute(171, 10)]
        PurpleCarpet,
        [MaterialAttribute(171, 11)]
        BlueCarpet,
        [MaterialAttribute(171, 12)]
        BrownCarpet,
        [MaterialAttribute(171, 13)]
        GreenCarpet,
        [MaterialAttribute(171, 14)]
        RedCarpet,
        [MaterialAttribute(171, 15)]
        BlackCarpet,
        [MaterialAttribute(172)]
        Terracotta,
        [MaterialAttribute(173)]
        CoalBlock,
        [MaterialAttribute(174)]
        PackedIce,
        [MaterialAttribute(163)]
        AcaciaStairs,
        [MaterialAttribute(164)]
        DarkOakStairs,
        [MaterialAttribute(165)]
        SlimeBlock,
        [MaterialAttribute(208)]
        GrassPath,
        [MaterialAttribute(7408,175)]
        Sunflower,
        [MaterialAttribute(175, 1)]
        Lilac,
        [MaterialAttribute(175, 4)]
        RoseBush,
        [MaterialAttribute(175, 5)]
        Peony,
        [MaterialAttribute(175, 2)]
        TallGrass,
        [MaterialAttribute(175, 3)]
        LargeFern,
        [MaterialAttribute(95)]
        WhiteStainedGlass,
        [MaterialAttribute(95, 1)]
        OrangeStainedGlass,
        [MaterialAttribute(95, 2)]
        MagentaStainedGlass,
        [MaterialAttribute(95, 3)]
        LightBlueStainedGlass,
        [MaterialAttribute(95, 4)]
        YellowStainedGlass,
        [MaterialAttribute(95, 5)]
        LimeStainedGlass,
        [MaterialAttribute(95, 6)]
        PinkStainedGlass,
        [MaterialAttribute(95, 7)]
        GrayStainedGlass,
        [MaterialAttribute(95, 8)]
        LightGrayStainedGlass,
        [MaterialAttribute(95, 9)]
        CyanStainedGlass,
        [MaterialAttribute(95, 10)]
        PurpleStainedGlass,
        [MaterialAttribute(95, 11)]
        BlueStainedGlass,
        [MaterialAttribute(95, 12)]
        BrownStainedGlass,
        [MaterialAttribute(95, 13)]
        GreenStainedGlass,
        [MaterialAttribute(95, 14)]
        RedStainedGlass,
        [MaterialAttribute(95, 15)]
        BlackStainedGlass,
        [MaterialAttribute(160)]
        WhiteStainedGlassPane,
        [MaterialAttribute(160, 1)]
        OrangeStainedGlassPane,
        [MaterialAttribute(160, 2)]
        MagentaStainedGlassPane,
        [MaterialAttribute(160, 3)]
        LightBlueStainedGlassPane,
        [MaterialAttribute(160, 4)]
        YellowStainedGlassPane,
        [MaterialAttribute(160, 5)]
        LimeStainedGlassPane,
        [MaterialAttribute(160, 6)]
        PinkStainedGlassPane,
        [MaterialAttribute(160, 7)]
        GrayStainedGlassPane,
        [MaterialAttribute(160, 8)]
        LightGrayStainedGlassPane,
        [MaterialAttribute(160, 9)]
        CyanStainedGlassPane,
        [MaterialAttribute(160, 10)]
        PurpleStainedGlassPane,
        [MaterialAttribute(160, 11)]
        BlueStainedGlassPane,
        [MaterialAttribute(160, 12)]
        BrownStainedGlassPane,
        [MaterialAttribute(160, 13)]
        GreenStainedGlassPane,
        [MaterialAttribute(160, 14)]
        RedStainedGlassPane,
        [MaterialAttribute(160, 15)]
        BlackStainedGlassPane,
        [MaterialAttribute(168)]
        Prismarine,
        [MaterialAttribute(168, 1)]
        PrismarineBricks,
        [MaterialAttribute(168, 2)]
        DarkPrismarine,
        
        //TODO: What?
        [MaterialAttribute(67)]
        PrismarineStairs,
        [MaterialAttribute(67)]
        PrismarineBrickStairs,
        [MaterialAttribute(67)]
        DarkPrismarineStairs,
        [MaterialAttribute(169)]
        SeaLantern,
        [MaterialAttribute(179)]
        RedSandstone,
        [MaterialAttribute(179, 1)]
        ChiseledRedSandstone,
        
        //TODO: What?
        [MaterialAttribute(179)]
        CutRedSandstone,
        
        [MaterialAttribute(180)]
        RedSandstoneStairs,
        [MaterialAttribute(210)]
        RepeatingCommandBlock,
        [MaterialAttribute(211)]
        ChainCommandBlock,
        [MaterialAttribute(213)]
        MagmaBlock,
        [MaterialAttribute(214)]
        NetherWartBlock,
        
        //TODO: What?
        [MaterialAttribute(214)]
        WarpedWartBlock,
        
        [MaterialAttribute(215)]
        RedNetherBricks,
        [MaterialAttribute(216)]
        BoneBlock,
        [MaterialAttribute(217)]
        StructureVoid,
        [MaterialAttribute(218)]
        Observer,
        [MaterialAttribute(229)]
        ShulkerBox,
        [MaterialAttribute(219)]
        WhiteShulkerBox,
        [MaterialAttribute(220)]
        OrangeShulkerBox,
        [MaterialAttribute(221)]
        MagentaShulkerBox,
        [MaterialAttribute(222)]
        LightBlueShulkerBox,
        [MaterialAttribute(223)]
        YellowShulkerBox,
        [MaterialAttribute(224)]
        LimeShulkerBox,
        [MaterialAttribute(225)]
        PinkShulkerBox,
        [MaterialAttribute(226)]
        GrayShulkerBox,
        [MaterialAttribute(227)]
        LightGrayShulkerBox,
        [MaterialAttribute(228)]
        CyanShulkerBox,
        [MaterialAttribute(229)]
        PurpleShulkerBox,
        [MaterialAttribute(230)]
        BlueShulkerBox,
        [MaterialAttribute(231)]
        BrownShulkerBox,
        [MaterialAttribute(232)]
        GreenShulkerBox,
        [MaterialAttribute(233)]
        RedShulkerBox,
        [MaterialAttribute(234)]
        BlackShulkerBox,
        [MaterialAttribute(235)]
        WhiteGlazedTerracotta,
        [MaterialAttribute(236)]
        OrangeGlazedTerracotta,
        [MaterialAttribute(237)]
        MagentaGlazedTerracotta,
        [MaterialAttribute(238)]
        LightBlueGlazedTerracotta,
        [MaterialAttribute(239)]
        YellowGlazedTerracotta,
        [MaterialAttribute(240)]
        LimeGlazedTerracotta,
        [MaterialAttribute(241)]
        PinkGlazedTerracotta,
        [MaterialAttribute(242)]
        GrayGlazedTerracotta,
        [MaterialAttribute(243)]
        LightGrayGlazedTerracotta,
        [MaterialAttribute(244)]
        CyanGlazedTerracotta,
        [MaterialAttribute(245)]
        PurpleGlazedTerracotta,
        [MaterialAttribute(246)]
        BlueGlazedTerracotta,
        [MaterialAttribute(247)]
        BrownGlazedTerracotta,
        [MaterialAttribute(248)]
        GreenGlazedTerracotta,
        [MaterialAttribute(249)]
        RedGlazedTerracotta,
        [MaterialAttribute(250)]
        BlackGlazedTerracotta,
        [MaterialAttribute(251)]
        WhiteConcrete,
        [MaterialAttribute(251, 1)]
        OrangeConcrete,
        [MaterialAttribute(251, 2)]
        MagentaConcrete,
        [MaterialAttribute(251, 3)]
        LightBlueConcrete,
        [MaterialAttribute(251, 4)]
        YellowConcrete,
        [MaterialAttribute(251, 5)]
        LimeConcrete,
        [MaterialAttribute(251, 6)]
        PinkConcrete,
        [MaterialAttribute(251, 7)]
        GrayConcrete,
        [MaterialAttribute(251, 8)]
        LightGrayConcrete,
        [MaterialAttribute(251, 9)]
        CyanConcrete,
        [MaterialAttribute(251, 10)]
        PurpleConcrete,
        [MaterialAttribute(251, 11)]
        BlueConcrete,
        [MaterialAttribute(251, 12)]
        BrownConcrete,
        [MaterialAttribute(251, 13)]
        GreenConcrete,
        [MaterialAttribute(251, 14)]
        RedConcrete,
        [MaterialAttribute(251, 15)]
        BlackConcrete,
        [MaterialAttribute(252)]
        WhiteConcretePowder,
        [MaterialAttribute(252, 1)]
        OrangeConcretePowder,
        [MaterialAttribute(252, 2)]
        MagentaConcretePowder,
        [MaterialAttribute(252, 3)]
        LightBlueConcretePowder,
        [MaterialAttribute(252, 4)]
        YellowConcretePowder,
        [MaterialAttribute(252, 5)]
        LimeConcretePowder,
        [MaterialAttribute(252, 6)]
        PinkConcretePowder,
        [MaterialAttribute(252, 7)]
        GrayConcretePowder,
        [MaterialAttribute(252, 8)]
        LightGrayConcretePowder,
        [MaterialAttribute(252, 9)]
        CyanConcretePowder,
        [MaterialAttribute(252, 10)]
        PurpleConcretePowder,
        [MaterialAttribute(252, 11)]
        BlueConcretePowder,
        [MaterialAttribute(252, 12)]
        BrownConcretePowder,
        [MaterialAttribute(252, 13)]
        GreenConcretePowder,
        [MaterialAttribute(252, 14)]
        RedConcretePowder,
        [MaterialAttribute(252, 15)]
        BlackConcretePowder,
        
        //TODO: What?
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
        [MaterialAttribute(22449)]
        BlueIce,
        [MaterialAttribute(5148)]
        Conduit,
        [MaterialAttribute(29588)]
        PolishedGraniteStairs,
        [MaterialAttribute(17561)]
        SmoothRedSandstoneStairs,
        [MaterialAttribute(27578)]
        MossyStoneBrickStairs,
        [MaterialAttribute(4625)]
        PolishedDioriteStairs,
        [MaterialAttribute(67)]
        MossyCobblestoneStairs,
        [MaterialAttribute(67)]
        EndStoneBrickStairs,
        [MaterialAttribute(67)]
        StoneStairs,
        [MaterialAttribute(128)]
        SmoothSandstoneStairs,
        [MaterialAttribute(156)]
        SmoothQuartzStairs,
        [MaterialAttribute(67)]
        GraniteStairs,
        [MaterialAttribute(67)]
        AndesiteStairs,
        [MaterialAttribute(114)]
        RedNetherBrickStairs,
        [MaterialAttribute(67)]
        PolishedAndesiteStairs,
        [MaterialAttribute(67)]
        DioriteStairs,
        [MaterialAttribute(44, 3)]
        PolishedGraniteSlab,
        [MaterialAttribute(44, 5)]
        MossyStoneBrickSlab,
        [MaterialAttribute(44, 3)]
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
        
        [MaterialAttribute(71)]
        IronDoor,
        [MaterialAttribute(64)]
        OakDoor,
        [MaterialAttribute(193)]
        SpruceDoor,
        [MaterialAttribute(194)]
        BirchDoor,
        [MaterialAttribute(195)]
        JungleDoor,
        [MaterialAttribute(196)]
        AcaciaDoor,
        [MaterialAttribute(197)]
        DarkOakDoor,
        
        //TODO: What?
        [MaterialAttribute(324)]
        CrimsonDoor,
        [MaterialAttribute(324)]
        WarpedDoor,
        
        [MaterialAttribute(93)]
        Repeater,
        [MaterialAttribute(149)]
        Comparator,
        [MaterialAttribute(255)]
        StructureBlock,
        [MaterialAttribute(17398)]
        Jigsaw,
        [MaterialAttribute(30120)]
        TurtleHelmet,
        [MaterialAttribute(11914)]
        Scute,
        [MaterialAttribute(259)]
        FlintAndSteel,
        [MaterialAttribute(260)]
        Apple,
        [MaterialAttribute(261)]
        Bow,
        [MaterialAttribute(262)]
        Arrow,
        [MaterialAttribute(263)]
        Coal,
        [MaterialAttribute(263, 1)]
        Charcoal,
        [MaterialAttribute(264)]
        Diamond,
        [MaterialAttribute(265)]
        IronIngot,
        [MaterialAttribute(266)]
        GoldIngot,
        [MaterialAttribute(32457)]
        NetheriteIngot,
        [MaterialAttribute(29331)]
        NetheriteScrap,
        [MaterialAttribute(268)]
        WoodenSword,
        [MaterialAttribute(269)]
        WoodenShovel,
        [MaterialAttribute(270)]
        WoodenPickaxe,
        [MaterialAttribute(271)]
        WoodenAxe,
        [MaterialAttribute(290)]
        WoodenHoe,
        [MaterialAttribute(272)]
        StoneSword,
        [MaterialAttribute(273)]
        StoneShovel,
        [MaterialAttribute(274)]
        StonePickaxe,
        [MaterialAttribute(275)]
        StoneAxe,
        [MaterialAttribute(291)]
        StoneHoe,
        [MaterialAttribute(283)]
        GoldenSword,
        [MaterialAttribute(284)]
        GoldenShovel,
        [MaterialAttribute(285)]
        GoldenPickaxe,
        [MaterialAttribute(286)]
        GoldenAxe,
        [MaterialAttribute(294)]
        GoldenHoe,
        [MaterialAttribute(267)]
        IronSword,
        [MaterialAttribute(256)]
        IronShovel,
        [MaterialAttribute(257)]
        IronPickaxe,
        [MaterialAttribute(58)]
        IronAxe,
        [MaterialAttribute(292)]
        IronHoe,
        [MaterialAttribute(276)]
        DiamondSword,
        [MaterialAttribute(277)]
        DiamondShovel,
        [MaterialAttribute(278)]
        DiamondPickaxe,
        [MaterialAttribute(279)]
        DiamondAxe,
        [MaterialAttribute(293)]
        DiamondHoe,
        [MaterialAttribute(276)]
        NetheriteSword,
        [MaterialAttribute(277)]
        NetheriteShovel,
        [MaterialAttribute(278)]
        NetheritePickaxe,
        [MaterialAttribute(279)]
        NetheriteAxe,
        [MaterialAttribute(293)]
        NetheriteHoe,
        [MaterialAttribute(280)]
        Stick,
        [MaterialAttribute(281)]
        Bowl,
        [MaterialAttribute(282)]
        MushroomStew,
        [MaterialAttribute(287)]
        String,
        [MaterialAttribute(288)]
        Feather,
        [MaterialAttribute(289)]
        Gunpowder,
        [MaterialAttribute(295)]
        WheatSeeds,
        [MaterialAttribute(59)]
        Wheat,
        [MaterialAttribute(297)]
        Bread,
        [MaterialAttribute(298)]
        LeatherHelmet,
        [MaterialAttribute(299)]
        LeatherChestplate,
        [MaterialAttribute(300)]
        LeatherLeggings,
        [MaterialAttribute(301)]
        LeatherBoots,
        [MaterialAttribute(302)]
        ChainmailHelmet,
        [MaterialAttribute(303)]
        ChainmailChestplate,
        [MaterialAttribute(304)]
        ChainmailLeggings,
        [MaterialAttribute(305)]
        ChainmailBoots,
        [MaterialAttribute(306)]
        IronHelmet,
        [MaterialAttribute(307)]
        IronChestplate,
        [MaterialAttribute(308)]
        IronLeggings,
        [MaterialAttribute(309)]
        IronBoots,
        [MaterialAttribute(310)]
        DiamondHelmet,
        [MaterialAttribute(311)]
        DiamondChestplate,
        [MaterialAttribute(312)]
        DiamondLeggings,
        [MaterialAttribute(313)]
        DiamondBoots,
        [MaterialAttribute(314)]
        GoldenHelmet,
        [MaterialAttribute(315)]
        GoldenChestplate,
        [MaterialAttribute(316)]
        GoldenLeggings,
        [MaterialAttribute(317)]
        GoldenBoots,
        [MaterialAttribute(310)]
        NetheriteHelmet,
        [MaterialAttribute(311)]
        NetheriteChestplate,
        [MaterialAttribute(312)]
        NetheriteLeggings,
        [MaterialAttribute(313)]
        NetheriteBoots,
        [MaterialAttribute(318)]
        Flint,
        [MaterialAttribute(319)]
        Porkchop,
        [MaterialAttribute(320)]
        CookedPorkchop,
        [MaterialAttribute(321)]
        Painting,
        [MaterialAttribute(322)]
        GoldenApple,
        [MaterialAttribute(322, 1)]
        EnchantedGoldenApple,
        [MaterialAttribute(323)]
        OakSign,
        [MaterialAttribute(323)]
        SpruceSign,
        [MaterialAttribute(323)]
        BirchSign,
        [MaterialAttribute(323)]
        JungleSign,
        [MaterialAttribute(323)]
        AcaciaSign,
        [MaterialAttribute(323)]
        DarkOakSign,
        [MaterialAttribute(323)]
        CrimsonSign,
        [MaterialAttribute(323)]
        WarpedSign,
        [MaterialAttribute(325)]
        Bucket,
        [MaterialAttribute(326)]
        WaterBucket,
        [MaterialAttribute(327)]
        LavaBucket,
        [MaterialAttribute(328)]
        Minecart,
        [MaterialAttribute(329)]
        Saddle,
        [MaterialAttribute(331)]
        Redstone,
        [MaterialAttribute(332)]
        Snowball,
        [MaterialAttribute(333)]
        OakBoat,
        [MaterialAttribute(334)]
        Leather,
        [MaterialAttribute(335)]
        MilkBucket,
        [MaterialAttribute(326)]
        PufferfishBucket,
        [MaterialAttribute(326)]
        SalmonBucket,
        [MaterialAttribute(326)]
        CodBucket,
        [MaterialAttribute(326)]
        TropicalFishBucket,
        [MaterialAttribute(336)]
        Brick,
        [MaterialAttribute(337)]
        ClayBall,
        [MaterialAttribute(12966)]
        DriedKelpBlock,
        [MaterialAttribute(339)]
        Paper,
        [MaterialAttribute(340)]
        Book,
        [MaterialAttribute(341)]
        SlimeBall,
        [MaterialAttribute(342)]
        ChestMinecart,
        [MaterialAttribute(343)]
        FurnaceMinecart,
        [MaterialAttribute(344)]
        Egg,
        [MaterialAttribute(345)]
        Compass,
        [MaterialAttribute(346)]
        FishingRod,
        [MaterialAttribute(347)]
        Clock,
        [MaterialAttribute(348)]
        GlowstoneDust,
        [MaterialAttribute(349)]
        Cod,
        [MaterialAttribute(349, 1)]
        Salmon,
        [MaterialAttribute(349, 2)]
        TropicalFish,
        [MaterialAttribute(349, 3)]
        Pufferfish,
        [MaterialAttribute(350)]
        CookedCod,
        [MaterialAttribute(350, 1)]
        CookedSalmon,
        [MaterialAttribute(351)]
        InkSac,
        [MaterialAttribute(351, 3)]
        CocoaBeans,
        [MaterialAttribute(351, 4)]
        LapisLazuli,
        [MaterialAttribute(351, 15)]
        WhiteDye,
        [MaterialAttribute(351, 14)]
        OrangeDye,
        [MaterialAttribute(351, 13)]
        MagentaDye,
        [MaterialAttribute(351, 12)]
        LightBlueDye,
        [MaterialAttribute(351, 11)]
        YellowDye,
        [MaterialAttribute(351, 10)]
        LimeDye,
        [MaterialAttribute(351, 9)]
        PinkDye,
        [MaterialAttribute(351, 8)]
        GrayDye,
        [MaterialAttribute(351, 7)]
        LightGrayDye,
        [MaterialAttribute(351, 6)]
        CyanDye,
        [MaterialAttribute(351, 5)]
        PurpleDye,
        [MaterialAttribute(351, 4)]
        BlueDye,
        [MaterialAttribute(351, 3)]
        BrownDye,
        [MaterialAttribute(351, 2)]
        GreenDye,
        [MaterialAttribute(351, 1)]
        RedDye,
        [MaterialAttribute(351)]
        BlackDye,
        [MaterialAttribute(351, 15)]
        BoneMeal,
        [MaterialAttribute(352)]
        Bone,
        [MaterialAttribute(353)]
        Sugar,
        [MaterialAttribute(92)]
        Cake,
        [MaterialAttribute(26)]
        WhiteBed,
        [MaterialAttribute(26, 1)]
        OrangeBed,
        [MaterialAttribute(26, 2)]
        MagentaBed,
        [MaterialAttribute(26, 3)]
        LightBlueBed,
        [MaterialAttribute(26, 4)]
        YellowBed,
        [MaterialAttribute(26, 5)]
        LimeBed,
        [MaterialAttribute(26, 6)]
        PinkBed,
        [MaterialAttribute(26, 7)]
        GrayBed,
        [MaterialAttribute(26, 8)]
        LightGrayBed,
        [MaterialAttribute(26, 9)]
        CyanBed,
        [MaterialAttribute(26, 10)]
        PurpleBed,
        [MaterialAttribute(26, 11)]
        BlueBed,
        [MaterialAttribute(26, 12)]
        BrownBed,
        [MaterialAttribute(26, 13)]
        GreenBed,
        [MaterialAttribute(26, 14)]
        RedBed,
        [MaterialAttribute(26, 15)]
        BlackBed,
        [MaterialAttribute(357)]
        Cookie,
        [MaterialAttribute(358)]
        FilledMap,
        [MaterialAttribute(359)]
        Shears,
        [MaterialAttribute(360)]
        MelonSlice,
        [MaterialAttribute(21042)]
        DriedKelp,
        [MaterialAttribute(361)]
        PumpkinSeeds,
        [MaterialAttribute(362)]
        MelonSeeds,
        [MaterialAttribute(363)]
        Beef,
        [MaterialAttribute(364)]
        CookedBeef,
        [MaterialAttribute(365)]
        Chicken,
        [MaterialAttribute(366)]
        CookedChicken,
        [MaterialAttribute(367)]
        RottenFlesh,
        [MaterialAttribute(368)]
        EnderPearl,
        [MaterialAttribute(369)]
        BlazeRod,
        [MaterialAttribute(370)]
        GhastTear,
        [MaterialAttribute(371)]
        GoldNugget,
        [MaterialAttribute(373)]
        Potion,
        [MaterialAttribute(374)]
        GlassBottle,
        [MaterialAttribute(375)]
        SpiderEye,
        [MaterialAttribute(376)]
        FermentedSpiderEye,
        [MaterialAttribute(377)]
        BlazePowder,
        [MaterialAttribute(378)]
        MagmaCream,
        [MaterialAttribute(381)]
        EnderEye,
        [MaterialAttribute(382)]
        GlisteringMelonSlice,
        [MaterialAttribute(383)]
        BatSpawnEgg,
        [MaterialAttribute(383)]
        BeeSpawnEgg,
        [MaterialAttribute(383)]
        BlazeSpawnEgg,
        [MaterialAttribute(383)]
        CatSpawnEgg,
        [MaterialAttribute(383)]
        CaveSpiderSpawnEgg,
        [MaterialAttribute(383)]
        ChickenSpawnEgg,
        [MaterialAttribute(383)]
        CodSpawnEgg,
        [MaterialAttribute(383)]
        CowSpawnEgg,
        [MaterialAttribute(383)]
        CreeperSpawnEgg,
        [MaterialAttribute(383)]
        DolphinSpawnEgg,
        [MaterialAttribute(383)]
        DonkeySpawnEgg,
        [MaterialAttribute(383)]
        DrownedSpawnEgg,
        [MaterialAttribute(383)]
        ElderGuardianSpawnEgg,
        [MaterialAttribute(383)]
        EndermanSpawnEgg,
        [MaterialAttribute(383)]
        EndermiteSpawnEgg,
        [MaterialAttribute(383)]
        EvokerSpawnEgg,
        [MaterialAttribute(383)]
        FoxSpawnEgg,
        [MaterialAttribute(383)]
        GhastSpawnEgg,
        [MaterialAttribute(383)]
        GuardianSpawnEgg,
        [MaterialAttribute(383)]
        HoglinSpawnEgg,
        [MaterialAttribute(383)]
        HorseSpawnEgg,
        [MaterialAttribute(383)]
        HuskSpawnEgg,
        [MaterialAttribute(383)]
        LlamaSpawnEgg,
        [MaterialAttribute(383)]
        MagmaCubeSpawnEgg,
        [MaterialAttribute(383)]
        MooshroomSpawnEgg,
        [MaterialAttribute(383)]
        MuleSpawnEgg,
        [MaterialAttribute(383)]
        OcelotSpawnEgg,
        [MaterialAttribute(383)]
        PandaSpawnEgg,
        [MaterialAttribute(383)]
        ParrotSpawnEgg,
        [MaterialAttribute(383)]
        PhantomSpawnEgg,
        [MaterialAttribute(383)]
        PigSpawnEgg,
        [MaterialAttribute(383)]
        PiglinSpawnEgg,
        [MaterialAttribute(383)]
        PiglinBruteSpawnEgg,
        [MaterialAttribute(383)]
        PillagerSpawnEgg,
        [MaterialAttribute(383)]
        PolarBearSpawnEgg,
        [MaterialAttribute(383)]
        PufferfishSpawnEgg,
        [MaterialAttribute(383)]
        RabbitSpawnEgg,
        [MaterialAttribute(383)]
        RavagerSpawnEgg,
        [MaterialAttribute(383)]
        SalmonSpawnEgg,
        [MaterialAttribute(383)]
        SheepSpawnEgg,
        [MaterialAttribute(383)]
        ShulkerSpawnEgg,
        [MaterialAttribute(383)]
        SilverfishSpawnEgg,
        [MaterialAttribute(383)]
        SkeletonSpawnEgg,
        [MaterialAttribute(383)]
        SkeletonHorseSpawnEgg,
        [MaterialAttribute(383)]
        SlimeSpawnEgg,
        [MaterialAttribute(383)]
        SpiderSpawnEgg,
        [MaterialAttribute(383)]
        SquidSpawnEgg,
        [MaterialAttribute(383)]
        StraySpawnEgg,
        [MaterialAttribute(383)]
        StriderSpawnEgg,
        [MaterialAttribute(383)]
        TraderLlamaSpawnEgg,
        [MaterialAttribute(383)]
        TropicalFishSpawnEgg,
        [MaterialAttribute(383)]
        TurtleSpawnEgg,
        [MaterialAttribute(383)]
        VexSpawnEgg,
        [MaterialAttribute(383)]
        VillagerSpawnEgg,
        [MaterialAttribute(383)]
        VindicatorSpawnEgg,
        [MaterialAttribute(383)]
        WanderingTraderSpawnEgg,
        [MaterialAttribute(383)]
        WitchSpawnEgg,
        [MaterialAttribute(383)]
        WitherSkeletonSpawnEgg,
        [MaterialAttribute(383)]
        WolfSpawnEgg,
        [MaterialAttribute(383)]
        ZoglinSpawnEgg,
        [MaterialAttribute(383)]
        ZombieSpawnEgg,
        [MaterialAttribute(383)]
        ZombieHorseSpawnEgg,
        [MaterialAttribute(383)]
        ZombieVillagerSpawnEgg,
        [MaterialAttribute(383)]
        ZombifiedPiglinSpawnEgg,
        [MaterialAttribute(384)]
        ExperienceBottle,
        [MaterialAttribute(385)]
        FireCharge,
        [MaterialAttribute(386)]
        WritableBook,
        [MaterialAttribute(387)]
        WrittenBook,
        [MaterialAttribute(388)]
        Emerald,
        [MaterialAttribute(389)]
        ItemFrame,
        [MaterialAttribute(390)]
        FlowerPot,
        [MaterialAttribute(391)]
        Carrot,
        [MaterialAttribute(392)]
        Potato,
        [MaterialAttribute(393)]
        BakedPotato,
        [MaterialAttribute(394)]
        PoisonousPotato,
        [MaterialAttribute(395)]
        Map,
        [MaterialAttribute(396)]
        GoldenCarrot,
        [MaterialAttribute(398)]
        CarrotOnAStick,
        [MaterialAttribute(398)]
        WarpedFungusOnAStick,
        [MaterialAttribute(399)]
        NetherStar,
        [MaterialAttribute(400)]
        PumpkinPie,
        [MaterialAttribute(401)]
        FireworkRocket,
        [MaterialAttribute(402)]
        FireworkStar,
        [MaterialAttribute(403)]
        EnchantedBook,
        [MaterialAttribute(405)]
        NetherBrick,
        [MaterialAttribute(406)]
        Quartz,
        [MaterialAttribute(407)]
        TntMinecart,
        [MaterialAttribute(408)]
        HopperMinecart,
        [MaterialAttribute(409)]
        PrismarineShard,
        [MaterialAttribute(410)]
        PrismarineCrystals,
        [MaterialAttribute(411)]
        Rabbit,
        [MaterialAttribute(412)]
        CookedRabbit,
        [MaterialAttribute(413)]
        RabbitStew,
        [MaterialAttribute(414)]
        RabbitFoot,
        [MaterialAttribute(415)]
        RabbitHide,
        [MaterialAttribute(416)]
        ArmorStand,
        [MaterialAttribute(417)]
        IronHorseArmor,
        [MaterialAttribute(418)]
        GoldenHorseArmor,
        [MaterialAttribute(419)]
        DiamondHorseArmor,
        [MaterialAttribute(418)]
        LeatherHorseArmor,
        [MaterialAttribute(420)]
        Lead,
        [MaterialAttribute(421)]
        NameTag,
        [MaterialAttribute(422)]
        CommandBlockMinecart,
        [MaterialAttribute(423)]
        Mutton,
        [MaterialAttribute(424)]
        CookedMutton,
        [MaterialAttribute(176, 15)]
        WhiteBanner,
        [MaterialAttribute(176, 14)]
        OrangeBanner,
        [MaterialAttribute(176, 13)]
        MagentaBanner,
        [MaterialAttribute(176, 12)]
        LightBlueBanner,
        [MaterialAttribute(176, 11)]
        YellowBanner,
        [MaterialAttribute(176, 10)]
        LimeBanner,
        [MaterialAttribute(176, 9)]
        PinkBanner,
        [MaterialAttribute(176, 8)]
        GrayBanner,
        [MaterialAttribute(176, 7)]
        LightGrayBanner,
        [MaterialAttribute(176, 6)]
        CyanBanner,
        [MaterialAttribute(176, 5)]
        PurpleBanner,
        [MaterialAttribute(176, 4)]
        BlueBanner,
        [MaterialAttribute(176, 3)]
        BrownBanner,
        [MaterialAttribute(176, 2)]
        GreenBanner,
        [MaterialAttribute(176, 1)]
        RedBanner,
        [MaterialAttribute(176)]
        BlackBanner,
        [MaterialAttribute(426)]
        EndCrystal,
        [MaterialAttribute(432)]
        ChorusFruit,
        [MaterialAttribute(433)]
        PoppedChorusFruit,
        [MaterialAttribute(434)]
        Beetroot,
        [MaterialAttribute(435)]
        BeetrootSeeds,
        [MaterialAttribute(436)]
        BeetrootSoup,
        [MaterialAttribute(437)]
        DragonBreath,
        [MaterialAttribute(438)]
        SplashPotion,
        [MaterialAttribute(439)]
        SpectralArrow,
        [MaterialAttribute(440)]
        TippedArrow,
        [MaterialAttribute(441)]
        LingeringPotion,
        [MaterialAttribute(442)]
        Shield,
        [MaterialAttribute(443)]
        Elytra,
        [MaterialAttribute(444)]
        SpruceBoat,
        [MaterialAttribute(445)]
        BirchBoat,
        [MaterialAttribute(446)]
        JungleBoat,
        [MaterialAttribute(447)]
        AcaciaBoat,
        [MaterialAttribute(448)]
        DarkOakBoat,
        [MaterialAttribute(449)]
        TotemOfUndying,
        [MaterialAttribute(450)]
        ShulkerShell,
        [MaterialAttribute(452)]
        IronNugget,
        [MaterialAttribute(453)]
        KnowledgeBook,
        [MaterialAttribute(280)]
        DebugStick,
        [MaterialAttribute(2256)]
        MusicDisc13,
        [MaterialAttribute(2257)]
        MusicDiscCat,
        [MaterialAttribute(2258)]
        MusicDiscBlocks,
        [MaterialAttribute(2259)]
        MusicDiscChirp,
        [MaterialAttribute(2260)]
        MusicDiscFar,
        [MaterialAttribute(2261)]
        MusicDiscMall,
        [MaterialAttribute(2262)]
        MusicDiscMellohi,
        [MaterialAttribute(2263)]
        MusicDiscStal,
        [MaterialAttribute(2264)]
        MusicDiscStrad,
        [MaterialAttribute(2265)]
        MusicDiscWard,
        [MaterialAttribute(2266)]
        MusicDisc11,
        [MaterialAttribute(2267)]
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
        [MaterialAttribute(261)]
        Crossbow,
        [MaterialAttribute(282)]
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
        [MaterialAttribute(8)]
        Water,
        [MaterialAttribute(9)]
        StationaryWater,
        [MaterialAttribute(10)]
        Lava,
        [MaterialAttribute(11)]
        StationaryLava,
        [MaterialAttribute(175, 2)]
        TallSeagrass,
        [MaterialAttribute(34)]
        PistonHead,
        [MaterialAttribute(36)]
        MovingPiston,
        [MaterialAttribute(50)]
        WallTorch,
        [MaterialAttribute(51)]
        Fire,
        [MaterialAttribute(30163,51)]
        SoulFire,
        [MaterialAttribute(55)]
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
        [MaterialAttribute(90)]
        NetherPortal,
        
        //TODO: What?
        [MaterialAttribute(104)]
        AttachedPumpkinStem,
        [MaterialAttribute(105)]
        AttachedMelonStem,
        
        [MaterialAttribute(104)]
        PumpkinStem,
        [MaterialAttribute(105)]
        MelonStem,
        [MaterialAttribute(119)]
        EndPortal,
        [MaterialAttribute(29709,127)]
        Cocoa,
        [MaterialAttribute(132)]
        Tripwire,
        [MaterialAttribute(390)]
        PottedOakSapling,
        [MaterialAttribute(390)]
        PottedSpruceSapling,
        [MaterialAttribute(390)]
        PottedBirchSapling,
        [MaterialAttribute(390)]
        PottedJungleSapling,
        [MaterialAttribute(390)]
        PottedAcaciaSapling,
        [MaterialAttribute(390)]
        PottedDarkOakSapling,
        [MaterialAttribute(390)]
        PottedFern,
        [MaterialAttribute(390)]
        PottedDandelion,
        [MaterialAttribute(390)]
        PottedPoppy,
        [MaterialAttribute(390)]
        PottedBlueOrchid,
        [MaterialAttribute(390)]
        PottedAllium,
        [MaterialAttribute(390)]
        PottedAzureBluet,
        [MaterialAttribute(390)]
        PottedRedTulip,
        [MaterialAttribute(390)]
        PottedOrangeTulip,
        [MaterialAttribute(390)]
        PottedWhiteTulip,
        [MaterialAttribute(390)]
        PottedPinkTulip,
        [MaterialAttribute(390)]
        PottedOxeyeDaisy,
        [MaterialAttribute(390)]
        PottedCornflower,
        [MaterialAttribute(390)]
        PottedLilyOfTheValley,
        [MaterialAttribute(390)]
        PottedWitherRose,
        [MaterialAttribute(390)]
        PottedRedMushroom,
        [MaterialAttribute(390)]
        PottedBrownMushroom,
        [MaterialAttribute(390)]
        PottedDeadBush,
        [MaterialAttribute(390)]
        PottedCactus,
        [MaterialAttribute(141)]
        Carrots,
        [MaterialAttribute(142)]
        Potatoes,
        
        //TODO: What?
        [MaterialAttribute(144)]
        SkeletonWallSkull,
        [MaterialAttribute(144, 1)]
        WitherSkeletonWallSkull,
        [MaterialAttribute(144, 2)]
        ZombieWallHead,
        [MaterialAttribute(144, 3)]
        PlayerWallHead,
        [MaterialAttribute(144, 4)]
        CreeperWallHead,
        [MaterialAttribute(144, 5)]
        DragonWallHead,
        [MaterialAttribute(177, 15)]
        WhiteWallBanner,
        [MaterialAttribute(177, 14)]
        OrangeWallBanner,
        [MaterialAttribute(177, 13)]
        MagentaWallBanner,
        [MaterialAttribute(177, 12)]
        LightBlueWallBanner,
        [MaterialAttribute(177, 11)]
        YellowWallBanner,
        [MaterialAttribute(177, 10)]
        LimeWallBanner,
        [MaterialAttribute(177, 9)]
        PinkWallBanner,
        [MaterialAttribute(177, 8)]
        GrayWallBanner,
        [MaterialAttribute(177, 7)]
        LightGrayWallBanner,
        [MaterialAttribute(177, 6)]
        CyanWallBanner,
        [MaterialAttribute(177, 5)]
        PurpleWallBanner,
        [MaterialAttribute(177, 4)]
        BlueWallBanner,
        [MaterialAttribute(177, 3)]
        BrownWallBanner,
        [MaterialAttribute(177, 2)]
        GreenWallBanner,
        [MaterialAttribute(177, 1)]
        RedWallBanner,
        [MaterialAttribute(177)]
        BlackWallBanner,
        [MaterialAttribute(207)]
        Beetroots,
        [MaterialAttribute(209)]
        EndGateway,
        [MaterialAttribute(212)]
        FrostedIce,
        
        //TODO: What?
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
        [MaterialAttribute(390)]
        PottedBamboo,
        [MaterialAttribute(0)]
        VoidAir,
        [MaterialAttribute(0)]
        CaveAir,
        [MaterialAttribute(31612)]
        BubbleColumn,
        [MaterialAttribute(11958)]
        SweetBerryBush,
        [MaterialAttribute(19437)]
        WeepingVinesPlant,
        [MaterialAttribute(25338)]
        TwistingVinesPlant,
        [MaterialAttribute(68)]
        CrimsonWallSign,
        [MaterialAttribute(68)]
        WarpedWallSign,
        [MaterialAttribute(390)]
        PottedCrimsonFungus,
        [MaterialAttribute(390)]
        PottedWarpedFungus,
        [MaterialAttribute(390)]
        PottedCrimsonRoots,
        [MaterialAttribute(390)]
        PottedWarpedRoots,
    }

    internal class MaterialAttribute : System.Attribute
    {
        public readonly int Id;
        
        public readonly int MaxStack;
        public readonly short Durability;

        public readonly byte SubId;

        public MaterialAttribute(int id, byte subId = 0, int stack = 64, short durability = 0)
        {
            Id = id;
            SubId = subId;
            MaxStack = stack;
            Durability = durability;
        }
        // public MaterialAttribute(int id) : this(id) {}
    }

    public static class MaterialExtensions
    {
        public static int GetBlockId(this Material m)
        {
            var attributes =
                (MaterialAttribute[]) m.GetType().GetField(m.ToString())!.GetCustomAttributes(typeof(MaterialAttribute),
                    false);
            if (attributes.Length > 0)
                return attributes[0].Id;

            return -1;
        }
        
        public static int GetMetaData(this Material m)
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
                case Material.CutSandstone: case Material.NoteBlock: case Material.PoweredRail: case Material.DetectorRail: case Material.StickyPiston: case Material.Cobweb:
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
                case Material.LapisBlock: case Material.Dispenser: case Material.Sandstone: case Material.ChiseledSandstone: case Material.CutSandstone: case Material.NoteBlock:
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