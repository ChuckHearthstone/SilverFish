using System.Collections.Generic;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Sahket Sapper
    /// 沙赫柯特工兵 
    /// </summary>
    public class Sim_ULD_280 : SimTemplate
    {
        /// <summary>
        /// Deathrattle: Return a random enemy minion to your opponent's hand.
        /// 亡语：随机将一个敌方随从移回对手的手牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            List<Minion> temp = (m.own) ? new List<Minion>(p.enemyMinions) : new List<Minion>(p.ownMinions);

            if (temp.Count > 0)
            {
                if (m.own) temp.Sort((a, b) => b.Attack.CompareTo(a.Attack));
                else temp.Sort((a, b) => a.Attack.CompareTo(b.Attack));
                Minion target = temp[0];
                if (m.own && temp.Count >= 2 && !target.taunt && temp[1].taunt) target = temp[1];
                p.minionReturnToHand(target, !m.own, 0);
            }
        }
    }
}