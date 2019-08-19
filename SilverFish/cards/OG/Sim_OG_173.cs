using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_173 : SimTemplate //* Blood of The Ancient One
	{
		//If you control two of these at the end of your turn, merge them into 'The Ancient One'

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.OG_173a); //The Ancient One
		
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
				List<Minion> temp = (turnEndOfOwner) ? p.ownMinions : p.enemyMinions;
				int anz =0;
				foreach (Minion m in temp)
				{
                    if (m.name == CardDB.cardName.bloodoftheancientone) anz++;
				}
				if (anz > 1)
				{
					anz = 0;
					foreach (Minion m in temp)
					{
                        if (m.name == CardDB.cardName.bloodoftheancientone)
						{
							p.minionGetDestroyed(m);
							anz++;
							if (anz == 2) break;
						}
					}

					int pos = (triggerEffectMinion.own) ? p.ownMinions.Count : p.enemyMinions.Count;
					p.callKid(kid, pos, triggerEffectMinion.own, false, true); 
				}
            }
        }
	}
}