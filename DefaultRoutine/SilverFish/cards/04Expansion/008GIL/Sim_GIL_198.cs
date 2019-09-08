using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Azalina Soulthief
    /// 窃魂者阿扎莉娜
    /// </summary>
    public class Sim_GIL_198 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Replace your hand with a copy of your opponent's.
        /// 战吼：将你的手牌替换成对手手牌的 复制。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.discardCards(10, own.own);
            for (int i = 0; i < p.enemyAnzCards; i++)
            {
                p.drawACard(CardName.unknown, own.own, true);
            }
        }
    }
}
