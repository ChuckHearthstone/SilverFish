using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._010TRL
{
    /// <summary>
    /// Banana Buffoon
    /// 香蕉小丑
    /// </summary>
    public class Sim_TRL_509 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Add 2 Bananas to your hand.
        /// 战吼：将两个香蕉置入你的手牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int count = 2;
            for (int i = 1; i <= count; i++)
            {
                p.drawACard(CardName.bananas, own.own, true);
                //the card draw counter will plus one in drawACard method
                //but the card is not drawn from deck, so we subtract it back
                if (own.own)
                {
                    p.owncarddraw--;
                }
                else
                {
                    p.enemycarddraw--;
                }
            }
        }
    }
}
