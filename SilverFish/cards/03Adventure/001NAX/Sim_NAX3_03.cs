using HREngine.Bots;

namespace SilverFish.cards._03Adventure._001NAX
{
	class Sim_NAX3_03 : SimTemplate //* Necrotic Poison
	{
		// Destroy a minion.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetDestroyed(target);
        }
    }
}