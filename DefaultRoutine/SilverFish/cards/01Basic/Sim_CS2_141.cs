using Chuck.SilverFish;

namespace SilverFish.cards._01Basic
{
	class Sim_CS2_141 : SimTemplate //ironforgerifleman
	{

//    kampfschrei:/ verursacht 1 schaden.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            int dmg = 1;
            p.minionGetDamageOrHeal(target, dmg);
		}


	}
}