using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_332 : SimTemplate //silence
	{

//    bringt einen diener zum schweigen/.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetSilenced(target);
		}

	}
}