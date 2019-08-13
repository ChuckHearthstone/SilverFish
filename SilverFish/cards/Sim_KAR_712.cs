using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_KAR_712 : SimTemplate //* Violet Illusionist
	{
		//During your turn, your hero is Immune.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own) p.ownHero.immune = true;
            else p.enemyHero.immune = true;
        }

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                if (turnStartOfOwner) p.ownHero.immune = true;
                else p.enemyHero.immune = true;
            }
        }
    }
}