using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_753 : SimTemplate //* Grimestreet Outfitter
	{
		// Battlecry: Give all minions in your hand +1/+1.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.type == CardDB.cardtype.MOB)
                    {
                        hc.addattack++;
                        hc.addHp++;
                        p.anzOwnExtraAngrHp += 2;
                    }
                }
            }
        }
	}
}