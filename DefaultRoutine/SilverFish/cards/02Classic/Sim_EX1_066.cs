using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_066 : SimTemplate //acidicswampooze
	{

//    kampfschrei:/ zerstört die waffe eures gegners.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.lowerWeaponDurability(1000, !own.own);
		}


	}
}