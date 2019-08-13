using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;

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
            AT_132_ROGUEt,
            AT_132_SHAMAN,
            AT_132_SHAMANa,
            AT_132_SHAMANb,
            AT_132_SHAMANc,
            AT_132_SHAMANd,
            AT_132_WARLOCK,
            AT_132_WARRIOR,
            AT_133,
            AT_133e,
            BRMA01_1,
            BRMA01_1H,
            BRMA01_2,
            BRMA01_2H,
            BRMA01_2H_2_TB,
            BRMA01_3,
            BRMA01_4,
            BRMA01_4t,
            BRMA02_1,
            BRMA02_1H,
            BRMA02_2,
            BRMA02_2H,
            BRMA02_2t,
            BRMA02_2_2c_TB,
            BRMA02_2_2_TB,
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
            BRMA07_2H,
            BRMA07_2_2c_TB,
            BRMA07_2_2_TB,
            BRMA07_3,
            BRMA08_1,
            BRMA08_1H,
            BRMA08_2,
            BRMA08_2H,
            BRMA08_3,
            BRMA09_1,
            BRMA09_1H,
            BRMA09_2,
            BRMA09_2H,
            BRMA09_2Ht,
            BRMA09_2t,
            BRMA09_2_TB,
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
            BRMA13_4H,
            BRMA13_4_2_TB,
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
            BRMA17_5H,
            BRMA17_5_TB,
            BRMA17_6,
            BRMA17_6H,
            BRMA17_7,
            BRMA17_8,
            BRMA17_8H,
            BRMA17_9,
            BRMA_01,
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
            CFM_621_m2,
            CFM_621_m3,
            CFM_621_m4,
            CFM_621_m5,
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
            CS1h_001,
            CS1h_001_H1,
            CS1h_001_H1_AT_132,
            CS1_042,
            CS1_069,
            CS1_112,
            CS1_113,
            CS1_129,
            CS1_129e,
            CS1_130,
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
            CS2_083b,
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
            CS2_101t,
            CS2_101_H1,
            CS2_101_H1_AT_132,
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
            DS1h_292,
            DS1h_292_H1,
            DS1h_292_H1_AT_132,
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
            EX1_tk34,
            EX1_tk9,
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
            HERO_01b,
            HERO_02,
            HERO_02a,
            HERO_02b,
            HERO_03,
            HERO_03a,
            HERO_04,
            HERO_04a,
            HERO_04b,
            HERO_05,
            HERO_05a,
            HERO_05b,
            HERO_06,
            HERO_06a,
            HERO_07,
            HERO_07a,
            HERO_08,
            HERO_08a,
            HERO_08b,
            HERO_08c,
            HERO_09,
            HERO_09a,
            HERO_09b,
            hexfrog,
            HRW02_1,
            HRW02_1e,
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
            LOEA_01,
            LOEA_01H,
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
            Mekka1,
            Mekka2,
            Mekka3,
            Mekka3e,
            Mekka4,
            Mekka4e,
            Mekka4t,
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
            NAX12_02H_2c_TB,
            NAX12_02H_2_TB,
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
            NAX1_01,
            NAX1_03,
            NAX1_04,
            NAX1_05,
            NAX2_01,
            NAX2_01H,
            NAX2_03,
            NAX2_03H,
            NAX2_05,
            NAX2_05H,
            NAX3_01,
            NAX3_01H,
            NAX3_02,
            NAX3_02H,
            NAX3_02_TB,
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
            PlaceholderCard,
            PRO_001,
            PRO_001a,
            PRO_001at,
            PRO_001b,
            PRO_001c,
            skele11,
            skele21,
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
            TB_013,
            TB_014,
            TB_015,
            TB_AllMinionsTauntCharge,
            TB_BlingBrawl_Blade1e,
            TB_BlingBrawl_Blade2e,
            TB_BlingBrawl_Hero1,
            TB_BlingBrawl_Hero1e,
            TB_BlingBrawl_Hero1p,
            TB_BlingBrawl_Weapon,
            TB_Blizzcon2016_GoonsEnchant,
            TB_Blizzcon2016_KabalEnchant,
            TB_Blizzcon2016_LotusEnchant,
            TB_BoomAnnoy_001e,
            TB_BRMA01_2H_2,
            TB_BRMA10_3H,
            TB_ClassRandom_Druid,
            TB_ClassRandom_Hunter,
            TB_ClassRandom_Mage,
            TB_ClassRandom_Paladin,
            TB_ClassRandom_PickSecondClass,
            TB_ClassRandom_Priest,
            TB_ClassRandom_Rogue,
            TB_ClassRandom_Shaman,
            TB_ClassRandom_Warlock,
            TB_ClassRandom_Warrior,
            TB_CoOpBossSpell_1,
            TB_CoOpBossSpell_2,
            TB_CoOpBossSpell_3,
            TB_CoOpBossSpell_4,
            TB_CoOpBossSpell_5,
            TB_CoOpBossSpell_6,
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
            TB_CoOpv3_104e,
            TB_Coopv3_104_NewClasses,
            TB_Coopv3_105,
            TB_CoOpv3_200,
            TB_CoOpv3_201,
            TB_CoOpv3_202,
            TB_CoOpv3_203,
            TB_CoOpv3_Boss,
            TB_CoOpv3_BOSS2e,
            TB_CoOpv3_BOSS3e,
            TB_CoOpv3_BOSS4e,
            TB_CoOpv3_BOSSe,
            TB_CoOpv3_Boss_NewClasses,
            TB_CoOp_Mechazod2,
            TB_CoOp_Mechazod_OLD,
            TB_DeckRecipe_MyDeckID,
            TB_DiscoverMyDeck_Discovery,
            TB_DiscoverMyDeck_Enchantment,
            TB_Dorothee_001,
            TB_EndlessMinions01,
            TB_Face_Ench1,
            TB_FactionWar_Hero_Annoy_Update,
            TB_FactionWar_Rag1,
            TB_FW_Boom,
            TB_FW_Boom_Update,
            TB_FW_Boom_Weapon,
            TB_FW_DrBoomMega,
            TB_FW_HeroPower_Boom,
            TB_FW_HeroPower_Boom_Update,
            TB_FW_ImbaTron,
            TB_FW_Mortar,
            TB_FW_OmegaMax,
            TB_FW_Warper,
            TB_GiftExchange_Enchantment,
            TB_GiftExchange_Snowball,
            TB_GiftExchange_Treasure,
            TB_GiftExchange_Treasure_Spell,
            TB_GP_01e_copy1,
            TB_GP_01e_v2,
            TB_GreatCurves_01,
            TB_KaraPortals_003,
            TB_KaraPortal_001,
            TB_KaraPortal_002,
            TB_KaraPortal_003,
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
            TB_KTRAF_HP_KT_3,
            TB_KTRAF_HP_RAF3,
            TB_KTRAF_HP_RAF4,
            TB_KTRAF_HP_RAF5,
            TB_KTRAF_H_1,
            TB_KTRAF_H_2,
            TB_LevelUp_001,
            TB_LOEA13_2,
            TB_MechWar_Boss1,
            TB_MechWar_Boss1_HeroPower,
            TB_MechWar_Boss2,
            TB_MechWar_Boss2_HeroPower,
            TB_MechWar_CommonCards,
            TB_MechWar_Minion1,
            TB_Mini_1e,
            TB_OG_027,
            TB_PickYourFate,
            TB_PickYourFate7Ench,
            TB_PickYourFateRandom,
            TB_PickYourFate_1,
            TB_PickYourFate_10,
            TB_PickYourFate_10_Ench,
            TB_PickYourFate_10_EnchMinion,
            TB_PickYourFate_11b,
            TB_PickYourFate_11rand,
            TB_PickYourFate_11_Ench,
            TB_PickYourFate_12,
            TB_PickYourFate_12_Ench,
            TB_PickYourFate_1_Ench,
            TB_PickYourFate_2,
            TB_PickYourFate_2nd,
            TB_PickYourFate_2_Ench,
            TB_PickYourFate_2_EnchMinion,
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
            TB_PickYourFate_7_EnchMiniom2nd,
            TB_PickYourFate_7_EnchMinion,
            TB_PickYourFate_7_Ench_2nd,
            TB_PickYourFate_8,
            TB_PickYourFate_8rand,
            TB_PickYourFate_8_Ench,
            TB_PickYourFate_8_EnchRand,
            TB_PickYourFate_9,
            TB_PickYourFate_9_Ench,
            TB_PickYourFate_9_EnchMinion,
            TB_PickYourFate_Confused,
            TB_PickYourFate_Windfury,
            TB_Pilot1,
            TB_RandCardCost,
            TB_RandHero2_001,
            TB_RMC_001,
            TB_SPT_Boss,
            TB_SPT_BossHeroPower,
            TB_SPT_BossWeapon,
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
            TB_SPT_DPromo_EnterPortal,
            TB_SPT_DPromo_Hero,
            TB_SPT_DPromo_Hero2,
            TB_SPT_Minion1,
            TB_SPT_Minion1e,
            TB_SPT_Minion2,
            TB_SPT_Minion2e,
            TB_SPT_Minion3,
            TB_SPT_Minion3e,
            TB_Superfriends001,
            TB_Superfriends001e,
            TB_Superfriends002e,
            TB_YoggServant_Enchant,
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
            XXX_001,
            XXX_002,
            XXX_003,
            XXX_004,
            XXX_005,
            XXX_006,
            XXX_007,
            XXX_008,
            XXX_009,
            XXX_009e,
            XXX_010,
            XXX_011,
            XXX_012,
            XXX_013,
            XXX_014,
            XXX_015,
            XXX_016,
            XXX_017,
            XXX_018,
            XXX_019,
            XXX_020,
            XXX_021,
            XXX_022,
            XXX_022e,
            XXX_023,
            XXX_024,
            XXX_025,
            XXX_026,
            XXX_027,
            XXX_028,
            XXX_029,
            XXX_030,
            XXX_039,
            XXX_040,
            XXX_041,
            XXX_042,
            XXX_043,
            XXX_044,
            XXX_045,
            XXX_046,
            XXX_047,
            XXX_048,
            XXX_049,
            XXX_050,
            XXX_051,
            XXX_052,
            XXX_053,
            XXX_054,
            XXX_054e,
            XXX_055,
            XXX_055e,
            XXX_056,
            XXX_057,
            XXX_058,
            XXX_058e,
            XXX_059,
            XXX_060,
            XXX_061,
            XXX_062,
            XXX_063,
            XXX_064,
            XXX_065,
            XXX_094,
            XXX_095,
            XXX_096,
            XXX_097,
            XXX_098,
            XXX_099,
            XXX_100,
            XXX_101,
            XXX_102,
            XXX_103,
            XXX_104,
            XXX_105,
            XXX_107,
            XXX_108,
            XXX_109,
            XXX_110,
            XXX_111,
            XXX_111e,
            XXX_112,
            XXX_113,
            XXX_115,
            XXX_115e,
            XXX_119,
            XXX_119e,
            XXX_999_Crash,
        }

        public cardIDEnum cardIdstringToEnum(string s)
        {
            CardDB.cardIDEnum CardEnum;
            if (Enum.TryParse<cardIDEnum>(s, false, out CardEnum)) return CardEnum;
            else
            {
                //if (s != "") Helpfunctions.Instance.ErrorLog("[CardDB] Unidentified card ID: " + s);
                return CardDB.cardIDEnum.None;
            }
        }

        public enum cardName
        {
            unknown,
            aberrantberserker,
            aberration,
            abomination,
            abusivesergeant,
            abyssal,
            abyssalenforcer,
            acidicswampooze,
            acidmaw,
            acolyteofpain,
            activate,
            activatearcanotron,
            activateelectron,
            activatemagmatron,
            activatetoxitron,
            add1tohealth,
            add2tohealth,
            add4tohealth,
            add8tohealth,
            addled,
            addledgrizzly,
            afk,
            again,
            aglowingpool,
            aibuddyallcharge,
            aibuddyallchargeallwindfury,
            aibuddyblankslate,
            aibuddydamageownhero5,
            aibuddydestroyminions,
            aibuddynodeckhand,
            aiextra1,
            aiextra2,
            aiextra3,
            aihelperbuddy,
            alakirthewindlord,
            alarmobot,
            aldorpeacekeeper,
            alexstrasza,
            alexstraszasboon,
            alexstraszaschampion,
            alexstraszasfire,
            alightinthedarkness,
            allchargeallwindfuryallthetime,
            alleriawindrunner,
            alleyarmorsmith,
            alleycat,
            almsoflight,
            amaniberserker,
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
            angrychicken,
            animagolem,
            animalcompanion,
            animated,
            animatedarmor,
            animatedshield,
            animatedstatue,
            animateearthen,
            annoyoptron,
            annoyotron,
            annoyotronprime,
            anodizedrobocub,
            anomalus,
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
            arcanosmith,
            arcanotron,
            archaedas,
            archmage,
            archmageantonidas,
            archmagesapprentice,
            archmagesinsight,
            archthiefrafaam,
            argentcommander,
            argenthorserider,
            argentlance,
            argentprotector,
            argentsquire,
            argentwatchman,
            armor1,
            armor100,
            armor5,
            armoredwarhorse,
            armorplated,
            armorplating,
            armorsmith,
            armorup,
            armory,
            arrakoadevotion,
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
            avatarofthecoin,
            avenge,
            avengingwrath,
            aviana,
            avianwatcher,
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
            baneofdoom,
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
            beartrap,
            beccaabel,
            beckonerofevil,
            becomehogger,
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
            bite,
            blackbishop,
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
            blarghghl,
            blastcrystalpotion,
            blessed,
            blessedchampion,
            blessingofkings,
            blessingofmight,
            blessingofthesun,
            blessingofwisdom,
            blessingsofthesun,
            blindwithrage,
            blingtron3000,
            blingtronsblade,
            blingtronsbladehero,
            blizzard,
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
            bloodrage,
            bloodsailcorsair,
            bloodsailcultist,
            bloodsailraider,
            bloodthistle,
            bloodthistletoxin,
            bloodtoichor,
            bloodwarriors,
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
            bolvarfordragon,
            bomblobber,
            bombsalvo,
            bombsquad,
            boneconstruct,
            boneguarded,
            boneguardlieutenant,
            boneminions,
            boneraptor,
            bonus,
            bookwyrm,
            boom,
            boombot,
            boombotbrood,
            boombotjr,
            bootybaybodyguard,
            bosshpswapper,
            boulderfistogre,
            bounce,
            bouncingblade,
            brannbronzebeard,
            brassknuckles,
            bravearcher,
            brawl,
            breakweapon,
            brewmaster,
            brianbirmingham,
            brianschwab,
            briarthorn,
            briarthorntoxin,
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
            bryanchang,
            buccaneer,
            burgle,
            burglybully,
            burlyrockjawtrogg,
            burningadrenaline,
            burrowingmine,
            cabaliststome,
            cabalshadowpriest,
            cairnebloodhoof,
            callerdevotion,
            callinthefinishers,
            callmediva,
            callofthewild,
            callpet,
            cameronchrisman,
            candle,
            cannibalize,
            captaingreenskin,
            captainsparrot,
            captboombot,
            capturedjormungar,
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
            charge,
            chargedhammer,
            chasingtrogg,
            cheapgift,
            cheat,
            chestofgold,
            chicken,
            chieftainscarvash,
            chilance,
            chillmaw,
            chillwindyeti,
            chogall,
            chooseanewcard,
            chooseoneofthree,
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
            cobaltguardian,
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
            coliseummanager,
            commandingshout,
            competitivespirit,
            conceal,
            concealed,
            coneofcold,
            confessorpaletress,
            confuse,
            confused,
            consecration,
            consultbrann,
            consume,
            convert,
            corehound,
            corehoundpup,
            corehoundpuppies,
            corendirebrew,
            corerager,
            corruptedegg,
            corruptedhealbot,
            corruptedseer,
            corruption,
            counterfeitcoin,
            counterspell,
            cowed,
            crackle,
            crash,
            crashtheserver,
            crazedalchemist,
            crazedhunter,
            crazedworshipper,
            crazymonkey,
            create15secrets,
            crowdfavorite,
            crownofkaelthas,
            crueltaskmaster,
            crush,
            cryomancer,
            crystal,
            crystalweaver,
            cthun,
            cthunschosen,
            cultapothecary,
            cultmaster,
            cultsorcerer,
            cup,
            curator,
            cursed,
            cursedblade,
            curseofrafaam,
            cutoff,
            cutpurse,
            cyclopianhorror,
            daggermastery,
            dalaranaspirant,
            dalaranmage,
            damage1,
            damage5,
            damageall,
            damageallbut1,
            damagedgolem,
            damagereflector,
            dancingswords,
            daringreporter,
            darkarakkoa,
            darkbargain,
            darkbomb,
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
            deadlyfork,
            deadlypoison,
            deadlyshot,
            deanayala,
            deathbloom,
            deathcharger,
            deathlord,
            deathmarkedlove,
            deathnorattle,
            deathrattlebonus,
            deathsbite,
            deathwing,
            deathwingdragonlord,
            debris,
            decimate,
            deckbuildingenchant,
            defender,
            defenderofargus,
            defiasbandit,
            defiascleaner,
            defiasringleader,
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
            dereksakamoto,
            desertcamel,
            destroy,
            destroyallheroes,
            destroyallmana,
            destroyallminions,
            destroyallsecrets,
            destroyamanacrystal,
            destroydeck,
            destroyheropower,
            destroyherosstuff,
            destroyplayedcardenchantment,
            destroyplayedcards,
            destroytargetsecrets,
            deviatebanana,
            deviateswitch,
            devilsaur,
            devolve,
            devotionoftheblade,
            diabolicalpowers,
            dieinsect,
            dieinsects,
            direclaws,
            direfatecard,
            direfatemanaburst,
            direfatemurlocs,
            direfatetauntandcharge,
            direfateunstableportals,
            direfatewindfury,
            direshapeshift,
            direwolfalpha,
            dirtyrat,
            discard,
            discardedarmor,
            discipleofcthun,
            discovermydeckenchant,
            disguised,
            dismount,
            dispatchkodo,
            dispel,
            divinefavor,
            divinespirit,
            divinestrength,
            djinniofzephyrs,
            djinnsintuition,
            donhancho,
            donothing,
            dontpushme,
            doom,
            doomcaller,
            doomfree,
            doomguard,
            doomhammer,
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
            dragonscalewarrior,
            dragonsfree,
            dragonsmight,
            dragonteeth,
            drainlife,
            drakkisathscommand,
            drakonidcrusher,
            drakonidoperative,
            drakonidslayer,
            draw3cards,
            drawoffensiveplay,
            drboom,
            drboomboomboomboom,
            dreadcorsair,
            dreadinfernal,
            dreadscale,
            dreadsteed,
            dream,
            drinkdeeply,
            druidoftheclaw,
            druidofthefang,
            druidoftheflame,
            druidofthesaber,
            dualwarglaives,
            dunemaulshaman,
            duplicate,
            duskboar,
            dustdevil,
            dwarfdemolitionist,
            dynamite,
            eadricthepure,
            eaglehornbow,
            earthelemental,
            earthenpursuer,
            earthenringfarseer,
            earthenstatue,
            earthshock,
            eaterofsecrets,
            eating,
            echoingooze,
            echolocate,
            echoofmedivh,
            edwinvancleef,
            eeriestatue,
            effigy,
            eldritchhorror,
            electron,
            elementaldestruction,
            elementaleruption,
            elisestarseeker,
            elitetaurenchieftain,
            elizabethcho,
            elunesgrace,
            elvenarcher,
            emboldened,
            emboldener3000,
            embracetheshadow,
            embracingtheshadow,
            emeralddrake,
            emergencycoolant,
            emperorcobra,
            emperorthaurissan,
            empowered,
            empoweringmist,
            empowerment,
            emptyenchant,
            enableemotes,
            enableforattack,
            enchant,
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
            equality,
            equipped,
            ericdelpriore,
            ericdodds,
            eruption,
            escape,
            essenceofthered,
            eternalsentinel,
            etherealarcanist,
            etherealconjurer,
            etherealpeddler,
            eveofdestruction,
            everyfinisawesome,
            evilheckler,
            eviscerate,
            evocation,
            evolve,
            evolvedkobold,
            evolvescales,
            evolvespines,
            excavatedevil,
            excessmana,
            execute,
            experienced,
            experiments,
            explorershat,
            explosiverune,
            explosiverunes,
            explosivesheep,
            explosiveshot,
            explosivetrap,
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
            faeriedragon,
            fallenhero,
            falloutslime,
            famished,
            fanaticdevotion,
            fandralstaghelm,
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
            fearsomedoomguard,
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
            feugen,
            fiercemonkey,
            fierybat,
            fierywaraxe,
            fightpromoter,
            filldeck,
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
            fireguarddestroyer,
            firehawkform,
            firelandsportal,
            firesworn,
            fistofjaraxxus,
            fjolalightbane,
            flameburst,
            flamecannon,
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
            forceaitouseheropower,
            forceofnature,
            forcetankmax,
            forcetankomegamax,
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
            freecards,
            freespell,
            freewheelingskulker,
            freeze,
            freezingpotion,
            freezingtrap,
            friendlybartender,
            frigidsnobold,
            frog,
            frostblast,
            frostbolt,
            frostbreath,
            frostelemental,
            frostgiant,
            frostnova,
            frostshock,
            frostwolfbanner,
            frostwolfgrunt,
            frostwolfwarlord,
            frothingberserker,
            frozenchampion,
            fullbelly,
            fullstrength,
            fungalgrowth,
            furioushowl,
            gadgetzanauctioneer,
            gadgetzanferryman,
            gadgetzanjouster,
            gadgetzansocialite,
            gahzrilla,
            galleryprotection,
            gallywixscoin,
            gangup,
            garr,
            garrisoncommander,
            garroshhellscream,
            gazlowe,
            gearmastermechazod,
            gelbinmekkatorque,
            generaldrakkisath,
            genzotheshark,
            geomancy,
            getawaykodo,
            getbig,
            getem,
            gettingangry,
            gettinghungry,
            giantfin,
            giantinsect,
            giantsandworm,
            giftofcards,
            giftofmana,
            gilblinstalker,
            givetauntandcharge,
            gladiatorslongbow,
            gladiatorslongbowenchantment,
            glaivezooka,
            gloriousfinale,
            gluth,
            gnoll,
            gnomereganinfantry,
            gnomishexperimenter,
            gnomishinventor,
            goblinautobarber,
            goblinblastmage,
            goblinsapper,
            goingnova,
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
            grantmegawindfury,
            graspofmalganis,
            greaterarcanemissiles,
            greaterhealingpotion,
            greaterpotion,
            greenskinscommand,
            grimestreetenforcer,
            grimestreetinformant,
            grimestreetoutfitter,
            grimestreetpawnbroker,
            grimestreetprotector,
            grimestreetsmuggler,
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
            hakkaribloodgoblet,
            hallazealtheascended,
            hamiltonchu,
            hammeroftwilight,
            hammerofwrath,
            handofargus,
            handofprotection,
            handswapperminion,
            handtodeck,
            hardpackedsnowballs,
            harrisonjones,
            harvest,
            harvestgolem,
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
            hemetnesingwary,
            henryho,
            heraldvolazj,
            herding,
            heretakebuff,
            herimwoo,
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
            hound,
            houndmaster,
            hourofcorruption,
            houroftwilight,
            hozenhealer,
            huffer,
            hugeego,
            hugetoad,
            humility,
            hungrycrab,
            hungrydragon,
            hungrynaga,
            huntersmark,
            hyena,
            iammurloc,
            icebarrier,
            iceblock,
            icecap,
            icehowl,
            icelance,
            icerager,
            ichorofundeath,
            ickyimp,
            ickytentacle,
            ignitemana,
            ihearyou,
            iknowaguy,
            illidanstormrage,
            illidanstormragecheat,
            illuminator,
            immolate,
            imp,
            imperialfavor,
            impgangboss,
            implosion,
            impmaster,
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
            insightful,
            inspired,
            instructorrazuvious,
            intensegaze,
            interloper,
            intrepiddragonstalker,
            investigatetherunes,
            ironbarkprotector,
            ironbeakowl,
            ironedout,
            ironforgeportal,
            ironforgerifleman,
            ironfurgrizzly,
            ironjuggernaut,
            ironsensei,
            ivoryknight,
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
            jasonmacallister,
            jaws,
            jaybaxter,
            jcpark,
            jeeringcrowd,
            jeeves,
            jeremycranford,
            jerrymascho,
            jeweledscarab,
            jinyuwaterspeaker,
            jomarokindred,
            jonaslaster,
            jonbankard,
            journeybelow,
            julianne,
            junglemoonkin,
            junglepanther,
            junkbot,
            junkedup,
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
            karakazham,
            kazakus,
            kazakuspotion,
            keeperofthegrove,
            keeperofuldaman,
            keepingsecrets,
            keithlandes,
            kelthuzad,
            kezanmystic,
            khadgar,
            khadgarspipe,
            kidnapper,
            killcommand,
            killmillhouse,
            killthelorewalker,
            kilrek,
            kindlygrandmother,
            kindredspirit,
            kingkrush,
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
            krultheunshackled,
            kuntheforgottenking,
            kvaldirraider,
            kyleharrison,
            laced,
            ladyblaumeux,
            ladyliadrin,
            ladynazjar,
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
            leeroyjenkins,
            legacyoftheemperor,
            legion,
            leokk,
            lepergnome,
            lesserheal,
            lesserpotion,
            levelup,
            leylines,
            lifetap,
            lightbomb,
            lightning,
            lightningbolt,
            lightningjolt,
            lightningstorm,
            lightofthenaaru,
            lightsblessing,
            lightschampion,
            lightsjustice,
            lightspawn,
            lightwarden,
            lightwell,
            lilexorcist,
            lionform,
            littlefriend,
            livingbomb,
            livinglava,
            livingroots,
            loatheb,
            lockandload,
            locustswarm,
            loomingpresence,
            lootedblade,
            loothoarder,
            lordjaraxxus,
            lordofthearena,
            lordslitherspear,
            lordvictornefarius,
            lorewalkercho,
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
            madamgoya,
            madbomber,
            madderbomber,
            madnesspotion,
            madscientist,
            maelstromportal,
            maexxna,
            magearmor,
            magicmirror,
            magmapulse,
            magmarager,
            magmatron,
            magmaw,
            magnatauralpha,
            magnibronzebeard,
            maidenofthelake,
            maintank,
            majordomoexecutus,
            makeimmune,
            malchezaarsimp,
            malfurionstormrage,
            malganis,
            malkorok,
            maloriak,
            malorne,
            malygos,
            manaaddict,
            manageode,
            managorged,
            manaheist,
            manastorm,
            manatidetotem,
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
            massdispel,
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
            maxma,
            maxmccall,
            mayornoggenfogger,
            meanstreetmarshal,
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
            mekgineerthermaplugg,
            melt,
            menageriemagician,
            menageriewarden,
            mesmash,
            metabolizedmagic,
            metalteeth,
            metaltoothleaper,
            michaelschweitzer,
            micromachine,
            midnightdrake,
            mightofmukla,
            mightofstormwind,
            mightofthehostler,
            mightofthemonkey,
            mightoftinkertown,
            mightofzulfarrak,
            mikedonais,
            mill10,
            mill30,
            millhousemanastorm,
            mime,
            mimironshead,
            mindblast,
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
            mogorschampion,
            mogortheogre,
            mogushanwarden,
            moirabronzebeard,
            molasses,
            moltengiant,
            moltenrage,
            moo,
            moonfire,
            moongladeportal,
            morgltheoracle,
            moroes,
            mortalcoil,
            mortalstrike,
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
            mysteriousrune,
            mysterypilot,
            mysticwool,
            nagacorsair,
            nagamyrmidon,
            nagarepellent,
            nagaseawitch,
            natpagle,
            natthedarkfisher,
            naturalize,
            nazrawildaxe,
            necroknight,
            necromancy,
            necroticaura,
            necroticpoison,
            needssharpening,
            nefarian,
            nefarianstrikes,
            neptulon,
            nerubarweblord,
            nerubian,
            nerubianegg,
            nerubianprophet,
            nerubiansoldier,
            nerubianspores,
            netherbloom,
            netherbreath,
            netherrage,
            netherspite,
            netherspitehistorian,
            newcalling,
            nexuschampionsaraad,
            nightbane,
            nightbanetemplar,
            nightblade,
            nightmare,
            nightsdevotion,
            noblesacrifice,
            noooooooooooo,
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
            obsidiandestroyer,
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
            oneeyedcheat,
            onfire,
            onthehunt,
            onyxbishop,
            onyxia,
            onyxiclaw,
            ooze,
            openthegates,
            opponentconcede,
            opponentdisconnect,
            optimism,
            orcwarrior,
            orgrimmaraspirant,
            orsisguard,
            overclock,
            overclocked,
            overloadedmechazod,
            overloading,
            pandarenscout,
            panther,
            pantherform,
            pantryspider,
            partyelemental,
            partyportal,
            patchesthepirate,
            patchwerk,
            patientassassin,
            pawn,
            pearlofthetides,
            perditionsblade,
            peruse,
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
            placeholdercard,
            plague,
            plate,
            platemailarmor,
            playerchoiceenchant,
            poisoncloud,
            poisonedblade,
            poisoneddagger,
            poisoneddaggers,
            poisonseeds,
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
            priestessofelune,
            priestofthefeast,
            primalfusion,
            primallyinfused,
            princemalchezaar,
            princesshuhuran,
            prioritize,
            prophetvelen,
            protectingthegallery,
            protecttheking,
            psychotron,
            publicdefender,
            puddlestomper,
            pure,
            purecold,
            purified,
            purify,
            putressed,
            putressvial,
            pyroblast,
            quartermaster,
            questingadventurer,
            quickshot,
            rachelledavis,
            rafaam,
            ragingworgen,
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
            rarespear,
            rascallyrunt,
            rat,
            ratpack,
            ravagingghoul,
            ravenholdtassassin,
            ravenidol,
            rawpower,
            razaenchant,
            razathechained,
            razorfenhunter,
            razorgore,
            razorgoresclaws,
            razorgoretheuntamed,
            recharge,
            recklessrocketeer,
            recombobulator,
            recruiter,
            recycle,
            redbeam,
            redemption,
            redmanawyrm,
            redportal,
            redridinghood,
            reflection,
            reflections,
            reforged,
            refreshmentvendor,
            reincarnate,
            reinforce,
            releasecoolant,
            releasetheaberrations,
            reliquaryseeker,
            removeallimmune,
            rendblackhand,
            renojackson,
            renouncedarkness,
            renouncedarknessdeckench,
            repairbot,
            repairs,
            repentance,
            restore1,
            restore5,
            restoreallhealth,
            resurrect,
            retribution,
            revealhand,
            revenge,
            reverberatinggong,
            reversingswitch,
            rexxar,
            rhonin,
            ricardorobaina,
            rivercrocolisk,
            riverpawgnoll,
            roaringtorch,
            robinfredericksen,
            robpardo,
            rock,
            rockbiterweapon,
            rockelemental,
            rockout,
            rodofthesun,
            roguesdoit,
            rollingboulder,
            romulo,
            rooted,
            rottenbanana,
            rumblingelemental,
            rummage,
            runeblade,
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
            sacredtrial,
            sacrificialpact,
            saddened,
            saddenedheroenchant,
            safe,
            saltydog,
            sap,
            sapling,
            sapphiron,
            savage,
            savagecombatant,
            savagemark,
            savageroar,
            savagery,
            savannahhighmane,
            scalednightmare,
            scarab,
            scarletcrusader,
            scarletpurifier,
            scavenginghyena,
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
            secretsofkarazhan,
            secretsofshadow,
            secretsofthecult,
            seethingstatue,
            selflesshero,
            senjinshieldmasta,
            sensedemons,
            sergeantsally,
            serratedshadows,
            servantofyoggsaron,
            servercrash,
            setallminionsto1health,
            sethealthto1,
            sethealthtofull,
            setthetable,
            seyilyoon,
            shadeofaran,
            shadeofnaxxramas,
            shadopanmonk,
            shadopanrider,
            shadowbeast,
            shadowbolt,
            shadowboltvolley,
            shadowbomber,
            shadowboxer,
            shadowcaster,
            shadowed,
            shadowfiend,
            shadowfiended,
            shadowflame,
            shadowform,
            shadowmadness,
            shadowofnothing,
            shadowoil,
            shadoworlight,
            shadowrager,
            shadowsensei,
            shadowsofmuru,
            shadowstep,
            shadowstrike,
            shadowtowergivemyminionsstealth,
            shadowtowerstealth,
            shadowvolley,
            shadowworddeath,
            shadowwordhorror,
            shadowwordpain,
            shadowy,
            shadydealer,
            shadydeals,
            shakuthecollector,
            shakyzipgunner,
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
            shipscannon,
            shiv,
            shotgunblast,
            shredderblade,
            shrinkmeister,
            shrinkray,
            shrunk,
            si7agent,
            sideshowspelleater,
            siegeengine,
            silence,
            silenceanddestroyallminions,
            silencedebug,
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
            sinisterpower,
            sinisterstrike,
            siphonsoul,
            sirfinleymrrgglton,
            sirzeliek,
            sizeincrease,
            skelesaurushex,
            skeletalsmith,
            skeleton,
            skeramcultist,
            skitter,
            skycapnkragg,
            slam,
            slaveofkelthuzad,
            sleepwiththefishes,
            slime,
            slimed,
            slitheringarcher,
            slitheringguard,
            sludgebelcher,
            smalltimebuccaneer,
            smalltimerecruits,
            smugglerscrate,
            smugglersrun,
            smuggling,
            snake,
            snakeball,
            snaketrap,
            sneedsoldshredder,
            snipe,
            snowchugger,
            soggoththeslitherer,
            solemnvigil,
            somany,
            sonicbreath,
            sonoftheflame,
            sootspewer,
            sorcerersapprentice,
            sorcerousdevotion,
            soulfire,
            souloftheforest,
            soulpower,
            soultap,
            southseacaptain,
            southseadeckhand,
            southseasquidface,
            sparringpartner,
            spawnofnzoth,
            spawnofshadows,
            spectralgothik,
            spectralknight,
            spectralrider,
            spectralspider,
            spectraltrainee,
            spectralwarrior,
            spellbender,
            spellbonus,
            spellbreaker,
            spellslinger,
            spider,
            spidertank,
            spikeddecoy,
            spikedhogrider,
            spines,
            spiritclaws,
            spiritwolf,
            spitefulsmith,
            spoon,
            spore,
            sporeburst,
            spreadingmadness,
            sprint,
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
            stampedingbeast,
            stampedingkodo,
            standagainstdarkness,
            standdown,
            starfall,
            starfire,
            starvingbuzzard,
            steadyshot,
            stealcard,
            steallife,
            steamwheedlesniper,
            stevengabriel,
            steward,
            stewardofdarkshire,
            stolengoods,
            stolenwintersveilgift,
            stomp,
            stoneclawtotem,
            stonescaleoil,
            stonesculpting,
            stoneskingargoyle,
            stonesplintertrogg,
            stonetuskboar,
            stormcrack,
            stormforgedaxe,
            stormpikecommando,
            stormwindchampion,
            stormwindknight,
            stranglethorntiger,
            streettrickster,
            streetwiseinvestigator,
            strengthofstormwind,
            strengthofthepack,
            succubus,
            sulfuras,
            summonapanther,
            summonarandomsecret,
            summonguardians,
            summoningportal,
            summoningstone,
            summonkilrek,
            sunfuryprotector,
            sunraiderphaerix,
            sunwalker,
            supercharge,
            supercharged,
            superiorpotion,
            susiesizzlesong,
            swashburglar,
            swingacross,
            swipe,
            switched,
            swordofjustice,
            swordsman,
            sylvanaswindrunner,
            tabbycat,
            tableset,
            tailswipe,
            taketheshortcut,
            tanarishogchopper,
            tankmode,
            tankup,
            targetdummy,
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
            terrifyingroar,
            terrifyingvisage,
            thaddius,
            thanekorthazz,
            thealchemist,
            theancientone,
            thebeast,
            theblackknight,
            theboogeymonster,
            thecoin,
            thecowking,
            thecrone,
            thecurator,
            thedarkness,
            theeye,
            thegrimygoons,
            thehorde,
            thejadelotus,
            thekabal,
            theking,
            themajordomo,
            themistcaller,
            theportalopens,
            therookery,
            thescoop,
            thesilverhand,
            theskeletonknight,
            thesongthatendstheworld,
            thesteelsentinel,
            thestormguardian,
            thetidalhand,
            thetruewarchief,
            thingfrombelow,
            thirstyblades,
            thistletea,
            thoughtsteal,
            thrall,
            thrallmarfarseer,
            throwrocks,
            thunderbluffvaliant,
            timberwolf,
            timeforsmash,
            timepieceofhorror,
            timerewinder,
            timerskine,
            tinkerssharpswordoil,
            tinkertowntechnician,
            tinkmasteroverspark,
            tinyknightofevil,
            tirionfordring,
            tolvirhoplite,
            tombpillager,
            tombspider,
            toshley,
            tossingplates,
            totemgolem,
            totemiccall,
            totemicmight,
            totemicslam,
            touchit,
            tournamentattendee,
            tournamentmedic,
            toxicsewerooze,
            toxitron,
            tracking,
            tradeprincegallywix,
            trained,
            training,
            trainingcomplete,
            transcendence,
            transformed,
            trapped,
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
            unbalancingstrike,
            unboundelemental,
            unchained,
            uncoverstaffpiece,
            undercityhuckster,
            undercityvaliant,
            understudy,
            undertaker,
            unearthedraptor,
            unholyshadow,
            unity,
            unleashthehounds,
            unlicensedapothecary,
            unrelentingrider,
            unrelentingtrainee,
            unrelentingwarrior,
            unstableghoul,
            unstableportal,
            upgrade,
            upgraded,
            upgradedrepairbot,
            uproot,
            uprooted,
            usherofsouls,
            utherlightbringer,
            v07tr0n,
            vaelastrasz,
            vaelastraszthecorrupt,
            valeerasanguinar,
            validateddoomsayer,
            vancleefsvengeance,
            vanish,
            vaporize,
            varianwrynn,
            vassalssubservience,
            velenschosen,
            vengeance,
            venturecomercenary,
            viciousswipe,
            victory,
            vilefininquisitor,
            villainy,
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
            voidterror,
            voidwalker,
            volcanicdrake,
            volcaniclumberer,
            volcanicpotion,
            voljin,
            voodoodoctor,
            wadethrough,
            wailingsoul,
            walkacrossgingerly,
            walterkong,
            wandawonderhooves,
            warbot,
            warded,
            warglaiveofazzinoth,
            wargolem,
            warhorsetrainer,
            warkodo,
            warsongcommander,
            watched,
            waterelemental,
            weallscream,
            weaponbuff,
            weaponbuffenchant,
            weaponnerf,
            weaponnerfenchant,
            weaponrack,
            weaseltunneler,
            webspinner,
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
            whitebishop,
            whiteeyes,
            whiteking,
            whiteknight,
            whitepawn,
            whitequeen,
            whiterook,
            whywontyoudie,
            wickedknife,
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
            wyrmrestagent,
            xarilpoisonedmind,
            yarrr,
            yoggsaronhopesend,
            yoggsaronsmagic,
            yoggsarontestauto,
            yoggsarontestmanual,
            yoggservantheroenchant,
            yongwoo,
            youngdragonhawk,
            youngpriestess,
            youthfulbrewmaster,
            ysera,
            yseraawakens,
            yserastear,
            yshaarjrageunbound,
            yshaarjsstrength,
            zealousinitiate,
            zinaar,
            zombiechow,
            zoobot,
            zwick
        }

        public cardName cardNamestringToEnum(string s)
        {
            CardDB.cardName NameEnum;
            if (Enum.TryParse<cardName>(s, false, out NameEnum)) return NameEnum;
            else
            {
                //if (s != "") Helpfunctions.Instance.ErrorLog("[CardDB] Unidentified card name: " + s);
                return CardDB.cardName.unknown;
            }
        }

        public enum ErrorType2
        {
            NONE = 0,
            REQ_MINION_TARGET = 1,
            REQ_FRIENDLY_TARGET = 2,
            REQ_ENEMY_TARGET = 3,
            REQ_DAMAGED_TARGET = 4,
            REQ_ENCHANTED_TARGET = 5,
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
            REQ_SECRET_CAP = 18,
            REQ_MINION_CAP_IF_TARGET_AVAILABLE = 19,
            REQ_MINION_CAP = 20,
            REQ_TARGET_ATTACKED_THIS_TURN = 21,
            REQ_TARGET_IF_AVAILABLE = 22,
            REQ_MINIMUM_ENEMY_MINIONS = 23,
            REQ_TARGET_FOR_COMBO = 24,
            REQ_NOT_EXHAUSTED_ACTIVATE = 25,
            REQ_UNIQUE_SECRET = 26,
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
            REQ_ENTIRE_ENTOURAGE_NOT_IN_PLAY = 44, //44 (totemic call)
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
            REQ_SECRET_CAP_FOR_NON_SECRET = 60,
            REQ_TARGET_EXACT_COST = 61,
            REQ_STEALTHED_TARGET = 62,
            REQ_MINION_SLOT_OR_MANA_CRYSTAL_SLOT = 63,
            REQ_DRAG_TO_PLAY = 64,
        }

        public class Card
        {
            //public string CardID = "";
            public cardName name = cardName.unknown;
            public TAG_RACE race = TAG_RACE.INVALID;
            public int rarity;
            public int cost;
            public int Class;
            public cardtype type = CardDB.cardtype.NONE;
            //public string description = "";

            public int Attack;
            public int Health;
            public int Durability;//for weapons
            public bool target;
            //public string targettext = "";
            public bool tank;
            public bool Silence;
            public bool choice;
            public bool windfury;
            public bool poisionous;
            public bool deathrattle;
            public bool battlecry;
            public bool discover;
            public bool oneTurnEffect;
            public bool Enrage;
            public bool Aura;
            public bool Elite;
            public bool Combo;
            public int overload;
            public bool Recall;
            public int recallValue;
            public bool immuneWhileAttacking;
            public bool immuneToSpellpowerg;
            public bool Stealth;
            public bool Freeze;
            public bool AdjacentBuff;
            public bool Shield;
            public bool Charge;
            public bool Secret;
            public bool Morph;
            public bool Spellpower;
            public bool GrantCharge;
            public bool HealTarget;
            public bool Inspire;
            //playRequirements, reqID= siehe PlayErrors->ErrorType
            public int needEmptyPlacesForPlaying;
            public int needWithMinAttackValueOf;
            public int needWithMaxAttackValueOf;
            public int needRaceForPlaying;
            public int needMinNumberOfEnemy;
            public int needMinTotalMinions;
            public int needMinOwnMinions;
            public int needMinionsCapIfAvailable;
            public int needControlaSecret = 0;


            //additional data
            public bool isToken;
            public int isCarddraw;
            public bool damagesTarget;
            public bool damagesTargetWithSpecial;
            public int targetPriority;
            public bool isSpecialMinion;

            public int spellpowervalue;
            public cardIDEnum cardIDenum = cardIDEnum.None;
            public List<ErrorType2> playrequires;
            public List<cardtrigers> trigers;

            public SimTemplate sim_card;
            public PenTemplate pen_card;

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
                this.GrantCharge = c.GrantCharge;
                this.HealTarget = c.HealTarget;
                this.Health = c.Health;
                this.immuneToSpellpowerg = c.immuneToSpellpowerg;
                this.immuneWhileAttacking = c.immuneWhileAttacking;
                this.Morph = c.Morph;
                this.name = c.name;
                this.needEmptyPlacesForPlaying = c.needEmptyPlacesForPlaying;
                this.needMinionsCapIfAvailable = c.needMinionsCapIfAvailable;
                this.needControlaSecret = c.needControlaSecret;
                this.needMinNumberOfEnemy = c.needMinNumberOfEnemy;
                this.needMinTotalMinions = c.needMinTotalMinions;
                this.needMinOwnMinions = c.needMinOwnMinions;
                this.needRaceForPlaying = c.needRaceForPlaying;
                this.needWithMaxAttackValueOf = c.needWithMaxAttackValueOf;
                this.needWithMinAttackValueOf = c.needWithMinAttackValueOf;
                this.oneTurnEffect = c.oneTurnEffect;
                this.playrequires = new List<ErrorType2>(c.playrequires);
                this.poisionous = c.poisionous;
                this.race = c.race;
                this.overload = c.overload;
                this.Recall = c.Recall;
                this.recallValue = c.recallValue;
                this.Secret = c.Secret;
                this.Shield = c.Shield;
                this.Silence = c.Silence;
                this.Spellpower = c.Spellpower;
                this.spellpowervalue = c.spellpowervalue;
                this.Stealth = c.Stealth;
                this.tank = c.tank;
                this.target = c.target;
                //this.targettext = c.targettext;
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
                if (this.type == CardDB.cardtype.MOB && ((own && p.ownMinions.Count >= 7) || (!own && p.enemyMinions.Count >=7))) return retval; // cant play mob, if we have already 7 minions
                if (this.Secret && ((own && (p.ownSecretsIDList.Contains(this.cardIDenum) || p.ownSecretsIDList.Count >= 5)) || (!own && p.enemySecretCount >= 5))) return retval;
                //if (p.mana < this.getManaCost(p, 1)) return retval;

                if (this.playrequires.Count == 0) { /*retval.Add(null);*/ return retval; }

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
                            if ((own ? p.ownWeaponDurability : p.enemyWeaponDurability) == 0) return retval;
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
                                if (p.enemyWeaponDurability > 0) targetEnemyHero = true;
                                else return retval;
                            }
                            else
                            {
                                if (p.ownWeaponDurability > 0) targetOwnHero = true;
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
                        //default:
                    }
                }

			    if(targetAll)
			    {
                    wereTargets = true;
                    if (targetAllFriendly != targetAllEnemy)
                    {
                        if(targetAllFriendly) targets.AddRange(p.ownMinions);
                        else targets.AddRange(p.enemyMinions);
                    }
                    else
                    {
                        targets.AddRange(p.ownMinions);
                        targets.AddRange(p.enemyMinions);
                    }
				    if(targetOnlyMinion)
				    {
                        targetEnemyHero = false;
                        targetOwnHero = false;
				    }
                    else
                    {
                        targetEnemyHero = true;
                        targetOwnHero = true;
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
                            if (m.handcard.card.race != (TAG_RACE)this.needRaceForPlaying) m.extraParam = true;
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
                    if (REQ_TARGET_WITH_DEATHRATTLE)
                    {
                        foreach (Minion m in targets)
                        {
                            if (!m.silenced && (m.handcard.card.deathrattle || m.deathrattle2 != null)) continue;
                            else m.extraParam = true;
                        }
                        targetOwnHero = false;
                        targetEnemyHero = false;
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
                        }
                        if (own) targetEnemyHero = true;
                        else targetOwnHero = true;
                    }
                    if (REQ_FROZEN_TARGET)
                    {
                        wereTargets = false;
                        foreach (Minion m in targets)
                        {
                            if (!m.frozen) m.extraParam = true;
                        }
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
                }

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

                //if (retval.Count == 0 && (!wereTargets || REQ_TARGET_IF_AVAILABLE)) retval.Add(null);

                return retval;
            }

            // todo sepefeets - merge 2 old functions with the new 1 
            /*
            public List<Minion> getTargetsForCard(Playfield p)
            {
                //todo make it faster!! 
                //todo remove the isRequirementInList with an big list of bools to ask the state of the bool
                bool addOwnHero = false;
                bool addEnemyHero = false;
                bool[] ownMins = new bool[p.ownMinions.Count];
                bool[] enemyMins = new bool[p.enemyMinions.Count];
                for (int i = 0; i < ownMins.Length; i++) ownMins[i] = false;
                for (int i = 0; i < enemyMins.Length; i++) enemyMins[i] = false;

                int k = 0;
                List<Minion> retval = new List<Minion>();

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_FOR_COMBO) && p.cardsPlayedThisTurn == 0) return retval;

                if ((isRequirementInList(CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE_AND_MINIMUM_FRIENDLY_MINIONS) && p.ownMinions.Count < this.needMinOwnMinions)) return retval;

                bool moreh = isRequirementInList(CardDB.ErrorType2.REQ_MINION_OR_ENEMY_HERO);
                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_TO_PLAY) || isRequirementInList(CardDB.ErrorType2.REQ_NONSELF_TARGET) || isRequirementInList(CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE) || isRequirementInList(CardDB.ErrorType2.REQ_TARGET_FOR_COMBO) || (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE_AND_MINIMUM_FRIENDLY_MINIONS) && p.ownMinions.Count >= this.needMinOwnMinions))
                {
                    addEnemyHero = true;
                    addOwnHero = true;

                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if ((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.cantBeTargetedBySpellsOrHeroPowers)) continue;
                        ownMins[k] = true;

                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.cantBeTargetedBySpellsOrHeroPowers)) || m.stealth) continue;
                        enemyMins[k] = true;
                    }

                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE_AND_DRAGON_IN_HAND))
                {
                    bool dragonInHand = false;
                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if (hc.card.race == TAG_RACE.DRAGON)
                        {
                            dragonInHand = true;
                            break;
                        }
                    }
                    if (dragonInHand == false) return retval;
                    //you have dragon on hand!
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if ((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.cantBeTargetedBySpellsOrHeroPowers)) continue;
                        ownMins[k] = true;

                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.cantBeTargetedBySpellsOrHeroPowers)) || m.stealth) continue;
                        enemyMins[k] = true;
                    }
                    addEnemyHero = true;
                    addOwnHero = true;

                }

                if (moreh)
                {
                    addEnemyHero = true;//moreh = req_minion_or_enemyHero
                    if (p.weHaveSteamwheedleSniper)
                    {
                        k = -1;
                        foreach (Minion m in p.ownMinions)
                        {
                            k++;
                            if ((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.cantBeTargetedBySpellsOrHeroPowers)) continue;
                            ownMins[k] = true;

                        }
                        k = -1;
                        foreach (Minion m in p.enemyMinions)
                        {
                            k++;
                            if (((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.cantBeTargetedBySpellsOrHeroPowers)) || m.stealth) continue;
                            enemyMins[k] = true;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_HERO_TARGET))
                {
                    for (int i = 0; i < ownMins.Length; i++) ownMins[i] = false;
                    for (int i = 0; i < enemyMins.Length; i++) enemyMins[i] = false;

                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_MINION_TARGET))
                {
                    addOwnHero = false;
                    addEnemyHero = false;
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_FRIENDLY_TARGET))
                {
                    addEnemyHero = false;
                    for (int i = 0; i < enemyMins.Length; i++) enemyMins[i] = false;
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_ENEMY_TARGET))
                {
                    addOwnHero = false;
                    for (int i = 0; i < ownMins.Length; i++) ownMins[i] = false;
                }


                if (isRequirementInList(CardDB.ErrorType2.REQ_LEGENDARY_TARGET))
                {
                    addOwnHero = false;
                    addEnemyHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if ((m.handcard.card.rarity < 5))
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if ((m.handcard.card.rarity < 5))
                        {
                            enemyMins[k] = false;
                        }
                    }
                }


                if (isRequirementInList(CardDB.ErrorType2.REQ_DAMAGED_TARGET))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (!m.wounded)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (!m.wounded)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_WITH_DEATHRATTLE))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if ( !(m.hasDeathrattle() || (m.handcard.card.deathrattle && !m.silenced) ))
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (!(m.hasDeathrattle() || (m.handcard.card.deathrattle && !m.silenced)))
                        {
                            enemyMins[k] = false;
                        }
                    }
                }
                

                if (isRequirementInList(CardDB.ErrorType2.REQ_UNDAMAGED_TARGET))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (m.wounded)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (m.wounded)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_MAX_ATTACK))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (m.Angr > this.needWithMaxAttackValueOf)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (m.Angr > this.needWithMaxAttackValueOf)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_MIN_ATTACK))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (m.Angr < this.needWithMinAttackValueOf)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (m.Angr < this.needWithMinAttackValueOf)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_WITH_RACE))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    addOwnHero = (p.ownHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON);
                    addEnemyHero = (p.enemyHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON);
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if ((m.handcard.card.race != (TAG_RACE)this.needRaceForPlaying))
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if ((m.handcard.card.race != (TAG_RACE)this.needRaceForPlaying))
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_MUST_TARGET_TAUNTER))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (!m.taunt)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (!m.taunt)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (addEnemyHero) retval.Add(p.enemyHero);
                if (addOwnHero) retval.Add(p.ownHero);

                k = -1;
                foreach (Minion m in p.ownMinions)
                {
                    k++;
                    if (ownMins[k]) retval.Add(m);
                }
                k = -1;
                foreach (Minion m in p.enemyMinions)
                {
                    k++;
                    if (enemyMins[k]) retval.Add(m);
                }

                return retval;

            }

            public List<Minion> getTargetsForCardEnemy(Playfield p)
            {
                //todo make it faster!! 
                //todo remove the isRequirementInList with an big list of bools to ask the state of the bool
                bool addOwnHero = false;
                bool addEnemyHero = false;
                bool[] ownMins = new bool[p.ownMinions.Count];
                bool[] enemyMins = new bool[p.enemyMinions.Count];
                for (int i = 0; i < ownMins.Length; i++) ownMins[i] = false;
                for (int i = 0; i < enemyMins.Length; i++) enemyMins[i] = false;

                int k = 0;
                List<Minion> retval = new List<Minion>();

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_FOR_COMBO) && p.cardsPlayedThisTurn == 0) return retval;

                bool moreh = isRequirementInList(CardDB.ErrorType2.REQ_MINION_OR_ENEMY_HERO);
                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_TO_PLAY) || isRequirementInList(CardDB.ErrorType2.REQ_NONSELF_TARGET) || isRequirementInList(CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE) || isRequirementInList(CardDB.ErrorType2.REQ_TARGET_FOR_COMBO))
                {
                    addEnemyHero = true;
                    addOwnHero = true;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.cantBeTargetedBySpellsOrHeroPowers)) || m.stealth) continue;
                        ownMins[k] = true;

                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if ((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.cantBeTargetedBySpellsOrHeroPowers)) continue;
                        enemyMins[k] = true;
                    }

                }

                if (moreh)
                {
                    addOwnHero = true;

                    if (p.enemyHaveSteamwheedleSniper)
                    {
                        k = -1;
                        foreach (Minion m in p.ownMinions)
                        {
                            k++;
                            if (((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.cantBeTargetedBySpellsOrHeroPowers)) || m.stealth) continue;
                            ownMins[k] = true;

                        }

                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_HERO_TARGET))
                {
                    for (int i = 0; i < ownMins.Length; i++) ownMins[i] = false;
                    for (int i = 0; i < enemyMins.Length; i++) enemyMins[i] = false;

                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_MINION_TARGET))
                {
                    addOwnHero = false;
                    addEnemyHero = false;
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_FRIENDLY_TARGET))
                {
                    addOwnHero = false;
                    for (int i = 0; i < ownMins.Length; i++) ownMins[i] = false;

                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_ENEMY_TARGET))
                {
                    addEnemyHero = false;
                    for (int i = 0; i < enemyMins.Length; i++) enemyMins[i] = false;
                }


                if (isRequirementInList(CardDB.ErrorType2.REQ_LEGENDARY_TARGET))
                {
                    addOwnHero = false;
                    addEnemyHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if ((m.handcard.card.rarity < 5))
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if ((m.handcard.card.rarity < 5))
                        {
                            enemyMins[k] = false;
                        }
                    }
                }



                if (isRequirementInList(CardDB.ErrorType2.REQ_DAMAGED_TARGET))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (!m.wounded)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (!m.wounded)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_UNDAMAGED_TARGET))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (m.wounded)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (m.wounded)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_MAX_ATTACK))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (m.Angr > this.needWithMaxAttackValueOf)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (m.Angr > this.needWithMaxAttackValueOf)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_MIN_ATTACK))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (m.Angr < this.needWithMinAttackValueOf)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (m.Angr < this.needWithMinAttackValueOf)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_WITH_RACE))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    addOwnHero = (p.ownHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON);
                    addEnemyHero = (p.enemyHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON);
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if ((m.handcard.card.race != (TAG_RACE)this.needRaceForPlaying))
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if ((m.handcard.card.race != (TAG_RACE)this.needRaceForPlaying))
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_MUST_TARGET_TAUNTER))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (!m.taunt)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (!m.taunt)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (addEnemyHero) retval.Add(p.enemyHero);
                if (addOwnHero) retval.Add(p.ownHero);

                k = -1;
                foreach (Minion m in p.ownMinions)
                {
                    k++;
                    if (ownMins[k]) retval.Add(m);
                }
                k = -1;
                foreach (Minion m in p.enemyMinions)
                {
                    k++;
                    if (enemyMins[k]) retval.Add(m);
                }

                return retval;

            }*/

            public int calculateManaCost(Playfield p)//calculates the mana from orginal mana, needed for back-to hand effects and new draw
            {
                int retval = this.cost;
                int offset = 0;

                if (p.anzOwnShadowfiends > 0) offset -= p.anzOwnShadowfiends;

                switch (this.type)
                {
                    case cardtype.MOB:
                        if (p.anzOwnAviana > 0) retval = 1;

                        offset += p.anzVentureCoMercenary * 3;

                        offset += p.anzManaWraith;

                        int temp = -(p.anzSummoningPortal) * 2;
                        if (retval + temp <= 0) temp = -retval + 1;
                        offset = offset + temp;

                        if (p.mobsPlayedThisTurn == 0)
                        {
                            offset -= p.anzPintSizedSummoner;
                        }

                        if (this.battlecry)
                        {
                            offset += p.anzNerubarWeblord * 2;
                        }

                        if ((TAG_RACE)this.race == TAG_RACE.MECHANICAL)
                        { //if the number of zauberlehrlings change
                            offset -= p.anzOwnMechwarper;
                        }
                        break;
                    case cardtype.SPELL:
                        if (p.nextSpellThisTurnCost0) return 0;
                        offset -= p.anzOwnSorcerersApprentice;
                        offset -= p.allSpellCostLess;
                        if (p.playedPreparation)
                        { //if the number of zauberlehrlings change
                            offset -= 3;
                        }
                        break;
                    case cardtype.WEAPON:
                        offset -= p.anzBlackwaterPirate * 2;
                        break;
                }

                offset -= p.myCardsCostLess;

                switch (this.name)
                {
                    case CardDB.cardName.wildmagic:
                        retval = offset;
                        break;
                    case CardDB.cardName.dreadcorsair:
                        retval = retval + offset - p.ownWeaponAttack;
                        break;
                    case CardDB.cardName.volcanicdrake:
                        retval = retval + offset - p.ownMinionsDiedTurn - p.enemyMinionsDiedTurn;
                        break;
                    case CardDB.cardName.thingfrombelow:
                        retval = retval + offset - p.tempTrigger.ownTotemSummoned;
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
                        retval = retval + offset - p.ownSpellsPlayedThisGame;
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

            public int getManaCost(Playfield p, int currentcost)//calculates mana from cleaned up mana!
            {
                int retval = currentcost;

                int offset = 0; // if offset < 0 costs become lower, if >0 costs are higher at the end

                // CARDS that increase/decrease the manacosts of others ##############################
                switch (this.type)
                {
                    case cardtype.HEROPWR:                        
                        if (p.anzOwnMaidenOfTheLake >= 1)
                        {
                            retval = 1;
                        }

                        if (p.anzOwnFencingCoach >= 1)
                        {
                            retval -= 2 * p.anzOwnFencingCoach;
                        }

                        retval += (p.isOwnTurn) ? p.anzEnemySaboteur * 5 : p.anzOwnSaboteur * 5;

                        break;
                    case cardtype.MOB:
                        //Manacosts changes with Venture Co. Mercenary
                        offset += p.anzVentureCoMercenary * 3;
                        //Manacosts changes with mana wraith
                        offset += p.anzManaWraith;

                        if (this.battlecry)
                        {
                            offset += p.anzNerubarWeblord * 2;
                        }

                        //Manacosts changes with the summoning-portal >_>
                        if (p.anzSummoningPortal >= 1)
                        {
                            int temp = -p.anzSummoningPortal * 2;
                            if (retval >= 1 && retval + temp <= 0) temp = -retval + 1;
                            offset = offset + temp;
                        }

                        //Manacosts changes with the pint-sized summoner
                        if (p.mobsPlayedThisTurn == 0)
                        {
                            offset -= p.anzPintSizedSummoner;
                        }

                        //manacosts changes with Mechwarper
                        if ((TAG_RACE)this.race == TAG_RACE.MECHANICAL)
                        {
                            offset -= p.anzOwnMechwarper;
                        }

                        if (p.anzOwnAviana > 0)
                        {
                            retval = 1;
                        }

                        if (this.type == cardtype.MOB && this.race == TAG_RACE.DRAGON)
                        {
                            retval -= (p.isOwnTurn) ? p.anzOwnDragonConsort * 2 : p.anzEnemyDragonConsort * 2;
                        }
                        break;
                    case cardtype.SPELL:
                        //Manacosts changes with the Sorcerer's Apprentice
                        offset -= p.anzOwnSorcerersApprentice;
                        
                        //manacosts are lowered, after we played preparation
                        if (p.playedPreparation)
                        {
                            offset -= 3;
                        }
                        
                        //loatheb
                        retval += (p.isOwnTurn) ? p.anzEnemyLoatheb * 5 : p.anzOwnLoatheb * 5;

                        //millhouse
                        if ((p.isOwnTurn && p.anzEnemyMillhouseManastorm) || (!p.isOwnTurn && p.anzOwnMillhouseManastorm))
                        {
                            retval = 0;
                        }

                        break;
                    case cardtype.WEAPON:
                        offset += p.anzBlackwaterPirate * 2;
                        break;
                }
                
                if ((this.type == cardtype.MOB || this.type == cardtype.SPELL || this.type == cardtype.WEAPON) && p.anzOwnNagaSeaWitch >= 1)
                {
                    retval = 5;
                }
                
                // CARDS that decrease their own manacosts ##############################
                switch (this.name)
                {
                    case CardDB.cardName.frostgiant:
                        retval = retval + offset - p.ownHeroPowerUses;
                        break;
                    case CardDB.cardName.arcanegiant:
                        retval = retval + offset - p.ownSpellsPlayedThisGame;
                        break;
                    case CardDB.cardName.kabalcrystalrunner:
                        retval = retval + offset - 2 * p.secretsplayedSinceRecalc;
                        break;
                    case CardDB.cardName.secondratebruiser:
                        retval = retval + offset - ((p.enemyMinions.Count < 3) ? 0 : 2) + ((p.enemyMobsCountStarted < 3) ? 0 : 2);
                        break;
                    case CardDB.cardName.skycapnkragg:
                        int pirates = 0;
                        foreach (Minion m in p.ownMinions)
                        {
                            if (m.handcard.card.race == TAG_RACE.PIRATE) pirates++;
                        }
                        retval = retval + offset - pirates;
                        break;
                    case CardDB.cardName.thingfrombelow:
                        retval = retval + offset - p.tempTrigger.ownTotemSummoned;
                        break;
                    case CardDB.cardName.knightofthewild:
                        retval = retval + offset - p.tempTrigger.ownBeastSummoned;
                        break;
                    case CardDB.cardName.dreadcorsair:
                        retval = retval + offset - p.ownWeaponAttack;
                        break;
                    case CardDB.cardName.seagiant:
                        retval = retval + offset - p.ownMinions.Count - p.enemyMinions.Count + p.ownMobsCountStarted + p.enemyMobsCountStarted;
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
                    case CardDB.cardName.crush:
                        // cost 4 less if we have a dmged minion
                        retval = retval + offset;
                        bool dmgedminions = false;
                        foreach (Minion m in p.ownMinions)
                        {
                            if (m.wounded) dmgedminions = true;
                        }
                        if (dmgedminions)
                        {
                            retval -= 4;
                        }
                        break;

                    //Costs (1) less for each minion that died this turn. - cards:
                    // dont forget to add them in    Handmanager->setHandcards !!!
                    case CardDB.cardName.volcanicdrake:
                    case CardDB.cardName.volcaniclumberer:
                    case CardDB.cardName.dragonsbreath:
                    case CardDB.cardName.solemnvigil:
                        retval = retval - p.anzMinionsDiedThisTurn;
                        break;
                    case CardDB.cardName.everyfinisawesome:
                        int murlocs = 0;
                        foreach (Minion m in p.ownMinions)
                        {
                            if (m.handcard.card.race == TAG_RACE.MURLOC)
                            {
                                murlocs++;
                            }
                        }
                        retval = retval - murlocs;
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

            //calculate the manacosts without the changing effects
            //we calculate the "orginal"-manacosts, because we dont know of effects like icetrap, prep and stuff
            public int getStartManaCosts(Playfield p, int currentcost) //only call this with p = new Playfield()!
            {
                int retval = currentcost;

                int offset = 0; // if offset < 0 costs become lower, if >0 costs are higher at the end

                // CARDS that increase the manacosts of others ##############################

                if (this.type == cardtype.MOB)
                {

                    //Manacosts changes with soeldner der venture co.
                    offset += -p.anzVentureCoMercenary * 3;
                    //Manacosts changes with mana-ghost
                    offset += -p.anzManaWraith;
                    //weblord
                    if (this.battlecry)
                    {
                        offset += -p.anzNerubarWeblord * 2;
                    }

                    if (p.anzOwnAviana >= 1)
                    {
                        offset += this.cost - 1;
                    }
                    else
                    {
                        if (p.anzOwnNagaSeaWitch >= 1)
                        {
                            offset += this.cost - 5;
                        }
                    }
                }
                else  //nagaseawitch for other cards
                {
                    if (p.anzOwnNagaSeaWitch >= 1)
                    {
                        offset += this.cost - 5;
                    }
                }

                

                // CARDS that decrease the manacosts of others ##############################

                if (this.type == cardtype.MOB)
                {

                    //Manacosts changes with the summoning-portal >_>
                    //cant lower the mana to 0
                    offset += p.anzSummoningPortal * 2;

                    //Manacosts changes with the pint-sized summoner
                    if (p.mobsPlayedThisTurn == 0)
                    {
                        offset += p.anzPintSizedSummoner;
                    }

                    //manacosts changes with Mechwarper
                    if ((TAG_RACE)this.race == TAG_RACE.MECHANICAL)
                    {
                        offset += p.anzOwnMechwarper;
                    }
                }


                if (this.type == cardtype.SPELL)
                {

                    //manacosts are lowered, after we played preparation
                    if (p.playedPreparation)
                    {
                        offset += 3;
                    }

                    //Manacosts changes with the zauberlehrling summoner
                    offset += p.anzOwnSorcerersApprentice;

                }


                switch (this.name)
                {

                    case CardDB.cardName.frostgiant:
                        retval = retval + offset + p.ownHeroPowerUses;
                        break;
                    case CardDB.cardName.arcanegiant:
                        retval = retval + offset - p.ownSpellsPlayedThisGame;
                        break;
                    case CardDB.cardName.skycapnkragg:
                        int pirates = 0;
                        foreach (Minion m in p.ownMinions)
                        {
                            if (m.handcard.card.race == TAG_RACE.PIRATE) pirates++;
                        }
                        retval = retval + offset + pirates;
                        break;
                    case CardDB.cardName.dreadcorsair:
                        retval = retval + offset + p.ownWeaponAttack;
                        break;
                    case CardDB.cardName.seagiant:
                        retval = retval + offset + p.ownMinions.Count + p.enemyMinions.Count;
                        break;
                    case CardDB.cardName.mountaingiant:
                        retval = retval + offset + p.owncards.Count;
                        break;
                    case CardDB.cardName.clockworkgiant:
                        retval = retval + offset + p.enemyAnzCards;
                        break;
                    case CardDB.cardName.moltengiant:
                        retval = retval + offset + p.ownHero.Hp;
                        break;
                    case CardDB.cardName.crush:
                        // cost 4 less if we have a dmged minion
                        bool dmgedminions = false;
                        foreach (Minion m in p.ownMinions)
                        {
                            if (m.wounded) dmgedminions = true;
                        }
                        if (dmgedminions) retval = retval + offset + 4;
                        break;

                    //Cards with effect: Costs (1) less for each minion that died this turn.
                    case CardDB.cardName.volcanicdrake:
                    case CardDB.cardName.volcaniclumberer:
                    case CardDB.cardName.dragonsbreath:
                    case CardDB.cardName.solemnvigil:
                        retval = retval + p.anzMinionsDiedThisTurn;
                        break;
                    default:
                        retval = retval + offset;
                        break;
                }

                if (this.Secret && (p.anzOwnCloakedHuntress > 0 || p.nextSecretThisTurnCost0))
                {
                    retval = this.cost;
                }

                if (this.type == cardtype.MOB && this.race == TAG_RACE.DRAGON)
                {
                    retval += (p.isOwnTurn) ? p.anzOwnDragonConsort * 2 : p.anzEnemyDragonConsort * 2;
                }

                if (this.type == cardtype.SPELL)
                {
                    retval -= (p.isOwnTurn) ? p.anzEnemyLoatheb * 5 : p.anzOwnLoatheb * 5;
                }

                if (this.type == cardtype.SPELL && ((p.isOwnTurn && p.anzEnemyMillhouseManastorm) || (!p.isOwnTurn && p.anzOwnMillhouseManastorm)))
                {
                    retval = this.cost;
                }

                retval = Math.Max(0, retval);

                return retval;
            }

            public bool canplayCard(Playfield p, int manacost)
            {
                //is playrequirement?
                bool haveToDoRequires = isRequirementInList(CardDB.ErrorType2.REQ_TARGET_TO_PLAY);
                // cant play if i have to few mana

                if (p.mana < this.getManaCost(p, manacost)) return false;

                // cant play mob, if i have allready 7 mininos
                if (this.type == CardDB.cardtype.MOB && p.ownMinions.Count >= 7) return false;

                if (isRequirementInList(CardDB.ErrorType2.REQ_MINIMUM_ENEMY_MINIONS))
                {
                    if (p.enemyMinions.Count < this.needMinNumberOfEnemy) return false;
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_FRIENDLY_MINION_DIED_THIS_GAME))
                {
                    if (Probabilitymaker.Instance.anzMinionSinGrave == 0) return false;
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_NUM_MINION_SLOTS))
                {
                    if (p.ownMinions.Count > 7 - this.needEmptyPlacesForPlaying) return false;
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_WEAPON_EQUIPPED))
                {
                    if (p.ownWeaponName == CardDB.cardName.unknown) return false;
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_MINIMUM_TOTAL_MINIONS))
                {
                    if (this.needMinTotalMinions > p.ownMinions.Count + p.enemyMinions.Count) return false;
                }



                if (haveToDoRequires)
                {
                    if (this.getTargetsForCard(p, false, true).Count == 0) return false;

                    //it requires a target-> return false if 
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE) && isRequirementInList(CardDB.ErrorType2.REQ_MINION_CAP_IF_TARGET_AVAILABLE))
                {
                    if (this.getTargetsForCard(p, false, true).Count >= 1 && p.ownMinions.Count > 7 - this.needMinionsCapIfAvailable) return false;
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_ENTIRE_ENTOURAGE_NOT_IN_PLAY))
                {
                    int difftotem = 0;
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.name == CardDB.cardName.healingtotem || m.name == CardDB.cardName.wrathofairtotem || m.name == CardDB.cardName.searingtotem || m.name == CardDB.cardName.stoneclawtotem) difftotem++;
                    }
                    if (difftotem == 4) return false;
                }


                if (this.Secret)
                {
                    if (p.ownSecretsIDList.Contains(this.cardIDenum)) return false;
                    if (p.ownSecretsIDList.Count >= 5) return false;
                }



                return true;
            }



        }

        List<string> namelist = new List<string>();
        List<Card> cardlist = new List<Card>();
        Dictionary<cardIDEnum, Card> cardidToCardList = new Dictionary<cardIDEnum, Card>();
        List<string> allCardIDS = new List<string>();
        public Card unknownCard;
        public bool installedWrong;

        public Card teacherminion;
        public Card illidanminion;
        public Card lepergnome;
        public Card burlyrockjaw;
        public Card grimpatron;
        public Card whelp2a1h;
        public Card imp;
        public Card ligthningJolt;

        private static CardDB instance;

        public static CardDB Instance //todo clean up this singleton too
        {
            get
            {
                if (instance == null)
                {
                    instance = new CardDB();
                    //instance.enumCreator();// only call this to get latest cardids

                    // have to do it 2 times or the kids inside the simcards will not have a simcard :D
                    foreach (Card c in instance.cardlist)
                    {
                        c.sim_card = instance.getSimCard(c.cardIDenum);
                        c.pen_card = instance.getPenCard(c.cardIDenum);
                    }
                    instance.setAdditionalData();
                }
                return instance;
            }
        }

        private CardDB()
        {
            string[] lines = new string[] { };
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
            //placeholdercard
            Card plchldr = new Card
            {
                name = cardName.unknown,
                cost = 1000,
                sim_card = new SimTemplate(),
                pen_card = new PenTemplate()
            };
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
                    string temp = s.Split(new string[] { "CardID=\"" }, StringSplitOptions.None)[1];
                    temp = temp.Replace("\">", "");
                    //c.CardID = temp;
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
                    if (temp.Equals("AT_132_SHAMAN")) c.choice = true; // its a choice card

                    //if (c.isToken) Helpfunctions.Instance.ErrorLog(temp +" is token");

                    continue;
                }
                /*
                if (s.Contains("<Entity version=\"1\" CardID=\""))
                {
                    c = new Card();
                    de = 0;
                    string temp = s.Replace("<Entity version=\"1\" CardID=\"", "");
                    temp = temp.Replace("\">", "");
                    //c.CardID = temp;
                    allCardIDS.Add(temp);
                    c.cardIDenum = this.cardIdstringToEnum(temp);
                    continue;
                }*/

                //health
                if (s.Contains("<Tag enumID=\"45\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.Health = Convert.ToInt32(temp);
                    continue;
                }

                //Class
                if (s.Contains("Tag enumID=\"199\"")) //added fopr sake of figure out which class it belongs too... sorry adds a little more data
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
                    c.race = (TAG_RACE)Convert.ToInt32(temp);
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

                    if (temp.Contains("overload"))
                    {
                        try
                        {
                            c.overload = Convert.ToInt32(temp.Split('(', ')')[1]);
                            //Helpfunctions.Instance.ErrorLog("CardDB - Card: " + c.cardIDenum + " Overload: " + c.overload);
                        }
                        catch
                        {

                        }
                    }

                    continue;
                }
                //targetingarrowtext
                if (s.Contains("<Tag enumID=\"325\""))
                {

                    string temp = s.Split(new string[] { "type=\"String\">" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split(new string[] { "</Tag>" }, StringSplitOptions.RemoveEmptyEntries)[0];
                    temp = temp.Replace("&lt;", "");
                    temp = temp.Replace("b&gt;", "");
                    temp = temp.Replace("/b&gt;", "");
                    temp = temp.ToLower(new System.Globalization.CultureInfo("en-US", false));

                    c.target = true;
                    continue;
                }


                //poisonous
                if (s.Contains("<Tag enumID=\"363\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.poisionous = true;
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
                //immunetospellpower
                if (s.Contains("<Tag enumID=\"349\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.immuneToSpellpowerg = true;
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
                //grantcharge
                if (s.Contains("<Tag enumID=\"355\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.GrantCharge = true;
                    continue;
                }
                //healtarget
                if (s.Contains("<Tag enumID=\"361\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.HealTarget = true;
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
                        if (char.IsDigit(temp, 0))
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
            }

            this.teacherminion = this.getCardDataFromID(CardDB.cardIDEnum.NEW1_026t);
            this.illidanminion = this.getCardDataFromID(CardDB.cardIDEnum.EX1_614t);
            this.lepergnome = this.getCardDataFromID(CardDB.cardIDEnum.EX1_029);
            this.burlyrockjaw = this.getCardDataFromID(CardDB.cardIDEnum.GVG_068);
            this.grimpatron = this.getCardDataFromID(CardDB.cardIDEnum.BRM_019);
            this.whelp2a1h = this.getCardDataFromID(CardDB.cardIDEnum.BRM_022t);//whelptoken from blackrock
            this.imp = this.getCardDataFromID(CardDB.cardIDEnum.BRM_006t);//imp from blackrock
            this.ligthningJolt = this.getCardDataFromID(CardDB.cardIDEnum.AT_050t);//deal 2 dmg hero power

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
                case cardIDEnum.AT_001: return new Sim_AT_001();
                case cardIDEnum.AT_002: return new Sim_AT_002();
                case cardIDEnum.AT_003: return new Sim_AT_003();
                case cardIDEnum.AT_004: return new Sim_AT_004();
                case cardIDEnum.AT_005: return new Sim_AT_005();
                case cardIDEnum.AT_005t: return new Sim_AT_005t();
                case cardIDEnum.AT_006: return new Sim_AT_006();
                case cardIDEnum.AT_007: return new Sim_AT_007();
                case cardIDEnum.AT_008: return new Sim_AT_008();
                case cardIDEnum.AT_009: return new Sim_AT_009();
                case cardIDEnum.AT_010: return new Sim_AT_010();
                case cardIDEnum.AT_011: return new Sim_AT_011();
                case cardIDEnum.AT_012: return new Sim_AT_012();
                case cardIDEnum.AT_013: return new Sim_AT_013();
                case cardIDEnum.AT_014: return new Sim_AT_014();
                case cardIDEnum.AT_015: return new Sim_AT_015();
                case cardIDEnum.AT_016: return new Sim_AT_016();
                case cardIDEnum.AT_017: return new Sim_AT_017();
                case cardIDEnum.AT_018: return new Sim_AT_018();
                case cardIDEnum.AT_019: return new Sim_AT_019();
                case cardIDEnum.AT_020: return new Sim_AT_020();
                case cardIDEnum.AT_021: return new Sim_AT_021();
                case cardIDEnum.AT_022: return new Sim_AT_022();
                case cardIDEnum.AT_023: return new Sim_AT_023();
                case cardIDEnum.AT_024: return new Sim_AT_024();
                case cardIDEnum.AT_025: return new Sim_AT_025();
                case cardIDEnum.AT_026: return new Sim_AT_026();
                case cardIDEnum.AT_027: return new Sim_AT_027();
                case cardIDEnum.AT_028: return new Sim_AT_028();
                case cardIDEnum.AT_029: return new Sim_AT_029();
                case cardIDEnum.AT_030: return new Sim_AT_030();
                case cardIDEnum.AT_031: return new Sim_AT_031();
                case cardIDEnum.AT_032: return new Sim_AT_032();
                case cardIDEnum.AT_033: return new Sim_AT_033();
                case cardIDEnum.AT_034: return new Sim_AT_034();
                case cardIDEnum.AT_035: return new Sim_AT_035();
                case cardIDEnum.AT_035t: return new Sim_AT_035t();
                case cardIDEnum.AT_036: return new Sim_AT_036();
                case cardIDEnum.AT_036t: return new Sim_AT_036t();
                case cardIDEnum.AT_037: return new Sim_AT_037();
                case cardIDEnum.AT_037a: return new Sim_AT_037a();
                case cardIDEnum.AT_037b: return new Sim_AT_037b();
                case cardIDEnum.AT_037t: return new Sim_AT_037t();
                case cardIDEnum.AT_038: return new Sim_AT_038();
                case cardIDEnum.AT_039: return new Sim_AT_039();
                case cardIDEnum.AT_040: return new Sim_AT_040();
                case cardIDEnum.AT_041: return new Sim_AT_041();
                case cardIDEnum.AT_042: return new Sim_AT_042();
                case cardIDEnum.AT_042a: return new Sim_AT_042a();
                case cardIDEnum.AT_042b: return new Sim_AT_042b();
                case cardIDEnum.AT_042t2: return new Sim_AT_042t2();
                case cardIDEnum.AT_042t: return new Sim_AT_042t();
                case cardIDEnum.AT_043: return new Sim_AT_043();
                case cardIDEnum.AT_044: return new Sim_AT_044();
                case cardIDEnum.AT_045: return new Sim_AT_045();
                case cardIDEnum.AT_046: return new Sim_AT_046();
                case cardIDEnum.AT_047: return new Sim_AT_047();
                case cardIDEnum.AT_048: return new Sim_AT_048();
                case cardIDEnum.AT_049: return new Sim_AT_049();
                case cardIDEnum.AT_050: return new Sim_AT_050();
                case cardIDEnum.AT_050t: return new Sim_AT_050t();
                case cardIDEnum.AT_051: return new Sim_AT_051();
                case cardIDEnum.AT_052: return new Sim_AT_052();
                case cardIDEnum.AT_053: return new Sim_AT_053();
                case cardIDEnum.AT_054: return new Sim_AT_054();
                case cardIDEnum.AT_055: return new Sim_AT_055();
                case cardIDEnum.AT_056: return new Sim_AT_056();
                case cardIDEnum.AT_057: return new Sim_AT_057();
                case cardIDEnum.AT_058: return new Sim_AT_058();
                case cardIDEnum.AT_059: return new Sim_AT_059();
                case cardIDEnum.AT_060: return new Sim_AT_060();
                case cardIDEnum.AT_061: return new Sim_AT_061();
                case cardIDEnum.AT_062: return new Sim_AT_062();
                case cardIDEnum.AT_063: return new Sim_AT_063();
                case cardIDEnum.AT_063t: return new Sim_AT_063t();
                case cardIDEnum.AT_064: return new Sim_AT_064();
                case cardIDEnum.AT_065: return new Sim_AT_065();
                case cardIDEnum.AT_066: return new Sim_AT_066();
                case cardIDEnum.AT_067: return new Sim_AT_067();
                case cardIDEnum.AT_068: return new Sim_AT_068();
                case cardIDEnum.AT_069: return new Sim_AT_069();
                case cardIDEnum.AT_070: return new Sim_AT_070();
                case cardIDEnum.AT_071: return new Sim_AT_071();
                case cardIDEnum.AT_072: return new Sim_AT_072();
                case cardIDEnum.AT_073: return new Sim_AT_073();
                case cardIDEnum.AT_074: return new Sim_AT_074();
                case cardIDEnum.AT_075: return new Sim_AT_075();
                case cardIDEnum.AT_076: return new Sim_AT_076();
                case cardIDEnum.AT_077: return new Sim_AT_077();
                case cardIDEnum.AT_078: return new Sim_AT_078();
                case cardIDEnum.AT_079: return new Sim_AT_079();
                case cardIDEnum.AT_080: return new Sim_AT_080();
                case cardIDEnum.AT_081: return new Sim_AT_081();
                case cardIDEnum.AT_082: return new Sim_AT_082();
                case cardIDEnum.AT_083: return new Sim_AT_083();
                case cardIDEnum.AT_084: return new Sim_AT_084();
                case cardIDEnum.AT_085: return new Sim_AT_085();
                case cardIDEnum.AT_086: return new Sim_AT_086();
                case cardIDEnum.AT_087: return new Sim_AT_087();
                case cardIDEnum.AT_088: return new Sim_AT_088();
                case cardIDEnum.AT_089: return new Sim_AT_089();
                case cardIDEnum.AT_090: return new Sim_AT_090();
                case cardIDEnum.AT_091: return new Sim_AT_091();
                case cardIDEnum.AT_092: return new Sim_AT_092();
                case cardIDEnum.AT_093: return new Sim_AT_093();
                case cardIDEnum.AT_094: return new Sim_AT_094();
                case cardIDEnum.AT_095: return new Sim_AT_095();
                case cardIDEnum.AT_096: return new Sim_AT_096();
                case cardIDEnum.AT_097: return new Sim_AT_097();
                case cardIDEnum.AT_098: return new Sim_AT_098();
                case cardIDEnum.AT_099: return new Sim_AT_099();
                case cardIDEnum.AT_099t: return new Sim_AT_099t();
                case cardIDEnum.AT_100: return new Sim_AT_100();
                case cardIDEnum.AT_101: return new Sim_AT_101();
                case cardIDEnum.AT_102: return new Sim_AT_102();
                case cardIDEnum.AT_103: return new Sim_AT_103();
                case cardIDEnum.AT_104: return new Sim_AT_104();
                case cardIDEnum.AT_105: return new Sim_AT_105();
                case cardIDEnum.AT_106: return new Sim_AT_106();
                case cardIDEnum.AT_108: return new Sim_AT_108();
                case cardIDEnum.AT_109: return new Sim_AT_109();
                case cardIDEnum.AT_110: return new Sim_AT_110();
                case cardIDEnum.AT_111: return new Sim_AT_111();
                case cardIDEnum.AT_112: return new Sim_AT_112();
                case cardIDEnum.AT_113: return new Sim_AT_113();
                case cardIDEnum.AT_114: return new Sim_AT_114();
                case cardIDEnum.AT_115: return new Sim_AT_115();
                case cardIDEnum.AT_116: return new Sim_AT_116();
                case cardIDEnum.AT_117: return new Sim_AT_117();
                case cardIDEnum.AT_118: return new Sim_AT_118();
                case cardIDEnum.AT_119: return new Sim_AT_119();
                case cardIDEnum.AT_120: return new Sim_AT_120();
                case cardIDEnum.AT_121: return new Sim_AT_121();
                case cardIDEnum.AT_122: return new Sim_AT_122();
                case cardIDEnum.AT_123: return new Sim_AT_123();
                case cardIDEnum.AT_124: return new Sim_AT_124();
                case cardIDEnum.AT_125: return new Sim_AT_125();
                case cardIDEnum.AT_127: return new Sim_AT_127();
                case cardIDEnum.AT_128: return new Sim_AT_128();
                case cardIDEnum.AT_129: return new Sim_AT_129();
                case cardIDEnum.AT_130: return new Sim_AT_130();
                case cardIDEnum.AT_131: return new Sim_AT_131();
                case cardIDEnum.AT_132: return new Sim_AT_132();
                case cardIDEnum.AT_132_DRUID: return new Sim_AT_132_DRUID();
                case cardIDEnum.AT_132_HUNTER: return new Sim_AT_132_HUNTER();
                case cardIDEnum.AT_132_MAGE: return new Sim_AT_132_MAGE();
                case cardIDEnum.AT_132_PALADIN: return new Sim_AT_132_PALADIN();
                case cardIDEnum.AT_132_PRIEST: return new Sim_AT_132_PRIEST();
                case cardIDEnum.AT_132_ROGUE: return new Sim_AT_132_ROGUE();
                case cardIDEnum.AT_132_ROGUEt: return new Sim_AT_132_ROGUEt();
                case cardIDEnum.AT_132_SHAMAN: return new Sim_AT_132_SHAMAN();
                case cardIDEnum.AT_132_SHAMANa: return new Sim_AT_132_SHAMANa();
                case cardIDEnum.AT_132_SHAMANb: return new Sim_AT_132_SHAMANb();
                case cardIDEnum.AT_132_SHAMANc: return new Sim_AT_132_SHAMANc();
                case cardIDEnum.AT_132_SHAMANd: return new Sim_AT_132_SHAMANd();
                case cardIDEnum.AT_132_WARLOCK: return new Sim_AT_132_WARLOCK();
                case cardIDEnum.AT_132_WARRIOR: return new Sim_AT_132_WARRIOR();
                case cardIDEnum.AT_133: return new Sim_AT_133();
                
                case cardIDEnum.BRMA01_2: return new Sim_BRMA01_2();
                case cardIDEnum.BRMA01_2H: return new Sim_BRMA01_2H();
                case cardIDEnum.BRMA01_2H_2_TB: return new Sim_BRMA01_2H_2_TB();
                case cardIDEnum.BRMA02_2: return new Sim_BRMA02_2();
                case cardIDEnum.BRMA02_2H: return new Sim_BRMA02_2H();
                case cardIDEnum.BRMA02_2_2_TB: return new Sim_BRMA02_2_2_TB();
                case cardIDEnum.BRMA02_2t: return new Sim_BRMA02_2t();
                case cardIDEnum.BRMA04_2: return new Sim_BRMA04_2();
                case cardIDEnum.BRMA06_2: return new Sim_BRMA06_2();
                case cardIDEnum.BRMA06_2H: return new Sim_BRMA06_2H();
                case cardIDEnum.BRMA06_2H_TB: return new Sim_BRMA06_2H_TB();
                case cardIDEnum.BRMA06_4: return new Sim_BRMA06_4();
                case cardIDEnum.BRMA06_4H: return new Sim_BRMA06_4H();
                case cardIDEnum.BRMA07_2: return new Sim_BRMA07_2();
                case cardIDEnum.BRMA07_2H: return new Sim_BRMA07_2H();
                case cardIDEnum.BRMA07_2_2_TB: return new Sim_BRMA07_2_2_TB();
                case cardIDEnum.BRMA09_2: return new Sim_BRMA09_2();
                case cardIDEnum.BRMA09_2H: return new Sim_BRMA09_2H();
                case cardIDEnum.BRMA09_2Ht: return new Sim_BRMA09_2Ht();
                case cardIDEnum.BRMA09_2_TB: return new Sim_BRMA09_2_TB();
                case cardIDEnum.BRMA09_2t: return new Sim_BRMA09_2t();
                case cardIDEnum.BRMA09_6: return new Sim_BRMA09_6();
                case cardIDEnum.BRMA12_3: return new Sim_BRMA12_3();
                case cardIDEnum.BRMA12_3H: return new Sim_BRMA12_3H();
                case cardIDEnum.BRMA12_4: return new Sim_BRMA12_4();
                case cardIDEnum.BRMA12_4H: return new Sim_BRMA12_4H();
                case cardIDEnum.BRMA13_4: return new Sim_BRMA13_4();
                case cardIDEnum.BRMA13_4H: return new Sim_BRMA13_4H();
                case cardIDEnum.BRMA13_4_2_TB: return new Sim_BRMA13_4_2_TB();
                case cardIDEnum.BRMA14_10: return new Sim_BRMA14_10();
                case cardIDEnum.BRMA14_10H: return new Sim_BRMA14_10H();
                case cardIDEnum.BRMA14_10H_TB: return new Sim_BRMA14_10H_TB();
                case cardIDEnum.BRMA14_5: return new Sim_BRMA14_5();
                case cardIDEnum.BRMA14_5H: return new Sim_BRMA14_5H();
                case cardIDEnum.BRMA17_5: return new Sim_BRMA17_5();
                case cardIDEnum.BRMA17_5H: return new Sim_BRMA17_5H();
                case cardIDEnum.BRMA17_5_TB: return new Sim_BRMA17_5_TB();
                case cardIDEnum.BRMA17_6: return new Sim_BRMA17_6();
                case cardIDEnum.BRMA17_6H: return new Sim_BRMA17_6H();
                
                case cardIDEnum.BRMC_94: return new Sim_BRMC_94();
                
                case cardIDEnum.BRM_001: return new Sim_BRM_001();
                case cardIDEnum.BRM_002: return new Sim_BRM_002();
                case cardIDEnum.BRM_003: return new Sim_BRM_003();
                case cardIDEnum.BRM_004: return new Sim_BRM_004();
                case cardIDEnum.BRM_004t: return new Sim_BRM_004t();
                case cardIDEnum.BRM_005: return new Sim_BRM_005();
                case cardIDEnum.BRM_006: return new Sim_BRM_006();
                case cardIDEnum.BRM_006t: return new Sim_BRM_006t();
                case cardIDEnum.BRM_007: return new Sim_BRM_007();
                case cardIDEnum.BRM_008: return new Sim_BRM_008();
                case cardIDEnum.BRM_009: return new Sim_BRM_009();
                case cardIDEnum.BRM_010: return new Sim_BRM_010();
                case cardIDEnum.BRM_010a: return new Sim_BRM_010a();
                case cardIDEnum.BRM_010b: return new Sim_BRM_010b();
                case cardIDEnum.BRM_010t2: return new Sim_BRM_010t2();
                case cardIDEnum.BRM_010t: return new Sim_BRM_010t();
                case cardIDEnum.BRM_011: return new Sim_BRM_011();
                case cardIDEnum.BRM_012: return new Sim_BRM_012();
                case cardIDEnum.BRM_013: return new Sim_BRM_013();
                case cardIDEnum.BRM_014: return new Sim_BRM_014();
                case cardIDEnum.BRM_015: return new Sim_BRM_015();
                case cardIDEnum.BRM_016: return new Sim_BRM_016();
                case cardIDEnum.BRM_017: return new Sim_BRM_017();
                case cardIDEnum.BRM_018: return new Sim_BRM_018();
                case cardIDEnum.BRM_019: return new Sim_BRM_019();
                case cardIDEnum.BRM_020: return new Sim_BRM_020();
                case cardIDEnum.BRM_022: return new Sim_BRM_022();
                case cardIDEnum.BRM_022t: return new Sim_BRM_022t();
                case cardIDEnum.BRM_024: return new Sim_BRM_024();
                case cardIDEnum.BRM_025: return new Sim_BRM_025();
                case cardIDEnum.BRM_026: return new Sim_BRM_026();
                case cardIDEnum.BRM_027: return new Sim_BRM_027();
                case cardIDEnum.BRM_027h: return new Sim_BRM_027h();
                case cardIDEnum.BRM_027p: return new Sim_BRM_027p();
                case cardIDEnum.BRM_027pH: return new Sim_BRM_027pH();
                case cardIDEnum.BRM_028: return new Sim_BRM_028();
                case cardIDEnum.BRM_029: return new Sim_BRM_029();
                case cardIDEnum.BRM_030: return new Sim_BRM_030();
                case cardIDEnum.BRM_030t: return new Sim_BRM_030t();
                case cardIDEnum.BRM_031: return new Sim_BRM_031();
                case cardIDEnum.BRM_033: return new Sim_BRM_033();
                case cardIDEnum.BRM_034: return new Sim_BRM_034();

                case cardIDEnum.CFM_020: return new Sim_CFM_020();
                case cardIDEnum.CFM_021: return new Sim_CFM_021();
                case cardIDEnum.CFM_025: return new Sim_CFM_025();
                case cardIDEnum.CFM_026: return new Sim_CFM_026();
                case cardIDEnum.CFM_039: return new Sim_CFM_039();
                case cardIDEnum.CFM_060: return new Sim_CFM_060();
                case cardIDEnum.CFM_061: return new Sim_CFM_061();
                case cardIDEnum.CFM_062: return new Sim_CFM_062();
                case cardIDEnum.CFM_063: return new Sim_CFM_063();
                case cardIDEnum.CFM_064: return new Sim_CFM_064();
                case cardIDEnum.CFM_065: return new Sim_CFM_065();
                case cardIDEnum.CFM_066: return new Sim_CFM_066();
                case cardIDEnum.CFM_067: return new Sim_CFM_067();
                case cardIDEnum.CFM_094: return new Sim_CFM_094();
                case cardIDEnum.CFM_095: return new Sim_CFM_095();
                case cardIDEnum.CFM_120: return new Sim_CFM_120();
                case cardIDEnum.CFM_300: return new Sim_CFM_300();
                case cardIDEnum.CFM_305: return new Sim_CFM_305();
                case cardIDEnum.CFM_308: return new Sim_CFM_308();
                case cardIDEnum.CFM_308a: return new Sim_CFM_308a();
                case cardIDEnum.CFM_308b: return new Sim_CFM_308b();
                case cardIDEnum.CFM_310: return new Sim_CFM_310();
                case cardIDEnum.CFM_312: return new Sim_CFM_312();
                case cardIDEnum.CFM_313: return new Sim_CFM_313();
                case cardIDEnum.CFM_315: return new Sim_CFM_315();
                case cardIDEnum.CFM_316: return new Sim_CFM_316();
                case cardIDEnum.CFM_321: return new Sim_CFM_321();
                case cardIDEnum.CFM_324: return new Sim_CFM_324();
                case cardIDEnum.CFM_325: return new Sim_CFM_325();
                case cardIDEnum.CFM_328: return new Sim_CFM_328();
                case cardIDEnum.CFM_333: return new Sim_CFM_333();
                case cardIDEnum.CFM_334: return new Sim_CFM_334();
                case cardIDEnum.CFM_335: return new Sim_CFM_335();
                case cardIDEnum.CFM_336: return new Sim_CFM_336();
                case cardIDEnum.CFM_337: return new Sim_CFM_337();
                case cardIDEnum.CFM_338: return new Sim_CFM_338();
                case cardIDEnum.CFM_341: return new Sim_CFM_341();
                case cardIDEnum.CFM_342: return new Sim_CFM_342();
                case cardIDEnum.CFM_343: return new Sim_CFM_343();
                case cardIDEnum.CFM_344: return new Sim_CFM_344();
                case cardIDEnum.CFM_602: return new Sim_CFM_602();
                case cardIDEnum.CFM_602a: return new Sim_CFM_602a();
                case cardIDEnum.CFM_602b: return new Sim_CFM_602b();
                case cardIDEnum.CFM_603: return new Sim_CFM_603();
                case cardIDEnum.CFM_604: return new Sim_CFM_604();
                case cardIDEnum.CFM_605: return new Sim_CFM_605();
                case cardIDEnum.CFM_606: return new Sim_CFM_606();
                case cardIDEnum.CFM_608: return new Sim_CFM_608();
                case cardIDEnum.CFM_609: return new Sim_CFM_609();
                case cardIDEnum.CFM_610: return new Sim_CFM_610();
                case cardIDEnum.CFM_611: return new Sim_CFM_611();
                case cardIDEnum.CFM_614: return new Sim_CFM_614();
                case cardIDEnum.CFM_616: return new Sim_CFM_616();
                case cardIDEnum.CFM_617: return new Sim_CFM_617();
                case cardIDEnum.CFM_619: return new Sim_CFM_619();
                case cardIDEnum.CFM_620: return new Sim_CFM_620();
                case cardIDEnum.CFM_621: return new Sim_CFM_621();
                case cardIDEnum.CFM_623: return new Sim_CFM_623();
                case cardIDEnum.CFM_626: return new Sim_CFM_626();
                case cardIDEnum.CFM_630: return new Sim_CFM_630();
                case cardIDEnum.CFM_631: return new Sim_CFM_631();
                case cardIDEnum.CFM_634: return new Sim_CFM_634();
                case cardIDEnum.CFM_636: return new Sim_CFM_636();
                case cardIDEnum.CFM_637: return new Sim_CFM_637();
                case cardIDEnum.CFM_639: return new Sim_CFM_639();
                case cardIDEnum.CFM_643: return new Sim_CFM_643();
                case cardIDEnum.CFM_646: return new Sim_CFM_646();
                case cardIDEnum.CFM_647: return new Sim_CFM_647();
                case cardIDEnum.CFM_648: return new Sim_CFM_648();
                case cardIDEnum.CFM_649: return new Sim_CFM_649();
                case cardIDEnum.CFM_650: return new Sim_CFM_650();
                case cardIDEnum.CFM_651: return new Sim_CFM_651();
                case cardIDEnum.CFM_652: return new Sim_CFM_652();
                case cardIDEnum.CFM_653: return new Sim_CFM_653();
                case cardIDEnum.CFM_654: return new Sim_CFM_654();
                case cardIDEnum.CFM_655: return new Sim_CFM_655();
                case cardIDEnum.CFM_656: return new Sim_CFM_656();
                case cardIDEnum.CFM_657: return new Sim_CFM_657();
                case cardIDEnum.CFM_658: return new Sim_CFM_658();
                case cardIDEnum.CFM_659: return new Sim_CFM_659();
                case cardIDEnum.CFM_660: return new Sim_CFM_660();
                case cardIDEnum.CFM_661: return new Sim_CFM_661();
                case cardIDEnum.CFM_662: return new Sim_CFM_662();
                case cardIDEnum.CFM_663: return new Sim_CFM_663();
                case cardIDEnum.CFM_665: return new Sim_CFM_665();
                case cardIDEnum.CFM_666: return new Sim_CFM_666();
                case cardIDEnum.CFM_667: return new Sim_CFM_667();
                case cardIDEnum.CFM_668: return new Sim_CFM_668();
                case cardIDEnum.CFM_669: return new Sim_CFM_669();
                case cardIDEnum.CFM_670: return new Sim_CFM_670();
                case cardIDEnum.CFM_671: return new Sim_CFM_671();
                case cardIDEnum.CFM_672: return new Sim_CFM_672();
                case cardIDEnum.CFM_685: return new Sim_CFM_685();
                case cardIDEnum.CFM_687: return new Sim_CFM_687();
                case cardIDEnum.CFM_688: return new Sim_CFM_688();
                case cardIDEnum.CFM_690: return new Sim_CFM_690();
                case cardIDEnum.CFM_691: return new Sim_CFM_691();
                case cardIDEnum.CFM_693: return new Sim_CFM_693();
                case cardIDEnum.CFM_694: return new Sim_CFM_694();
                case cardIDEnum.CFM_696: return new Sim_CFM_696();
                case cardIDEnum.CFM_697: return new Sim_CFM_697();
                case cardIDEnum.CFM_699: return new Sim_CFM_699();
                case cardIDEnum.CFM_707: return new Sim_CFM_707();
                case cardIDEnum.CFM_713: return new Sim_CFM_713();
                case cardIDEnum.CFM_715: return new Sim_CFM_715();
                case cardIDEnum.CFM_716: return new Sim_CFM_716();
                case cardIDEnum.CFM_717: return new Sim_CFM_717();
                case cardIDEnum.CFM_750: return new Sim_CFM_750();
                case cardIDEnum.CFM_751: return new Sim_CFM_751();
                case cardIDEnum.CFM_752: return new Sim_CFM_752();
                case cardIDEnum.CFM_753: return new Sim_CFM_753();
                case cardIDEnum.CFM_754: return new Sim_CFM_754();
                case cardIDEnum.CFM_755: return new Sim_CFM_755();
                case cardIDEnum.CFM_756: return new Sim_CFM_756();
                case cardIDEnum.CFM_759: return new Sim_CFM_759();
                case cardIDEnum.CFM_760: return new Sim_CFM_760();
                case cardIDEnum.CFM_781: return new Sim_CFM_781();
                case cardIDEnum.CFM_790: return new Sim_CFM_790();
                case cardIDEnum.CFM_800: return new Sim_CFM_800();
                case cardIDEnum.CFM_806: return new Sim_CFM_806();
                case cardIDEnum.CFM_807: return new Sim_CFM_807();
                case cardIDEnum.CFM_808: return new Sim_CFM_808();
                case cardIDEnum.CFM_809: return new Sim_CFM_809();
                case cardIDEnum.CFM_810: return new Sim_CFM_810();
                case cardIDEnum.CFM_811: return new Sim_CFM_811();
                case cardIDEnum.CFM_815: return new Sim_CFM_815();
                case cardIDEnum.CFM_816: return new Sim_CFM_816();
                case cardIDEnum.CFM_851: return new Sim_CFM_851();
                case cardIDEnum.CFM_852: return new Sim_CFM_852();
                case cardIDEnum.CFM_853: return new Sim_CFM_853();
                case cardIDEnum.CFM_854: return new Sim_CFM_854();
                case cardIDEnum.CFM_855: return new Sim_CFM_855();
                case cardIDEnum.CFM_900: return new Sim_CFM_900();
                case cardIDEnum.CFM_902: return new Sim_CFM_902();
                case cardIDEnum.CFM_905: return new Sim_CFM_905();
                case cardIDEnum.CFM_940: return new Sim_CFM_940();

                case cardIDEnum.CS1_042: return new Sim_CS1_042();
                case cardIDEnum.CS1_069: return new Sim_CS1_069();
                case cardIDEnum.CS1_112: return new Sim_CS1_112();
                case cardIDEnum.CS1_113: return new Sim_CS1_113();
                case cardIDEnum.CS1_129: return new Sim_CS1_129();
                case cardIDEnum.CS1_130: return new Sim_CS1_130();
                case cardIDEnum.CS1h_001: return new Sim_CS1h_001();
                case cardIDEnum.CS1h_001_H1: return new Sim_CS1h_001();
                case cardIDEnum.CS1h_001_H1_AT_132: return new Sim_AT_132_PRIEST();
                case cardIDEnum.CS2_003: return new Sim_CS2_003();
                case cardIDEnum.CS2_004: return new Sim_CS2_004();
                case cardIDEnum.CS2_005: return new Sim_CS2_005();
                case cardIDEnum.CS2_007: return new Sim_CS2_007();
                case cardIDEnum.CS2_008: return new Sim_CS2_008();
                case cardIDEnum.CS2_009: return new Sim_CS2_009();
                case cardIDEnum.CS2_011: return new Sim_CS2_011();
                case cardIDEnum.CS2_012: return new Sim_CS2_012();
                case cardIDEnum.CS2_013: return new Sim_CS2_013();
                case cardIDEnum.CS2_013t: return new Sim_CS2_013t();
                case cardIDEnum.CS2_017: return new Sim_CS2_017();
                case cardIDEnum.CS2_022: return new Sim_CS2_022();
                case cardIDEnum.CS2_023: return new Sim_CS2_023();
                case cardIDEnum.CS2_024: return new Sim_CS2_024();
                case cardIDEnum.CS2_025: return new Sim_CS2_025();
                case cardIDEnum.CS2_026: return new Sim_CS2_026();
                case cardIDEnum.CS2_027: return new Sim_CS2_027();
                case cardIDEnum.CS2_028: return new Sim_CS2_028();
                case cardIDEnum.CS2_029: return new Sim_CS2_029();
                case cardIDEnum.CS2_031: return new Sim_CS2_031();
                case cardIDEnum.CS2_032: return new Sim_CS2_032();
                case cardIDEnum.CS2_033: return new Sim_CS2_033();
                case cardIDEnum.CS2_034: return new Sim_CS2_034();
                case cardIDEnum.CS2_034_H1: return new Sim_CS2_034();
                case cardIDEnum.CS2_034_H1_AT_132: return new Sim_AT_132_MAGE();
                case cardIDEnum.CS2_034_H2: return new Sim_CS2_034();
                case cardIDEnum.CS2_034_H2_AT_132: return new Sim_AT_132_MAGE();
                case cardIDEnum.CS2_037: return new Sim_CS2_037();
                case cardIDEnum.CS2_038: return new Sim_CS2_038();
                case cardIDEnum.CS2_039: return new Sim_CS2_039();
                case cardIDEnum.CS2_041: return new Sim_CS2_041();
                case cardIDEnum.CS2_042: return new Sim_CS2_042();
                case cardIDEnum.CS2_045: return new Sim_CS2_045();
                case cardIDEnum.CS2_046: return new Sim_CS2_046();
                case cardIDEnum.CS2_049: return new Sim_CS2_049();
                case cardIDEnum.CS2_049_H1: return new Sim_CS2_049();
                case cardIDEnum.CS2_049_H1_AT_132: return new Sim_AT_132_SHAMAN();
                case cardIDEnum.CS2_050: return new Sim_CS2_050();
                case cardIDEnum.CS2_051: return new Sim_CS2_051();
                case cardIDEnum.CS2_052: return new Sim_CS2_052();
                case cardIDEnum.CS2_053: return new Sim_CS2_053();
                case cardIDEnum.CS2_056: return new Sim_CS2_056();
                case cardIDEnum.CS2_057: return new Sim_CS2_057();
                case cardIDEnum.CS2_059: return new Sim_CS2_059();
                case cardIDEnum.CS2_061: return new Sim_CS2_061();
                case cardIDEnum.CS2_062: return new Sim_CS2_062();
                case cardIDEnum.CS2_063: return new Sim_CS2_063();
                case cardIDEnum.CS2_064: return new Sim_CS2_064();
                case cardIDEnum.CS2_065: return new Sim_CS2_065();
                case cardIDEnum.CS2_072: return new Sim_CS2_072();
                case cardIDEnum.CS2_073: return new Sim_CS2_073();
                case cardIDEnum.CS2_074: return new Sim_CS2_074();
                case cardIDEnum.CS2_075: return new Sim_CS2_075();
                case cardIDEnum.CS2_076: return new Sim_CS2_076();
                case cardIDEnum.CS2_077: return new Sim_CS2_077();
                case cardIDEnum.CS2_080: return new Sim_CS2_080();
                case cardIDEnum.CS2_082: return new Sim_CS2_082();
                case cardIDEnum.CS2_083b: return new Sim_CS2_083b();
                case cardIDEnum.CS2_084: return new Sim_CS2_084();
                case cardIDEnum.CS2_087: return new Sim_CS2_087();
                case cardIDEnum.CS2_088: return new Sim_CS2_088();
                case cardIDEnum.CS2_089: return new Sim_CS2_089();
                case cardIDEnum.CS2_091: return new Sim_CS2_091();
                case cardIDEnum.CS2_092: return new Sim_CS2_092();
                case cardIDEnum.CS2_093: return new Sim_CS2_093();
                case cardIDEnum.CS2_094: return new Sim_CS2_094();
                case cardIDEnum.CS2_097: return new Sim_CS2_097();
                case cardIDEnum.CS2_101: return new Sim_CS2_101();
                case cardIDEnum.CS2_101_H1: return new Sim_CS2_101();
                case cardIDEnum.CS2_101_H1_AT_132: return new Sim_AT_132_PALADIN();
                case cardIDEnum.CS2_101t: return new Sim_CS2_101t();
                case cardIDEnum.CS2_102: return new Sim_CS2_102();
                case cardIDEnum.CS2_102_H1: return new Sim_CS2_102();
                case cardIDEnum.CS2_102_H1_AT_132: return new Sim_AT_132_WARRIOR();
                case cardIDEnum.CS2_103: return new Sim_CS2_103();
                case cardIDEnum.CS2_104: return new Sim_CS2_104();
                case cardIDEnum.CS2_105: return new Sim_CS2_105();
                case cardIDEnum.CS2_106: return new Sim_CS2_106();
                case cardIDEnum.CS2_108: return new Sim_CS2_108();
                case cardIDEnum.CS2_112: return new Sim_CS2_112();
                case cardIDEnum.CS2_114: return new Sim_CS2_114();
                case cardIDEnum.CS2_117: return new Sim_CS2_117();
                case cardIDEnum.CS2_118: return new Sim_CS2_118();
                case cardIDEnum.CS2_119: return new Sim_CS2_119();
                case cardIDEnum.CS2_120: return new Sim_CS2_120();
                case cardIDEnum.CS2_121: return new Sim_CS2_121();
                case cardIDEnum.CS2_122: return new Sim_CS2_122();
                case cardIDEnum.CS2_124: return new Sim_CS2_124();
                case cardIDEnum.CS2_125: return new Sim_CS2_125();
                case cardIDEnum.CS2_127: return new Sim_CS2_127();
                case cardIDEnum.CS2_131: return new Sim_CS2_131();
                case cardIDEnum.CS2_141: return new Sim_CS2_141();
                case cardIDEnum.CS2_142: return new Sim_CS2_142();
                case cardIDEnum.CS2_146: return new Sim_CS2_146();
                case cardIDEnum.CS2_147: return new Sim_CS2_147();
                case cardIDEnum.CS2_150: return new Sim_CS2_150();
                case cardIDEnum.CS2_151: return new Sim_CS2_151();
                case cardIDEnum.CS2_152: return new Sim_CS2_152();
                case cardIDEnum.CS2_155: return new Sim_CS2_155();
                case cardIDEnum.CS2_161: return new Sim_CS2_161();
                case cardIDEnum.CS2_162: return new Sim_CS2_162();
                case cardIDEnum.CS2_168: return new Sim_CS2_168();
                case cardIDEnum.CS2_169: return new Sim_CS2_169();
                case cardIDEnum.CS2_171: return new Sim_CS2_171();
                case cardIDEnum.CS2_172: return new Sim_CS2_172();
                case cardIDEnum.CS2_173: return new Sim_CS2_173();
                case cardIDEnum.CS2_179: return new Sim_CS2_179();
                case cardIDEnum.CS2_181: return new Sim_CS2_181();
                case cardIDEnum.CS2_182: return new Sim_CS2_182();
                case cardIDEnum.CS2_186: return new Sim_CS2_186();
                case cardIDEnum.CS2_187: return new Sim_CS2_187();
                case cardIDEnum.CS2_188: return new Sim_CS2_188();
                case cardIDEnum.CS2_189: return new Sim_CS2_189();
                case cardIDEnum.CS2_196: return new Sim_CS2_196();
                case cardIDEnum.CS2_197: return new Sim_CS2_197();
                case cardIDEnum.CS2_200: return new Sim_CS2_200();
                case cardIDEnum.CS2_201: return new Sim_CS2_201();
                case cardIDEnum.CS2_203: return new Sim_CS2_203();
                case cardIDEnum.CS2_213: return new Sim_CS2_213();
                case cardIDEnum.CS2_221: return new Sim_CS2_221();
                case cardIDEnum.CS2_222: return new Sim_CS2_222();
                case cardIDEnum.CS2_226: return new Sim_CS2_226();
                case cardIDEnum.CS2_227: return new Sim_CS2_227();
                case cardIDEnum.CS2_231: return new Sim_CS2_231();
                case cardIDEnum.CS2_232: return new Sim_CS2_232();
                case cardIDEnum.CS2_233: return new Sim_CS2_233();
                case cardIDEnum.CS2_234: return new Sim_CS2_234();
                case cardIDEnum.CS2_235: return new Sim_CS2_235();
                case cardIDEnum.CS2_236: return new Sim_CS2_236();
                case cardIDEnum.CS2_237: return new Sim_CS2_237();
                case cardIDEnum.CS2_boar: return new Sim_CS2_boar();
                case cardIDEnum.CS2_mirror: return new Sim_CS2_mirror();
                case cardIDEnum.CS2_tk1: return new Sim_CS2_tk1();
                
                case cardIDEnum.DREAM_01: return new Sim_DREAM_01();
                case cardIDEnum.DREAM_02: return new Sim_DREAM_02();
                case cardIDEnum.DREAM_03: return new Sim_DREAM_03();
                case cardIDEnum.DREAM_04: return new Sim_DREAM_04();
                case cardIDEnum.DREAM_05: return new Sim_DREAM_05();
                
                case cardIDEnum.DS1_055: return new Sim_DS1_055();
                case cardIDEnum.DS1_070: return new Sim_DS1_070();
                case cardIDEnum.DS1_175: return new Sim_DS1_175();
                case cardIDEnum.DS1_178: return new Sim_DS1_178();
                case cardIDEnum.DS1_183: return new Sim_DS1_183();
                case cardIDEnum.DS1_184: return new Sim_DS1_184();
                case cardIDEnum.DS1_185: return new Sim_DS1_185();
                case cardIDEnum.DS1_188: return new Sim_DS1_188();
                case cardIDEnum.DS1_233: return new Sim_DS1_233();
                case cardIDEnum.DS1h_292: return new Sim_DS1h_292();
                case cardIDEnum.DS1h_292_H1: return new Sim_DS1h_292();
                case cardIDEnum.DS1h_292_H1_AT_132: return new Sim_AT_132_HUNTER();

                case cardIDEnum.EX1_001: return new Sim_EX1_001();
                case cardIDEnum.EX1_002: return new Sim_EX1_002();
                case cardIDEnum.EX1_004: return new Sim_EX1_004();
                case cardIDEnum.EX1_005: return new Sim_EX1_005();
                case cardIDEnum.EX1_006: return new Sim_EX1_006();
                case cardIDEnum.EX1_007: return new Sim_EX1_007();
                case cardIDEnum.EX1_008: return new Sim_EX1_008();
                case cardIDEnum.EX1_009: return new Sim_EX1_009();
                case cardIDEnum.EX1_010: return new Sim_EX1_010();
                case cardIDEnum.EX1_011: return new Sim_EX1_011();
                case cardIDEnum.EX1_012: return new Sim_EX1_012();
                case cardIDEnum.EX1_014: return new Sim_EX1_014();
                case cardIDEnum.EX1_014t: return new Sim_EX1_014t();
                case cardIDEnum.EX1_015: return new Sim_EX1_015();
                case cardIDEnum.EX1_016: return new Sim_EX1_016();
                case cardIDEnum.EX1_017: return new Sim_EX1_017();
                case cardIDEnum.EX1_019: return new Sim_EX1_019();
                case cardIDEnum.EX1_020: return new Sim_EX1_020();
                case cardIDEnum.EX1_021: return new Sim_EX1_021();
                case cardIDEnum.EX1_023: return new Sim_EX1_023();
                case cardIDEnum.EX1_025: return new Sim_EX1_025();
                case cardIDEnum.EX1_025t: return new Sim_EX1_025t();
                case cardIDEnum.EX1_028: return new Sim_EX1_028();
                case cardIDEnum.EX1_029: return new Sim_EX1_029();
                case cardIDEnum.EX1_032: return new Sim_EX1_032();
                case cardIDEnum.EX1_033: return new Sim_EX1_033();
                case cardIDEnum.EX1_043: return new Sim_EX1_043();
                case cardIDEnum.EX1_044: return new Sim_EX1_044();
                case cardIDEnum.EX1_045: return new Sim_EX1_045();
                case cardIDEnum.EX1_046: return new Sim_EX1_046();
                case cardIDEnum.EX1_048: return new Sim_EX1_048();
                case cardIDEnum.EX1_049: return new Sim_EX1_049();
                case cardIDEnum.EX1_050: return new Sim_EX1_050();
                case cardIDEnum.EX1_055: return new Sim_EX1_055();
                case cardIDEnum.EX1_057: return new Sim_EX1_057();
                case cardIDEnum.EX1_058: return new Sim_EX1_058();
                case cardIDEnum.EX1_059: return new Sim_EX1_059();
                case cardIDEnum.EX1_062: return new Sim_EX1_062();
                case cardIDEnum.EX1_066: return new Sim_EX1_066();
                case cardIDEnum.EX1_067: return new Sim_EX1_067();
                case cardIDEnum.EX1_076: return new Sim_EX1_076();
                case cardIDEnum.EX1_080: return new Sim_EX1_080();
                case cardIDEnum.EX1_082: return new Sim_EX1_082();
                case cardIDEnum.EX1_083: return new Sim_EX1_083();
                case cardIDEnum.EX1_084: return new Sim_EX1_084();
                case cardIDEnum.EX1_085: return new Sim_EX1_085();
                case cardIDEnum.EX1_089: return new Sim_EX1_089();
                case cardIDEnum.EX1_091: return new Sim_EX1_091();
                case cardIDEnum.EX1_093: return new Sim_EX1_093();
                case cardIDEnum.EX1_095: return new Sim_EX1_095();
                case cardIDEnum.EX1_096: return new Sim_EX1_096();
                case cardIDEnum.EX1_097: return new Sim_EX1_097();
                case cardIDEnum.EX1_100: return new Sim_EX1_100();
                case cardIDEnum.EX1_102: return new Sim_EX1_102();
                case cardIDEnum.EX1_103: return new Sim_EX1_103();
                case cardIDEnum.EX1_105: return new Sim_EX1_105();
                case cardIDEnum.EX1_110: return new Sim_EX1_110();
                case cardIDEnum.EX1_110t: return new Sim_EX1_110t();
                case cardIDEnum.EX1_112: return new Sim_EX1_112();
                case cardIDEnum.EX1_116: return new Sim_EX1_116();
                case cardIDEnum.EX1_116t: return new Sim_EX1_116t();
                case cardIDEnum.EX1_124: return new Sim_EX1_124();
                case cardIDEnum.EX1_126: return new Sim_EX1_126();
                case cardIDEnum.EX1_128: return new Sim_EX1_128();
                case cardIDEnum.EX1_129: return new Sim_EX1_129();
                case cardIDEnum.EX1_130: return new Sim_EX1_130();
                case cardIDEnum.EX1_130a: return new Sim_EX1_130a();
                case cardIDEnum.EX1_131: return new Sim_EX1_131();
                case cardIDEnum.EX1_131t: return new Sim_EX1_131t();
                case cardIDEnum.EX1_132: return new Sim_EX1_132();
                case cardIDEnum.EX1_133: return new Sim_EX1_133();
                case cardIDEnum.EX1_134: return new Sim_EX1_134();
                case cardIDEnum.EX1_136: return new Sim_EX1_136();
                case cardIDEnum.EX1_137: return new Sim_EX1_137();
                case cardIDEnum.EX1_144: return new Sim_EX1_144();
                case cardIDEnum.EX1_145: return new Sim_EX1_145();
                case cardIDEnum.EX1_154: return new Sim_EX1_154();
                case cardIDEnum.EX1_154a: return new Sim_EX1_154a();
                case cardIDEnum.EX1_154b: return new Sim_EX1_154b();
                case cardIDEnum.EX1_155: return new Sim_EX1_155();
                case cardIDEnum.EX1_155a: return new Sim_EX1_155a();
                case cardIDEnum.EX1_155b: return new Sim_EX1_155b();
                case cardIDEnum.EX1_158: return new Sim_EX1_158();
                case cardIDEnum.EX1_158t: return new Sim_EX1_158t();
                case cardIDEnum.EX1_160: return new Sim_EX1_160();
                case cardIDEnum.EX1_160a: return new Sim_EX1_160a();
                case cardIDEnum.EX1_160b: return new Sim_EX1_160b();
                case cardIDEnum.EX1_160t: return new Sim_EX1_160t();
                case cardIDEnum.EX1_161: return new Sim_EX1_161();
                case cardIDEnum.EX1_162: return new Sim_EX1_162();
                case cardIDEnum.EX1_164: return new Sim_EX1_164();
                case cardIDEnum.EX1_164a: return new Sim_EX1_164a();
                case cardIDEnum.EX1_164b: return new Sim_EX1_164b();
                case cardIDEnum.EX1_165: return new Sim_EX1_165();
                case cardIDEnum.EX1_165a: return new Sim_EX1_165a();
                case cardIDEnum.EX1_165b: return new Sim_EX1_165b();
                case cardIDEnum.EX1_165t1: return new Sim_EX1_165t1();
                case cardIDEnum.EX1_165t2: return new Sim_EX1_165t2();
                case cardIDEnum.EX1_166: return new Sim_EX1_166();
                case cardIDEnum.EX1_166a: return new Sim_EX1_166a();
                case cardIDEnum.EX1_166b: return new Sim_EX1_166b();
                case cardIDEnum.EX1_169: return new Sim_EX1_169();
                case cardIDEnum.EX1_170: return new Sim_EX1_170();
                case cardIDEnum.EX1_173: return new Sim_EX1_173();
                case cardIDEnum.EX1_178: return new Sim_EX1_178();
                case cardIDEnum.EX1_178a: return new Sim_EX1_178a();
                case cardIDEnum.EX1_178b: return new Sim_EX1_178b();
                case cardIDEnum.EX1_238: return new Sim_EX1_238();
                case cardIDEnum.EX1_241: return new Sim_EX1_241();
                case cardIDEnum.EX1_243: return new Sim_EX1_243();
                case cardIDEnum.EX1_244: return new Sim_EX1_244();
                case cardIDEnum.EX1_245: return new Sim_EX1_245();
                case cardIDEnum.EX1_246: return new Sim_EX1_246();
                case cardIDEnum.EX1_247: return new Sim_EX1_247();
                case cardIDEnum.EX1_248: return new Sim_EX1_248();
                case cardIDEnum.EX1_249: return new Sim_EX1_249();
                case cardIDEnum.EX1_250: return new Sim_EX1_250();
                case cardIDEnum.EX1_251: return new Sim_EX1_251();
                case cardIDEnum.EX1_258: return new Sim_EX1_258();
                case cardIDEnum.EX1_259: return new Sim_EX1_259();
                case cardIDEnum.EX1_274: return new Sim_EX1_274();
                case cardIDEnum.EX1_275: return new Sim_EX1_275();
                case cardIDEnum.EX1_277: return new Sim_EX1_277();
                case cardIDEnum.EX1_278: return new Sim_EX1_278();
                case cardIDEnum.EX1_279: return new Sim_EX1_279();
                case cardIDEnum.EX1_283: return new Sim_EX1_283();
                case cardIDEnum.EX1_284: return new Sim_EX1_284();
                case cardIDEnum.EX1_287: return new Sim_EX1_287();
                case cardIDEnum.EX1_289: return new Sim_EX1_289();
                case cardIDEnum.EX1_294: return new Sim_EX1_294();
                case cardIDEnum.EX1_295: return new Sim_EX1_295();
                case cardIDEnum.EX1_298: return new Sim_EX1_298();
                case cardIDEnum.EX1_301: return new Sim_EX1_301();
                case cardIDEnum.EX1_302: return new Sim_EX1_302();
                case cardIDEnum.EX1_303: return new Sim_EX1_303();
                case cardIDEnum.EX1_304: return new Sim_EX1_304();
                case cardIDEnum.EX1_306: return new Sim_EX1_306();
                case cardIDEnum.EX1_308: return new Sim_EX1_308();
                case cardIDEnum.EX1_309: return new Sim_EX1_309();
                case cardIDEnum.EX1_310: return new Sim_EX1_310();
                case cardIDEnum.EX1_312: return new Sim_EX1_312();
                case cardIDEnum.EX1_313: return new Sim_EX1_313();
                case cardIDEnum.EX1_315: return new Sim_EX1_315();
                case cardIDEnum.EX1_316: return new Sim_EX1_316();
                case cardIDEnum.EX1_317: return new Sim_EX1_317();
                case cardIDEnum.EX1_317t: return new Sim_EX1_317t();
                case cardIDEnum.EX1_319: return new Sim_EX1_319();
                case cardIDEnum.EX1_320: return new Sim_EX1_320();
                case cardIDEnum.EX1_323: return new Sim_EX1_323();
                case cardIDEnum.EX1_323h: return new Sim_EX1_323h();
                case cardIDEnum.EX1_323w: return new Sim_EX1_323w();
                case cardIDEnum.EX1_332: return new Sim_EX1_332();
                case cardIDEnum.EX1_334: return new Sim_EX1_334();
                case cardIDEnum.EX1_335: return new Sim_EX1_335();
                case cardIDEnum.EX1_339: return new Sim_EX1_339();
                case cardIDEnum.EX1_341: return new Sim_EX1_341();
                case cardIDEnum.EX1_345: return new Sim_EX1_345();
                case cardIDEnum.EX1_345t: return new Sim_EX1_345t();
                case cardIDEnum.EX1_349: return new Sim_EX1_349();
                case cardIDEnum.EX1_350: return new Sim_EX1_350();
                case cardIDEnum.EX1_354: return new Sim_EX1_354();
                case cardIDEnum.EX1_355: return new Sim_EX1_355();
                case cardIDEnum.EX1_360: return new Sim_EX1_360();
                case cardIDEnum.EX1_362: return new Sim_EX1_362();
                case cardIDEnum.EX1_363: return new Sim_EX1_363();
                case cardIDEnum.EX1_365: return new Sim_EX1_365();
                case cardIDEnum.EX1_366: return new Sim_EX1_366();
                case cardIDEnum.EX1_371: return new Sim_EX1_371();
                case cardIDEnum.EX1_379: return new Sim_EX1_379();
                case cardIDEnum.EX1_382: return new Sim_EX1_382();
                case cardIDEnum.EX1_383: return new Sim_EX1_383();
                case cardIDEnum.EX1_383t: return new Sim_EX1_383t();
                case cardIDEnum.EX1_384: return new Sim_EX1_384();
                case cardIDEnum.EX1_390: return new Sim_EX1_390();
                case cardIDEnum.EX1_391: return new Sim_EX1_391();
                case cardIDEnum.EX1_392: return new Sim_EX1_392();
                case cardIDEnum.EX1_393: return new Sim_EX1_393();
                case cardIDEnum.EX1_396: return new Sim_EX1_396();
                case cardIDEnum.EX1_398: return new Sim_EX1_398();
                case cardIDEnum.EX1_398t: return new Sim_EX1_398t();
                case cardIDEnum.EX1_399: return new Sim_EX1_399();
                case cardIDEnum.EX1_400: return new Sim_EX1_400();
                case cardIDEnum.EX1_402: return new Sim_EX1_402();
                case cardIDEnum.EX1_405: return new Sim_EX1_405();
                case cardIDEnum.EX1_407: return new Sim_EX1_407();
                case cardIDEnum.EX1_408: return new Sim_EX1_408();
                case cardIDEnum.EX1_409: return new Sim_EX1_409();
                case cardIDEnum.EX1_409t: return new Sim_EX1_409t();
                case cardIDEnum.EX1_410: return new Sim_EX1_410();
                case cardIDEnum.EX1_411: return new Sim_EX1_411();
                case cardIDEnum.EX1_412: return new Sim_EX1_412();
                case cardIDEnum.EX1_414: return new Sim_EX1_414();
                case cardIDEnum.EX1_506: return new Sim_EX1_506();
                case cardIDEnum.EX1_506a: return new Sim_EX1_506a();
                case cardIDEnum.EX1_507: return new Sim_EX1_507();
                case cardIDEnum.EX1_508: return new Sim_EX1_508();
                case cardIDEnum.EX1_509: return new Sim_EX1_509();
                case cardIDEnum.EX1_522: return new Sim_EX1_522();
                case cardIDEnum.EX1_531: return new Sim_EX1_531();
                case cardIDEnum.EX1_533: return new Sim_EX1_533();
                case cardIDEnum.EX1_534: return new Sim_EX1_534();
                case cardIDEnum.EX1_534t: return new Sim_EX1_534t();
                case cardIDEnum.EX1_536: return new Sim_EX1_536();
                case cardIDEnum.EX1_537: return new Sim_EX1_537();
                case cardIDEnum.EX1_538: return new Sim_EX1_538();
                case cardIDEnum.EX1_538t: return new Sim_EX1_538t();
                case cardIDEnum.EX1_539: return new Sim_EX1_539();
                case cardIDEnum.EX1_543: return new Sim_EX1_543();
                case cardIDEnum.EX1_544: return new Sim_EX1_544();
                case cardIDEnum.EX1_549: return new Sim_EX1_549();
                case cardIDEnum.EX1_554: return new Sim_EX1_554();
                case cardIDEnum.EX1_554t: return new Sim_EX1_554t();
                case cardIDEnum.EX1_556: return new Sim_EX1_556();
                case cardIDEnum.EX1_557: return new Sim_EX1_557();
                case cardIDEnum.EX1_558: return new Sim_EX1_558();
                case cardIDEnum.EX1_559: return new Sim_EX1_559();
                case cardIDEnum.EX1_560: return new Sim_EX1_560();
                case cardIDEnum.EX1_561: return new Sim_EX1_561();
                case cardIDEnum.EX1_562: return new Sim_EX1_562();
                case cardIDEnum.EX1_563: return new Sim_EX1_563();
                case cardIDEnum.EX1_564: return new Sim_EX1_564();
                case cardIDEnum.EX1_565: return new Sim_EX1_565();
                case cardIDEnum.EX1_567: return new Sim_EX1_567();
                case cardIDEnum.EX1_570: return new Sim_EX1_570();
                case cardIDEnum.EX1_571: return new Sim_EX1_571();
                case cardIDEnum.EX1_572: return new Sim_EX1_572();
                case cardIDEnum.EX1_573: return new Sim_EX1_573();
                case cardIDEnum.EX1_573a: return new Sim_EX1_573a();
                case cardIDEnum.EX1_573b: return new Sim_EX1_573b();
                case cardIDEnum.EX1_573t: return new Sim_EX1_573t();
                case cardIDEnum.EX1_575: return new Sim_EX1_575();
                case cardIDEnum.EX1_577: return new Sim_EX1_577();
                case cardIDEnum.EX1_578: return new Sim_EX1_578();
                case cardIDEnum.EX1_581: return new Sim_EX1_581();
                case cardIDEnum.EX1_582: return new Sim_EX1_582();
                case cardIDEnum.EX1_583: return new Sim_EX1_583();
                case cardIDEnum.EX1_584: return new Sim_EX1_584();
                case cardIDEnum.EX1_586: return new Sim_EX1_586();
                case cardIDEnum.EX1_587: return new Sim_EX1_587();
                case cardIDEnum.EX1_590: return new Sim_EX1_590();
                case cardIDEnum.EX1_591: return new Sim_EX1_591();
                case cardIDEnum.EX1_593: return new Sim_EX1_593();
                case cardIDEnum.EX1_594: return new Sim_EX1_594();
                case cardIDEnum.EX1_595: return new Sim_EX1_595();
                case cardIDEnum.EX1_596: return new Sim_EX1_596();
                case cardIDEnum.EX1_597: return new Sim_EX1_597();
                case cardIDEnum.EX1_598: return new Sim_EX1_598();
                case cardIDEnum.EX1_603: return new Sim_EX1_603();
                case cardIDEnum.EX1_604: return new Sim_EX1_604();
                case cardIDEnum.EX1_606: return new Sim_EX1_606();
                case cardIDEnum.EX1_607: return new Sim_EX1_607();
                case cardIDEnum.EX1_608: return new Sim_EX1_608();
                case cardIDEnum.EX1_609: return new Sim_EX1_609();
                case cardIDEnum.EX1_610: return new Sim_EX1_610();
                case cardIDEnum.EX1_611: return new Sim_EX1_611();
                case cardIDEnum.EX1_612: return new Sim_EX1_612();
                case cardIDEnum.EX1_613: return new Sim_EX1_613();
                case cardIDEnum.EX1_614: return new Sim_EX1_614();
                case cardIDEnum.EX1_614t: return new Sim_EX1_614t();
                case cardIDEnum.EX1_616: return new Sim_EX1_616();
                case cardIDEnum.EX1_617: return new Sim_EX1_617();
                case cardIDEnum.EX1_619: return new Sim_EX1_619();
                case cardIDEnum.EX1_620: return new Sim_EX1_620();
                case cardIDEnum.EX1_621: return new Sim_EX1_621();
                case cardIDEnum.EX1_622: return new Sim_EX1_622();
                case cardIDEnum.EX1_623: return new Sim_EX1_623();
                case cardIDEnum.EX1_624: return new Sim_EX1_624();
                case cardIDEnum.EX1_625: return new Sim_EX1_625();
                case cardIDEnum.EX1_625t2: return new Sim_EX1_625t2();
                case cardIDEnum.EX1_625t: return new Sim_EX1_625t();
                case cardIDEnum.EX1_626: return new Sim_EX1_626();
                case cardIDEnum.EX1_finkle: return new Sim_EX1_finkle();
                case cardIDEnum.EX1_tk11: return new Sim_EX1_tk11();
                case cardIDEnum.EX1_tk28: return new Sim_EX1_tk28();
                case cardIDEnum.EX1_tk29: return new Sim_EX1_tk29();
                case cardIDEnum.EX1_tk33: return new Sim_EX1_tk33();
                case cardIDEnum.EX1_tk34: return new Sim_EX1_tk34();
                case cardIDEnum.EX1_tk9: return new Sim_EX1_tk9();
                
                case cardIDEnum.FP1_001: return new Sim_FP1_001();
                case cardIDEnum.FP1_002: return new Sim_FP1_002();
                case cardIDEnum.FP1_002t: return new Sim_FP1_002t();
                case cardIDEnum.FP1_003: return new Sim_FP1_003();
                case cardIDEnum.FP1_004: return new Sim_FP1_004();
                case cardIDEnum.FP1_005: return new Sim_FP1_005();
                case cardIDEnum.FP1_006: return new Sim_FP1_006();
                case cardIDEnum.FP1_007: return new Sim_FP1_007();
                case cardIDEnum.FP1_007t: return new Sim_FP1_007t();
                case cardIDEnum.FP1_008: return new Sim_FP1_008();
                case cardIDEnum.FP1_009: return new Sim_FP1_009();
                case cardIDEnum.FP1_010: return new Sim_FP1_010();
                case cardIDEnum.FP1_011: return new Sim_FP1_011();
                case cardIDEnum.FP1_012: return new Sim_FP1_012();
                case cardIDEnum.FP1_012t: return new Sim_FP1_012t();
                case cardIDEnum.FP1_013: return new Sim_FP1_013();
                case cardIDEnum.FP1_014: return new Sim_FP1_014();
                case cardIDEnum.FP1_014t: return new Sim_FP1_014t();
                case cardIDEnum.FP1_015: return new Sim_FP1_015();
                case cardIDEnum.FP1_016: return new Sim_FP1_016();
                case cardIDEnum.FP1_017: return new Sim_FP1_017();
                case cardIDEnum.FP1_018: return new Sim_FP1_018();
                case cardIDEnum.FP1_019: return new Sim_FP1_019();
                case cardIDEnum.FP1_019t: return new Sim_FP1_019t();
                case cardIDEnum.FP1_020: return new Sim_FP1_020();
                case cardIDEnum.FP1_021: return new Sim_FP1_021();
                case cardIDEnum.FP1_022: return new Sim_FP1_022();
                case cardIDEnum.FP1_023: return new Sim_FP1_023();
                case cardIDEnum.FP1_024: return new Sim_FP1_024();
                case cardIDEnum.FP1_025: return new Sim_FP1_025();
                case cardIDEnum.FP1_026: return new Sim_FP1_026();
                case cardIDEnum.FP1_027: return new Sim_FP1_027();
                case cardIDEnum.FP1_028: return new Sim_FP1_028();
                case cardIDEnum.FP1_029: return new Sim_FP1_029();
                case cardIDEnum.FP1_030: return new Sim_FP1_030();
                case cardIDEnum.FP1_031: return new Sim_FP1_031();
                
                case cardIDEnum.GAME_002: return new Sim_GAME_002();
                case cardIDEnum.GAME_005: return new Sim_GAME_005();
                case cardIDEnum.GAME_006: return new Sim_GAME_006();
                
                case cardIDEnum.GVG_001: return new Sim_GVG_001();
                case cardIDEnum.GVG_002: return new Sim_GVG_002();
                case cardIDEnum.GVG_003: return new Sim_GVG_003();
                case cardIDEnum.GVG_004: return new Sim_GVG_004();
                case cardIDEnum.GVG_005: return new Sim_GVG_005();
                case cardIDEnum.GVG_006: return new Sim_GVG_006();
                case cardIDEnum.GVG_007: return new Sim_GVG_007();
                case cardIDEnum.GVG_008: return new Sim_GVG_008();
                case cardIDEnum.GVG_009: return new Sim_GVG_009();
                case cardIDEnum.GVG_010: return new Sim_GVG_010();
                case cardIDEnum.GVG_011: return new Sim_GVG_011();
                case cardIDEnum.GVG_012: return new Sim_GVG_012();
                case cardIDEnum.GVG_013: return new Sim_GVG_013();
                case cardIDEnum.GVG_014: return new Sim_GVG_014();
                case cardIDEnum.GVG_015: return new Sim_GVG_015();
                case cardIDEnum.GVG_016: return new Sim_GVG_016();
                case cardIDEnum.GVG_017: return new Sim_GVG_017();
                case cardIDEnum.GVG_018: return new Sim_GVG_018();
                case cardIDEnum.GVG_019: return new Sim_GVG_019();
                case cardIDEnum.GVG_020: return new Sim_GVG_020();
                case cardIDEnum.GVG_021: return new Sim_GVG_021();
                case cardIDEnum.GVG_022: return new Sim_GVG_022();
                case cardIDEnum.GVG_023: return new Sim_GVG_023();
                case cardIDEnum.GVG_024: return new Sim_GVG_024();
                case cardIDEnum.GVG_025: return new Sim_GVG_025();
                case cardIDEnum.GVG_026: return new Sim_GVG_026();
                case cardIDEnum.GVG_027: return new Sim_GVG_027();
                case cardIDEnum.GVG_028: return new Sim_GVG_028();
                case cardIDEnum.GVG_028t: return new Sim_GVG_028t();
                case cardIDEnum.GVG_029: return new Sim_GVG_029();
                case cardIDEnum.GVG_030: return new Sim_GVG_030();
                case cardIDEnum.GVG_030a: return new Sim_GVG_030a();
                case cardIDEnum.GVG_030b: return new Sim_GVG_030b();
                case cardIDEnum.GVG_031: return new Sim_GVG_031();
                case cardIDEnum.GVG_032: return new Sim_GVG_032();
                case cardIDEnum.GVG_032a: return new Sim_GVG_032a();
                case cardIDEnum.GVG_032b: return new Sim_GVG_032b();
                case cardIDEnum.GVG_033: return new Sim_GVG_033();
                case cardIDEnum.GVG_034: return new Sim_GVG_034();
                case cardIDEnum.GVG_035: return new Sim_GVG_035();
                case cardIDEnum.GVG_036: return new Sim_GVG_036();
                case cardIDEnum.GVG_037: return new Sim_GVG_037();
                case cardIDEnum.GVG_038: return new Sim_GVG_038();
                case cardIDEnum.GVG_039: return new Sim_GVG_039();
                case cardIDEnum.GVG_040: return new Sim_GVG_040();
                case cardIDEnum.GVG_041: return new Sim_GVG_041();
                case cardIDEnum.GVG_041a: return new Sim_GVG_041a();
                case cardIDEnum.GVG_041b: return new Sim_GVG_041b();
                case cardIDEnum.GVG_042: return new Sim_GVG_042();
                case cardIDEnum.GVG_043: return new Sim_GVG_043();
                case cardIDEnum.GVG_044: return new Sim_GVG_044();
                case cardIDEnum.GVG_045: return new Sim_GVG_045();
                case cardIDEnum.GVG_045t: return new Sim_GVG_045t();
                case cardIDEnum.GVG_046: return new Sim_GVG_046();
                case cardIDEnum.GVG_047: return new Sim_GVG_047();
                case cardIDEnum.GVG_048: return new Sim_GVG_048();
                case cardIDEnum.GVG_049: return new Sim_GVG_049();
                case cardIDEnum.GVG_050: return new Sim_GVG_050();
                case cardIDEnum.GVG_051: return new Sim_GVG_051();
                case cardIDEnum.GVG_052: return new Sim_GVG_052();
                case cardIDEnum.GVG_053: return new Sim_GVG_053();
                case cardIDEnum.GVG_054: return new Sim_GVG_054();
                case cardIDEnum.GVG_055: return new Sim_GVG_055();
                case cardIDEnum.GVG_056: return new Sim_GVG_056();
                case cardIDEnum.GVG_056t: return new Sim_GVG_056t();
                case cardIDEnum.GVG_057: return new Sim_GVG_057();
                case cardIDEnum.GVG_058: return new Sim_GVG_058();
                case cardIDEnum.GVG_059: return new Sim_GVG_059();
                case cardIDEnum.GVG_060: return new Sim_GVG_060();
                case cardIDEnum.GVG_061: return new Sim_GVG_061();
                case cardIDEnum.GVG_062: return new Sim_GVG_062();
                case cardIDEnum.GVG_063: return new Sim_GVG_063();
                case cardIDEnum.GVG_064: return new Sim_GVG_064();
                case cardIDEnum.GVG_065: return new Sim_GVG_065();
                case cardIDEnum.GVG_066: return new Sim_GVG_066();
                case cardIDEnum.GVG_067: return new Sim_GVG_067();
                case cardIDEnum.GVG_068: return new Sim_GVG_068();
                case cardIDEnum.GVG_069: return new Sim_GVG_069();
                case cardIDEnum.GVG_070: return new Sim_GVG_070();
                case cardIDEnum.GVG_071: return new Sim_GVG_071();
                case cardIDEnum.GVG_072: return new Sim_GVG_072();
                case cardIDEnum.GVG_073: return new Sim_GVG_073();
                case cardIDEnum.GVG_074: return new Sim_GVG_074();
                case cardIDEnum.GVG_075: return new Sim_GVG_075();
                case cardIDEnum.GVG_076: return new Sim_GVG_076();
                case cardIDEnum.GVG_077: return new Sim_GVG_077();
                case cardIDEnum.GVG_078: return new Sim_GVG_078();
                case cardIDEnum.GVG_079: return new Sim_GVG_079();
                case cardIDEnum.GVG_080: return new Sim_GVG_080();
                case cardIDEnum.GVG_080t: return new Sim_GVG_080t();
                case cardIDEnum.GVG_081: return new Sim_GVG_081();
                case cardIDEnum.GVG_082: return new Sim_GVG_082();
                case cardIDEnum.GVG_083: return new Sim_GVG_083();
                case cardIDEnum.GVG_084: return new Sim_GVG_084();
                case cardIDEnum.GVG_085: return new Sim_GVG_085();
                case cardIDEnum.GVG_086: return new Sim_GVG_086();
                case cardIDEnum.GVG_087: return new Sim_GVG_087();
                case cardIDEnum.GVG_088: return new Sim_GVG_088();
                case cardIDEnum.GVG_089: return new Sim_GVG_089();
                case cardIDEnum.GVG_090: return new Sim_GVG_090();
                case cardIDEnum.GVG_091: return new Sim_GVG_091();
                case cardIDEnum.GVG_092: return new Sim_GVG_092();
                case cardIDEnum.GVG_093: return new Sim_GVG_093();
                case cardIDEnum.GVG_094: return new Sim_GVG_094();
                case cardIDEnum.GVG_095: return new Sim_GVG_095();
                case cardIDEnum.GVG_096: return new Sim_GVG_096();
                case cardIDEnum.GVG_097: return new Sim_GVG_097();
                case cardIDEnum.GVG_098: return new Sim_GVG_098();
                case cardIDEnum.GVG_099: return new Sim_GVG_099();
                case cardIDEnum.GVG_100: return new Sim_GVG_100();
                case cardIDEnum.GVG_101: return new Sim_GVG_101();
                case cardIDEnum.GVG_102: return new Sim_GVG_102();
                case cardIDEnum.GVG_103: return new Sim_GVG_103();
                case cardIDEnum.GVG_104: return new Sim_GVG_104();
                case cardIDEnum.GVG_105: return new Sim_GVG_105();
                case cardIDEnum.GVG_106: return new Sim_GVG_106();
                case cardIDEnum.GVG_107: return new Sim_GVG_107();
                case cardIDEnum.GVG_108: return new Sim_GVG_108();
                case cardIDEnum.GVG_109: return new Sim_GVG_109();
                case cardIDEnum.GVG_110: return new Sim_GVG_110();
                case cardIDEnum.GVG_110t: return new Sim_GVG_110t();
                case cardIDEnum.GVG_111: return new Sim_GVG_111();
                case cardIDEnum.GVG_111t: return new Sim_GVG_111t();
                case cardIDEnum.GVG_112: return new Sim_GVG_112();
                case cardIDEnum.GVG_113: return new Sim_GVG_113();
                case cardIDEnum.GVG_114: return new Sim_GVG_114();
                case cardIDEnum.GVG_115: return new Sim_GVG_115();
                case cardIDEnum.GVG_116: return new Sim_GVG_116();
                case cardIDEnum.GVG_117: return new Sim_GVG_117();
                case cardIDEnum.GVG_118: return new Sim_GVG_118();
                case cardIDEnum.GVG_119: return new Sim_GVG_119();
                case cardIDEnum.GVG_120: return new Sim_GVG_120();
                case cardIDEnum.GVG_121: return new Sim_GVG_121();
                case cardIDEnum.GVG_122: return new Sim_GVG_122();
                case cardIDEnum.GVG_123: return new Sim_GVG_123();
                
                case cardIDEnum.HERO_01: return new Sim_HERO_01();
                case cardIDEnum.HERO_01a: return new Sim_HERO_01();
                case cardIDEnum.HERO_01b: return new Sim_HERO_01();
                case cardIDEnum.HERO_02: return new Sim_HERO_02();
                case cardIDEnum.HERO_02a: return new Sim_HERO_02();
                case cardIDEnum.HERO_02b: return new Sim_HERO_02();
                case cardIDEnum.HERO_03: return new Sim_HERO_03();
                case cardIDEnum.HERO_03a: return new Sim_HERO_03();
                case cardIDEnum.HERO_04: return new Sim_HERO_04();
                case cardIDEnum.HERO_04a: return new Sim_HERO_04();
                case cardIDEnum.HERO_04b: return new Sim_HERO_04();
                case cardIDEnum.HERO_05: return new Sim_HERO_05();
                case cardIDEnum.HERO_05a: return new Sim_HERO_05();
                case cardIDEnum.HERO_05b: return new Sim_HERO_05();
                case cardIDEnum.HERO_06: return new Sim_HERO_06();
                case cardIDEnum.HERO_06a: return new Sim_HERO_06();
                case cardIDEnum.HERO_07: return new Sim_HERO_07();
                case cardIDEnum.HERO_07a: return new Sim_HERO_07();
                case cardIDEnum.HERO_08: return new Sim_HERO_08();
                case cardIDEnum.HERO_08a: return new Sim_HERO_08();
                case cardIDEnum.HERO_08b: return new Sim_HERO_08();
                case cardIDEnum.HERO_08c: return new Sim_HERO_08();
                case cardIDEnum.HERO_09: return new Sim_HERO_09();
                case cardIDEnum.HERO_09a: return new Sim_HERO_09();
                case cardIDEnum.HERO_09b: return new Sim_HERO_09();

                //case cardIDEnum.KAR_003a: return new Sim_KAR_003a();
                //case cardIDEnum.KAR_003b: return new Sim_KAR_003b();
                case cardIDEnum.KAR_004: return new Sim_KAR_004();
                case cardIDEnum.KAR_004a: return new Sim_KAR_004a();
                case cardIDEnum.KAR_005: return new Sim_KAR_005();
                case cardIDEnum.KAR_005a: return new Sim_KAR_005a();
                case cardIDEnum.KAR_006: return new Sim_KAR_006();
                case cardIDEnum.KAR_009: return new Sim_KAR_009();
                case cardIDEnum.KAR_010: return new Sim_KAR_010();
                case cardIDEnum.KAR_010a: return new Sim_KAR_010a();
                case cardIDEnum.KAR_011: return new Sim_KAR_011();
                case cardIDEnum.KAR_013: return new Sim_KAR_013();
                case cardIDEnum.KAR_021: return new Sim_KAR_021();
                case cardIDEnum.KAR_025: return new Sim_KAR_025();
                case cardIDEnum.KAR_025a: return new Sim_KAR_025a();
                case cardIDEnum.KAR_025b: return new Sim_KAR_025b();
                case cardIDEnum.KAR_025c: return new Sim_KAR_025c();
                case cardIDEnum.KAR_026: return new Sim_KAR_026();
                case cardIDEnum.KAR_026t: return new Sim_KAR_026t();
                case cardIDEnum.KAR_028: return new Sim_KAR_028();
                case cardIDEnum.KAR_029: return new Sim_KAR_029();
                case cardIDEnum.KAR_030: return new Sim_KAR_030();
                case cardIDEnum.KAR_030a: return new Sim_KAR_030a();
                case cardIDEnum.KAR_033: return new Sim_KAR_033();
                //case cardIDEnum.KAR_035: return new Sim_KAR_035();
                case cardIDEnum.KAR_036: return new Sim_KAR_036();
                //case cardIDEnum.KAR_036e: return new Sim_KAR_036e();
                case cardIDEnum.KAR_037: return new Sim_KAR_037();
                //case cardIDEnum.KAR_037t: return new Sim_KAR_037t();
                case cardIDEnum.KAR_041: return new Sim_KAR_041();
                case cardIDEnum.KAR_044: return new Sim_KAR_044();
                case cardIDEnum.KAR_044a: return new Sim_KAR_044a();
                case cardIDEnum.KAR_057: return new Sim_KAR_057();
                case cardIDEnum.KAR_061: return new Sim_KAR_061();
                case cardIDEnum.KAR_062: return new Sim_KAR_062();
                case cardIDEnum.KAR_063: return new Sim_KAR_063();
                case cardIDEnum.KAR_065: return new Sim_KAR_065();
                case cardIDEnum.KAR_069: return new Sim_KAR_069();
                case cardIDEnum.KAR_070: return new Sim_KAR_070();
                case cardIDEnum.KAR_073: return new Sim_KAR_073();
                case cardIDEnum.KAR_075: return new Sim_KAR_075();
                case cardIDEnum.KAR_076: return new Sim_KAR_076();
                case cardIDEnum.KAR_077: return new Sim_KAR_077();
                //case cardIDEnum.KAR_077e: return new Sim_KAR_077e();
                case cardIDEnum.KAR_089: return new Sim_KAR_089();
                case cardIDEnum.KAR_091: return new Sim_KAR_091();
                case cardIDEnum.KAR_092: return new Sim_KAR_092();
                case cardIDEnum.KAR_094: return new Sim_KAR_094();
                case cardIDEnum.KAR_094a: return new Sim_KAR_094a();
                case cardIDEnum.KAR_095: return new Sim_KAR_095();
                //case cardIDEnum.KAR_095e: return new Sim_KAR_095e();
                case cardIDEnum.KAR_096: return new Sim_KAR_096();
                case cardIDEnum.KAR_097: return new Sim_KAR_097();
                case cardIDEnum.KAR_097t: return new Sim_KAR_097t();
                case cardIDEnum.KAR_114: return new Sim_KAR_114();
                //case cardIDEnum.KAR_114e: return new Sim_KAR_114e();
                case cardIDEnum.KAR_204: return new Sim_KAR_204();
                case cardIDEnum.KAR_205: return new Sim_KAR_205();
                case cardIDEnum.KAR_300: return new Sim_KAR_300();
                case cardIDEnum.KAR_702: return new Sim_KAR_702();
                //case cardIDEnum.KAR_702e: return new Sim_KAR_702e();
                case cardIDEnum.KAR_710: return new Sim_KAR_710();
                case cardIDEnum.KAR_710m: return new Sim_KAR_710m();
                case cardIDEnum.KAR_711: return new Sim_KAR_711();
                case cardIDEnum.KAR_712: return new Sim_KAR_712();
                
                case cardIDEnum.LOEA10_3: return new Sim_LOEA10_3();
                case cardIDEnum.LOEA16_3: return new Sim_LOEA16_3();
                case cardIDEnum.LOEA16_4: return new Sim_LOEA16_4();
                case cardIDEnum.LOEA16_5: return new Sim_LOEA16_5();
                case cardIDEnum.LOEA16_5t: return new Sim_LOEA16_5t();
                
                case cardIDEnum.LOE_002: return new Sim_LOE_002();
                case cardIDEnum.LOE_002t: return new Sim_LOE_002t();
                case cardIDEnum.LOE_003: return new Sim_LOE_003();
                case cardIDEnum.LOE_006: return new Sim_LOE_006();
                case cardIDEnum.LOE_007: return new Sim_LOE_007();
                case cardIDEnum.LOE_007t: return new Sim_LOE_007t();
                case cardIDEnum.LOE_009: return new Sim_LOE_009();
                case cardIDEnum.LOE_009t: return new Sim_LOE_009t();
                case cardIDEnum.LOE_010: return new Sim_LOE_010();
                case cardIDEnum.LOE_011: return new Sim_LOE_011();
                case cardIDEnum.LOE_012: return new Sim_LOE_012();
                case cardIDEnum.LOE_016: return new Sim_LOE_016();
                case cardIDEnum.LOE_017: return new Sim_LOE_017();
                case cardIDEnum.LOE_018: return new Sim_LOE_018();
                case cardIDEnum.LOE_019: return new Sim_LOE_019();
                case cardIDEnum.LOE_019t2: return new Sim_LOE_019t2();
                case cardIDEnum.LOE_019t: return new Sim_LOE_019t();
                case cardIDEnum.LOE_020: return new Sim_LOE_020();
                case cardIDEnum.LOE_021: return new Sim_LOE_021();
                case cardIDEnum.LOE_022: return new Sim_LOE_022();
                case cardIDEnum.LOE_023: return new Sim_LOE_023();
                case cardIDEnum.LOE_026: return new Sim_LOE_026();
                case cardIDEnum.LOE_027: return new Sim_LOE_027();
                case cardIDEnum.LOE_029: return new Sim_LOE_029();
                case cardIDEnum.LOE_038: return new Sim_LOE_038();
                case cardIDEnum.LOE_039: return new Sim_LOE_039();
                case cardIDEnum.LOE_046: return new Sim_LOE_046();
                case cardIDEnum.LOE_047: return new Sim_LOE_047();
                case cardIDEnum.LOE_050: return new Sim_LOE_050();
                case cardIDEnum.LOE_051: return new Sim_LOE_051();
                case cardIDEnum.LOE_053: return new Sim_LOE_053();
                case cardIDEnum.LOE_061: return new Sim_LOE_061();
                case cardIDEnum.LOE_073: return new Sim_LOE_073();
                case cardIDEnum.LOE_076: return new Sim_LOE_076();
                case cardIDEnum.LOE_077: return new Sim_LOE_077();
                case cardIDEnum.LOE_079: return new Sim_LOE_079();
                case cardIDEnum.LOE_086: return new Sim_LOE_086();
                case cardIDEnum.LOE_089: return new Sim_LOE_089();
                case cardIDEnum.LOE_089t: return new Sim_LOE_089t();
                case cardIDEnum.LOE_092: return new Sim_LOE_092();
                case cardIDEnum.LOE_104: return new Sim_LOE_104();
                case cardIDEnum.LOE_105: return new Sim_LOE_105();
                case cardIDEnum.LOE_107: return new Sim_LOE_107();
                case cardIDEnum.LOE_110: return new Sim_LOE_110();
                case cardIDEnum.LOE_110t: return new Sim_LOE_110t();
                case cardIDEnum.LOE_111: return new Sim_LOE_111();
                case cardIDEnum.LOE_113: return new Sim_LOE_113();
                case cardIDEnum.LOE_115: return new Sim_LOE_115();
                case cardIDEnum.LOE_115a: return new Sim_LOE_115a();
                case cardIDEnum.LOE_115b: return new Sim_LOE_115b();
                case cardIDEnum.LOE_116: return new Sim_LOE_116();
                case cardIDEnum.LOE_118: return new Sim_LOE_118();
                case cardIDEnum.LOE_119: return new Sim_LOE_119();
                
                case cardIDEnum.Mekka1: return new Sim_Mekka1();
                case cardIDEnum.Mekka2: return new Sim_Mekka2();
                case cardIDEnum.Mekka3: return new Sim_Mekka3();
                case cardIDEnum.Mekka4: return new Sim_Mekka4();
                case cardIDEnum.Mekka4t: return new Sim_Mekka4t();
                
                case cardIDEnum.NEW1_003: return new Sim_NEW1_003();
                case cardIDEnum.NEW1_004: return new Sim_NEW1_004();
                case cardIDEnum.NEW1_005: return new Sim_NEW1_005();
                case cardIDEnum.NEW1_007: return new Sim_NEW1_007();
                case cardIDEnum.NEW1_007a: return new Sim_NEW1_007a();
                case cardIDEnum.NEW1_007b: return new Sim_NEW1_007b();
                case cardIDEnum.NEW1_008: return new Sim_NEW1_008();
                case cardIDEnum.NEW1_008a: return new Sim_NEW1_008a();
                case cardIDEnum.NEW1_008b: return new Sim_NEW1_008b();
                case cardIDEnum.NEW1_009: return new Sim_NEW1_009();
                case cardIDEnum.NEW1_010: return new Sim_NEW1_010();
                case cardIDEnum.NEW1_011: return new Sim_NEW1_011();
                case cardIDEnum.NEW1_012: return new Sim_NEW1_012();
                case cardIDEnum.NEW1_014: return new Sim_NEW1_014();
                case cardIDEnum.NEW1_016: return new Sim_NEW1_016();
                case cardIDEnum.NEW1_017: return new Sim_NEW1_017();
                case cardIDEnum.NEW1_018: return new Sim_NEW1_018();
                case cardIDEnum.NEW1_019: return new Sim_NEW1_019();
                case cardIDEnum.NEW1_020: return new Sim_NEW1_020();
                case cardIDEnum.NEW1_021: return new Sim_NEW1_021();
                case cardIDEnum.NEW1_022: return new Sim_NEW1_022();
                case cardIDEnum.NEW1_023: return new Sim_NEW1_023();
                case cardIDEnum.NEW1_024: return new Sim_NEW1_024();
                case cardIDEnum.NEW1_025: return new Sim_NEW1_025();
                case cardIDEnum.NEW1_026: return new Sim_NEW1_026();
                case cardIDEnum.NEW1_026t: return new Sim_NEW1_026t();
                case cardIDEnum.NEW1_027: return new Sim_NEW1_027();
                case cardIDEnum.NEW1_029: return new Sim_NEW1_029();
                case cardIDEnum.NEW1_030: return new Sim_NEW1_030();
                case cardIDEnum.NEW1_031: return new Sim_NEW1_031();
                case cardIDEnum.NEW1_032: return new Sim_NEW1_032();
                case cardIDEnum.NEW1_033: return new Sim_NEW1_033();
                case cardIDEnum.NEW1_034: return new Sim_NEW1_034();
                case cardIDEnum.NEW1_036: return new Sim_NEW1_036();
                case cardIDEnum.NEW1_037: return new Sim_NEW1_037();
                case cardIDEnum.NEW1_038: return new Sim_NEW1_038();
                case cardIDEnum.NEW1_040: return new Sim_NEW1_040();
                case cardIDEnum.NEW1_040t: return new Sim_NEW1_040t();
                case cardIDEnum.NEW1_041: return new Sim_NEW1_041();
                
                case cardIDEnum.OG_006: return new Sim_OG_006();
                case cardIDEnum.OG_006a: return new Sim_OG_006a();
                case cardIDEnum.OG_006b: return new Sim_OG_006b();
                case cardIDEnum.OG_023: return new Sim_OG_023();
                case cardIDEnum.OG_024: return new Sim_OG_024();
                case cardIDEnum.OG_026: return new Sim_OG_026();
                case cardIDEnum.OG_027: return new Sim_OG_027();
                case cardIDEnum.OG_031: return new Sim_OG_031();
                case cardIDEnum.OG_031a: return new Sim_OG_031a();
                case cardIDEnum.OG_033: return new Sim_OG_033();
                case cardIDEnum.OG_042: return new Sim_OG_042();
                case cardIDEnum.OG_044: return new Sim_OG_044();
                case cardIDEnum.OG_045: return new Sim_OG_045();
                case cardIDEnum.OG_047: return new Sim_OG_047();
                case cardIDEnum.OG_048: return new Sim_OG_048();
                case cardIDEnum.OG_051: return new Sim_OG_051();
                case cardIDEnum.OG_061: return new Sim_OG_061();
                case cardIDEnum.OG_070: return new Sim_OG_070();
                case cardIDEnum.OG_072: return new Sim_OG_072();
                case cardIDEnum.OG_073: return new Sim_OG_073();
                case cardIDEnum.OG_080: return new Sim_OG_080();
                case cardIDEnum.OG_080b: return new Sim_OG_080b();
                case cardIDEnum.OG_080c: return new Sim_OG_080c();
                case cardIDEnum.OG_080d: return new Sim_OG_080d();
                case cardIDEnum.OG_080e: return new Sim_OG_080e();
                case cardIDEnum.OG_080f: return new Sim_OG_080f();
                case cardIDEnum.OG_081: return new Sim_OG_081();
                case cardIDEnum.OG_082: return new Sim_OG_082();
                case cardIDEnum.OG_083: return new Sim_OG_083();
                case cardIDEnum.OG_085: return new Sim_OG_085();
                case cardIDEnum.OG_086: return new Sim_OG_086();
                case cardIDEnum.OG_090: return new Sim_OG_090();
                case cardIDEnum.OG_094: return new Sim_OG_094();
                case cardIDEnum.OG_096: return new Sim_OG_096();
                case cardIDEnum.OG_100: return new Sim_OG_100();
                case cardIDEnum.OG_101: return new Sim_OG_101();
                case cardIDEnum.OG_102: return new Sim_OG_102();
                case cardIDEnum.OG_104: return new Sim_OG_104();
                case cardIDEnum.OG_109: return new Sim_OG_109();
                case cardIDEnum.OG_113: return new Sim_OG_113();
                case cardIDEnum.OG_114: return new Sim_OG_114();
                case cardIDEnum.OG_116: return new Sim_OG_116();
                case cardIDEnum.OG_118: return new Sim_OG_118();
                case cardIDEnum.OG_120: return new Sim_OG_120();
                case cardIDEnum.OG_121: return new Sim_OG_121();
                case cardIDEnum.OG_122: return new Sim_OG_122();
                case cardIDEnum.OG_123: return new Sim_OG_123();
                case cardIDEnum.OG_131: return new Sim_OG_131();
                case cardIDEnum.OG_133: return new Sim_OG_133();
                case cardIDEnum.OG_134: return new Sim_OG_134();
                case cardIDEnum.OG_141: return new Sim_OG_141();
                case cardIDEnum.OG_142: return new Sim_OG_142();
                case cardIDEnum.OG_145: return new Sim_OG_145();
                case cardIDEnum.OG_147: return new Sim_OG_147();
                case cardIDEnum.OG_149: return new Sim_OG_149();
                case cardIDEnum.OG_150: return new Sim_OG_150();
                case cardIDEnum.OG_151: return new Sim_OG_151();
                case cardIDEnum.OG_152: return new Sim_OG_152();
                case cardIDEnum.OG_153: return new Sim_OG_153();
                case cardIDEnum.OG_156: return new Sim_OG_156();
                case cardIDEnum.OG_158: return new Sim_OG_158();
                case cardIDEnum.OG_161: return new Sim_OG_161();
                case cardIDEnum.OG_162: return new Sim_OG_162();
                case cardIDEnum.OG_173: return new Sim_OG_173();
                case cardIDEnum.OG_173a: return new Sim_OG_173a();
                case cardIDEnum.OG_174: return new Sim_OG_174();
                case cardIDEnum.OG_176: return new Sim_OG_176();
                case cardIDEnum.OG_179: return new Sim_OG_179();
                case cardIDEnum.OG_188: return new Sim_OG_188();
                case cardIDEnum.OG_195: return new Sim_OG_195();
                case cardIDEnum.OG_198: return new Sim_OG_198();
                case cardIDEnum.OG_200: return new Sim_OG_200();
                case cardIDEnum.OG_202: return new Sim_OG_202();
                case cardIDEnum.OG_206: return new Sim_OG_206();
                case cardIDEnum.OG_207: return new Sim_OG_207();
                case cardIDEnum.OG_209: return new Sim_OG_209();
                case cardIDEnum.OG_211: return new Sim_OG_211();
                case cardIDEnum.OG_216: return new Sim_OG_216();
                case cardIDEnum.OG_218: return new Sim_OG_218();
                case cardIDEnum.OG_220: return new Sim_OG_220();
                case cardIDEnum.OG_221: return new Sim_OG_221();
                case cardIDEnum.OG_222: return new Sim_OG_222();
                case cardIDEnum.OG_223: return new Sim_OG_223();
                case cardIDEnum.OG_229: return new Sim_OG_229();
                case cardIDEnum.OG_234: return new Sim_OG_234();
                case cardIDEnum.OG_239: return new Sim_OG_239();
                case cardIDEnum.OG_241: return new Sim_OG_241();
                case cardIDEnum.OG_241a: return new Sim_OG_241a();
                case cardIDEnum.OG_247: return new Sim_OG_247();
                case cardIDEnum.OG_248: return new Sim_OG_248();
                case cardIDEnum.OG_249: return new Sim_OG_249();
                case cardIDEnum.OG_249a: return new Sim_OG_249a();
                case cardIDEnum.OG_254: return new Sim_OG_254();
                case cardIDEnum.OG_255: return new Sim_OG_255();
                case cardIDEnum.OG_256: return new Sim_OG_256();
                case cardIDEnum.OG_267: return new Sim_OG_267();
                case cardIDEnum.OG_271: return new Sim_OG_271();
                case cardIDEnum.OG_272: return new Sim_OG_272();
                case cardIDEnum.OG_273: return new Sim_OG_273();
                case cardIDEnum.OG_276: return new Sim_OG_276();
                case cardIDEnum.OG_280: return new Sim_OG_280();
                case cardIDEnum.OG_281: return new Sim_OG_281();
                case cardIDEnum.OG_282: return new Sim_OG_282();
                case cardIDEnum.OG_283: return new Sim_OG_283();
                case cardIDEnum.OG_284: return new Sim_OG_284();
                case cardIDEnum.OG_286: return new Sim_OG_286();
                case cardIDEnum.OG_290: return new Sim_OG_290();
                case cardIDEnum.OG_291: return new Sim_OG_291();
                case cardIDEnum.OG_292: return new Sim_OG_292();
                case cardIDEnum.OG_293: return new Sim_OG_293();
                case cardIDEnum.OG_295: return new Sim_OG_295();
                case cardIDEnum.OG_300: return new Sim_OG_300();
                case cardIDEnum.OG_301: return new Sim_OG_301();
                case cardIDEnum.OG_302: return new Sim_OG_302();
                case cardIDEnum.OG_303: return new Sim_OG_303();
                case cardIDEnum.OG_308: return new Sim_OG_308();
                case cardIDEnum.OG_309: return new Sim_OG_309();
                case cardIDEnum.OG_310: return new Sim_OG_310();
                case cardIDEnum.OG_311: return new Sim_OG_311();
                case cardIDEnum.OG_312: return new Sim_OG_312();
                case cardIDEnum.OG_313: return new Sim_OG_313();
                case cardIDEnum.OG_314: return new Sim_OG_314();
                case cardIDEnum.OG_315: return new Sim_OG_315();
                case cardIDEnum.OG_316: return new Sim_OG_316();
                case cardIDEnum.OG_317: return new Sim_OG_317();
                case cardIDEnum.OG_318: return new Sim_OG_318();
                case cardIDEnum.OG_319: return new Sim_OG_319();
                case cardIDEnum.OG_320: return new Sim_OG_320();
                case cardIDEnum.OG_321: return new Sim_OG_321();
                case cardIDEnum.OG_322: return new Sim_OG_322();
                case cardIDEnum.OG_323: return new Sim_OG_323();
                case cardIDEnum.OG_325: return new Sim_OG_325();
                case cardIDEnum.OG_326: return new Sim_OG_326();
                case cardIDEnum.OG_327: return new Sim_OG_327();
                case cardIDEnum.OG_328: return new Sim_OG_328();
                case cardIDEnum.OG_330: return new Sim_OG_330();
                case cardIDEnum.OG_334: return new Sim_OG_334();
                case cardIDEnum.OG_335: return new Sim_OG_335();
                case cardIDEnum.OG_337: return new Sim_OG_337();
                case cardIDEnum.OG_339: return new Sim_OG_339();
                case cardIDEnum.OG_340: return new Sim_OG_340();
                
                case cardIDEnum.PART_001: return new Sim_PART_001();
                case cardIDEnum.PART_002: return new Sim_PART_002();
                case cardIDEnum.PART_003: return new Sim_PART_003();
                case cardIDEnum.PART_004: return new Sim_PART_004();
                case cardIDEnum.PART_005: return new Sim_PART_005();
                case cardIDEnum.PART_006: return new Sim_PART_006();
                case cardIDEnum.PART_007: return new Sim_PART_007();
                
                case cardIDEnum.PRO_001: return new Sim_PRO_001();
                case cardIDEnum.PRO_001a: return new Sim_PRO_001a();
                case cardIDEnum.PRO_001at: return new Sim_PRO_001at();
                case cardIDEnum.PRO_001b: return new Sim_PRO_001b();
                case cardIDEnum.PRO_001c: return new Sim_PRO_001c();
                
                case cardIDEnum.TB_007: return new Sim_TB_007();
                case cardIDEnum.TU4d_003: return new Sim_TU4d_003();
                case cardIDEnum.TU4f_004: return new Sim_TU4f_004();
                case cardIDEnum.TU4f_007: return new Sim_TU4f_007();
                case cardIDEnum.ds1_whelptoken: return new Sim_ds1_whelptoken();
                case cardIDEnum.hexfrog: return new Sim_hexfrog();
                case cardIDEnum.skele11: return new Sim_skele11();
                case cardIDEnum.skele21: return new Sim_skele21();
                case cardIDEnum.tt_004: return new Sim_tt_004();
                case cardIDEnum.tt_010: return new Sim_tt_010();
                case cardIDEnum.tt_010a: return new Sim_tt_010a();
                
                case cardIDEnum.PlaceholderCard: return new Sim_PlaceholderCard();
            }

            return new SimTemplate();
        }

        public PenTemplate getPenCard(cardIDEnum id)
        {
            switch (id)
            {
                case cardIDEnum.AT_001: return new Pen_AT_001();
                case cardIDEnum.AT_002: return new Pen_AT_002();
                case cardIDEnum.AT_003: return new Pen_AT_003();
                case cardIDEnum.AT_004: return new Pen_AT_004();
                case cardIDEnum.AT_005: return new Pen_AT_005();
                case cardIDEnum.AT_005t: return new Pen_AT_005t();
                case cardIDEnum.AT_006: return new Pen_AT_006();
                case cardIDEnum.AT_007: return new Pen_AT_007();
                case cardIDEnum.AT_008: return new Pen_AT_008();
                case cardIDEnum.AT_009: return new Pen_AT_009();
                case cardIDEnum.AT_010: return new Pen_AT_010();
                case cardIDEnum.AT_011: return new Pen_AT_011();
                case cardIDEnum.AT_012: return new Pen_AT_012();
                case cardIDEnum.AT_013: return new Pen_AT_013();
                case cardIDEnum.AT_014: return new Pen_AT_014();
                case cardIDEnum.AT_015: return new Pen_AT_015();
                case cardIDEnum.AT_016: return new Pen_AT_016();
                case cardIDEnum.AT_017: return new Pen_AT_017();
                case cardIDEnum.AT_018: return new Pen_AT_018();
                case cardIDEnum.AT_019: return new Pen_AT_019();
                case cardIDEnum.AT_020: return new Pen_AT_020();
                case cardIDEnum.AT_021: return new Pen_AT_021();
                case cardIDEnum.AT_022: return new Pen_AT_022();
                case cardIDEnum.AT_023: return new Pen_AT_023();
                case cardIDEnum.AT_024: return new Pen_AT_024();
                case cardIDEnum.AT_025: return new Pen_AT_025();
                case cardIDEnum.AT_026: return new Pen_AT_026();
                case cardIDEnum.AT_027: return new Pen_AT_027();
                case cardIDEnum.AT_028: return new Pen_AT_028();
                case cardIDEnum.AT_029: return new Pen_AT_029();
                case cardIDEnum.AT_030: return new Pen_AT_030();
                case cardIDEnum.AT_031: return new Pen_AT_031();
                case cardIDEnum.AT_032: return new Pen_AT_032();
                case cardIDEnum.AT_033: return new Pen_AT_033();
                case cardIDEnum.AT_034: return new Pen_AT_034();
                case cardIDEnum.AT_035: return new Pen_AT_035();
                case cardIDEnum.AT_035t: return new Pen_AT_035t();
                case cardIDEnum.AT_036: return new Pen_AT_036();
                case cardIDEnum.AT_036t: return new Pen_AT_036t();
                case cardIDEnum.AT_037: return new Pen_AT_037();
                case cardIDEnum.AT_037a: return new Pen_AT_037a();
                case cardIDEnum.AT_037b: return new Pen_AT_037b();
                case cardIDEnum.AT_037t: return new Pen_AT_037t();
                case cardIDEnum.AT_038: return new Pen_AT_038();
                case cardIDEnum.AT_039: return new Pen_AT_039();
                case cardIDEnum.AT_040: return new Pen_AT_040();
                case cardIDEnum.AT_041: return new Pen_AT_041();
                case cardIDEnum.AT_042: return new Pen_AT_042();
                case cardIDEnum.AT_042a: return new Pen_AT_042a();
                case cardIDEnum.AT_042b: return new Pen_AT_042b();
                case cardIDEnum.AT_042t2: return new Pen_AT_042t2();
                case cardIDEnum.AT_042t: return new Pen_AT_042t();
                case cardIDEnum.AT_043: return new Pen_AT_043();
                case cardIDEnum.AT_044: return new Pen_AT_044();
                case cardIDEnum.AT_045: return new Pen_AT_045();
                case cardIDEnum.AT_046: return new Pen_AT_046();
                case cardIDEnum.AT_047: return new Pen_AT_047();
                case cardIDEnum.AT_048: return new Pen_AT_048();
                case cardIDEnum.AT_049: return new Pen_AT_049();
                case cardIDEnum.AT_050: return new Pen_AT_050();
                case cardIDEnum.AT_050t: return new Pen_AT_050t();
                case cardIDEnum.AT_051: return new Pen_AT_051();
                case cardIDEnum.AT_052: return new Pen_AT_052();
                case cardIDEnum.AT_053: return new Pen_AT_053();
                case cardIDEnum.AT_054: return new Pen_AT_054();
                case cardIDEnum.AT_055: return new Pen_AT_055();
                case cardIDEnum.AT_056: return new Pen_AT_056();
                case cardIDEnum.AT_057: return new Pen_AT_057();
                case cardIDEnum.AT_058: return new Pen_AT_058();
                case cardIDEnum.AT_059: return new Pen_AT_059();
                case cardIDEnum.AT_060: return new Pen_AT_060();
                case cardIDEnum.AT_061: return new Pen_AT_061();
                case cardIDEnum.AT_062: return new Pen_AT_062();
                case cardIDEnum.AT_063: return new Pen_AT_063();
                case cardIDEnum.AT_063t: return new Pen_AT_063t();
                case cardIDEnum.AT_064: return new Pen_AT_064();
                case cardIDEnum.AT_065: return new Pen_AT_065();
                case cardIDEnum.AT_066: return new Pen_AT_066();
                case cardIDEnum.AT_067: return new Pen_AT_067();
                case cardIDEnum.AT_068: return new Pen_AT_068();
                case cardIDEnum.AT_069: return new Pen_AT_069();
                case cardIDEnum.AT_070: return new Pen_AT_070();
                case cardIDEnum.AT_071: return new Pen_AT_071();
                case cardIDEnum.AT_072: return new Pen_AT_072();
                case cardIDEnum.AT_073: return new Pen_AT_073();
                case cardIDEnum.AT_074: return new Pen_AT_074();
                case cardIDEnum.AT_075: return new Pen_AT_075();
                case cardIDEnum.AT_076: return new Pen_AT_076();
                case cardIDEnum.AT_077: return new Pen_AT_077();
                case cardIDEnum.AT_078: return new Pen_AT_078();
                case cardIDEnum.AT_079: return new Pen_AT_079();
                case cardIDEnum.AT_080: return new Pen_AT_080();
                case cardIDEnum.AT_081: return new Pen_AT_081();
                case cardIDEnum.AT_082: return new Pen_AT_082();
                case cardIDEnum.AT_083: return new Pen_AT_083();
                case cardIDEnum.AT_084: return new Pen_AT_084();
                case cardIDEnum.AT_085: return new Pen_AT_085();
                case cardIDEnum.AT_086: return new Pen_AT_086();
                case cardIDEnum.AT_087: return new Pen_AT_087();
                case cardIDEnum.AT_088: return new Pen_AT_088();
                case cardIDEnum.AT_089: return new Pen_AT_089();
                case cardIDEnum.AT_090: return new Pen_AT_090();
                case cardIDEnum.AT_091: return new Pen_AT_091();
                case cardIDEnum.AT_092: return new Pen_AT_092();
                case cardIDEnum.AT_093: return new Pen_AT_093();
                case cardIDEnum.AT_094: return new Pen_AT_094();
                case cardIDEnum.AT_095: return new Pen_AT_095();
                case cardIDEnum.AT_096: return new Pen_AT_096();
                case cardIDEnum.AT_097: return new Pen_AT_097();
                case cardIDEnum.AT_098: return new Pen_AT_098();
                case cardIDEnum.AT_099: return new Pen_AT_099();
                case cardIDEnum.AT_099t: return new Pen_AT_099t();
                case cardIDEnum.AT_100: return new Pen_AT_100();
                case cardIDEnum.AT_101: return new Pen_AT_101();
                case cardIDEnum.AT_102: return new Pen_AT_102();
                case cardIDEnum.AT_103: return new Pen_AT_103();
                case cardIDEnum.AT_104: return new Pen_AT_104();
                case cardIDEnum.AT_105: return new Pen_AT_105();
                case cardIDEnum.AT_106: return new Pen_AT_106();
                case cardIDEnum.AT_108: return new Pen_AT_108();
                case cardIDEnum.AT_109: return new Pen_AT_109();
                case cardIDEnum.AT_110: return new Pen_AT_110();
                case cardIDEnum.AT_111: return new Pen_AT_111();
                case cardIDEnum.AT_112: return new Pen_AT_112();
                case cardIDEnum.AT_113: return new Pen_AT_113();
                case cardIDEnum.AT_114: return new Pen_AT_114();
                case cardIDEnum.AT_115: return new Pen_AT_115();
                case cardIDEnum.AT_116: return new Pen_AT_116();
                case cardIDEnum.AT_117: return new Pen_AT_117();
                case cardIDEnum.AT_118: return new Pen_AT_118();
                case cardIDEnum.AT_119: return new Pen_AT_119();
                case cardIDEnum.AT_120: return new Pen_AT_120();
                case cardIDEnum.AT_121: return new Pen_AT_121();
                case cardIDEnum.AT_122: return new Pen_AT_122();
                case cardIDEnum.AT_123: return new Pen_AT_123();
                case cardIDEnum.AT_124: return new Pen_AT_124();
                case cardIDEnum.AT_125: return new Pen_AT_125();
                case cardIDEnum.AT_127: return new Pen_AT_127();
                case cardIDEnum.AT_128: return new Pen_AT_128();
                case cardIDEnum.AT_129: return new Pen_AT_129();
                case cardIDEnum.AT_130: return new Pen_AT_130();
                case cardIDEnum.AT_131: return new Pen_AT_131();
                case cardIDEnum.AT_132: return new Pen_AT_132();
                case cardIDEnum.AT_132_DRUID: return new Pen_AT_132_DRUID();
                case cardIDEnum.AT_132_HUNTER: return new Pen_AT_132_HUNTER();
                case cardIDEnum.AT_132_MAGE: return new Pen_AT_132_MAGE();
                case cardIDEnum.AT_132_PALADIN: return new Pen_AT_132_PALADIN();
                case cardIDEnum.AT_132_PRIEST: return new Pen_AT_132_PRIEST();
                case cardIDEnum.AT_132_ROGUE: return new Pen_AT_132_ROGUE();
                case cardIDEnum.AT_132_ROGUEt: return new Pen_AT_132_ROGUEt();
                case cardIDEnum.AT_132_SHAMAN: return new Pen_AT_132_SHAMAN();
                case cardIDEnum.AT_132_SHAMANa: return new Pen_AT_132_SHAMANa();
                case cardIDEnum.AT_132_SHAMANb: return new Pen_AT_132_SHAMANb();
                case cardIDEnum.AT_132_SHAMANc: return new Pen_AT_132_SHAMANc();
                case cardIDEnum.AT_132_SHAMANd: return new Pen_AT_132_SHAMANd();
                case cardIDEnum.AT_132_WARLOCK: return new Pen_AT_132_WARLOCK();
                case cardIDEnum.AT_132_WARRIOR: return new Pen_AT_132_WARRIOR();
                case cardIDEnum.AT_133: return new Pen_AT_133();
                
                case cardIDEnum.BRM_029: return new Pen_BRM_029();
                
                case cardIDEnum.CS1_042: return new Pen_CS1_042();
                case cardIDEnum.CS1_069: return new Pen_CS1_069();
                case cardIDEnum.CS1_112: return new Pen_CS1_112();
                case cardIDEnum.CS1_113: return new Pen_CS1_113();
                case cardIDEnum.CS1_129: return new Pen_CS1_129();
                case cardIDEnum.CS1_130: return new Pen_CS1_130();
                case cardIDEnum.CS1h_001: return new Pen_CS1h_001();
                case cardIDEnum.CS2_003: return new Pen_CS2_003();
                case cardIDEnum.CS2_004: return new Pen_CS2_004();
                case cardIDEnum.CS2_005: return new Pen_CS2_005();
                case cardIDEnum.CS2_007: return new Pen_CS2_007();
                case cardIDEnum.CS2_008: return new Pen_CS2_008();
                case cardIDEnum.CS2_009: return new Pen_CS2_009();
                case cardIDEnum.CS2_011: return new Pen_CS2_011();
                case cardIDEnum.CS2_012: return new Pen_CS2_012();
                case cardIDEnum.CS2_013: return new Pen_CS2_013();
                case cardIDEnum.CS2_013t: return new Pen_CS2_013t();
                case cardIDEnum.CS2_017: return new Pen_CS2_017();
                case cardIDEnum.CS2_022: return new Pen_CS2_022();
                case cardIDEnum.CS2_023: return new Pen_CS2_023();
                case cardIDEnum.CS2_024: return new Pen_CS2_024();
                case cardIDEnum.CS2_025: return new Pen_CS2_025();
                case cardIDEnum.CS2_026: return new Pen_CS2_026();
                case cardIDEnum.CS2_027: return new Pen_CS2_027();
                case cardIDEnum.CS2_028: return new Pen_CS2_028();
                case cardIDEnum.CS2_029: return new Pen_CS2_029();
                case cardIDEnum.CS2_031: return new Pen_CS2_031();
                case cardIDEnum.CS2_032: return new Pen_CS2_032();
                case cardIDEnum.CS2_033: return new Pen_CS2_033();
                case cardIDEnum.CS2_034: return new Pen_CS2_034();
                case cardIDEnum.CS2_037: return new Pen_CS2_037();
                case cardIDEnum.CS2_038: return new Pen_CS2_038();
                case cardIDEnum.CS2_039: return new Pen_CS2_039();
                case cardIDEnum.CS2_041: return new Pen_CS2_041();
                case cardIDEnum.CS2_042: return new Pen_CS2_042();
                case cardIDEnum.CS2_045: return new Pen_CS2_045();
                case cardIDEnum.CS2_046: return new Pen_CS2_046();
                case cardIDEnum.CS2_049: return new Pen_CS2_049();
                case cardIDEnum.CS2_050: return new Pen_CS2_050();
                case cardIDEnum.CS2_051: return new Pen_CS2_051();
                case cardIDEnum.CS2_052: return new Pen_CS2_052();
                case cardIDEnum.CS2_053: return new Pen_CS2_053();
                case cardIDEnum.CS2_056: return new Pen_CS2_056();
                case cardIDEnum.CS2_057: return new Pen_CS2_057();
                case cardIDEnum.CS2_059: return new Pen_CS2_059();
                case cardIDEnum.CS2_061: return new Pen_CS2_061();
                case cardIDEnum.CS2_062: return new Pen_CS2_062();
                case cardIDEnum.CS2_063: return new Pen_CS2_063();
                case cardIDEnum.CS2_064: return new Pen_CS2_064();
                case cardIDEnum.CS2_065: return new Pen_CS2_065();
                case cardIDEnum.CS2_072: return new Pen_CS2_072();
                case cardIDEnum.CS2_073: return new Pen_CS2_073();
                case cardIDEnum.CS2_074: return new Pen_CS2_074();
                case cardIDEnum.CS2_075: return new Pen_CS2_075();
                case cardIDEnum.CS2_076: return new Pen_CS2_076();
                case cardIDEnum.CS2_077: return new Pen_CS2_077();
                case cardIDEnum.CS2_080: return new Pen_CS2_080();
                case cardIDEnum.CS2_082: return new Pen_CS2_082();
                case cardIDEnum.CS2_083b: return new Pen_CS2_083b();
                case cardIDEnum.CS2_084: return new Pen_CS2_084();
                case cardIDEnum.CS2_087: return new Pen_CS2_087();
                case cardIDEnum.CS2_088: return new Pen_CS2_088();
                case cardIDEnum.CS2_089: return new Pen_CS2_089();
                case cardIDEnum.CS2_091: return new Pen_CS2_091();
                case cardIDEnum.CS2_092: return new Pen_CS2_092();
                case cardIDEnum.CS2_093: return new Pen_CS2_093();
                case cardIDEnum.CS2_094: return new Pen_CS2_094();
                case cardIDEnum.CS2_097: return new Pen_CS2_097();
                case cardIDEnum.CS2_101: return new Pen_CS2_101();
                case cardIDEnum.CS2_101t: return new Pen_CS2_101t();
                case cardIDEnum.CS2_102: return new Pen_CS2_102();
                case cardIDEnum.CS2_103: return new Pen_CS2_103();
                case cardIDEnum.CS2_104: return new Pen_CS2_104();
                case cardIDEnum.CS2_105: return new Pen_CS2_105();
                case cardIDEnum.CS2_106: return new Pen_CS2_106();
                case cardIDEnum.CS2_108: return new Pen_CS2_108();
                case cardIDEnum.CS2_112: return new Pen_CS2_112();
                case cardIDEnum.CS2_114: return new Pen_CS2_114();
                case cardIDEnum.CS2_117: return new Pen_CS2_117();
                case cardIDEnum.CS2_118: return new Pen_CS2_118();
                case cardIDEnum.CS2_119: return new Pen_CS2_119();
                case cardIDEnum.CS2_120: return new Pen_CS2_120();
                case cardIDEnum.CS2_121: return new Pen_CS2_121();
                case cardIDEnum.CS2_122: return new Pen_CS2_122();
                case cardIDEnum.CS2_124: return new Pen_CS2_124();
                case cardIDEnum.CS2_125: return new Pen_CS2_125();
                case cardIDEnum.CS2_127: return new Pen_CS2_127();
                case cardIDEnum.CS2_131: return new Pen_CS2_131();
                case cardIDEnum.CS2_141: return new Pen_CS2_141();
                case cardIDEnum.CS2_142: return new Pen_CS2_142();
                case cardIDEnum.CS2_146: return new Pen_CS2_146();
                case cardIDEnum.CS2_147: return new Pen_CS2_147();
                case cardIDEnum.CS2_150: return new Pen_CS2_150();
                case cardIDEnum.CS2_151: return new Pen_CS2_151();
                case cardIDEnum.CS2_152: return new Pen_CS2_152();
                case cardIDEnum.CS2_155: return new Pen_CS2_155();
                case cardIDEnum.CS2_161: return new Pen_CS2_161();
                case cardIDEnum.CS2_162: return new Pen_CS2_162();
                case cardIDEnum.CS2_168: return new Pen_CS2_168();
                case cardIDEnum.CS2_169: return new Pen_CS2_169();
                case cardIDEnum.CS2_171: return new Pen_CS2_171();
                case cardIDEnum.CS2_172: return new Pen_CS2_172();
                case cardIDEnum.CS2_173: return new Pen_CS2_173();
                case cardIDEnum.CS2_179: return new Pen_CS2_179();
                case cardIDEnum.CS2_181: return new Pen_CS2_181();
                case cardIDEnum.CS2_182: return new Pen_CS2_182();
                case cardIDEnum.CS2_186: return new Pen_CS2_186();
                case cardIDEnum.CS2_187: return new Pen_CS2_187();
                case cardIDEnum.CS2_188: return new Pen_CS2_188();
                case cardIDEnum.CS2_189: return new Pen_CS2_189();
                case cardIDEnum.CS2_196: return new Pen_CS2_196();
                case cardIDEnum.CS2_197: return new Pen_CS2_197();
                case cardIDEnum.CS2_200: return new Pen_CS2_200();
                case cardIDEnum.CS2_201: return new Pen_CS2_201();
                case cardIDEnum.CS2_203: return new Pen_CS2_203();
                case cardIDEnum.CS2_213: return new Pen_CS2_213();
                case cardIDEnum.CS2_221: return new Pen_CS2_221();
                case cardIDEnum.CS2_222: return new Pen_CS2_222();
                case cardIDEnum.CS2_226: return new Pen_CS2_226();
                case cardIDEnum.CS2_227: return new Pen_CS2_227();
                case cardIDEnum.CS2_231: return new Pen_CS2_231();
                case cardIDEnum.CS2_232: return new Pen_CS2_232();
                case cardIDEnum.CS2_233: return new Pen_CS2_233();
                case cardIDEnum.CS2_234: return new Pen_CS2_234();
                case cardIDEnum.CS2_235: return new Pen_CS2_235();
                case cardIDEnum.CS2_236: return new Pen_CS2_236();
                case cardIDEnum.CS2_237: return new Pen_CS2_237();
                case cardIDEnum.CS2_boar: return new Pen_CS2_boar();
                case cardIDEnum.CS2_mirror: return new Pen_CS2_mirror();
                case cardIDEnum.CS2_tk1: return new Pen_CS2_tk1();
                
                case cardIDEnum.DREAM_01: return new Pen_DREAM_01();
                case cardIDEnum.DREAM_02: return new Pen_DREAM_02();
                case cardIDEnum.DREAM_03: return new Pen_DREAM_03();
                case cardIDEnum.DREAM_04: return new Pen_DREAM_04();
                case cardIDEnum.DREAM_05: return new Pen_DREAM_05();
                
                case cardIDEnum.DS1_055: return new Pen_DS1_055();
                case cardIDEnum.DS1_070: return new Pen_DS1_070();
                case cardIDEnum.DS1_175: return new Pen_DS1_175();
                case cardIDEnum.DS1_178: return new Pen_DS1_178();
                case cardIDEnum.DS1_183: return new Pen_DS1_183();
                case cardIDEnum.DS1_184: return new Pen_DS1_184();
                case cardIDEnum.DS1_185: return new Pen_DS1_185();
                case cardIDEnum.DS1_188: return new Pen_DS1_188();
                case cardIDEnum.DS1_233: return new Pen_DS1_233();
                case cardIDEnum.DS1h_292: return new Pen_DS1h_292();
                
                case cardIDEnum.EX1_001: return new Pen_EX1_001();
                case cardIDEnum.EX1_002: return new Pen_EX1_002();
                case cardIDEnum.EX1_004: return new Pen_EX1_004();
                case cardIDEnum.EX1_005: return new Pen_EX1_005();
                case cardIDEnum.EX1_006: return new Pen_EX1_006();
                case cardIDEnum.EX1_007: return new Pen_EX1_007();
                case cardIDEnum.EX1_008: return new Pen_EX1_008();
                case cardIDEnum.EX1_009: return new Pen_EX1_009();
                case cardIDEnum.EX1_010: return new Pen_EX1_010();
                case cardIDEnum.EX1_011: return new Pen_EX1_011();
                case cardIDEnum.EX1_012: return new Pen_EX1_012();
                case cardIDEnum.EX1_014: return new Pen_EX1_014();
                case cardIDEnum.EX1_014t: return new Pen_EX1_014t();
                case cardIDEnum.EX1_015: return new Pen_EX1_015();
                case cardIDEnum.EX1_016: return new Pen_EX1_016();
                case cardIDEnum.EX1_017: return new Pen_EX1_017();
                case cardIDEnum.EX1_019: return new Pen_EX1_019();
                case cardIDEnum.EX1_020: return new Pen_EX1_020();
                case cardIDEnum.EX1_021: return new Pen_EX1_021();
                case cardIDEnum.EX1_023: return new Pen_EX1_023();
                case cardIDEnum.EX1_025: return new Pen_EX1_025();
                case cardIDEnum.EX1_025t: return new Pen_EX1_025t();
                case cardIDEnum.EX1_028: return new Pen_EX1_028();
                case cardIDEnum.EX1_029: return new Pen_EX1_029();
                case cardIDEnum.EX1_032: return new Pen_EX1_032();
                case cardIDEnum.EX1_033: return new Pen_EX1_033();
                case cardIDEnum.EX1_043: return new Pen_EX1_043();
                case cardIDEnum.EX1_044: return new Pen_EX1_044();
                case cardIDEnum.EX1_045: return new Pen_EX1_045();
                case cardIDEnum.EX1_046: return new Pen_EX1_046();
                case cardIDEnum.EX1_048: return new Pen_EX1_048();
                case cardIDEnum.EX1_049: return new Pen_EX1_049();
                case cardIDEnum.EX1_050: return new Pen_EX1_050();
                case cardIDEnum.EX1_055: return new Pen_EX1_055();
                case cardIDEnum.EX1_057: return new Pen_EX1_057();
                case cardIDEnum.EX1_058: return new Pen_EX1_058();
                case cardIDEnum.EX1_059: return new Pen_EX1_059();
                case cardIDEnum.EX1_062: return new Pen_EX1_062();
                case cardIDEnum.EX1_066: return new Pen_EX1_066();
                case cardIDEnum.EX1_067: return new Pen_EX1_067();
                case cardIDEnum.EX1_076: return new Pen_EX1_076();
                case cardIDEnum.EX1_080: return new Pen_EX1_080();
                case cardIDEnum.EX1_082: return new Pen_EX1_082();
                case cardIDEnum.EX1_083: return new Pen_EX1_083();
                case cardIDEnum.EX1_084: return new Pen_EX1_084();
                case cardIDEnum.EX1_085: return new Pen_EX1_085();
                case cardIDEnum.EX1_089: return new Pen_EX1_089();
                case cardIDEnum.EX1_091: return new Pen_EX1_091();
                case cardIDEnum.EX1_093: return new Pen_EX1_093();
                case cardIDEnum.EX1_095: return new Pen_EX1_095();
                case cardIDEnum.EX1_096: return new Pen_EX1_096();
                case cardIDEnum.EX1_097: return new Pen_EX1_097();
                case cardIDEnum.EX1_100: return new Pen_EX1_100();
                case cardIDEnum.EX1_102: return new Pen_EX1_102();
                case cardIDEnum.EX1_103: return new Pen_EX1_103();
                case cardIDEnum.EX1_105: return new Pen_EX1_105();
                case cardIDEnum.EX1_110: return new Pen_EX1_110();
                case cardIDEnum.EX1_110t: return new Pen_EX1_110t();
                case cardIDEnum.EX1_112: return new Pen_EX1_112();
                case cardIDEnum.EX1_116: return new Pen_EX1_116();
                case cardIDEnum.EX1_116t: return new Pen_EX1_116t();
                case cardIDEnum.EX1_124: return new Pen_EX1_124();
                case cardIDEnum.EX1_126: return new Pen_EX1_126();
                case cardIDEnum.EX1_128: return new Pen_EX1_128();
                case cardIDEnum.EX1_129: return new Pen_EX1_129();
                case cardIDEnum.EX1_130: return new Pen_EX1_130();
                case cardIDEnum.EX1_130a: return new Pen_EX1_130a();
                case cardIDEnum.EX1_131: return new Pen_EX1_131();
                case cardIDEnum.EX1_131t: return new Pen_EX1_131t();
                case cardIDEnum.EX1_132: return new Pen_EX1_132();
                case cardIDEnum.EX1_133: return new Pen_EX1_133();
                case cardIDEnum.EX1_134: return new Pen_EX1_134();
                case cardIDEnum.EX1_136: return new Pen_EX1_136();
                case cardIDEnum.EX1_137: return new Pen_EX1_137();
                case cardIDEnum.EX1_144: return new Pen_EX1_144();
                case cardIDEnum.EX1_145: return new Pen_EX1_145();
                case cardIDEnum.EX1_154: return new Pen_EX1_154();
                case cardIDEnum.EX1_154a: return new Pen_EX1_154a();
                case cardIDEnum.EX1_154b: return new Pen_EX1_154b();
                case cardIDEnum.EX1_155: return new Pen_EX1_155();
                case cardIDEnum.EX1_155a: return new Pen_EX1_155a();
                case cardIDEnum.EX1_155b: return new Pen_EX1_155b();
                case cardIDEnum.EX1_158: return new Pen_EX1_158();
                case cardIDEnum.EX1_158t: return new Pen_EX1_158t();
                case cardIDEnum.EX1_160: return new Pen_EX1_160();
                case cardIDEnum.EX1_160a: return new Pen_EX1_160a();
                case cardIDEnum.EX1_160b: return new Pen_EX1_160b();
                case cardIDEnum.EX1_160t: return new Pen_EX1_160t();
                case cardIDEnum.EX1_161: return new Pen_EX1_161();
                case cardIDEnum.EX1_162: return new Pen_EX1_162();
                case cardIDEnum.EX1_164: return new Pen_EX1_164();
                case cardIDEnum.EX1_164a: return new Pen_EX1_164a();
                case cardIDEnum.EX1_164b: return new Pen_EX1_164b();
                case cardIDEnum.EX1_165: return new Pen_EX1_165();
                case cardIDEnum.EX1_165a: return new Pen_EX1_165a();
                case cardIDEnum.EX1_165b: return new Pen_EX1_165b();
                case cardIDEnum.EX1_165t1: return new Pen_EX1_165t1();
                case cardIDEnum.EX1_165t2: return new Pen_EX1_165t2();
                case cardIDEnum.EX1_166: return new Pen_EX1_166();
                case cardIDEnum.EX1_166a: return new Pen_EX1_166a();
                case cardIDEnum.EX1_166b: return new Pen_EX1_166b();
                case cardIDEnum.EX1_169: return new Pen_EX1_169();
                case cardIDEnum.EX1_170: return new Pen_EX1_170();
                case cardIDEnum.EX1_173: return new Pen_EX1_173();
                case cardIDEnum.EX1_178: return new Pen_EX1_178();
                case cardIDEnum.EX1_178a: return new Pen_EX1_178a();
                case cardIDEnum.EX1_178b: return new Pen_EX1_178b();
                case cardIDEnum.EX1_238: return new Pen_EX1_238();
                case cardIDEnum.EX1_241: return new Pen_EX1_241();
                case cardIDEnum.EX1_243: return new Pen_EX1_243();
                case cardIDEnum.EX1_244: return new Pen_EX1_244();
                case cardIDEnum.EX1_245: return new Pen_EX1_245();
                case cardIDEnum.EX1_246: return new Pen_EX1_246();
                case cardIDEnum.EX1_247: return new Pen_EX1_247();
                case cardIDEnum.EX1_248: return new Pen_EX1_248();
                case cardIDEnum.EX1_249: return new Pen_EX1_249();
                case cardIDEnum.EX1_250: return new Pen_EX1_250();
                case cardIDEnum.EX1_251: return new Pen_EX1_251();
                case cardIDEnum.EX1_258: return new Pen_EX1_258();
                case cardIDEnum.EX1_259: return new Pen_EX1_259();
                case cardIDEnum.EX1_274: return new Pen_EX1_274();
                case cardIDEnum.EX1_275: return new Pen_EX1_275();
                case cardIDEnum.EX1_277: return new Pen_EX1_277();
                case cardIDEnum.EX1_278: return new Pen_EX1_278();
                case cardIDEnum.EX1_279: return new Pen_EX1_279();
                case cardIDEnum.EX1_283: return new Pen_EX1_283();
                case cardIDEnum.EX1_284: return new Pen_EX1_284();
                case cardIDEnum.EX1_287: return new Pen_EX1_287();
                case cardIDEnum.EX1_289: return new Pen_EX1_289();
                case cardIDEnum.EX1_294: return new Pen_EX1_294();
                case cardIDEnum.EX1_295: return new Pen_EX1_295();
                case cardIDEnum.EX1_298: return new Pen_EX1_298();
                case cardIDEnum.EX1_301: return new Pen_EX1_301();
                case cardIDEnum.EX1_302: return new Pen_EX1_302();
                case cardIDEnum.EX1_303: return new Pen_EX1_303();
                case cardIDEnum.EX1_304: return new Pen_EX1_304();
                case cardIDEnum.EX1_306: return new Pen_EX1_306();
                case cardIDEnum.EX1_308: return new Pen_EX1_308();
                case cardIDEnum.EX1_309: return new Pen_EX1_309();
                case cardIDEnum.EX1_310: return new Pen_EX1_310();
                case cardIDEnum.EX1_312: return new Pen_EX1_312();
                case cardIDEnum.EX1_313: return new Pen_EX1_313();
                case cardIDEnum.EX1_315: return new Pen_EX1_315();
                case cardIDEnum.EX1_316: return new Pen_EX1_316();
                case cardIDEnum.EX1_317: return new Pen_EX1_317();
                case cardIDEnum.EX1_317t: return new Pen_EX1_317t();
                case cardIDEnum.EX1_319: return new Pen_EX1_319();
                case cardIDEnum.EX1_320: return new Pen_EX1_320();
                case cardIDEnum.EX1_323: return new Pen_EX1_323();
                case cardIDEnum.EX1_323h: return new Pen_EX1_323h();
                case cardIDEnum.EX1_323w: return new Pen_EX1_323w();
                case cardIDEnum.EX1_332: return new Pen_EX1_332();
                case cardIDEnum.EX1_334: return new Pen_EX1_334();
                case cardIDEnum.EX1_335: return new Pen_EX1_335();
                case cardIDEnum.EX1_339: return new Pen_EX1_339();
                case cardIDEnum.EX1_341: return new Pen_EX1_341();
                case cardIDEnum.EX1_345: return new Pen_EX1_345();
                case cardIDEnum.EX1_345t: return new Pen_EX1_345t();
                case cardIDEnum.EX1_349: return new Pen_EX1_349();
                case cardIDEnum.EX1_350: return new Pen_EX1_350();
                case cardIDEnum.EX1_354: return new Pen_EX1_354();
                case cardIDEnum.EX1_355: return new Pen_EX1_355();
                case cardIDEnum.EX1_360: return new Pen_EX1_360();
                case cardIDEnum.EX1_362: return new Pen_EX1_362();
                case cardIDEnum.EX1_363: return new Pen_EX1_363();
                case cardIDEnum.EX1_365: return new Pen_EX1_365();
                case cardIDEnum.EX1_366: return new Pen_EX1_366();
                case cardIDEnum.EX1_371: return new Pen_EX1_371();
                case cardIDEnum.EX1_379: return new Pen_EX1_379();
                case cardIDEnum.EX1_382: return new Pen_EX1_382();
                case cardIDEnum.EX1_383: return new Pen_EX1_383();
                case cardIDEnum.EX1_383t: return new Pen_EX1_383t();
                case cardIDEnum.EX1_384: return new Pen_EX1_384();
                case cardIDEnum.EX1_390: return new Pen_EX1_390();
                case cardIDEnum.EX1_391: return new Pen_EX1_391();
                case cardIDEnum.EX1_392: return new Pen_EX1_392();
                case cardIDEnum.EX1_393: return new Pen_EX1_393();
                case cardIDEnum.EX1_396: return new Pen_EX1_396();
                case cardIDEnum.EX1_398: return new Pen_EX1_398();
                case cardIDEnum.EX1_398t: return new Pen_EX1_398t();
                case cardIDEnum.EX1_399: return new Pen_EX1_399();
                case cardIDEnum.EX1_400: return new Pen_EX1_400();
                case cardIDEnum.EX1_402: return new Pen_EX1_402();
                case cardIDEnum.EX1_405: return new Pen_EX1_405();
                case cardIDEnum.EX1_407: return new Pen_EX1_407();
                case cardIDEnum.EX1_408: return new Pen_EX1_408();
                case cardIDEnum.EX1_409: return new Pen_EX1_409();
                case cardIDEnum.EX1_409t: return new Pen_EX1_409t();
                case cardIDEnum.EX1_410: return new Pen_EX1_410();
                case cardIDEnum.EX1_411: return new Pen_EX1_411();
                case cardIDEnum.EX1_412: return new Pen_EX1_412();
                case cardIDEnum.EX1_414: return new Pen_EX1_414();
                case cardIDEnum.EX1_506: return new Pen_EX1_506();
                case cardIDEnum.EX1_506a: return new Pen_EX1_506a();
                case cardIDEnum.EX1_507: return new Pen_EX1_507();
                case cardIDEnum.EX1_508: return new Pen_EX1_508();
                case cardIDEnum.EX1_509: return new Pen_EX1_509();
                case cardIDEnum.EX1_522: return new Pen_EX1_522();
                case cardIDEnum.EX1_531: return new Pen_EX1_531();
                case cardIDEnum.EX1_533: return new Pen_EX1_533();
                case cardIDEnum.EX1_534: return new Pen_EX1_534();
                case cardIDEnum.EX1_534t: return new Pen_EX1_534t();
                case cardIDEnum.EX1_536: return new Pen_EX1_536();
                case cardIDEnum.EX1_537: return new Pen_EX1_537();
                case cardIDEnum.EX1_538: return new Pen_EX1_538();
                case cardIDEnum.EX1_538t: return new Pen_EX1_538t();
                case cardIDEnum.EX1_539: return new Pen_EX1_539();
                case cardIDEnum.EX1_543: return new Pen_EX1_543();
                case cardIDEnum.EX1_544: return new Pen_EX1_544();
                case cardIDEnum.EX1_549: return new Pen_EX1_549();
                case cardIDEnum.EX1_554: return new Pen_EX1_554();
                case cardIDEnum.EX1_554t: return new Pen_EX1_554t();
                case cardIDEnum.EX1_556: return new Pen_EX1_556();
                case cardIDEnum.EX1_557: return new Pen_EX1_557();
                case cardIDEnum.EX1_558: return new Pen_EX1_558();
                case cardIDEnum.EX1_559: return new Pen_EX1_559();
                case cardIDEnum.EX1_560: return new Pen_EX1_560();
                case cardIDEnum.EX1_561: return new Pen_EX1_561();
                case cardIDEnum.EX1_562: return new Pen_EX1_562();
                case cardIDEnum.EX1_563: return new Pen_EX1_563();
                case cardIDEnum.EX1_564: return new Pen_EX1_564();
                case cardIDEnum.EX1_565: return new Pen_EX1_565();
                case cardIDEnum.EX1_567: return new Pen_EX1_567();
                case cardIDEnum.EX1_570: return new Pen_EX1_570();
                case cardIDEnum.EX1_571: return new Pen_EX1_571();
                case cardIDEnum.EX1_572: return new Pen_EX1_572();
                case cardIDEnum.EX1_573: return new Pen_EX1_573();
                case cardIDEnum.EX1_573a: return new Pen_EX1_573a();
                case cardIDEnum.EX1_573b: return new Pen_EX1_573b();
                case cardIDEnum.EX1_573t: return new Pen_EX1_573t();
                case cardIDEnum.EX1_575: return new Pen_EX1_575();
                case cardIDEnum.EX1_577: return new Pen_EX1_577();
                case cardIDEnum.EX1_578: return new Pen_EX1_578();
                case cardIDEnum.EX1_581: return new Pen_EX1_581();
                case cardIDEnum.EX1_582: return new Pen_EX1_582();
                case cardIDEnum.EX1_583: return new Pen_EX1_583();
                case cardIDEnum.EX1_584: return new Pen_EX1_584();
                case cardIDEnum.EX1_586: return new Pen_EX1_586();
                case cardIDEnum.EX1_587: return new Pen_EX1_587();
                case cardIDEnum.EX1_590: return new Pen_EX1_590();
                case cardIDEnum.EX1_591: return new Pen_EX1_591();
                case cardIDEnum.EX1_593: return new Pen_EX1_593();
                case cardIDEnum.EX1_594: return new Pen_EX1_594();
                case cardIDEnum.EX1_595: return new Pen_EX1_595();
                case cardIDEnum.EX1_596: return new Pen_EX1_596();
                case cardIDEnum.EX1_597: return new Pen_EX1_597();
                case cardIDEnum.EX1_598: return new Pen_EX1_598();
                case cardIDEnum.EX1_603: return new Pen_EX1_603();
                case cardIDEnum.EX1_604: return new Pen_EX1_604();
                case cardIDEnum.EX1_606: return new Pen_EX1_606();
                case cardIDEnum.EX1_607: return new Pen_EX1_607();
                case cardIDEnum.EX1_608: return new Pen_EX1_608();
                case cardIDEnum.EX1_609: return new Pen_EX1_609();
                case cardIDEnum.EX1_610: return new Pen_EX1_610();
                case cardIDEnum.EX1_611: return new Pen_EX1_611();
                case cardIDEnum.EX1_612: return new Pen_EX1_612();
                case cardIDEnum.EX1_613: return new Pen_EX1_613();
                case cardIDEnum.EX1_614: return new Pen_EX1_614();
                case cardIDEnum.EX1_614t: return new Pen_EX1_614t();
                case cardIDEnum.EX1_616: return new Pen_EX1_616();
                case cardIDEnum.EX1_617: return new Pen_EX1_617();
                case cardIDEnum.EX1_619: return new Pen_EX1_619();
                case cardIDEnum.EX1_620: return new Pen_EX1_620();
                case cardIDEnum.EX1_621: return new Pen_EX1_621();
                case cardIDEnum.EX1_622: return new Pen_EX1_622();
                case cardIDEnum.EX1_623: return new Pen_EX1_623();
                case cardIDEnum.EX1_624: return new Pen_EX1_624();
                case cardIDEnum.EX1_625: return new Pen_EX1_625();
                case cardIDEnum.EX1_625t2: return new Pen_EX1_625t2();
                case cardIDEnum.EX1_625t: return new Pen_EX1_625t();
                case cardIDEnum.EX1_626: return new Pen_EX1_626();
                case cardIDEnum.EX1_finkle: return new Pen_EX1_finkle();
                case cardIDEnum.EX1_tk11: return new Pen_EX1_tk11();
                case cardIDEnum.EX1_tk28: return new Pen_EX1_tk28();
                case cardIDEnum.EX1_tk29: return new Pen_EX1_tk29();
                case cardIDEnum.EX1_tk33: return new Pen_EX1_tk33();
                case cardIDEnum.EX1_tk34: return new Pen_EX1_tk34();
                case cardIDEnum.EX1_tk9: return new Pen_EX1_tk9();
                
                case cardIDEnum.FP1_001: return new Pen_FP1_001();
                case cardIDEnum.FP1_002: return new Pen_FP1_002();
                case cardIDEnum.FP1_002t: return new Pen_FP1_002t();
                case cardIDEnum.FP1_003: return new Pen_FP1_003();
                case cardIDEnum.FP1_004: return new Pen_FP1_004();
                case cardIDEnum.FP1_005: return new Pen_FP1_005();
                case cardIDEnum.FP1_006: return new Pen_FP1_006();
                case cardIDEnum.FP1_007: return new Pen_FP1_007();
                case cardIDEnum.FP1_007t: return new Pen_FP1_007t();
                case cardIDEnum.FP1_008: return new Pen_FP1_008();
                case cardIDEnum.FP1_009: return new Pen_FP1_009();
                case cardIDEnum.FP1_010: return new Pen_FP1_010();
                case cardIDEnum.FP1_011: return new Pen_FP1_011();
                case cardIDEnum.FP1_012: return new Pen_FP1_012();
                case cardIDEnum.FP1_012t: return new Pen_FP1_012t();
                case cardIDEnum.FP1_013: return new Pen_FP1_013();
                case cardIDEnum.FP1_014: return new Pen_FP1_014();
                case cardIDEnum.FP1_014t: return new Pen_FP1_014t();
                case cardIDEnum.FP1_015: return new Pen_FP1_015();
                case cardIDEnum.FP1_016: return new Pen_FP1_016();
                case cardIDEnum.FP1_017: return new Pen_FP1_017();
                case cardIDEnum.FP1_018: return new Pen_FP1_018();
                case cardIDEnum.FP1_019: return new Pen_FP1_019();
                case cardIDEnum.FP1_019t: return new Pen_FP1_019t();
                case cardIDEnum.FP1_020: return new Pen_FP1_020();
                case cardIDEnum.FP1_021: return new Pen_FP1_021();
                case cardIDEnum.FP1_022: return new Pen_FP1_022();
                case cardIDEnum.FP1_023: return new Pen_FP1_023();
                case cardIDEnum.FP1_024: return new Pen_FP1_024();
                case cardIDEnum.FP1_025: return new Pen_FP1_025();
                case cardIDEnum.FP1_026: return new Pen_FP1_026();
                case cardIDEnum.FP1_027: return new Pen_FP1_027();
                case cardIDEnum.FP1_028: return new Pen_FP1_028();
                case cardIDEnum.FP1_029: return new Pen_FP1_029();
                case cardIDEnum.FP1_030: return new Pen_FP1_030();
                case cardIDEnum.FP1_031: return new Pen_FP1_031();
                
                case cardIDEnum.GAME_002: return new Pen_GAME_002();
                case cardIDEnum.GAME_005: return new Pen_GAME_005();
                case cardIDEnum.GAME_006: return new Pen_GAME_006();
                
                case cardIDEnum.GVG_001: return new Pen_GVG_001();
                case cardIDEnum.GVG_002: return new Pen_GVG_002();
                case cardIDEnum.GVG_003: return new Pen_GVG_003();
                case cardIDEnum.GVG_004: return new Pen_GVG_004();
                case cardIDEnum.GVG_005: return new Pen_GVG_005();
                case cardIDEnum.GVG_006: return new Pen_GVG_006();
                case cardIDEnum.GVG_007: return new Pen_GVG_007();
                case cardIDEnum.GVG_008: return new Pen_GVG_008();
                case cardIDEnum.GVG_009: return new Pen_GVG_009();
                case cardIDEnum.GVG_010: return new Pen_GVG_010();
                case cardIDEnum.GVG_011: return new Pen_GVG_011();
                case cardIDEnum.GVG_012: return new Pen_GVG_012();
                case cardIDEnum.GVG_013: return new Pen_GVG_013();
                case cardIDEnum.GVG_014: return new Pen_GVG_014();
                case cardIDEnum.GVG_015: return new Pen_GVG_015();
                case cardIDEnum.GVG_016: return new Pen_GVG_016();
                case cardIDEnum.GVG_017: return new Pen_GVG_017();
                case cardIDEnum.GVG_018: return new Pen_GVG_018();
                case cardIDEnum.GVG_019: return new Pen_GVG_019();
                case cardIDEnum.GVG_020: return new Pen_GVG_020();
                case cardIDEnum.GVG_021: return new Pen_GVG_021();
                case cardIDEnum.GVG_022: return new Pen_GVG_022();
                case cardIDEnum.GVG_023: return new Pen_GVG_023();
                case cardIDEnum.GVG_024: return new Pen_GVG_024();
                case cardIDEnum.GVG_025: return new Pen_GVG_025();
                case cardIDEnum.GVG_026: return new Pen_GVG_026();
                case cardIDEnum.GVG_027: return new Pen_GVG_027();
                case cardIDEnum.GVG_028: return new Pen_GVG_028();
                case cardIDEnum.GVG_028t: return new Pen_GVG_028t();
                case cardIDEnum.GVG_029: return new Pen_GVG_029();
                case cardIDEnum.GVG_030: return new Pen_GVG_030();
                case cardIDEnum.GVG_030a: return new Pen_GVG_030a();
                case cardIDEnum.GVG_030b: return new Pen_GVG_030b();
                case cardIDEnum.GVG_031: return new Pen_GVG_031();
                case cardIDEnum.GVG_032: return new Pen_GVG_032();
                case cardIDEnum.GVG_032a: return new Pen_GVG_032a();
                case cardIDEnum.GVG_032b: return new Pen_GVG_032b();
                case cardIDEnum.GVG_033: return new Pen_GVG_033();
                case cardIDEnum.GVG_034: return new Pen_GVG_034();
                case cardIDEnum.GVG_035: return new Pen_GVG_035();
                case cardIDEnum.GVG_036: return new Pen_GVG_036();
                case cardIDEnum.GVG_037: return new Pen_GVG_037();
                case cardIDEnum.GVG_038: return new Pen_GVG_038();
                case cardIDEnum.GVG_039: return new Pen_GVG_039();
                case cardIDEnum.GVG_040: return new Pen_GVG_040();
                case cardIDEnum.GVG_041: return new Pen_GVG_041();
                case cardIDEnum.GVG_041a: return new Pen_GVG_041a();
                case cardIDEnum.GVG_041b: return new Pen_GVG_041b();
                case cardIDEnum.GVG_042: return new Pen_GVG_042();
                case cardIDEnum.GVG_043: return new Pen_GVG_043();
                case cardIDEnum.GVG_044: return new Pen_GVG_044();
                case cardIDEnum.GVG_045: return new Pen_GVG_045();
                case cardIDEnum.GVG_045t: return new Pen_GVG_045t();
                case cardIDEnum.GVG_046: return new Pen_GVG_046();
                case cardIDEnum.GVG_047: return new Pen_GVG_047();
                case cardIDEnum.GVG_048: return new Pen_GVG_048();
                case cardIDEnum.GVG_049: return new Pen_GVG_049();
                case cardIDEnum.GVG_050: return new Pen_GVG_050();
                case cardIDEnum.GVG_051: return new Pen_GVG_051();
                case cardIDEnum.GVG_052: return new Pen_GVG_052();
                case cardIDEnum.GVG_053: return new Pen_GVG_053();
                case cardIDEnum.GVG_054: return new Pen_GVG_054();
                case cardIDEnum.GVG_055: return new Pen_GVG_055();
                case cardIDEnum.GVG_056: return new Pen_GVG_056();
                case cardIDEnum.GVG_056t: return new Pen_GVG_056t();
                case cardIDEnum.GVG_057: return new Pen_GVG_057();
                case cardIDEnum.GVG_058: return new Pen_GVG_058();
                case cardIDEnum.GVG_059: return new Pen_GVG_059();
                case cardIDEnum.GVG_060: return new Pen_GVG_060();
                case cardIDEnum.GVG_061: return new Pen_GVG_061();
                case cardIDEnum.GVG_062: return new Pen_GVG_062();
                case cardIDEnum.GVG_063: return new Pen_GVG_063();
                case cardIDEnum.GVG_064: return new Pen_GVG_064();
                case cardIDEnum.GVG_065: return new Pen_GVG_065();
                case cardIDEnum.GVG_066: return new Pen_GVG_066();
                case cardIDEnum.GVG_067: return new Pen_GVG_067();
                case cardIDEnum.GVG_068: return new Pen_GVG_068();
                case cardIDEnum.GVG_069: return new Pen_GVG_069();
                case cardIDEnum.GVG_070: return new Pen_GVG_070();
                case cardIDEnum.GVG_071: return new Pen_GVG_071();
                case cardIDEnum.GVG_072: return new Pen_GVG_072();
                case cardIDEnum.GVG_073: return new Pen_GVG_073();
                case cardIDEnum.GVG_074: return new Pen_GVG_074();
                case cardIDEnum.GVG_075: return new Pen_GVG_075();
                case cardIDEnum.GVG_076: return new Pen_GVG_076();
                case cardIDEnum.GVG_077: return new Pen_GVG_077();
                case cardIDEnum.GVG_078: return new Pen_GVG_078();
                case cardIDEnum.GVG_079: return new Pen_GVG_079();
                case cardIDEnum.GVG_080: return new Pen_GVG_080();
                case cardIDEnum.GVG_080t: return new Pen_GVG_080t();
                case cardIDEnum.GVG_081: return new Pen_GVG_081();
                case cardIDEnum.GVG_082: return new Pen_GVG_082();
                case cardIDEnum.GVG_083: return new Pen_GVG_083();
                case cardIDEnum.GVG_084: return new Pen_GVG_084();
                case cardIDEnum.GVG_085: return new Pen_GVG_085();
                case cardIDEnum.GVG_086: return new Pen_GVG_086();
                case cardIDEnum.GVG_087: return new Pen_GVG_087();
                case cardIDEnum.GVG_088: return new Pen_GVG_088();
                case cardIDEnum.GVG_089: return new Pen_GVG_089();
                case cardIDEnum.GVG_090: return new Pen_GVG_090();
                case cardIDEnum.GVG_091: return new Pen_GVG_091();
                case cardIDEnum.GVG_092: return new Pen_GVG_092();
                case cardIDEnum.GVG_092t: return new Pen_GVG_092t();
                case cardIDEnum.GVG_093: return new Pen_GVG_093();
                case cardIDEnum.GVG_094: return new Pen_GVG_094();
                case cardIDEnum.GVG_095: return new Pen_GVG_095();
                case cardIDEnum.GVG_096: return new Pen_GVG_096();
                case cardIDEnum.GVG_097: return new Pen_GVG_097();
                case cardIDEnum.GVG_098: return new Pen_GVG_098();
                case cardIDEnum.GVG_099: return new Pen_GVG_099();
                case cardIDEnum.GVG_100: return new Pen_GVG_100();
                case cardIDEnum.GVG_101: return new Pen_GVG_101();
                case cardIDEnum.GVG_102: return new Pen_GVG_102();
                case cardIDEnum.GVG_103: return new Pen_GVG_103();
                case cardIDEnum.GVG_104: return new Pen_GVG_104();
                case cardIDEnum.GVG_105: return new Pen_GVG_105();
                case cardIDEnum.GVG_106: return new Pen_GVG_106();
                case cardIDEnum.GVG_107: return new Pen_GVG_107();
                case cardIDEnum.GVG_108: return new Pen_GVG_108();
                case cardIDEnum.GVG_109: return new Pen_GVG_109();
                case cardIDEnum.GVG_110: return new Pen_GVG_110();
                case cardIDEnum.GVG_110t: return new Pen_GVG_110t();
                case cardIDEnum.GVG_111: return new Pen_GVG_111();
                case cardIDEnum.GVG_111t: return new Pen_GVG_111t();
                case cardIDEnum.GVG_112: return new Pen_GVG_112();
                case cardIDEnum.GVG_113: return new Pen_GVG_113();
                case cardIDEnum.GVG_114: return new Pen_GVG_114();
                case cardIDEnum.GVG_115: return new Pen_GVG_115();
                case cardIDEnum.GVG_116: return new Pen_GVG_116();
                case cardIDEnum.GVG_117: return new Pen_GVG_117();
                case cardIDEnum.GVG_118: return new Pen_GVG_118();
                case cardIDEnum.GVG_119: return new Pen_GVG_119();
                case cardIDEnum.GVG_120: return new Pen_GVG_120();
                case cardIDEnum.GVG_121: return new Pen_GVG_121();
                case cardIDEnum.GVG_122: return new Pen_GVG_122();
                case cardIDEnum.GVG_123: return new Pen_GVG_123();
                
                case cardIDEnum.HERO_01: return new Pen_HERO_01();
                case cardIDEnum.HERO_01a: return new Pen_HERO_01();
                case cardIDEnum.HERO_01b: return new Pen_HERO_01();
                case cardIDEnum.HERO_02: return new Pen_HERO_02();
                case cardIDEnum.HERO_02a: return new Pen_HERO_02();
                case cardIDEnum.HERO_02b: return new Pen_HERO_02();
                case cardIDEnum.HERO_03: return new Pen_HERO_03();
                case cardIDEnum.HERO_03a: return new Pen_HERO_03();
                case cardIDEnum.HERO_04: return new Pen_HERO_04();
                case cardIDEnum.HERO_04a: return new Pen_HERO_04();
                case cardIDEnum.HERO_04b: return new Pen_HERO_04();
                case cardIDEnum.HERO_05: return new Pen_HERO_05();
                case cardIDEnum.HERO_05a: return new Pen_HERO_05();
                case cardIDEnum.HERO_05b: return new Pen_HERO_05();
                case cardIDEnum.HERO_06: return new Pen_HERO_06();
                case cardIDEnum.HERO_06a: return new Pen_HERO_06();
                case cardIDEnum.HERO_07: return new Pen_HERO_07();
                case cardIDEnum.HERO_07a: return new Pen_HERO_07();
                case cardIDEnum.HERO_08: return new Pen_HERO_08();
                case cardIDEnum.HERO_08a: return new Pen_HERO_08();
                case cardIDEnum.HERO_08b: return new Pen_HERO_08();
                case cardIDEnum.HERO_08c: return new Pen_HERO_08();
                case cardIDEnum.HERO_09: return new Pen_HERO_09();
                case cardIDEnum.HERO_09a: return new Pen_HERO_09();
                case cardIDEnum.HERO_09b: return new Pen_HERO_09();

                case cardIDEnum.LOE_002: return new Pen_LOE_002();
                case cardIDEnum.LOE_002t: return new Pen_LOE_002t();
                case cardIDEnum.LOE_003: return new Pen_LOE_003();
                case cardIDEnum.LOE_006: return new Pen_LOE_006();
                case cardIDEnum.LOE_007: return new Pen_LOE_007();
                case cardIDEnum.LOE_007t: return new Pen_LOE_007t();
                case cardIDEnum.LOE_009: return new Pen_LOE_009();
                case cardIDEnum.LOE_009t: return new Pen_LOE_009t();
                case cardIDEnum.LOE_010: return new Pen_LOE_010();
                case cardIDEnum.LOE_011: return new Pen_LOE_011();
                case cardIDEnum.LOE_012: return new Pen_LOE_012();
                case cardIDEnum.LOE_016: return new Pen_LOE_016();
                case cardIDEnum.LOE_017: return new Pen_LOE_017();
                case cardIDEnum.LOE_018: return new Pen_LOE_018();
                case cardIDEnum.LOE_019: return new Pen_LOE_019();
                case cardIDEnum.LOE_019t2: return new Pen_LOE_019t2();
                case cardIDEnum.LOE_019t: return new Pen_LOE_019t();
                case cardIDEnum.LOE_020: return new Pen_LOE_020();
                case cardIDEnum.LOE_021: return new Pen_LOE_021();
                case cardIDEnum.LOE_022: return new Pen_LOE_022();
                case cardIDEnum.LOE_023: return new Pen_LOE_023();
                case cardIDEnum.LOE_026: return new Pen_LOE_026();
                case cardIDEnum.LOE_027: return new Pen_LOE_027();
                case cardIDEnum.LOE_029: return new Pen_LOE_029();
                case cardIDEnum.LOE_038: return new Pen_LOE_038();
                case cardIDEnum.LOE_039: return new Pen_LOE_039();
                case cardIDEnum.LOE_046: return new Pen_LOE_046();
                case cardIDEnum.LOE_047: return new Pen_LOE_047();
                case cardIDEnum.LOE_050: return new Pen_LOE_050();
                case cardIDEnum.LOE_051: return new Pen_LOE_051();
                case cardIDEnum.LOE_053: return new Pen_LOE_053();
                case cardIDEnum.LOE_061: return new Pen_LOE_061();
                case cardIDEnum.LOE_073: return new Pen_LOE_073();
                case cardIDEnum.LOE_076: return new Pen_LOE_076();
                case cardIDEnum.LOE_077: return new Pen_LOE_077();
                case cardIDEnum.LOE_079: return new Pen_LOE_079();
                case cardIDEnum.LOE_086: return new Pen_LOE_086();
                case cardIDEnum.LOE_089: return new Pen_LOE_089();
                case cardIDEnum.LOE_089t2: return new Pen_LOE_089t2();
                case cardIDEnum.LOE_089t3: return new Pen_LOE_089t3();
                case cardIDEnum.LOE_089t: return new Pen_LOE_089t();
                case cardIDEnum.LOE_092: return new Pen_LOE_092();
                case cardIDEnum.LOE_104: return new Pen_LOE_104();
                case cardIDEnum.LOE_105: return new Pen_LOE_105();
                case cardIDEnum.LOE_107: return new Pen_LOE_107();
                case cardIDEnum.LOE_110: return new Pen_LOE_110();
                case cardIDEnum.LOE_110t: return new Pen_LOE_110t();
                case cardIDEnum.LOE_111: return new Pen_LOE_111();
                case cardIDEnum.LOE_113: return new Pen_LOE_113();
                case cardIDEnum.LOE_115: return new Pen_LOE_115();
                case cardIDEnum.LOE_115a: return new Pen_LOE_115a();
                case cardIDEnum.LOE_115b: return new Pen_LOE_115b();
                case cardIDEnum.LOE_116: return new Pen_LOE_116();
                case cardIDEnum.LOE_118: return new Pen_LOE_118();
                case cardIDEnum.LOE_119: return new Pen_LOE_119();
                
                case cardIDEnum.Mekka1: return new Pen_Mekka1();
                case cardIDEnum.Mekka2: return new Pen_Mekka2();
                case cardIDEnum.Mekka3: return new Pen_Mekka3();
                case cardIDEnum.Mekka4: return new Pen_Mekka4();
                case cardIDEnum.Mekka4t: return new Pen_Mekka4t();
                
                case cardIDEnum.NEW1_003: return new Pen_NEW1_003();
                case cardIDEnum.NEW1_004: return new Pen_NEW1_004();
                case cardIDEnum.NEW1_005: return new Pen_NEW1_005();
                case cardIDEnum.NEW1_007: return new Pen_NEW1_007();
                case cardIDEnum.NEW1_007a: return new Pen_NEW1_007a();
                case cardIDEnum.NEW1_007b: return new Pen_NEW1_007b();
                case cardIDEnum.NEW1_008: return new Pen_NEW1_008();
                case cardIDEnum.NEW1_008a: return new Pen_NEW1_008a();
                case cardIDEnum.NEW1_008b: return new Pen_NEW1_008b();
                case cardIDEnum.NEW1_009: return new Pen_NEW1_009();
                case cardIDEnum.NEW1_010: return new Pen_NEW1_010();
                case cardIDEnum.NEW1_011: return new Pen_NEW1_011();
                case cardIDEnum.NEW1_012: return new Pen_NEW1_012();
                case cardIDEnum.NEW1_014: return new Pen_NEW1_014();
                case cardIDEnum.NEW1_016: return new Pen_NEW1_016();
                case cardIDEnum.NEW1_017: return new Pen_NEW1_017();
                case cardIDEnum.NEW1_018: return new Pen_NEW1_018();
                case cardIDEnum.NEW1_019: return new Pen_NEW1_019();
                case cardIDEnum.NEW1_020: return new Pen_NEW1_020();
                case cardIDEnum.NEW1_021: return new Pen_NEW1_021();
                case cardIDEnum.NEW1_022: return new Pen_NEW1_022();
                case cardIDEnum.NEW1_023: return new Pen_NEW1_023();
                case cardIDEnum.NEW1_024: return new Pen_NEW1_024();
                case cardIDEnum.NEW1_025: return new Pen_NEW1_025();
                case cardIDEnum.NEW1_026: return new Pen_NEW1_026();
                case cardIDEnum.NEW1_026t: return new Pen_NEW1_026t();
                case cardIDEnum.NEW1_027: return new Pen_NEW1_027();
                case cardIDEnum.NEW1_029: return new Pen_NEW1_029();
                case cardIDEnum.NEW1_030: return new Pen_NEW1_030();
                case cardIDEnum.NEW1_031: return new Pen_NEW1_031();
                case cardIDEnum.NEW1_032: return new Pen_NEW1_032();
                case cardIDEnum.NEW1_033: return new Pen_NEW1_033();
                case cardIDEnum.NEW1_034: return new Pen_NEW1_034();
                case cardIDEnum.NEW1_036: return new Pen_NEW1_036();
                case cardIDEnum.NEW1_037: return new Pen_NEW1_037();
                case cardIDEnum.NEW1_038: return new Pen_NEW1_038();
                case cardIDEnum.NEW1_040: return new Pen_NEW1_040();
                case cardIDEnum.NEW1_040t: return new Pen_NEW1_040t();
                case cardIDEnum.NEW1_041: return new Pen_NEW1_041();
                
                case cardIDEnum.OG_027: return new Pen_OG_027();
                case cardIDEnum.OG_051: return new Pen_OG_051();
                case cardIDEnum.OG_086: return new Pen_OG_086();
                case cardIDEnum.OG_101: return new Pen_OG_101();
                case cardIDEnum.OG_114: return new Pen_OG_114();
                case cardIDEnum.OG_198: return new Pen_OG_198();
                case cardIDEnum.OG_202: return new Pen_OG_202();
                
                case cardIDEnum.PART_001: return new Pen_PART_001();
                case cardIDEnum.PART_002: return new Pen_PART_002();
                case cardIDEnum.PART_003: return new Pen_PART_003();
                case cardIDEnum.PART_004: return new Pen_PART_004();
                case cardIDEnum.PART_005: return new Pen_PART_005();
                case cardIDEnum.PART_006: return new Pen_PART_006();
                case cardIDEnum.PART_007: return new Pen_PART_007();
                
                case cardIDEnum.PRO_001: return new Pen_PRO_001();
                case cardIDEnum.PRO_001a: return new Pen_PRO_001a();
                case cardIDEnum.PRO_001at: return new Pen_PRO_001at();
                case cardIDEnum.PRO_001b: return new Pen_PRO_001b();
                case cardIDEnum.PRO_001c: return new Pen_PRO_001c();
                
                case cardIDEnum.PlaceholderCard: return new Pen_PlaceholderCard();
                case cardIDEnum.ds1_whelptoken: return new Pen_ds1_whelptoken();
                case cardIDEnum.hexfrog: return new Pen_hexfrog();
                case cardIDEnum.skele11: return new Pen_skele11();
                case cardIDEnum.skele21: return new Pen_skele21();
                case cardIDEnum.tt_004: return new Pen_tt_004();
                case cardIDEnum.tt_010: return new Pen_tt_010();
                case cardIDEnum.tt_010a: return new Pen_tt_010a();
            }

            return new PenTemplate();
        }

        //call this if carddb.txt was changed to generate new stuff
        private void enumCreator()
        {
            // cardIDEnum creator:
            Helpfunctions.Instance.writeToBuffer("public enum cardIDEnum");
            Helpfunctions.Instance.writeToBuffer("{");
            Helpfunctions.Instance.writeToBuffer("None,");
            foreach (string cardid in this.allCardIDS)
            {
                Helpfunctions.Instance.writeToBuffer(cardid + ",");
            }
            Helpfunctions.Instance.writeToBuffer("}");

            
            // cardName creator:
            List<string> namelist = new List<string>();
            foreach (string cardid in this.namelist)
            {
                if (namelist.Contains(cardid)) continue;
                namelist.Add(cardid);
            }
            
            Helpfunctions.Instance.writeToBuffer("public enum cardName");
            Helpfunctions.Instance.writeToBuffer("{");
            foreach (string cardid in namelist)
            {
                Helpfunctions.Instance.writeToBuffer(cardid + ",");
            }
            Helpfunctions.Instance.writeToBuffer("}");

            
            // getSimCard creator:
            Helpfunctions.Instance.writeToBuffer("public SimTemplate getSimCard(cardIDEnum id)");
            Helpfunctions.Instance.writeToBuffer("{");
            Helpfunctions.Instance.writeToBuffer("switch (id)");
            Helpfunctions.Instance.writeToBuffer("{");
            foreach (string cardid in this.allCardIDS)
            {
                Helpfunctions.Instance.writeToBuffer("case cardIDEnum." + cardid + ": return new Sim_" + cardid + "();");
            }
            Helpfunctions.Instance.writeToBuffer("return new SimTemplate();");
            Helpfunctions.Instance.writeToBuffer("}");
            Helpfunctions.Instance.writeToBuffer("}");


            Helpfunctions.Instance.writeBufferToCardDB();
        }

        private static string removeSpecialChars(string s)
        {
            return Regex.Replace(s, "[^a-zA-Z0-9]+", "", RegexOptions.Compiled);
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