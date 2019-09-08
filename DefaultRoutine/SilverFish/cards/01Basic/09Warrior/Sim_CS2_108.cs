using HREngine.Bots;

namespace SilverFish.cards._01Basic._09Warrior
{
	class Sim_CS2_108 : SimTemplate //execute
	{

//    vernichtet einen verletzten feindlichen diener.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetDestroyed(target);
		}

	}
}