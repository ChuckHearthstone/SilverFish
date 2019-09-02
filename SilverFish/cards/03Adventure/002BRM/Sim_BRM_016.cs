using HREngine.Bots;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRM_016 : SimTemplate //* Axe Flinger
	{
		// Whenever this minion takes damage, deal 2 damage to the enemy hero

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.anzGotDmg > 0)
            {
                int tmp = m.anzGotDmg;
                m.anzGotDmg = 0;
                for (int i = 0; i < tmp; i++)
                {
					p.minionGetDamageOrHeal(m.own ? p.enemyHero : p.ownHero, 2);
                }
            }
        }
	}
}