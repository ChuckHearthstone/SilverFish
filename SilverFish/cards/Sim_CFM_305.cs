using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_305 : SimTemplate //* Smuggler's Run
	{
		// Gige all minions in your hand +1/+1.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
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