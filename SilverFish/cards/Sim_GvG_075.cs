using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_075 : SimTemplate //Ship's Cannon
    {

        //   Whenever you summon a Pirate, deal 2 damage to a random enemy.

        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if (triggerEffectMinion.own == summonedMinion.own && summonedMinion.handcard.card.race == TAG_RACE.PIRATE)
            {
                p.doDmgToRandomEnemyCLIENT2(2, true, triggerEffectMinion.own);
            }
        }
    }
}