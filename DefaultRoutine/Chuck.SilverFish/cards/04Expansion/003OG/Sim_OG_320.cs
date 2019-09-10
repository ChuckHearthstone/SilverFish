using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_320 : SimTemplate //* Midnight Drake
	{
		// Battlecry: Gain +1 attack for each other card in your hand.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.minionGetBuffed(own, (own.own) ? p.owncards.Count : p.enemyAnzCards, 0);
		}
	}
}