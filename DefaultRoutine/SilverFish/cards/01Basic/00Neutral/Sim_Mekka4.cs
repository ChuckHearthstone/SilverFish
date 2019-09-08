using HREngine.Bots;

namespace SilverFish.cards._01Basic._00Neutral
{
	class Sim_Mekka4 : SimTemplate //* poultryizer
	{
        CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.Mekka4t);
                                
//    verwandelt zu beginn eures zuges einen zufälligen diener in ein huhn (1/1).

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                Minion tm = null;
                int ges = 1000;
                foreach (Minion m in p.ownMinions)
                {
                    if (m.Attack + m.HealthPoints < ges)
                    {
                        tm = m;
                        ges = m.Attack + m.HealthPoints;
                    }
                }
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.Attack + m.HealthPoints < ges)
                    {
                        tm = m;
                        ges = m.Attack + m.HealthPoints;
                    }
                }
                if (ges <= 999)
                {
                    p.minionTransform(tm, c);
                    tm.playedThisTurn = false;
                    tm.Ready = true;
                }
            }
        }

      

	}
}