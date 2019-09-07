using HREngine.Bots;

namespace SilverFish.cards._03Adventure._003LOE
{
	class Sim_LOE_107 : SimTemplate //* Eerie Statue
	{
		//Can't attack unless it's the only minion on the battlefield.
		
		public override void onMinionWasSummoned(Playfield p, Minion m, Minion summonedMinion)
        {
            if (!m.silenced)
            {
                m.cantAttack = (p.ownMinions.Count + p.enemyMinions.Count > 0) ? true : false;
                m.updateReadyness();
            }
        }
		
        public override void onMinionDiedTrigger(Playfield p, Minion m, Minion diedMinion)
        {
            if (!m.silenced)
            {
                int minionsOnBoard = 0;
                foreach (Minion mnn in p.ownMinions) if (mnn.HealthPoints > 0) minionsOnBoard++;
                foreach (Minion mnn in p.enemyMinions) if (mnn.HealthPoints > 0) minionsOnBoard++;
                m.cantAttack = (minionsOnBoard > 0) ? true : false;
                m.updateReadyness();
            }
        }
	}
}