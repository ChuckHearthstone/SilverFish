using System;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Elise the Enlightened
    /// 启迪者伊莉斯
    /// </summary>
    public class Sim_ULD_139 : SimTemplate
    {
        /// <summary>
        /// Battlecry: If your deck has no duplicates, duplicate your hand.
        /// 战吼：如果你的牌库里没有相同的牌，则复制你的手牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own && p.prozis.noDuplicates)
            {
                int ownCardsNum = p.owncards.Count;

                for (int i = 0; i < Math.Min(ownCardsNum, 10 - ownCardsNum); i++)
                {
                    p.drawACard(p.owncards[i].card.name, own.own, true);
                }
            }
        }
    }
}