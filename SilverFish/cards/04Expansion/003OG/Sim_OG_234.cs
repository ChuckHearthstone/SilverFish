using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_234 : SimTemplate //* Darkshire Alchemist
	{
		//Battlecry: Restore 5 Health.
		
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int heal = (own.own) ? p.getMinionHeal(5) : p.getEnemyMinionHeal(5);
            p.minionGetDamageOrHeal(own.own ? p.ownHero : p.enemyHero, -heal);
        }
    }
}