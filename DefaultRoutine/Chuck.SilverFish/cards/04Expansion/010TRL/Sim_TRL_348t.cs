using System;
using System.Collections.Generic;
using System.Text;

namespace Chuck.SilverFish
{
	class Sim_TRL_348t : SimTemplate //* 山猫
	{
		//突袭

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            own.cantAttackHeroes = true;
		}

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner) triggerEffectMinion.cantAttackHeroes = false;
        }
    }
}