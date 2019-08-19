using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_086 : SimTemplate //* Giant Anaconda
	{
		//Deathrattle: Summon a minion from your hand with 5 or more Attack.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
					if (hc.card.Attack + hc.addattack >= 5)
                    {
                        p.callKid(hc.card, p.owncards.Count, m.own);
						p.removeCard(hc);
                        break;
                    }
                }
            }
            else p.callKid(CardDB.Instance.getCardData(CardDB.cardName.seagiant), p.enemyMinions.Count, m.own);
        }
	}
}