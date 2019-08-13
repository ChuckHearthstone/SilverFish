using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_240: SimTemplate //* Runeforge Haunter
    {
        // During your turn, your weapon doesn't lose Durability.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own) p.ownWeapon.immune = true;
            else p.enemyWeapon.immune = true;
        }

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                if (turnStartOfOwner) p.ownWeapon.immune = true;
                else p.enemyWeapon.immune = true;
            }
        }
    }
}