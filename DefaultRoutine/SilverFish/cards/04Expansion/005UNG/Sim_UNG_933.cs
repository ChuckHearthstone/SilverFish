using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_933 : SimTemplate //* King Mosh
	{
		//Battlecry: Destroy all damaged minions.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            foreach (Minion m in p.ownMinions)
            {
                if (m.wounded)  p.minionGetDestroyed(m);
            }
            foreach (Minion m in p.enemyMinions)
            {
                if (m.wounded) p.minionGetDestroyed(m);
            }
        }
    }
}