namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Diseased Vulture
    /// 染病的兀鹫
    /// </summary>
    public class Sim_ULD_167 : SimTemplate
    {
        /// <summary>
        /// After your hero takes damage on your turn, summon a random 3-Cost minion.
        /// 你的英雄在自己的回合受到伤害后，随机召唤一个法力值消耗为（3）点的随从。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="triggerEffectMinion"></param>
        /// <param name="anzOwnMinionsGotDmg"></param>
        /// <param name="anzEnemyMinionsGotDmg"></param>
        /// <param name="anzOwnHeroGotDmg"></param>
        /// <param name="anzEnemyHeroGotDmg"></param>
        public override void onMinionGotDmgTrigger(Playfield p, Minion triggerEffectMinion, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            int pos = (triggerEffectMinion.own) ? p.ownMinions.Count : p.enemyMinions.Count;
            if (p.ownHero.anzGotDmg > 0 && triggerEffectMinion.own)
            {
                p.CallKid(p.getRandomCardForManaMinion(3), pos, triggerEffectMinion.own);
            }
            else if (p.enemyHero.anzGotDmg > 0 && !triggerEffectMinion.own)
            {
                p.CallKid(p.getRandomCardForManaMinion(3), pos, triggerEffectMinion.own);
            }
        }
    }
}