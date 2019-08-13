using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    internal class Sim_GVG_075 : SimTemplate //* Ship's Cannon
    {

        //   Whenever you summon a Pirate, deal 2 damage to a random enemy.

        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if ((TAG_RACE)summonedMinion.handcard.card.race == TAG_RACE.PIRATE && triggerEffectMinion.own == summonedMinion.own)
            {
                Minion target = null;

                if (triggerEffectMinion.own)
                {
                    target = p.getEnemyCharTargetForRandomSingleDamage(2);
                }
                else
                {
                    target = p.searchRandomMinion(p.ownMinions, searchmode.searchHighestAttack); //damage the Highest (pessimistic)
                    if (target == null) target = p.ownHero;
                }
                p.minionGetDamageOrHeal(target, 2, true);
            }
        }
    }
}
