using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_255 : SimTemplate //* Doomcaller
	{
		//Battlecry: Give your C'Thun +2/+2 (wherever it is). If it's dead, shuffle it into your deck.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.cthunGetBuffed(2, 2, 0);
		}
	}
}