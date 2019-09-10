using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_039 : SimTemplate //* Savage Combatant
	{
		//Inspire: Give your hero +2 Attack this turn.

		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
				p.minionGetTempBuff(own ? p.ownHero : p.enemyHero, 2, 0);
			}
        }
	}
}