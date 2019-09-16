using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// King Phaoris
    /// 法奥瑞斯国王 
    /// </summary>
    public class Sim_ULD_304 : SimTemplate
    {
        /// <summary>
        /// Battlecry: For each spell in your hand, summon a random minion of the same Cost.
        /// 战吼：你手牌中每有一张法术牌，便召唤一个法力值消耗与法术牌相同的随机随从。
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
                        p.CallKid(p.getRandomCardForManaMinion(hc.manacost), p.ownMinions.Count, own.own);
                    }
                    if (p.ownMinions.Count == 7) break;
                }
            }
        }
    }
}