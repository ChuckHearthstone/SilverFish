using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_836 : SimTemplate //* Clutchmother Zavas
	{
		//Whenever you discard this, give it +2/+2 and return it to your hand.


        public override bool onCardDicscard(Playfield p, Handmanager.Handcard hc, Minion own, int num, bool checkBonus)
        {
            if (checkBonus) return true;
			if (own != null) return false;

            p.drawACard(CardDB.cardName.clutchmotherzavas, true, true);
            int i = p.owncards.Count - 1;
            p.owncards[i].addattack = hc.addattack +2;
            p.owncards[i].addHp = hc.addHp + 2;
            return true;
        }
    }
}