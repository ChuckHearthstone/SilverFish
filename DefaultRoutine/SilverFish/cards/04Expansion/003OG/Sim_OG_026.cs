using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_026 : SimTemplate //* Eternal Sentinel
	{
		//Battlecry: Unlock your Overloaded Mana Crystals.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own) p.unlockMana();
		}
	}
}