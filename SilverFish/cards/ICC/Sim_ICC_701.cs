using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_701: SimTemplate //* Skulking Geist
    {
        // Battlecry: Destroy all 1-Cost spells in both hands and decks.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                foreach (Handmanager.Handcard hc in p.owncards.ToArray())
                {
                    if (hc.manacost == 1 && hc.card.type == CardDB.cardtype.SPELL) p.owncards.Remove(hc);
                }
                p.renumHandCards(p.owncards);
            }
		}
	}
}