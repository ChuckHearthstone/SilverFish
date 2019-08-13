using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_318 : SimTemplate //* Hogger, Doom of Elwynn
	{
		//Whenever this minion takes damage, summon a 2/2 Gnoll with Taunt.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.OG_318t);
		
        public override void onMinionGotDmgTrigger(Playfield p, Minion m, bool ownDmgdmin)
        {
            if (m.anzGotDmg>=1)
            {
                for (int i = 0; i < m.anzGotDmg; i++)
                {
					p.callKid(kid, m.zonepos, m.own);
                }
                m.anzGotDmg = 0;
            }
        }
	}
}