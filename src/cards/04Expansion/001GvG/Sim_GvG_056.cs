using System;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_056 : SimTemplate //Iron Juggernaut
    {

        //   Battlecry:&lt;/b&gt; Shuffle a Mine into your opponent's deck. When drawn, it explodes for 10 damage.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                p.enemyDeckSize++;
                if (p.enemyDeckSize <= 6)
                {
                    p.minionGetDamageOrHeal(p.enemyHero, Math.Min(10, p.enemyHero.HealthPoints-1), true);
                    p.evaluatePenality -= 6;
                }
                else
                {
                    if (p.enemyDeckSize <= 16)
                    {
                        p.minionGetDamageOrHeal(p.enemyHero, Math.Min(5, p.enemyHero.HealthPoints - 1), true);
                        p.evaluatePenality -= 8;
                    }
                    else
                    {
                        if (p.enemyDeckSize <= 26)
                        {
                            p.minionGetDamageOrHeal(p.enemyHero, Math.Min(2, p.enemyHero.HealthPoints - 1), true);
                            p.evaluatePenality -= 10;
                        }
                    }
                }
            }
            else
            {
                p.ownDeckSize++;
            }
        }


    }

}