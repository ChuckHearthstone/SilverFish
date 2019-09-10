using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_048 : SimTemplate //spellbreaker
	{

//    kampfschrei:/ bringt einen diener zum schweigen/.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null) p.minionGetSilenced(target);
		}


	}
}