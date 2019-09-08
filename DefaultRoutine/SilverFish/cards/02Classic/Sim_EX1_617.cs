using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_617 : SimTemplate //* Deadly Shot
	{
        // Destroy a random enemy minion.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            Minion m = p.searchRandomMinion(ownplay ? p.enemyMinions : p.ownMinions, searchmode.searchLowestHP);
            if (m != null) p.minionGetDestroyed(m);
		}

	}
}