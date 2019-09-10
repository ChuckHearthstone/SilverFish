using Chuck.SilverFish;

namespace SilverFish.cards._03Adventure._001NAX
{
	class Sim_NAX10_03H : SimTemplate //* Hateful Strike
	{
		// Hero Power: Destroy a minion.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetDestroyed(target);
        }
    }
}