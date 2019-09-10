using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_052 : SimTemplate //* Totem Golem
	{
		//Overload: (1)
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own) p.ueberladung++;
		}
	}
}