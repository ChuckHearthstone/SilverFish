using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_DAL_743 : SimTemplate //* 荆棘帮斗猪
	{
		//突袭，亡语：召唤一个1/1的鱼人。

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.DAL_743t);// 1/1鱼人
        
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            own.cantAttackHeroes = true;
		}

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner) triggerEffectMinion.cantAttackHeroes = false;
        }
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.CallKid(kid, m.zonepos-1, m.own);
        }

		
    }
}