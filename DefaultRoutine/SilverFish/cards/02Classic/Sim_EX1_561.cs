using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_561 : SimTemplate //alexstrasza
	{

//    kampfschrei:/ setzt das verbleibende leben eines helden auf 15.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            target.HealthPoints = 15;
		}


	}
}