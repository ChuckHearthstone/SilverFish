using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_014t : SimTemplate //bananas
	{

//    verleiht einem diener +1/+1.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetBuffed(target, 1, 1);
		}

	}
}