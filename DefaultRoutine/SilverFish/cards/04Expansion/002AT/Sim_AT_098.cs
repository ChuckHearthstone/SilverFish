using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_098 : SimTemplate //* Sideshow Spelleater
	{
		//Battlecry: Copy your opoonent's Hero Power.

		public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
		{
			if (m.own) p.ownHeroAblility = new Handmanager.Handcard(p.enemyHeroAblility);
            else p.enemyHeroAblility = new Handmanager.Handcard(p.ownHeroAblility);
		}
	}
}