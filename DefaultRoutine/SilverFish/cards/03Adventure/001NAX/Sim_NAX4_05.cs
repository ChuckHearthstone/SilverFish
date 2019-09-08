using HREngine.Bots;

namespace SilverFish.cards._03Adventure._001NAX
{
	class Sim_NAX4_05 : SimTemplate //* Plague
	{
		// Destroy all non-Skeleton minions.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			foreach (Minion m in p.ownMinions)
            {
                if (m.name != CardDB.CardName.skeleton) p.minionGetDestroyed(m);
            }
            foreach (Minion m in p.enemyMinions)
            {
                if (m.name != CardDB.CardName.skeleton) p.minionGetDestroyed(m);
            }
		}
	}
}