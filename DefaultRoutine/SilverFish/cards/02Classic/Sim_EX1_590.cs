using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_590 : SimTemplate //* Blood Knight
	{
        //Battlecry: All minions lose Divine Shield. Gain +3/+3 for each Shield lost.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            int shilds = 0;
            foreach (Minion m in p.ownMinions)
            {
                if (m.divineshild)
                {
                    p.minionLosesDivineShield(m);
                    shilds++;
                }
            }
            foreach (Minion m in p.enemyMinions)
            {
                if (m.divineshild)
                {
                    p.minionLosesDivineShield(m);
                    shilds++;
                }
            }
            p.minionGetBuffed(own, 3 * shilds, 3 * shilds);
		}
	}
}