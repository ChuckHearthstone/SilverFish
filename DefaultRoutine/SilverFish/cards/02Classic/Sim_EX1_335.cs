using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_335 : SimTemplate //lightspawn
	{

//    der angriff dieses dieners entspricht immer seinem leben.
        //todo dont buff this!
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            own.Attack = own.HealthPoints;
		}

	}
}