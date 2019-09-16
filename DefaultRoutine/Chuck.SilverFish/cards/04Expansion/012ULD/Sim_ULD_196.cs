using System.Collections.Generic;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// 尼斐塞特仪祭师
    /// Neferset Ritualist
    /// </summary>
    public class Sim_ULD_196 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Restore adjacent minions to full Health.
        /// 战吼：为相邻的随从恢复所有生命值。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion mnn in temp)
            {
                if (mnn.zonepos == own.zonepos - 1 || mnn.zonepos == own.zonepos + 1)
                {
                    int heal = (own.own) ? p.getMinionHeal(mnn.maxHp - mnn.HealthPoints) : p.getEnemyMinionHeal(mnn.maxHp - mnn.HealthPoints);
                    p.minionGetDamageOrHeal(mnn, -heal, true);
                }
            }
        }
    }
}