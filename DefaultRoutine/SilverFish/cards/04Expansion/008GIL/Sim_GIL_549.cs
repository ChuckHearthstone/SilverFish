using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Toki, Time-Tinker
    /// 时光修补匠托奇
    /// </summary>
    public class Sim_GIL_549 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Add a random Legendary minion from the past to your hand.
        /// 战吼：随机将一张狂野传说随从牌置入你的手牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardName.unknown, own.own);
        }
    }
}
