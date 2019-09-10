using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_051 : SimTemplate //* Forbidden Ancient
	{
		//Battlecry: Spend all your Mana. Gain +1/+1 for each mana spent.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			if (own.own)
			{
				p.minionGetBuffed(own, p.mana, p.mana);
				p.mana = 0;
			}
		}
	}
}