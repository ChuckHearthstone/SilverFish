using Chuck.SilverFish;

namespace SilverFish.cards._01Basic.Shaman
{
    /// <summary>
    /// Healing Totem
    /// 治疗图腾
    /// </summary>
    class Sim_NEW1_009 : SimTemplate
    {
        /// <summary>
        /// At the end of your turn, restore 1 Health to all friendly minions.
        /// 在你的回合结束时，为所有友方随从恢复1点生命值。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="triggerEffectMinion"></param>
        /// <param name="turnEndOfOwner"></param>
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                int heal = (triggerEffectMinion.own) ? p.getMinionHeal(1) : p.getEnemyMinionHeal(1);
                p.allMinionOfASideGetDamage(turnEndOfOwner, -heal);
            }
        }
    }
}