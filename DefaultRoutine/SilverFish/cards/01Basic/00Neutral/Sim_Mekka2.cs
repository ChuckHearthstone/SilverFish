using Chuck.SilverFish;

namespace SilverFish.cards._01Basic._00Neutral
{
    class Sim_Mekka2 : SimTemplate //repairbot
    {

        //    stellt am ende eures zuges bei einem verletzten charakter 6 leben wieder her.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (turnEndOfOwner == triggerEffectMinion.own)
            {

                Minion tm = null;
                int hl = (triggerEffectMinion.own) ? p.getMinionHeal(6) : p.getEnemyMinionHeal(6);
                int heal = 0;
                foreach (Minion m in p.ownMinions)
                {
                    if (m.maxHp - m.HealthPoints > heal)
                    {
                        tm = m;
                        heal = m.maxHp - m.HealthPoints;
                    }
                }
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.maxHp - m.HealthPoints > heal)
                    {
                        tm = m;
                        heal = m.maxHp - m.HealthPoints;
                    }
                }
                if (heal >= 1)
                {
                    p.minionGetDamageOrHeal(tm, -hl);
                }
                else
                {
                    p.minionGetDamageOrHeal(p.ownHero.HealthPoints < 30 ? p.ownHero : p.enemyHero, -hl);
                }

            }
        }

    }
}