using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_209 : SimTemplate //* Hallazeal the Ascended
	{
		//Whenever your spells deal damage, restore that much Health to your hero.
		
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool ownplay, Minion m)
        {
            if (m.own == ownplay && hc.card.type == CardDB.cardtype.SPELL)
            {
                Minion target = (ownplay) ? p.ownHero : p.enemyHero;
                p.minionGetDamageOrHeal(target, -p.prozis.penman.guessTotalSpellDamage(p, hc.card.name, ownplay));
            }
        }
    }
}