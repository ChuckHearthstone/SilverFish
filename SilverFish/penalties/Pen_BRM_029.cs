using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_BRM_029 : PenTemplate //rendblackhand
	{
		public override float getPlayPenalty(Playfield p, Handmanager.Handcard hc, Minion target, int choice, bool isLethal)
		{
            // nudge play if battlecry conditions are met
            if (target != null && !target.isHero && target.handcard.card.rarity >= 5)
            {
                foreach (Handmanager.Handcard handcard in p.owncards)
                {
                    if (handcard.card.race == TAG_RACE.DRAGON) return -6;
                }
            }
            return 0;
        }
	}
}
