using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Anka, the Buried
    /// 被埋葬的安卡 
    /// </summary>
    public class Sim_ULD_288 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Change each Deathrattle minion in your hand into a 1/1 that costs (1).
        /// 战吼：使你手牌中所有具有亡语的随从牌变为1/1，且法力值消耗为（1）点。
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
                    if (hc.card.type == CardType.Minion && hc.card.deathrattle)
                    {
                        hc.manacost = 1;
                        hc.addattack = 1 - hc.card.Attack;
                        hc.addHp = 1 - hc.card.Health;
                    }
                }
            }
        }
    }
}