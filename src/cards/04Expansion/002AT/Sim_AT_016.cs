using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_016 : SimTemplate //* Confuse
	{
		//Swap the Attack and Health of all minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            foreach (Minion m in p.ownMinions)
            {
				p.minionSwapAngrAndHP(m);
            }
            foreach (Minion m in p.enemyMinions)
            {
				p.minionSwapAngrAndHP(m);
            }
        }
    }
}