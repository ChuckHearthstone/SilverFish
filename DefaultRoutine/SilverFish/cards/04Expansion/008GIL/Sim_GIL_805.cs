using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Coffin Crasher
    /// 破棺者
    /// </summary>
    public class Sim_GIL_805 : SimTemplate
    {
        /// <summary>
        /// Deathrattle: Summon a Deathrattle minion from your hand.
        /// 亡语：从你的手牌中召唤一个亡语随从。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.deathrattle)
                    {
                        p.CallKid(hc.card, p.owncards.Count, m.own);
                        p.removeCard(hc);
                        break;
                    }
                }
            }
            else p.CallKid(CardDB.Instance.getCardData(CardName.unknown), p.enemyMinions.Count, m.own);
        }
    }
}
