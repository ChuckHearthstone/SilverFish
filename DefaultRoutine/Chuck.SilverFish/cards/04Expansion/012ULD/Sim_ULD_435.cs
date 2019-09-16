using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Naga Sand Witch
    /// 纳迦沙漠女巫 
    /// </summary>
    public class Sim_ULD_435 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Change the Cost of spells in your hand to (5).
        /// 战吼：使你手牌中的法术牌法力值消耗变为（5）点。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.type == CardType.SPELL)
                    {
                        hc.manacost = 5;
                    }
                }
            }
        }
    }
}