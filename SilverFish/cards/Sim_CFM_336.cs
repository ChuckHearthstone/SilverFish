using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_336 : SimTemplate //* Shaky Zipgunner
	{
		// Deathrattle: Give a random minion in your hand +2/+2.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
                Handmanager.Handcard hc = p.searchRandomMinionInHand(p.owncards, Playfield.searchmode.searchLowestCost, Playfield.cardsProperty.Mob);
                if (hc != null)
                {
                    hc.addattack += 2;
                    hc.addHp += 2;
                    p.anzOwnExtraAngrHp += 4;
                }
            }
        }
	}
}