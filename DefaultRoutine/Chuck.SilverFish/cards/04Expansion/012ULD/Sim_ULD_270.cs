using System.Collections.Generic;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Sandhoof Waterbearer
    /// 沙蹄搬水工
    /// </summary>
    public class Sim_ULD_270 : SimTemplate
    {
        /// <summary>
        /// At the end of your turn, restore 5 Health to a damaged friendly character.
        /// 在你的回合结束时，为一个受伤的友方角色恢复5点生命值。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="triggerEffectMinion"></param>
        /// <param name="turnEndOfOwner"></param>
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                int heal = (turnEndOfOwner) ? p.getMinionHeal(5) : p.getEnemyMinionHeal(5);
                List<Minion> temp = (turnEndOfOwner) ? p.ownMinions : p.enemyMinions;
                if (temp.Count >= 1)
                {
                    bool healed = false;
                    foreach (Minion m in temp)
                    {
                        if (m.wounded)
                        {
                            p.minionGetDamageOrHeal(m, -heal);
                            healed = true;
                            break;
                        }
                    }
                    if (!healed)
                    {
                        p.minionGetDamageOrHeal(turnEndOfOwner ? p.ownHero : p.enemyHero, -heal);
                    }
                }
                else
                {
                    p.minionGetDamageOrHeal(turnEndOfOwner ? p.ownHero : p.enemyHero, -heal);
                }
            }
        }
    }
}