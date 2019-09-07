using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_104 : SimTemplate //* Tuskarr Jouster
	{
		//Battlecry: Reveal a minion in each deck. If yours costs more, restore 7 Health to your hero.
		
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int heal = (own.own) ? p.getMinionHeal(7) : p.getEnemyMinionHeal(7);
            p.minionGetDamageOrHeal(own.own ? p.ownHero : p.enemyHero, -heal); // optimistic
        }
    }
}