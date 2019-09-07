using HREngine.Bots;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRMA07_2H : SimTemplate //* ME SMASH
	{
		// Hero Power: Destroy a random enemy minion.
				
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
		    Minion m = p.searchRandomMinion(ownplay ? p.enemyMinions : p.ownMinions, searchmode.searchLowestHP);
            if (m != null) p.minionGetDestroyed(m);
        }
	}
}