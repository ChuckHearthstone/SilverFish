using HREngine.Bots;

namespace SilverFish.cards._01Basic._07Shaman
{
	class Sim_CS2_042 : SimTemplate //fireelemental
	{

//    kampfschrei:/ verursacht 3 schaden.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            int dmg = 3;
            p.minionGetDamageOrHeal(target, dmg);
           
		}

	}
}