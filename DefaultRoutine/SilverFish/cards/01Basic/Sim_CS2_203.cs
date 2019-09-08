using HREngine.Bots;

namespace SilverFish.cards._01Basic
{
	class Sim_CS2_203 : SimTemplate //ironbeakowl
	{

//    kampfschrei:/ bringt einen diener zum schweigen/.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null) p.minionGetSilenced(target);
		}


	}
}