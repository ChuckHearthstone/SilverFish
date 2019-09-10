using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Worgen Abomination
    /// 狼人憎恶
    /// </summary>
    public class Sim_GIL_117 : SimTemplate
    {
        /// <summary>
        /// At the end of your turn, deal 2 damage to all other damaged minions.
        /// 在你的回合结束时，对所有其他受伤的随从造成2点伤害。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="triggerEffectMinion"></param>
        /// <param name="turnEndOfOwner"></param>
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (turnEndOfOwner == triggerEffectMinion.own)
            {
                foreach (Minion m in p.ownMinions)
                {
                    if (m.wounded) p.minionGetDamageOrHeal(m, 2);
                }
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.wounded) p.minionGetDamageOrHeal(m, 2);
                }
            }
        }
    }
}
