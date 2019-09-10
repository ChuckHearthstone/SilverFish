using System;
using System.Collections.Generic;
using System.Text;
using SilverFish.Enums;

namespace Chuck.SilverFish
{
	class Sim_TRL_348 : SimTemplate //* 魔泉山猫
	{
		//突袭，战吼：将一张1/1并具有突袭的山猫置入你的手牌。

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            own.cantAttackHeroes = true;

            p.drawACard(CardIdEnum.TRL_348t, own.own, true);
		}

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner) triggerEffectMinion.cantAttackHeroes = false;
        }

    }
}