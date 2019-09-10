using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_108 : SimTemplate //* Armored Warhorse
	{
		//Battlecry: Reveal a minion in each deck.If yours costs more, gain Charge.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.minionGetCharge(own); // optimistic
		}
	}
}