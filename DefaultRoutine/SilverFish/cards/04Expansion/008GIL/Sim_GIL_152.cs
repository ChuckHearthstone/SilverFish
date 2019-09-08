using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Blackhowl Gunspire
    /// 黑嚎炮塔
    /// </summary>
    public class Sim_GIL_152 : SimTemplate
    {
        /// <summary>
        /// Can't attack. Whenever this minion takes damage, deal 3 damage to a random enemy.
        /// 无法攻击。每当该随从受到伤害时，随机对一个敌人造成3点 伤害。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        /// <param name="anzOwnMinionsGotDmg"></param>
        /// <param name="anzEnemyMinionsGotDmg"></param>
        /// <param name="anzOwnHeroGotDmg"></param>
        /// <param name="anzEnemyHeroGotDmg"></param>
        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.anzGotDmg > 0)
            {
                int tmp = m.anzGotDmg;
                m.anzGotDmg = 0;
                for (int i = 0; i < tmp; i++)
                {
                    Minion target = null;

                    if (m.own)
                    {
                        target = p.getEnemyCharTargetForRandomSingleDamage(3);
                    }
                    else
                    {
                        target = p.searchRandomMinion(p.ownMinions, searchmode.searchLowestHP); //(pessimistic)
                        if (target == null) target = p.ownHero;
                    }
                    p.minionGetDamageOrHeal(target, 3);
                }
            }
        }
    }
}
