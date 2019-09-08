using HREngine.Bots;

namespace SilverFish.cards._01Basic._00Neutral
{
	class Sim_Mekka3 : SimTemplate //emboldener3000
	{

//    verleiht am ende eures zuges einem zufälligen diener +1/+1.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
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
                    p.minionGetBuffed(tm, 1, 1);
                }
            }
        }

	}
}