using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_312 : SimTemplate //twistingnether
	{

//    vernichtet alle diener.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.allMinionsGetDestroyed();
		}

	}
}