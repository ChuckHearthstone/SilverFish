using Chuck.SilverFish;

namespace SilverFish.cards._01Basic
{
	class Sim_CS2_117 : SimTemplate //earthenringfarseer
	{

//    kampfschrei:/ stellt 3 leben wieder her.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            int heal = (own.own) ? p.getMinionHeal(3) : p.getEnemyMinionHeal(3);
            p.minionGetDamageOrHeal(target, -heal);
		}

	}
}