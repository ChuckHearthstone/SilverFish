using HREngine.Bots;

namespace SilverFish.cards._01Basic
{
	class Sim_CS2_084 : SimTemplate //* huntersmark
	{
        //Change a minion's Health to 1.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionSetLifetoX(target, 1);
		}

	}
}