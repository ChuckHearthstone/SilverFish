using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_317 : SimTemplate //* Deathwing, Dragonlord
	{
		//Deathrattle: Put all Dragons from your hand into the battlefield.
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
				if (p.ownMinions.Count < 7)
				{
					bool needTrigger = false;
					foreach (Handmanager.Handcard hc in p.owncards.ToArray())
					{
						if ((TAG_RACE)hc.card.race == TAG_RACE.DRAGON)
						{
							p.callKid(hc.card, p.ownMinions.Count, true);
							p.removeCard(hc);
							needTrigger = true;
							if (p.ownMinions.Count > 6) break;
						}
					}
					if (needTrigger) p.triggerCardsChanged(true);
				}
            }
            else
            {
				CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_561);//Alexstrasza
                p.callKid(kid, p.enemyMinions.Count, false);
				if (p.enemyAnzCards > 1)
				{
					p.enemyAnzCards--;
					p.triggerCardsChanged(false);
				}
            }
        }
	}
}
