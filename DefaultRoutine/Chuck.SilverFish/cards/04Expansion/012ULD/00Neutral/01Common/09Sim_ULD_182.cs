using System.Collections.Generic;

namespace Chuck.SilverFish.cards._04Expansion._012ULD._00Neutral._01Common
{
    /// <summary>
    /// Spitting Camel
    /// 乱喷的骆驼
    /// </summary>
    public class Sim_ULD_182 : SimTemplate
    {
        /// <summary>
        /// At the end of your turn, deal 1 damage to another random friendly minion.
        /// 在你的回合结束时，随机对另一个友方随从造成1点伤害。
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
                    Minion target = null;
                    if (triggerEffectMinion.entitiyID != tmp[0].entitiyID) target = tmp[0];
                    else target = tmp[1];
                    for (int i = 1; i < count; i++)
                    {
                        if (triggerEffectMinion.entitiyID == tmp[i].entitiyID) continue;
                        if (tmp[i].HealthPoints < target.HealthPoints) target = tmp[i]; //take the weakest
                    }
                    if (target != null) p.minionGetDamageOrHeal(target, 1);
                }
            }
        }
    }
}