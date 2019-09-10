using Chuck.SilverFish;
using SilverFish.Enums;
using System.Collections.Generic;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Micro Mummy 
    /// 微型木乃伊
    /// </summary>
    public class Sim_ULD_217 : SimTemplate
    {
        /// <summary>
        /// Reborn At the end of your turn, give another random friendly minion +1 Attack.
        /// 复生在你的回合结束时，随机使另一个友方随从获得+1攻击力。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="triggerEffectMinion"></param>
        /// <param name="turnEndOfOwner"></param>
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                List<Minion> tmp = turnEndOfOwner ? p.ownMinions : p.enemyMinions;
                int count = tmp.Count;
                if (count > 1)
                {
                    Minion mnn = null;
                    if (triggerEffectMinion.entitiyID != tmp[0].entitiyID) mnn = tmp[0];
                    else mnn = tmp[1];

                    for (int i = 1; i < count; i++)
                    {
                        if (triggerEffectMinion.entitiyID == tmp[i].entitiyID) continue;
                        if (tmp[i].HealthPoints < mnn.HealthPoints) mnn = tmp[i]; //take the weakest
                    }
                    if (mnn != null) p.minionGetBuffed(mnn, 1, 0);
                }
            }
        }
    }
}
