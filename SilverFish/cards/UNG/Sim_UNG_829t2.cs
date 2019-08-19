using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_829t2 : SimTemplate //* Nether Portal
	{
		//At the end of your turn, summon two 3/2 Imps.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.UNG_829t3); //Nether Imp

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                p.callKid(kid, triggerEffectMinion.zonepos - 1, triggerEffectMinion.own); //1st left
                p.callKid(kid, triggerEffectMinion.zonepos, triggerEffectMinion.own); 
            }
        }
	}
}