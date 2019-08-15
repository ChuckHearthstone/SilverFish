using System.Linq;

namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public struct targett
    {
        public int target;
        public int targetEntity;

        public targett(int targ, int ent)
        {
            this.target = targ;
            this.targetEntity = ent;
        }
    }


    public class CardDB
    {
        // Data is stored in hearthstone-folder -> data->win cardxml0
        //(data-> cardxml0 seems outdated (blutelfkleriker has 3hp there >_>)
        public enum cardtype
        {
            NONE,
            MOB,
            SPELL,
            WEAPON,
            HEROPWR,
            ENCHANTMENT,
            HERO,

        }

        public enum cardtrigers
        {
            newtriger,
            getBattlecryEffect,
            onAHeroGotHealedTrigger,
            onAMinionGotHealedTrigger,
            onAuraEnds,
            onAuraStarts,
            onCardIsGoingToBePlayed,
            onCardPlay,
            onCardWasPlayed,
            onDeathrattle,
            onEnrageStart,
            onEnrageStop,
            onMinionDiedTrigger,
            onMinionGotDmgTrigger,
            onMinionIsSummoned,
            onMinionWasSummoned,
            onSecretPlay,
            onTurnEndsTrigger,
            onTurnStartTrigger,
            triggerInspire
        }

        public enum cardrace
        {
            INVALID,
            BLOODELF,
            DRAENEI,
            DWARF,
            GNOME,
            GOBLIN,
            HUMAN,
            NIGHTELF,
            ORC,
            TAUREN,
            TROLL,
            UNDEAD,
            WORGEN,
            GOBLIN2,
            MURLOC,
            DEMON,
            SCOURGE,
            MECHANICAL,
            ELEMENTAL,
            OGRE,
            PET,
            TOTEM,
            NERUBIAN,
            PIRATE,
            DRAGON
        }

        public enum cardIDEnum
        {
            None,
            aiextra1,
            hero,
            PlaceholderCard,
            AT_001,
            AT_002,
            AT_003,
            AT_004,
            AT_005,
            AT_005t,
            AT_006,
            AT_006e,
            AT_007,
            AT_008,
            AT_009,
            AT_010,
            AT_011,
            AT_011e,
            AT_012,
            AT_013,
            AT_013e,
            AT_014,
            AT_014e,
            AT_015,
            AT_016,
            AT_016e,
            AT_017,
            AT_017e,
            AT_018,
            AT_019,
            AT_019e,
            AT_020,
            AT_021,
            AT_021e,
            AT_022,
            AT_023,
            AT_024,
            AT_024e,
            AT_025,
            AT_026,
            AT_027,
            AT_027e,
            AT_028,
            AT_028e,
            AT_029,
            AT_029e,
            AT_030,
            AT_031,
            AT_032,
            AT_032e,
            AT_033,
            AT_034,
            AT_034e,
            AT_035,
            AT_035t,
            AT_036,
            AT_036t,
            AT_037,
            AT_037a,
            AT_037b,
            AT_037t,
            AT_038,
            AT_039,
            AT_039e,
            AT_040,
            AT_040e,
            AT_041,
            AT_041e,
            AT_042,
            AT_042a,
            AT_042b,
            AT_042t,
            AT_042t2,
            AT_043,
            AT_044,
            AT_045,
            AT_045e,
            AT_045ee,
            AT_046,
            AT_047,
            AT_047e,
            AT_048,
            AT_049,
            AT_049e,
            AT_050,
            AT_050t,
            AT_051,
            AT_052,
            AT_053,
            AT_054,
            AT_055,
            AT_056,
            AT_057,
            AT_057o,
            AT_058,
            AT_059,
            AT_060,
            AT_061,
            AT_061e,
            AT_062,
            AT_063,
            AT_063t,
            AT_064,
            AT_065,
            AT_065e,
            AT_066,
            AT_066e,
            AT_067,
            AT_068,
            AT_068e,
            AT_069,
            AT_069e,
            AT_070,
            AT_071,
            AT_071e,
            AT_072,
            AT_073,
            AT_073e,
            AT_074,
            AT_074e2,
            AT_075,
            AT_075e,
            AT_076,
            AT_077,
            AT_077e,
            AT_078,
            AT_079,
            AT_080,
            AT_081,
            AT_081e,
            AT_082,
            AT_082e,
            AT_083,
            AT_083e,
            AT_084,
            AT_084e,
            AT_085,
            AT_086,
            AT_086e,
            AT_087,
            AT_088,
            AT_089,
            AT_089e,
            AT_090,
            AT_090e,
            AT_091,
            AT_092,
            AT_093,
            AT_094,
            AT_095,
            AT_096,
            AT_096e,
            AT_097,
            AT_098,
            AT_099,
            AT_099t,
            AT_100,
            AT_101,
            AT_102,
            AT_103,
            AT_104,
            AT_105,
            AT_106,
            AT_108,
            AT_109,
            AT_109e,
            AT_110,
            AT_111,
            AT_112,
            AT_113,
            AT_114,
            AT_115,
            AT_115e,
            AT_116,
            AT_116e,
            AT_117,
            AT_117e,
            AT_118,
            AT_119,
            AT_119e,
            AT_120,
            AT_121,
            AT_121e,
            AT_122,
            AT_123,
            AT_124,
            AT_125,
            AT_127,
            AT_128,
            AT_129,
            AT_130,
            AT_131,
            AT_132,
            AT_132_DRUID,
            AT_132_DRUIDe,
            AT_132_HUNTER,
            AT_132_MAGE,
            AT_132_PALADIN,
            AT_132_PRIEST,
            AT_132_ROGUE,
            AT_132_ROGUE_H1,
            AT_132_ROGUEt,
            AT_132_ROGUEt_H1,
            AT_132_SHAMAN,
            AT_132_SHAMANa,
            AT_132_SHAMANb,
            AT_132_SHAMANc,
            AT_132_SHAMANd,
            AT_132_WARLOCK,
            AT_132_WARRIOR,
            AT_133,
            AT_133e,
            BRM_001,
            BRM_001e,
            BRM_002,
            BRM_003,
            BRM_003e,
            BRM_004,
            BRM_004e,
            BRM_004t,
            BRM_005,
            BRM_006,
            BRM_006t,
            BRM_007,
            BRM_008,
            BRM_009,
            BRM_010,
            BRM_010a,
            BRM_010b,
            BRM_010t,
            BRM_010t2,
            BRM_011,
            BRM_011t,
            BRM_012,
            BRM_012e,
            BRM_013,
            BRM_014,
            BRM_014e,
            BRM_015,
            BRM_016,
            BRM_017,
            BRM_018,
            BRM_018e,
            BRM_019,
            BRM_020,
            BRM_020e,
            BRM_022,
            BRM_022t,
            BRM_024,
            BRM_024e,
            BRM_025,
            BRM_026,
            BRM_027,
            BRM_027h,
            BRM_027p,
            BRM_027pH,
            BRM_028,
            BRM_028e,
            BRM_029,
            BRM_030,
            BRM_030t,
            BRM_031,
            BRM_033,
            BRM_033e,
            BRM_034,
            BRMA_01,
            BRMA01_1,
            BRMA01_1H,
            BRMA01_2,
            BRMA01_2H,
            BRMA01_2H_2_TB,
            BRMA01_2H_2c_TB,
            BRMA01_3,
            BRMA01_4,
            BRMA01_4t,
            BRMA02_1,
            BRMA02_1H,
            BRMA02_2,
            BRMA02_2_2_TB,
            BRMA02_2_2c_TB,
            BRMA02_2H,
            BRMA02_2t,
            BRMA03_1,
            BRMA03_1H,
            BRMA03_2,
            BRMA03_3,
            BRMA03_3H,
            BRMA04_1,
            BRMA04_1H,
            BRMA04_2,
            BRMA04_3,
            BRMA04_3H,
            BRMA04_4,
            BRMA04_4H,
            BRMA05_1,
            BRMA05_1H,
            BRMA05_2,
            BRMA05_2H,
            BRMA05_3,
            BRMA05_3e,
            BRMA05_3H,
            BRMA05_3He,
            BRMA06_1,
            BRMA06_1H,
            BRMA06_2,
            BRMA06_2H,
            BRMA06_2H_TB,
            BRMA06_3,
            BRMA06_3H,
            BRMA06_4,
            BRMA06_4H,
            BRMA07_1,
            BRMA07_1H,
            BRMA07_2,
            BRMA07_2_2_TB,
            BRMA07_2_2c_TB,
            BRMA07_2H,
            BRMA07_3,
            BRMA08_1,
            BRMA08_1H,
            BRMA08_2,
            BRMA08_2H,
            BRMA08_3,
            BRMA09_1,
            BRMA09_1H,
            BRMA09_2,
            BRMA09_2_TB,
            BRMA09_2H,
            BRMA09_2Ht,
            BRMA09_2t,
            BRMA09_3,
            BRMA09_3H,
            BRMA09_3Ht,
            BRMA09_3t,
            BRMA09_4,
            BRMA09_4H,
            BRMA09_4Ht,
            BRMA09_4t,
            BRMA09_5,
            BRMA09_5H,
            BRMA09_5Ht,
            BRMA09_5t,
            BRMA09_6,
            BRMA10_1,
            BRMA10_1H,
            BRMA10_3,
            BRMA10_3e,
            BRMA10_3H,
            BRMA10_4,
            BRMA10_4H,
            BRMA10_5,
            BRMA10_5H,
            BRMA10_6,
            BRMA10_6e,
            BRMA11_1,
            BRMA11_1H,
            BRMA11_2,
            BRMA11_2H,
            BRMA11_2H_2_TB,
            BRMA11_3,
            BRMA12_1,
            BRMA12_10,
            BRMA12_1H,
            BRMA12_2,
            BRMA12_2H,
            BRMA12_3,
            BRMA12_3H,
            BRMA12_4,
            BRMA12_4H,
            BRMA12_5,
            BRMA12_5H,
            BRMA12_6,
            BRMA12_6H,
            BRMA12_7,
            BRMA12_7H,
            BRMA12_8,
            BRMA12_8t,
            BRMA12_8te,
            BRMA12_9,
            BRMA13_1,
            BRMA13_1H,
            BRMA13_2,
            BRMA13_2H,
            BRMA13_3,
            BRMA13_3H,
            BRMA13_4,
            BRMA13_4_2_TB,
            BRMA13_4H,
            BRMA13_5,
            BRMA13_6,
            BRMA13_7,
            BRMA13_8,
            BRMA14_1,
            BRMA14_10,
            BRMA14_10H,
            BRMA14_10H_TB,
            BRMA14_11,
            BRMA14_12,
            BRMA14_1H,
            BRMA14_2,
            BRMA14_2H,
            BRMA14_3,
            BRMA14_4,
            BRMA14_4H,
            BRMA14_5,
            BRMA14_5H,
            BRMA14_6,
            BRMA14_6H,
            BRMA14_7,
            BRMA14_7H,
            BRMA14_8,
            BRMA14_8H,
            BRMA14_9,
            BRMA14_9H,
            BRMA15_1,
            BRMA15_1H,
            BRMA15_2,
            BRMA15_2H,
            BRMA15_2He,
            BRMA15_3,
            BRMA15_4,
            BRMA16_1,
            BRMA16_1H,
            BRMA16_2,
            BRMA16_2H,
            BRMA16_3,
            BRMA16_3e,
            BRMA16_4,
            BRMA16_5,
            BRMA16_5e,
            BRMA17_2,
            BRMA17_2H,
            BRMA17_3,
            BRMA17_3H,
            BRMA17_4,
            BRMA17_5,
            BRMA17_5_TB,
            BRMA17_5H,
            BRMA17_6,
            BRMA17_6H,
            BRMA17_7,
            BRMA17_8,
            BRMA17_8H,
            BRMA17_9,
            BRMC_100,
            BRMC_100e,
            BRMC_83,
            BRMC_84,
            BRMC_85,
            BRMC_86,
            BRMC_86e,
            BRMC_87,
            BRMC_88,
            BRMC_89,
            BRMC_90,
            BRMC_91,
            BRMC_92,
            BRMC_93,
            BRMC_94,
            BRMC_95,
            BRMC_95h,
            BRMC_95he,
            BRMC_96,
            BRMC_97,
            BRMC_97e,
            BRMC_98,
            BRMC_98e,
            BRMC_99,
            BRMC_99e,
            CFM_020,
            CFM_020e,
            CFM_021,
            CFM_025,
            CFM_026,
            CFM_026e,
            CFM_039,
            CFM_060,
            CFM_060e,
            CFM_061,
            CFM_062,
            CFM_063,
            CFM_063e,
            CFM_064,
            CFM_064e,
            CFM_065,
            CFM_066,
            CFM_067,
            CFM_094,
            CFM_095,
            CFM_120,
            CFM_300,
            CFM_305,
            CFM_305e,
            CFM_308,
            CFM_308a,
            CFM_308b,
            CFM_310,
            CFM_310t,
            CFM_312,
            CFM_313,
            CFM_315,
            CFM_315t,
            CFM_316,
            CFM_316t,
            CFM_321,
            CFM_324,
            CFM_324t,
            CFM_325,
            CFM_325e,
            CFM_328,
            CFM_333,
            CFM_334,
            CFM_334e,
            CFM_335,
            CFM_336,
            CFM_336e,
            CFM_337,
            CFM_337t,
            CFM_338,
            CFM_338e,
            CFM_341,
            CFM_342,
            CFM_342e,
            CFM_343,
            CFM_344,
            CFM_602,
            CFM_602a,
            CFM_602b,
            CFM_603,
            CFM_603e,
            CFM_604,
            CFM_605,
            CFM_606,
            CFM_606t,
            CFM_608,
            CFM_609,
            CFM_610,
            CFM_610e,
            CFM_611,
            CFM_611e,
            CFM_611e2,
            CFM_614,
            CFM_614e,
            CFM_616,
            CFM_617,
            CFM_617e,
            CFM_619,
            CFM_620,
            CFM_621,
            CFM_621_m2,
            CFM_621_m3,
            CFM_621_m4,
            CFM_621_m5,
            CFM_621e,
            CFM_621e2,
            CFM_621e3,
            CFM_621t,
            CFM_621t10,
            CFM_621t11,
            CFM_621t12,
            CFM_621t13,
            CFM_621t14,
            CFM_621t15,
            CFM_621t16,
            CFM_621t17,
            CFM_621t18,
            CFM_621t19,
            CFM_621t2,
            CFM_621t20,
            CFM_621t21,
            CFM_621t22,
            CFM_621t23,
            CFM_621t24,
            CFM_621t25,
            CFM_621t26,
            CFM_621t27,
            CFM_621t28,
            CFM_621t29,
            CFM_621t3,
            CFM_621t30,
            CFM_621t31,
            CFM_621t32,
            CFM_621t33,
            CFM_621t37,
            CFM_621t38,
            CFM_621t39,
            CFM_621t4,
            CFM_621t5,
            CFM_621t6,
            CFM_621t8,
            CFM_621t9,
            CFM_623,
            CFM_626,
            CFM_626e,
            CFM_630,
            CFM_631,
            CFM_631e,
            CFM_634,
            CFM_636,
            CFM_637,
            CFM_639,
            CFM_639e,
            CFM_643,
            CFM_643e,
            CFM_643e2,
            CFM_646,
            CFM_647,
            CFM_648,
            CFM_648t,
            CFM_649,
            CFM_650,
            CFM_650e,
            CFM_651,
            CFM_651e,
            CFM_652,
            CFM_653,
            CFM_654,
            CFM_655,
            CFM_656,
            CFM_657,
            CFM_658,
            CFM_658e,
            CFM_659,
            CFM_660,
            CFM_661,
            CFM_661e,
            CFM_662,
            CFM_663,
            CFM_665,
            CFM_666,
            CFM_667,
            CFM_668,
            CFM_668t,
            CFM_668t2,
            CFM_669,
            CFM_670,
            CFM_671,
            CFM_671e,
            CFM_672,
            CFM_685,
            CFM_685e,
            CFM_687,
            CFM_687e,
            CFM_688,
            CFM_690,
            CFM_691,
            CFM_693,
            CFM_694,
            CFM_694e,
            CFM_696,
            CFM_697,
            CFM_699,
            CFM_699e,
            CFM_707,
            CFM_712_t01,
            CFM_712_t02,
            CFM_712_t03,
            CFM_712_t04,
            CFM_712_t05,
            CFM_712_t06,
            CFM_712_t07,
            CFM_712_t08,
            CFM_712_t09,
            CFM_712_t10,
            CFM_712_t11,
            CFM_712_t12,
            CFM_712_t13,
            CFM_712_t14,
            CFM_712_t15,
            CFM_712_t16,
            CFM_712_t17,
            CFM_712_t18,
            CFM_712_t19,
            CFM_712_t20,
            CFM_712_t21,
            CFM_712_t22,
            CFM_712_t23,
            CFM_712_t24,
            CFM_712_t25,
            CFM_712_t26,
            CFM_712_t27,
            CFM_712_t28,
            CFM_712_t29,
            CFM_712_t30,
            CFM_713,
            CFM_715,
            CFM_716,
            CFM_717,
            CFM_750,
            CFM_751,
            CFM_752,
            CFM_752e,
            CFM_753,
            CFM_753e,
            CFM_754,
            CFM_754e,
            CFM_755,
            CFM_755e,
            CFM_756,
            CFM_759,
            CFM_760,
            CFM_781,
            CFM_790,
            CFM_800,
            CFM_806,
            CFM_807,
            CFM_808,
            CFM_809,
            CFM_810,
            CFM_811,
            CFM_815,
            CFM_816,
            CFM_816e,
            CFM_851,
            CFM_851e,
            CFM_852,
            CFM_853,
            CFM_853e,
            CFM_854,
            CFM_855,
            CFM_900,
            CFM_902,
            CFM_905,
            CFM_940,
            CRED_01,
            CRED_02,
            CRED_03,
            CRED_04,
            CRED_05,
            CRED_06,
            CRED_07,
            CRED_08,
            CRED_09,
            CRED_10,
            CRED_11,
            CRED_12,
            CRED_13,
            CRED_14,
            CRED_15,
            CRED_16,
            CRED_17,
            CRED_18,
            CRED_19,
            CRED_20,
            CRED_21,
            CRED_22,
            CRED_23,
            CRED_24,
            CRED_25,
            CRED_26,
            CRED_27,
            CRED_28,
            CRED_29,
            CRED_30,
            CRED_31,
            CRED_32,
            CRED_33,
            CRED_34,
            CRED_35,
            CRED_36,
            CRED_37,
            CRED_38,
            CRED_39,
            CRED_40,
            CRED_41,
            CRED_42,
            CRED_43,
            CRED_44,
            CRED_45,
            CRED_46,
            CRED_47,
            CRED_48,
            CRED_49,
            CRED_50,
            CRED_51,
            CRED_52,
            CRED_53,
            CRED_54,
            CRED_55,
            CRED_56,
            CRED_57,
            CRED_58,
            CRED_59,
            CRED_60,
            CRED_61,
            CRED_62,
            CRED_63,
            CRED_64,
            CRED_65,
            CRED_66,
            CRED_67,
            CRED_68,
            CRED_69,
            CRED_70,
            CRED_71,
            CRED_72,
            CRED_73,
            CRED_74,
            CRED_75,
            CRED_76,
            CRED_77,
            CRED_78,
            CRED_79,
            CRED_80,
            CRED_81,
            CRED_82,
            CRED_83,
            CRED_84,
            CRED_85,
            CRED_86,
            CRED_87,
            CS1_042,
            CS1_069,
            CS1_112,
            CS1_113,
            CS1_129,
            CS1_129e,
            CS1_130,
            CS1h_001,
            CS1h_001_H1,
            CS1h_001_H1_AT_132,
            CS2_003,
            CS2_004,
            CS2_004e,
            CS2_005,
            CS2_005o,
            CS2_007,
            CS2_008,
            CS2_009,
            CS2_009e,
            CS2_011,
            CS2_011o,
            CS2_012,
            CS2_013,
            CS2_013t,
            CS2_017,
            CS2_017o,
            CS2_022,
            CS2_022e,
            CS2_023,
            CS2_024,
            CS2_025,
            CS2_026,
            CS2_027,
            CS2_028,
            CS2_029,
            CS2_031,
            CS2_032,
            CS2_033,
            CS2_034,
            CS2_034_H1,
            CS2_034_H1_AT_132,
            CS2_034_H2,
            CS2_034_H2_AT_132,
            CS2_037,
            CS2_038,
            CS2_038e,
            CS2_039,
            CS2_041,
            CS2_041e,
            CS2_042,
            CS2_045,
            CS2_045e,
            CS2_046,
            CS2_046e,
            CS2_049,
            CS2_049_H1,
            CS2_049_H1_AT_132,
            CS2_050,
            CS2_051,
            CS2_052,
            CS2_053,
            CS2_053e,
            CS2_056,
            CS2_056_H1,
            CS2_057,
            CS2_059,
            CS2_059o,
            CS2_061,
            CS2_062,
            CS2_063,
            CS2_063e,
            CS2_064,
            CS2_065,
            CS2_072,
            CS2_073,
            CS2_073e,
            CS2_073e2,
            CS2_074,
            CS2_074e,
            CS2_075,
            CS2_076,
            CS2_077,
            CS2_080,
            CS2_082,
            CS2_082_H1,
            CS2_083b,
            CS2_083b_H1,
            CS2_083e,
            CS2_084,
            CS2_084e,
            CS2_087,
            CS2_087e,
            CS2_088,
            CS2_089,
            CS2_091,
            CS2_092,
            CS2_092e,
            CS2_093,
            CS2_094,
            CS2_097,
            CS2_101,
            CS2_101_H1,
            CS2_101_H1_AT_132,
            CS2_101_H2,
            CS2_101_H2_AT_132,
            CS2_101t,
            CS2_102,
            CS2_102_H1,
            CS2_102_H1_AT_132,
            CS2_103,
            CS2_103e2,
            CS2_104,
            CS2_104e,
            CS2_105,
            CS2_105e,
            CS2_106,
            CS2_108,
            CS2_112,
            CS2_114,
            CS2_117,
            CS2_118,
            CS2_119,
            CS2_120,
            CS2_121,
            CS2_122,
            CS2_122e,
            CS2_124,
            CS2_125,
            CS2_127,
            CS2_131,
            CS2_141,
            CS2_142,
            CS2_146,
            CS2_147,
            CS2_150,
            CS2_151,
            CS2_152,
            CS2_155,
            CS2_161,
            CS2_162,
            CS2_168,
            CS2_169,
            CS2_171,
            CS2_172,
            CS2_173,
            CS2_179,
            CS2_181,
            CS2_181e,
            CS2_182,
            CS2_186,
            CS2_187,
            CS2_188,
            CS2_188o,
            CS2_189,
            CS2_196,
            CS2_197,
            CS2_200,
            CS2_201,
            CS2_203,
            CS2_213,
            CS2_221,
            CS2_221e,
            CS2_222,
            CS2_222o,
            CS2_226,
            CS2_226e,
            CS2_227,
            CS2_231,
            CS2_232,
            CS2_233,
            CS2_234,
            CS2_235,
            CS2_236,
            CS2_236e,
            CS2_237,
            CS2_boar,
            CS2_mirror,
            CS2_tk1,
            DREAM_01,
            DREAM_02,
            DREAM_03,
            DREAM_04,
            DREAM_05,
            DREAM_05e,
            DS1_055,
            DS1_070,
            DS1_070o,
            DS1_175,
            DS1_175o,
            DS1_178,
            DS1_178e,
            DS1_183,
            DS1_184,
            DS1_185,
            DS1_188,
            DS1_188e,
            DS1_233,
            ds1_whelptoken,
            DS1h_292,
            DS1h_292_H1,
            DS1h_292_H1_AT_132,
            EX1_001,
            EX1_001e,
            EX1_002,
            EX1_004,
            EX1_004e,
            EX1_005,
            EX1_006,
            EX1_007,
            EX1_008,
            EX1_009,
            EX1_009e,
            EX1_010,
            EX1_011,
            EX1_012,
            EX1_014,
            EX1_014t,
            EX1_014te,
            EX1_015,
            EX1_016,
            EX1_017,
            EX1_019,
            EX1_019e,
            EX1_020,
            EX1_021,
            EX1_023,
            EX1_025,
            EX1_025t,
            EX1_028,
            EX1_029,
            EX1_032,
            EX1_033,
            EX1_043,
            EX1_043e,
            EX1_044,
            EX1_044e,
            EX1_045,
            EX1_046,
            EX1_046e,
            EX1_048,
            EX1_049,
            EX1_050,
            EX1_055,
            EX1_055o,
            EX1_057,
            EX1_058,
            EX1_059,
            EX1_059e,
            EX1_062,
            EX1_066,
            EX1_067,
            EX1_076,
            EX1_080,
            EX1_080o,
            EX1_082,
            EX1_083,
            EX1_084,
            EX1_084e,
            EX1_085,
            EX1_089,
            EX1_091,
            EX1_093,
            EX1_093e,
            EX1_095,
            EX1_096,
            EX1_097,
            EX1_100,
            EX1_102,
            EX1_103,
            EX1_103e,
            EX1_105,
            EX1_110,
            EX1_110t,
            EX1_112,
            EX1_116,
            EX1_116t,
            EX1_124,
            EX1_126,
            EX1_128,
            EX1_128e,
            EX1_129,
            EX1_130,
            EX1_130a,
            EX1_131,
            EX1_131t,
            EX1_132,
            EX1_133,
            EX1_134,
            EX1_136,
            EX1_137,
            EX1_144,
            EX1_145,
            EX1_145o,
            EX1_154,
            EX1_154a,
            EX1_154b,
            EX1_155,
            EX1_155a,
            EX1_155ae,
            EX1_155b,
            EX1_155be,
            EX1_158,
            EX1_158e,
            EX1_158t,
            EX1_160,
            EX1_160a,
            EX1_160b,
            EX1_160be,
            EX1_160t,
            EX1_161,
            EX1_162,
            EX1_162o,
            EX1_164,
            EX1_164a,
            EX1_164b,
            EX1_165,
            EX1_165a,
            EX1_165b,
            EX1_165t1,
            EX1_165t2,
            EX1_166,
            EX1_166a,
            EX1_166b,
            EX1_169,
            EX1_170,
            EX1_173,
            EX1_178,
            EX1_178a,
            EX1_178ae,
            EX1_178b,
            EX1_178be,
            EX1_238,
            EX1_241,
            EX1_243,
            EX1_244,
            EX1_244e,
            EX1_245,
            EX1_246,
            EX1_246e,
            EX1_247,
            EX1_248,
            EX1_249,
            EX1_250,
            EX1_251,
            EX1_258,
            EX1_258e,
            EX1_259,
            EX1_274,
            EX1_274e,
            EX1_275,
            EX1_277,
            EX1_278,
            EX1_279,
            EX1_283,
            EX1_284,
            EX1_287,
            EX1_289,
            EX1_294,
            EX1_295,
            EX1_295o,
            EX1_298,
            EX1_301,
            EX1_302,
            EX1_303,
            EX1_304,
            EX1_304e,
            EX1_306,
            EX1_308,
            EX1_309,
            EX1_310,
            EX1_312,
            EX1_313,
            EX1_315,
            EX1_316,
            EX1_316e,
            EX1_317,
            EX1_317t,
            EX1_319,
            EX1_320,
            EX1_323,
            EX1_323h,
            EX1_323w,
            EX1_332,
            EX1_334,
            EX1_334e,
            EX1_335,
            EX1_339,
            EX1_341,
            EX1_345,
            EX1_345t,
            EX1_349,
            EX1_350,
            EX1_354,
            EX1_355,
            EX1_355e,
            EX1_360,
            EX1_360e,
            EX1_362,
            EX1_363,
            EX1_363e,
            EX1_363e2,
            EX1_365,
            EX1_366,
            EX1_366e,
            EX1_371,
            EX1_379,
            EX1_379e,
            EX1_382,
            EX1_382e,
            EX1_383,
            EX1_383t,
            EX1_384,
            EX1_390,
            EX1_390e,
            EX1_391,
            EX1_392,
            EX1_393,
            EX1_393e,
            EX1_396,
            EX1_398,
            EX1_398t,
            EX1_399,
            EX1_399e,
            EX1_400,
            EX1_402,
            EX1_405,
            EX1_407,
            EX1_408,
            EX1_409,
            EX1_409e,
            EX1_409t,
            EX1_410,
            EX1_411,
            EX1_411e,
            EX1_411e2,
            EX1_412,
            EX1_412e,
            EX1_414,
            EX1_414e,
            EX1_506,
            EX1_506a,
            EX1_507,
            EX1_507e,
            EX1_508,
            EX1_508o,
            EX1_509,
            EX1_509e,
            EX1_522,
            EX1_531,
            EX1_531e,
            EX1_533,
            EX1_534,
            EX1_534t,
            EX1_536,
            EX1_536e,
            EX1_537,
            EX1_538,
            EX1_538t,
            EX1_539,
            EX1_543,
            EX1_544,
            EX1_549,
            EX1_549o,
            EX1_554,
            EX1_554t,
            EX1_556,
            EX1_557,
            EX1_558,
            EX1_559,
            EX1_560,
            EX1_561,
            EX1_561e,
            EX1_562,
            EX1_563,
            EX1_564,
            EX1_565,
            EX1_565o,
            EX1_567,
            EX1_570,
            EX1_570e,
            EX1_571,
            EX1_572,
            EX1_573,
            EX1_573a,
            EX1_573ae,
            EX1_573b,
            EX1_573t,
            EX1_575,
            EX1_577,
            EX1_578,
            EX1_581,
            EX1_582,
            EX1_583,
            EX1_584,
            EX1_584e,
            EX1_586,
            EX1_587,
            EX1_590,
            EX1_590e,
            EX1_591,
            EX1_593,
            EX1_594,
            EX1_595,
            EX1_596,
            EX1_596e,
            EX1_597,
            EX1_598,
            EX1_603,
            EX1_603e,
            EX1_604,
            EX1_604o,
            EX1_606,
            EX1_607,
            EX1_607e,
            EX1_608,
            EX1_609,
            EX1_610,
            EX1_611,
            EX1_611e,
            EX1_612,
            EX1_612o,
            EX1_613,
            EX1_613e,
            EX1_614,
            EX1_614t,
            EX1_616,
            EX1_617,
            EX1_619,
            EX1_619e,
            EX1_620,
            EX1_621,
            EX1_622,
            EX1_623,
            EX1_623e,
            EX1_624,
            EX1_625,
            EX1_625t,
            EX1_625t2,
            EX1_626,
            EX1_finkle,
            EX1_tk11,
            EX1_tk28,
            EX1_tk29,
            EX1_tk31,
            EX1_tk33,
            EX1_tk33_2_TB,
            EX1_tk34,
            EX1_tk9,
            FB_LK_012h,
            FB_LK_013h,
            FB_LK_014h,
            FB_LK_BossSetup001,
            FB_LK_BossSetup001a,
            FB_LK_BossSetup001b,
            FB_LK_BossSetup001c,
            FB_LK_ClearBoard,
            FB_LK_Druid_copy,
            FB_LK_Druid_Ench_copy,
            FB_LK_GetClass_copy,
            FB_LK_Hunter_copy,
            FB_LK_Hunter_Ench_copy,
            FB_LK_Mage_copy,
            FB_LK_Mage_Ench_copy,
            FB_LK_NewHeroCards,
            FB_LK_Paladin_copy,
            FB_LK_Paladin_Ench_copy,
            FB_LK_Priest_copy,
            FB_LK_Priest_Ench_copy,
            FB_LK_Raid_Hero,
            FB_LK_Raid_Hero_Battledamaged,
            FB_LK_Rogue_copy,
            FB_LK_Rogue_Ench_copy,
            FB_LK_Shaman_copy,
            FB_LK_Shaman_Ench_copy,
            FB_LK_WaitForDiscover,
            FB_LK_Warlock_copy,
            FB_LK_Warlock_Ench_copy,
            FB_LK_Warrior_copy,
            FB_LK_Warrior_Ench_copy,
            FB_LK001,
            FB_LK002,
            FB_LK003,
            FB_LK004,
            FB_LK005,
            FB_LK006,
            FB_LK007p,
            FB_LK008h,
            FB_LK009,
            FB_LK010,
            FB_LK011,
            FB_LKDebug001,
            FB_LKDebug002,
            FB_LKStats001,
            FB_LKStats001a,
            FB_LKStats001d,
            FB_LKStats002,
            FB_LKStats002a,
            FB_LKStats002b,
            FB_LKStats002c,
            FB_LKStats002ench,
            FB_TagTeam_Druid_Ench,
            FB_TagTeam_Hunter_Ench,
            FB_TagTeam_Mage_Ench,
            FB_TagTeam_Paladin_Ench,
            FB_TagTeam_Priest_Ench,
            FB_TagTeam_Rogue_Ench,
            FB_TagTeam_Shaman_Ench,
            FB_TagTeam_WaitForDiscover,
            FB_TagTeam_Warlock_Ench,
            FB_TagTeam_Warrior_Ench,
            FP1_001,
            FP1_002,
            FP1_002t,
            FP1_003,
            FP1_004,
            FP1_005,
            FP1_005e,
            FP1_006,
            FP1_007,
            FP1_007t,
            FP1_008,
            FP1_009,
            FP1_010,
            FP1_011,
            FP1_012,
            FP1_012t,
            FP1_013,
            FP1_014,
            FP1_014t,
            FP1_015,
            FP1_016,
            FP1_017,
            FP1_018,
            FP1_019,
            FP1_019t,
            FP1_020,
            FP1_020e,
            FP1_021,
            FP1_022,
            FP1_023,
            FP1_023e,
            FP1_024,
            FP1_025,
            FP1_026,
            FP1_027,
            FP1_028,
            FP1_028e,
            FP1_029,
            FP1_030,
            FP1_030e,
            FP1_031,
            GAME_001,
            GAME_002,
            GAME_003,
            GAME_003e,
            GAME_004,
            GAME_005,
            GAME_005e,
            GAME_006,
            GVG_001,
            GVG_002,
            GVG_003,
            GVG_004,
            GVG_005,
            GVG_006,
            GVG_007,
            GVG_008,
            GVG_009,
            GVG_010,
            GVG_010b,
            GVG_011,
            GVG_011a,
            GVG_012,
            GVG_013,
            GVG_014,
            GVG_014a,
            GVG_015,
            GVG_016,
            GVG_017,
            GVG_018,
            GVG_019,
            GVG_019e,
            GVG_020,
            GVG_021,
            GVG_021e,
            GVG_022,
            GVG_022a,
            GVG_022b,
            GVG_023,
            GVG_023a,
            GVG_024,
            GVG_025,
            GVG_026,
            GVG_027,
            GVG_027e,
            GVG_028,
            GVG_028t,
            GVG_029,
            GVG_030,
            GVG_030a,
            GVG_030ae,
            GVG_030b,
            GVG_030be,
            GVG_031,
            GVG_032,
            GVG_032a,
            GVG_032b,
            GVG_033,
            GVG_034,
            GVG_035,
            GVG_036,
            GVG_036e,
            GVG_037,
            GVG_038,
            GVG_039,
            GVG_040,
            GVG_041,
            GVG_041a,
            GVG_041b,
            GVG_041c,
            GVG_042,
            GVG_043,
            GVG_043e,
            GVG_044,
            GVG_045,
            GVG_045t,
            GVG_046,
            GVG_046e,
            GVG_047,
            GVG_048,
            GVG_048e,
            GVG_049,
            GVG_049e,
            GVG_050,
            GVG_051,
            GVG_051e,
            GVG_052,
            GVG_053,
            GVG_054,
            GVG_055,
            GVG_055e,
            GVG_056,
            GVG_056t,
            GVG_057,
            GVG_057a,
            GVG_058,
            GVG_059,
            GVG_060,
            GVG_060e,
            GVG_061,
            GVG_062,
            GVG_063,
            GVG_063a,
            GVG_064,
            GVG_065,
            GVG_066,
            GVG_067,
            GVG_067a,
            GVG_068,
            GVG_068a,
            GVG_069,
            GVG_069a,
            GVG_070,
            GVG_071,
            GVG_072,
            GVG_073,
            GVG_074,
            GVG_075,
            GVG_076,
            GVG_076a,
            GVG_077,
            GVG_078,
            GVG_079,
            GVG_080,
            GVG_080t,
            GVG_081,
            GVG_082,
            GVG_083,
            GVG_084,
            GVG_085,
            GVG_086,
            GVG_086e,
            GVG_087,
            GVG_088,
            GVG_089,
            GVG_090,
            GVG_091,
            GVG_092,
            GVG_092t,
            GVG_093,
            GVG_094,
            GVG_095,
            GVG_096,
            GVG_097,
            GVG_098,
            GVG_099,
            GVG_100,
            GVG_100e,
            GVG_101,
            GVG_101e,
            GVG_102,
            GVG_102e,
            GVG_103,
            GVG_104,
            GVG_104a,
            GVG_105,
            GVG_106,
            GVG_106e,
            GVG_107,
            GVG_108,
            GVG_109,
            GVG_110,
            GVG_110t,
            GVG_111,
            GVG_111t,
            GVG_112,
            GVG_113,
            GVG_114,
            GVG_115,
            GVG_116,
            GVG_117,
            GVG_118,
            GVG_119,
            GVG_120,
            GVG_121,
            GVG_122,
            GVG_123,
            GVG_123e,
            HERO_01,
            HERO_01a,
            HERO_02,
            HERO_02a,
            HERO_03,
            HERO_03a,
            HERO_04,
            HERO_04a,
            HERO_04b,
            HERO_05,
            HERO_05a,
            HERO_06,
            HERO_07,
            HERO_07a,
            HERO_08,
            HERO_08a,
            HERO_08b,
            HERO_09,
            HERO_09a,
            hexfrog,
            HRW02_1,
            HRW02_1e,
            HRW02_2,
            HRW02_3,
            ICC_018,
            ICC_018e,
            ICC_019,
            ICC_019t,
            ICC_021,
            ICC_023,
            ICC_025,
            ICC_025t,
            ICC_026,
            ICC_026t,
            ICC_027,
            ICC_028,
            ICC_028e,
            ICC_029,
            ICC_029e,
            ICC_031,
            ICC_031e,
            ICC_032,
            ICC_034,
            ICC_038,
            ICC_039,
            ICC_039e,
            ICC_041,
            ICC_047,
            ICC_047a,
            ICC_047b,
            ICC_047e,
            ICC_047t,
            ICC_047t2,
            ICC_049,
            ICC_049e,
            ICC_050,
            ICC_051,
            ICC_051a,
            ICC_051b,
            ICC_051t,
            ICC_051t2,
            ICC_051t3,
            ICC_052,
            ICC_054,
            ICC_055,
            ICC_056,
            ICC_056e,
            ICC_058,
            ICC_062,
            ICC_064,
            ICC_065,
            ICC_067,
            ICC_068,
            ICC_069,
            ICC_071,
            ICC_071e,
            ICC_075,
            ICC_078,
            ICC_079,
            ICC_079e,
            ICC_081,
            ICC_082,
            ICC_083,
            ICC_085,
            ICC_085t,
            ICC_086,
            ICC_088,
            ICC_089,
            ICC_090,
            ICC_091,
            ICC_092,
            ICC_092e,
            ICC_093,
            ICC_093e,
            ICC_094,
            ICC_094e,
            ICC_096,
            ICC_096e,
            ICC_097,
            ICC_097e,
            ICC_098,
            ICC_099,
            ICC_200,
            ICC_201,
            ICC_204,
            ICC_206,
            ICC_207,
            ICC_210,
            ICC_210e,
            ICC_212,
            ICC_213,
            ICC_214,
            ICC_215,
            ICC_218,
            ICC_220,
            ICC_221,
            ICC_221e,
            ICC_233,
            ICC_235,
            ICC_235e,
            ICC_236,
            ICC_238,
            ICC_240,
            ICC_240e,
            ICC_243,
            ICC_244,
            ICC_244e,
            ICC_245,
            ICC_252,
            ICC_257,
            ICC_257e,
            ICC_281,
            ICC_289,
            ICC_314,
            ICC_314t1,
            ICC_314t1e,
            ICC_314t2,
            ICC_314t3,
            ICC_314t4,
            ICC_314t5,
            ICC_314t6,
            ICC_314t7,
            ICC_314t7e,
            ICC_314t8,
            ICC_405,
            ICC_407,
            ICC_408,
            ICC_415,
            ICC_419,
            ICC_450,
            ICC_450e,
            ICC_466,
            ICC_467,
            ICC_467e,
            ICC_468,
            ICC_469,
            ICC_481,
            ICC_481p,
            ICC_483e,
            ICC_700,
            ICC_701,
            ICC_702,
            ICC_705,
            ICC_705e,
            ICC_706,
            ICC_800h3t,
            ICC_801,
            ICC_802,
            ICC_807,
            ICC_807e,
            ICC_808,
            ICC_808e,
            ICC_809,
            ICC_809e,
            ICC_810,
            ICC_810e,
            ICC_811,
            ICC_812,
            ICC_820,
            ICC_823,
            ICC_825,
            ICC_827,
            ICC_827e,
            ICC_827e3,
            ICC_827p,
            ICC_827t,
            ICC_828,
            ICC_828e,
            ICC_828p,
            ICC_828t,
            ICC_828t2,
            ICC_828t3,
            ICC_829,
            ICC_829p,
            ICC_829t,
            ICC_829t2,
            ICC_829t3,
            ICC_829t4,
            ICC_829t5,
            ICC_830,
            ICC_830p,
            ICC_831,
            ICC_831p,
            ICC_832,
            ICC_832a,
            ICC_832b,
            ICC_832e,
            ICC_832p,
            ICC_832pa,
            ICC_832pb,
            ICC_832t3,
            ICC_832t4,
            ICC_833,
            ICC_833e,
            ICC_833e2,
            ICC_833h,
            ICC_833t,
            ICC_834,
            ICC_834h,
            ICC_834w,
            ICC_835,
            ICC_836,
            ICC_837,
            ICC_837e,
            ICC_838,
            ICC_838t,
            ICC_841,
            ICC_841e,
            ICC_849,
            ICC_849e,
            ICC_850,
            ICC_850e,
            ICC_851,
            ICC_851e,
            ICC_852,
            ICC_852e,
            ICC_853,
            ICC_854,
            ICC_855,
            ICC_856,
            ICC_858,
            ICC_858e,
            ICC_900,
            ICC_900t,
            ICC_901,
            ICC_902,
            ICC_903,
            ICC_903t,
            ICC_904,
            ICC_904e,
            ICC_905,
            ICC_910,
            ICC_911,
            ICC_912,
            ICC_913,
            ICCA01_001,
            ICCA01_003,
            ICCA01_004,
            ICCA01_004t,
            ICCA01_005,
            ICCA01_007,
            ICCA01_008,
            ICCA01_009,
            ICCA01_010,
            ICCA01_011,
            ICCA01_013,
            ICCA03_001,
            ICCA04_001,
            ICCA04_002,
            ICCA04_004,
            ICCA04_008p,
            ICCA04_009p,
            ICCA04_010p,
            ICCA04_011p,
            ICCA05_001,
            ICCA05_002e,
            ICCA05_002p,
            ICCA05_003,
            ICCA05_004p,
            ICCA05_020,
            ICCA05_021,
            ICCA06_001,
            ICCA06_002p,
            ICCA06_003,
            ICCA06_004,
            ICCA06_005,
            ICCA07_001,
            ICCA07_001h2,
            ICCA07_001h3,
            ICCA07_002p,
            ICCA07_003p,
            ICCA07_004,
            ICCA07_004e,
            ICCA07_005p,
            ICCA07_008,
            ICCA07_020,
            ICCA08_001,
            ICCA08_002p,
            ICCA08_002t,
            ICCA08_017,
            ICCA08_020,
            ICCA08_021,
            ICCA08_022,
            ICCA08_022e,
            ICCA08_022e2,
            ICCA08_023,
            ICCA08_023e,
            ICCA08_024,
            ICCA08_025,
            ICCA08_026,
            ICCA08_027,
            ICCA08_028,
            ICCA08_029,
            ICCA08_030p,
            ICCA08_032p,
            ICCA08_033,
            ICCA09_001p,
            ICCA09_001t1,
            ICCA09_002,
            ICCA09_003t4,
            ICCA10_001,
            ICCA10_009,
            ICCA10_009p,
            ICCA11_001,
            KAR_004,
            KAR_004a,
            KAR_005,
            KAR_005a,
            KAR_006,
            KAR_009,
            KAR_010,
            KAR_010a,
            KAR_011,
            KAR_013,
            KAR_021,
            KAR_025,
            KAR_025a,
            KAR_025b,
            KAR_025c,
            KAR_026,
            KAR_026t,
            KAR_028,
            KAR_029,
            KAR_030,
            KAR_030a,
            KAR_033,
            KAR_035,
            KAR_036,
            KAR_036e,
            KAR_037,
            KAR_037t,
            KAR_041,
            KAR_044,
            KAR_044a,
            KAR_057,
            KAR_061,
            KAR_062,
            KAR_063,
            KAR_065,
            KAR_069,
            KAR_070,
            KAR_073,
            KAR_075,
            KAR_076,
            KAR_077,
            KAR_077e,
            KAR_089,
            KAR_091,
            KAR_092,
            KAR_094,
            KAR_094a,
            KAR_095,
            KAR_095e,
            KAR_096,
            KAR_097,
            KAR_097t,
            KAR_114,
            KAR_114e,
            KAR_204,
            KAR_205,
            KAR_300,
            KAR_702,
            KAR_702e,
            KAR_710,
            KAR_710m,
            KAR_711,
            KAR_712,
            KAR_A01_01,
            KAR_A01_01H,
            KAR_A01_02,
            KAR_A01_02e,
            KAR_A01_02H,
            KAR_A02_01,
            KAR_A02_01H,
            KAR_A02_02,
            KAR_A02_02H,
            KAR_A02_03,
            KAR_A02_03H,
            KAR_A02_04,
            KAR_A02_04H,
            KAR_A02_05,
            KAR_A02_05H,
            KAR_A02_06,
            KAR_A02_06e2,
            KAR_A02_06H,
            KAR_A02_06He,
            KAR_A02_09,
            KAR_A02_09e,
            KAR_A02_09eH,
            KAR_A02_09H,
            KAR_A02_10,
            KAR_A02_11,
            KAR_A02_12,
            KAR_A02_12H,
            KAR_A02_13,
            KAR_A02_13H,
            KAR_A10_01,
            KAR_A10_02,
            KAR_A10_03,
            KAR_A10_04,
            KAR_A10_05,
            KAR_A10_06,
            KAR_A10_07,
            KAR_A10_08,
            KAR_A10_09,
            KAR_A10_10,
            KAR_A10_22,
            KAR_A10_22H,
            KAR_A10_33,
            KAR_a10_Boss1,
            KAR_a10_Boss1H,
            KAR_a10_Boss1H_TB,
            KAR_a10_Boss1H_TB22,
            KAR_a10_Boss2,
            KAR_a10_Boss2H,
            KAR_a10_Boss2H_TB,
            KARA_00_01,
            KARA_00_01H,
            KARA_00_02,
            KARA_00_02a,
            KARA_00_02H,
            KARA_00_03,
            KARA_00_03c,
            KARA_00_03H,
            KARA_00_04,
            KARA_00_04H,
            KARA_00_05,
            KARA_00_05e,
            KARA_00_06,
            KARA_00_06e,
            KARA_00_07,
            KARA_00_08,
            KARA_00_09,
            KARA_00_10,
            KARA_00_11,
            KARA_04_01,
            KARA_04_01h,
            KARA_04_01heroic,
            KARA_04_02hp,
            KARA_04_05,
            KARA_04_05h,
            KARA_05_01b,
            KARA_05_01e,
            KARA_05_01h,
            KARA_05_01hheroic,
            KARA_05_01hp,
            KARA_05_01hpheroic,
            KARA_05_02,
            KARA_05_02heroic,
            KARA_06_01,
            KARA_06_01e,
            KARA_06_01heroic,
            KARA_06_02,
            KARA_06_02heroic,
            KARA_06_03hp,
            KARA_06_03hpheroic,
            KARA_07_01,
            KARA_07_01heroic,
            KARA_07_02,
            KARA_07_02e,
            KARA_07_03,
            KARA_07_03heroic,
            KARA_07_05,
            KARA_07_05heroic,
            KARA_07_06,
            KARA_07_06heroic,
            KARA_07_07,
            KARA_07_07heroic,
            KARA_07_08,
            KARA_07_08heroic,
            KARA_08_01,
            KARA_08_01H,
            KARA_08_02,
            KARA_08_02e,
            KARA_08_02eH,
            KARA_08_02H,
            KARA_08_03,
            KARA_08_03e,
            KARA_08_03H,
            KARA_08_04,
            KARA_08_04e,
            KARA_08_05,
            KARA_08_05H,
            KARA_08_06,
            KARA_08_06e2,
            KARA_08_08,
            KARA_08_08e2,
            KARA_09_01,
            KARA_09_01heroic,
            KARA_09_02,
            KARA_09_03,
            KARA_09_03a,
            KARA_09_03a_heroic,
            KARA_09_03heroic,
            KARA_09_04,
            KARA_09_05,
            KARA_09_05heroic,
            KARA_09_06,
            KARA_09_06heroic,
            KARA_09_07,
            KARA_09_07heroic,
            KARA_09_08,
            KARA_09_08_heroic,
            KARA_11_01,
            KARA_11_01heroic,
            KARA_11_02,
            KARA_12_01,
            KARA_12_01H,
            KARA_12_02,
            KARA_12_02H,
            KARA_12_03,
            KARA_12_03H,
            KARA_13_01,
            KARA_13_01H,
            KARA_13_02,
            KARA_13_02H,
            KARA_13_03,
            KARA_13_03H,
            KARA_13_06,
            KARA_13_06H,
            KARA_13_11,
            KARA_13_11e,
            KARA_13_12,
            KARA_13_12H,
            KARA_13_13,
            KARA_13_13H,
            KARA_13_15,
            KARA_13_16,
            KARA_13_17,
            KARA_13_19,
            KARA_13_19e,
            KARA_13_20,
            KARA_13_22,
            KARA_13_23,
            KARA_13_26,
            LOE_002,
            LOE_002t,
            LOE_003,
            LOE_006,
            LOE_007,
            LOE_007t,
            LOE_008,
            LOE_008H,
            LOE_009,
            LOE_009e,
            LOE_009t,
            LOE_010,
            LOE_011,
            LOE_012,
            LOE_016,
            LOE_016t,
            LOE_017,
            LOE_017e,
            LOE_018,
            LOE_018e,
            LOE_019,
            LOE_019e,
            LOE_019t,
            LOE_019t2,
            LOE_020,
            LOE_021,
            LOE_022,
            LOE_023,
            LOE_024t,
            LOE_026,
            LOE_027,
            LOE_029,
            LOE_030e,
            LOE_038,
            LOE_039,
            LOE_046,
            LOE_047,
            LOE_050,
            LOE_051,
            LOE_053,
            LOE_061,
            LOE_061e,
            LOE_073,
            LOE_073e,
            LOE_076,
            LOE_077,
            LOE_079,
            LOE_086,
            LOE_089,
            LOE_089t,
            LOE_089t2,
            LOE_089t3,
            LOE_092,
            LOE_104,
            LOE_105,
            LOE_105e,
            LOE_107,
            LOE_110,
            LOE_110t,
            LOE_111,
            LOE_113,
            LOE_113e,
            LOE_115,
            LOE_115a,
            LOE_115b,
            LOE_116,
            LOE_118,
            LOE_118e,
            LOE_119,
            LOEA_01,
            LOEA_01H,
            LOEA01_01,
            LOEA01_01h,
            LOEA01_02,
            LOEA01_02h,
            LOEA01_11,
            LOEA01_11h,
            LOEA01_11he,
            LOEA01_12,
            LOEA01_12h,
            LOEA02_01,
            LOEA02_01h,
            LOEA02_02,
            LOEA02_02h,
            LOEA02_03,
            LOEA02_04,
            LOEA02_05,
            LOEA02_06,
            LOEA02_10,
            LOEA02_10a,
            LOEA02_10c,
            LOEA04_01,
            LOEA04_01e,
            LOEA04_01eh,
            LOEA04_01h,
            LOEA04_02,
            LOEA04_02h,
            LOEA04_06,
            LOEA04_06a,
            LOEA04_06b,
            LOEA04_13bt,
            LOEA04_13bth,
            LOEA04_23,
            LOEA04_23h,
            LOEA04_24,
            LOEA04_24h,
            LOEA04_25,
            LOEA04_25h,
            LOEA04_27,
            LOEA04_28,
            LOEA04_28a,
            LOEA04_28b,
            LOEA04_29,
            LOEA04_29a,
            LOEA04_29b,
            LOEA04_30,
            LOEA04_30a,
            LOEA04_31b,
            LOEA05_01,
            LOEA05_01h,
            LOEA05_02,
            LOEA05_02a,
            LOEA05_02h,
            LOEA05_02ha,
            LOEA05_03,
            LOEA05_03h,
            LOEA06_02,
            LOEA06_02h,
            LOEA06_02t,
            LOEA06_02th,
            LOEA06_03,
            LOEA06_03e,
            LOEA06_03eh,
            LOEA06_03h,
            LOEA06_04,
            LOEA06_04h,
            LOEA07_01,
            LOEA07_02,
            LOEA07_02h,
            LOEA07_03,
            LOEA07_03h,
            LOEA07_09,
            LOEA07_11,
            LOEA07_12,
            LOEA07_14,
            LOEA07_18,
            LOEA07_20,
            LOEA07_21,
            LOEA07_24,
            LOEA07_25,
            LOEA07_26,
            LOEA07_28,
            LOEA07_29,
            LOEA08_01,
            LOEA08_01h,
            LOEA09_1,
            LOEA09_10,
            LOEA09_11,
            LOEA09_12,
            LOEA09_13,
            LOEA09_1H,
            LOEA09_2,
            LOEA09_2e,
            LOEA09_2eH,
            LOEA09_2H,
            LOEA09_3,
            LOEA09_3a,
            LOEA09_3aH,
            LOEA09_3b,
            LOEA09_3c,
            LOEA09_3d,
            LOEA09_3H,
            LOEA09_4,
            LOEA09_4H,
            LOEA09_5,
            LOEA09_5H,
            LOEA09_6,
            LOEA09_6H,
            LOEA09_7,
            LOEA09_7e,
            LOEA09_7H,
            LOEA09_8,
            LOEA09_8H,
            LOEA09_9,
            LOEA09_9H,
            LOEA10_1,
            LOEA10_1H,
            LOEA10_2,
            LOEA10_2H,
            LOEA10_3,
            LOEA10_5,
            LOEA10_5H,
            LOEA12_1,
            LOEA12_1H,
            LOEA12_2,
            LOEA12_2H,
            LOEA13_1,
            LOEA13_1h,
            LOEA13_2,
            LOEA13_2H,
            LOEA14_1,
            LOEA14_1H,
            LOEA14_2,
            LOEA14_2H,
            LOEA15_1,
            LOEA15_1H,
            LOEA15_2,
            LOEA15_2H,
            LOEA15_3,
            LOEA15_3H,
            LOEA16_1,
            LOEA16_10,
            LOEA16_11,
            LOEA16_12,
            LOEA16_13,
            LOEA16_14,
            LOEA16_15,
            LOEA16_16,
            LOEA16_16H,
            LOEA16_17,
            LOEA16_18,
            LOEA16_18H,
            LOEA16_19,
            LOEA16_19H,
            LOEA16_1H,
            LOEA16_2,
            LOEA16_20,
            LOEA16_20e,
            LOEA16_20H,
            LOEA16_21,
            LOEA16_21H,
            LOEA16_22,
            LOEA16_22H,
            LOEA16_23,
            LOEA16_23H,
            LOEA16_24,
            LOEA16_24H,
            LOEA16_25,
            LOEA16_25H,
            LOEA16_26,
            LOEA16_26H,
            LOEA16_27,
            LOEA16_27H,
            LOEA16_2H,
            LOEA16_3,
            LOEA16_3e,
            LOEA16_4,
            LOEA16_5,
            LOEA16_5t,
            LOEA16_6,
            LOEA16_7,
            LOEA16_8,
            LOEA16_8a,
            LOEA16_9,
            Mekka1,
            Mekka2,
            Mekka3,
            Mekka3e,
            Mekka4,
            Mekka4e,
            Mekka4t,
            NAX1_01,
            NAX1_03,
            NAX1_04,
            NAX1_05,
            NAX10_01,
            NAX10_01H,
            NAX10_02,
            NAX10_02H,
            NAX10_03,
            NAX10_03H,
            NAX11_01,
            NAX11_01H,
            NAX11_02,
            NAX11_02H,
            NAX11_02H_2_TB,
            NAX11_03,
            NAX11_04,
            NAX11_04e,
            NAX12_01,
            NAX12_01H,
            NAX12_02,
            NAX12_02e,
            NAX12_02H,
            NAX12_02H_2_TB,
            NAX12_02H_2c_TB,
            NAX12_03,
            NAX12_03e,
            NAX12_03H,
            NAX12_04,
            NAX12_04e,
            NAX13_01,
            NAX13_01H,
            NAX13_02,
            NAX13_02e,
            NAX13_03,
            NAX13_03e,
            NAX13_04H,
            NAX13_05H,
            NAX14_01,
            NAX14_01H,
            NAX14_02,
            NAX14_03,
            NAX14_04,
            NAX15_01,
            NAX15_01e,
            NAX15_01H,
            NAX15_01He,
            NAX15_02,
            NAX15_02H,
            NAX15_03n,
            NAX15_03t,
            NAX15_04,
            NAX15_04a,
            NAX15_04H,
            NAX15_05,
            NAX1h_01,
            NAX1h_03,
            NAX1h_04,
            NAX2_01,
            NAX2_01H,
            NAX2_03,
            NAX2_03H,
            NAX2_05,
            NAX2_05H,
            NAX3_01,
            NAX3_01H,
            NAX3_02,
            NAX3_02_TB,
            NAX3_02H,
            NAX3_03,
            NAX4_01,
            NAX4_01H,
            NAX4_03,
            NAX4_03H,
            NAX4_04,
            NAX4_04H,
            NAX4_05,
            NAX5_01,
            NAX5_01H,
            NAX5_02,
            NAX5_02H,
            NAX5_03,
            NAX6_01,
            NAX6_01H,
            NAX6_02,
            NAX6_02H,
            NAX6_03,
            NAX6_03t,
            NAX6_03te,
            NAX6_04,
            NAX7_01,
            NAX7_01H,
            NAX7_02,
            NAX7_03,
            NAX7_03H,
            NAX7_04,
            NAX7_04H,
            NAX7_05,
            NAX8_01,
            NAX8_01H,
            NAX8_02,
            NAX8_02H,
            NAX8_02H_TB,
            NAX8_03,
            NAX8_03t,
            NAX8_04,
            NAX8_04t,
            NAX8_05,
            NAX8_05t,
            NAX9_01,
            NAX9_01H,
            NAX9_02,
            NAX9_02H,
            NAX9_03,
            NAX9_03H,
            NAX9_04,
            NAX9_04H,
            NAX9_05,
            NAX9_05H,
            NAX9_06,
            NAX9_07,
            NAX9_07e,
            NAXM_001,
            NAXM_002,
            NEW1_003,
            NEW1_004,
            NEW1_005,
            NEW1_007,
            NEW1_007a,
            NEW1_007b,
            NEW1_008,
            NEW1_008a,
            NEW1_008b,
            NEW1_009,
            NEW1_010,
            NEW1_011,
            NEW1_012,
            NEW1_012o,
            NEW1_014,
            NEW1_014e,
            NEW1_016,
            NEW1_017,
            NEW1_017e,
            NEW1_018,
            NEW1_018e,
            NEW1_019,
            NEW1_020,
            NEW1_021,
            NEW1_022,
            NEW1_023,
            NEW1_024,
            NEW1_024o,
            NEW1_025,
            NEW1_025e,
            NEW1_026,
            NEW1_026t,
            NEW1_027,
            NEW1_027e,
            NEW1_029,
            NEW1_029t,
            NEW1_030,
            NEW1_031,
            NEW1_032,
            NEW1_033,
            NEW1_033o,
            NEW1_034,
            NEW1_036,
            NEW1_036e,
            NEW1_036e2,
            NEW1_037,
            NEW1_037e,
            NEW1_038,
            NEW1_038o,
            NEW1_040,
            NEW1_040t,
            NEW1_041,
            OG_006,
            OG_006a,
            OG_006b,
            OG_023,
            OG_023t,
            OG_024,
            OG_026,
            OG_027,
            OG_028,
            OG_031,
            OG_031a,
            OG_033,
            OG_034,
            OG_042,
            OG_044,
            OG_044a,
            OG_044b,
            OG_044c,
            OG_045,
            OG_045a,
            OG_047,
            OG_047a,
            OG_047b,
            OG_047e,
            OG_048,
            OG_048e,
            OG_051,
            OG_051e,
            OG_058,
            OG_061,
            OG_061t,
            OG_070,
            OG_070e,
            OG_072,
            OG_073,
            OG_080,
            OG_080ae,
            OG_080b,
            OG_080c,
            OG_080d,
            OG_080de,
            OG_080e,
            OG_080ee,
            OG_080f,
            OG_081,
            OG_082,
            OG_083,
            OG_085,
            OG_086,
            OG_087,
            OG_090,
            OG_094,
            OG_094e,
            OG_096,
            OG_100,
            OG_101,
            OG_102,
            OG_102e,
            OG_104,
            OG_104e,
            OG_109,
            OG_113,
            OG_113e,
            OG_114,
            OG_114a,
            OG_116,
            OG_118,
            OG_118e,
            OG_118f,
            OG_120,
            OG_121,
            OG_121e,
            OG_122,
            OG_123,
            OG_123e,
            OG_131,
            OG_133,
            OG_134,
            OG_138,
            OG_138e,
            OG_141,
            OG_142,
            OG_145,
            OG_147,
            OG_149,
            OG_150,
            OG_150e,
            OG_151,
            OG_152,
            OG_153,
            OG_156,
            OG_156a,
            OG_158,
            OG_158e,
            OG_161,
            OG_162,
            OG_173,
            OG_173a,
            OG_174,
            OG_174e,
            OG_176,
            OG_179,
            OG_188,
            OG_188e,
            OG_195,
            OG_195a,
            OG_195b,
            OG_195c,
            OG_195e,
            OG_198,
            OG_200,
            OG_200e,
            OG_202,
            OG_202a,
            OG_202ae,
            OG_202b,
            OG_202c,
            OG_206,
            OG_207,
            OG_209,
            OG_211,
            OG_216,
            OG_216a,
            OG_218,
            OG_218e,
            OG_220,
            OG_221,
            OG_222,
            OG_222e,
            OG_223,
            OG_223e,
            OG_229,
            OG_234,
            OG_239,
            OG_241,
            OG_241a,
            OG_247,
            OG_248,
            OG_249,
            OG_249a,
            OG_254,
            OG_254e,
            OG_255,
            OG_256,
            OG_256e,
            OG_267,
            OG_267e,
            OG_270a,
            OG_271,
            OG_271e,
            OG_272,
            OG_272t,
            OG_273,
            OG_276,
            OG_279,
            OG_280,
            OG_281,
            OG_281e,
            OG_282,
            OG_282e,
            OG_283,
            OG_284,
            OG_284e,
            OG_286,
            OG_290,
            OG_290e,
            OG_291,
            OG_291e,
            OG_292,
            OG_292e,
            OG_293,
            OG_293e,
            OG_293f,
            OG_295,
            OG_300,
            OG_300e,
            OG_301,
            OG_302,
            OG_302e,
            OG_303,
            OG_303e,
            OG_308,
            OG_309,
            OG_310,
            OG_311,
            OG_311e,
            OG_312,
            OG_312e,
            OG_313,
            OG_313e,
            OG_314,
            OG_314b,
            OG_315,
            OG_315e,
            OG_316,
            OG_316k,
            OG_317,
            OG_318,
            OG_318t,
            OG_319,
            OG_320,
            OG_320e,
            OG_321,
            OG_321e,
            OG_322,
            OG_323,
            OG_325,
            OG_326,
            OG_327,
            OG_328,
            OG_330,
            OG_334,
            OG_335,
            OG_337,
            OG_337e,
            OG_338,
            OG_339,
            OG_339e,
            OG_340,
            PART_001,
            PART_001e,
            PART_002,
            PART_003,
            PART_004,
            PART_004e,
            PART_005,
            PART_006,
            PART_006a,
            PART_007,
            PART_007e,
            PRO_001,
            PRO_001a,
            PRO_001at,
            PRO_001b,
            PRO_001c,
            skele11,
            skele21,
            TagTeamIceBlock,
            TB_001,
            TB_006,
            TB_006e,
            TB_007,
            TB_007e,
            TB_008,
            TB_009,
            TB_010,
            TB_010e,
            TB_011,
            TB_012,
            TB_014,
            TB_015,
            TB_100th_001,
            TB_100th_BananaPlayerEnchant,
            TB_AllMinionsTauntCharge,
            TB_BlingBrawl_Blade1e,
            TB_BlingBrawl_Blade2e,
            TB_BlingBrawl_Hero1e,
            TB_BlingBrawl_Hero1p,
            TB_BlingBrawl_Weapon,
            TB_Blizzcon2016_GoonsEnchant,
            TB_Blizzcon2016_KabalEnchant,
            TB_Blizzcon2016_LotusEnchant,
            TB_BoomAnnoy_001e,
            TB_BoomBotFestival_001e,
            TB_BossRumble_001,
            TB_BossRumble_001hp,
            TB_BossRumble_002,
            TB_BossRumble_002hp,
            TB_BossRumble_003,
            TB_BossRumble_003hp,
            TB_BossRumble001hpe,
            TB_BRMA01_2H_2,
            TB_BRMA10_3H,
            TB_ClassRandom_Druid,
            TB_ClassRandom_Hunter,
            TB_ClassRandom_Mage,
            TB_ClassRandom_Paladin,
            TB_ClassRandom_Pick2nd_100th,
            TB_ClassRandom_PickSecondClass,
            TB_ClassRandom_Priest,
            TB_ClassRandom_Rogue,
            TB_ClassRandom_Shaman,
            TB_ClassRandom_Warlock,
            TB_ClassRandom_Warrior,
            TB_CoOp_Mechazod_OLD,
            TB_CoOp_Mechazod_V2,
            TB_CoOp_Mechazod2,
            TB_CoOpBossSpell_1,
            TB_CoOpBossSpell_2,
            TB_CoOpBossSpell_3,
            TB_CoOpBossSpell_4,
            TB_CoOpBossSpell_5,
            TB_CoOpBossSpell_6,
            TB_CoopHero_001,
            TB_CoopHero_002,
            TB_CoopHero_H_001,
            TB_CoopHero_HP_001,
            TB_CoOpv3_001,
            TB_CoOpv3_002,
            TB_CoOpv3_003,
            TB_CoOpv3_004,
            TB_CoOpv3_005,
            TB_CoOpv3_006,
            TB_CoOpv3_007,
            TB_CoOpv3_008,
            TB_CoOpv3_009,
            TB_CoOpv3_009e,
            TB_Coopv3_009t,
            TB_CoOpv3_010,
            TB_CoOpv3_011,
            TB_CoOpv3_012,
            TB_CoOpv3_013,
            TB_Coopv3_100,
            TB_Coopv3_101,
            TB_CoOpv3_101e,
            TB_Coopv3_102,
            TB_Coopv3_102a,
            TB_Coopv3_102b,
            TB_Coopv3_103,
            TB_Coopv3_104,
            TB_Coopv3_104_NewClasses,
            TB_CoOpv3_104e,
            TB_Coopv3_105,
            TB_CoOpv3_200,
            TB_CoOpv3_201,
            TB_CoOpv3_202,
            TB_CoOpv3_203,
            TB_CoOpv3_Boss,
            TB_CoOpv3_Boss_FB,
            TB_CoOpv3_Boss_NewClasses,
            TB_CoOpv3_BOSS2e,
            TB_CoOpv3_BOSS3e,
            TB_CoOpv3_BOSS4e,
            TB_CoOpv3_BOSSe,
            TB_DeckRecipe_MyDeckID,
            TB_DiscoverMyDeck_Discovery,
            TB_DiscoverMyDeck_Enchantment,
            TB_Dorothee_001,
            TB_EndlessMinions01,
            TB_Face_Ench1,
            TB_FireFestEnch,
            TB_FireFestival_Brazier,
            TB_FireFestival_Fireworks,
            TB_FireFestival_MRag,
            TB_Frost_Rag,
            TB_FW_DrBoomMega,
            TB_FW_ImbaTron,
            TB_FW_Mortar,
            TB_FW_OmegaMax,
            TB_FW_Rag,
            TB_FW_Warper,
            TB_GiftExchange_Enchantment,
            TB_GiftExchange_Snowball,
            TB_GiftExchange_Treasure,
            TB_GiftExchange_Treasure_Spell,
            TB_GP_01e,
            TB_GP_01e_copy1,
            TB_GP_01e_v2,
            TB_GP_03,
            TB_GreatCurves_01,
            TB_KaraPortal_001,
            TB_KaraPortal_002,
            TB_KaraPortal_003,
            TB_KaraPortals_003,
            TB_KTRAF_08w,
            TB_KTRAF_1,
            TB_KTRAF_10,
            TB_KTRAF_101,
            TB_KTRAF_104,
            TB_KTRAF_10e,
            TB_KTRAF_11,
            TB_KTRAF_12,
            TB_KTRAF_2,
            TB_KTRAF_2s,
            TB_KTRAF_3,
            TB_KTRAF_4,
            TB_KTRAF_4m,
            TB_KTRAF_5,
            TB_KTRAF_6,
            TB_KTRAF_6m,
            TB_KTRAF_7,
            TB_KTRAF_8,
            TB_KTRAF_H_1,
            TB_KTRAF_H_2,
            TB_KTRAF_HP_KT_3,
            TB_KTRAF_HP_RAF3,
            TB_KTRAF_HP_RAF4,
            TB_KTRAF_HP_RAF5,
            TB_KTRAF_Under,
            TB_Lethal002,
            TB_Lethal003,
            TB_Lethal004,
            TB_Lethal005,
            TB_Lethal006,
            TB_Lethal007,
            TB_Lethal008,
            TB_Lethal009,
            TB_Lethal010,
            TB_LethalSetup001a,
            TB_LethalSetup001b,
            TB_LethalSetup02,
            TB_LevelUp_001,
            TB_LevelUp_002,
            TB_LOEA13_2,
            TB_MammothParty_301,
            TB_MammothParty_302,
            TB_MammothParty_303,
            TB_MammothParty_Boss002,
            TB_MammothParty_hp001,
            TB_MammothParty_hp002,
            TB_MammothParty_m001,
            TB_MammothParty_m001_alt,
            TB_MammothParty_s002ee,
            TB_MammothParty_s004,
            TB_MammothParty_s101,
            TB_MammothParty_s101a,
            TB_MammothParty_s101b,
            TB_MammothParty_s998,
            TB_MechWar_Boss1,
            TB_MechWar_Boss1_HeroPower,
            TB_MechWar_Boss2,
            TB_MechWar_Boss2_HeroPower,
            TB_MechWar_CommonCards,
            TB_MechWar_Minion1,
            TB_Mini_1e,
            TB_MnkWf01,
            TB_MP_01e,
            TB_MP_02e,
            TB_OG_027,
            TB_PickYourFate,
            TB_PickYourFate_1,
            TB_PickYourFate_1_Ench,
            TB_PickYourFate_10,
            TB_PickYourFate_10_Ench,
            TB_PickYourFate_10_EnchMinion,
            TB_PickYourFate_11_Ench,
            TB_PickYourFate_11b,
            TB_PickYourFate_11rand,
            TB_PickYourFate_12,
            TB_PickYourFate_12_Ench,
            TB_PickYourFate_2,
            TB_PickYourFate_2_Ench,
            TB_PickYourFate_2_EnchMinion,
            TB_PickYourFate_2nd,
            TB_PickYourFate_3,
            TB_PickYourFate_3_Ench,
            TB_PickYourFate_4,
            TB_PickYourFate_4_Ench,
            TB_PickYourFate_4_EnchMinion,
            TB_PickYourFate_5,
            TB_PickYourFate_5_Ench,
            TB_PickYourFate_6,
            TB_PickYourFate_6_2nd,
            TB_PickYourFate_7,
            TB_PickYourFate_7_2nd,
            TB_PickYourFate_7_Ench_2nd,
            TB_PickYourFate_7_EnchMiniom2nd,
            TB_PickYourFate_7_EnchMinion,
            TB_PickYourFate_8,
            TB_PickYourFate_8_Ench,
            TB_PickYourFate_8_EnchRand,
            TB_PickYourFate_8rand,
            TB_PickYourFate_9,
            TB_PickYourFate_9_Ench,
            TB_PickYourFate_9_EnchMinion,
            TB_PickYourFate_Confused,
            TB_PickYourFate_Windfury,
            TB_PickYourFate7Ench,
            TB_PickYourFateRandom,
            TB_Pilot1,
            TB_Presents_001,
            TB_Presents_002,
            TB_Presents_003,
            TB_RandCardCost,
            TB_RandHero2_001,
            TB_RMC_001,
            TB_Spellwrite_001,
            TB_SPT_Boss,
            TB_SPT_BossHeroPower,
            TB_SPT_BossWeapon,
            TB_SPT_DPromo_EnterPortal,
            TB_SPT_DPromo_Hero,
            TB_SPT_DPromo_Hero2,
            TB_SPT_DPromoCrate1,
            TB_SPT_DPromoCrate2,
            TB_SPT_DPromoCrate3,
            TB_SPT_DPromoEnch3,
            TB_SPT_DpromoEX1_312,
            TB_SPT_DPromoHP,
            TB_SPT_DPromoHP2,
            TB_SPT_DPromoMinion,
            TB_SPT_DPromoMinion2,
            TB_SPT_DPromoMinionChamp,
            TB_SPT_DPromoMinionInit,
            TB_SPT_DpromoPortal,
            TB_SPT_DPromoSecre8,
            TB_SPT_DPromoSecre8e,
            TB_SPT_DPromoSecret1,
            TB_SPT_DPromoSecret10,
            TB_SPT_DPromoSecret2,
            TB_SPT_DPromoSecret3,
            TB_SPT_DPromoSecret4,
            TB_SPT_DPromoSecret5,
            TB_SPT_DPromoSecret6,
            TB_SPT_DPromoSecret7,
            TB_SPT_DPromoSecret9,
            TB_SPT_DPromoSecret9e,
            TB_SPT_DPromoSpell1,
            TB_SPT_DPromoSpell2,
            TB_SPT_DPromoSpellBovine1,
            TB_SPT_DPromoSpellBovine1e,
            TB_SPT_DPromoSpellPortal,
            TB_SPT_DPromoSpellPortal2,
            TB_SPT_Minion1,
            TB_SPT_Minion1e,
            TB_SPT_Minion2,
            TB_SPT_Minion2e,
            TB_SPT_Minion3,
            TB_SPT_Minion3e,
            TB_SPT_MTH_Boss,
            TB_SPT_MTH_Boss0,
            TB_SPT_MTH_Boss2,
            TB_SPT_MTH_Boss3,
            TB_SPT_MTH_BossHeroPower,
            TB_SPT_MTH_BossWeapon,
            TB_SPT_MTH_Minion1,
            TB_SPT_MTH_Minion2,
            TB_SPT_MTH_Minion3,
            TB_Superfriends001,
            TB_Superfriends001e,
            TB_Superfriends002e,
            TB_SwapBossHeroPowerByClass,
            TB_SwapHeroWithDeathKnight,
            TB_TagTeam,
            TB_TagTeam_ClearBoard,
            TB_TagTeam_Druid,
            TB_TagTeam_GetClass,
            TB_TagTeam_Hunter,
            TB_TagTeam_Mage,
            TB_TagTeam_NewHeroCards,
            TB_TagTeam_Paladin,
            TB_TagTeam_Priest,
            TB_TagTeam_Rogue,
            TB_TagTeam_Shaman,
            TB_TagTeam_Warlock,
            TB_TagTeam_Warrior,
            TB_YoggServant_Enchant,
            TBA01_1,
            TBA01_4,
            TBA01_5,
            TBA01_6,
            TBST_001,
            TBST_002,
            TBST_003,
            TBST_004,
            TBST_005,
            TBST_006,
            TBUD_1,
            TP_Bling_HP2,
            tt_004,
            tt_004o,
            tt_010,
            tt_010a,
            TU4a_001,
            TU4a_002,
            TU4a_003,
            TU4a_004,
            TU4a_005,
            TU4a_006,
            TU4b_001,
            TU4c_001,
            TU4c_002,
            TU4c_003,
            TU4c_004,
            TU4c_005,
            TU4c_006,
            TU4c_006e,
            TU4c_007,
            TU4c_008,
            TU4c_008e,
            TU4d_001,
            TU4d_002,
            TU4d_003,
            TU4e_001,
            TU4e_002,
            TU4e_002t,
            TU4e_003,
            TU4e_004,
            TU4e_005,
            TU4e_007,
            TU4f_001,
            TU4f_002,
            TU4f_003,
            TU4f_004,
            TU4f_004o,
            TU4f_005,
            TU4f_006,
            TU4f_006o,
            TU4f_007,
            UNG_001,
            UNG_002,
            UNG_004,
            UNG_004e,
            UNG_009,
            UNG_010,
            UNG_011,
            UNG_015,
            UNG_015e,
            UNG_018,
            UNG_019,
            UNG_020,
            UNG_021,
            UNG_022,
            UNG_022e,
            UNG_024,
            UNG_025,
            UNG_027,
            UNG_027t2,
            UNG_027t4,
            UNG_028,
            UNG_028e,
            UNG_028t,
            UNG_029,
            UNG_030,
            UNG_032,
            UNG_034,
            UNG_035,
            UNG_037,
            UNG_037e,
            UNG_047,
            UNG_049,
            UNG_057,
            UNG_057t1,
            UNG_058,
            UNG_060,
            UNG_061,
            UNG_063,
            UNG_063e,
            UNG_064,
            UNG_065,
            UNG_065t,
            UNG_067,
            UNG_067t1,
            UNG_067t1e,
            UNG_067t1e2,
            UNG_070,
            UNG_070e,
            UNG_071,
            UNG_072,
            UNG_073,
            UNG_073e,
            UNG_075,
            UNG_076,
            UNG_076t1,
            UNG_078,
            UNG_079,
            UNG_082,
            UNG_083,
            UNG_083t1,
            UNG_084,
            UNG_085,
            UNG_086,
            UNG_087,
            UNG_088,
            UNG_089,
            UNG_099,
            UNG_100,
            UNG_101,
            UNG_101a,
            UNG_101b,
            UNG_101t,
            UNG_101t2,
            UNG_101t3,
            UNG_103,
            UNG_108,
            UNG_108e,
            UNG_109,
            UNG_111,
            UNG_111t1,
            UNG_113,
            UNG_113e,
            UNG_116,
            UNG_116t,
            UNG_116te,
            UNG_201,
            UNG_201t,
            UNG_202,
            UNG_205,
            UNG_208,
            UNG_208t,
            UNG_211,
            UNG_211a,
            UNG_211aa,
            UNG_211b,
            UNG_211c,
            UNG_211d,
            UNG_800,
            UNG_801,
            UNG_803,
            UNG_806,
            UNG_807,
            UNG_807e,
            UNG_808,
            UNG_809,
            UNG_809t1,
            UNG_810,
            UNG_812,
            UNG_813,
            UNG_814,
            UNG_816,
            UNG_817,
            UNG_818,
            UNG_823,
            UNG_823e,
            UNG_829,
            UNG_829t1,
            UNG_829t2,
            UNG_829t3,
            UNG_830,
            UNG_831,
            UNG_831e,
            UNG_832,
            UNG_832e,
            UNG_833,
            UNG_834,
            UNG_834t1,
            UNG_835,
            UNG_836,
            UNG_836e,
            UNG_838,
            UNG_840,
            UNG_843,
            UNG_844,
            UNG_845,
            UNG_846,
            UNG_847,
            UNG_848,
            UNG_851,
            UNG_851t1,
            UNG_852,
            UNG_854,
            UNG_856,
            UNG_900,
            UNG_907,
            UNG_907e,
            UNG_910,
            UNG_912,
            UNG_913,
            UNG_914,
            UNG_914t1,
            UNG_915,
            UNG_916,
            UNG_916e,
            UNG_917,
            UNG_917e,
            UNG_917t1,
            UNG_919,
            UNG_920,
            UNG_920t1,
            UNG_920t2,
            UNG_922,
            UNG_922t1,
            UNG_923,
            UNG_925,
            UNG_926,
            UNG_927,
            UNG_928,
            UNG_929,
            UNG_929e,
            UNG_933,
            UNG_934,
            UNG_934t1,
            UNG_934t2,
            UNG_937,
            UNG_938,
            UNG_940,
            UNG_940t8,
            UNG_941,
            UNG_941e,
            UNG_942,
            UNG_942t,
            UNG_946,
            UNG_948,
            UNG_950,
            UNG_952,
            UNG_952e,
            UNG_953,
            UNG_953e,
            UNG_954,
            UNG_954t1,
            UNG_955,
            UNG_956,
            UNG_956e,
            UNG_957,
            UNG_957t1,
            UNG_960,
            UNG_961,
            UNG_962,
            UNG_963,
            UNG_999t10,
            UNG_999t10e,
            UNG_999t13,
            UNG_999t13e,
            UNG_999t14,
            UNG_999t14e,
            UNG_999t2,
            UNG_999t2e,
            UNG_999t2t1,
            UNG_999t3,
            UNG_999t3e,
            UNG_999t4,
            UNG_999t4e,
            UNG_999t5,
            UNG_999t5e,
            UNG_999t6,
            UNG_999t6e,
            UNG_999t7,
            UNG_999t7e,
            UNG_999t8,
            UNG_999t8e,
            BOT_020,
            BOT_020e,
            BOT_021,
            BOT_021e,
            BOT_031,
            BOT_033,
            BOT_034,
            BOT_035,
            BOT_035e,
            BOT_038,
            BOT_038e,
            BOT_039,
            BOT_039e,
            BOT_042,
            BOT_042t,
            BOT_050,
            BOT_054,
            BOT_059,
            BOT_066,
            BOT_066t,
            BOT_067,
            BOT_067e,
            BOT_069,
            BOT_069e,
            BOT_079,
            BOT_079e,
            BOT_083,
            BOT_083e,
            BOT_084,
            BOT_087,
            BOT_087e,
            BOT_093,
            BOT_098,
            BOT_099,
            BOT_101,
            BOT_101e2,
            BOT_102,
            BOT_102t,
            BOT_103,
            BOT_104,
            BOT_107,
            BOT_107e,
            BOT_216,
            BOT_218,
            BOT_218t,
            BOT_219,
            BOT_219e,
            BOT_219t,
            BOT_219te,
            BOT_222,
            BOT_224,
            BOT_226,
            BOT_226e,
            BOT_234,
            BOT_234e,
            BOT_236,
            BOT_237,
            BOT_237e,
            BOT_238,
            BOT_238e,
            BOT_238e2,
            BOT_238p,
            BOT_238p1,
            BOT_238p2,
            BOT_238p3,
            BOT_238p4,
            BOT_238p6,
            BOT_242,
            BOT_243,
            BOT_243e,
            BOT_245,
            BOT_246,
            BOT_251,
            BOT_251e,
            BOT_254,
            BOT_256,
            BOT_257,
            BOT_257e,
            BOT_258,
            BOT_258e,
            BOT_263,
            BOT_263e,
            BOT_267,
            BOT_270,
            BOT_270t,
            BOT_280,
            BOT_280e,
            BOT_283,
            BOT_283e,
            BOT_286,
            BOT_288,
            BOT_291,
            BOT_296,
            BOT_296e,
            BOT_299,
            BOT_308,
            BOT_309,
            BOT_312,
            BOT_312e,
            BOT_312t,
            BOT_401,
            BOT_402,
            BOT_404,
            BOT_406,
            BOT_407,
            BOT_411,
            BOT_411e,
            BOT_411e2,
            BOT_413,
            BOT_413e,
            BOT_414,
            BOT_419,
            BOT_420,
            BOT_422,
            BOT_422a,
            BOT_422ae,
            BOT_422b,
            BOT_423,
            BOT_423e,
            BOT_424,
            BOT_429,
            BOT_431,
            BOT_433,
            BOT_434,
            BOT_434e,
            BOT_434e2,
            BOT_435,
            BOT_436,
            BOT_436e,
            BOT_437,
            BOT_437e,
            BOT_438,
            BOT_438e,
            BOT_443,
            BOT_443e,
            BOT_444,
            BOT_444e,
            BOT_445,
            BOT_445t,
            BOT_447,
            BOT_448,
            BOT_451,
            BOT_453,
            BOT_507,
            BOT_508,
            BOT_509,
            BOT_511,
            BOT_511t,
            BOT_517,
            BOT_517e,
            BOT_521,
            BOT_523,
            BOT_529,
            BOT_529e,
            BOT_531,
            BOT_531e,
            BOT_531e2,
            BOT_532,
            BOT_533,
            BOT_534,
            BOT_535,
            BOT_536,
            BOT_537,
            BOT_537t,
            BOT_538,
            BOT_539,
            BOT_540,
            BOT_543,
            BOT_543e,
            BOT_544,
            BOT_548,
            BOT_548e,
            BOT_550,
            BOT_550e,
            BOT_552,
            BOT_555,
            BOT_558,
            BOT_558e,
            BOT_559,
            BOT_559e,
            BOT_562,
            BOT_562e,
            BOT_563,
            BOT_563e,
            BOT_565,
            BOT_565t,
            BOT_566,
            BOT_566e,
            BOT_566e2,
            BOT_567,
            BOT_567e,
            BOT_568,
            BOT_568e,
            BOT_573,
            BOT_576,
            BOT_576e,
            BOT_600,
            BOT_601,
            BOT_603,
            BOT_604,
            BOT_606,
            BOT_906,
            BOT_906e,
            BOT_907,
            BOT_907e,
            BOT_908,
            BOT_909,
            BOT_910,
            BOT_910e,
            BOT_911,
            BOT_911e,
            BOT_912,
            BOT_913,
            BOT_914,
            BOT_914h,
            GIL_000,
            GIL_113,
            GIL_116,
            GIL_117,
            GIL_118,
            GIL_119,
            GIL_119e,
            GIL_120,
            GIL_121,
            GIL_124,
            GIL_125,
            GIL_125e,
            GIL_128,
            GIL_128e,
            GIL_130,
            GIL_130e,
            GIL_134,
            GIL_142,
            GIL_142e,
            GIL_143,
            GIL_145,
            GIL_145e,
            GIL_147,
            GIL_152,
            GIL_155,
            GIL_155e,
            GIL_156,
            GIL_188,
            GIL_188a,
            GIL_188b,
            GIL_188t,
            GIL_188t2,
            GIL_188t3,
            GIL_190,
            GIL_190t,
            GIL_191,
            GIL_191t,
            GIL_198,
            GIL_200,
            GIL_200e,
            GIL_200t,
            GIL_201,
            GIL_201t,
            GIL_202,
            GIL_202t,
            GIL_203,
            GIL_203e,
            GIL_207,
            GIL_212,
            GIL_213,
            GIL_504,
            GIL_504h,
            GIL_506,
            GIL_507,
            GIL_507e,
            GIL_508,
            GIL_508t,
            GIL_510,
            GIL_510e,
            GIL_513,
            GIL_513e,
            GIL_515,
            GIL_515e,
            GIL_518,
            GIL_526,
            GIL_526e,
            GIL_527,
            GIL_528,
            GIL_528t,
            GIL_529,
            GIL_529t,
            GIL_530,
            GIL_531,
            GIL_534,
            GIL_534t,
            GIL_537,
            GIL_543,
            GIL_545,
            GIL_547,
            GIL_547e,
            GIL_548,
            GIL_549,
            GIL_553,
            GIL_553t,
            GIL_557,
            GIL_558,
            GIL_561,
            GIL_562,
            GIL_565,
            GIL_571,
            GIL_577,
            GIL_577t,
            GIL_578,
            GIL_580,
            GIL_581,
            GIL_583,
            GIL_583e,
            GIL_584,
            GIL_586,
            GIL_586e,
            GIL_596,
            GIL_596e,
            GIL_598,
            GIL_600,
            GIL_601,
            GIL_601e,
            GIL_607,
            GIL_607e,
            GIL_607t,
            GIL_608,
            GIL_608e,
            GIL_614,
            GIL_614e1,
            GIL_614e2,
            GIL_616,
            GIL_616t,
            GIL_616t2,
            GIL_618,
            GIL_618e,
            GIL_620,
            GIL_620e,
            GIL_622,
            GIL_623,
            GIL_623e,
            GIL_624,
            GIL_624e,
            GIL_634,
            GIL_635,
            GIL_637,
            GIL_640,
            GIL_640e,
            GIL_645,
            GIL_646,
            GIL_648,
            GIL_650,
            GIL_650e,
            GIL_653,
            GIL_653e,
            GIL_654,
            GIL_655,
            GIL_655e,
            GIL_658,
            GIL_658e,
            GIL_661,
            GIL_663,
            GIL_663t,
            GIL_664,
            GIL_665,
            GIL_665e,
            GIL_667,
            GIL_672,
            GIL_672e,
            GIL_677,
            GIL_678,
            GIL_680,
            GIL_681,
            GIL_682,
            GIL_682t,
            GIL_683,
            GIL_683t,
            GIL_685,
            GIL_687,
            GIL_691,
            GIL_692,
            GIL_692e,
            GIL_693,
            GIL_694,
            GIL_696,
            GIL_800,
            GIL_800e2,
            GIL_801,
            GIL_803,
            GIL_803e,
            GIL_805,
            GIL_807,
            GIL_809,
            GIL_813,
            GIL_815,
            GIL_816,
            GIL_817,
            GIL_819,
            GIL_820,
            GIL_825,
            GIL_826,
            GIL_827,
            GIL_828,
            GIL_828e,
            GIL_833,
            GIL_835,
            GIL_836,
            GIL_837,
            GIL_837e,
            GIL_838,
            GIL_840,
            GIL_840e,
            GIL_902,
            GIL_902e,
            GIL_903,
            GIL_905,
            GIL_905e,
            LOOT_008,
            LOOT_010e,
            LOOT_013,
            LOOT_014,
            LOOT_017,
            LOOT_018,
            LOOT_018e,
            LOOT_026,
            LOOT_026e,
            LOOT_026t,
            LOOT_033,
            LOOT_041,
            LOOT_043,
            LOOT_043t2,
            LOOT_043t3,
            LOOT_044,
            LOOT_047,
            LOOT_047e,
            LOOT_048,
            LOOT_051,
            LOOT_051t1,
            LOOT_051t2,
            LOOT_054,
            LOOT_054b,
            LOOT_054be,
            LOOT_054c,
            LOOT_054d,
            LOOT_056,
            LOOT_060,
            LOOT_062,
            LOOT_064,
            LOOT_064t1,
            LOOT_064t2,
            LOOT_069,
            LOOT_069t,
            LOOT_077,
            LOOT_077t,
            LOOT_078,
            LOOT_079,
            LOOT_080,
            LOOT_080t2,
            LOOT_080t3,
            LOOT_085,
            LOOT_088,
            LOOT_091,
            LOOT_091t,
            LOOT_091t1,
            LOOT_091t1t,
            LOOT_091t2,
            LOOT_091t2t,
            LOOT_093,
            LOOT_101,
            LOOT_103,
            LOOT_103t1,
            LOOT_103t2,
            LOOT_104,
            LOOT_104e,
            LOOT_106,
            LOOT_106t,
            LOOT_108,
            LOOT_111,
            LOOT_117,
            LOOT_118,
            LOOT_118e,
            LOOT_122,
            LOOT_124,
            LOOT_124e,
            LOOT_125,
            LOOT_130,
            LOOT_131,
            LOOT_131t1,
            LOOT_132,
            LOOT_134,
            LOOT_134e,
            LOOT_136,
            LOOT_136e,
            LOOT_137,
            LOOT_144,
            LOOT_149,
            LOOT_149e,
            LOOT_150,
            LOOT_150t1,
            LOOT_152,
            LOOT_152e,
            LOOT_153,
            LOOT_153t1,
            LOOT_154,
            LOOT_161,
            LOOT_161e,
            LOOT_165,
            LOOT_165e,
            LOOT_167,
            LOOT_167e,
            LOOT_170,
            LOOT_172,
            LOOT_184,
            LOOT_187,
            LOOT_187e,
            LOOT_193,
            LOOT_203,
            LOOT_203t2,
            LOOT_203t3,
            LOOT_203t4,
            LOOT_204,
            LOOT_204e,
            LOOT_209,
            LOOT_209t,
            LOOT_210,
            LOOT_211,
            LOOT_214,
            LOOT_214e,
            LOOT_216,
            LOOT_216e,
            LOOT_217,
            LOOT_218,
            LOOT_222,
            LOOT_231,
            LOOT_233,
            LOOT_233t,
            LOOT_258,
            LOOT_278,
            LOOT_278e,
            LOOT_278t1,
            LOOT_278t1e,
            LOOT_278t2,
            LOOT_278t2e,
            LOOT_278t3,
            LOOT_278t3e,
            LOOT_278t3e2,
            LOOT_278t4,
            LOOT_278t4e,
            LOOT_285,
            LOOT_285t,
            LOOT_285t2,
            LOOT_285t3,
            LOOT_285t3t,
            LOOT_285t4,
            LOOT_285t4t,
            LOOT_286,
            LOOT_286t1,
            LOOT_286t2,
            LOOT_286t2e,
            LOOT_286t3,
            LOOT_286t3e,
            LOOT_286t4,
            LOOT_291,
            LOOT_306,
            LOOT_309,
            LOOT_313,
            LOOT_314,
            LOOT_315,
            LOOT_329,
            LOOT_333,
            LOOT_333e,
            LOOT_344,
            LOOT_344e,
            LOOT_347,
            LOOT_351,
            LOOT_353,
            LOOT_357,
            LOOT_357l,
            LOOT_358,
            LOOT_358e,
            LOOT_363,
            LOOT_364,
            LOOT_365,
            LOOT_367,
            LOOT_368,
            LOOT_370,
            LOOT_373,
            LOOT_375,
            LOOT_380,
            LOOT_382,
            LOOT_383,
            LOOT_388,
            LOOT_389,
            LOOT_392,
            LOOT_394,
            LOOT_398,
            LOOT_410,
            LOOT_412,
            LOOT_412e,
            LOOT_413,
            LOOT_414,
            LOOT_415,
            LOOT_415t1,
            LOOT_415t1t,
            LOOT_415t2,
            LOOT_415t2t,
            LOOT_415t3,
            LOOT_415t3t,
            LOOT_415t4,
            LOOT_415t4t,
            LOOT_415t5,
            LOOT_415t5t,
            LOOT_415t6,
            LOOT_417,
            LOOT_420,
            LOOT_440e,
            LOOT_500,
            LOOT_500d,
            LOOT_500e,
            LOOT_503,
            LOOT_503t,
            LOOT_503t2,
            LOOT_504,
            LOOT_504t,
            LOOT_506,
            LOOT_507,
            LOOT_507t,
            LOOT_507t2,
            LOOT_511,
            LOOT_516,
            LOOT_517,
            LOOT_517e,
            LOOT_517e2,
            LOOT_518,
            LOOT_519,
            LOOT_520,
            LOOT_520e,
            LOOT_521,
            LOOT_522,
            LOOT_526,
            LOOT_526d,
            LOOT_526et,
            LOOT_526t,
            LOOT_528,
            LOOT_528e,
            LOOT_529,
            LOOT_529e,
            LOOT_534,
            LOOT_535,
            LOOT_535t,
            LOOT_537,
            LOOT_538,
            LOOT_539,
            LOOT_540,
            LOOT_541,
            LOOT_541t,
            LOOT_542,
            LOOT_542e,
            LOOT_998h,
            LOOT_998j,
            LOOT_998k,
            LOOT_998l,
            LOOT_998le,
            TRL_010,
            TRL_012,
            TRL_015,
            TRL_020,
            TRL_020t,
            TRL_057,
            TRL_058,
            TRL_058e,
            TRL_059,
            TRL_059e,
            TRL_060,
            TRL_065,
            TRL_065h,
            TRL_071,
            TRL_071e,
            TRL_074,
            TRL_074e,
            TRL_077,
            TRL_077e,
            TRL_082,
            TRL_082e,
            TRL_085,
            TRL_085e,
            TRL_092,
            TRL_092e,
            TRL_096,
            TRL_096e,
            TRL_097,
            TRL_111,
            TRL_111e1,
            TRL_119,
            TRL_119e,
            TRL_124,
            TRL_126,
            TRL_127,
            TRL_128,
            TRL_131,
            TRL_131t,
            TRL_151,
            TRL_151t,
            TRL_156,
            TRL_157,
            TRL_223,
            TRL_232,
            TRL_232t,
            TRL_240,
            TRL_241,
            TRL_243,
            TRL_243e,
            TRL_244,
            TRL_244e,
            TRL_245,
            TRL_246,
            TRL_247,
            TRL_249,
            TRL_249e,
            TRL_251,
            TRL_251e,
            TRL_252,
            TRL_253,
            TRL_254,
            TRL_254a,
            TRL_254ae,
            TRL_254b,
            TRL_254t,
            TRL_255,
            TRL_255e,
            TRL_257,
            TRL_258,
            TRL_259,
            TRL_260,
            TRL_300,
            TRL_302,
            TRL_302e,
            TRL_304,
            TRL_304e,
            TRL_305,
            TRL_306,
            TRL_307,
            TRL_308,
            TRL_309,
            TRL_309t,
            TRL_310,
            TRL_310e,
            TRL_311,
            TRL_312,
            TRL_312e,
            TRL_313,
            TRL_315,
            TRL_316,
            TRL_316t,
            TRL_317,
            TRL_318,
            TRL_319,
            TRL_319e,
            TRL_321,
            TRL_323,
            TRL_324,
            TRL_325,
            TRL_326,
            TRL_327,
            TRL_327e,
            TRL_328,
            TRL_329,
            TRL_329e,
            TRL_339,
            TRL_341,
            TRL_341t,
            TRL_343,
            TRL_343at1,
            TRL_343at2,
            TRL_343bt1,
            TRL_343bt2,
            TRL_343ct1,
            TRL_343ct2,
            TRL_343dt1,
            TRL_343dt2,
            TRL_343et1,
            TRL_345,
            TRL_347,
            TRL_347t,
            TRL_348,
            TRL_348t,
            TRL_349,
            TRL_351,
            TRL_351t,
            TRL_352,
            TRL_360,
            TRL_362,
            TRL_363,
            TRL_363t,
            TRL_390,
            TRL_390e,
            TRL_390e2,
            TRL_400,
            TRL_405,
            TRL_405e,
            TRL_406,
            TRL_406e,
            TRL_407,
            TRL_407e,
            TRL_408,
            TRL_409,
            TRL_409e,
            TRL_500,
            TRL_500e,
            TRL_501,
            TRL_501e,
            TRL_502,
            TRL_502e,
            TRL_503,
            TRL_503t,
            TRL_504,
            TRL_505,
            TRL_505e,
            TRL_506,
            TRL_506e,
            TRL_507,
            TRL_507t,
            TRL_508,
            TRL_509,
            TRL_509t,
            TRL_509te,
            TRL_512,
            TRL_513,
            TRL_514,
            TRL_514e,
            TRL_515,
            TRL_516,
            TRL_517,
            TRL_517e2,
            TRL_520,
            TRL_521,
            TRL_522,
            TRL_523,
            TRL_524,
            TRL_525,
            TRL_526,
            TRL_527,
            TRL_528,
            TRL_528e,
            TRL_530,
            TRL_531,
            TRL_531t,
            TRL_532,
            TRL_533,
            TRL_535,
            TRL_537,
            TRL_537e,
            TRL_541,
            TRL_541t,
            TRL_542,
            TRL_543,
            TRL_545,
            TRL_545e,
            TRL_546,
            TRL_550,
            TRL_551,
            TRL_555,
            TRL_564,
            TRL_566,
            TRL_569,
            TRL_570,
            TRL_900,
            TRL_901,
            TRL_901e,
            DAL_007,
            DAL_008,
            DAL_009,
            DAL_010,
            DAL_011,
            DAL_011e,
            DAL_030,
            DAL_030e,
            DAL_039,
            DAL_040,
            DAL_047,
            DAL_049,
            DAL_052,
            DAL_052e,
            DAL_058,
            DAL_059,
            DAL_060,
            DAL_062,
            DAL_062e,
            DAL_063,
            DAL_064,
            DAL_065,
            DAL_070,
            DAL_070e,
            DAL_071,
            DAL_077,
            DAL_077e,
            DAL_078,
            DAL_081,
            DAL_081e,
            DAL_085,
            DAL_086,
            DAL_086e,
            DAL_087,
            DAL_087t,
            DAL_088,
            DAL_088t2,
            DAL_089,
            DAL_090,
            DAL_092,
            DAL_095,
            DAL_095e,
            DAL_096,
            DAL_141,
            DAL_141ts,
            DAL_146,
            DAL_146t,
            DAL_147,
            DAL_147e,
            DAL_163,
            DAL_173,
            DAL_177,
            DAL_177ts,
            DAL_182,
            DAL_185,
            DAL_256,
            DAL_256t2,
            DAL_256ts,
            DAL_350,
            DAL_350a,
            DAL_350b,
            DAL_351,
            DAL_351e,
            DAL_351ts,
            DAL_352,
            DAL_354,
            DAL_354t,
            DAL_355,
            DAL_357,
            DAL_357t,
            DAL_366,
            DAL_366t1,
            DAL_366t2,
            DAL_366t3,
            DAL_366t4,
            DAL_371,
            DAL_372,
            DAL_373,
            DAL_373ts,
            DAL_376,
            DAL_377,
            DAL_378,
            DAL_378t1,
            DAL_378ts,
            DAL_379,
            DAL_379e,
            DAL_379t,
            DAL_400,
            DAL_413,
            DAL_415,
            DAL_416,
            DAL_417,
            DAL_422,
            DAL_431,
            DAL_431t,
            DAL_432,
            DAL_433,
            DAL_434,
            DAL_538,
            DAL_539,
            DAL_544,
            DAL_546,
            DAL_548,
            DAL_548e,
            DAL_550,
            DAL_551,
            DAL_553,
            DAL_554,
            DAL_554t,
            DAL_558,
            DAL_560,
            DAL_560e2,
            DAL_561,
            DAL_561e,
            DAL_563,
            DAL_563e,
            DAL_565,
            DAL_566,
            DAL_566t,
            DAL_568,
            DAL_568e,
            DAL_568ts,
            DAL_570,
            DAL_570e,
            DAL_571,
            DAL_571e,
            DAL_573,
            DAL_575,
            DAL_576,
            DAL_576e,
            DAL_577,
            DAL_577ts,
            DAL_578,
            DAL_581,
            DAL_582,
            DAL_582t,
            DAL_582t2,
            DAL_587,
            DAL_589,
            DAL_589e,
            DAL_592,
            DAL_602,
            DAL_603,
            DAL_604,
            DAL_605,
            DAL_605e,
            DAL_606,
            DAL_607,
            DAL_607e,
            DAL_608,
            DAL_609,
            DAL_613,
            DAL_614,
            DAL_615,
            DAL_710,
            DAL_710e,
            DAL_714,
            DAL_714e,
            DAL_716,
            DAL_719,
            DAL_720,
            DAL_721,
            DAL_723,
            DAL_724,
            DAL_726,
            DAL_726e,
            DAL_727,
            DAL_727e,
            DAL_728,
            DAL_729,
            DAL_731,
            DAL_732,
            DAL_733,
            DAL_733t,
            DAL_735,
            DAL_736,
            DAL_739,
            DAL_739e,
            DAL_741,
            DAL_742,
            DAL_742e,
            DAL_743,
            DAL_743t,
            DAL_744,
            DAL_744e,
            DAL_747,
            DAL_747t,
            DAL_748,
            DAL_749,
            DAL_751,
            DAL_751t,
            DAL_752,
            DAL_752e,
            DAL_752e2,
            DAL_759,
            DAL_760,
            DAL_769,
            DAL_770,
            DAL_771,
            DAL_773,
            DAL_773e,
            DAL_774,
            DAL_775,
            DAL_799,
        }

        public cardIDEnum cardIdstringToEnum(string s)
        {
            CardDB.cardIDEnum CardEnum;
            if (Enum.TryParse<cardIDEnum>(s, false, out CardEnum)) return CardEnum;
            else
            {
                Triton.Common.LogUtilities.Logger.GetLoggerInstanceForType().ErrorFormat("[Unidentified card ID :" + s + "]");
                return CardDB.cardIDEnum.None;
            }
        }

        public enum cardName
        {
            unknown,
            aarongutierrez,
            aberrantberserker,
            aberration,
            abominablebowman,
            abominableknuckles,
            abomination,
            abusivesergeant,
            abyssal,
            abyssalenforcer,
            acherusveteran,
            acidicswampooze,
            acidmaw,
            acolyteofagony,
            acolyteofpain,
            activate,
            activatearcanotron,
            activateelectron,
            activatemagmatron,
            activatetoxitron,
            adaptation,
            addled,
            addledgrizzly,
            afk,
            afkay,
            aglowingpool,
            aiextra1,
            aiextra2,
            aiextra3,
            airelemental,
            alakirthewindlord,
            alarmobot,
            aldorpeacekeeper,
            alexchapman,
            alexstrasza,
            alexstraszasboon,
            alexstraszaschampion,
            alexstraszasfire,
            alextsang,
            alightinthedarkness,
            alleriawindrunner,
            alleyarmorsmith,
            alleycat,
            almsoflight,
            amaniberserker,
            amarawardenofhope,
            ambercarapace,
            ambush,
            amgamrager,
            ancestorscall,
            ancestralhealing,
            ancestralinfusion,
            ancestralknowledge,
            ancestralspirit,
            ancientbrewmaster,
            ancientcurse,
            ancientharbinger,
            ancientmage,
            ancientofblossoms,
            ancientoflore,
            ancientofwar,
            ancientpower,
            ancientsecrets,
            ancientshade,
            ancientshieldbearer,
            ancientteachings,
            ancientwatcher,
            anduinwrynn,
            andybrock,
            anewheroapproaches,
            angrychicken,
            animagolem,
            animalcompanion,
            animated,
            animatedarmor,
            animatedberserker,
            animatedshield,
            animatedstatue,
            animateearthen,
            annoyoptron,
            annoyotron,
            anodizedrobocub,
            anomalus,
            antimagicshell,
            antiquehealbot,
            anubarak,
            anubarambusher,
            anubisathsentinel,
            anubisathtempleguard,
            anubrekhan,
            anyfincanhappen,
            arathiweaponsmith,
            arcaneanomaly,
            arcaneblast,
            arcaneexplosion,
            arcanegiant,
            arcanegolem,
            arcaneintellect,
            arcanelypowerful,
            arcanemissiles,
            arcanenullifierx21,
            arcanepower,
            arcaneshot,
            arcanitereaper,
            arcanologist,
            arcanosmith,
            arcanotron,
            archaedas,
            archbishopbenedictus,
            archmage,
            archmageantonidas,
            archmagesapprentice,
            archmagesinsight,
            archthiefrafaam,
            arfus,
            argentcommander,
            argenthorserider,
            argentlance,
            argentprotector,
            argentsquire,
            argentwatchman,
            armedanddangerous,
            armoredwarhorse,
            armorplated,
            armorplating,
            armorsmith,
            armorup,
            armory,
            armyofthedead,
            arrakoadevotion,
            arrogantcrusader,
            ascended,
            ashbringer,
            asimpletrick,
            assassinate,
            assassinsblade,
            assassinsstealth,
            astralcommunion,
            astralportal,
            atiesh,
            atramedes,
            attackmode,
            auchenaisoulpriest,
            auctionmasterbeardo,
            avalanche,
            avatarofthecoin,
            avenge,
            avengingwrath,
            aviana,
            avianwatcher,
            awakenthemakers,
            awooooo,
            axeflinger,
            ayablackpaw,
            azuredrake,
            babblingbook,
            backroombouncer,
            backstab,
            backstreetleper,
            bainebloodhoof,
            ballistashot,
            ballofspiders,
            bamboozle,
            bananas,
            bananasondeath,
            baneofdoom,
            barnabusthestomper,
            barnes,
            barongeddon,
            baronrivendare,
            barracks,
            barrel,
            barrelforward,
            barreltoss,
            bash,
            battleaxe,
            battlecrybonus,
            battlerage,
            battlestandard,
            beaconofhope,
            bearform,
            bearshark,
            beartrap,
            beccaabel,
            beckonerofevil,
            benbrode,
            beneaththegrounds,
            benedictionsplinter,
            benthompson,
            beomkihong,
            beourguest,
            berserk,
            berserking,
            bestialwrath,
            betrayal,
            bigbadclaws,
            bigbadwolf,
            bigbanana,
            biggamehunter,
            bigtimeracketeer,
            bigwisps,
            bilefintidehunter,
            bindingheal,
            bite,
            biteofthebloodqueen,
            biteweed,
            bitten,
            bittertidehydra,
            blackbishop,
            blackguard,
            blackking,
            blackknight,
            blackpawn,
            blackqueen,
            blackrook,
            blackwaterpirate,
            blackwhelp,
            blackwing,
            blackwingcorruptor,
            blackwingtechnician,
            bladedcultist,
            bladeflurry,
            bladeofcthun,
            bladestorm,
            blarghghl,
            blastcrystalpotion,
            blazecaller,
            blessed,
            blessedchampion,
            blessingofkings,
            blessingofmight,
            blessingofthesun,
            blessingofthevalkyr,
            blessingofwisdom,
            blessingsofthesun,
            blindwithrage,
            blingtron3000,
            blingtronsblade,
            blingtronsbladehero,
            blizzard,
            blockofice,
            bloodbeast,
            bloodbloom,
            bloodessence,
            bloodfenraptor,
            bloodfury,
            bloodfurypotion,
            bloodhoofbrave,
            bloodimp,
            bloodknight,
            bloodlust,
            bloodmagethalnos,
            bloodoftheancientone,
            bloodpact,
            bloodqueenlanathel,
            bloodrage,
            bloodrazor,
            bloodreaverguldan,
            bloodrune,
            bloodsailcorsair,
            bloodsailcultist,
            bloodsailraider,
            bloodtap,
            bloodthirst,
            bloodthirsty,
            bloodthistle,
            bloodthistletoxin,
            bloodtoichor,
            bloodwarriors,
            bloodworm,
            blowgillsniper,
            blubberbaron,
            bluebeam,
            bluegillwarrior,
            blueportal,
            boar,
            bobfitch,
            bogcreeper,
            bolframshield,
            bolster,
            bolstered,
            bolvarfireblood,
            bolvarfordragon,
            bomblobber,
            bombsalvo,
            bombsquad,
            bonebaron,
            boneconstruct,
            bonedrake,
            boneguarded,
            boneguardlieutenant,
            bonemare,
            bonemaresboon,
            boneminions,
            boneraptor,
            bonespike,
            bonestorm,
            bonus,
            bookwyrm,
            boom,
            boombot,
            boombotattached,
            boombotjr,
            bootybaybodyguard,
            bosshpswapper,
            boulderfistogre,
            bouncingblade,
            bradcrusco,
            brannbronzebeard,
            brassknuckles,
            bravearcher,
            brawl,
            brawlprogresssaved,
            brazier,
            breathofsindragosa,
            brewmaster,
            brewpotion,
            brianbirmingham,
            brianfarr,
            brianschwab,
            briarthorn,
            briarthorntoxin,
            brighteyedscout,
            brilliance,
            bringiton,
            broodaffliction,
            broodafflictionblack,
            broodafflictionblue,
            broodafflictionbronze,
            broodafflictiongreen,
            broodafflictionred,
            broom,
            browfurrow,
            brrrloc,
            bryanchang,
            bryntrollthebonearbiter,
            buccaneer,
            buildabeast,
            burgle,
            burglybully,
            burlyrockjawtrogg,
            burningadrenaline,
            burrowingmine,
            cabaliststome,
            cabalshadowpriest,
            cairnebloodhoof,
            callerdevotion,
            callingforbackup,
            callinthefinishers,
            callmediva,
            callofthewild,
            callpet,
            cameronchrisman,
            camillesanford,
            cancellingtheapocalypse,
            candle,
            cannibalize,
            captaingreenskin,
            captainsparrot,
            capturedjormungar,
            cardpresent,
            carnassasbrood,
            carriongrub,
            cashin,
            castfromshadow,
            castle,
            catform,
            catinahat,
            cattrick,
            cauldron,
            celestialdreamer,
            cellarspider,
            cenarius,
            ceremony,
            chains,
            challenged,
            charge,
            chargeddevilsaur,
            chargedhammer,
            charlènelescanff,
            chasingtrogg,
            cheapgift,
            cheat,
            checkforherodeath,
            checkforherodeathinlichkingraid,
            chestofgold,
            chicken,
            chieftainscarvash,
            chilance,
            chillbladechampion,
            chillmaw,
            chillwindyeti,
            chitteringtunneler,
            chogall,
            chooseanewcard,
            chooseoneofthree,
            chooseyourpath,
            chrisbelcher,
            christianscharling,
            christopheryim,
            chromaggus,
            chromaticdragonkin,
            chromaticdrake,
            chromaticmutation,
            chromaticprototype,
            circleofhealing,
            cityofstormwind,
            claw,
            claws,
            cleave,
            clericsblessing,
            cloaked,
            cloakedhuntress,
            clockworkgiant,
            clockworkgnome,
            clockworkknight,
            clutchmotherzavas,
            cobaltguardian,
            cobaltscalebane,
            cobrashot,
            coghammer,
            cogmaster,
            cogmasterswrench,
            coinsvengeance,
            coinsvengence,
            coldarradrake,
            coldblood,
            coldlightoracle,
            coldlightseer,
            coldwraith,
            coliseummanager,
            commandingshout,
            competitivespirit,
            conceal,
            concealed,
            coneofcold,
            confessorpaletress,
            conflagrate,
            confuse,
            confused,
            consecration,
            constructgolem,
            consultbrann,
            consume,
            convert,
            convinced,
            coopboss,
            corehound,
            corehoundpup,
            corehoundpuppies,
            corendirebrew,
            corerager,
            corneredsentry,
            corpseraiser,
            corpsetaker,
            corpsewidow,
            corruptedegg,
            corruptedhealbot,
            corruptedseer,
            corruptingmist,
            corruption,
            counterfeitcoin,
            counterspell,
            cowed,
            crackle,
            cracklingrazormaw,
            cracklingshield,
            crazedalchemist,
            crazedhunter,
            crazedworshipper,
            crazymonkey,
            create15secrets,
            crowdfavorite,
            crownofkaelthas,
            crueldinomancer,
            crueltaskmaster,
            crush,
            cryomancer,
            cryostasis,
            cryptlord,
            crystal,
            crystalcore,
            crystallineoracle,
            crystallized,
            crystalweaver,
            cthun,
            cthunschosen,
            cultapothecary,
            cultmaster,
            cultsorcerer,
            cup,
            curator,
            curiousglimmerroot,
            cursed,
            cursedblade,
            curseofrafaam,
            cutoff,
            cutpurse,
            cyclopianhorror,
            daggermastery,
            dalaranaspirant,
            dalaranmage,
            damagedgolem,
            dancingswords,
            danemmons,
            daringreporter,
            darionmograine,
            darkarakkoa,
            darkbargain,
            darkbomb,
            darkconviction,
            darkcultist,
            darkfusion,
            darkguardian,
            darkironbouncer,
            darkirondwarf,
            darkironskulker,
            darkironspectator,
            darknesscalls,
            darkpact,
            darkpeddler,
            darkpower,
            darkscalehealer,
            darkshirealchemist,
            darkshirecouncilman,
            darkshirelibrarian,
            darkspeaker,
            darkwanderer,
            darkwispers,
            darnassusaspirant,
            darttrap,
            davekosak,
            davidpendergrast,
            deadlyfork,
            deadlypoison,
            deadlyshot,
            deadmanshand,
            deadscaleknight,
            deanayala,
            deathanddecay,
            deathaxepunisher,
            deathbecomes,
            deathbloom,
            deathbringersaurfang,
            deathcharger,
            deathcoil,
            deathgrip,
            deathlord,
            deathlordnazgrim,
            deathmarkedlove,
            deathrattlebonus,
            deathrevenant,
            deathsbite,
            deathspeaker,
            deathsshadow,
            deathstalkerrexxar,
            deathward,
            deathwing,
            deathwingdragonlord,
            debris,
            decay,
            decimate,
            deckbuildingenchant,
            decorate,
            decoratedstormwind,
            decreasehealth,
            defender,
            defenderofargus,
            defiasbandit,
            defiascleaner,
            defiasringleader,
            defile,
            dementedfrostcaller,
            demigodsfavor,
            demolisher,
            demonfire,
            demonfuse,
            demonheart,
            demonicdraught,
            demonicpresence,
            demonsloose,
            demonwrath,
            derekdupras,
            dereksakamoto,
            desertcamel,
            desperatestand,
            despicabledreadlord,
            deviatebanana,
            deviateswitch,
            devilsaur,
            devilsauregg,
            devolve,
            devotionoftheblade,
            devourmind,
            diabolicalpowers,
            dieinsect,
            dieinsects,
            dinomancy,
            dinosize,
            direclaws,
            direfatecard,
            direfatemanaburst,
            direfatemurlocs,
            direfatetauntandcharge,
            direfateunstableportals,
            direfatewindfury,
            direhornform,
            direhornhatchling,
            direhornmatriarch,
            direshapeshift,
            direwolfalpha,
            dirtyrat,
            discardedarmor,
            discipleofcthun,
            discovermydeckenchant,
            discovernextclass,
            discovernextclasscopy,
            disguised,
            dismount,
            dispatchkodo,
            dispel,
            divinefavor,
            divinespirit,
            divinestrength,
            divinesweets,
            djinniofzephyrs,
            djinnsintuition,
            donhancho,
            dontpushme,
            doom,
            doomcaller,
            doomedapprentice,
            doomerang,
            doomfree,
            doomguard,
            doomhammer,
            doompact,
            doomsayer,
            doppelgangster,
            dorothee,
            doublezap,
            draconiclineage,
            draconicpower,
            draeneitotemcarver,
            dragonblood,
            dragonconsort,
            dragonegg,
            dragonfirepotion,
            dragonhawkery,
            dragonhawkrider,
            dragonkin,
            dragonkinsorcerer,
            dragonkinspellcaster,
            dragonlingmechanic,
            dragonlust,
            dragonsbreath,
            dragonscales,
            dragonscalewarrior,
            dragonsfree,
            dragonsmight,
            dragonteeth,
            drainlife,
            drainsoul,
            drakkaridefender,
            drakkarienchanter,
            drakkisathscommand,
            drakonidcrusher,
            drakonidoperative,
            drakonidslayer,
            drawoffensiveplay,
            drboom,
            drboomboomboomboom,
            dreadcorsair,
            dreadinfernal,
            dreadscale,
            dreadsteed,
            dream,
            drewkorfe,
            drinkdeeply,
            druid,
            druidoftheclaw,
            druidofthefang,
            druidoftheflame,
            druidofthesaber,
            druidoftheswarm,
            dualwarglaives,
            dunemaulshaman,
            duplicate,
            duskboar,
            dustdevil,
            dustinescoffery,
            dwarfdemolitionist,
            dyinglight,
            dynamite,
            eadricthepure,
            eagerrogue,
            eaglehornbow,
            earthelemental,
            earthenpursuer,
            earthenringfarseer,
            earthenscales,
            earthenstatue,
            earthshock,
            eaterofsecrets,
            eating,
            echoedspirit,
            echoingooze,
            echolocate,
            echoofmedivh,
            edwinvancleef,
            eeriestatue,
            effigy,
            eggnapper,
            elderlongneck,
            eldritchhorror,
            electron,
            elementaldestruction,
            elementaleruption,
            elisestarseeker,
            elisethetrailblazer,
            elitetaurenchieftain,
            elizabethcho,
            elunesgrace,
            elvenarcher,
            emboldened,
            emboldener3000,
            embraced,
            embracedarkness,
            embracetheshadow,
            embracingtheshadow,
            emeralddrake,
            emeraldhivequeen,
            emeraldreaver,
            emergencycoolant,
            emperorcobra,
            emperorthaurissan,
            empowered,
            empoweringmist,
            empowerment,
            enchantedraven,
            endlessenchantment,
            endlesshunger,
            enfeeble,
            enhanced,
            enhanceomechano,
            enigmaticportal,
            enormous,
            enough,
            enrage,
            enraged,
            enterthecoliseum,
            entomb,
            envenomed,
            envenomweapon,
            equality,
            equipped,
            ericdelpriore,
            ericdodds,
            eruption,
            escape,
            essenceofthered,
            eternalsentinel,
            eternalservitude,
            etherealarcanist,
            etherealconjurer,
            etherealpeddler,
            evanpolekoff,
            eveofdestruction,
            everyfinisawesome,
            evilheckler,
            eviscerate,
            evocation,
            evolve,
            evolvedkobold,
            evolvescales,
            evolvespines,
            evolvingspores,
            excavatedevil,
            excessmana,
            execute,
            experienced,
            experiments,
            explodingbloatbat,
            explorershat,
            exploreungoro,
            explosiverune,
            explosiverunes,
            explosivesheep,
            explosiveshot,
            explosivetrap,
            extracalcium,
            extrapoke,
            extrasharp,
            extrastabby,
            extrateeth,
            eydisdarkbane,
            eyeforaneye,
            eyeinthesky,
            eyeofhakkar,
            eyeoforsis,
            faceless,
            facelessbehemoth,
            facelessdestroyer,
            facelessmanipulator,
            facelessshambler,
            facelesssummoner,
            facilitated,
            fadeleaf,
            fadeleaftoxin,
            fadinglight,
            faeriedragon,
            fallenchampions,
            fallenhero,
            fallensuncleric,
            falloutslime,
            famished,
            fanaticdevotion,
            fandralstaghelm,
            fangs,
            fanofknives,
            farsight,
            fate,
            fate11enchmurloc,
            fate12enchconfuse,
            fate7ench2nd,
            fate7enchgetacoin,
            fate8getarmor,
            fate8rand2armoreachturn,
            fate9enchdeathrattlebonus,
            fatearmor,
            fatebananas,
            fatecoin,
            fateconfusion,
            fateportals,
            fatespells,
            fatespinner,
            fearsomedoomguard,
            feedingtime,
            feigndeath,
            felbloom,
            felcannon,
            felfirepotion,
            felguard,
            felorcsoulfiend,
            felrage,
            felreaver,
            fencingcoach,
            fencingpractice,
            fencreeper,
            feralrage,
            feralspirit,
            festergut,
            feugen,
            fierceforest,
            fiercemonkey,
            fierybat,
            fierywaraxe,
            fightpromoter,
            fightthelichking,
            filledup,
            finderskeepers,
            finickycloakfield,
            finjatheflyingstar,
            finkleeinhorn,
            fireball,
            fireblast,
            fireblastrank2,
            firebloomtoxin,
            firecatform,
            fireelemental,
            firefly,
            fireguarddestroyer,
            firehawkform,
            firelandsportal,
            fireplumeharbinger,
            fireplumephoenix,
            fireplumesheart,
            firesworn,
            fireworks,
            fistofjaraxxus,
            fjolalightbane,
            flameburst,
            flamecannon,
            flameelemental,
            flamegeyser,
            flameheart,
            flameimp,
            flamejuggler,
            flamelance,
            flameleviathan,
            flamemissiles,
            flameofazzinoth,
            flamesofazzinoth,
            flamestrike,
            flametongue,
            flametonguetotem,
            flamewaker,
            flamewakeracolyte,
            flamewreath,
            flamewreathedfaceless,
            flamingclaws,
            flare,
            flashheal,
            fleethemine,
            flesheatingghoul,
            flickeringdarkness,
            floatingwatcher,
            flyingmachine,
            flyingmonkey,
            foamsword,
            foereaper4000,
            followmyrules,
            foolsbane,
            forbiddenancient,
            forbiddenflame,
            forbiddenhealing,
            forbiddenpower,
            forbiddenritual,
            forbiddenshaping,
            forceofnature,
            forcetankmax,
            forcetankomegamax,
            forgeofsouls,
            forgesoforgrimmar,
            forgottenarmor,
            forgottenmana,
            forgottentorch,
            fork,
            forkedlightning,
            forlornstalker,
            fortitude,
            fossilized,
            fossilizeddevilsaur,
            freefromamber,
            freespell,
            freewheelingskulker,
            freezingblast,
            freezingpotion,
            freezingtrap,
            freshfish,
            friendlybartender,
            frigidsnobold,
            frog,
            frostblast,
            frostbolt,
            frostbreath,
            frostelemental,
            frostgiant,
            frostlich,
            frostlichjaina,
            frostmourne,
            frostmourneenchantment,
            frostnova,
            frostshock,
            frostwidow,
            frostwolfbanner,
            frostwolfgrunt,
            frostwolfwarlord,
            frothingberserker,
            frozenblood,
            frozenchampion,
            frozenclone,
            frozencrusher,
            fruitplate,
            fullbelly,
            fullstrength,
            fungalgrowth,
            furioushowl,
            furnacefirecolossus,
            gadgetzanauctioneer,
            gadgetzanferryman,
            gadgetzanjouster,
            gadgetzansocialite,
            gahzrilla,
            galleryprotection,
            gallywixscoin,
            galvadon,
            gangup,
            garr,
            garrisoncommander,
            garroshhellscream,
            gazlowe,
            gearmastermechazod,
            gelbinmekkatorque,
            generaldrakkisath,
            gentlemegasaur,
            genzotheshark,
            geomancy,
            getawaykodo,
            getbig,
            getem,
            gettingangry,
            gettinghungry,
            ghastlyconjurer,
            ghoul,
            ghoulinfestor,
            giantanaconda,
            giantfin,
            giantinsect,
            giantmastodon,
            giantsandworm,
            giantwasp,
            giftofcards,
            giftofmana,
            gilblinstalker,
            givetauntandcharge,
            glacialmysteries,
            glacialshard,
            gladiatorslongbow,
            gladiatorslongbowenchantment,
            glaivezooka,
            gloriousfinale,
            gluth,
            gluttonousooze,
            gnash,
            gnoll,
            gnomeferatu,
            gnomereganinfantry,
            gnomishexperimenter,
            gnomishinventor,
            goblinautobarber,
            goblinblastmage,
            goblinsapper,
            goingnova,
            golakkacrawler,
            goldenmonkey,
            goldshirefootman,
            goldthorn,
            golemagg,
            gorehowl,
            gorillabota3,
            gormoktheimpaler,
            gothiktheharvester,
            grandcrusader,
            grandwidowfaerlina,
            graspofmalganis,
            graveshambler,
            gravevengeance,
            greaterarcanemissiles,
            greaterhealingpotion,
            greaterpotion,
            greenskinscommand,
            grievousbite,
            grimestreetenforcer,
            grimestreetinformant,
            grimestreetoutfitter,
            grimestreetpawnbroker,
            grimestreetprotector,
            grimestreetsmuggler,
            grimnecromancer,
            grimpatron,
            grimscalechum,
            grimscaleoracle,
            grimygadgeteer,
            grobbulus,
            grommashhellscream,
            grookfumaster,
            groomed,
            grotesquedragonhawk,
            grovetender,
            grow,
            growingooze,
            growth,
            grumblyrunt,
            gruul,
            guardian,
            guardianoficecrown,
            guardianofkings,
            guldan,
            gurubashiberserker,
            guzzler,
            gyth,
            hadidjahchamberlin,
            hadronox,
            hakkaribloodgoblet,
            hallazealtheascended,
            hallucination,
            hamiltonchu,
            hammeroftwilight,
            hammerofwrath,
            hancho,
            handofargus,
            handofprotection,
            happyghoul,
            happypartygoer,
            hardpackedsnowballs,
            harrisonjones,
            harvest,
            harvestgolem,
            harvestofsouls,
            hatefulstrike,
            hauntedcreeper,
            haywiremech,
            headcrack,
            heal,
            healingtotem,
            healingtouch,
            healingwave,
            heartoffire,
            heavyaxe,
            heigantheunclean,
            hellbovine,
            hellbovinechampion,
            hellfire,
            hellohellohello,
            hemetjunglehunter,
            hemetnesingwary,
            henryho,
            heraldvolazj,
            herding,
            heretakebuff,
            herimwoo,
            heroicdifficulty,
            heroicmode,
            heroicstrike,
            hex,
            hexxed,
            hiddencache,
            hiddengnome,
            highjusticegrimstone,
            highlordomokk,
            hiredgun,
            hobartgrapplehammer,
            hobgoblin,
            hogger,
            hoggerdoomofelwynn,
            hoggersmash,
            hollow,
            holychampion,
            holyfire,
            holylight,
            holynova,
            holysmite,
            holywrath,
            homingchicken,
            hoodedacolyte,
            hook,
            hotspringguardian,
            hound,
            houndmaster,
            hourofcorruption,
            houroftwilight,
            howlfiend,
            howlingcommander,
            hozenhealer,
            huffer,
            hugeego,
            hugetoad,
            humility,
            humongousrazorleaf,
            hungrycrab,
            hungrydragon,
            hungrynaga,
            hunter,
            huntersmark,
            hydrologist,
            hyena,
            hyldnirfrostrider,
            iammurloc,
            icebarrier,
            iceblock,
            icebreaker,
            icecap,
            iceclaw,
            icefishing,
            icehowl,
            icelance,
            icerager,
            icewalker,
            ichorofundeath,
            ickyimp,
            ickytentacle,
            icytouch,
            icyveins,
            igneouselemental,
            ignitemana,
            ihearyou,
            iknowaguy,
            illidanstormrage,
            illuminator,
            immolate,
            imp,
            imperialfavor,
            impgangboss,
            implosion,
            impmaster,
            increasehealth,
            incredibleimpression,
            incubation,
            infernal,
            inferno,
            infest,
            infestedtauren,
            infestedwolf,
            infusion,
            injuredblademaster,
            injuredkvaldir,
            inkmastersolia,
            innerfire,
            innerrage,
            innervate,
            innkeeperhealthset,
            innkeepertools,
            inquisitorwhitemane,
            insightful,
            inspired,
            instructorrazuvious,
            intensegaze,
            interloper,
            intrepiddragonstalker,
            investigatetherunes,
            invocationofair,
            invocationofearth,
            invocationoffire,
            invocationofwater,
            ironbarkprotector,
            ironbeakowl,
            ironedout,
            ironforgeportal,
            ironforgerifleman,
            ironfurgrizzly,
            ironhide,
            ironjuggernaut,
            ironsensei,
            itsallscaley,
            ivoryknight,
            jacobjarecki,
            jadebehemoth,
            jadeblossom,
            jadechieftain,
            jadeclaws,
            jadegolem,
            jadeidol,
            jadelightning,
            jadeshuriken,
            jadespirit,
            jadeswarmer,
            jainaproudmoore,
            jasonchayes,
            jasondeford,
            jasonmacallister,
            jasonshattuck,
            jaws,
            jaybaxter,
            jcpark,
            jeeringcrowd,
            jeeves,
            jeremycranford,
            jerrycheng,
            jerrymascho,
            jeweledmacaw,
            jeweledscarab,
            jinyuwaterspeaker,
            jointheranks,
            jointheranksplayerenchantment,
            jomarokindred,
            jonaslaster,
            jonbankard,
            joshdurica,
            journeybelow,
            julianne,
            junglegiants,
            junglemoonkin,
            junglepanther,
            junkbot,
            junkedup,
            justblaze,
            justicartrueheart,
            justiceserved,
            kabalchemist,
            kabalcourier,
            kabalcrystalrunner,
            kabaldemon,
            kaballackey,
            kabalsongstealer,
            kabaltalonpriest,
            kabaltrafficker,
            kalimosprimallord,
            karakazham,
            kazakus,
            kazakuspotion,
            keeningbanshee,
            keeperofthegrove,
            keeperofuldaman,
            keepingsecrets,
            keithlandes,
            kelesethsblessing,
            kelthuzad,
            kezanmystic,
            khadgar,
            khadgarspipe,
            kidnapper,
            killcommand,
            killmillhouse,
            killobjectiveanubarak,
            killthelorewalker,
            kilrek,
            kindlygrandmother,
            kindredspirit,
            kingkrush,
            kingmosh,
            kingmukla,
            kingofbeasts,
            kingsblood,
            kingsbloodtoxin,
            kingsdefender,
            kingselekk,
            kirintormage,
            klaxxiamberweaver,
            knife,
            knifejuggler,
            knightofthewild,
            knowledge,
            knuckles,
            koboldgeomancer,
            kodorider,
            kookychemist,
            kookychemistry,
            korkronelite,
            kriszierhut,
            krultheunshackled,
            kuntheforgottenking,
            kvaldirraider,
            kyleharrison,
            laced,
            ladyblaumeux,
            ladydeathwhisper,
            ladyliadrin,
            ladynazjar,
            lakkarifelhound,
            lakkarisacrifice,
            lancecarrier,
            lanternofpower,
            largetalons,
            laughingsister,
            lava,
            lavaburst,
            lavashock,
            layonhands,
            leaderofthepack,
            leathercladhogleader,
            leechingpoison,
            leeroyjenkins,
            legacyoftheemperor,
            legion,
            leokk,
            lepergnome,
            lesserheal,
            lesserpotion,
            levelup,
            leylines,
            lichkingmodifications,
            lichkingmodificationscopy,
            lifetap,
            lightbomb,
            lightfusedstegodon,
            lightning,
            lightningbolt,
            lightningjolt,
            lightningspeed,
            lightningstorm,
            lightofthenaaru,
            lightsblessing,
            lightschampion,
            lightsjustice,
            lightspawn,
            lightssorrow,
            lightwarden,
            lightwell,
            likeasorethumb,
            lilexorcist,
            lilianvoss,
            lionform,
            liquidmembrane,
            littlefriend,
            livbreeden,
            livingbomb,
            livinglava,
            livingmana,
            livingroots,
            livingspores,
            lkphase2debug,
            lkphase3debug,
            loatheb,
            lockandload,
            locustswarm,
            loomingpresence,
            lootedblade,
            loothoarder,
            lordjaraxxus,
            lordmarrowgar,
            lordofthearena,
            lordslitherspear,
            lordvictornefarius,
            lorenzominaca,
            lorewalkercho,
            lostinthejungle,
            losttallstrider,
            lotharsleftgreave,
            lotusagents,
            lotusassassin,
            lotusillusionist,
            lovesannoyotron,
            lowlysquire,
            lucifron,
            luckofthecoin,
            luckydobuccaneer,
            lumberinggolem,
            lunarvisions,
            lyrathesunshard,
            madamgoya,
            madbomber,
            madderbomber,
            madderscience,
            maddestscience,
            madness,
            madnesspotion,
            madscience,
            madscientist,
            maelstromportal,
            maexxna,
            mage,
            magearmor,
            magicmirror,
            magmapulse,
            magmarager,
            magmatron,
            magmaw,
            magmic,
            magnatauralpha,
            magnibronzebeard,
            maidenofthelake,
            maievshadowsong,
            maintank,
            majordomoexecutus,
            malchezaarsimp,
            malfurionstormrage,
            malfurionthepestilent,
            malganis,
            malkorok,
            maloriak,
            malorne,
            malygos,
            manaaddict,
            manabind,
            manageode,
            managorged,
            manaheist,
            manastorm,
            manatidetotem,
            manatreant,
            manawraith,
            manawyrm,
            manicsoulcaster,
            manyimps,
            manywisps,
            maptothegoldenmonkey,
            markmoonwalker,
            markofnature,
            markofthehorsemen,
            markofthelotus,
            markofthewild,
            markofyshaarj,
            martinbrochu,
            massdispel,
            massive,
            massivedifficulty,
            massivegnoll,
            massiveruneblade,
            masterjouster,
            masterofceremonies,
            masterofdisguise,
            masterofevolution,
            masterspresence,
            mastersummoner,
            masterswordsmith,
            mastiff,
            matthewgrubb,
            mattplace,
            mattwyble,
            maxma,
            maxmccall,
            mayornoggenfogger,
            meanstreetmarshal,
            meatwagon,
            mebigger,
            mechanicaldragonling,
            mechanicalparrot,
            mechanicalyeti,
            mechbearcat,
            mechfan,
            mechwarper,
            meddlingfool,
            medivh,
            medivhslocket,
            medivhsvalet,
            medivhtheguardian,
            megafin,
            mekgineerthermaplugg,
            melt,
            menageriemagician,
            menageriewarden,
            mesmash,
            metabolizedmagic,
            metalteeth,
            metaltoothleaper,
            meteor,
            michaelaltuna,
            michaelreynaga,
            michaelschweitzer,
            michaelskacal,
            micromachine,
            midnightdrake,
            mightofmukla,
            mightofnerub,
            mightofstormwind,
            mightofthehostler,
            mightofthemonkey,
            mightoftinkertown,
            mightofzulfarrak,
            mikedonais,
            millhousemanastorm,
            mime,
            mimicpod,
            mimironshead,
            mindblast,
            mindbreaker,
            mindcontrol,
            mindcontrolcrystal,
            mindcontrolling,
            mindcontroltech,
            mindgames,
            mindpocalypse,
            mindshatter,
            mindspike,
            mindvision,
            minecart,
            mineshaft,
            miniature,
            minimage,
            minirag,
            mirage,
            miragecaller,
            mirekeeper,
            mirrorentity,
            mirrorimage,
            mirrorofdoom,
            misdirection,
            misha,
            mistcallerdeckench,
            mistressofmixtures,
            mistressofpain,
            mlarggragllabl,
            moatlurker,
            modificationscomplete,
            modifythelichking,
            mogorschampion,
            mogortheogre,
            mogushanwarden,
            moirabronzebeard,
            moltenblade,
            moltengiant,
            moltenrage,
            moltenreflection,
            moniqueory,
            moo,
            moonfire,
            moongladeportal,
            moorabi,
            morgltheoracle,
            moroes,
            mortalcoil,
            mortalstrike,
            mountainfirearmor,
            mountaingiant,
            mountedraptor,
            mrbigglesworth,
            mrgglaargl,
            mrghlglhal,
            mrglllraawrrrglrur,
            mrglmrglmrgl,
            mrglmrglnyahnyah,
            muklasbigbrother,
            muklaschampion,
            muklatyrantofthevale,
            mulch,
            multishot,
            mummyzombie,
            murloc,
            murlocbonus,
            murlocescaping,
            murlocknight,
            murlocraider,
            murlocrazorgill,
            murlocscout,
            murlocsescaping,
            murloctidecaller,
            murloctidehunter,
            murloctinyfin,
            murlocwarleader,
            museumcurator,
            musterforbattle,
            mutatinginjection,
            mutation,
            mydeckid,
            mysteriouschallenger,
            mysteriousescaleation,
            mysteriousrune,
            mysterypilot,
            mysticwool,
            nadiamankrikswife,
            nagacorsair,
            nagamyrmidon,
            nagarepellent,
            nagaseawitch,
            natpagle,
            natthedarkfisher,
            naturalize,
            nazrawildaxe,
            nealkochhar,
            necroknight,
            necromancy,
            necroticaura,
            necroticgeist,
            necroticplague,
            necroticpoison,
            needssharpening,
            needyhunter,
            nefarian,
            nefarianstrikes,
            nemsynecrofizzle,
            neptulon,
            nerubarweblord,
            nerubian,
            nerubianegg,
            nerubianprophet,
            nerubiansoldier,
            nerubianspores,
            nerubianunraveler,
            nestingroc,
            netherbloom,
            netherbreath,
            netherimp,
            netherportal,
            netherrage,
            netherspite,
            netherspitehistorian,
            netherspiteinfernal,
            newcalling,
            newhero,
            nextherodruidench,
            nextherodruidenchcopy,
            nextherohunterench,
            nextherohunterenchcopy,
            nextheromageench,
            nextheromageenchcopy,
            nextheropaladinench,
            nextheropaladinenchcopy,
            nextheropriestench,
            nextheropriestenchcopy,
            nextherorogueench,
            nextherorogueenchcopy,
            nextheroshamanench,
            nextheroshamanenchcopy,
            nextherowarlockench,
            nextherowarlockenchcopy,
            nextherowarriorench,
            nextherowarriorenchcopy,
            nexuschampionsaraad,
            nicholaskinney,
            nightbane,
            nightbanetemplar,
            nightblade,
            nighthowler,
            nightmare,
            nightsdevotion,
            noblesacrifice,
            noisecomplaint,
            noooooooooooo,
            normaldifficulty,
            northseakraken,
            northshirecleric,
            noththeplaguebringer,
            nourish,
            noviceengineer,
            noway,
            nozdormu,
            nzothsfirstmate,
            nzoththecorruptor,
            oasissnapjaw,
            obliterate,
            obsidiandestroyer,
            obsidianshard,
            obsidianstatue,
            offensiveplay,
            ogrebrute,
            ogremagi,
            ogreninja,
            ogrewarmaul,
            oldhorde,
            oldhordeorc,
            oldlegithealer,
            oldmurkeye,
            oldn3wbhealer,
            oldn3wbmage,
            oldn3wbtank,
            oldpvprogue,
            oldtbstpushcommoncard,
            omegawarper,
            omnotrondefensesystem,
            onastegodon,
            oneeyedcheat,
            onfire,
            onthehunt,
            onyxbishop,
            onyxia,
            onyxiclaw,
            ooze,
            openthegates,
            openthewaygate,
            optimism,
            orcwarrior,
            orgrimmaraspirant,
            ornerydirehorn,
            ornerypartygoer,
            orsisguard,
            overclock,
            overclocked,
            overfullbelly,
            overloadedmechazod,
            overloading,
            ozruk,
            paladin,
            pandarenscout,
            panther,
            pantherform,
            pantryspider,
            partyarmory,
            partybanner,
            partybarracks,
            partycapital,
            partycrasher,
            partyelemental,
            partyportal,
            partysupplies,
            partytownstormwind,
            patchesthepirate,
            patchwerk,
            patientassassin,
            patnagle,
            pawn,
            pearlofthetides,
            pelt,
            perditionsblade,
            peruse,
            peterwhalen,
            phantomfreebooter,
            pickyourfate1ench,
            pickyourfate2ench,
            pickyourfate3ench,
            pickyourfate4ench,
            pickyourfate5ench,
            pickyourfatebuildaround,
            pickyourfaterandom,
            pickyourfaterandon2nd,
            pickyoursecondclass,
            pileon,
            pilferedpower,
            pilotedshredder,
            pilotedskygolem,
            piñatagolem,
            pintsizedsummoner,
            pintsizepotion,
            piranha,
            piranhalauncher,
            pirate,
            pistons,
            pitcher,
            pitfighter,
            pitlord,
            pitofspikes,
            pitsnake,
            plague,
            plagued,
            plaguelord,
            plaguescientist,
            plant,
            plate,
            platemailarmor,
            playdead,
            poisoncloud,
            poisonedblade,
            poisoneddagger,
            poisoneddaggers,
            poisonseeds,
            poisonspit,
            polarity,
            polarityshift,
            pollutedhoarder,
            polymorph,
            polymorphboar,
            pompousthespian,
            possessedvillager,
            potionofmadness,
            potionofmight,
            potionofpolymorph,
            poultryizer,
            pouraround,
            powerspell,
            powered,
            powermace,
            powerofdalaran,
            poweroffaith,
            powerofthebluff,
            powerofthefirelord,
            powerofthehorde,
            powerofthekirintor,
            powerofthepeople,
            powerofthetitans,
            powerofthewild,
            poweroftheziggurat,
            poweroverwhelming,
            powerrager,
            powershot,
            powertransfer,
            powerwordglory,
            powerwordshield,
            powerwordtentacles,
            preparation,
            present,
            priest,
            priestessofelune,
            priestofthefeast,
            primalfin,
            primalfinchampion,
            primalfinlookout,
            primalfintotem,
            primalfusion,
            primallyinfused,
            primalmagic,
            primordialdrake,
            primordialglyph,
            princearthas,
            princekeleseth,
            princemalchezaar,
            princesshuhuran,
            princetaldaram,
            princevalanar,
            prioritize,
            professorputricide,
            prophetvelen,
            protectingthegallery,
            protecttheking,
            psychotron,
            pterrordax,
            pterrordaxhatchling,
            publicdefender,
            puddlestomper,
            pure,
            purecold,
            purgetheweak,
            purified,
            purify,
            putressed,
            putressvial,
            puzzle1,
            puzzle2,
            puzzle3,
            puzzle4,
            puzzle5,
            puzzle6,
            puzzle7,
            puzzle8,
            puzzle9,
            pyroblast,
            pyros,
            quartermaster,
            queencarnassa,
            questingadventurer,
            quickshot,
            raaaar,
            rachelledavis,
            radiantelemental,
            rafaam,
            ragingworgen,
            ragnaros,
            ragnaroslightlord,
            ragnarosthefirelord,
            raidhealer,
            raidleader,
            rainoffire,
            raisedead,
            rally,
            rallyingblade,
            rampage,
            ramwrangler,
            raptor,
            raptorform,
            raptorhatchling,
            raptorpatriarch,
            rarespear,
            rascallyrunt,
            rat,
            ratpack,
            rattlingrascal,
            raucous,
            ravagingghoul,
            ravasaurrunt,
            ravenholdtassassin,
            ravenidol,
            ravenouspterrordax,
            rawpower,
            razaenchant,
            razathechained,
            razorfenhunter,
            razorgore,
            razorgoresclaws,
            razorgoretheuntamed,
            razorpetal,
            razorpetallasher,
            razorpetalvolley,
            readytoreturn,
            recharge,
            recklessrocketeer,
            recombobulator,
            recruiter,
            recycle,
            redbeam,
            redeemed,
            redemption,
            redmanawyrm,
            redportal,
            redridinghood,
            reflection,
            reflections,
            reforged,
            refreshmentvendor,
            regenerativecookies,
            reincarnate,
            reinforce,
            releasecoolant,
            releasetheaberrations,
            relentlessmarch,
            reliquaryseeker,
            remembrance,
            remorselesswinter,
            rendblackhand,
            renojackson,
            renouncedarkness,
            renouncedarknessdeckench,
            repairbot,
            repairs,
            repentance,
            repurposed,
            resilientweapon,
            restart,
            resurrect,
            retribution,
            revenge,
            reverberatinggong,
            reversingswitch,
            rexxar,
            rhonin,
            ricardorobaina,
            righteousprotector,
            rivercrocolisk,
            riverpawgnoll,
            roaringtorch,
            robinfredericksen,
            robpardo,
            rock,
            rockbiterweapon,
            rockcandy,
            rockelemental,
            rockout,
            rockpoolhunter,
            rockycarapace,
            rodofthesun,
            rogue,
            roguesdoit,
            rollingboulder,
            rollthebones,
            romperstompers,
            romulo,
            rooted,
            rotface,
            rottenbanana,
            rumblingelemental,
            rummage,
            runeblade,
            runeforgehaunter,
            runicegg,
            rustyhook,
            rustyhorn,
            ryanchew,
            ryanmasterson,
            sabertoothlion,
            sabertoothpanther,
            sabertoothtiger,
            sabotage,
            saboteur,
            sabretoothstalker,
            sacredtrial,
            sacrificialpact,
            saddened,
            saddenedheroenchant,
            safe,
            saltydog,
            sanguinereveler,
            sap,
            sapling,
            sapphiron,
            saronitechaingang,
            satedthreshadon,
            savage,
            savagecombatant,
            savagemark,
            savageroar,
            savagery,
            savannahhighmane,
            scalednightmare,
            scarab,
            scarabbeetle,
            scarabform,
            scarabplague,
            scarabshell,
            scarletcrusader,
            scarletpurifier,
            scavenginghyena,
            scourgelordgarrosh,
            scouted,
            screwjankclunker,
            screwyjank,
            seadevilenchant,
            seadevilstinger,
            seagiant,
            sealofchampions,
            sealoflight,
            seareaver,
            searingtotem,
            secondclassdruid,
            secondclasshunter,
            secondclassmage,
            secondclasspaladin,
            secondclasspriest,
            secondclassrogue,
            secondclassshaman,
            secondclasswarlock,
            secondclasswarrior,
            secondratebruiser,
            secretkeeper,
            secretlysated,
            secretmagus,
            secretsofkarazhan,
            secretsofshadow,
            secretsofthecitadel,
            secretsofthecult,
            seethingstatue,
            selflesshero,
            senjinshieldmasta,
            sensedemons,
            sergeantsally,
            serratedshadows,
            servantofkalimos,
            servantofyoggsaron,
            setthetable,
            seyilyoon,
            shaded,
            shadeofaran,
            shadeofnaxxramas,
            shadopanmonk,
            shadopanrider,
            shadowascendant,
            shadowbeast,
            shadowblade,
            shadowbolt,
            shadowboltvolley,
            shadowbomber,
            shadowboxer,
            shadowcaster,
            shadowed,
            shadowessence,
            shadowfiend,
            shadowfiended,
            shadowflame,
            shadowform,
            shadowmadness,
            shadowmourne,
            shadowofnothing,
            shadowoil,
            shadoworlight,
            shadowrager,
            shadowreaperanduin,
            shadowreflection,
            shadowsensei,
            shadowsofmuru,
            shadowstep,
            shadowstrike,
            shadowtowergivemyminionsstealth,
            shadowtowernew,
            shadowtowerpower,
            shadowtowerstealth,
            shadowvisions,
            shadowvolley,
            shadowworddeath,
            shadowwordhorror,
            shadowwordpain,
            shadowy,
            shadydealer,
            shadydeals,
            shakuthecollector,
            shakyzipgunner,
            shallowgravedigger,
            shaman,
            shandoslesson,
            shapeshift,
            shardofsulfuras,
            sharp,
            sharpen,
            sharpened,
            sharpfork,
            shatter,
            shatteredsuncleric,
            shatteringspree,
            sheep,
            shellshield,
            shellshifter,
            sherazincorpseflower,
            sherazinseed,
            shieldbearer,
            shieldblock,
            shieldedminibot,
            shieldglare,
            shieldmaiden,
            shieldslam,
            shieldsman,
            shifterzerus,
            shifting,
            shiftingshade,
            shimmeringtempest,
            shipscannon,
            shiv,
            shotgunblast,
            shrinkmeister,
            shrinkray,
            shroudingmist,
            shrunk,
            shutuppriest,
            si7agent,
            sideshowspelleater,
            siegeengine,
            silence,
            silentknight,
            silithidswarmer,
            siltfinspiritwalker,
            silverbackpatriarch,
            silverhandknight,
            silverhandmurloc,
            silverhandrecruit,
            silverhandregent,
            silvermight,
            silvermoonguardian,
            silvermoonportal,
            silverwaregolem,
            simulacrum,
            sindragosa,
            sinisterpower,
            sinisterstrike,
            siphonlife,
            siphonsoul,
            sirfinleymrrgglton,
            sirzeliek,
            sizeincrease,
            skelemancer,
            skelesaurushex,
            skeletalenforcer,
            skeletalflayer,
            skeletalknight,
            skeletalreconstruction,
            skeletalsmith,
            skeleton,
            skeramcultist,
            skitter,
            skulkinggeist,
            skycapnkragg,
            slam,
            slaveofkelthuzad,
            sleepingacolyte,
            sleepwiththefishes,
            slime,
            slimed,
            slitheringarcher,
            slitheringguard,
            sludgebelcher,
            smalltimebuccaneer,
            smalltimerecruits,
            smuggle,
            smugglerscrate,
            smugglersrun,
            smuggling,
            snake,
            snaketrap,
            sneedsoldshredder,
            snipe,
            snowchugger,
            snowflipperpenguin,
            snowfurygiant,
            soggoththeslitherer,
            sojinhwang,
            soldiersofthecolddark,
            solemnvigil,
            somany,
            somethinginthepunch,
            sonicbreath,
            sonoftheflame,
            sootspewer,
            sorcerersapprentice,
            sorcerousdevotion,
            soulfire,
            souloftheforest,
            soulpower,
            soulreaper,
            soultap,
            southseacaptain,
            southseadeckhand,
            southseasquidface,
            sparringpartner,
            spawnofnzoth,
            spawnofshadows,
            spectralgothik,
            spectralknight,
            spectralpillager,
            spectralrider,
            spectralspider,
            spectraltrainee,
            spectralwarrior,
            spellbender,
            spellbonus,
            spellbreaker,
            spellcaster,
            spellslinger,
            spellweaver,
            spider,
            spiderfangs,
            spiderform,
            spiderplague,
            spidertank,
            spikeddecoy,
            spikedhogrider,
            spikeridgedsteed,
            spines,
            spiritclaws,
            spiritecho,
            spiritlash,
            spiritsingerumbra,
            spiritwolf,
            spitefulsmith,
            spoon,
            spore,
            sporeburst,
            spreadingmadness,
            spreadingplague,
            sprint,
            sprout,
            spystalker,
            squidoilsheen,
            squire,
            squirmingtentacle,
            squirrel,
            stablemaster,
            stafffirstpiece,
            staffoforigination,
            stafftwopieces,
            stalagg,
            stampede,
            stampeding,
            stampedingbeast,
            stampedingkodo,
            standagainstdarkness,
            standdown,
            starfall,
            starfire,
            starvingbuzzard,
            steadyshot,
            steallife,
            steamsurger,
            steamwheedlesniper,
            stegodon,
            stevengabriel,
            steveshimizu,
            stevewalker,
            steward,
            stewardofdarkshire,
            stitched,
            stitchedtracker,
            stolengoods,
            stolenwintersveilgift,
            stomp,
            stoneclawtotem,
            stoneelemental,
            stonehilldefender,
            stonescaleoil,
            stonesculpting,
            stonesentinel,
            stoneskingargoyle,
            stonesplintertrogg,
            stonetuskboar,
            stonewall,
            stormcrack,
            stormforgedaxe,
            stormpikecommando,
            stormwatcher,
            stormwindchampion,
            stormwindknight,
            stranglethorntiger,
            streettrickster,
            streetwiseinvestigator,
            strengthofstormwind,
            strengthofthepack,
            strongshell,
            strongshellscavenger,
            stubborngastropod,
            succubus,
            suddengenesis,
            sulfuras,
            summonapanther,
            summonguardians,
            summoningportal,
            summoningstone,
            summonkilrek,
            sunbornevalkyr,
            sunfuryprotector,
            sunkeepertarim,
            sunraiderphaerix,
            sunwalker,
            supercharge,
            supercharged,
            superiorpotion,
            supremelichking,
            susiesizzlesong,
            swampkingdred,
            swapbossheropowerbyclass,
            swapherowithdeathknight,
            swashburglar,
            swingacross,
            swipe,
            switched,
            swordofjustice,
            swordsman,
            sylvanaswindrunner,
            tabbycat,
            tableset,
            tagteamiceblock,
            tailswipe,
            taintedzealot,
            taketheshortcut,
            taldaramsvisage,
            tanarishogchopper,
            tankmode,
            tankup,
            tarcreeper,
            targetdummy,
            tarlord,
            tarlurker,
            tarnishedcoin,
            tasty,
            taurenwarrior,
            tbclockworkcarddealer,
            tbenchrandommanacost,
            tbenchwhosthebossnow,
            tbmechwarcommoncards,
            tbrandomcardcost,
            tbudsummonearlyminion,
            teachingsofthekirintor,
            teamplayerenchantment,
            teapot,
            tempered,
            templeenforcer,
            templeescape,
            templeescapeenchant,
            tentacleofnzoth,
            tentacles,
            tentaclesforarms,
            terestianillhoof,
            terribletank,
            terrifyingroar,
            terrifyingvisage,
            terriwellman,
            terrorscalestalker,
            testsubject,
            thaddius,
            thanekorthazz,
            thealchemist,
            theancientone,
            thebeast,
            theblackknight,
            theboogeymonster,
            thecavernsbelow,
            thecoin,
            thecowking,
            thecrone,
            thecurator,
            thedarkness,
            theeye,
            thefinalbattle,
            thefourhorsemen,
            thegrimygoons,
            thehorde,
            thehunted,
            thejadelotus,
            thekabal,
            theking,
            thelastkaleidosaur,
            thelichking,
            themajordomo,
            themarshqueen,
            themistcaller,
            theportalopens,
            thepriceofpower,
            therock,
            therookery,
            thesaint,
            thescoop,
            thescourge,
            thesilverhand,
            theskeletonknight,
            thesteelsentinel,
            thestormguardian,
            thetidalhand,
            thetrueking,
            thetruelich,
            thetruewarchief,
            thevoraxx,
            thingfrombelow,
            thirstyblades,
            thistletea,
            thorastrollbane,
            thoughtsteal,
            thrall,
            thralldeathseer,
            thrallmarfarseer,
            throwrocks,
            thunderbluffvaliant,
            thunderlizard,
            tickingabomination,
            tidalsurge,
            timberwolf,
            timeforsmash,
            timepieceofhorror,
            timerewinder,
            timerskine,
            timewarp,
            tinkerssharpswordoil,
            tinkertowntechnician,
            tinkmasteroverspark,
            tinyknightofevil,
            tirionfordring,
            tolvirhoplite,
            tolvirstoneshaper,
            tolvirwarden,
            tomblurker,
            tombpillager,
            tombspider,
            tomyaidunderling,
            tortollanforager,
            tortollanprimalist,
            tortollanshellraiser,
            toshley,
            tossingplates,
            totemgolem,
            totemiccall,
            totemicmight,
            totemicslam,
            totemsversussecrets,
            touchit,
            tournamentattendee,
            tournamentmedic,
            toxicarrow,
            toxicsewerooze,
            toxitron,
            tracking,
            tradeprincegallywix,
            trained,
            training,
            trainingcomplete,
            transcendence,
            transformed,
            transmutespirit,
            trapped,
            trappedsoul,
            treachery,
            treant,
            treasurecrazed,
            treeoflife,
            trembling,
            tremblingbeforethewolf,
            troggbeastrager,
            trogghateminions,
            trogghatespells,
            troggnostupid,
            troggzortheearthinator,
            trueform,
            truelove,
            truesilverchampion,
            tundrarhino,
            tunneltrogg,
            tuskarrfisherman,
            tuskarrjouster,
            tuskarrtotemic,
            twilightdarkmender,
            twilightdrake,
            twilightelder,
            twilightelemental,
            twilightendurance,
            twilightflamecaller,
            twilightgeomancer,
            twilightguardian,
            twilightsembrace,
            twilightsummoner,
            twilightwhelp,
            twinemperorveklor,
            twinemperorveknilash,
            twistedlight,
            twistedworgen,
            twister,
            twistingnether,
            tyrandewhisperwind,
            tyrantus,
            ultimateinfestation,
            ultrasaur,
            unbalancingstrike,
            unboundelemental,
            unbreakable,
            unchained,
            unchainedmagic,
            uncoverstaffpiece,
            undercityhuckster,
            undercityvaliant,
            understudy,
            undertaker,
            unearthedraptor,
            ungoropack,
            unholyshadow,
            unitethemurlocs,
            unity,
            unleashthehounds,
            unlicensedapothecary,
            unrelentingrider,
            unrelentingtrainee,
            unrelentingwarrior,
            unstableghoul,
            unstableportal,
            unwillingsacrifice,
            upgrade,
            upgraded,
            upgradedrepairbot,
            uproot,
            uprooted,
            usherofsouls,
            utherlightbringer,
            utheroftheebonblade,
            v07tr0n,
            vaelastrasz,
            vaelastraszthecorrupt,
            valeerasanguinar,
            valeerasbagenchant,
            valeerathehollow,
            validateddoomsayer,
            valithriadreamwalker,
            valkyrshadowguard,
            valkyrsoulclaimer,
            vampiricbite,
            vampiricleech,
            vancleefsvengeance,
            vanish,
            vaporize,
            varianwrynn,
            vassalssubservience,
            veilofshadows,
            velenschosen,
            vengeance,
            venomancer,
            venomstriketrap,
            venturecomercenary,
            verdantlongneck,
            veteransfavor,
            viciousfledgling,
            viciousswipe,
            victory,
            vilefininquisitor,
            vilespineslayer,
            villainy,
            vinecleaver,
            violetapprentice,
            violetillusionist,
            violetteacher,
            virmensensei,
            visionsoffate,
            visionsofhate,
            visionsofhypnos,
            visionsofknowledge,
            visionsoftheamazon,
            visionsoftheassassin,
            visionsofthebarbarian,
            visionsofthecrusader,
            visionsofthenecromancer,
            visionsofthesorcerer,
            visionsofvalor,
            vitalitytotem,
            voidcaller,
            voidcrusher,
            voidform,
            voidterror,
            voidwalker,
            volatileelemental,
            volcanicdrake,
            volcaniclumberer,
            volcanicmight,
            volcanicpotion,
            volcano,
            volcanosaur,
            voljin,
            voodoodoctor,
            voodoohexxer,
            vryghoul,
            wadethrough,
            wailingsoul,
            waitfordiscover,
            walkacrossgingerly,
            walterkong,
            wandawonderhooves,
            warbot,
            warded,
            warglaiveofazzinoth,
            wargolem,
            warhorsetrainer,
            warkodo,
            warlock,
            warlockonfire,
            warrior,
            warsongcommander,
            watched,
            waterelemental,
            weallscream,
            weaponrack,
            weaseltunneler,
            webspinner,
            webweave,
            webwrap,
            weespellstopper,
            wellequipped,
            wellfed,
            whelp,
            whippedintoshape,
            whirlingash,
            whirlingblades,
            whirlingzapomatic,
            whirlwind,
            whisperofdeath,
            whitebishop,
            whiteeyes,
            whiteking,
            whiteknight,
            whitepawn,
            whitequeen,
            whiterook,
            whywontyoudie,
            wickedknife,
            wickedskeleton,
            wickedwitchdoctor,
            wickerflameburnbristle,
            wildgrowth,
            wildmagic,
            wildpyromancer,
            wildwalker,
            wilfredfizzlebang,
            willofmukla,
            willofstormwind,
            willofthevizier,
            wilyrunt,
            windfury,
            windfuryharpy,
            windspeaker,
            windupburglebot,
            wintersveilgift,
            wishforcompanionship,
            wishforglory,
            wishformorewishes,
            wishforpower,
            wishforvalor,
            wisp,
            wispsoftheoldgods,
            wittyweaponplay,
            wobblingrunts,
            wolfrider,
            worgengreaser,
            worgeninfiltrator,
            worshipper,
            worthlessimp,
            woundup,
            wrath,
            wrathguard,
            wrathion,
            wrathofairtotem,
            wretchedtiller,
            wyrmrestagent,
            xarilpoisonedmind,
            yarrr,
            yoggsaronhopesend,
            yoggsaronsmagic,
            yoggservantheroenchant,
            yongwoo,
            youngdragonhawk,
            youngpriestess,
            yournextvictimcomes,
            youthfulbrewmaster,
            ysera,
            yseraawakens,
            yserastear,
            yshaarjrageunbound,
            yshaarjsstrength,
            zealousinitiate,
            zinaar,
            zombeast,
            zombiechow,
            zombiepresent,
            zoobot,
            zwick,
            marinthefox,
            masterchest,
            tolinsgoblet,
            goldenkobold,
            wondrouswand,
            wandswonder,
            zarogscrown,
            滑板机器人,
            青铜门卫,
            地精炸弹,
            投掷炸弹,
            爆破大师弗拉克,
            毒箭机器人,
            烟火技师,
            待发状态,
            死灵机械师,
            死灵机械,
            武器计划,
            电圆锯,
            生锈的回收机器人,
            生物计划,
            恒金巡游者,
            机械雏龙,
            机械巨龙,
            火箭靴,
            砰砰飞艇,
            火箭奇兵,
            可靠的灯泡,
            启发,
            毒物学家,
            毒素,
            紫色烟雾,
            学术剽窃,
            元素反应,
            没电的铁皮人,
            我找到了,
            星界裂隙,
            战嚎,
            火花钻机,
            火花,
            观星者露娜,
            掷弹机器人,
            飞弹机器人,
            欧米茄医护兵,
            安保巡游者,
            警卫机器人,
            增生手臂,
            加装,
            更多手臂,
            灵魂炸弹,
            双生小鬼,
            虚魂破坏者,
            虚魂充能,
            萎缩射线,
            水晶工匠坎格尔,
            铍金毁灭者,
            科学狂人砰砰博士,
            急速爆发,
            红色按钮,
            电磁炮,
            防爆护盾,
            霰弹炮,
            无人运输机,
            微型战队,
            迈拉的不稳定元素,
            迈拉腐泉,
            死灵炼金术,
            风暴聚合器,
            瓶装闪电,
            蜘蛛炸弹,
            鲁莽试验,
            星术师,
            露娜的口袋银河,
            星击,
            克隆大师泽里克,
            克隆载体,
            灵魂灌注,
            灌注,
            载人毁灭机,
            欢乐的发明家,
            吵吵机器人,
            全息术士,
            全息影像,
            蹦蹦兔,
            动能,
            死金匕首,
            实验室招募员,
            风暴追逐者,
            欧米茄防御者,
            欧米茄能量,
            欧米茄装配,
            弹簧火箭犬,
            可升级机器人,
            量产型恐吓机,
            复制威胁者,
            微型机器人,
            武装皮纳塔,
            奥秘图纸,
            香甜的灵力瓜,
            超级对撞器,
            雷云元素,
            伊莱克特拉风潮,
            带电,
            放电,
            脑力激荡者,
            脑力激荡,
            隐鳞药剂师,
            树木学家,
            植树造林,
            牛头人园丁,
            施肥,
            新生幼苗,
            梦境花栽种师,
            插花艺术,
            机械克苏恩,
            弗拉克的火箭炮,
            旋翼滑翔者,
            莫瑞甘博士,
            软泥教授弗洛普,
            软绵绵,
            克隆装置,
            棱彩透镜,
            互换法力值消耗,
            地精的把戏,
            黏呼呼的,
            机核芯片,
            芯片植入,
            虚空分析师,
            分析强化,
            弗洛普的神奇黏液,
            黏呼呼,
            机械袋鼠,
            机械袋鼠宝宝,
            晶化师,
            受损的机械剑龙,
            流电爆裂,
            迸射流星,
            黏液喷射者,
            死金药剂,
            丧钟机器人,
            爆盐投弹手,
            炸弹,
            引力翻转,
            上下颠倒,
            炼魂术,
            植被破碎机,
            真言术仿,
            仿制,
            星界密使,
            星界之力,
            投弹机器人,
            凶恶的雨云,
            机械推土牛,
            微机操控者,
            欧米茄探员,
            机械蛋,
            机械暴龙,
            火花引擎,
            奥能水母,
            电磁脉冲特工,
            欧米茄灵能者,
            心智融合,
            脱逃的样本,
            奇利亚斯,
            电能工匠,
            电化,
            群星罗列者,
            星界使者塞雷西亚,
            实验体,
            存储的资料,
            强能雷象,
            发牌,
            伪装机器人,
            伪装,
            战争机兵,
            荒疫爬行者,
            辐射软泥怪,
            鲁莽的实验者,
            鲁莽的实验,
            泽里克的克隆展,
            克隆,
            莫瑞甘的灵界,
            稍纵即逝的灵魂,
            实验体9号,
            疯狂的药剂师,
            用药过量,
            研发计划,
            气象学家,
            钢铁暴怒者,
            宇宙异象,
            爆爆机器人,
            格洛顿,
            通电机器人,
            通电,
            自动防御矩阵,
            水晶学,
            亮石技师,
            圣光灌注,
            吵吵模组,
            坎格尔的无尽大军,
            恶魔计划,
            神奇的威兹班,
            回响附魔,
            狂暴的狼人,
            奥术锁匠,
            狼人憎恶,
            癫狂的医生,
            坩埚元素,
            殚精竭虑,
            暴怒的双头巨人,
            黑沼枭兽,
            苔藓恐魔,
            疯帽客,
            帽子,
            艾莫莉丝,
            艾莫莉丝标记,
            阴郁的牡鹿,
            寓言,
            圣水,
            变色龙卡米洛斯,
            变形,
            凶恶的鳞皮兽,
            敲响警钟,
            钟声,
            燃烬风暴,
            黑嚎炮塔,
            赤环蜂,
            激怒,
            石英元素,
            镰刀德鲁伊,
            恐豹形态,
            恐狼形态,
            夜鳞龙后,
            夜鳞雏龙,
            恶魔法阵,
            小鬼,
            窃魂者阿扎莉娜,
            暮湾镇猎手,
            属性互换,
            南瓜农夫,
            吉尔尼斯皇家卫兵,
            责难,
            魅影民兵,
            唤鸦者,
            杂毛秘术师,
            女巫哈加莎,
            蛊惑,
            偷袭,
            失魂的守卫,
            强体,
            夜行蝙蝠,
            蝙蝠,
            迷雾幽灵,
            迷雾,
            迷失的幽魂,
            恐怖献祭,
            捕鼠人,
            饱餐,
            飞翼冲击,
            龙骨卫士,
            为了龙族,
            邪魂审判官,
            迅捷的信使,
            幻术士,
            阴燃电鳗,
            女巫的学徒,
            荆棘帮暴徒,
            加强,
            致命武装,
            黑暗附体,
            幽灵战马,
            达利乌斯克罗雷,
            血牙,
            怨灵之书,
            时光修补匠托奇,
            精灵之森,
            小精灵,
            被诅咒的海盗,
            沼泽水蛭,
            黑樟林树精,
            邪巢诱捕蛛,
            逝网蜘蛛,
            巫术时刻,
            捕鼠陷阱,
            末日骇鼠,
            女伯爵阿莎摩尔,
            城镇公告员,
            缚沙者,
            图腾啃食者,
            啃食图腾,
            女巫森林吹笛人,
            大地之力,
            风暴之躯,
            银剑,
            银质,
            苔丝格雷迈恩,
            静电震击,
            巨鳞蠕虫,
            凶猛沙虫,
            毒药贩子,
            廉价毒药,
            狩猎犬,
            女巫森林小鬼,
            巫毒娃娃,
            被巫毒娃娃诅咒,
            巫毒娃娃的诅咒,
            分裂腐树,
            分裂树苗,
            树枝,
            格林达鸦羽,
            鸦羽的召唤,
            人偶大师多里安,
            恐怖人偶,
            吸血蚊,
            女巫森林灰熊,
            老灰熊,
            暗夜徘徊者,
            追猎,
            警钟哨卫,
            教堂石像兽,
            凶猛咆哮,
            古董收藏家,
            罕见发现,
            篝火元素,
            发条机器人,
            总督察,
            驯犬大师肖尔,
            出击,
            樵夫之斧,
            樵夫,
            战路,
            腐树巨人,
            生长,
            碎枝,
            碎枝化,
            神圣赞美诗,
            女巫森林苹果,
            树人,
            三眼乌鸦,
            虚弱诅咒,
            腐烂的苹果树,
            幽灵弯刀,
            阴森可怖,
            面具收集者,
            冥光鱼人,
            胡桃精,
            梦魇融合怪,
            泥沼狩猎者,
            泥沼怪,
            沼泽飞龙,
            飞龙猎手,
            圣光楷模,
            通缉令,
            大法师阿鲁高,
            吉恩格雷迈恩,
            乌尔诅咒,
            鲜血女巫,
            利亚姆王子,
            搜索,
            暮陨者艾维娜,
            魔音,
            急速冷冻,
            民兵指挥官,
            草莽,
            破棺者,
            塑沼者,
            破铜烂铁机器人,
            鲜活梦魇,
            恶毒的银行家,
            沼泽龙蛋,
            玻璃骑士,
            女巫的坩埚,
            沙德沃克,
            高弗雷勋爵,
            噬月者巴库,
            闪狐,
            凶猛狂暴,
            森林向导,
            南瓜宝宝,
            炽焰祈咒,
            闪光飞蛾,
            飞蛾之尘,
            黑猫,
            白衣幽魂,
            天使坚毅,
            刺喉海盗,
            锐利,
            隐秘的智慧,
            食腐飞龙,
            腐蚀吐息,
            心灵尖啸,
            暗影力量,
            粗俗的矮劣魔,
            狗头人图书管理员,
            黑暗契约,
            铁钩掠夺者,
            铁钩恐惧,
            法多雷突袭者,
            蜘蛛伏击,
            魔网蜘蛛,
            洞穴探宝者,
            狗头人蛮兵,
            小型法术紫水晶,
            法术紫水晶,
            大型法术紫水晶,
            铁刃护手,
            树皮术,
            铁木魔像,
            小型法术玉石,
            法术玉石,
            大型法术玉石,
            分岔路口,
            探索黑暗,
            无所畏惧,
            打开宝箱,
            吃下蘑菇,
            星界猛虎,
            粉碎之手,
            狗头人隐士,
            小型法术蓝宝石,
            法术蓝宝石,
            大型法术蓝宝石,
            下水道爬行者,
            巨鼠,
            侧翼打击,
            狼,
            洞穴多头蛇,
            游荡怪物,
            小型法术翡翠,
            法术翡翠,
            大型法术翡翠,
            伦鲁迪洛尔,
            英勇药水,
            小型法术珍珠,
            守护之魂,
            法术珍珠,
            大型法术珍珠,
            战斗号角,
            爆炸符文,
            小型法术红宝石,
            法术红宝石,
            大型法术红宝石,
            变形卷轴,
            惊奇套牌,
            惊奇卡牌,
            艾露尼斯,
            机械异种蝎,
            蜡油元素,
            黑色龙人铁匠,
            锻造,
            腐蚀淤泥,
            孤胆英雄,
            孤胆,
            石皮蜥蜴,
            奥术统御者,
            绿色凝胶怪,
            绿色软泥怪,
            屠龙者,
            利齿宝箱,
            利齿,
            鬼祟恶魔,
            恶魔之力,
            贪睡巨龙,
            藏宝巨龙,
            通道爬行者,
            爬行,
            缚雾熊怪,
            迷雾元素,
            喧哗的诗人,
            士气振奋,
            紫色岩虫,
            肉虫,
            砂齿骑兵,
            食肉魔块,
            影舞者索尼娅,
            索尼娅之影,
            菌菇术士,
            魔法蘑菇,
            乌鸦魔仆,
            巨龙之怒,
            白银先锋,
            暮光召唤,
            闪光的骏马,
            小型法术秘银石,
            法术秘银石,
            大型法术秘银石,
            秘银魔像,
            诈死,
            侥幸逃脱,
            巨龙之魂,
            巨龙的灵魂,
            叛变,
            精灵咏唱者,
            闪避,
            莱妮莎炎伤,
            大主教之光,
            来我身边,
            凶猛的聒噪怪,
            蜡烛弓,
            奥术工匠,
            被诅咒的门徒,
            被诅咒的亡魂,
            厄运鼹鼠,
            未鉴定的药剂,
            闻起来像,
            生命药剂,
            生命之血,
            纯净药剂,
            纯净之力,
            暗影药剂,
            暗影之触,
            希望药剂,
            希望之声,
            未鉴定的盾牌,
            塔盾加10,
            锯齿盾牌,
            符文盾牌,
            钢铁魔像,
            尖刺盾牌,
            未鉴定的重槌,
            勇士重槌,
            神圣重槌,
            神圣赐福,
            祝福重槌,
            神圣祝福,
            净化重槌,
            蘑菇酿酒师,
            着魔男仆,
            橡树的召唤,
            水晶雄狮,
            灰熊守护者,
            穴居人食菌者,
            伊克斯里德真菌之王,
            等级提升,
            等级加1,
            原始护身符,
            狗头人学徒,
            贪婪的林精,
            灵能窥探,
            老狐狸马林,
            大师宝箱,
            撼世者格朗勃尔,
            格朗勃尔之力,
            旱谷狱卒,
            鲁莽风暴,
            宝石魔像,
            枯须铸甲师,
            虚空领主,
            寻求组队,
            治疗之雨,
            公会招募员,
            灾厄斩杀者,
            狗头人武僧,
            饥饿的双头怪,
            菌菇附魔师,
            狗头人拾荒者,
            世界之树的嫩枝,
            闪光的蘑菇,
            和蔼的灯神,
            破晓之龙,
            狗头人幻术师,
            硬壳甲虫,
            资深档案管理员,
            首席门徒林恩,
            第一封印,
            地狱猎犬,
            第二封印,
            第三封印,
            第四封印,
            终极封印,
            吞噬者阿扎里,
            大灾变,
            堕落者之颅,
            爆炸效果,
            瓦兰奈尔,
            装备瓦兰奈尔,
            小型法术黑曜石,
            法术黑曜石,
            大型法术黑曜石,
            不稳定的异变,
            符文之矛,
            小型法术钻石,
            法术钻石,
            大型法术钻石,
            卡瑟娜冬灵,
            蛇发女妖佐拉,
            低语元素,
            低语,
            风剪唤风者,
            地塑师伊普,
            渗水的软泥怪,
            白化变色龙,
            欧克哈特大师,
            碾压墙,
            黑暗之主,
            黑暗蜡烛侦测,
            黑暗蜡烛,
            暮光侍僧,
            暮光诅咒,
            虚空撕裂者,
            虚空转换,
            镀金的石像鬼,
            巨龙召唤者奥兰纳,
            火龙,
            魔网操控者,
            坦普卢斯,
            恶毒的召唤师,
            驯龙师,
            托瓦格尔国王,
            国王的赎金,
            弑君,
            弑君洗牌,
            托林的酒杯,
            扎罗格的王冠,
            黄金狗头人,
            奇迹之杖,
            杖之奇迹,
            中场拾荒者,
            图腾重击,
            黑心票贩,
            盲眼游侠,
            毒蛇守卫,
            亡鬼幻象,
            幻象,
            沼泽游荡者,
            淹没,
            青蛙之灵,
            祖尔金,
            狂暴投掷,
            血帆啸猴,
            血帆之旅,
            锯刃齿,
            尖牙,
            古拉巴什宣传员,
            言过其实,
            终极巫毒,
            巫毒,
            泽蒂摩,
            泽蒂摩的魔法浪潮,
            鲨鱼之灵,
            鲨鱼之力,
            格里伏塔,
            猜猜看,
            灵媒术,
            猎头者之斧,
            野兽之心,
            团伙劫掠,
            钩牙船长,
            火炮弹幕,
            再生,
            沙地苦工,
            僵尸,
            退役冠军,
            赛场新秀,
            盗取武器,
            走跳板,
            迅猛龙之灵,
            铁皮恐角龙,
            铁皮小恐龙,
            野蛮先锋,
            贡克迅猛龙之神,
            飞扑,
            掠食本能,
            尖啸,
            虚空契约,
            护魂者,
            残酷集结,
            蝙蝠之灵,
            希里克的恩赐,
            高阶祭司耶克里克,
            希里克蝙蝠之神,
            神灵印记,
            贡克的坚韧,
            迅猛龙群,
            迅猛龙,
            狂奔怒吼,
            奔踏,
            鲜血巨魔工兵,
            群体狂乱,
            塔兰吉公主,
            邦桑迪死亡之神,
            西瓦尔拉猛虎之神,
            暂避锋芒,
            法拉基战斧,
            战斗准备,
            新人登场,
            永恒祭司,
            圣光闪现,
            高阶祭司塞卡尔,
            猛虎之灵,
            老虎,
            元素唤醒,
            奥术暴龙,
            狂暴咒术师,
            古拉巴什之力,
            灼烧,
            火焰狂人,
            加亚莱龙鹰之神,
            炎魔之王拉格纳罗斯,
            冲击波,
            妖术领主玛拉卡斯,
            龙鹰之灵,
            龙鹰之力,
            毁灭打击,
            烬鳞幼龙,
            重金属狂潮,
            鞭笞者苏萨斯,
            燃棘枪兵,
            犀牛之灵,
            犀牛之灵庇护,
            指挥官沃恩,
            阿卡里犀牛之神,
            犀牛厚皮,
            主人的召唤,
            树语者,
            古树,
            战争德鲁伊罗缇,
            甲龙,
            剜齿虎,
            翼手龙,
            暴掠龙,
            卡格瓦青蛙之神,
            诱饵射击,
            魔暴龙,
            魔泉山猫,
            山猫,
            血顶战略家,
            蟾蜍雨,
            蟾蜍,
            舔舔魔杖,
            领主之鞭,
            巨龙怒吼,
            萨隆铁矿监工,
            自由的矿工,
            大胆的吞火者,
            烈火如织,
            裂魂残像,
            狂野兽王,
            战争印记,
            嗜睡的神枪手,
            起床气,
            茶水小弟,
            优质活水,
            墓园恐魔,
            格罗尔鲨鱼之神,
            血染大海,
            疯入膏肓,
            彻底疯狂,
            奥金尼幻象,
            黑暗灵魂,
            亡者之灵,
            邦桑迪的信徒,
            甲虫卵,
            甲虫,
            藏宝海湾荷官,
            无助的幼雏,
            复仇者,
            古拉巴什小鸡,
            准备出击,
            鲨鳍后援,
            海盗杂兵,
            再生暴徒,
            香蕉小丑,
            香蕉,
            调皮的噬踝者,
            莫什奥格执行者,
            好斗的侏儒,
            侏儒战意,
            场馆保镖,
            古拉巴什供品,
            赛场狂热者,
            哇哦,
            鱼人大厨,
            竞技场奴隶主,
            疾疫使者,
            火树巫医,
            破盾者,
            竞技场财宝箱,
            龙喉喷火者,
            达卡莱幻术师,
            阵线破坏者,
            癫狂,
            蒙面选手,
            暴牙震颤者,
            暴牙破坏者,
            莫什奥格播报员,
            冰淇淋小贩,
            钳嘴龟盾卫,
            送葬者安德提卡,
            殉葬亡语,
            夺灵者哈卡,
            堕落之血,
            乌达斯塔,
            血爪,
            赞达拉武士,
            精神焕发,
            暴躁的巨龟,
            阿曼尼战熊,
            粗暴的恐怖巨魔,
            恶魔之箭,
            魔精大师兹伊希,
            荒野的复仇,
            看台喷火龙,
            汤水商贩,
            哈尔拉兹山猫之神,
            山猫之灵,
            哈尔拉兹的祝福,
            拉法姆的阴谋,
            砰砰博士的阴谋,
            哈加莎的阴谋,
            托瓦格尔的阴谋,
            拉祖尔的阴谋,
            拉祖尔的诅咒,
            阴暗的人影,
            暗藏身形,
            无面渗透者,
            荆棘帮箭猪,
            活动喷泉,
            下水道渔人,
            泥沼变形怪,
            泥沼变形,
            机械拷问者,
            空间撕裂器,
            发条地精,
            扫荡打击,
            圣剑扳手,
            爆破之王砰砰,
            不眠之魂,
            砰砰机甲,
            劫掠,
            突变,
            毒鳍鱼人,
            剧毒之鳍,
            旅行医者,
            破咒珠宝师,
            光彩照人,
            达拉然圣剑士,
            夺日者间谍,
            窃取机密,
            荆棘帮巫婆,
            融合怪,
            机械保险箱,
            保险柜,
            魔法订书匠,
            荆棘帮小偷,
            奥术仆从,
            紫罗兰魔剑士,
            魔法光辉,
            紫罗兰典狱官,
            孤注一掷,
            青铜传令官,
            青铜龙,
            龙语者,
            巨龙之吼,
            渡鸦信使,
            至暗时刻,
            咒术师的召唤,
            魔法蓝蛙,
            阿兰纳丝蛛后,
            森林的援助,
            水晶之力,
            利刺荆棘,
            愈合之花,
            远古祝福,
            远古的祝福,
            晶歌传送门,
            橡果人,
            松鼠,
            织命者,
            卢森巴克,
            卢森巴克之魂,
            未鉴定的合约,
            刺客合约,
            招募合约,
            赏金合约,
            叛变合约,
            标记射击,
            奥术弓箭手,
            急速射击,
            湮灭战车,
            九命兽魂,
            猛兽出笼,
            双足飞龙,
            温蕾萨风行者,
            群星之怒,
            索利达尔群星之怒,
            怪盗布缆鼠,
            怪盗征募员,
            怪盗恶霸,
            荆棘帮蟊贼,
            劫匪之王托瓦格尔,
            至尊盗王拉法姆,
            沼泽女王哈加莎,
            德鲁斯瓦恐魔,
            女巫杂酿,
            淤泥吞食者,
            奥术守望者,
            隐秘破坏者,
            夺日者战斗法师,
            药水商人,
            咖啡师林彻,
            艾泽里特元素,
            奥术扩张,
            下水道软泥怪,
            骄傲的防御者,
            恶狼大法师,
            大厨诺米,
            猛火元素,
            大法师瓦格斯,
            霸气的旅店老板娘,
            保护窖藏,
            巨型小鬼,
            小鬼当家,
            性急的杂兵,
            邪恶之力,
            传送门大恶魔,
            古怪的铭文师,
            复仇卷轴,
            光铸祝福,
            永不屈服,
            神秘之刃,
            神秘力量,
            指挥官蕾撒,
            卡德加,
            肯瑞托三修法师,
            肯瑞托的诅咒,
            霜冻射线,
            创世之力,
            诺萨莉,
            传送门守护者,
            地狱犬传送门,
            地狱犬,
            闪光蝴蝶,
            狩猎盛宴,
            狩猎小队,
            莽头食人魔,
            情势反转,
            法力飓风,
            机械巨熊,
            小鬼狱火,
            小鬼真棒,
            怪盗天才,
            邪能领主贝图格,
            滚滚邪能,
            魔术戏法,
            卡雷苟斯,
            无面跟班,
            狗头人跟班,
            女巫跟班,
            鱼人之魂,
            下水道销赃人,
            街头智慧,
            宿敌,
            塔克诺兹维克,
            摇摆矿锄,
            亡者卡特琳娜,
            禁忌咒文,
            群体复活,
            斯卡基尔,
            斯卡基尔的祝福,
            冒险号角,
            雄姿英发,
            战略转移,
            拉祖尔女士,
            决斗,
            守护者斯塔拉蒂斯,
            守卫梦境之路,
            水晶树妖,
            达拉然图书管理员,
            档案员艾丽西娜,
            地精跟班,
            超短引线,
            虚灵跟班,
            暴走旋风,
            旋风冲锋,
            荆棘帮斗猪,
            荆棘帮马仔,
            无面暴怒者,
            熟谙脉络,
            飞行管理员,
            狮鹫,
            法力之池,
            复生大盗,
            疯狂召唤师,
            耶比托乔巴斯,
            玩具模型,
            大甩卖,
            凶恶的废钢猎犬,
            推土壮汉,
            提振士气,
            欧米茄毁灭者,
            散财军士,
            魔法飞毯,
            飞得更高,
            特殊坐骑商人,
            坑道爆破师,
            晶角雄鹿,
        }

        public cardName cardNamestringToEnum(string s)
        {
            CardDB.cardName NameEnum;
            if (Enum.TryParse<cardName>(s, false, out NameEnum)) return NameEnum;
            else return CardDB.cardName.unknown;
        }

        public enum ErrorType2
        {
            INVALID = -1,
            NONE = 0,
            REQ_MINION_TARGET = 1,
            REQ_FRIENDLY_TARGET = 2,
            REQ_ENEMY_TARGET = 3,
            REQ_DAMAGED_TARGET = 4,
            REQ_MAX_SECRETS = 5,
            REQ_FROZEN_TARGET = 6,
            REQ_CHARGE_TARGET = 7,
            REQ_TARGET_MAX_ATTACK = 8,
            REQ_NONSELF_TARGET = 9,
            REQ_TARGET_WITH_RACE = 10,
            REQ_TARGET_TO_PLAY = 11,
            REQ_NUM_MINION_SLOTS = 12,
            REQ_WEAPON_EQUIPPED = 13,
            REQ_ENOUGH_MANA = 14,
            REQ_YOUR_TURN = 15,
            REQ_NONSTEALTH_ENEMY_TARGET = 16,
            REQ_HERO_TARGET = 17,
            REQ_SECRET_ZONE_CAP = 18,
            REQ_MINION_CAP_IF_TARGET_AVAILABLE = 19,
            REQ_MINION_CAP = 20,
            REQ_TARGET_ATTACKED_THIS_TURN = 21,
            REQ_TARGET_IF_AVAILABLE = 22,
            REQ_MINIMUM_ENEMY_MINIONS = 23,
            REQ_TARGET_FOR_COMBO = 24,
            REQ_NOT_EXHAUSTED_ACTIVATE = 25,
            REQ_UNIQUE_SECRET_OR_QUEST = 26,
            REQ_TARGET_TAUNTER = 27,
            REQ_CAN_BE_ATTACKED = 28,
            REQ_ACTION_PWR_IS_MASTER_PWR = 29,
            REQ_TARGET_MAGNET = 30,
            REQ_ATTACK_GREATER_THAN_0 = 31,
            REQ_ATTACKER_NOT_FROZEN = 32,
            REQ_HERO_OR_MINION_TARGET = 33,
            REQ_CAN_BE_TARGETED_BY_SPELLS = 34,
            REQ_SUBCARD_IS_PLAYABLE = 35,
            REQ_TARGET_FOR_NO_COMBO = 36,
            REQ_NOT_MINION_JUST_PLAYED = 37,
            REQ_NOT_EXHAUSTED_HERO_POWER = 38,
            REQ_CAN_BE_TARGETED_BY_OPPONENTS = 39,
            REQ_ATTACKER_CAN_ATTACK = 40,
            REQ_TARGET_MIN_ATTACK = 41,
            REQ_CAN_BE_TARGETED_BY_HERO_POWERS = 42,
            REQ_ENEMY_TARGET_NOT_IMMUNE = 43,
            REQ_ENTIRE_ENTOURAGE_NOT_IN_PLAY = 44,
            REQ_MINIMUM_TOTAL_MINIONS = 45,
            REQ_MUST_TARGET_TAUNTER = 46,
            REQ_UNDAMAGED_TARGET = 47,
            REQ_CAN_BE_TARGETED_BY_BATTLECRIES = 48,
            REQ_STEADY_SHOT = 49,
            REQ_MINION_OR_ENEMY_HERO = 50,
            REQ_TARGET_IF_AVAILABLE_AND_DRAGON_IN_HAND = 51,
            REQ_LEGENDARY_TARGET = 52,
            REQ_FRIENDLY_MINION_DIED_THIS_TURN = 53,
            REQ_FRIENDLY_MINION_DIED_THIS_GAME = 54,
            REQ_ENEMY_WEAPON_EQUIPPED = 55,
            REQ_TARGET_IF_AVAILABLE_AND_MINIMUM_FRIENDLY_MINIONS = 56,
            REQ_TARGET_WITH_BATTLECRY = 57,
            REQ_TARGET_WITH_DEATHRATTLE = 58,
            REQ_TARGET_IF_AVAILABLE_AND_MINIMUM_FRIENDLY_SECRETS = 59,
            REQ_SECRET_ZONE_CAP_FOR_NON_SECRET = 60,
            REQ_TARGET_EXACT_COST = 61,
            REQ_STEALTHED_TARGET = 62,
            REQ_MINION_SLOT_OR_MANA_CRYSTAL_SLOT = 63,
            REQ_MAX_QUESTS = 64,
            REQ_TARGET_IF_AVAILABE_AND_ELEMENTAL_PLAYED_LAST_TURN = 65,
            REQ_TARGET_NOT_VAMPIRE = 66,
            REQ_TARGET_NOT_DAMAGEABLE_ONLY_BY_WEAPONS = 67,
            REQ_NOT_DISABLED_HERO_POWER = 68,
            REQ_MUST_PLAY_OTHER_CARD_FIRST = 69,
            REQ_HAND_NOT_FULL = 70,
            REQ_DRAG_TO_PLAY = 71,
        }

        public class Card
        {
            //public string CardID = "";
            public cardName name = cardName.unknown;
            public int race = 0;
            public int rarity = 0;
            public int cost = 0;
            public int Class = 0;
            public cardtype type = CardDB.cardtype.NONE;
            //public string description = "";

            public int Attack = 0;
            public int Health = 0;
            public int Durability = 0;//for weapons
            public bool tank = false;
            public bool Silence = false;
            public bool choice = false;
            public bool windfury = false;
            public bool poisonous = false;
            public bool lifesteal = false;
            public bool deathrattle = false;
            public bool battlecry = false;
            public bool discover = false;
            public bool oneTurnEffect = false;
            public bool Enrage = false;
            public bool Aura = false;
            public bool Elite = false;
            public bool Combo = false;
            public int overload = 0;
            public bool immuneWhileAttacking = false;
            public bool untouchable = false;
            public bool Stealth = false;
            public bool Freeze = false;
            public bool AdjacentBuff = false;
            public bool Shield = false;
            public bool Charge = false;
            public bool Secret = false;
            public bool Quest = false;
            public bool Morph = false;
            public bool Spellpower = false;
            public bool Inspire = false;



            public int needEmptyPlacesForPlaying = 0;
            public int needWithMinAttackValueOf = 0;
            public int needWithMaxAttackValueOf = 0;
            public int needRaceForPlaying = 0;
            public int needMinNumberOfEnemy = 0;
            public int needMinTotalMinions = 0;
            public int needMinOwnMinions = 0;
            public int needMinionsCapIfAvailable = 0;
            public int needControlaSecret = 0;
            
            //additional data
            public bool isToken = false;
            public int isCarddraw = 0;
            public bool damagesTarget = false;
            public bool damagesTargetWithSpecial = false;
            public int targetPriority = 0;
            public bool isSpecialMinion = false;

            public int spellpowervalue = 0;
            public cardIDEnum cardIDenum = cardIDEnum.None;
            public List<ErrorType2> playrequires;
            public List<cardtrigers> trigers;

            public SimTemplate sim_card;

            public Card()
            {
                playrequires = new List<ErrorType2>();
            }

            public Card(Card c)
            {
                //this.entityID = c.entityID;
                this.rarity = c.rarity;
                this.AdjacentBuff = c.AdjacentBuff;
                this.Attack = c.Attack;
                this.Aura = c.Aura;
                this.battlecry = c.battlecry;
                this.discover = c.discover;
                //this.CardID = c.CardID;
                this.Charge = c.Charge;
                this.choice = c.choice;
                this.Combo = c.Combo;
                this.cost = c.cost;
                this.deathrattle = c.deathrattle;
                this.Inspire = c.Inspire;
                //this.description = c.description;
                this.Durability = c.Durability;
                this.Elite = c.Elite;
                this.Enrage = c.Enrage;
                this.Freeze = c.Freeze;
                this.Health = c.Health;
                this.immuneWhileAttacking = c.immuneWhileAttacking;
                this.untouchable = c.untouchable;
                this.Morph = c.Morph;
                this.name = c.name;
                this.needEmptyPlacesForPlaying = c.needEmptyPlacesForPlaying;
                this.needMinionsCapIfAvailable = c.needMinionsCapIfAvailable;
                this.needMinNumberOfEnemy = c.needMinNumberOfEnemy;
                this.needMinTotalMinions = c.needMinTotalMinions;
                this.needMinOwnMinions = c.needMinOwnMinions;
                this.needRaceForPlaying = c.needRaceForPlaying;
                this.needControlaSecret = c.needControlaSecret;
                this.needWithMaxAttackValueOf = c.needWithMaxAttackValueOf;
                this.needWithMinAttackValueOf = c.needWithMinAttackValueOf;
                this.oneTurnEffect = c.oneTurnEffect;
                this.playrequires = new List<ErrorType2>(c.playrequires);
                this.poisonous = c.poisonous;
                this.lifesteal = c.lifesteal;
                this.race = c.race;
                this.overload = c.overload;
                this.Secret = c.Secret;
                this.Quest = c.Quest;
                this.Shield = c.Shield;
                this.Silence = c.Silence;
                this.Spellpower = c.Spellpower;
                this.spellpowervalue = c.spellpowervalue;
                this.Stealth = c.Stealth;
                this.tank = c.tank;
                this.type = c.type;
                this.windfury = c.windfury;
                this.cardIDenum = c.cardIDenum;
                this.sim_card = c.sim_card;
                this.isToken = c.isToken;
            }

            public bool isRequirementInList(CardDB.ErrorType2 et)
            {
                return this.playrequires.Contains(et);
            }

            public List<Minion> getTargetsForCard(Playfield p, bool isLethalCheck, bool own)
            {
                //if wereTargets=true and 0 targets at end -> then can not play this card
                List<Minion> retval = new List<Minion>();
                if (this.type == CardDB.cardtype.MOB && ((own && p.ownMinions.Count >= 7) || (!own && p.enemyMinions.Count >=7))) return retval; // cant play mob, if we have allready 7 mininos
                if (this.Secret && ((own && (p.ownSecretsIDList.Contains(this.cardIDenum) || p.ownSecretsIDList.Count >= 5)) || (!own && p.enemySecretCount >= 5))) return retval;
                //if (p.mana < this.getManaCost(p, 1)) return retval;

                if (this.playrequires.Count == 0) { retval.Add(null); return retval; }

                List<Minion> targets = new List<Minion>();
                bool targetAll = false;
                bool targetAllEnemy = false;
                bool targetAllFriendly = false;
                bool targetEnemyHero = false;
                bool targetOwnHero = false;
                bool targetOnlyMinion = false;
                bool extraParam = false;
                bool wereTargets = false;
                bool REQ_UNDAMAGED_TARGET = false;
                bool REQ_TARGET_WITH_DEATHRATTLE = false;
                bool REQ_TARGET_WITH_RACE = false;
                bool REQ_TARGET_MIN_ATTACK = false;
                bool REQ_TARGET_MAX_ATTACK = false;
                bool REQ_MUST_TARGET_TAUNTER = false;
                bool REQ_STEADY_SHOT = false;
                bool REQ_FROZEN_TARGET = false;
                bool REQ_HERO_TARGET = false;
                bool REQ_DAMAGED_TARGET = false;
                bool REQ_LEGENDARY_TARGET = false;
                bool REQ_TARGET_IF_AVAILABLE = false;
                bool REQ_STEALTHED_TARGET = false;
                bool REQ_TARGET_IF_AVAILABE_AND_ELEMENTAL_PLAYED_LAST_TURN = false;

                foreach (CardDB.ErrorType2 PlayReq in this.playrequires)
                {
                    switch (PlayReq)
                    {
                        case ErrorType2.REQ_TARGET_TO_PLAY:
                            targetAll = true;
                            continue;
                        case ErrorType2.REQ_MINION_TARGET:
                            targetOnlyMinion = true;
                            continue;
                        case ErrorType2.REQ_TARGET_IF_AVAILABLE:
                            REQ_TARGET_IF_AVAILABLE = true;
                            targetAll = true;
                            continue;
                        case ErrorType2.REQ_FRIENDLY_TARGET:
                            if (own) targetAllFriendly = true;
                            else targetAllEnemy = true;
                            continue;
                        case ErrorType2.REQ_NUM_MINION_SLOTS:
                            if ((own ? p.ownMinions.Count : p.enemyMinions.Count) > 7 - this.needEmptyPlacesForPlaying) return retval;
                            continue;
                        case ErrorType2.REQ_MINION_SLOT_OR_MANA_CRYSTAL_SLOT:
                            if (own) { if (p.ownMinions.Count > 6 & p.ownMaxMana > 9) return retval; }
                            else if (p.enemyMinions.Count > 6 & p.enemyMaxMana > 9) return retval;
                            continue;
                        case ErrorType2.REQ_ENEMY_TARGET:
                            if (own) targetAllEnemy = true;
                            else targetAllFriendly = true;
                            continue;
                        case ErrorType2.REQ_HERO_TARGET:
                            REQ_HERO_TARGET = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_MINIMUM_ENEMY_MINIONS:
                            if ((own ? p.enemyMinions.Count : p.ownMinions.Count) < this.needMinNumberOfEnemy) return retval;
                            continue;
                        case ErrorType2.REQ_NONSELF_TARGET:
                            targetAll = true;
                            continue;
                        case ErrorType2.REQ_TARGET_WITH_RACE:
                            REQ_TARGET_WITH_RACE = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_DAMAGED_TARGET:
                            REQ_DAMAGED_TARGET = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_TARGET_MAX_ATTACK:
                            REQ_TARGET_MAX_ATTACK = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_WEAPON_EQUIPPED:
                            if ((own ? p.ownWeapon.Durability : p.enemyWeapon.Durability) == 0) return retval;
                            continue;
                        case ErrorType2.REQ_TARGET_FOR_COMBO:
                            if (p.cardsPlayedThisTurn >=1) targetAll = true;
                            continue;
                        case ErrorType2.REQ_TARGET_MIN_ATTACK:
                            REQ_TARGET_MIN_ATTACK = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_MINIMUM_TOTAL_MINIONS:
                            if (this.needMinTotalMinions > p.ownMinions.Count + p.enemyMinions.Count) return retval;
                            continue;
                        case ErrorType2.REQ_MINION_CAP_IF_TARGET_AVAILABLE:
                            if ((own ? p.ownMinions.Count : p.enemyMinions.Count) > 7 - this.needMinionsCapIfAvailable) return retval;
                            continue;
                        case ErrorType2.REQ_ENTIRE_ENTOURAGE_NOT_IN_PLAY:
                            int difftotem = 0;
                            foreach (Minion m in (own ? p.ownMinions : p.enemyMinions))
                            {
                                if (m.name == CardDB.cardName.healingtotem || m.name == CardDB.cardName.wrathofairtotem || m.name == CardDB.cardName.searingtotem || m.name == CardDB.cardName.stoneclawtotem) difftotem++;
                            }
                            if (difftotem == 4) return retval;
                            continue;
                        case ErrorType2.REQ_MUST_TARGET_TAUNTER:
                            REQ_MUST_TARGET_TAUNTER = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_TARGET_IF_AVAILABLE_AND_DRAGON_IN_HAND:
                            if (own)
                            {
                                foreach (Handmanager.Handcard hc in p.owncards)
                                {
                                    if ((TAG_RACE)hc.card.race == TAG_RACE.DRAGON) {targetAll = true; break; }
                                }
                            }
                            else targetAll = true; // apriori the enemy have a dragon
                            continue;
                        case ErrorType2.REQ_LEGENDARY_TARGET:
                            REQ_LEGENDARY_TARGET = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_UNDAMAGED_TARGET:
                            REQ_UNDAMAGED_TARGET = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_TARGET_WITH_DEATHRATTLE:
                            REQ_TARGET_WITH_DEATHRATTLE = true;
                            targetOnlyMinion = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_TARGET_IF_AVAILABE_AND_ELEMENTAL_PLAYED_LAST_TURN:
                            REQ_TARGET_IF_AVAILABE_AND_ELEMENTAL_PLAYED_LAST_TURN = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_STEADY_SHOT:
                            REQ_STEADY_SHOT = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_FROZEN_TARGET:
                            REQ_FROZEN_TARGET = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_MINION_OR_ENEMY_HERO:
                            REQ_STEADY_SHOT = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_STEALTHED_TARGET:
                            REQ_STEALTHED_TARGET = true;
                            extraParam = true;
                            continue;
                        case ErrorType2.REQ_ENEMY_WEAPON_EQUIPPED:
                            if (own)
                            {
                                if (p.enemyWeapon.Durability > 0) targetEnemyHero = true;
                                else return retval;
                            }
                            else
                            {
                                if (p.ownWeapon.Durability > 0) targetOwnHero = true;
                                else return retval;
                            }
                            continue;
                        case ErrorType2.REQ_TARGET_IF_AVAILABLE_AND_MINIMUM_FRIENDLY_MINIONS:
                            int tmp = (own) ? p.ownMinions.Count : p.enemyMinions.Count;
                            if (tmp >= needMinOwnMinions) targetAll = true;
                            continue;
                        case ErrorType2.REQ_TARGET_IF_AVAILABLE_AND_MINIMUM_FRIENDLY_SECRETS:
                            if (p.ownSecretsIDList.Count >= needControlaSecret) targetAll = true;
                            continue;
                        case ErrorType2.REQ_MUST_PLAY_OTHER_CARD_FIRST:
                            if (p.cardsPlayedThisTurn == 0) return retval;
                            continue;
                        case ErrorType2.REQ_HAND_NOT_FULL:
                            if (p.owncards.Count == 10) return retval;
                            continue;

                            //default:
                    }
                }

			    if(targetAll)
			    {
                    wereTargets = true;
                    if (targetAllFriendly != targetAllEnemy)
                    {
                        if (targetAllFriendly)
                        {
                            foreach (Minion m in p.ownMinions) if (!m.untouchable) targets.Add(m);
                        }
                        else
                        {
                            foreach (Minion m in p.enemyMinions) if (!m.untouchable) targets.Add(m);
                        }
                    }
                    else
                    {
                        foreach (Minion m in p.ownMinions) if (!m.untouchable) targets.Add(m);
                        foreach (Minion m in p.enemyMinions) if (!m.untouchable) targets.Add(m);
                    }
				    if(targetOnlyMinion)
				    {
                        targetEnemyHero = false;
                        targetOwnHero = false;
				    }
                    else
                    {
                        if (!p.enemyHero.immune) targetEnemyHero = true;
                        if (!p.ownHero.immune) targetOwnHero = true;
                        if (targetAllEnemy) targetOwnHero = false;
                        if (targetAllFriendly) targetEnemyHero = false;
                    }
			    }

                if(extraParam)
                {
                    wereTargets = true;
                    if(REQ_TARGET_WITH_RACE)
                    {
                        foreach (Minion m in targets)
                        {
                            if (m.handcard.card.race != this.needRaceForPlaying) m.extraParam = true;
                        }
                        targetOwnHero = (p.ownHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON);
                        targetEnemyHero = (p.enemyHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON);
                    }
                    if(REQ_HERO_TARGET)
                    {
                        foreach (Minion m in targets)
                        {
                            m.extraParam = true;
                        }
                        targetOwnHero = true;
                        targetEnemyHero = true;
                    }
                    if(REQ_DAMAGED_TARGET)
                    {
                        foreach (Minion m in targets)
                        {
                            if (!m.wounded)
                            {
                                m.extraParam = true;
                            }
                        }
                        targetOwnHero = false;
                        targetEnemyHero = false;
                    }
                    if(REQ_TARGET_MAX_ATTACK)
                    {
                        foreach (Minion m in targets)
                        {
                            if (m.Angr > this.needWithMaxAttackValueOf)
                            {
                                m.extraParam = true;
                            }
                        }
                        targetOwnHero = false;
                        targetEnemyHero = false;
                    }
                    if(REQ_TARGET_MIN_ATTACK)
                    {
                        foreach (Minion m in targets)
                        {
                            if (m.Angr < this.needWithMinAttackValueOf)
                            {
                                m.extraParam = true;
                            }
                        }
                        targetOwnHero = false;
                        targetEnemyHero = false;
                    }
                    if(REQ_MUST_TARGET_TAUNTER)
                    {
                        foreach (Minion m in targets)
                        {
                            if (!m.taunt)
                            {
                                m.extraParam = true;
                            }
                        }
                        targetOwnHero = false;
                        targetEnemyHero = false;
                    }
                    if(REQ_UNDAMAGED_TARGET)
                    {
                        foreach (Minion m in targets)
                        {
                            if (m.wounded)
                            {
                                m.extraParam = true;
                            }
                        }
                        targetOwnHero = false;
                        targetEnemyHero = false;
                    }
                    if (REQ_STEALTHED_TARGET)
                    {
                        foreach (Minion m in targets)
                        {
                            if (!m.stealth)
                            {
                                m.extraParam = true;
                            }
                        }
                        targetOwnHero = false;
                        targetEnemyHero = false;
                    }
                    if (REQ_TARGET_WITH_DEATHRATTLE)
                    {
                        foreach (Minion m in targets)
                        {
                            if (!m.silenced && (m.handcard.card.deathrattle || m.deathrattle2 != null ||
                            m.ancestralspirit + m.desperatestand + m.souloftheforest + m.stegodon + m.livingspores + m.explorershat + m.returnToHand + m.infest > 0)) continue;               
                            else m.extraParam = true;
                        }
                        targetOwnHero = false;
                        targetEnemyHero = false;
                    }
                    if (REQ_TARGET_IF_AVAILABE_AND_ELEMENTAL_PLAYED_LAST_TURN)
                    {
                        if (p.anzOwnElementalsLastTurn < 1)
                        {
                            foreach (Minion m in targets) m.extraParam = true;
                            targetOwnHero = false;
                            targetEnemyHero = false;
                        }
                    }
                    if(REQ_LEGENDARY_TARGET)
                    {
                        wereTargets = false;
                        foreach (Minion m in targets)
                        {
                            if (m.handcard.card.rarity != 5) m.extraParam = true;
                        }
                        targetOwnHero = false;
                        targetEnemyHero = false;
                    }
                    if(REQ_STEADY_SHOT)
                    {
                        if ((p.weHaveSteamwheedleSniper && own) || (p.enemyHaveSteamwheedleSniper && !own))
                        {
                            foreach (Minion m in targets)
                            {
                                if (m.cantBeTargetedBySpellsOrHeroPowers && (this.type == cardtype.HEROPWR || this.type == cardtype.SPELL))
                                {
                                    m.extraParam = true;
                                    if(m.stealth && !m.own) m.extraParam = true;
                                }
                            }
                            if (own) targetEnemyHero = true;
                            else targetOwnHero = true;
                        }
                        else wereTargets = false;
                    }
                    if (REQ_FROZEN_TARGET)
                    {
                        
                        foreach (Minion m in targets)
                        {
                            if (!m.frozen) m.extraParam = true;
                        }
                    }                    
                }

                if (targetEnemyHero && own && p.enemyHero.stealth) targetEnemyHero = false;
                if (targetOwnHero && !own && p.ownHero.stealth) targetOwnHero = false;

                if (isLethalCheck) 
                {
                    if (targetEnemyHero && own) retval.Add(p.enemyHero);
                    else if (targetOwnHero && !own) retval.Add(p.ownHero);
                    
                    switch (this.type)
                    {
                        case cardtype.SPELL:
                            if (p.prozis.penman.attackBuffDatabase.ContainsKey(this.name))
                            {
                                if (targetOwnHero && own) retval.Add(p.ownHero);
                                foreach (Minion m in targets)
                                {
                                    if (m.extraParam != true && !m.cantBeTargetedBySpellsOrHeroPowers)
                                    {
                                        if (m.own)
                                        {
                                            if (m.Ready) retval.Add(m);
                                        }
                                        else if (m.taunt) retval.Add(m);
                                    }
                                    m.extraParam = false;
                                }
                            }
                            else
                            {
                                switch (this.name)
                                {
                                    case cardName.polymorphboar:
                                        foreach (Minion m in targets)
                                        {
                                            m.extraParam = false;
                                            if (m.cantBeTargetedBySpellsOrHeroPowers) continue;
                                            if (m.own) retval.Add(m);
                                            else if (m.taunt) retval.Add(m);
                                        }
                                        break;
                                    case cardName.hex: goto case cardName.polymorph;
                                    case cardName.polymorph:
                                        foreach (Minion m in targets)
                                        {
                                            m.extraParam = false;
                                            if (!m.own && m.taunt && !m.cantBeTargetedBySpellsOrHeroPowers) retval.Add(m);
                                        }
                                        break;
                                }
                            }
                            break;
                        case cardtype.MOB:
                            foreach (Minion m in targets)
                            {
                                if (m.extraParam != true)
                                {
                                    if (m.stealth && !m.own) continue;
                                    retval.Add(m);
                                }
                                m.extraParam = false;
                            }
                            break;
                        case cardtype.HEROPWR:
                            if (p.prozis.penman.attackBuffDatabase.ContainsKey(this.name))
                            {
                                foreach (Minion m in targets)
                                {
                                    if (m.extraParam != true && !m.cantBeTargetedBySpellsOrHeroPowers)
                                    {
                                        if (m.own)
                                        {
                                            if (m.Ready) retval.Add(m);
                                        }
                                        else if (m.taunt) retval.Add(m);
                                    }
                                    m.extraParam = false;
                                }
                            }
                            break;
                    }
                }
                else
                {
                    if (targetEnemyHero) retval.Add(p.enemyHero);
                    if (targetOwnHero) retval.Add(p.ownHero);

                    foreach (Minion m in targets)
                    {
                        if (m.extraParam != true)
                        {
                            if (m.stealth && !m.own) continue;
                            if (m.cantBeTargetedBySpellsOrHeroPowers && (this.type == cardtype.SPELL || this.type == cardtype.HEROPWR)) continue;
                            retval.Add(m);
                        }
                        m.extraParam = false;
                    }
                }

                if (retval.Count == 0 && (!wereTargets || REQ_TARGET_IF_AVAILABLE)) retval.Add(null);

                return retval;
            }
            

            public List<Minion> getTargetsForHeroPower(Playfield p, bool own)
            {
                List<Minion> trgts = getTargetsForCard(p, p.isLethalCheck, own);
                cardName abName = own ? p.ownHeroAblility.card.name : p.enemyHeroAblility.card.name;
                int abType = 0; //0 none, 1 damage, 2 heal, 3 baff
                switch (abName)
                {
                    case cardName.heal: goto case cardName.lesserheal; 
                    case cardName.lesserheal:
                        if (p.anzOwnAuchenaiSoulpriest > 0 || p.embracetheshadow > 0) abType = 1;
                        else abType = 2;
                        break;
                    case cardName.ballistashot: abType = 1; break; 
                    case cardName.steadyshot: abType = 1; break;
                    case cardName.fireblast: abType = 1; break;
                    case cardName.fireblastrank2: abType = 1; break;
                    case cardName.lightningjolt: abType = 1; break;
                    case cardName.mindspike: abType = 1; break;
                    case cardName.mindshatter: abType = 1; break;
                    case cardName.powerofthefirelord: abType = 1; break;
                    case cardName.shotgunblast: abType = 1; break;
                    case cardName.unbalancingstrike: abType = 1; break;
                    case cardName.dinomancy: abType = 3; break;
                }

                switch (abType)
                {
                    case 2:
                        List<Minion> minions = own ? p.ownMinions : p.enemyMinions;
                        int tCount = minions.Count;
                        bool needCut = true;
                        for (int i = 0; i < tCount; i++)
                        {
                            switch (minions[i].name)
                            {
                                case cardName.shadowboxer: 
                                    if (own && p.enemyHero.Hp == 1 && p.enemyMinions.Count > 0) needCut = false;
                                    break;
                                case cardName.holychampion: needCut = false; break;
                                case cardName.lightwarden: needCut = false; break;
                                case cardName.northshirecleric: needCut = false; break;
                                
                                
                            }
                        }
                        
                        tCount = trgts.Count;
                        if (tCount > 0)
                        {
                            if (trgts[0] != null)
                            {
                                List<Minion> tmp = new List<Minion>();
                                for (int i = 0; i < tCount; i++)
                                {
                                    Minion m = trgts[i];
                                    if (m.Hp < m.maxHp)
                                    {
                                        if (needCut)
                                        {
                                            if (m.own == own) tmp.Add(m);
                                        }
                                        else tmp.Add(m);
                                    }
                                }
                                return tmp;
                            }
                        }
                        break;
                }
                return trgts;
            }

            public int calculateManaCost(Playfield p)//calculates the mana from orginal mana, needed for back-to hand effects and new draw
            {
                int retval = this.cost;
                int offset = 0;

                if (p.anzOwnShadowfiend > 0) offset -= p.anzOwnShadowfiend;

                switch (this.type)
                {
                    case cardtype.MOB:
                        if (p.anzOwnAviana > 0) retval = 1;

                        offset += p.ownMinionsCostMore;

                        if (this.deathrattle) offset += p.ownDRcardsCostMore;

                        offset += p.managespenst;

                        int temp = -(p.startedWithbeschwoerungsportal) * 2;
                        if (retval + temp <= 0) temp = -retval + 1;
                        offset = offset + temp;

                        if (p.mobsplayedThisTurn == 0)
                        {
                            offset -= p.winzigebeschwoererin;
                        }

                        if (this.battlecry)
                        {
                            offset += p.nerubarweblord * 2;
                        }

                        if ((TAG_RACE)this.race == TAG_RACE.MECHANICAL)
                        { //if the number of zauberlehrlings change
                            offset -= p.anzOwnMechwarper;
                        }
                        break;
                    case cardtype.SPELL:
                        if (p.nextSpellThisTurnCost0) return 0;
                        offset += p.ownSpelsCostMore; 
                        if (p.playedPreparation)
                        { //if the number of zauberlehrlings change
                            offset -= 3;
                        }
                        break;
                    case cardtype.WEAPON:
                        offset -= p.blackwaterpirate * 2;
                        if (this.deathrattle) offset += p.ownDRcardsCostMore;
                        break;
                }

                offset -= p.myCardsCostLess;

                switch (this.name)
                {
                    case CardDB.cardName.happyghoul:
                        if (p.ownHero.anzGotHealed > 0) retval = offset;
                        break;
                    case CardDB.cardName.wildmagic:
                        retval = offset;
                        break;
                    case CardDB.cardName.dreadcorsair:
                        retval = retval + offset - p.ownWeapon.Angr;
                        break;
                    case CardDB.cardName.volcanicdrake:
                        retval = retval + offset - p.ownMinionsDiedTurn - p.enemyMinionsDiedTurn;
                        break;
                    case CardDB.cardName.knightofthewild:
                        retval = retval + offset - p.tempTrigger.ownBeastSummoned;
                        break;
                    case CardDB.cardName.seagiant:
                        retval = retval + offset - p.ownMinions.Count - p.enemyMinions.Count;
                        break;
                    case CardDB.cardName.mountaingiant:
                        retval = retval + offset - p.owncards.Count;
                        break;
                    case CardDB.cardName.clockworkgiant:
                        retval = retval + offset - p.enemyAnzCards;
                        break;
                    case CardDB.cardName.moltengiant:
                        retval = retval + offset - p.ownHero.maxHp + p.ownHero.Hp;
                        break;
                    case CardDB.cardName.frostgiant:
                        retval = retval + offset - p.anzUsedOwnHeroPower;
                        break;
                    case CardDB.cardName.arcanegiant:
                        retval = retval + offset - p.spellsplayedSinceRecalc;
                        break;
                    case CardDB.cardName.snowfurygiant:
                        retval = retval + offset - p.ueberladung;
                        break;
                    case CardDB.cardName.kabalcrystalrunner:
                        retval = retval + offset - 2 * p.secretsplayedSinceRecalc;
                        break;
                    case CardDB.cardName.secondratebruiser:
                        retval = retval + offset - ((p.enemyMinions.Count < 3) ? 0 : 2);
                        break;
                    case CardDB.cardName.golemagg:
                        retval = retval + offset - p.ownHero.maxHp + p.ownHero.Hp;
                        break;
                    case CardDB.cardName.volcaniclumberer:
                        retval = retval + offset - p.ownMinionsDiedTurn - p.enemyMinionsDiedTurn;
                        break;
                    case CardDB.cardName.skycapnkragg:
                        int costBonus = 0;
                        foreach (Minion m in p.ownMinions)
                        {
                            if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE) costBonus++;
                        }
                        retval = retval + offset - costBonus;
                        break;
                    case CardDB.cardName.everyfinisawesome:
                        int costBonusM = 0;
                        foreach (Minion m in p.ownMinions)
                        {
                            if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) costBonusM++;
                        }
                        retval = retval + offset - costBonusM;
                        break;
                    case CardDB.cardName.crush:
                        // cost 4 less if we have a dmged minion
                        bool dmgedminions = false;
                        foreach (Minion m in p.ownMinions)
                        {
                            if (m.wounded) dmgedminions = true;
                        }
                        if (dmgedminions)
                        {
                            retval = retval + offset - 4;
                        }
                        break;
                    default:
                        retval = retval + offset;
                        break;
                }

                if (this.Secret)
                {
                    if (p.anzOwnCloakedHuntress > 0 || p.nextSecretThisTurnCost0) retval = 0;
                }

                retval = Math.Max(0, retval);

                return retval;
            }

            public int getManaCost(Playfield p, int currentcost)
            {
                int retval = currentcost;
                
                int offset = 0; // if offset < 0 costs become lower, if >0 costs are higher at the end

                // CARDS that increase/decrease the manacosts of others ##############################
                switch (this.type)
                {
                    case cardtype.HEROPWR:
                        retval += p.ownHeroPowerCostLessOnce;
                        if (retval < 0) retval = 0;
                        return retval;
                    case cardtype.MOB:
                        
                        if (p.ownMinionsCostMore != p.ownMinionsCostMoreAtStart)
                        {
                            offset += (p.ownMinionsCostMore - p.ownMinionsCostMoreAtStart);
                        }

                        
                        if (this.deathrattle && p.ownDRcardsCostMore != p.ownDRcardsCostMoreAtStart)
                        {
                            offset += (p.ownDRcardsCostMore - p.ownDRcardsCostMoreAtStart);
                        }

                        
                        if (p.managespenst != p.startedWithManagespenst)
                        {
                            offset += (p.managespenst - p.startedWithManagespenst);
                        }

                        
                        if (this.battlecry && p.nerubarweblord != p.startedWithnerubarweblord)
                        {
                            offset += (p.nerubarweblord - p.startedWithnerubarweblord) * 2;
                        }
                        
                        
                        if (p.anzOwnAviana > 0)
                        {
                            retval = 1;
                        }

                        
                        if (p.anzOwnMechwarper != p.anzOwnMechwarperStarted && (TAG_RACE)this.race == TAG_RACE.MECHANICAL)
                        {
                            offset += (p.anzOwnMechwarperStarted - p.anzOwnMechwarper);
                        }

                        
                        if (p.startedWithbeschwoerungsportal != p.beschwoerungsportal)
                        {
                            offset += (p.startedWithbeschwoerungsportal - p.beschwoerungsportal) * 2;
                        }

                        
                        if (p.winzigebeschwoererin != p.startedWithWinzigebeschwoererin && ((p.turnCounter == 0 && p.startedWithMobsPlayedThisTurn == 0) || (p.turnCounter > 0 && p.mobsplayedThisTurn == 0)))
                        {
                            offset += (p.startedWithWinzigebeschwoererin - p.winzigebeschwoererin);
                        }

                        
                        if (p.anzOwnDragonConsort != p.anzOwnDragonConsortStarted && (TAG_RACE)this.race == TAG_RACE.DRAGON)
                        {
                            offset += (p.anzOwnDragonConsortStarted - p.anzOwnDragonConsort) * 2;
                        }
                        break;
                    case cardtype.SPELL:
                        
                        if (p.nextSpellThisTurnCost0) return 0;
                        
                        
                        if (p.ownSpelsCostMoreAtStart != p.ownSpelsCostMore)
                        {
                            offset += p.ownSpelsCostMore - p.ownSpelsCostMoreAtStart;
                        }

                        
                        if (p.playedPreparation)
                        {
                            offset -= 3;
                        }
                        break;
                    case cardtype.WEAPON:
                        
                        if (p.blackwaterpirateStarted != p.blackwaterpirate)
                        {
                            offset += (p.blackwaterpirateStarted - p.blackwaterpirate) * 2;
                        }
                        
                        if (this.deathrattle && p.ownDRcardsCostMore != p.ownDRcardsCostMoreAtStart)
                        {
                            offset += (p.ownDRcardsCostMore - p.ownDRcardsCostMoreAtStart);
                        }
                        break;
                }

                
                if (p.startedWithmyCardsCostLess != p.myCardsCostLess)
                {
                    offset += p.startedWithmyCardsCostLess - p.myCardsCostLess;
                }

                switch (this.name)
                {
                    case CardDB.cardName.volcaniclumberer:
                        retval = retval + offset - p.ownMinionsDiedTurn - p.enemyMinionsDiedTurn;
                        break;
                    case CardDB.cardName.solemnvigil:
                        retval = retval + offset - p.ownMinionsDiedTurn - p.enemyMinionsDiedTurn;
                        break;
                    case CardDB.cardName.volcanicdrake:
                        retval = retval + offset - p.ownMinionsDiedTurn - p.enemyMinionsDiedTurn;
                        break;
                    case CardDB.cardName.knightofthewild:
                        retval = retval + offset - p.tempTrigger.ownBeastSummoned;
                        break;
                    case CardDB.cardName.dragonsbreath:
                        retval = retval + offset - p.ownMinionsDiedTurn - p.enemyMinionsDiedTurn;
                        break;
                    case CardDB.cardName.dreadcorsair:
                        retval = retval + offset - p.ownWeapon.Angr + p.ownWeaponAttackStarted; // if weapon attack change we change manacost
                        break;
                    case CardDB.cardName.seagiant:
                        retval = retval + offset - p.ownMinions.Count - p.enemyMinions.Count + p.ownMobsCountStarted + p.enemyMobsCountStarted;
                        break;
                    case CardDB.cardName.mountaingiant:
                        retval = retval + offset - p.owncards.Count + p.ownCardsCountStarted;
                        break;
                    case CardDB.cardName.clockworkgiant:
                        retval = retval + offset - p.enemyAnzCards + p.enemyCardsCountStarted;
                        break;
                    case CardDB.cardName.moltengiant:
                        retval = retval + offset - p.ownHeroHpStarted + p.ownHero.Hp;
                        break;
                    case CardDB.cardName.frostgiant:
                        retval = retval + offset - p.anzUsedOwnHeroPower;
                        break;
                    case CardDB.cardName.arcanegiant:
                        retval = retval + offset - p.spellsplayedSinceRecalc;
                        break;
                    case CardDB.cardName.snowfurygiant:
                        retval = retval + offset - p.ueberladung;
                        break;
                    case CardDB.cardName.kabalcrystalrunner:
                        retval = retval + offset - 2 * p.secretsplayedSinceRecalc;
                        break;
                    case CardDB.cardName.secondratebruiser:
                        retval = retval + offset - ((p.enemyMinions.Count < 3) ? 0 : 2) + ((p.enemyMobsCountStarted < 3) ? 0 : 2);
                        break;
                    case CardDB.cardName.golemagg:
                        retval = retval + offset - p.ownHeroHpStarted + p.ownHero.Hp;
                        break;
                    case CardDB.cardName.skycapnkragg:
                        int costBonus = 0;
                        foreach (Minion m in p.ownMinions)
                        {
                            if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE) costBonus++;
                        }
                        retval = retval + offset - costBonus + p.anzOwnPiratesStarted;
                        break;
                    case CardDB.cardName.everyfinisawesome:
                        int costBonusM = 0;
                        foreach (Minion m in p.ownMinions)
                        {
                            if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) costBonusM++;
                        }
                        retval = retval + offset - costBonusM + p.anzOwnMurlocStarted;
                        break;
                    case CardDB.cardName.crush:
                        // cost 4 less if we have a dmged minion
                        bool dmgedminions = false;
                        foreach (Minion m in p.ownMinions)
                        {
                            if (m.wounded) dmgedminions = true;
                        }
                        if (dmgedminions != p.startedWithDamagedMinions)
                        {
                            if (dmgedminions)
                            {
                                retval = retval + offset - 4;
                            }
                            else
                            {
                                retval = retval + offset + 4;
                            }
                        }
                        break;
                    case CardDB.cardName.happyghoul:
                        if (p.ownHero.anzGotHealed > 0) retval = 0;
                        break;
                    case CardDB.cardName.wildmagic:
                        retval = 0;
                        break;
                    case CardDB.cardName.thingfrombelow:
                        if (p.playactions.Count > 0)
                        {
                            foreach (Action a in p.playactions)
                            {
                                if (a.actionType == actionEnum.playcard)
                                {
                                    switch(a.card.card.name)
                                    {
                                        case cardName.tuskarrtotemic: retval -= p.ownBrannBronzebeard + 1; break;
                                        default:
                                            if ((TAG_RACE)a.card.card.race == TAG_RACE.TOTEM) retval--;
                                            break;
                                    }
                                }
                                else if (a.actionType == actionEnum.useHeroPower)
                                {
                                    switch (a.card.card.name)
                                    {
                                        case cardName.totemiccall: retval--; break;
                                        case cardName.totemicslam: retval--; break;
                                    }
                                }
                            }
                        }
                        break;
                    default:
                        retval = retval + offset;
                        break;
                }

                if (this.Secret && (p.anzOwnCloakedHuntress > 0 || p.nextSecretThisTurnCost0))
                {
                    retval = 0;
                }
                
                retval = Math.Max(0, retval);
                
                return retval;
            }

            public bool canplayCard(Playfield p, int manacost, bool own)
            {
                if (p.mana < this.getManaCost(p, manacost)) return false;
                if (this.getTargetsForCard(p, false, own).Count == 0) return false;
                return true;
            }

        }

        List<string> namelist = new List<string>();
        List<Card> cardlist = new List<Card>();
        Dictionary<cardIDEnum, Card> cardidToCardList = new Dictionary<cardIDEnum, Card>();
        List<string> allCardIDS = new List<string>();
        public Card unknownCard;
        public bool installedWrong = false;

        public Card teacherminion;
        public Card illidanminion;
        public Card lepergnome;
        public Card burlyrockjaw;
        private static CardDB instance;

        public static CardDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CardDB();
                    //instance.enumCreator();// only call this to get latest cardids
                    // have to do it 2 times (or the kids inside the simcards will not have a simcard :D
                    foreach (Card c in instance.cardlist)
                    {
                        c.sim_card = instance.getSimCard(c.cardIDenum);
                    }
                    instance.setAdditionalData();
                }
                return instance;
            }
        }

        private CardDB()
        {
            string[] lines = new string[0] { };
            try
            {
                string path = Settings.Instance.path;
                lines = System.IO.File.ReadAllLines(path + "_carddb.txt");
                Helpfunctions.Instance.ErrorLog("read carddb.txt " + lines.Length + " lines");
            }
            catch
            {
                Helpfunctions.Instance.logg("cant find _carddb.txt");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("cant find _carddb.txt in " + Settings.Instance.path);
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("you installed it wrong");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                this.installedWrong = true;
            }
            cardlist.Clear();
            this.cardidToCardList.Clear();
            Card c = new Card();
            int de = 0;
            //placeholdercard
            Card plchldr = new Card { name = cardName.unknown, cost = 1000 };
            this.namelist.Add("unknown");
            this.cardlist.Add(plchldr);
            this.unknownCard = cardlist[0];
            string name = "";
            foreach (string s in lines)
            {
                if (s.Contains("/Entity"))
                {
                    if (c.type == cardtype.ENCHANTMENT)
                    {
                        //Helpfunctions.Instance.logg(c.CardID);
                        //Helpfunctions.Instance.logg(c.name);
                        //Helpfunctions.Instance.logg(c.description);
                        continue;
                    }
                    if (name != "")
                    {
                        this.namelist.Add(name);
                    }
                    name = "";
                    if (c.name != CardDB.cardName.unknown)
                    {

                        this.cardlist.Add(c);
                        //Helpfunctions.Instance.logg(c.name);

                        if (!this.cardidToCardList.ContainsKey(c.cardIDenum))
                        {
                            this.cardidToCardList.Add(c.cardIDenum, c);
                        }
                    }

                }
                if (s.Contains("<Entity version=\"") && s.Contains(" CardID=\""))
                {
                    c = new Card();
                    de = 0;
                    string temp = s.Split(new string[] { "CardID=\"" }, StringSplitOptions.None)[1];
                    temp = temp.Replace("\">", "");

                    allCardIDS.Add(temp);
                    c.cardIDenum = this.cardIdstringToEnum(temp);

                    //token:
                    if (temp.EndsWith("t"))
                    {
                        c.isToken = true;
                    }
                    if (temp.Equals("ds1_whelptoken")) c.isToken = true;
                    if (temp.Equals("CS2_mirror")) c.isToken = true;
                    if (temp.Equals("CS2_050")) c.isToken = true;
                    if (temp.Equals("CS2_052")) c.isToken = true;
                    if (temp.Equals("CS2_051")) c.isToken = true;
                    if (temp.Equals("NEW1_009")) c.isToken = true;
                    if (temp.Equals("CS2_152")) c.isToken = true;
                    if (temp.Equals("CS2_boar")) c.isToken = true;
                    if (temp.Equals("EX1_tk11")) c.isToken = true;
                    if (temp.Equals("EX1_506a")) c.isToken = true;
                    if (temp.Equals("skele21")) c.isToken = true;
                    if (temp.Equals("EX1_tk9")) c.isToken = true;
                    if (temp.Equals("EX1_finkle")) c.isToken = true;
                    if (temp.Equals("EX1_598")) c.isToken = true;
                    if (temp.Equals("EX1_tk34")) c.isToken = true;
                    //if (c.isToken) Helpfunctions.Instance.ErrorLog(temp +" is token");

                    continue;
                }

                //health
                if (s.Contains("<Tag enumID=\"45\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.Health = Convert.ToInt32(temp);
                    continue;
                }

                //Class
                if (s.Contains("Tag enumID=\"199\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.Class = Convert.ToInt32(temp);
                    continue;
                }

                //attack
                if (s.Contains("<Tag enumID=\"47\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.Attack = Convert.ToInt32(temp);
                    continue;
                }
                //race
                if (s.Contains("<Tag enumID=\"200\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.race = Convert.ToInt32(temp);
                    continue;
                }
                //rarity
                if (s.Contains("<Tag enumID=\"203\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.rarity = Convert.ToInt32(temp);
                    continue;
                }
                //manacost
                if (s.Contains("<Tag enumID=\"48\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.cost = Convert.ToInt32(temp);
                    continue;
                }
                //cardtype
                if (s.Contains("<Tag enumID=\"202\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    if (c.name != CardDB.cardName.unknown)
                    {
                        //Helpfunctions.Instance.logg(temp);
                    }

                    int crdtype = Convert.ToInt32(temp);
                    if (crdtype == 10)
                    {
                        c.type = CardDB.cardtype.HEROPWR;
                    }
                    if (crdtype == 3)
                    {
                        c.type = CardDB.cardtype.HERO;
                    }
                    if (crdtype == 4)
                    {
                        c.type = CardDB.cardtype.MOB;
                    }
                    if (crdtype == 5)
                    {
                        c.type = CardDB.cardtype.SPELL;
                    }
                    if (crdtype == 6)
                    {
                        c.type = CardDB.cardtype.ENCHANTMENT;
                    }
                    if (crdtype == 7)
                    {
                        c.type = CardDB.cardtype.WEAPON;
                    }
                    continue;
                }

                //cardname
                if (s.Contains("<Tag enumID=\"185\""))
                {
                    string temp = s.Split(new string[] { "type=\"String\">" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split(new string[] { "</Tag>" }, StringSplitOptions.RemoveEmptyEntries)[0];
                    temp = temp.Replace("&lt;", "");
                    temp = temp.Replace("b&gt;", "");
                    temp = temp.Replace("/b&gt;", "");
                    temp = temp.ToLower(new System.Globalization.CultureInfo("en-US", false));
                    temp = temp.Replace("'", "");
                    temp = temp.Replace(" ", "");
                    temp = temp.Replace(":", "");
                    temp = temp.Replace(".", "");
                    temp = temp.Replace("!", "");
                    temp = temp.Replace("?", "");
                    temp = temp.Replace("-", "");
                    temp = temp.Replace("_", "");
                    temp = temp.Replace(",", "");
                    temp = temp.Replace("(", "");
                    temp = temp.Replace(")", "");
                    temp = temp.Replace("/", "");
                    temp = temp.Replace("\"", "");
                    //Helpfunctions.Instance.logg(temp);
                    c.name = this.cardNamestringToEnum(temp);
                    name = temp;


                    continue;
                }

                //cardtextinhand
                if (s.Contains("<Tag enumID=\"184\""))
                {
                    string temp = s.Split(new string[] { "type=\"String\">" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split(new string[] { "</Tag>" }, StringSplitOptions.RemoveEmptyEntries)[0];
                    temp = temp.Replace("&lt;", "");
                    temp = temp.Replace("b&gt;", "");
                    temp = temp.Replace("/b&gt;", "");
                    temp = temp.ToLower(new System.Globalization.CultureInfo("en-US", false));

                    if (temp.Contains("choose one"))
                    {
                        c.choice = true;
                        //Helpfunctions.Instance.logg(c.name + " is choice");
                    }
                    continue;
                }

                //poisonous
                if (s.Contains("<Tag enumID=\"363\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.poisonous = true;
                    continue;
                }
                //enrage
                if (s.Contains("<Tag enumID=\"212\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Enrage = true;
                    continue;
                }
                //OneTurnEffect
                if (s.Contains("<Tag enumID=\"338\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.oneTurnEffect = true;
                    continue;
                }
                //aura
                if (s.Contains("<Tag enumID=\"362\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Aura = true;
                    continue;
                }

                //taunt
                if (s.Contains("<Tag enumID=\"190\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.tank = true;
                    continue;
                }
                //battlecry
                if (s.Contains("<Tag enumID=\"218\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.battlecry = true;
                    continue;
                }
                //discover
                if (s.Contains("<Tag enumID=\"415\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.discover = true;
                    continue;
                }
                //windfury
                if (s.Contains("<Tag enumID=\"189\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.windfury = true;
                    continue;
                }
                //deathrattle
                if (s.Contains("<Tag enumID=\"217\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.deathrattle = true;
                    continue;
                }
                //Inspire
                if (s.Contains("<Tag enumID=\"403\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Inspire = true;
                    continue;
                }
                //durability
                if (s.Contains("<Tag enumID=\"187\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.Durability = Convert.ToInt32(temp);
                    continue;
                }
                //elite
                if (s.Contains("<Tag enumID=\"114\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Elite = true;
                    continue;
                }
                //combo
                if (s.Contains("<Tag enumID=\"220\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Combo = true;
                    continue;
                }
                //overload
                if (s.Contains("<Tag enumID=\"296\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.overload = Convert.ToInt32(temp);
                    continue;
                }
                //lifesteal
                if (s.Contains("<Tag enumID=\"685\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.lifesteal = true;
                    continue;
                }
                
                //untouchable
                if (s.Contains("<Tag enumID=\"448\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.untouchable = true;
                    continue;
                }
                //stealh
                if (s.Contains("<Tag enumID=\"191\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Stealth = true;
                    continue;
                }
                //secret
                if (s.Contains("<Tag enumID=\"219\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Secret = true;
                    continue;
                }
                //quest
                if (s.Contains("<Tag enumID=\"462\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Quest = true;
                    continue;
                }                
                //freeze
                if (s.Contains("<Tag enumID=\"208\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Freeze = true;
                    continue;
                }
                //adjacentbuff
                if (s.Contains("<Tag enumID=\"350\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.AdjacentBuff = true;
                    continue;
                }
                //divineshield
                if (s.Contains("<Tag enumID=\"194\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Shield = true;
                    continue;
                }
                //charge
                if (s.Contains("<Tag enumID=\"197\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Charge = true;
                    continue;
                }
                //silence
                if (s.Contains("<Tag enumID=\"339\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Silence = true;
                    continue;
                }
                //morph
                if (s.Contains("<Tag enumID=\"293\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Morph = true;
                    continue;
                }
                //spellpower
                if (s.Contains("<Tag enumID=\"192\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Spellpower = true;
                    c.spellpowervalue = 1;
                    if (c.name == CardDB.cardName.ancientmage) c.spellpowervalue = 0;
                    if (c.name == CardDB.cardName.malygos) c.spellpowervalue = 5;
                    if (c.name == CardDB.cardName.arcanotron) c.spellpowervalue = 2;
                    continue;
                }

                if (s.Contains("<PlayRequirement"))
                {
                    string temp = s.Split(new string[] { "reqID=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int reqID = Convert.ToInt32(temp);
                    c.playrequires.Add((ErrorType2)reqID);

                    int param = 0;
                    temp = s.Split(new string[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    try
                    {
                        if (Char.IsDigit(temp, 0))
                        {
                            temp = temp.Split('\"')[0];
                            param = Convert.ToInt32(temp);
                        }
                    }
                    catch
                    {
                        param = 0;
                    }
                    if (param > 0)
                    {
                        switch (reqID)
                        {
                            case 8:
                                c.needWithMaxAttackValueOf = param;
                                continue;
                            case 10:
                                c.needRaceForPlaying = param;
                                continue;
                            case 12:
                                c.needEmptyPlacesForPlaying = param;
                                continue;
                            case 19:
                                c.needMinionsCapIfAvailable = param;
                                continue;
                            case 23:
                                c.needMinNumberOfEnemy = param;
                                continue;
                            case 41:
                                c.needWithMinAttackValueOf = param;
                                continue;
                            case 45:
                                c.needMinTotalMinions = param;
                                continue;
                            case 56:
                                c.needMinOwnMinions = param;
                                continue;
                            case 59:
                                c.needControlaSecret = param;
                                continue;
                        }
                    }
                }

                if (s.Contains("<Tag name="))
                {
                    string temp = s.Split(new string[] { "<Tag name=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];

                }


            }

            this.teacherminion = this.getCardDataFromID(CardDB.cardIDEnum.NEW1_026t);
            this.illidanminion = this.getCardDataFromID(CardDB.cardIDEnum.EX1_614t);
            this.lepergnome = this.getCardDataFromID(CardDB.cardIDEnum.EX1_029);
            this.burlyrockjaw = this.getCardDataFromID(CardDB.cardIDEnum.GVG_068);

            Helpfunctions.Instance.ErrorLog("CardList:" + cardidToCardList.Count);

        }

        public Card getCardData(CardDB.cardName cardname)
        {

            foreach (Card ca in this.cardlist)
            {
                if (ca.name == cardname)
                {
                    return ca;
                }
            }

            return unknownCard;
        }

        public Card getCardDataFromID(cardIDEnum id)
        {
            return this.cardidToCardList.ContainsKey(id) ? this.cardidToCardList[id] : this.unknownCard;
        }

        public SimTemplate getSimCard(cardIDEnum id)
        {
            switch (id)
            {
                case cardIDEnum.None:
                    return new Sim_None();
                case cardIDEnum.NAX3_02_TB:
                    return new Sim_NAX3_02_TB();
                case cardIDEnum.NAX12_02H_2_TB:
                    return new Sim_NAX12_02H_2_TB();
                case cardIDEnum.NAX11_02H_2_TB:
                    return new Sim_NAX11_02H_2_TB();
                case cardIDEnum.BRMA17_5_TB:
                    return new Sim_BRMA17_5_TB();
                case cardIDEnum.BRMA14_10H_TB:
                    return new Sim_BRMA14_10H_TB();
                case cardIDEnum.BRMA13_4_2_TB:
                    return new Sim_BRMA13_4_2_TB();
                case cardIDEnum.BRMA07_2_2_TB:
                    return new Sim_BRMA07_2_2_TB();
                case cardIDEnum.BRMA06_2H_TB:
                    return new Sim_BRMA06_2H_TB();
                case cardIDEnum.BRMA02_2_2_TB:
                    return new Sim_BRMA02_2_2_TB();
                case cardIDEnum.BRMA01_2H_2_TB:
                    return new Sim_BRMA01_2H_2_TB();
                case cardIDEnum.BRMA09_2_TB:
                    return new Sim_BRMA09_2_TB();
                case cardIDEnum.NAX8_02H_TB:
                    return new Sim_NAX8_02H_TB();

                case cardIDEnum.AT_001:
                    return new Sim_AT_001();
                case cardIDEnum.AT_003:
                    return new Sim_AT_003();
                case cardIDEnum.AT_004:
                    return new Sim_AT_004();
                case cardIDEnum.AT_005:
                    return new Sim_AT_005();
                case cardIDEnum.AT_005t:
                    return new Sim_AT_005t();
                case cardIDEnum.AT_006:
                    return new Sim_AT_006();
                case cardIDEnum.AT_007:
                    return new Sim_AT_007();
                case cardIDEnum.AT_008:
                    return new Sim_AT_008();
                case cardIDEnum.AT_009:
                    return new Sim_AT_009();
                case cardIDEnum.AT_010:
                    return new Sim_AT_010();
                case cardIDEnum.AT_011:
                    return new Sim_AT_011();
                case cardIDEnum.AT_012:
                    return new Sim_AT_012();
                case cardIDEnum.AT_013:
                    return new Sim_AT_013();
                case cardIDEnum.AT_014:
                    return new Sim_AT_014();
                case cardIDEnum.AT_015:
                    return new Sim_AT_015();
                case cardIDEnum.AT_016:
                    return new Sim_AT_016();
                case cardIDEnum.AT_017:
                    return new Sim_AT_017();
                case cardIDEnum.AT_018:
                    return new Sim_AT_018();
                case cardIDEnum.AT_019:
                    return new Sim_AT_019();
                case cardIDEnum.AT_020:
                    return new Sim_AT_020();
                case cardIDEnum.AT_021:
                    return new Sim_AT_021();
                case cardIDEnum.AT_022:
                    return new Sim_AT_022();
                case cardIDEnum.AT_023:
                    return new Sim_AT_023();
                case cardIDEnum.AT_024:
                    return new Sim_AT_024();
                case cardIDEnum.AT_025:
                    return new Sim_AT_025();
                case cardIDEnum.AT_026:
                    return new Sim_AT_026();
                case cardIDEnum.AT_027:
                    return new Sim_AT_027();
                case cardIDEnum.AT_028:
                    return new Sim_AT_028();
                case cardIDEnum.AT_029:
                    return new Sim_AT_029();
                case cardIDEnum.AT_030:
                    return new Sim_AT_030();
                case cardIDEnum.AT_031:
                    return new Sim_AT_031();
                case cardIDEnum.AT_032:
                    return new Sim_AT_032();
                case cardIDEnum.AT_033:
                    return new Sim_AT_033();
                case cardIDEnum.AT_034:
                    return new Sim_AT_034();
                case cardIDEnum.AT_035:
                    return new Sim_AT_035();
                case cardIDEnum.AT_036:
                    return new Sim_AT_036();
                case cardIDEnum.AT_036t:
                    return new Sim_AT_036t();
                case cardIDEnum.AT_037:
                    return new Sim_AT_037();
                case cardIDEnum.AT_037a:
                    return new Sim_AT_037a();
                case cardIDEnum.AT_037b:
                    return new Sim_AT_037b();
                case cardIDEnum.AT_037t:
                    return new Sim_AT_037t();
                case cardIDEnum.AT_038:
                    return new Sim_AT_038();
                case cardIDEnum.AT_039:
                    return new Sim_AT_039();
                case cardIDEnum.AT_040:
                    return new Sim_AT_040();
                case cardIDEnum.AT_041:
                    return new Sim_AT_041();
                case cardIDEnum.AT_042:
                    return new Sim_AT_042();
                case cardIDEnum.AT_042a:
                    return new Sim_AT_042a();
                case cardIDEnum.AT_042b:
                    return new Sim_AT_042b();
                case cardIDEnum.AT_042t:
                    return new Sim_AT_042t();
                case cardIDEnum.AT_042t2:
                    return new Sim_AT_042t2();
                case cardIDEnum.AT_043:
                    return new Sim_AT_043();
                case cardIDEnum.AT_044:
                    return new Sim_AT_044();
                case cardIDEnum.AT_045:
                    return new Sim_AT_045();
                case cardIDEnum.AT_046:
                    return new Sim_AT_046();
                case cardIDEnum.AT_047:
                    return new Sim_AT_047();
                case cardIDEnum.AT_048:
                    return new Sim_AT_048();
                case cardIDEnum.AT_049:
                    return new Sim_AT_049();
                case cardIDEnum.AT_050:
                    return new Sim_AT_050();
                case cardIDEnum.AT_050t:
                    return new Sim_AT_050t();
                case cardIDEnum.AT_051:
                    return new Sim_AT_051();
                case cardIDEnum.AT_052:
                    return new Sim_AT_052();
                case cardIDEnum.AT_053:
                    return new Sim_AT_053();
                case cardIDEnum.AT_054:
                    return new Sim_AT_054();
                case cardIDEnum.AT_055:
                    return new Sim_AT_055();
                case cardIDEnum.AT_056:
                    return new Sim_AT_056();
                case cardIDEnum.AT_057:
                    return new Sim_AT_057();
                case cardIDEnum.AT_058:
                    return new Sim_AT_058();
                case cardIDEnum.AT_059:
                    return new Sim_AT_059();
                case cardIDEnum.AT_060:
                    return new Sim_AT_060();
                case cardIDEnum.AT_061:
                    return new Sim_AT_061();
                case cardIDEnum.AT_062:
                    return new Sim_AT_062();
                case cardIDEnum.AT_063:
                    return new Sim_AT_063();
                case cardIDEnum.AT_063t:
                    return new Sim_AT_063t();
                case cardIDEnum.AT_064:
                    return new Sim_AT_064();
                case cardIDEnum.AT_065:
                    return new Sim_AT_065();
                case cardIDEnum.AT_066:
                    return new Sim_AT_066();
                case cardIDEnum.AT_067:
                    return new Sim_AT_067();
                case cardIDEnum.AT_068:
                    return new Sim_AT_068();
                case cardIDEnum.AT_069:
                    return new Sim_AT_069();
                case cardIDEnum.AT_070:
                    return new Sim_AT_070();
                case cardIDEnum.AT_071:
                    return new Sim_AT_071();
                case cardIDEnum.AT_072:
                    return new Sim_AT_072();
                case cardIDEnum.AT_073:
                    return new Sim_AT_073();
                case cardIDEnum.AT_074:
                    return new Sim_AT_074();
                case cardIDEnum.AT_075:
                    return new Sim_AT_075();
                case cardIDEnum.AT_076:
                    return new Sim_AT_076();
                case cardIDEnum.AT_077:
                    return new Sim_AT_077();
                case cardIDEnum.AT_078:
                    return new Sim_AT_078();
                case cardIDEnum.AT_079:
                    return new Sim_AT_079();
                case cardIDEnum.AT_080:
                    return new Sim_AT_080();
                case cardIDEnum.AT_081:
                    return new Sim_AT_081();
                case cardIDEnum.AT_082:
                    return new Sim_AT_082();
                case cardIDEnum.AT_083:
                    return new Sim_AT_083();
                case cardIDEnum.AT_084:
                    return new Sim_AT_084();
                case cardIDEnum.AT_085:
                    return new Sim_AT_085();
                case cardIDEnum.AT_086:
                    return new Sim_AT_086();
                case cardIDEnum.AT_087:
                    return new Sim_AT_087();
                case cardIDEnum.AT_088:
                    return new Sim_AT_088();
                case cardIDEnum.AT_089:
                    return new Sim_AT_089();
                case cardIDEnum.AT_090:
                    return new Sim_AT_090();
                case cardIDEnum.AT_091:
                    return new Sim_AT_091();
                case cardIDEnum.AT_092:
                    return new Sim_AT_092();
                case cardIDEnum.AT_093:
                    return new Sim_AT_093();
                case cardIDEnum.AT_094:
                    return new Sim_AT_094();
                case cardIDEnum.AT_095:
                    return new Sim_AT_095();
                case cardIDEnum.AT_096:
                    return new Sim_AT_096();
                case cardIDEnum.AT_097:
                    return new Sim_AT_097();
                case cardIDEnum.AT_098:
                    return new Sim_AT_098();
                case cardIDEnum.AT_099:
                    return new Sim_AT_099();
                case cardIDEnum.AT_099t:
                    return new Sim_AT_099t();
                case cardIDEnum.AT_100:
                    return new Sim_AT_100();
                case cardIDEnum.AT_101:
                    return new Sim_AT_101();
                case cardIDEnum.AT_102:
                    return new Sim_AT_102();
                case cardIDEnum.AT_103:
                    return new Sim_AT_103();
                case cardIDEnum.AT_104:
                    return new Sim_AT_104();
                case cardIDEnum.AT_105:
                    return new Sim_AT_105();
                case cardIDEnum.AT_106:
                    return new Sim_AT_106();
                case cardIDEnum.AT_108:
                    return new Sim_AT_108();
                case cardIDEnum.AT_109:
                    return new Sim_AT_109();
                case cardIDEnum.AT_110:
                    return new Sim_AT_110();
                case cardIDEnum.AT_111:
                    return new Sim_AT_111();
                case cardIDEnum.AT_112:
                    return new Sim_AT_112();
                case cardIDEnum.AT_113:
                    return new Sim_AT_113();
                case cardIDEnum.AT_114:
                    return new Sim_AT_114();
                case cardIDEnum.AT_115:
                    return new Sim_AT_115();
                case cardIDEnum.AT_116:
                    return new Sim_AT_116();
                case cardIDEnum.AT_117:
                    return new Sim_AT_117();
                case cardIDEnum.AT_118:
                    return new Sim_AT_118();
                case cardIDEnum.AT_119:
                    return new Sim_AT_119();
                case cardIDEnum.AT_120:
                    return new Sim_AT_120();
                case cardIDEnum.AT_121:
                    return new Sim_AT_121();
                case cardIDEnum.AT_122:
                    return new Sim_AT_122();
                case cardIDEnum.AT_123:
                    return new Sim_AT_123();
                case cardIDEnum.AT_124:
                    return new Sim_AT_124();
                case cardIDEnum.AT_125:
                    return new Sim_AT_125();
                case cardIDEnum.AT_127:
                    return new Sim_AT_127();
                case cardIDEnum.AT_128:
                    return new Sim_AT_128();
                case cardIDEnum.AT_129:
                    return new Sim_AT_129();
                case cardIDEnum.AT_131:
                    return new Sim_AT_131();
                case cardIDEnum.AT_132:
                    return new Sim_AT_132();
                case cardIDEnum.AT_132_DRUID:
                    return new Sim_AT_132_DRUID();
                case cardIDEnum.AT_132_HUNTER:
                    return new Sim_AT_132_HUNTER();
                case cardIDEnum.AT_132_MAGE:
                    return new Sim_AT_132_MAGE();
                case cardIDEnum.AT_132_PALADIN:
                    return new Sim_AT_132_PALADIN();
                case cardIDEnum.AT_132_PRIEST:
                    return new Sim_AT_132_PRIEST();
                case cardIDEnum.CS1h_001_H1_AT_132:
                    return new Sim_AT_132_PRIEST();
                case cardIDEnum.AT_132_ROGUE:
                    return new Sim_AT_132_ROGUE();
                case cardIDEnum.AT_132_ROGUEt:
                    return new Sim_AT_132_ROGUEt();
                case cardIDEnum.CS2_049_H1_AT_132:
                    return new Sim_AT_132_SHAMAN();
                case cardIDEnum.AT_132_SHAMAN:
                    return new Sim_AT_132_SHAMAN();
                case cardIDEnum.AT_132_SHAMANa:
                    return new Sim_AT_132_SHAMANa();
                case cardIDEnum.AT_132_SHAMANb:
                    return new Sim_AT_132_SHAMANb();
                case cardIDEnum.AT_132_SHAMANc:
                    return new Sim_AT_132_SHAMANc();
                case cardIDEnum.AT_132_SHAMANd:
                    return new Sim_AT_132_SHAMANd();
                case cardIDEnum.AT_132_WARLOCK:
                    return new Sim_AT_132_WARLOCK();
                case cardIDEnum.AT_132_WARRIOR:
                    return new Sim_AT_132_WARRIOR();
                case cardIDEnum.AT_133:
                    return new Sim_AT_133();
                case cardIDEnum.NEW1_007b:
                    return new Sim_NEW1_007b();
                case cardIDEnum.EX1_613:
                    return new Sim_EX1_613();
                case cardIDEnum.EX1_133:
                    return new Sim_EX1_133();
                case cardIDEnum.NEW1_018:
                    return new Sim_NEW1_018();
                case cardIDEnum.EX1_012:
                    return new Sim_EX1_012();
                case cardIDEnum.EX1_178a:
                    return new Sim_EX1_178a();
                case cardIDEnum.CS2_231:
                    return new Sim_CS2_231();
                case cardIDEnum.CS2_179:
                    return new Sim_CS2_179();
                case cardIDEnum.EX1_244:
                    return new Sim_EX1_244();
                case cardIDEnum.EX1_178b:
                    return new Sim_EX1_178b();
                case cardIDEnum.EX1_573b:
                    return new Sim_EX1_573b();
                case cardIDEnum.NEW1_007a:
                    return new Sim_NEW1_007a();
                case cardIDEnum.EX1_345t:
                    return new Sim_EX1_345t();
                case cardIDEnum.FP1_007t:
                    return new Sim_FP1_007t();
                case cardIDEnum.EX1_025:
                    return new Sim_EX1_025();
                case cardIDEnum.EX1_396:
                    return new Sim_EX1_396();
                case cardIDEnum.NEW1_017:
                    return new Sim_NEW1_017();
                case cardIDEnum.NEW1_008a:
                    return new Sim_NEW1_008a();
                case cardIDEnum.EX1_533:
                    return new Sim_EX1_533();
                case cardIDEnum.EX1_522:
                    return new Sim_EX1_522();

                // case CardDB.cardIDEnum.NAX11_04: return new Sim_NAX11_04();
                case cardIDEnum.NEW1_026:
                    return new Sim_NEW1_026();
                case cardIDEnum.EX1_398:
                    return new Sim_EX1_398();

                // case CardDB.cardIDEnum.NAX4_04: return new Sim_NAX4_04();
                case cardIDEnum.EX1_007:
                    return new Sim_EX1_007();
                case cardIDEnum.CS1_112:
                    return new Sim_CS1_112();
                case cardIDEnum.NEW1_036:
                    return new Sim_NEW1_036();
                case cardIDEnum.EX1_258:
                    return new Sim_EX1_258();
                case cardIDEnum.HERO_01:
                    return new Sim_HERO_01();
                case cardIDEnum.HERO_01a:
                    return new Sim_HERO_01();
                case cardIDEnum.CS2_087:
                    return new Sim_CS2_087();
                case cardIDEnum.DREAM_05:
                    return new Sim_DREAM_05();
                case cardIDEnum.CS2_092:
                    return new Sim_CS2_092();
                case cardIDEnum.CS2_022:
                    return new Sim_CS2_022();
                case cardIDEnum.EX1_046:
                    return new Sim_EX1_046();
                case cardIDEnum.PRO_001b:
                    return new Sim_PRO_001b();
                case cardIDEnum.PRO_001a:
                    return new Sim_PRO_001a();
                case cardIDEnum.CS2_103:
                    return new Sim_CS2_103();
                case cardIDEnum.NEW1_041:
                    return new Sim_NEW1_041();
                case cardIDEnum.EX1_360:
                    return new Sim_EX1_360();
                case cardIDEnum.FP1_023:
                    return new Sim_FP1_023();
                case cardIDEnum.NEW1_038:
                    return new Sim_NEW1_038();
                case cardIDEnum.CS2_009:
                    return new Sim_CS2_009();
                case cardIDEnum.EX1_010:
                    return new Sim_EX1_010();
                case cardIDEnum.CS2_024:
                    return new Sim_CS2_024();
                case cardIDEnum.EX1_565:
                    return new Sim_EX1_565();
                case cardIDEnum.CS2_076:
                    return new Sim_CS2_076();
                case cardIDEnum.FP1_004:
                    return new Sim_FP1_004();
                case cardIDEnum.CS2_162:
                    return new Sim_CS2_162();
                case cardIDEnum.EX1_110t:
                    return new Sim_EX1_110t();
                case cardIDEnum.CS2_181:
                    return new Sim_CS2_181();
                case cardIDEnum.EX1_309:
                    return new Sim_EX1_309();
                case cardIDEnum.EX1_354:
                    return new Sim_EX1_354();
                case cardIDEnum.EX1_023:
                    return new Sim_EX1_023();
                case cardIDEnum.NEW1_034:
                    return new Sim_NEW1_034();
                case cardIDEnum.CS2_003:
                    return new Sim_CS2_003();
                case cardIDEnum.HERO_06:
                    return new Sim_HERO_06();
                case cardIDEnum.CS2_201:
                    return new Sim_CS2_201();
                case cardIDEnum.EX1_508:
                    return new Sim_EX1_508();
                case cardIDEnum.EX1_259:
                    return new Sim_EX1_259();
                case cardIDEnum.EX1_341:
                    return new Sim_EX1_341();
                case cardIDEnum.EX1_103:
                    return new Sim_EX1_103();
                case cardIDEnum.FP1_021:
                    return new Sim_FP1_021();
                case cardIDEnum.EX1_411:
                    return new Sim_EX1_411();
                case cardIDEnum.CS2_053:
                    return new Sim_CS2_053();
                case cardIDEnum.CS2_182:
                    return new Sim_CS2_182();
                case cardIDEnum.CS2_008:
                    return new Sim_CS2_008();
                case cardIDEnum.CS2_233:
                    return new Sim_CS2_233();
                case cardIDEnum.EX1_626:
                    return new Sim_EX1_626();
                case cardIDEnum.EX1_059:
                    return new Sim_EX1_059();
                case cardIDEnum.EX1_334:
                    return new Sim_EX1_334();
                case cardIDEnum.EX1_619:
                    return new Sim_EX1_619();
                case cardIDEnum.NEW1_032:
                    return new Sim_NEW1_032();
                case cardIDEnum.EX1_158t:
                    return new Sim_EX1_158t();
                case cardIDEnum.EX1_006:
                    return new Sim_EX1_006();
                case cardIDEnum.NEW1_031:
                    return new Sim_NEW1_031();
                case cardIDEnum.DREAM_04:
                    return new Sim_DREAM_04();
                case cardIDEnum.EX1_004:
                    return new Sim_EX1_004();
                case cardIDEnum.EX1_095:
                    return new Sim_EX1_095();
                case cardIDEnum.NEW1_007:
                    return new Sim_NEW1_007();
                case cardIDEnum.EX1_275:
                    return new Sim_EX1_275();
                case cardIDEnum.EX1_245:
                    return new Sim_EX1_245();
                case cardIDEnum.EX1_383:
                    return new Sim_EX1_383();
                case cardIDEnum.FP1_016:
                    return new Sim_FP1_016();
                case cardIDEnum.CS2_125:
                    return new Sim_CS2_125();
                case cardIDEnum.EX1_137:
                    return new Sim_EX1_137();
                case cardIDEnum.DS1_185:
                    return new Sim_DS1_185();
                case cardIDEnum.FP1_010:
                    return new Sim_FP1_010();
                case cardIDEnum.EX1_598:
                    return new Sim_EX1_598();
                case cardIDEnum.EX1_304:
                    return new Sim_EX1_304();
                case cardIDEnum.EX1_302:
                    return new Sim_EX1_302();
                case cardIDEnum.EX1_614t:
                    return new Sim_EX1_614t();
                case cardIDEnum.CS2_108:
                    return new Sim_CS2_108();
                case cardIDEnum.CS2_046:
                    return new Sim_CS2_046();
                case cardIDEnum.EX1_014t:
                    return new Sim_EX1_014t();
                case cardIDEnum.NEW1_005:
                    return new Sim_NEW1_005();
                case cardIDEnum.EX1_062:
                    return new Sim_EX1_062();
                case cardIDEnum.Mekka1:
                    return new Sim_Mekka1();
                case cardIDEnum.tt_010a:
                    return new Sim_tt_010a();
                case cardIDEnum.CS2_072:
                    return new Sim_CS2_072();
                case cardIDEnum.TU4f_007:
                    return new Sim_TU4f_007();
                case cardIDEnum.EX1_tk28:
                    return new Sim_EX1_tk28();
                case cardIDEnum.FP1_014:
                    return new Sim_FP1_014();
                case cardIDEnum.EX1_409t:
                    return new Sim_EX1_409t();
                case cardIDEnum.EX1_507:
                    return new Sim_EX1_507();
                case cardIDEnum.EX1_144:
                    return new Sim_EX1_144();
                case cardIDEnum.CS2_038:
                    return new Sim_CS2_038();
                case cardIDEnum.EX1_093:
                    return new Sim_EX1_093();
                case cardIDEnum.CS2_080:
                    return new Sim_CS2_080();
                case cardIDEnum.EX1_005:
                    return new Sim_EX1_005();
                case cardIDEnum.EX1_382:
                    return new Sim_EX1_382();
                case cardIDEnum.CS2_028:
                    return new Sim_CS2_028();
                case cardIDEnum.EX1_538:
                    return new Sim_EX1_538();
                case cardIDEnum.DREAM_02:
                    return new Sim_DREAM_02();
                case cardIDEnum.EX1_581:
                    return new Sim_EX1_581();
                case cardIDEnum.EX1_131t:
                    return new Sim_EX1_131t();
                case cardIDEnum.CS2_147:
                    return new Sim_CS2_147();
                case cardIDEnum.CS1_113:
                    return new Sim_CS1_113();
                case cardIDEnum.CS2_161:
                    return new Sim_CS2_161();
                case cardIDEnum.CS2_031:
                    return new Sim_CS2_031();
                case cardIDEnum.EX1_166b:
                    return new Sim_EX1_166b();
                case cardIDEnum.EX1_066:
                    return new Sim_EX1_066();
                case cardIDEnum.EX1_355:
                    return new Sim_EX1_355();
                case cardIDEnum.EX1_534:
                    return new Sim_EX1_534();
                case cardIDEnum.EX1_162:
                    return new Sim_EX1_162();
                case cardIDEnum.EX1_363:
                    return new Sim_EX1_363();
                case cardIDEnum.EX1_164a:
                    return new Sim_EX1_164a();
                case cardIDEnum.CS2_188:
                    return new Sim_CS2_188();
                case cardIDEnum.EX1_016:
                    return new Sim_EX1_016();
                case cardIDEnum.EX1_603:
                    return new Sim_EX1_603();
                case cardIDEnum.EX1_238:
                    return new Sim_EX1_238();
                case cardIDEnum.EX1_166:
                    return new Sim_EX1_166();
                case cardIDEnum.DS1h_292:
                    return new Sim_DS1h_292();
                case cardIDEnum.DS1h_292_H1:
                    return new Sim_DS1h_292();
                case cardIDEnum.DS1_183:
                    return new Sim_DS1_183();
                case cardIDEnum.EX1_076:
                    return new Sim_EX1_076();
                case cardIDEnum.EX1_048:
                    return new Sim_EX1_048();
                case cardIDEnum.FP1_026:
                    return new Sim_FP1_026();
                case cardIDEnum.CS2_074:
                    return new Sim_CS2_074();
                case cardIDEnum.FP1_027:
                    return new Sim_FP1_027();
                case cardIDEnum.EX1_323w:
                    return new Sim_EX1_323w();
                case cardIDEnum.EX1_129:
                    return new Sim_EX1_129();
                case cardIDEnum.EX1_405:
                    return new Sim_EX1_405();
                case cardIDEnum.EX1_317:
                    return new Sim_EX1_317();
                case cardIDEnum.EX1_606:
                    return new Sim_EX1_606();
                case cardIDEnum.FP1_006:
                    return new Sim_FP1_006();
                case cardIDEnum.NEW1_008:
                    return new Sim_NEW1_008();
                case cardIDEnum.CS2_119:
                    return new Sim_CS2_119();
                case cardIDEnum.CS2_121:
                    return new Sim_CS2_121();
                case cardIDEnum.CS1h_001:
                    return new Sim_CS1h_001();
                case cardIDEnum.CS1h_001_H1:
                    return new Sim_CS1h_001();
                case cardIDEnum.EX1_tk34:
                    return new Sim_EX1_tk34();
                case cardIDEnum.NEW1_020:
                    return new Sim_NEW1_020();
                case cardIDEnum.CS2_196:
                    return new Sim_CS2_196();
                case cardIDEnum.EX1_312:
                    return new Sim_EX1_312();
                case cardIDEnum.FP1_022:
                    return new Sim_FP1_022();
                case cardIDEnum.EX1_160b:
                    return new Sim_EX1_160b();
                case cardIDEnum.EX1_563:
                    return new Sim_EX1_563();
                case cardIDEnum.FP1_031:
                    return new Sim_FP1_031();
                case cardIDEnum.NEW1_029:
                    return new Sim_NEW1_029();
                case cardIDEnum.CS1_129:
                    return new Sim_CS1_129();
                case cardIDEnum.HERO_03:
                    return new Sim_HERO_03();
                case cardIDEnum.HERO_03a:
                    return new Sim_HERO_03();
                case cardIDEnum.Mekka4t:
                    return new Sim_Mekka4t();
                case cardIDEnum.EX1_158:
                    return new Sim_EX1_158();
                case cardIDEnum.NEW1_025:
                    return new Sim_NEW1_025();
                case cardIDEnum.FP1_012t:
                    return new Sim_FP1_012t();
                case cardIDEnum.EX1_083:
                    return new Sim_EX1_083();
                case cardIDEnum.EX1_295:
                    return new Sim_EX1_295();
                case cardIDEnum.EX1_407:
                    return new Sim_EX1_407();
                case cardIDEnum.NEW1_004:
                    return new Sim_NEW1_004();
                case cardIDEnum.FP1_019:
                    return new Sim_FP1_019();
                case cardIDEnum.PRO_001at:
                    return new Sim_PRO_001at();
                case cardIDEnum.EX1_625t:
                    return new Sim_EX1_625t();
                case cardIDEnum.EX1_014:
                    return new Sim_EX1_014();
                case cardIDEnum.CS2_097:
                    return new Sim_CS2_097();
                case cardIDEnum.EX1_558:
                    return new Sim_EX1_558();
                case cardIDEnum.EX1_tk29:
                    return new Sim_EX1_tk29();
                case cardIDEnum.CS2_186:
                    return new Sim_CS2_186();
                case cardIDEnum.EX1_084:
                    return new Sim_EX1_084();
                case cardIDEnum.NEW1_012:
                    return new Sim_NEW1_012();
                case cardIDEnum.FP1_014t:
                    return new Sim_FP1_014t();
                case cardIDEnum.EX1_578:
                    return new Sim_EX1_578();
                case cardIDEnum.CS2_221:
                    return new Sim_CS2_221();
                case cardIDEnum.EX1_019:
                    return new Sim_EX1_019();
                case cardIDEnum.FP1_019t:
                    return new Sim_FP1_019t();
                case cardIDEnum.EX1_132:
                    return new Sim_EX1_132();
                case cardIDEnum.EX1_284:
                    return new Sim_EX1_284();
                case cardIDEnum.EX1_105:
                    return new Sim_EX1_105();
                case cardIDEnum.NEW1_011:
                    return new Sim_NEW1_011();
                case cardIDEnum.EX1_017:
                    return new Sim_EX1_017();
                case cardIDEnum.EX1_249:
                    return new Sim_EX1_249();
                case cardIDEnum.FP1_002t:
                    return new Sim_FP1_002t();
                case cardIDEnum.EX1_313:
                    return new Sim_EX1_313();
                case cardIDEnum.EX1_155b:
                    return new Sim_EX1_155b();
                case cardIDEnum.NEW1_033:
                    return new Sim_NEW1_033();
                case cardIDEnum.CS2_106:
                    return new Sim_CS2_106();
                case cardIDEnum.FP1_018:
                    return new Sim_FP1_018();
                case cardIDEnum.DS1_233:
                    return new Sim_DS1_233();
                case cardIDEnum.DS1_175:
                    return new Sim_DS1_175();
                case cardIDEnum.NEW1_024:
                    return new Sim_NEW1_024();
                case cardIDEnum.CS2_189:
                    return new Sim_CS2_189();
                case cardIDEnum.NEW1_037:
                    return new Sim_NEW1_037();
                case cardIDEnum.EX1_414:
                    return new Sim_EX1_414();
                case cardIDEnum.EX1_538t:
                    return new Sim_EX1_538t();
                case cardIDEnum.EX1_586:
                    return new Sim_EX1_586();
                case cardIDEnum.EX1_310:
                    return new Sim_EX1_310();
                case cardIDEnum.NEW1_010:
                    return new Sim_NEW1_010();
                case cardIDEnum.EX1_534t:
                    return new Sim_EX1_534t();
                case cardIDEnum.FP1_028:
                    return new Sim_FP1_028();
                case cardIDEnum.EX1_604:
                    return new Sim_EX1_604();
                case cardIDEnum.EX1_160:
                    return new Sim_EX1_160();
                case cardIDEnum.EX1_165t1:
                    return new Sim_EX1_165t1();
                case cardIDEnum.CS2_062:
                    return new Sim_CS2_062();
                case cardIDEnum.CS2_155:
                    return new Sim_CS2_155();
                case cardIDEnum.CS2_213:
                    return new Sim_CS2_213();
                case cardIDEnum.CS2_004:
                    return new Sim_CS2_004();
                case cardIDEnum.CS2_023:
                    return new Sim_CS2_023();
                case cardIDEnum.EX1_164:
                    return new Sim_EX1_164();
                case cardIDEnum.EX1_009:
                    return new Sim_EX1_009();
                case cardIDEnum.FP1_007:
                    return new Sim_FP1_007();
                case cardIDEnum.EX1_345:
                    return new Sim_EX1_345();
                case cardIDEnum.EX1_116:
                    return new Sim_EX1_116();
                case cardIDEnum.EX1_399:
                    return new Sim_EX1_399();
                case cardIDEnum.EX1_587:
                    return new Sim_EX1_587();
                case cardIDEnum.EX1_571:
                    return new Sim_EX1_571();
                case cardIDEnum.EX1_335:
                    return new Sim_EX1_335();
                case cardIDEnum.HERO_08:
                    return new Sim_HERO_08();
                case cardIDEnum.HERO_08a:
                    return new Sim_HERO_08();
                case cardIDEnum.HERO_08b:
                    return new Sim_HERO_08();
                case cardIDEnum.EX1_166a:
                    return new Sim_EX1_166a();
                case cardIDEnum.EX1_finkle:
                    return new Sim_EX1_finkle();
                case cardIDEnum.EX1_164b:
                    return new Sim_EX1_164b();
                case cardIDEnum.EX1_283:
                    return new Sim_EX1_283();
                case cardIDEnum.EX1_339:
                    return new Sim_EX1_339();
                case cardIDEnum.EX1_531:
                    return new Sim_EX1_531();
                case cardIDEnum.EX1_134:
                    return new Sim_EX1_134();
                case cardIDEnum.EX1_350:
                    return new Sim_EX1_350();
                case cardIDEnum.EX1_308:
                    return new Sim_EX1_308();
                case cardIDEnum.CS2_197:
                    return new Sim_CS2_197();
                case cardIDEnum.skele21:
                    return new Sim_skele21();
                case cardIDEnum.FP1_013:
                    return new Sim_FP1_013();
                case cardIDEnum.EX1_509:
                    return new Sim_EX1_509();
                case cardIDEnum.EX1_612:
                    return new Sim_EX1_612();
                case cardIDEnum.EX1_021:
                    return new Sim_EX1_021();
                case cardIDEnum.CS2_226:
                    return new Sim_CS2_226();
                case cardIDEnum.EX1_608:
                    return new Sim_EX1_608();
                case cardIDEnum.EX1_624:
                    return new Sim_EX1_624();
                case cardIDEnum.EX1_616:
                    return new Sim_EX1_616();
                case cardIDEnum.EX1_008:
                    return new Sim_EX1_008();
                case cardIDEnum.PlaceholderCard:
                    return new Sim_PlaceholderCard();
                case cardIDEnum.EX1_045:
                    return new Sim_EX1_045();
                case cardIDEnum.EX1_015:
                    return new Sim_EX1_015();
                case cardIDEnum.CS2_171:
                    return new Sim_CS2_171();
                case cardIDEnum.CS2_041:
                    return new Sim_CS2_041();
                case cardIDEnum.EX1_128:
                    return new Sim_EX1_128();
                case cardIDEnum.CS2_112:
                    return new Sim_CS2_112();
                case cardIDEnum.HERO_07:
                    return new Sim_HERO_07();
                case cardIDEnum.HERO_07a:
                    return new Sim_HERO_07();
                case cardIDEnum.EX1_412:
                    return new Sim_EX1_412();
                case cardIDEnum.CS2_117:
                    return new Sim_CS2_117();
                case cardIDEnum.EX1_562:
                    return new Sim_EX1_562();
                case cardIDEnum.EX1_055:
                    return new Sim_EX1_055();
                case cardIDEnum.FP1_012:
                    return new Sim_FP1_012();
                case cardIDEnum.EX1_317t:
                    return new Sim_EX1_317t();
                case cardIDEnum.EX1_278:
                    return new Sim_EX1_278();
                case cardIDEnum.CS2_tk1:
                    return new Sim_CS2_tk1();
                case cardIDEnum.EX1_590:
                    return new Sim_EX1_590();
                case cardIDEnum.CS1_130:
                    return new Sim_CS1_130();
                case cardIDEnum.NEW1_008b:
                    return new Sim_NEW1_008b();
                case cardIDEnum.EX1_365:
                    return new Sim_EX1_365();
                case cardIDEnum.CS2_141:
                    return new Sim_CS2_141();
                case cardIDEnum.PRO_001:
                    return new Sim_PRO_001();
                case cardIDEnum.CS2_173:
                    return new Sim_CS2_173();
                case cardIDEnum.CS2_017:
                    return new Sim_CS2_017();
                case cardIDEnum.EX1_392:
                    return new Sim_EX1_392();
                case cardIDEnum.EX1_593:
                    return new Sim_EX1_593();
                case cardIDEnum.EX1_049:
                    return new Sim_EX1_049();
                case cardIDEnum.EX1_002:
                    return new Sim_EX1_002();
                case cardIDEnum.CS2_056:
                    return new Sim_CS2_056();
                case cardIDEnum.CS2_056_H1:
                    return new Sim_CS2_056();                    
                case cardIDEnum.EX1_596:
                    return new Sim_EX1_596();
                case cardIDEnum.EX1_136:
                    return new Sim_EX1_136();
                case cardIDEnum.EX1_323:
                    return new Sim_EX1_323();
                case cardIDEnum.CS2_073:
                    return new Sim_CS2_073();
                case cardIDEnum.EX1_001:
                    return new Sim_EX1_001();
                case cardIDEnum.EX1_044:
                    return new Sim_EX1_044();
                case cardIDEnum.Mekka4:
                    return new Sim_Mekka4();
                case cardIDEnum.CS2_142:
                    return new Sim_CS2_142();
                case cardIDEnum.EX1_573:
                    return new Sim_EX1_573();
                case cardIDEnum.FP1_009:
                    return new Sim_FP1_009();
                case cardIDEnum.CS2_050:
                    return new Sim_CS2_050();
                case cardIDEnum.EX1_390:
                    return new Sim_EX1_390();
                case cardIDEnum.EX1_610:
                    return new Sim_EX1_610();
                case cardIDEnum.hexfrog:
                    return new Sim_hexfrog();
                case cardIDEnum.CS2_082:
                    return new Sim_CS2_082();
                case cardIDEnum.NEW1_040:
                    return new Sim_NEW1_040();
                case cardIDEnum.DREAM_01:
                    return new Sim_DREAM_01();
                case cardIDEnum.EX1_595:
                    return new Sim_EX1_595();
                case cardIDEnum.CS2_013:
                    return new Sim_CS2_013();
                case cardIDEnum.CS2_077:
                    return new Sim_CS2_077();
                case cardIDEnum.NEW1_014:
                    return new Sim_NEW1_014();
                case cardIDEnum.GAME_002:
                    return new Sim_GAME_002();
                case cardIDEnum.EX1_165:
                    return new Sim_EX1_165();
                case cardIDEnum.CS2_013t:
                    return new Sim_CS2_013t();
                case cardIDEnum.EX1_tk11:
                    return new Sim_EX1_tk11();
                case cardIDEnum.EX1_591:
                    return new Sim_EX1_591();
                case cardIDEnum.EX1_549:
                    return new Sim_EX1_549();
                case cardIDEnum.CS2_045:
                    return new Sim_CS2_045();
                case cardIDEnum.CS2_237:
                    return new Sim_CS2_237();
                case cardIDEnum.CS2_027:
                    return new Sim_CS2_027();
                case cardIDEnum.CS2_101t:
                    return new Sim_CS2_101t();
                case cardIDEnum.CS2_063:
                    return new Sim_CS2_063();
                case cardIDEnum.EX1_145:
                    return new Sim_EX1_145();
                case cardIDEnum.EX1_110:
                    return new Sim_EX1_110();
                case cardIDEnum.EX1_408:
                    return new Sim_EX1_408();
                case cardIDEnum.EX1_544:
                    return new Sim_EX1_544();
                case cardIDEnum.CS2_151:
                    return new Sim_CS2_151();
                case cardIDEnum.CS2_088:
                    return new Sim_CS2_088();
                case cardIDEnum.EX1_057:
                    return new Sim_EX1_057();
                case cardIDEnum.FP1_020:
                    return new Sim_FP1_020();
                case cardIDEnum.CS2_169:
                    return new Sim_CS2_169();
                case cardIDEnum.EX1_573t:
                    return new Sim_EX1_573t();
                case cardIDEnum.EX1_323h:
                    return new Sim_EX1_323h();
                case cardIDEnum.EX1_tk9:
                    return new Sim_EX1_tk9();
                case cardIDEnum.CS2_037:
                    return new Sim_CS2_037();
                case cardIDEnum.CS2_007:
                    return new Sim_CS2_007();
                case cardIDEnum.CS2_227:
                    return new Sim_CS2_227();
                case cardIDEnum.NEW1_003:
                    return new Sim_NEW1_003();
                case cardIDEnum.GAME_006:
                    return new Sim_GAME_006();
                case cardIDEnum.EX1_320:
                    return new Sim_EX1_320();
                case cardIDEnum.EX1_097:
                    return new Sim_EX1_097();
                case cardIDEnum.tt_004:
                    return new Sim_tt_004();
                case cardIDEnum.EX1_096:
                    return new Sim_EX1_096();
                case cardIDEnum.EX1_126:
                    return new Sim_EX1_126();
                case cardIDEnum.EX1_577:
                    return new Sim_EX1_577();
                case cardIDEnum.EX1_319:
                    return new Sim_EX1_319();
                case cardIDEnum.EX1_611:
                    return new Sim_EX1_611();
                case cardIDEnum.CS2_146:
                    return new Sim_CS2_146();
                case cardIDEnum.EX1_154b:
                    return new Sim_EX1_154b();
                case cardIDEnum.skele11:
                    return new Sim_skele11();
                case cardIDEnum.EX1_165t2:
                    return new Sim_EX1_165t2();
                case cardIDEnum.CS2_172:
                    return new Sim_CS2_172();
                case cardIDEnum.CS2_114:
                    return new Sim_CS2_114();
                case cardIDEnum.CS1_069:
                    return new Sim_CS1_069();
                case cardIDEnum.EX1_173:
                    return new Sim_EX1_173();
                case cardIDEnum.CS1_042:
                    return new Sim_CS1_042();
                case cardIDEnum.EX1_506a:
                    return new Sim_EX1_506a();
                case cardIDEnum.EX1_298:
                    return new Sim_EX1_298();
                case cardIDEnum.CS2_104:
                    return new Sim_CS2_104();
                case cardIDEnum.FP1_001:
                    return new Sim_FP1_001();
                case cardIDEnum.HERO_02:
                    return new Sim_HERO_02();
                case cardIDEnum.HERO_02a:
                    return new Sim_HERO_02();
                case cardIDEnum.CS2_051:
                    return new Sim_CS2_051();
                case cardIDEnum.NEW1_016:
                    return new Sim_NEW1_016();
                case cardIDEnum.EX1_033:
                    return new Sim_EX1_033();
                case cardIDEnum.EX1_028:
                    return new Sim_EX1_028();
                case cardIDEnum.EX1_621:
                    return new Sim_EX1_621();
                case cardIDEnum.EX1_554:
                    return new Sim_EX1_554();
                case cardIDEnum.EX1_091:
                    return new Sim_EX1_091();
                case cardIDEnum.FP1_017:
                    return new Sim_FP1_017();
                case cardIDEnum.EX1_409:
                    return new Sim_EX1_409();
                case cardIDEnum.EX1_410:
                    return new Sim_EX1_410();
                case cardIDEnum.CS2_039:
                    return new Sim_CS2_039();
                case cardIDEnum.EX1_557:
                    return new Sim_EX1_557();
                case cardIDEnum.DS1_070:
                    return new Sim_DS1_070();
                case cardIDEnum.CS2_033:
                    return new Sim_CS2_033();
                case cardIDEnum.EX1_536:
                    return new Sim_EX1_536();
                case cardIDEnum.EX1_559:
                    return new Sim_EX1_559();
                case cardIDEnum.CS2_052:
                    return new Sim_CS2_052();
                case cardIDEnum.EX1_539:
                    return new Sim_EX1_539();
                case cardIDEnum.EX1_575:
                    return new Sim_EX1_575();
                case cardIDEnum.CS2_083b:
                    return new Sim_CS2_083b();
                case cardIDEnum.CS2_083b_H1:
                    return new Sim_CS2_083b();                    
                case cardIDEnum.CS2_061:
                    return new Sim_CS2_061();
                case cardIDEnum.NEW1_021:
                    return new Sim_NEW1_021();
                case cardIDEnum.DS1_055:
                    return new Sim_DS1_055();
                case cardIDEnum.EX1_625:
                    return new Sim_EX1_625();
                case cardIDEnum.CS2_026:
                    return new Sim_CS2_026();
                case cardIDEnum.EX1_294:
                    return new Sim_EX1_294();
                case cardIDEnum.EX1_287:
                    return new Sim_EX1_287();
                case cardIDEnum.EX1_625t2:
                    return new Sim_EX1_625t2();
                case cardIDEnum.CS2_118:
                    return new Sim_CS2_118();
                case cardIDEnum.CS2_124:
                    return new Sim_CS2_124();
                case cardIDEnum.Mekka3:
                    return new Sim_Mekka3();
                case cardIDEnum.EX1_112:
                    return new Sim_EX1_112();
                case cardIDEnum.FP1_011:
                    return new Sim_FP1_011();
                case cardIDEnum.HERO_04:
                    return new Sim_HERO_04();
                case cardIDEnum.HERO_04a:
                    return new Sim_HERO_04();
                case cardIDEnum.EX1_607:
                    return new Sim_EX1_607();
                case cardIDEnum.DREAM_03:
                    return new Sim_DREAM_03();
                case cardIDEnum.FP1_003:
                    return new Sim_FP1_003();
                case cardIDEnum.CS2_105:
                    return new Sim_CS2_105();
                case cardIDEnum.FP1_002:
                    return new Sim_FP1_002();
                case cardIDEnum.EX1_567:
                    return new Sim_EX1_567();
                case cardIDEnum.FP1_008:
                    return new Sim_FP1_008();
                case cardIDEnum.DS1_184:
                    return new Sim_DS1_184();
                case cardIDEnum.CS2_029:
                    return new Sim_CS2_029();
                case cardIDEnum.GAME_005:
                    return new Sim_GAME_005();
                case cardIDEnum.CS2_187:
                    return new Sim_CS2_187();
                case cardIDEnum.EX1_020:
                    return new Sim_EX1_020();
                case cardIDEnum.EX1_011:
                    return new Sim_EX1_011();
                case cardIDEnum.CS2_057:
                    return new Sim_CS2_057();
                case cardIDEnum.EX1_274:
                    return new Sim_EX1_274();
                case cardIDEnum.EX1_306:
                    return new Sim_EX1_306();
                case cardIDEnum.EX1_170:
                    return new Sim_EX1_170();
                case cardIDEnum.EX1_617:
                    return new Sim_EX1_617();
                case cardIDEnum.CS2_101:
                    return new Sim_CS2_101();
                case cardIDEnum.CS2_101_H1:
                    return new Sim_CS2_101();
                case cardIDEnum.FP1_015:
                    return new Sim_FP1_015();
                case cardIDEnum.CS2_005:
                    return new Sim_CS2_005();
                case cardIDEnum.EX1_537:
                    return new Sim_EX1_537();
                case cardIDEnum.EX1_384:
                    return new Sim_EX1_384();
                case cardIDEnum.EX1_362:
                    return new Sim_EX1_362();
                case cardIDEnum.EX1_301:
                    return new Sim_EX1_301();
                case cardIDEnum.CS2_235:
                    return new Sim_CS2_235();
                case cardIDEnum.EX1_029:
                    return new Sim_EX1_029();
                case cardIDEnum.CS2_042:
                    return new Sim_CS2_042();
                case cardIDEnum.EX1_155a:
                    return new Sim_EX1_155a();
                case cardIDEnum.CS2_102:
                    return new Sim_CS2_102();
                case cardIDEnum.CS2_102_H1:
                    return new Sim_CS2_102();
                case cardIDEnum.EX1_609:
                    return new Sim_EX1_609();
                case cardIDEnum.NEW1_027:
                    return new Sim_NEW1_027();
                case cardIDEnum.EX1_165a:
                    return new Sim_EX1_165a();
                case cardIDEnum.EX1_570:
                    return new Sim_EX1_570();
                case cardIDEnum.EX1_131:
                    return new Sim_EX1_131();
                case cardIDEnum.EX1_556:
                    return new Sim_EX1_556();
                case cardIDEnum.EX1_543:
                    return new Sim_EX1_543();
                case cardIDEnum.NEW1_009:
                    return new Sim_NEW1_009();
                case cardIDEnum.EX1_100:
                    return new Sim_EX1_100();
                case cardIDEnum.EX1_573a:
                    return new Sim_EX1_573a();
                case cardIDEnum.CS2_084:
                    return new Sim_CS2_084();
                case cardIDEnum.EX1_582:
                    return new Sim_EX1_582();
                case cardIDEnum.EX1_043:
                    return new Sim_EX1_043();
                case cardIDEnum.EX1_050:
                    return new Sim_EX1_050();
                case cardIDEnum.FP1_005:
                    return new Sim_FP1_005();
                case cardIDEnum.EX1_620:
                    return new Sim_EX1_620();
                case cardIDEnum.EX1_303:
                    return new Sim_EX1_303();
                case cardIDEnum.HERO_09:
                    return new Sim_HERO_09();
                case cardIDEnum.HERO_09a:
                    return new Sim_HERO_09();
                case cardIDEnum.EX1_067:
                    return new Sim_EX1_067();
                case cardIDEnum.EX1_277:
                    return new Sim_EX1_277();
                case cardIDEnum.Mekka2:
                    return new Sim_Mekka2();
                case cardIDEnum.FP1_024:
                    return new Sim_FP1_024();
                case cardIDEnum.FP1_030:
                    return new Sim_FP1_030();
                case cardIDEnum.EX1_178:
                    return new Sim_EX1_178();
                case cardIDEnum.CS2_222:
                    return new Sim_CS2_222();
                case cardIDEnum.EX1_160a:
                    return new Sim_EX1_160a();
                case cardIDEnum.CS2_012:
                    return new Sim_CS2_012();
                case cardIDEnum.EX1_246:
                    return new Sim_EX1_246();
                case cardIDEnum.EX1_572:
                    return new Sim_EX1_572();
                case cardIDEnum.EX1_089:
                    return new Sim_EX1_089();
                case cardIDEnum.CS2_059:
                    return new Sim_CS2_059();
                case cardIDEnum.EX1_279:
                    return new Sim_EX1_279();
                case cardIDEnum.CS2_168:
                    return new Sim_CS2_168();
                case cardIDEnum.tt_010:
                    return new Sim_tt_010();
                case cardIDEnum.NEW1_023:
                    return new Sim_NEW1_023();
                case cardIDEnum.CS2_075:
                    return new Sim_CS2_075();
                case cardIDEnum.EX1_316:
                    return new Sim_EX1_316();
                case cardIDEnum.CS2_025:
                    return new Sim_CS2_025();
                case cardIDEnum.CS2_234:
                    return new Sim_CS2_234();
                case cardIDEnum.EX1_130:
                    return new Sim_EX1_130();
                case cardIDEnum.CS2_064:
                    return new Sim_CS2_064();
                case cardIDEnum.EX1_161:
                    return new Sim_EX1_161();
                case cardIDEnum.CS2_049:
                    return new Sim_CS2_049();
                case cardIDEnum.CS2_049_H1:
                    return new Sim_CS2_049();
                case cardIDEnum.EX1_154:
                    return new Sim_EX1_154();
                case cardIDEnum.EX1_080:
                    return new Sim_EX1_080();
                case cardIDEnum.NEW1_022:
                    return new Sim_NEW1_022();
                case cardIDEnum.EX1_251:
                    return new Sim_EX1_251();
                case cardIDEnum.FP1_025:
                    return new Sim_FP1_025();
                case cardIDEnum.EX1_371:
                    return new Sim_EX1_371();
                case cardIDEnum.CS2_mirror:
                    return new Sim_CS2_mirror();
                case cardIDEnum.EX1_594:
                    return new Sim_EX1_594();
                case cardIDEnum.EX1_560:
                    return new Sim_EX1_560();
                case cardIDEnum.CS2_236:
                    return new Sim_CS2_236();
                case cardIDEnum.EX1_402:
                    return new Sim_EX1_402();
                case cardIDEnum.EX1_506:
                    return new Sim_EX1_506();
                case cardIDEnum.DS1_178:
                    return new Sim_DS1_178();
                case cardIDEnum.EX1_315:
                    return new Sim_EX1_315();
                case cardIDEnum.CS2_094:
                    return new Sim_CS2_094();
                case cardIDEnum.NEW1_040t:
                    return new Sim_NEW1_040t();
                case cardIDEnum.CS2_131:
                    return new Sim_CS2_131();
                case cardIDEnum.EX1_082:
                    return new Sim_EX1_082();
                case cardIDEnum.CS2_093:
                    return new Sim_CS2_093();
                case cardIDEnum.CS2_boar:
                    return new Sim_CS2_boar();
                case cardIDEnum.NEW1_019:
                    return new Sim_NEW1_019();
                case cardIDEnum.EX1_289:
                    return new Sim_EX1_289();
                case cardIDEnum.EX1_025t:
                    return new Sim_EX1_025t();
                case cardIDEnum.EX1_398t:
                    return new Sim_EX1_398t();
                case cardIDEnum.CS2_091:
                    return new Sim_CS2_091();
                case cardIDEnum.EX1_241:
                    return new Sim_EX1_241();
                case cardIDEnum.EX1_085:
                    return new Sim_EX1_085();
                case cardIDEnum.CS2_200:
                    return new Sim_CS2_200();
                case cardIDEnum.CS2_034:
                    return new Sim_CS2_034();
                case cardIDEnum.CS2_034_H1:
                    return new Sim_CS2_034();
                case cardIDEnum.CS2_034_H2:
                    return new Sim_CS2_034();
                case cardIDEnum.CS2_034_H2_AT_132:
                    return new Sim_CS2_034_H1_AT_132();
                case cardIDEnum.EX1_583:
                    return new Sim_EX1_583();
                case cardIDEnum.EX1_584:
                    return new Sim_EX1_584();
                case cardIDEnum.EX1_155:
                    return new Sim_EX1_155();
                case cardIDEnum.EX1_622:
                    return new Sim_EX1_622();
                case cardIDEnum.CS2_203:
                    return new Sim_CS2_203();
                case cardIDEnum.EX1_124:
                    return new Sim_EX1_124();
                case cardIDEnum.EX1_379:
                    return new Sim_EX1_379();
                case cardIDEnum.EX1_032:
                    return new Sim_EX1_032();
                case cardIDEnum.EX1_391:
                    return new Sim_EX1_391();
                case cardIDEnum.EX1_366:
                    return new Sim_EX1_366();
                case cardIDEnum.EX1_400:
                    return new Sim_EX1_400();
                case cardIDEnum.EX1_614:
                    return new Sim_EX1_614();
                case cardIDEnum.EX1_561:
                    return new Sim_EX1_561();
                case cardIDEnum.EX1_332:
                    return new Sim_EX1_332();
                case cardIDEnum.HERO_05:
                    return new Sim_HERO_05();
                case cardIDEnum.HERO_05a:
                    return new Sim_HERO_05();
                case cardIDEnum.CS2_065:
                    return new Sim_CS2_065();
                case cardIDEnum.ds1_whelptoken:
                    return new Sim_ds1_whelptoken();
                case cardIDEnum.CS2_032:
                    return new Sim_CS2_032();
                case cardIDEnum.CS2_120:
                    return new Sim_CS2_120();
                case cardIDEnum.EX1_247:
                    return new Sim_EX1_247();
                case cardIDEnum.EX1_154a:
                    return new Sim_EX1_154a();
                case cardIDEnum.EX1_554t:
                    return new Sim_EX1_554t();
                case cardIDEnum.NEW1_026t:
                    return new Sim_NEW1_026t();
                case cardIDEnum.EX1_623:
                    return new Sim_EX1_623();
                case cardIDEnum.EX1_383t:
                    return new Sim_EX1_383t();
                case cardIDEnum.EX1_597:
                    return new Sim_EX1_597();
                case cardIDEnum.EX1_130a:
                    return new Sim_EX1_130a();
                case cardIDEnum.CS2_011:
                    return new Sim_CS2_011();
                case cardIDEnum.EX1_169:
                    return new Sim_EX1_169();
                case cardIDEnum.EX1_tk33:
                    return new Sim_EX1_tk33();
                case cardIDEnum.EX1_250:
                    return new Sim_EX1_250();
                case cardIDEnum.EX1_564:
                    return new Sim_EX1_564();
                case cardIDEnum.EX1_349:
                    return new Sim_EX1_349();
                case cardIDEnum.EX1_102:
                    return new Sim_EX1_102();
                case cardIDEnum.EX1_058:
                    return new Sim_EX1_058();
                case cardIDEnum.EX1_243:
                    return new Sim_EX1_243();
                case cardIDEnum.PRO_001c:
                    return new Sim_PRO_001c();
                case cardIDEnum.EX1_116t:
                    return new Sim_EX1_116t();
                case cardIDEnum.FP1_029:
                    return new Sim_FP1_029();
                case cardIDEnum.CS2_089:
                    return new Sim_CS2_089();
                case cardIDEnum.EX1_248:
                    return new Sim_EX1_248();
                case cardIDEnum.CS2_122:
                    return new Sim_CS2_122();
                case cardIDEnum.EX1_393:
                    return new Sim_EX1_393();
                case cardIDEnum.CS2_232:
                    return new Sim_CS2_232();
                case cardIDEnum.EX1_165b:
                    return new Sim_EX1_165b();
                case cardIDEnum.NEW1_030:
                    return new Sim_NEW1_030();
                case cardIDEnum.CS2_150:
                    return new Sim_CS2_150();
                case cardIDEnum.CS2_152:
                    return new Sim_CS2_152();
                case cardIDEnum.EX1_160t:
                    return new Sim_EX1_160t();
                case cardIDEnum.CS2_127:
                    return new Sim_CS2_127();
                case cardIDEnum.DS1_188:
                    return new Sim_DS1_188();
                case cardIDEnum.CFM_020:
                    return new Sim_CFM_020();
                case cardIDEnum.CFM_021:
                    return new Sim_CFM_021();
                case cardIDEnum.CFM_025:
                    return new Sim_CFM_025();
                case cardIDEnum.CFM_026:
                    return new Sim_CFM_026();
                case cardIDEnum.CFM_039:
                    return new Sim_CFM_039();
                case cardIDEnum.CFM_060:
                    return new Sim_CFM_060();
                case cardIDEnum.CFM_061:
                    return new Sim_CFM_061();
                case cardIDEnum.CFM_062:
                    return new Sim_CFM_062();
                case cardIDEnum.CFM_063:
                    return new Sim_CFM_063();
                case cardIDEnum.CFM_064:
                    return new Sim_CFM_064();
                case cardIDEnum.CFM_065:
                    return new Sim_CFM_065();
                case cardIDEnum.CFM_066:
                    return new Sim_CFM_066();
                case cardIDEnum.CFM_067:
                    return new Sim_CFM_067();
                case cardIDEnum.CFM_094:
                    return new Sim_CFM_094();
                case cardIDEnum.CFM_095:
                    return new Sim_CFM_095();
                case cardIDEnum.CFM_120:
                    return new Sim_CFM_120();
                case cardIDEnum.CFM_300:
                    return new Sim_CFM_300();
                case cardIDEnum.CFM_305:
                    return new Sim_CFM_305();
                case cardIDEnum.CFM_308:
                    return new Sim_CFM_308();
                case cardIDEnum.CFM_308a:
                    return new Sim_CFM_308a();
                case cardIDEnum.CFM_308b:
                    return new Sim_CFM_308b();
                case cardIDEnum.CFM_310:
                    return new Sim_CFM_310();
                case cardIDEnum.CFM_312:
                    return new Sim_CFM_312();
                case cardIDEnum.CFM_313:
                    return new Sim_CFM_313();
                case cardIDEnum.CFM_315:
                    return new Sim_CFM_315();
                case cardIDEnum.CFM_316:
                    return new Sim_CFM_316();
                case cardIDEnum.CFM_321:
                    return new Sim_CFM_321();
                case cardIDEnum.CFM_324:
                    return new Sim_CFM_324();
                case cardIDEnum.CFM_325:
                    return new Sim_CFM_325();
                case cardIDEnum.CFM_328:
                    return new Sim_CFM_328();
                case cardIDEnum.CFM_333:
                    return new Sim_CFM_333();
                case cardIDEnum.CFM_334:
                    return new Sim_CFM_334();
                case cardIDEnum.CFM_335:
                    return new Sim_CFM_335();
                case cardIDEnum.CFM_336:
                    return new Sim_CFM_336();
                case cardIDEnum.CFM_337:
                    return new Sim_CFM_337();
                case cardIDEnum.CFM_338:
                    return new Sim_CFM_338();
                case cardIDEnum.CFM_341:
                    return new Sim_CFM_341();
                case cardIDEnum.CFM_342:
                    return new Sim_CFM_342();
                case cardIDEnum.CFM_343:
                    return new Sim_CFM_343();
                case cardIDEnum.CFM_344:
                    return new Sim_CFM_344();
                case cardIDEnum.CFM_602:
                    return new Sim_CFM_602();
                case cardIDEnum.CFM_602a:
                    return new Sim_CFM_602a();
                case cardIDEnum.CFM_602b:
                    return new Sim_CFM_602b();
                case cardIDEnum.CFM_603:
                    return new Sim_CFM_603();
                case cardIDEnum.CFM_604:
                    return new Sim_CFM_604();
                case cardIDEnum.CFM_605:
                    return new Sim_CFM_605();
                case cardIDEnum.CFM_606:
                    return new Sim_CFM_606();
                case cardIDEnum.CFM_608:
                    return new Sim_CFM_608();
                case cardIDEnum.CFM_609:
                    return new Sim_CFM_609();
                case cardIDEnum.CFM_610:
                    return new Sim_CFM_610();
                case cardIDEnum.CFM_611:
                    return new Sim_CFM_611();
                case cardIDEnum.CFM_614:
                    return new Sim_CFM_614();
                case cardIDEnum.CFM_616:
                    return new Sim_CFM_616();
                case cardIDEnum.CFM_617:
                    return new Sim_CFM_617();
                case cardIDEnum.CFM_619:
                    return new Sim_CFM_619();
                case cardIDEnum.CFM_620:
                    return new Sim_CFM_620();
                case cardIDEnum.CFM_621:
                    return new Sim_CFM_621();
                case cardIDEnum.CFM_623:
                    return new Sim_CFM_623();
                case cardIDEnum.CFM_626:
                    return new Sim_CFM_626();
                case cardIDEnum.CFM_630:
                    return new Sim_CFM_630();
                case cardIDEnum.CFM_631:
                    return new Sim_CFM_631();
                case cardIDEnum.CFM_634:
                    return new Sim_CFM_634();
                case cardIDEnum.CFM_636:
                    return new Sim_CFM_636();
                case cardIDEnum.CFM_637:
                    return new Sim_CFM_637();
                case cardIDEnum.CFM_639:
                    return new Sim_CFM_639();
                case cardIDEnum.CFM_643:
                    return new Sim_CFM_643();
                case cardIDEnum.CFM_646:
                    return new Sim_CFM_646();
                case cardIDEnum.CFM_647:
                    return new Sim_CFM_647();
                case cardIDEnum.CFM_648:
                    return new Sim_CFM_648();
                case cardIDEnum.CFM_649:
                    return new Sim_CFM_649();
                case cardIDEnum.CFM_650:
                    return new Sim_CFM_650();
                case cardIDEnum.CFM_651:
                    return new Sim_CFM_651();
                case cardIDEnum.CFM_652:
                    return new Sim_CFM_652();
                case cardIDEnum.CFM_653:
                    return new Sim_CFM_653();
                case cardIDEnum.CFM_654:
                    return new Sim_CFM_654();
                case cardIDEnum.CFM_655:
                    return new Sim_CFM_655();
                case cardIDEnum.CFM_656:
                    return new Sim_CFM_656();
                case cardIDEnum.CFM_657:
                    return new Sim_CFM_657();
                case cardIDEnum.CFM_658:
                    return new Sim_CFM_658();
                case cardIDEnum.CFM_659:
                    return new Sim_CFM_659();
                case cardIDEnum.CFM_660:
                    return new Sim_CFM_660();
                case cardIDEnum.CFM_661:
                    return new Sim_CFM_661();
                case cardIDEnum.CFM_662:
                    return new Sim_CFM_662();
                case cardIDEnum.CFM_663:
                    return new Sim_CFM_663();
                case cardIDEnum.CFM_665:
                    return new Sim_CFM_665();
                case cardIDEnum.CFM_666:
                    return new Sim_CFM_666();
                case cardIDEnum.CFM_667:
                    return new Sim_CFM_667();
                case cardIDEnum.CFM_668:
                    return new Sim_CFM_668();
                case cardIDEnum.CFM_669:
                    return new Sim_CFM_669();
                case cardIDEnum.CFM_670:
                    return new Sim_CFM_670();
                case cardIDEnum.CFM_671:
                    return new Sim_CFM_671();
                case cardIDEnum.CFM_672:
                    return new Sim_CFM_672();
                case cardIDEnum.CFM_685:
                    return new Sim_CFM_685();
                case cardIDEnum.CFM_687:
                    return new Sim_CFM_687();
                case cardIDEnum.CFM_688:
                    return new Sim_CFM_688();
                case cardIDEnum.CFM_690:
                    return new Sim_CFM_690();
                case cardIDEnum.CFM_691:
                    return new Sim_CFM_691();
                case cardIDEnum.CFM_693:
                    return new Sim_CFM_693();
                case cardIDEnum.CFM_694:
                    return new Sim_CFM_694();
                case cardIDEnum.CFM_696:
                    return new Sim_CFM_696();
                case cardIDEnum.CFM_697:
                    return new Sim_CFM_697();
                case cardIDEnum.CFM_699:
                    return new Sim_CFM_699();
                case cardIDEnum.CFM_707:
                    return new Sim_CFM_707();
                case cardIDEnum.CFM_713:
                    return new Sim_CFM_713();
                case cardIDEnum.CFM_715:
                    return new Sim_CFM_715();
                case cardIDEnum.CFM_716:
                    return new Sim_CFM_716();
                case cardIDEnum.CFM_717:
                    return new Sim_CFM_717();
                case cardIDEnum.CFM_750:
                    return new Sim_CFM_750();
                case cardIDEnum.CFM_751:
                    return new Sim_CFM_751();
                case cardIDEnum.CFM_752:
                    return new Sim_CFM_752();
                case cardIDEnum.CFM_753:
                    return new Sim_CFM_753();
                case cardIDEnum.CFM_754:
                    return new Sim_CFM_754();
                case cardIDEnum.CFM_755:
                    return new Sim_CFM_755();
                case cardIDEnum.CFM_756:
                    return new Sim_CFM_756();
                case cardIDEnum.CFM_759:
                    return new Sim_CFM_759();
                case cardIDEnum.CFM_760:
                    return new Sim_CFM_760();
                case cardIDEnum.CFM_781:
                    return new Sim_CFM_781();
                case cardIDEnum.CFM_790:
                    return new Sim_CFM_790();
                case cardIDEnum.CFM_800:
                    return new Sim_CFM_800();
                case cardIDEnum.CFM_806:
                    return new Sim_CFM_806();
                case cardIDEnum.CFM_807:
                    return new Sim_CFM_807();
                case cardIDEnum.CFM_808:
                    return new Sim_CFM_808();
                case cardIDEnum.CFM_809:
                    return new Sim_CFM_809();
                case cardIDEnum.CFM_810:
                    return new Sim_CFM_810();
                case cardIDEnum.CFM_811:
                    return new Sim_CFM_811();
                case cardIDEnum.CFM_815:
                    return new Sim_CFM_815();
                case cardIDEnum.CFM_816:
                    return new Sim_CFM_816();
                case cardIDEnum.CFM_851:
                    return new Sim_CFM_851();
                case cardIDEnum.CFM_852:
                    return new Sim_CFM_852();
                case cardIDEnum.CFM_853:
                    return new Sim_CFM_853();
                case cardIDEnum.CFM_854:
                    return new Sim_CFM_854();
                case cardIDEnum.CFM_855:
                    return new Sim_CFM_855();
                case cardIDEnum.CFM_900:
                    return new Sim_CFM_900();
                case cardIDEnum.CFM_902:
                    return new Sim_CFM_902();
                case cardIDEnum.CFM_905:
                    return new Sim_CFM_905();
                case cardIDEnum.CFM_940:
                    return new Sim_CFM_940();
                case cardIDEnum.CFM_621t10:
                    return new Sim_CFM_621t10();
                case cardIDEnum.CFM_621t16:
                    return new Sim_CFM_621t16();
                case cardIDEnum.CFM_621t17:
                    return new Sim_CFM_621t17();
                case cardIDEnum.CFM_621t18:
                    return new Sim_CFM_621t18();
                case cardIDEnum.CFM_621t19:
                    return new Sim_CFM_621t19();
                case cardIDEnum.CFM_621t2:
                    return new Sim_CFM_621t2();
                case cardIDEnum.CFM_621t20:
                    return new Sim_CFM_621t20();
                case cardIDEnum.CFM_621t21:
                    return new Sim_CFM_621t21();
                case cardIDEnum.CFM_621t22:
                    return new Sim_CFM_621t22();
                case cardIDEnum.CFM_621t23:
                    return new Sim_CFM_621t23();
                case cardIDEnum.CFM_621t24:
                    return new Sim_CFM_621t24();
                case cardIDEnum.CFM_621t25:
                    return new Sim_CFM_621t25();
                case cardIDEnum.CFM_621t26:
                    return new Sim_CFM_621t26();
                case cardIDEnum.CFM_621t27:
                    return new Sim_CFM_621t27();
                case cardIDEnum.CFM_621t28:
                    return new Sim_CFM_621t28();
                case cardIDEnum.CFM_621t29:
                    return new Sim_CFM_621t29();
                case cardIDEnum.CFM_621t3:
                    return new Sim_CFM_621t3();
                case cardIDEnum.CFM_621t30:
                    return new Sim_CFM_621t30();
                case cardIDEnum.CFM_621t31:
                    return new Sim_CFM_621t31();
                case cardIDEnum.CFM_621t32:
                    return new Sim_CFM_621t32();
                case cardIDEnum.CFM_621t33:
                    return new Sim_CFM_621t33();
                case cardIDEnum.CFM_621t37:
                    return new Sim_CFM_621t37();
                case cardIDEnum.CFM_621t38:
                    return new Sim_CFM_621t38();
                case cardIDEnum.CFM_621t39:
                    return new Sim_CFM_621t39();
                case cardIDEnum.CFM_621t4:
                    return new Sim_CFM_621t4();
                case cardIDEnum.CFM_621t5:
                    return new Sim_CFM_621t5();
                case cardIDEnum.CFM_621t6:
                    return new Sim_CFM_621t6();
                case cardIDEnum.CFM_621t8:
                    return new Sim_CFM_621t8();
                case cardIDEnum.CFM_621t9:
                    return new Sim_CFM_621t9();
                case cardIDEnum.CFM_668t:
                    return new Sim_CFM_668t();
                case cardIDEnum.CFM_668t2:
                    return new Sim_CFM_668t2();
                case CardDB.cardIDEnum.GVG_001:
                    return new Sim_GVG_001();
                case CardDB.cardIDEnum.GVG_002:
                    return new Sim_GVG_002();
                case CardDB.cardIDEnum.GVG_003:
                    return new Sim_GVG_003();
                case CardDB.cardIDEnum.GVG_004:
                    return new Sim_GVG_004();
                case CardDB.cardIDEnum.GVG_005:
                    return new Sim_GVG_005();
                case CardDB.cardIDEnum.GVG_006:
                    return new Sim_GVG_006();
                case CardDB.cardIDEnum.GVG_007:
                    return new Sim_GVG_007();
                case CardDB.cardIDEnum.GVG_008:
                    return new Sim_GVG_008();
                case CardDB.cardIDEnum.GVG_009:
                    return new Sim_GVG_009();
                case CardDB.cardIDEnum.GVG_010:
                    return new Sim_GVG_010();
                case CardDB.cardIDEnum.GVG_011:
                    return new Sim_GVG_011();
                case CardDB.cardIDEnum.GVG_012:
                    return new Sim_GVG_012();
                case CardDB.cardIDEnum.GVG_013:
                    return new Sim_GVG_013();
                case CardDB.cardIDEnum.GVG_014:
                    return new Sim_GVG_014();
                case CardDB.cardIDEnum.GVG_015:
                    return new Sim_GVG_015();
                case CardDB.cardIDEnum.GVG_016:
                    return new Sim_GVG_016();
                case CardDB.cardIDEnum.GVG_017:
                    return new Sim_GVG_017();
                case CardDB.cardIDEnum.GVG_018:
                    return new Sim_GVG_018();
                case CardDB.cardIDEnum.GVG_019:
                    return new Sim_GVG_019();
                case CardDB.cardIDEnum.GVG_020:
                    return new Sim_GVG_020();
                case CardDB.cardIDEnum.GVG_021:
                    return new Sim_GVG_021();
                case CardDB.cardIDEnum.GVG_022:
                    return new Sim_GVG_022();
                case CardDB.cardIDEnum.GVG_023:
                    return new Sim_GVG_023();
                case CardDB.cardIDEnum.GVG_024:
                    return new Sim_GVG_024();
                case CardDB.cardIDEnum.GVG_025:
                    return new Sim_GVG_025();
                case CardDB.cardIDEnum.GVG_026:
                    return new Sim_GVG_026();
                case CardDB.cardIDEnum.GVG_027:
                    return new Sim_GVG_027();
                case CardDB.cardIDEnum.GVG_028:
                    return new Sim_GVG_028();
                case CardDB.cardIDEnum.GVG_028t:
                    return new Sim_GVG_028t();
                case CardDB.cardIDEnum.GVG_029:
                    return new Sim_GVG_029();
                case CardDB.cardIDEnum.GVG_030:
                    return new Sim_GVG_030();
                case CardDB.cardIDEnum.GVG_030a:
                    return new Sim_GVG_030a();
                case CardDB.cardIDEnum.GVG_030b:
                    return new Sim_GVG_030b();
                case CardDB.cardIDEnum.GVG_031:
                    return new Sim_GVG_031();
                case CardDB.cardIDEnum.GVG_032:
                    return new Sim_GVG_032();
                case CardDB.cardIDEnum.GVG_032a:
                    return new Sim_GVG_032a();
                case CardDB.cardIDEnum.GVG_032b:
                    return new Sim_GVG_032b();
                case CardDB.cardIDEnum.GVG_033:
                    return new Sim_GVG_033();
                case CardDB.cardIDEnum.GVG_034:
                    return new Sim_GVG_034();
                case CardDB.cardIDEnum.GVG_035:
                    return new Sim_GVG_035();
                case CardDB.cardIDEnum.GVG_036:
                    return new Sim_GVG_036();
                case CardDB.cardIDEnum.GVG_037:
                    return new Sim_GVG_037();
                case CardDB.cardIDEnum.GVG_038:
                    return new Sim_GVG_038();
                case CardDB.cardIDEnum.GVG_039:
                    return new Sim_GVG_039();
                case CardDB.cardIDEnum.GVG_040:
                    return new Sim_GVG_040();
                case CardDB.cardIDEnum.GVG_041:
                    return new Sim_GVG_041();
                case CardDB.cardIDEnum.GVG_041a:
                    return new Sim_GVG_041a();
                case CardDB.cardIDEnum.GVG_041b:
                    return new Sim_GVG_041b();
                case CardDB.cardIDEnum.GVG_042:
                    return new Sim_GVG_042();
                case CardDB.cardIDEnum.GVG_043:
                    return new Sim_GVG_043();
                case CardDB.cardIDEnum.GVG_044:
                    return new Sim_GVG_044();
                case CardDB.cardIDEnum.GVG_045:
                    return new Sim_GVG_045();
                case CardDB.cardIDEnum.GVG_045t:
                    return new Sim_GVG_045t();
                case CardDB.cardIDEnum.GVG_046:
                    return new Sim_GVG_046();
                case CardDB.cardIDEnum.GVG_047:
                    return new Sim_GVG_047();
                case CardDB.cardIDEnum.GVG_048:
                    return new Sim_GVG_048();
                case CardDB.cardIDEnum.GVG_049:
                    return new Sim_GVG_049();
                case CardDB.cardIDEnum.GVG_050:
                    return new Sim_GVG_050();
                case CardDB.cardIDEnum.GVG_051:
                    return new Sim_GVG_051();
                case CardDB.cardIDEnum.GVG_052:
                    return new Sim_GVG_052();
                case CardDB.cardIDEnum.GVG_053:
                    return new Sim_GVG_053();
                case CardDB.cardIDEnum.GVG_054:
                    return new Sim_GVG_054();
                case CardDB.cardIDEnum.GVG_055:
                    return new Sim_GVG_055();
                case CardDB.cardIDEnum.GVG_056:
                    return new Sim_GVG_056();
                case CardDB.cardIDEnum.GVG_056t:
                    return new Sim_GVG_056t();
                case CardDB.cardIDEnum.GVG_057:
                    return new Sim_GVG_057();
                case CardDB.cardIDEnum.GVG_058:
                    return new Sim_GVG_058();
                case CardDB.cardIDEnum.GVG_059:
                    return new Sim_GVG_059();
                case CardDB.cardIDEnum.GVG_060:
                    return new Sim_GVG_060();
                case CardDB.cardIDEnum.GVG_061:
                    return new Sim_GVG_061();
                case CardDB.cardIDEnum.GVG_062:
                    return new Sim_GVG_062();
                case CardDB.cardIDEnum.GVG_063:
                    return new Sim_GVG_063();
                case CardDB.cardIDEnum.GVG_064:
                    return new Sim_GVG_064();
                case CardDB.cardIDEnum.GVG_065:
                    return new Sim_GVG_065();
                case CardDB.cardIDEnum.GVG_066:
                    return new Sim_GVG_066();
                case CardDB.cardIDEnum.GVG_067:
                    return new Sim_GVG_067();
                case CardDB.cardIDEnum.GVG_068:
                    return new Sim_GVG_068();
                case CardDB.cardIDEnum.GVG_069:
                    return new Sim_GVG_069();
                case CardDB.cardIDEnum.GVG_070:
                    return new Sim_GVG_070();
                case CardDB.cardIDEnum.GVG_071:
                    return new Sim_GVG_071();
                case CardDB.cardIDEnum.GVG_072:
                    return new Sim_GVG_072();
                case CardDB.cardIDEnum.GVG_073:
                    return new Sim_GVG_073();
                case CardDB.cardIDEnum.GVG_074:
                    return new Sim_GVG_074();
                case CardDB.cardIDEnum.GVG_075:
                    return new Sim_GVG_075();
                case CardDB.cardIDEnum.GVG_076:
                    return new Sim_GVG_076();
                case CardDB.cardIDEnum.GVG_077:
                    return new Sim_GVG_077();
                case CardDB.cardIDEnum.GVG_078:
                    return new Sim_GVG_078();
                case CardDB.cardIDEnum.GVG_079:
                    return new Sim_GVG_079();
                case CardDB.cardIDEnum.GVG_080:
                    return new Sim_GVG_080();
                case CardDB.cardIDEnum.GVG_080t:
                    return new Sim_GVG_080t();
                case CardDB.cardIDEnum.GVG_081:
                    return new Sim_GVG_081();
                case CardDB.cardIDEnum.GVG_082:
                    return new Sim_GVG_082();
                case CardDB.cardIDEnum.GVG_083:
                    return new Sim_GVG_083();
                case CardDB.cardIDEnum.GVG_084:
                    return new Sim_GVG_084();
                case CardDB.cardIDEnum.GVG_085:
                    return new Sim_GVG_085();
                case CardDB.cardIDEnum.GVG_086:
                    return new Sim_GVG_086();
                case CardDB.cardIDEnum.GVG_087:
                    return new Sim_GVG_087();
                case CardDB.cardIDEnum.GVG_088:
                    return new Sim_GVG_088();
                case CardDB.cardIDEnum.GVG_089:
                    return new Sim_GVG_089();
                case CardDB.cardIDEnum.GVG_090:
                    return new Sim_GVG_090();
                case CardDB.cardIDEnum.GVG_091:
                    return new Sim_GVG_091();
                case CardDB.cardIDEnum.GVG_092:
                    return new Sim_GVG_092();
                case CardDB.cardIDEnum.GVG_093:
                    return new Sim_GVG_093();
                case CardDB.cardIDEnum.GVG_094:
                    return new Sim_GVG_094();
                case CardDB.cardIDEnum.GVG_095:
                    return new Sim_GVG_095();
                case CardDB.cardIDEnum.GVG_096:
                    return new Sim_GVG_096();
                case CardDB.cardIDEnum.GVG_097:
                    return new Sim_GVG_097();
                case CardDB.cardIDEnum.GVG_098:
                    return new Sim_GVG_098();
                case CardDB.cardIDEnum.GVG_099:
                    return new Sim_GVG_099();
                case CardDB.cardIDEnum.GVG_100:
                    return new Sim_GVG_100();
                case CardDB.cardIDEnum.GVG_101:
                    return new Sim_GVG_101();
                case CardDB.cardIDEnum.GVG_102:
                    return new Sim_GVG_102();
                case CardDB.cardIDEnum.GVG_103:
                    return new Sim_GVG_103();
                case CardDB.cardIDEnum.GVG_104:
                    return new Sim_GVG_104();
                case CardDB.cardIDEnum.GVG_105:
                    return new Sim_GVG_105();
                case CardDB.cardIDEnum.GVG_106:
                    return new Sim_GVG_106();
                case CardDB.cardIDEnum.GVG_107:
                    return new Sim_GVG_107();
                case CardDB.cardIDEnum.GVG_108:
                    return new Sim_GVG_108();
                case CardDB.cardIDEnum.GVG_109:
                    return new Sim_GVG_109();
                case CardDB.cardIDEnum.GVG_110:
                    return new Sim_GVG_110();
                case CardDB.cardIDEnum.GVG_110t:
                    return new Sim_GVG_110t();
                case CardDB.cardIDEnum.GVG_111:
                    return new Sim_GVG_111();
                case CardDB.cardIDEnum.GVG_111t:
                    return new Sim_GVG_111t();
                case CardDB.cardIDEnum.GVG_112:
                    return new Sim_GVG_112();
                case CardDB.cardIDEnum.GVG_113:
                    return new Sim_GVG_113();
                case CardDB.cardIDEnum.GVG_114:
                    return new Sim_GVG_114();
                case CardDB.cardIDEnum.GVG_115:
                    return new Sim_GVG_115();
                case CardDB.cardIDEnum.GVG_116:
                    return new Sim_GVG_116();
                case CardDB.cardIDEnum.GVG_117:
                    return new Sim_GVG_117();
                case CardDB.cardIDEnum.GVG_118:
                    return new Sim_GVG_118();
                case CardDB.cardIDEnum.GVG_119:
                    return new Sim_GVG_119();
                case CardDB.cardIDEnum.GVG_120:
                    return new Sim_GVG_120();
                case CardDB.cardIDEnum.GVG_121:
                    return new Sim_GVG_121();
                case CardDB.cardIDEnum.GVG_122:
                    return new Sim_GVG_122();
                case CardDB.cardIDEnum.GVG_123:
                    return new Sim_GVG_123();
                case CardDB.cardIDEnum.PART_001:
                    return new Sim_PART_001();
                case CardDB.cardIDEnum.PART_002:
                    return new Sim_PART_002();
                case CardDB.cardIDEnum.PART_003:
                    return new Sim_PART_003();
                case CardDB.cardIDEnum.PART_004:
                    return new Sim_PART_004();
                case CardDB.cardIDEnum.PART_005:
                    return new Sim_PART_005();
                case CardDB.cardIDEnum.PART_006:
                    return new Sim_PART_006();
                case CardDB.cardIDEnum.PART_007:
                    return new Sim_PART_007();
                case cardIDEnum.NAX1_05:
                    return new Sim_NAX1_05();
                case cardIDEnum.NAX11_04:
                    return new Sim_NAX11_04();
                case cardIDEnum.NAX14_04:
                    return new Sim_NAX14_04();
                case cardIDEnum.NAX15_02:
                    return new Sim_NAX15_02();
                case cardIDEnum.NAX15_02H:
                    return new Sim_NAX15_02H();
                case cardIDEnum.NAX2_03:
                    return new Sim_NAX2_03();
                case cardIDEnum.NAX2_03H:
                    return new Sim_NAX2_03H();
                case cardIDEnum.NAX5_03:
                    return new Sim_NAX5_03();
                case cardIDEnum.NAX6_03t:
                    return new Sim_NAX6_03t();
                case cardIDEnum.NAX8_02:
                    return new Sim_NAX8_02();
                case cardIDEnum.NAX8_02H:
                    return new Sim_NAX8_02H();
                case cardIDEnum.NAX8_03:
                    return new Sim_NAX8_03();
                case cardIDEnum.NAX8_03t:
                    return new Sim_NAX8_03t();
                case cardIDEnum.NAX8_04:
                    return new Sim_NAX8_04();
                case cardIDEnum.NAX8_04t:
                    return new Sim_NAX8_04t();
                case cardIDEnum.NAX8_05:
                    return new Sim_NAX8_05();
                case cardIDEnum.NAX8_05t:
                    return new Sim_NAX8_05t();
                case cardIDEnum.NAXM_001:
                    return new Sim_NAXM_001();
                case cardIDEnum.BRMA09_6:
                    return new Sim_BRMA09_6();
                case cardIDEnum.BRM_001:
                    return new Sim_BRM_001();
                case cardIDEnum.BRM_002:
                    return new Sim_BRM_002();
                case cardIDEnum.BRM_003:
                    return new Sim_BRM_003();
                case cardIDEnum.BRM_004:
                    return new Sim_BRM_004();
                case cardIDEnum.BRM_004t:
                    return new Sim_BRM_004t();
                case cardIDEnum.BRM_005:
                    return new Sim_BRM_005();
                case cardIDEnum.BRM_006:
                    return new Sim_BRM_006();
                case cardIDEnum.BRM_006t:
                    return new Sim_BRM_006t();
                case cardIDEnum.BRM_007:
                    return new Sim_BRM_007();
                case cardIDEnum.BRM_008:
                    return new Sim_BRM_008();
                case cardIDEnum.BRM_009:
                    return new Sim_BRM_009();
                case cardIDEnum.BRM_010:
                    return new Sim_BRM_010();
                case cardIDEnum.BRM_010a:
                    return new Sim_BRM_010a();
                case cardIDEnum.BRM_010b:
                    return new Sim_BRM_010b();
                case cardIDEnum.BRM_010t:
                    return new Sim_BRM_010t();
                case cardIDEnum.BRM_010t2:
                    return new Sim_BRM_010t2();
                case cardIDEnum.BRM_011:
                    return new Sim_BRM_011();
                case cardIDEnum.BRM_012:
                    return new Sim_BRM_012();
                case cardIDEnum.BRM_013:
                    return new Sim_BRM_013();
                case cardIDEnum.BRM_014:
                    return new Sim_BRM_014();
                case cardIDEnum.BRM_015:
                    return new Sim_BRM_015();
                case cardIDEnum.BRM_016:
                    return new Sim_BRM_016();
                case cardIDEnum.BRM_017:
                    return new Sim_BRM_017();
                case cardIDEnum.BRM_018:
                    return new Sim_BRM_018();
                case cardIDEnum.BRM_019:
                    return new Sim_BRM_019();
                case cardIDEnum.BRM_020:
                    return new Sim_BRM_020();
                case cardIDEnum.BRM_022:
                    return new Sim_BRM_022();
                case cardIDEnum.BRM_022t:
                    return new Sim_BRM_022t();
                case cardIDEnum.BRM_024:
                    return new Sim_BRM_024();
                case cardIDEnum.BRM_025:
                    return new Sim_BRM_025();
                case cardIDEnum.BRM_026:
                    return new Sim_BRM_026();
                case cardIDEnum.BRM_027:
                    return new Sim_BRM_027();
                case cardIDEnum.BRM_027p:
                    return new Sim_BRM_027p();
                case cardIDEnum.BRM_028:
                    return new Sim_BRM_028();
                case cardIDEnum.BRM_029:
                    return new Sim_BRM_029();
                case cardIDEnum.BRM_030:
                    return new Sim_BRM_030();
                case cardIDEnum.BRM_031:
                    return new Sim_BRM_031();
                case cardIDEnum.BRM_033:
                    return new Sim_BRM_033();
                case cardIDEnum.BRM_034:
                    return new Sim_BRM_034();

                case cardIDEnum.BRMA01_2:
                    return new Sim_BRMA01_2();
                case cardIDEnum.BRMA01_2H:
                    return new Sim_BRMA01_2H();
                case cardIDEnum.BRMA02_2:
                    return new Sim_BRMA02_2();
                case cardIDEnum.BRMA02_2H:
                    return new Sim_BRMA02_2H();
                case cardIDEnum.BRMA02_2t:
                    return new Sim_BRMA02_2t();
                case cardIDEnum.BRMA04_2:
                    return new Sim_BRMA04_2();
                case cardIDEnum.BRMA06_2:
                    return new Sim_BRMA06_2();
                case cardIDEnum.BRMA06_2H:
                    return new Sim_BRMA06_2H();
                case cardIDEnum.BRMA06_4:
                    return new Sim_BRMA06_4();
                case cardIDEnum.BRMA06_4H:
                    return new Sim_BRMA06_4H();
                case cardIDEnum.BRMA07_2:
                    return new Sim_BRMA07_2();
                case cardIDEnum.BRMA07_2H:
                    return new Sim_BRMA07_2H();
                case cardIDEnum.BRMA09_2:
                    return new Sim_BRMA09_2();
                case cardIDEnum.BRMA09_2H:
                    return new Sim_BRMA09_2H();
                case cardIDEnum.BRMA09_2Ht:
                    return new Sim_BRMA09_2Ht();
                case cardIDEnum.BRMA09_2t:
                    return new Sim_BRMA09_2t();
                case cardIDEnum.BRMA13_4:
                    return new Sim_BRMA13_4();
                case cardIDEnum.BRMA13_4H:
                    return new Sim_BRMA13_4H();
                case cardIDEnum.BRMA14_10:
                    return new Sim_BRMA14_10();
                case cardIDEnum.BRMA14_10H:
                    return new Sim_BRMA14_10H();
                case cardIDEnum.BRMA14_5:
                    return new Sim_BRMA14_5();
                case cardIDEnum.BRMA14_5H:
                    return new Sim_BRMA14_5H();
                case cardIDEnum.BRMA17_5:
                    return new Sim_BRMA17_5();
                case cardIDEnum.BRMA17_5H:
                    return new Sim_BRMA17_5H();
                case cardIDEnum.BRMA17_6:
                    return new Sim_BRMA17_6();
                case cardIDEnum.BRMA17_6H:
                    return new Sim_BRMA17_6H();
                case cardIDEnum.BRMC_94:
                    return new Sim_BRMC_94();
                case cardIDEnum.CS2_034_H1_AT_132:
                    return new Sim_CS2_034_H1_AT_132();
                case cardIDEnum.DS1h_292_H1_AT_132:
                    return new Sim_DS1h_292_H1_AT_132();
                case cardIDEnum.NAX10_02:
                    return new Sim_NAX10_02();
                case cardIDEnum.NAX10_02H:
                    return new Sim_NAX10_02H();
                case cardIDEnum.NAX10_03:
                    return new Sim_NAX10_03();
                case cardIDEnum.NAX10_03H:
                    return new Sim_NAX10_03H();
                case cardIDEnum.NAX11_02:
                    return new Sim_NAX11_02();
                case cardIDEnum.NAX11_02H:
                    return new Sim_NAX11_02H();
                case cardIDEnum.NAX11_03:
                    return new Sim_NAX11_03();
                case cardIDEnum.NAX12_02:
                    return new Sim_NAX12_02();
                case cardIDEnum.NAX12_02H:
                    return new Sim_NAX12_02H();
                case cardIDEnum.NAX12_03:
                    return new Sim_NAX12_03();
                case cardIDEnum.NAX12_03H:
                    return new Sim_NAX12_03H();
                case cardIDEnum.NAX12_04:
                    return new Sim_NAX12_04();
                case cardIDEnum.NAX13_02:
                    return new Sim_NAX13_02();
                case cardIDEnum.NAX13_03:
                    return new Sim_NAX13_03();
                case cardIDEnum.NAX13_04H:
                    return new Sim_NAX13_04H();
                case cardIDEnum.NAX13_05H:
                    return new Sim_NAX13_05H();
                case cardIDEnum.NAX14_02:
                    return new Sim_NAX14_02();
                case cardIDEnum.NAX14_03:
                    return new Sim_NAX14_03();
                case cardIDEnum.NAX15_03n:
                    return new Sim_NAX15_03n();
                case cardIDEnum.NAX15_03t:
                    return new Sim_NAX15_03t();
                case cardIDEnum.NAX15_04:
                    return new Sim_NAX15_04();
                case cardIDEnum.NAX15_04H:
                    return new Sim_NAX15_04H();
                case cardIDEnum.NAX15_05:
                    return new Sim_NAX15_05();
                case cardIDEnum.NAX1h_03:
                    return new Sim_NAX1h_03();
                case cardIDEnum.NAX1h_04:
                    return new Sim_NAX1h_04();
                case cardIDEnum.NAX1_03:
                    return new Sim_NAX1_03();
                case cardIDEnum.NAX1_04:
                    return new Sim_NAX1_04();
                case cardIDEnum.NAX2_05:
                    return new Sim_NAX2_05();
                case cardIDEnum.NAX2_05H:
                    return new Sim_NAX2_05H();
                case cardIDEnum.NAX3_02:
                    return new Sim_NAX3_02();
                case cardIDEnum.NAX3_02H:
                    return new Sim_NAX3_02H();
                case cardIDEnum.NAX3_03:
                    return new Sim_NAX3_03();
                case cardIDEnum.NAX4_03:
                    return new Sim_NAX4_03();
                case cardIDEnum.NAX4_03H:
                    return new Sim_NAX4_03H();
                case cardIDEnum.NAX4_04:
                    return new Sim_NAX4_04();
                case cardIDEnum.NAX4_04H:
                    return new Sim_NAX4_04H();
                case cardIDEnum.NAX4_05:
                    return new Sim_NAX4_05();
                case cardIDEnum.NAX5_02:
                    return new Sim_NAX5_02();
                case cardIDEnum.NAX5_02H:
                    return new Sim_NAX5_02H();
                case cardIDEnum.NAX6_02:
                    return new Sim_NAX6_02();
                case cardIDEnum.NAX6_02H:
                    return new Sim_NAX6_02H();
                case cardIDEnum.NAX6_03:
                    return new Sim_NAX6_03();
                case cardIDEnum.NAX6_04:
                    return new Sim_NAX6_04();
                case cardIDEnum.NAX7_02:
                    return new Sim_NAX7_02();
                case cardIDEnum.NAX7_03:
                    return new Sim_NAX7_03();
                case cardIDEnum.NAX7_03H:
                    return new Sim_NAX7_03H();
                case cardIDEnum.NAX7_04:
                    return new Sim_NAX7_04();
                case cardIDEnum.NAX7_04H:
                    return new Sim_NAX7_04H();
                case cardIDEnum.NAX7_05:
                    return new Sim_NAX7_05();
                case cardIDEnum.NAX9_02:
                    return new Sim_NAX9_02();
                case cardIDEnum.NAX9_02H:
                    return new Sim_NAX9_02H();
                case cardIDEnum.NAX9_03:
                    return new Sim_NAX9_03();
                case cardIDEnum.NAX9_03H:
                    return new Sim_NAX9_03H();
                case cardIDEnum.NAX9_04:
                    return new Sim_NAX9_04();
                case cardIDEnum.NAX9_04H:
                    return new Sim_NAX9_04H();
                case cardIDEnum.NAX9_05:
                    return new Sim_NAX9_05();
                case cardIDEnum.NAX9_05H:
                    return new Sim_NAX9_05H();
                case cardIDEnum.NAX9_06:
                    return new Sim_NAX9_06();
                case cardIDEnum.NAX9_07:
                    return new Sim_NAX9_07();
                case cardIDEnum.NAXM_002:
                    return new Sim_NAXM_002();
                case cardIDEnum.TB_007:
                    return new Sim_TB_007();
                case cardIDEnum.TU4d_003:
                    return new Sim_TU4d_003();
                case cardIDEnum.TU4f_004:
                    return new Sim_TU4f_004();
                case cardIDEnum.BRMA12_3:
                    return new Sim_BRMA12_3();
                case cardIDEnum.BRMA12_3H:
                    return new Sim_BRMA12_3H();
                case cardIDEnum.BRMA12_4:
                    return new Sim_BRMA12_4();
                case cardIDEnum.BRMA12_4H:
                    return new Sim_BRMA12_4H();
                case cardIDEnum.LOE_002:
                    return new Sim_LOE_002();
                case cardIDEnum.LOE_002t:
                    return new Sim_LOE_002t();
                case cardIDEnum.LOE_003:
                    return new Sim_LOE_003();
                case cardIDEnum.LOE_006:
                    return new Sim_LOE_006();
                case cardIDEnum.LOE_007:
                    return new Sim_LOE_007();
                case cardIDEnum.LOE_007t:
                    return new Sim_LOE_007t();
                case cardIDEnum.LOE_009:
                    return new Sim_LOE_009();
                case cardIDEnum.LOE_010:
                    return new Sim_LOE_010();
                case cardIDEnum.LOE_011:
                    return new Sim_LOE_011();
                case cardIDEnum.LOE_012:
                    return new Sim_LOE_012();
                case cardIDEnum.LOE_016:
                    return new Sim_LOE_016();
                case cardIDEnum.LOE_017:
                    return new Sim_LOE_017();
                case cardIDEnum.LOE_018:
                    return new Sim_LOE_018();
                case cardIDEnum.LOE_019t:
                    return new Sim_LOE_019t();
                case cardIDEnum.LOE_019t2:
                    return new Sim_LOE_019t2();
                case cardIDEnum.LOE_020:
                    return new Sim_LOE_020();
                case cardIDEnum.LOE_021:
                    return new Sim_LOE_021();
                case cardIDEnum.LOE_022:
                    return new Sim_LOE_022();
                case cardIDEnum.LOE_023:
                    return new Sim_LOE_023();
                case cardIDEnum.LOE_026:
                    return new Sim_LOE_026();
                case cardIDEnum.LOE_027:
                    return new Sim_LOE_027();
                case cardIDEnum.LOE_029:
                    return new Sim_LOE_029();
                case cardIDEnum.LOE_039:
                    return new Sim_LOE_039();
                case cardIDEnum.LOE_046:
                    return new Sim_LOE_046();
                case cardIDEnum.LOE_047:
                    return new Sim_LOE_047();
                case cardIDEnum.LOE_050:
                    return new Sim_LOE_050();
                case cardIDEnum.LOE_051:
                    return new Sim_LOE_051();
                case cardIDEnum.LOE_053:
                    return new Sim_LOE_053();
                case cardIDEnum.LOE_061:
                    return new Sim_LOE_061();
                case cardIDEnum.LOE_073:
                    return new Sim_LOE_073();
                case cardIDEnum.LOE_076:
                    return new Sim_LOE_076();
                case cardIDEnum.LOE_077:
                    return new Sim_LOE_077();
                case cardIDEnum.LOE_079:
                    return new Sim_LOE_079();
                case cardIDEnum.LOE_086:
                    return new Sim_LOE_086();
                case cardIDEnum.LOE_089:
                    return new Sim_LOE_089();
                case cardIDEnum.LOE_092:
                    return new Sim_LOE_092();
                case cardIDEnum.LOE_104:
                    return new Sim_LOE_104();
                case cardIDEnum.LOE_105:
                    return new Sim_LOE_105();
                case cardIDEnum.LOE_107:
                    return new Sim_LOE_107();
                case cardIDEnum.LOE_110:
                    return new Sim_LOE_110();
                case cardIDEnum.LOE_110t:
                    return new Sim_LOE_110t();
                case cardIDEnum.LOE_111:
                    return new Sim_LOE_111();
                case cardIDEnum.LOE_113:
                    return new Sim_LOE_113();
                case cardIDEnum.LOE_115:
                    return new Sim_LOE_115();
                case cardIDEnum.LOE_116:
                    return new Sim_LOE_116();
                case cardIDEnum.LOE_118:
                    return new Sim_LOE_118();
                case cardIDEnum.LOE_119:
                    return new Sim_LOE_119();
                case cardIDEnum.LOEA10_3:
                    return new Sim_LOEA10_3();
                case cardIDEnum.LOEA16_3:
                    return new Sim_LOEA16_3();
                case cardIDEnum.LOEA16_4:
                    return new Sim_LOEA16_4();
                case cardIDEnum.LOEA16_5:
                    return new Sim_LOEA16_5();
                case cardIDEnum.OG_006:
                    return new Sim_OG_006();
                case cardIDEnum.OG_006a:
                    return new Sim_OG_006a();
                case cardIDEnum.OG_006b:
                    return new Sim_OG_006b();
                case cardIDEnum.OG_023:
                    return new Sim_OG_023();
                case cardIDEnum.OG_024:
                    return new Sim_OG_024();
                case cardIDEnum.OG_026:
                    return new Sim_OG_026();
                case cardIDEnum.OG_027:
                    return new Sim_OG_027();
                case cardIDEnum.OG_031:
                    return new Sim_OG_031();
                case cardIDEnum.OG_031a:
                    return new Sim_OG_031a();
                case cardIDEnum.OG_033:
                    return new Sim_OG_033();
                case cardIDEnum.OG_042:
                    return new Sim_OG_042();
                case cardIDEnum.OG_044:
                    return new Sim_OG_044();
                case cardIDEnum.OG_045:
                    return new Sim_OG_045();
                case cardIDEnum.OG_047:
                    return new Sim_OG_047();
                case cardIDEnum.OG_048:
                    return new Sim_OG_048();
                case cardIDEnum.OG_051:
                    return new Sim_OG_051();
                case cardIDEnum.OG_058:
                    return new Sim_OG_058();
                case cardIDEnum.OG_061:
                    return new Sim_OG_061();
                case cardIDEnum.OG_070:
                    return new Sim_OG_070();
                case cardIDEnum.OG_072:
                    return new Sim_OG_072();
                case cardIDEnum.OG_073:
                    return new Sim_OG_073();
                case cardIDEnum.OG_080:
                    return new Sim_OG_080();
                case cardIDEnum.OG_080b:
                    return new Sim_OG_080b();
                case cardIDEnum.OG_080c:
                    return new Sim_OG_080c();
                case cardIDEnum.OG_080d:
                    return new Sim_OG_080d();
                case cardIDEnum.OG_080e:
                    return new Sim_OG_080e();
                case cardIDEnum.OG_080f:
                    return new Sim_OG_080f();
                case cardIDEnum.OG_081:
                    return new Sim_OG_081();
                case cardIDEnum.OG_082:
                    return new Sim_OG_082();
                case cardIDEnum.OG_083:
                    return new Sim_OG_083();
                case cardIDEnum.OG_085:
                    return new Sim_OG_085();
                case cardIDEnum.OG_086:
                    return new Sim_OG_086();
                case cardIDEnum.OG_090:
                    return new Sim_OG_090();
                case cardIDEnum.OG_094:
                    return new Sim_OG_094();
                case cardIDEnum.OG_096:
                    return new Sim_OG_096();
                case cardIDEnum.OG_100:
                    return new Sim_OG_100();
                case cardIDEnum.OG_101:
                    return new Sim_OG_101();
                case cardIDEnum.OG_102:
                    return new Sim_OG_102();
                case cardIDEnum.OG_104:
                    return new Sim_OG_104();
                case cardIDEnum.OG_109:
                    return new Sim_OG_109();
                case cardIDEnum.OG_113:
                    return new Sim_OG_113();
                case cardIDEnum.OG_114:
                    return new Sim_OG_114();
                case cardIDEnum.OG_116:
                    return new Sim_OG_116();
                case cardIDEnum.OG_118:
                    return new Sim_OG_118();
                case cardIDEnum.OG_120:
                    return new Sim_OG_120();
                case cardIDEnum.OG_121:
                    return new Sim_OG_121();
                case cardIDEnum.OG_122:
                    return new Sim_OG_122();
                case cardIDEnum.OG_123:
                    return new Sim_OG_123();
                case cardIDEnum.OG_131:
                    return new Sim_OG_131();
                case cardIDEnum.OG_133:
                    return new Sim_OG_133();
                case cardIDEnum.OG_134:
                    return new Sim_OG_134();
                case cardIDEnum.OG_141:
                    return new Sim_OG_141();
                case cardIDEnum.OG_142:
                    return new Sim_OG_142();
                case cardIDEnum.OG_145:
                    return new Sim_OG_145();
                case cardIDEnum.OG_147:
                    return new Sim_OG_147();
                case cardIDEnum.OG_149:
                    return new Sim_OG_149();
                case cardIDEnum.OG_150:
                    return new Sim_OG_150();
                case cardIDEnum.OG_151:
                    return new Sim_OG_151();
                case cardIDEnum.OG_152:
                    return new Sim_OG_152();
                case cardIDEnum.OG_153:
                    return new Sim_OG_153();
                case cardIDEnum.OG_156:
                    return new Sim_OG_156();
                case cardIDEnum.OG_158:
                    return new Sim_OG_158();
                case cardIDEnum.OG_161:
                    return new Sim_OG_161();
                case cardIDEnum.OG_162:
                    return new Sim_OG_162();
                case cardIDEnum.OG_173:
                    return new Sim_OG_173();
                case cardIDEnum.OG_173a:
                    return new Sim_OG_173a();
                case cardIDEnum.OG_174:
                    return new Sim_OG_174();
                case cardIDEnum.OG_176:
                    return new Sim_OG_176();
                case cardIDEnum.OG_179:
                    return new Sim_OG_179();
                case cardIDEnum.OG_188:
                    return new Sim_OG_188();
                case cardIDEnum.OG_195:
                    return new Sim_OG_195();
                case cardIDEnum.OG_195b:
                    return new Sim_OG_195b();
                case cardIDEnum.OG_198:
                    return new Sim_OG_198();
                case cardIDEnum.OG_200:
                    return new Sim_OG_200();
                case cardIDEnum.OG_202:
                    return new Sim_OG_202();
                case cardIDEnum.OG_206:
                    return new Sim_OG_206();
                case cardIDEnum.OG_207:
                    return new Sim_OG_207();
                case cardIDEnum.OG_209:
                    return new Sim_OG_209();
                case cardIDEnum.OG_211:
                    return new Sim_OG_211();
                case cardIDEnum.OG_216:
                    return new Sim_OG_216();
                case cardIDEnum.OG_218:
                    return new Sim_OG_218();
                case cardIDEnum.OG_220:
                    return new Sim_OG_220();
                case cardIDEnum.OG_221:
                    return new Sim_OG_221();
                case cardIDEnum.OG_222:
                    return new Sim_OG_222();
                case cardIDEnum.OG_223:
                    return new Sim_OG_223();
                case cardIDEnum.OG_229:
                    return new Sim_OG_229();
                case cardIDEnum.OG_234:
                    return new Sim_OG_234();
                case cardIDEnum.OG_239:
                    return new Sim_OG_239();
                case cardIDEnum.OG_241:
                    return new Sim_OG_241();
                case cardIDEnum.OG_241a:
                    return new Sim_OG_241a();
                case cardIDEnum.OG_247:
                    return new Sim_OG_247();
                case cardIDEnum.OG_248:
                    return new Sim_OG_248();
                case cardIDEnum.OG_249:
                    return new Sim_OG_249();
                case cardIDEnum.OG_249a:
                    return new Sim_OG_249a();
                case cardIDEnum.OG_254:
                    return new Sim_OG_254();
                case cardIDEnum.OG_255:
                    return new Sim_OG_255();
                case cardIDEnum.OG_256:
                    return new Sim_OG_256();
                case cardIDEnum.OG_267:
                    return new Sim_OG_267();
                case cardIDEnum.OG_271:
                    return new Sim_OG_271();
                case cardIDEnum.OG_272:
                    return new Sim_OG_272();
                case cardIDEnum.OG_273:
                    return new Sim_OG_273();
                case cardIDEnum.OG_276:
                    return new Sim_OG_276();
                case cardIDEnum.OG_280:
                    return new Sim_OG_280();
                case cardIDEnum.OG_281:
                    return new Sim_OG_281();
                case cardIDEnum.OG_282:
                    return new Sim_OG_282();
                case cardIDEnum.OG_283:
                    return new Sim_OG_283();
                case cardIDEnum.OG_284:
                    return new Sim_OG_284();
                case cardIDEnum.OG_286:
                    return new Sim_OG_286();
                case cardIDEnum.OG_290:
                    return new Sim_OG_290();
                case cardIDEnum.OG_291:
                    return new Sim_OG_291();
                case cardIDEnum.OG_292:
                    return new Sim_OG_292();
                case cardIDEnum.OG_293:
                    return new Sim_OG_293();
                case cardIDEnum.OG_295:
                    return new Sim_OG_295();
                case cardIDEnum.OG_300:
                    return new Sim_OG_300();
                case cardIDEnum.OG_301:
                    return new Sim_OG_301();
                case cardIDEnum.OG_302:
                    return new Sim_OG_302();
                case cardIDEnum.OG_303:
                    return new Sim_OG_303();
                case cardIDEnum.OG_308:
                    return new Sim_OG_308();
                case cardIDEnum.OG_309:
                    return new Sim_OG_309();
                case cardIDEnum.OG_310:
                    return new Sim_OG_310();
                case cardIDEnum.OG_311:
                    return new Sim_OG_311();
                case cardIDEnum.OG_312:
                    return new Sim_OG_312();
                case cardIDEnum.OG_313:
                    return new Sim_OG_313();
                case cardIDEnum.OG_314:
                    return new Sim_OG_314();
                case cardIDEnum.OG_315:
                    return new Sim_OG_315();
                case cardIDEnum.OG_316:
                    return new Sim_OG_316();
                case cardIDEnum.OG_317:
                    return new Sim_OG_317();
                case cardIDEnum.OG_318:
                    return new Sim_OG_318();
                case cardIDEnum.OG_319:
                    return new Sim_OG_319();
                case cardIDEnum.OG_320:
                    return new Sim_OG_320();
                case cardIDEnum.OG_321:
                    return new Sim_OG_321();
                case cardIDEnum.OG_322:
                    return new Sim_OG_322();
                case cardIDEnum.OG_323:
                    return new Sim_OG_323();
                case cardIDEnum.OG_325:
                    return new Sim_OG_325();
                case cardIDEnum.OG_326:
                    return new Sim_OG_326();
                case cardIDEnum.OG_327:
                    return new Sim_OG_327();
                case cardIDEnum.OG_328:
                    return new Sim_OG_328();
                case cardIDEnum.OG_330:
                    return new Sim_OG_330();
                case cardIDEnum.OG_334:
                    return new Sim_OG_334();
                case cardIDEnum.OG_335:
                    return new Sim_OG_335();
                case cardIDEnum.OG_337:
                    return new Sim_OG_337();
                case cardIDEnum.OG_339:
                    return new Sim_OG_339();
                case cardIDEnum.OG_340:
                    return new Sim_OG_340();

                case cardIDEnum.KAR_004:
                    return new Sim_KAR_004();
                case cardIDEnum.KAR_005:
                    return new Sim_KAR_005();
                case cardIDEnum.KAR_005a:
                    return new Sim_KAR_005a();
                case cardIDEnum.KAR_006:
                    return new Sim_KAR_006();
                case cardIDEnum.KAR_009:
                    return new Sim_KAR_009();
                case cardIDEnum.KAR_010:
                    return new Sim_KAR_010();
                case cardIDEnum.KAR_011:
                    return new Sim_KAR_011();
                case cardIDEnum.KAR_013:
                    return new Sim_KAR_013();
                case cardIDEnum.KAR_021:
                    return new Sim_KAR_021();
                case cardIDEnum.KAR_025:
                    return new Sim_KAR_025();
                case cardIDEnum.KAR_026:
                    return new Sim_KAR_026();
                case cardIDEnum.KAR_028:
                    return new Sim_KAR_028();
                case cardIDEnum.KAR_029:
                    return new Sim_KAR_029();
                case cardIDEnum.KAR_030a:
                    return new Sim_KAR_030a();
                case cardIDEnum.KAR_033:
                    return new Sim_KAR_033();
                case cardIDEnum.KAR_035:
                    return new Sim_KAR_035();
                case cardIDEnum.KAR_036:
                    return new Sim_KAR_036();
                case cardIDEnum.KAR_037:
                    return new Sim_KAR_037();
                case cardIDEnum.KAR_041:
                    return new Sim_KAR_041();
                case cardIDEnum.KAR_044:
                    return new Sim_KAR_044();
                case cardIDEnum.KAR_057:
                    return new Sim_KAR_057();
                case cardIDEnum.KAR_061:
                    return new Sim_KAR_061();
                case cardIDEnum.KAR_062:
                    return new Sim_KAR_062();
                case cardIDEnum.KAR_063:
                    return new Sim_KAR_063();
                case cardIDEnum.KAR_065:
                    return new Sim_KAR_065();
                case cardIDEnum.KAR_069:
                    return new Sim_KAR_069();
                case cardIDEnum.KAR_070:
                    return new Sim_KAR_070();
                case cardIDEnum.KAR_073:
                    return new Sim_KAR_073();
                case cardIDEnum.KAR_075:
                    return new Sim_KAR_075();
                case cardIDEnum.KAR_076:
                    return new Sim_KAR_076();
                case cardIDEnum.KAR_077:
                    return new Sim_KAR_077();
                case cardIDEnum.KAR_089:
                    return new Sim_KAR_089();
                case cardIDEnum.KAR_091:
                    return new Sim_KAR_091();
                case cardIDEnum.KAR_092:
                    return new Sim_KAR_092();
                case cardIDEnum.KAR_094:
                    return new Sim_KAR_094();
                case cardIDEnum.KAR_095:
                    return new Sim_KAR_095();
                case cardIDEnum.KAR_096:
                    return new Sim_KAR_096();
                case cardIDEnum.KAR_097:
                    return new Sim_KAR_097();
                case cardIDEnum.KAR_097t:
                    return new Sim_KAR_097t();
                case cardIDEnum.KAR_114:
                    return new Sim_KAR_114();
                case cardIDEnum.KAR_204:
                    return new Sim_KAR_204();
                case cardIDEnum.KAR_205:
                    return new Sim_KAR_205();
                case cardIDEnum.KAR_300:
                    return new Sim_KAR_300();
                case cardIDEnum.KAR_702:
                    return new Sim_KAR_702();
                case cardIDEnum.KAR_710:
                    return new Sim_KAR_710();
                case cardIDEnum.KAR_711:
                    return new Sim_KAR_711();
                case cardIDEnum.KAR_712:
                    return new Sim_KAR_712();
                case cardIDEnum.UNG_001:
                    return new Sim_UNG_001();
                case cardIDEnum.UNG_002:
                    return new Sim_UNG_002();
                case cardIDEnum.UNG_004:
                    return new Sim_UNG_004();
                case cardIDEnum.UNG_009:
                    return new Sim_UNG_009();
                case cardIDEnum.UNG_010:
                    return new Sim_UNG_010();
                case cardIDEnum.UNG_011:
                    return new Sim_UNG_011();
                case cardIDEnum.UNG_015:
                    return new Sim_UNG_015();
                case cardIDEnum.UNG_018:
                    return new Sim_UNG_018();
                case cardIDEnum.UNG_019:
                    return new Sim_UNG_019();
                case cardIDEnum.UNG_020:
                    return new Sim_UNG_020();
                case cardIDEnum.UNG_021:
                    return new Sim_UNG_021();
                case cardIDEnum.UNG_022:
                    return new Sim_UNG_022();
                case cardIDEnum.UNG_024:
                    return new Sim_UNG_024();
                case cardIDEnum.UNG_025:
                    return new Sim_UNG_025();
                case cardIDEnum.UNG_027:
                    return new Sim_UNG_027();
                case cardIDEnum.UNG_027t2:
                    return new Sim_UNG_027t2();
                case cardIDEnum.UNG_027t4:
                    return new Sim_UNG_027t4();
                case cardIDEnum.UNG_028:
                    return new Sim_UNG_028();
                case cardIDEnum.UNG_028t:
                    return new Sim_UNG_028t();
                case cardIDEnum.UNG_029:
                    return new Sim_UNG_029();
                case cardIDEnum.UNG_030:
                    return new Sim_UNG_030();
                case cardIDEnum.UNG_032:
                    return new Sim_UNG_032();
                case cardIDEnum.UNG_034:
                    return new Sim_UNG_034();
                case cardIDEnum.UNG_035:
                    return new Sim_UNG_035();
                case cardIDEnum.UNG_037:
                    return new Sim_UNG_037();
                case cardIDEnum.UNG_047:
                    return new Sim_UNG_047();
                case cardIDEnum.UNG_049:
                    return new Sim_UNG_049();
                case cardIDEnum.UNG_057:
                    return new Sim_UNG_057();
                case cardIDEnum.UNG_057t1:
                    return new Sim_UNG_057t1();
                case cardIDEnum.UNG_058:
                    return new Sim_UNG_058();
                case cardIDEnum.UNG_060:
                    return new Sim_UNG_060();
                case cardIDEnum.UNG_061:
                    return new Sim_UNG_061();
                case cardIDEnum.UNG_063:
                    return new Sim_UNG_063();
                case cardIDEnum.UNG_064:
                    return new Sim_UNG_064();
                case cardIDEnum.UNG_065:
                    return new Sim_UNG_065();
                case cardIDEnum.UNG_065t:
                    return new Sim_UNG_065t();
                case cardIDEnum.UNG_067:
                    return new Sim_UNG_067();
                case cardIDEnum.UNG_067t1:
                    return new Sim_UNG_067t1();
                case cardIDEnum.UNG_070:
                    return new Sim_UNG_070();
                case cardIDEnum.UNG_071:
                    return new Sim_UNG_071();
                case cardIDEnum.UNG_072:
                    return new Sim_UNG_072();
                case cardIDEnum.UNG_073:
                    return new Sim_UNG_073();
                case cardIDEnum.UNG_075:
                    return new Sim_UNG_075();
                case cardIDEnum.UNG_076:
                    return new Sim_UNG_076();
                case cardIDEnum.UNG_076t1:
                    return new Sim_UNG_076t1();
                case cardIDEnum.UNG_078:
                    return new Sim_UNG_078();
                case cardIDEnum.UNG_079:
                    return new Sim_UNG_079();
                case cardIDEnum.UNG_082:
                    return new Sim_UNG_082();
                case cardIDEnum.UNG_083:
                    return new Sim_UNG_083();
                case cardIDEnum.UNG_083t1:
                    return new Sim_UNG_083t1();
                case cardIDEnum.UNG_084:
                    return new Sim_UNG_084();
                case cardIDEnum.UNG_085:
                    return new Sim_UNG_085();
                case cardIDEnum.UNG_086:
                    return new Sim_UNG_086();
                case cardIDEnum.UNG_087:
                    return new Sim_UNG_087();
                case cardIDEnum.UNG_088:
                    return new Sim_UNG_088();
                case cardIDEnum.UNG_089:
                    return new Sim_UNG_089();
                case cardIDEnum.UNG_099:
                    return new Sim_UNG_099();
                case cardIDEnum.UNG_100:
                    return new Sim_UNG_100();
                case cardIDEnum.UNG_101:
                    return new Sim_UNG_101();
                case cardIDEnum.UNG_103:
                    return new Sim_UNG_103();
                case cardIDEnum.UNG_108:
                    return new Sim_UNG_108();
                case cardIDEnum.UNG_109:
                    return new Sim_UNG_109();
                case cardIDEnum.UNG_111:
                    return new Sim_UNG_111();
                case cardIDEnum.UNG_111t1:
                    return new Sim_UNG_111t1();
                case cardIDEnum.UNG_113:
                    return new Sim_UNG_113();
                case cardIDEnum.UNG_116:
                    return new Sim_UNG_116();
                case cardIDEnum.UNG_116t:
                    return new Sim_UNG_116t();
                case cardIDEnum.UNG_201:
                    return new Sim_UNG_201();
                case cardIDEnum.UNG_202:
                    return new Sim_UNG_202();
                case cardIDEnum.UNG_205:
                    return new Sim_UNG_205();
                case cardIDEnum.UNG_208:
                    return new Sim_UNG_208();
                case cardIDEnum.UNG_211:
                    return new Sim_UNG_211();
                case cardIDEnum.UNG_211a:
                    return new Sim_UNG_211a();
                case cardIDEnum.UNG_211aa:
                    return new Sim_UNG_211aa();
                case cardIDEnum.UNG_211b:
                    return new Sim_UNG_211b();
                case cardIDEnum.UNG_211c:
                    return new Sim_UNG_211c();
                case cardIDEnum.UNG_211d:
                    return new Sim_UNG_211d();
                case cardIDEnum.UNG_800:
                    return new Sim_UNG_800();
                case cardIDEnum.UNG_801:
                    return new Sim_UNG_801();
                case cardIDEnum.UNG_803:
                    return new Sim_UNG_803();
                case cardIDEnum.UNG_806:
                    return new Sim_UNG_806();
                case cardIDEnum.UNG_807:
                    return new Sim_UNG_807();
                case cardIDEnum.UNG_808:
                    return new Sim_UNG_808();
                case cardIDEnum.UNG_809:
                    return new Sim_UNG_809();
                case cardIDEnum.UNG_809t1:
                    return new Sim_UNG_809t1();
                case cardIDEnum.UNG_810:
                    return new Sim_UNG_810();
                case cardIDEnum.UNG_812:
                    return new Sim_UNG_812();
                case cardIDEnum.UNG_813:
                    return new Sim_UNG_813();
                case cardIDEnum.UNG_814:
                    return new Sim_UNG_814();
                case cardIDEnum.UNG_816:
                    return new Sim_UNG_816();
                case cardIDEnum.UNG_817:
                    return new Sim_UNG_817();
                case cardIDEnum.UNG_818:
                    return new Sim_UNG_818();
                case cardIDEnum.UNG_823:
                    return new Sim_UNG_823();
                case cardIDEnum.UNG_829:
                    return new Sim_UNG_829();
                case cardIDEnum.UNG_829t1:
                    return new Sim_UNG_829t1();
                case cardIDEnum.UNG_829t2:
                    return new Sim_UNG_829t2();
                case cardIDEnum.UNG_829t3:
                    return new Sim_UNG_829t3();
                case cardIDEnum.UNG_830:
                    return new Sim_UNG_830();
                case cardIDEnum.UNG_831:
                    return new Sim_UNG_831();
                case cardIDEnum.UNG_832:
                    return new Sim_UNG_832();
                case cardIDEnum.UNG_833:
                    return new Sim_UNG_833();
                case cardIDEnum.UNG_834:
                    return new Sim_UNG_834();
                case cardIDEnum.UNG_835:
                    return new Sim_UNG_835();
                case cardIDEnum.UNG_836:
                    return new Sim_UNG_836();
                case cardIDEnum.UNG_838:
                    return new Sim_UNG_838();
                case cardIDEnum.UNG_840:
                    return new Sim_UNG_840();
                case cardIDEnum.UNG_843:
                    return new Sim_UNG_843();
                case cardIDEnum.UNG_844:
                    return new Sim_UNG_844();
                case cardIDEnum.UNG_845:
                    return new Sim_UNG_845();
                case cardIDEnum.UNG_846:
                    return new Sim_UNG_846();
                case cardIDEnum.UNG_847:
                    return new Sim_UNG_847();
                case cardIDEnum.UNG_848:
                    return new Sim_UNG_848();
                case cardIDEnum.UNG_851:
                    return new Sim_UNG_851();
                case cardIDEnum.UNG_851t1:
                    return new Sim_UNG_851t1();
                case cardIDEnum.UNG_852:
                    return new Sim_UNG_852();
                case cardIDEnum.UNG_854:
                    return new Sim_UNG_854();
                case cardIDEnum.UNG_856:
                    return new Sim_UNG_856();
                case cardIDEnum.UNG_900:
                    return new Sim_UNG_900();
                case cardIDEnum.UNG_907:
                    return new Sim_UNG_907();
                case cardIDEnum.UNG_910:
                    return new Sim_UNG_910();
                case cardIDEnum.UNG_912:
                    return new Sim_UNG_912();
                case cardIDEnum.UNG_913:
                    return new Sim_UNG_913();
                case cardIDEnum.UNG_914:
                    return new Sim_UNG_914();
                case cardIDEnum.UNG_914t1:
                    return new Sim_UNG_914t1();
                case cardIDEnum.UNG_915:
                    return new Sim_UNG_915();
                case cardIDEnum.UNG_916:
                    return new Sim_UNG_916();
                case cardIDEnum.UNG_917:
                    return new Sim_UNG_917();
                case cardIDEnum.UNG_917t1:
                    return new Sim_UNG_917t1();
                case cardIDEnum.UNG_919:
                    return new Sim_UNG_919();
                case cardIDEnum.UNG_920:
                    return new Sim_UNG_920();
                case cardIDEnum.UNG_920t1:
                    return new Sim_UNG_920t1();
                case cardIDEnum.UNG_920t2:
                    return new Sim_UNG_920t2();
                case cardIDEnum.UNG_922:
                    return new Sim_UNG_922();
                case cardIDEnum.UNG_923:
                    return new Sim_UNG_923();
                case cardIDEnum.UNG_925:
                    return new Sim_UNG_925();
                case cardIDEnum.UNG_926:
                    return new Sim_UNG_926();
                case cardIDEnum.UNG_927:
                    return new Sim_UNG_927();
                case cardIDEnum.UNG_928:
                    return new Sim_UNG_928();
                case cardIDEnum.UNG_929:
                    return new Sim_UNG_929();
                case cardIDEnum.UNG_933:
                    return new Sim_UNG_933();
                case cardIDEnum.UNG_934:
                    return new Sim_UNG_934();
                case cardIDEnum.UNG_934t1:
                    return new Sim_UNG_934t1();
                case cardIDEnum.UNG_934t2:
                    return new Sim_UNG_934t2();
                case cardIDEnum.UNG_937:
                    return new Sim_UNG_937();
                case cardIDEnum.UNG_938:
                    return new Sim_UNG_938();
                case cardIDEnum.UNG_940:
                    return new Sim_UNG_940();
                case cardIDEnum.UNG_940t8:
                    return new Sim_UNG_940t8();
                case cardIDEnum.UNG_941:
                    return new Sim_UNG_941();
                case cardIDEnum.UNG_942:
                    return new Sim_UNG_942();
                case cardIDEnum.UNG_942t:
                    return new Sim_UNG_942t();
                case cardIDEnum.UNG_946:
                    return new Sim_UNG_946();
                case cardIDEnum.UNG_948:
                    return new Sim_UNG_948();
                case cardIDEnum.UNG_950:
                    return new Sim_UNG_950();
                case cardIDEnum.UNG_952:
                    return new Sim_UNG_952();
                case cardIDEnum.UNG_953:
                    return new Sim_UNG_953();
                case cardIDEnum.UNG_954:
                    return new Sim_UNG_954();
                case cardIDEnum.UNG_954t1:
                    return new Sim_UNG_954t1();
                case cardIDEnum.UNG_955:
                    return new Sim_UNG_955();
                case cardIDEnum.UNG_956:
                    return new Sim_UNG_956();
                case cardIDEnum.UNG_957:
                    return new Sim_UNG_957();
                case cardIDEnum.UNG_960:
                    return new Sim_UNG_960();
                case cardIDEnum.UNG_961:
                    return new Sim_UNG_961();
                case cardIDEnum.UNG_962:
                    return new Sim_UNG_962();
                case cardIDEnum.UNG_963:
                    return new Sim_UNG_963();
                case cardIDEnum.UNG_999t10:
                    return new Sim_UNG_999t10();
                case cardIDEnum.UNG_999t13:
                    return new Sim_UNG_999t13();
                case cardIDEnum.UNG_999t14:
                    return new Sim_UNG_999t14();
                case cardIDEnum.UNG_999t2:
                    return new Sim_UNG_999t2();
                case cardIDEnum.UNG_999t2t1:
                    return new Sim_UNG_999t2t1();
                case cardIDEnum.UNG_999t3:
                    return new Sim_UNG_999t3();
                case cardIDEnum.UNG_999t4:
                    return new Sim_UNG_999t4();
                case cardIDEnum.UNG_999t5:
                    return new Sim_UNG_999t5();
                case cardIDEnum.UNG_999t6:
                    return new Sim_UNG_999t6();
                case cardIDEnum.UNG_999t7:
                    return new Sim_UNG_999t7();
                case cardIDEnum.UNG_999t8:
                    return new Sim_UNG_999t8();

                case cardIDEnum.ICC_018:
                    return new Sim_ICC_018();
                case cardIDEnum.ICC_019:
                    return new Sim_ICC_019();
                case cardIDEnum.ICC_021:
                    return new Sim_ICC_021();
                case cardIDEnum.ICC_023:
                    return new Sim_ICC_023();
                case cardIDEnum.ICC_025:
                    return new Sim_ICC_025();
                case cardIDEnum.ICC_026:
                    return new Sim_ICC_026();
                case cardIDEnum.ICC_027:
                    return new Sim_ICC_027();
                case cardIDEnum.ICC_028:
                    return new Sim_ICC_028();
                case cardIDEnum.ICC_029:
                    return new Sim_ICC_029();
                case cardIDEnum.ICC_031:
                    return new Sim_ICC_031();
                case cardIDEnum.ICC_032:
                    return new Sim_ICC_032();
                case cardIDEnum.ICC_034:
                    return new Sim_ICC_034();
                case cardIDEnum.ICC_038:
                    return new Sim_ICC_038();
                case cardIDEnum.ICC_039:
                    return new Sim_ICC_039();
                case cardIDEnum.ICC_041:
                    return new Sim_ICC_041();
                case cardIDEnum.ICC_047:
                    return new Sim_ICC_047();
                case cardIDEnum.ICC_047t:
                    return new Sim_ICC_047t();
                case cardIDEnum.ICC_047t2:
                    return new Sim_ICC_047t2();
                case cardIDEnum.ICC_049:
                    return new Sim_ICC_049();
                case cardIDEnum.ICC_050:
                    return new Sim_ICC_050();
                case cardIDEnum.ICC_051:
                    return new Sim_ICC_051();
                case cardIDEnum.ICC_052:
                    return new Sim_ICC_052();
                case cardIDEnum.ICC_054:
                    return new Sim_ICC_054();
                case cardIDEnum.ICC_055:
                    return new Sim_ICC_055();
                case cardIDEnum.ICC_056:
                    return new Sim_ICC_056();
                case cardIDEnum.ICC_058:
                    return new Sim_ICC_058();
                case cardIDEnum.ICC_062:
                    return new Sim_ICC_062();
                case cardIDEnum.ICC_064:
                    return new Sim_ICC_064();
                case cardIDEnum.ICC_065:
                    return new Sim_ICC_065();
                case cardIDEnum.ICC_067:
                    return new Sim_ICC_067();
                case cardIDEnum.ICC_068:
                    return new Sim_ICC_068();
                case cardIDEnum.ICC_069:
                    return new Sim_ICC_069();
                case cardIDEnum.ICC_071:
                    return new Sim_ICC_071();
                case cardIDEnum.ICC_075:
                    return new Sim_ICC_075();
                case cardIDEnum.ICC_078:
                    return new Sim_ICC_078();
                case cardIDEnum.ICC_079:
                    return new Sim_ICC_079();
                case cardIDEnum.ICC_081:
                    return new Sim_ICC_081();
                case cardIDEnum.ICC_082:
                    return new Sim_ICC_082();
                case cardIDEnum.ICC_083:
                    return new Sim_ICC_083();
                case cardIDEnum.ICC_085:
                    return new Sim_ICC_085();
                case cardIDEnum.ICC_086:
                    return new Sim_ICC_086();
                case cardIDEnum.ICC_088:
                    return new Sim_ICC_088();
                case cardIDEnum.ICC_089:
                    return new Sim_ICC_089();
                case cardIDEnum.ICC_090:
                    return new Sim_ICC_090();
                case cardIDEnum.ICC_091:
                    return new Sim_ICC_091();
                case cardIDEnum.ICC_092:
                    return new Sim_ICC_092();
                case cardIDEnum.ICC_093:
                    return new Sim_ICC_093();
                case cardIDEnum.ICC_094:
                    return new Sim_ICC_094();
                case cardIDEnum.ICC_096:
                    return new Sim_ICC_096();
                case cardIDEnum.ICC_097:
                    return new Sim_ICC_097();
                case cardIDEnum.ICC_098:
                    return new Sim_ICC_098();
                case cardIDEnum.ICC_099:
                    return new Sim_ICC_099();
                case cardIDEnum.ICC_200:
                    return new Sim_ICC_200();
                case cardIDEnum.ICC_201:
                    return new Sim_ICC_201();
                case cardIDEnum.ICC_204:
                    return new Sim_ICC_204();
                case cardIDEnum.ICC_206:
                    return new Sim_ICC_206();
                case cardIDEnum.ICC_207:
                    return new Sim_ICC_207();
                case cardIDEnum.ICC_210:
                    return new Sim_ICC_210();
                case cardIDEnum.ICC_212:
                    return new Sim_ICC_212();
                case cardIDEnum.ICC_213:
                    return new Sim_ICC_213();
                case cardIDEnum.ICC_214:
                    return new Sim_ICC_214();
                case cardIDEnum.ICC_215:
                    return new Sim_ICC_215();
                case cardIDEnum.ICC_218:
                    return new Sim_ICC_218();
                case cardIDEnum.ICC_220:
                    return new Sim_ICC_220();
                case cardIDEnum.ICC_221:
                    return new Sim_ICC_221();
                case cardIDEnum.ICC_233:
                    return new Sim_ICC_233();
                case cardIDEnum.ICC_235:
                    return new Sim_ICC_235();
                case cardIDEnum.ICC_236:
                    return new Sim_ICC_236();
                case cardIDEnum.ICC_238:
                    return new Sim_ICC_238();
                case cardIDEnum.ICC_240:
                    return new Sim_ICC_240();
                case cardIDEnum.ICC_243:
                    return new Sim_ICC_243();
                case cardIDEnum.ICC_244:
                    return new Sim_ICC_244();
                case cardIDEnum.ICC_245:
                    return new Sim_ICC_245();
                case cardIDEnum.ICC_252:
                    return new Sim_ICC_252();
                case cardIDEnum.ICC_257:
                    return new Sim_ICC_257();
                case cardIDEnum.ICC_281:
                    return new Sim_ICC_281();
                case cardIDEnum.ICC_289:
                    return new Sim_ICC_289();
                case cardIDEnum.ICC_314:
                    return new Sim_ICC_314();
                case cardIDEnum.ICC_314t1:
                    return new Sim_ICC_314t1();
                case cardIDEnum.ICC_314t2:
                    return new Sim_ICC_314t2();
                case cardIDEnum.ICC_314t3:
                    return new Sim_ICC_314t3();
                case cardIDEnum.ICC_314t4:
                    return new Sim_ICC_314t4();
                case cardIDEnum.ICC_314t5:
                    return new Sim_ICC_314t5();
                case cardIDEnum.ICC_314t6:
                    return new Sim_ICC_314t6();
                case cardIDEnum.ICC_314t7:
                    return new Sim_ICC_314t7();
                case cardIDEnum.ICC_314t8:
                    return new Sim_ICC_314t8();
                case cardIDEnum.ICC_405:
                    return new Sim_ICC_405();
                case cardIDEnum.ICC_407:
                    return new Sim_ICC_407();
                case cardIDEnum.ICC_408:
                    return new Sim_ICC_408();
                case cardIDEnum.ICC_415:
                    return new Sim_ICC_415();
                case cardIDEnum.ICC_419:
                    return new Sim_ICC_419();
                case cardIDEnum.ICC_450:
                    return new Sim_ICC_450();
                case cardIDEnum.ICC_466:
                    return new Sim_ICC_466();
                case cardIDEnum.ICC_467:
                    return new Sim_ICC_467();
                case cardIDEnum.ICC_468:
                    return new Sim_ICC_468();
                case cardIDEnum.ICC_469:
                    return new Sim_ICC_469();
                case cardIDEnum.ICC_481:
                    return new Sim_ICC_481();
                case cardIDEnum.ICC_481p:
                    return new Sim_ICC_481p();
                case cardIDEnum.ICC_700:
                    return new Sim_ICC_700();
                case cardIDEnum.ICC_701:
                    return new Sim_ICC_701();
                case cardIDEnum.ICC_702:
                    return new Sim_ICC_702();
                case cardIDEnum.ICC_705:
                    return new Sim_ICC_705();
                case cardIDEnum.ICC_706:
                    return new Sim_ICC_706();
                case cardIDEnum.ICC_801:
                    return new Sim_ICC_801();
                case cardIDEnum.ICC_802:
                    return new Sim_ICC_802();
                case cardIDEnum.ICC_807:
                    return new Sim_ICC_807();
                case cardIDEnum.ICC_808:
                    return new Sim_ICC_808();
                case cardIDEnum.ICC_809:
                    return new Sim_ICC_809();
                case cardIDEnum.ICC_810:
                    return new Sim_ICC_810();
                case cardIDEnum.ICC_811:
                    return new Sim_ICC_811();
                case cardIDEnum.ICC_812:
                    return new Sim_ICC_812();
                case cardIDEnum.ICC_820:
                    return new Sim_ICC_820();
                case cardIDEnum.ICC_823:
                    return new Sim_ICC_823();
                case cardIDEnum.ICC_825:
                    return new Sim_ICC_825();
                case cardIDEnum.ICC_827:
                    return new Sim_ICC_827();
                case cardIDEnum.ICC_827p:
                    return new Sim_ICC_827p();
                case cardIDEnum.ICC_827t:
                    return new Sim_ICC_827t();
                case cardIDEnum.ICC_828:
                    return new Sim_ICC_828();
                case cardIDEnum.ICC_828p:
                    return new Sim_ICC_828p();
                case cardIDEnum.ICC_829:
                    return new Sim_ICC_829();
                case cardIDEnum.ICC_829p:
                    return new Sim_ICC_829p();
                case cardIDEnum.ICC_829t:
                    return new Sim_ICC_829t();
                case cardIDEnum.ICC_830:
                    return new Sim_ICC_830();
                case cardIDEnum.ICC_830p:
                    return new Sim_ICC_830p();
                case cardIDEnum.ICC_831:
                    return new Sim_ICC_831();
                case cardIDEnum.ICC_831p:
                    return new Sim_ICC_831p();
                case cardIDEnum.ICC_832:
                    return new Sim_ICC_832();
                case cardIDEnum.ICC_832p:
                    return new Sim_ICC_832p();
                case cardIDEnum.ICC_832pa:
                    return new Sim_ICC_832pa();
                case cardIDEnum.ICC_832pb:
                    return new Sim_ICC_832pb();
                case cardIDEnum.ICC_833:
                    return new Sim_ICC_833();
                case cardIDEnum.ICC_833h:
                    return new Sim_ICC_833h();
                case cardIDEnum.ICC_834:
                    return new Sim_ICC_834();
                case cardIDEnum.ICC_834h:
                    return new Sim_ICC_834h();
                case cardIDEnum.ICC_835:
                    return new Sim_ICC_835();
                case cardIDEnum.ICC_836:
                    return new Sim_ICC_836();
                case cardIDEnum.ICC_837:
                    return new Sim_ICC_837();
                case cardIDEnum.ICC_838:
                    return new Sim_ICC_838();
                case cardIDEnum.ICC_838t:
                    return new Sim_ICC_838t();
                case cardIDEnum.ICC_841:
                    return new Sim_ICC_841();
                case cardIDEnum.ICC_849:
                    return new Sim_ICC_849();
                case cardIDEnum.ICC_850:
                    return new Sim_ICC_850();
                case cardIDEnum.ICC_851:
                    return new Sim_ICC_851();
                case cardIDEnum.ICC_852:
                    return new Sim_ICC_852();
                case cardIDEnum.ICC_853:
                    return new Sim_ICC_853();
                case cardIDEnum.ICC_854:
                    return new Sim_ICC_854();
                case cardIDEnum.ICC_855:
                    return new Sim_ICC_855();
                case cardIDEnum.ICC_856:
                    return new Sim_ICC_856();
                case cardIDEnum.ICC_858:
                    return new Sim_ICC_858();
                case cardIDEnum.ICC_900:
                    return new Sim_ICC_900();
                case cardIDEnum.ICC_901:
                    return new Sim_ICC_901();
                case cardIDEnum.ICC_902:
                    return new Sim_ICC_902();
                case cardIDEnum.ICC_903:
                    return new Sim_ICC_903();
                case cardIDEnum.ICC_904:
                    return new Sim_ICC_904();
                case cardIDEnum.ICC_905:
                    return new Sim_ICC_905();
                case cardIDEnum.ICC_910:
                    return new Sim_ICC_910();
                case cardIDEnum.ICC_911:
                    return new Sim_ICC_911();
                case cardIDEnum.ICC_912:
                    return new Sim_ICC_912();
                case cardIDEnum.ICC_913:
                    return new Sim_ICC_913();
                case cardIDEnum.LOOT_357:
                    return new Sim_LOOT_357();
                case cardIDEnum.LOOT_357l:
                    return new Sim_LOOT_357l();
                case cardIDEnum.LOOT_998h:
                    return new Sim_LOOT_998h();
                case cardIDEnum.LOOT_998k:
                    return new Sim_LOOT_998k();
                case cardIDEnum.LOOT_998l:
                    return new Sim_LOOT_998l();
                case cardIDEnum.LOOT_998j:
                    return new Sim_LOOT_998j();
                case cardIDEnum.GIL_530:
                    return new Sim_GIL_530();
            }

            return new SimTemplate();
        }

        private void enumCreator()
        {
            //call this, if carddb.txt was changed, to get latest public enum cardIDEnum
            Helpfunctions.Instance.logg("public enum cardIDEnum");
            Helpfunctions.Instance.logg("{");
            Helpfunctions.Instance.logg("None,");
            foreach (string cardid in this.allCardIDS)
            {
                Helpfunctions.Instance.logg(cardid + ",");
            }
            Helpfunctions.Instance.logg("}");



            Helpfunctions.Instance.logg("public cardIDEnum cardIdstringToEnum(string s)");
            Helpfunctions.Instance.logg("{");
            foreach (string cardid in this.allCardIDS)
            {
                Helpfunctions.Instance.logg("if(s==\"" + cardid + "\") return CardDB.cardIDEnum." + cardid + ";");
            }
            Helpfunctions.Instance.logg("return CardDB.cardIDEnum.None;");
            Helpfunctions.Instance.logg("}");

            List<string> namelist = new List<string>();

            foreach (string cardid in this.namelist)
            {
                if (namelist.Contains(cardid)) continue;
                namelist.Add(cardid);
            }


            Helpfunctions.Instance.logg("public enum cardName");
            Helpfunctions.Instance.logg("{");
            foreach (string cardid in namelist)
            {
                Helpfunctions.Instance.logg(cardid + ",");
            }
            Helpfunctions.Instance.logg("}");

            Helpfunctions.Instance.logg("public cardName cardNamestringToEnum(string s)");
            Helpfunctions.Instance.logg("{");
            foreach (string cardid in namelist)
            {
                Helpfunctions.Instance.logg("if(s==\"" + cardid + "\") return CardDB.cardName." + cardid + ";");
            }
            Helpfunctions.Instance.logg("return CardDB.cardName.unknown;");
            Helpfunctions.Instance.logg("}");

            // simcard creator:

            Helpfunctions.Instance.logg("public SimTemplate getSimCard(cardIDEnum id)");
            Helpfunctions.Instance.logg("{");
            foreach (string cardid in this.allCardIDS)
            {
                Helpfunctions.Instance.logg("if(id == CardDB.cardIDEnum." + cardid + ") return new Sim_" + cardid + "();");
            }
            Helpfunctions.Instance.logg("return new SimTemplate();");
            Helpfunctions.Instance.logg("}");

        }

        private void setAdditionalData()
        {
            PenalityManager pen = PenalityManager.Instance;

            foreach (Card c in this.cardlist)
            {
                if (pen.cardDrawBattleCryDatabase.ContainsKey(c.name))
                {
                    c.isCarddraw = pen.cardDrawBattleCryDatabase[c.name];
                }

                if (pen.DamageTargetSpecialDatabase.ContainsKey(c.name))
                {
                    c.damagesTargetWithSpecial = true;
                }

                if (pen.DamageTargetDatabase.ContainsKey(c.name))
                {
                    c.damagesTarget = true;
                }

                if (pen.priorityTargets.ContainsKey(c.name))
                {
                    c.targetPriority = pen.priorityTargets[c.name];
                }

                if (pen.specialMinions.ContainsKey(c.name))
                {
                    c.isSpecialMinion = true;
                }
                
                c.trigers = new List<cardtrigers>();
                Type trigerType = c.sim_card.GetType();
                foreach (string trigerName in Enum.GetNames(typeof(cardtrigers)))
                {
                    try
                    {
	                    foreach (var m in trigerType.GetMethods().Where(e=>e.Name.Equals(trigerName, StringComparison.Ordinal)))
	                    {
							if (m.DeclaringType == trigerType)
								c.trigers.Add((cardtrigers)Enum.Parse(typeof(cardtrigers), trigerName));
						}
                    }
                    catch
                    {
                    }
                }
                if (c.trigers.Count > 10) c.trigers.Clear();
            }
        }

    }

}