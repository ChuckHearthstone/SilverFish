using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_026 : SimTemplate //* Wrathguard
	{
		//Whenever this minion takes damage, also deal that amount to your hero.

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.anzGotDmg > 0)
            {
                m.anzGotDmg = 0;
				p.minionGetDamageOrHeal(m.own ? p.ownHero : p.enemyHero, m.GotDmgValue);
            }
        }
	}
}