using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_316 : SimTemplate //* Rat Pack
	{
		// Deathrattle: Summon a number of 1/1 Rats equal to this minion's Attack.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_316t); //1/1 Rat

        public override void onDeathrattle(Playfield p, Minion m)
        {
            int anz = m.Angr;
            if (anz > 0)
            {
                p.callKid(kid, m.zonepos - 1, m.own, false);
                anz--;                
                for (int i = 0; i < anz; i++)
                {
                    p.callKid(kid, m.zonepos - 1, m.own);
                }
            }
        }
    }
}