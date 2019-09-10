using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_622 : SimTemplate //shadowworddeath
	{

//    vernichtet einen diener mit mind. 5 angriff.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetDestroyed(target);
		}

	}
}