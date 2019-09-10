using System;
using System.Collections.Generic;
using System.Text;
using SilverFish.Enums;

namespace Chuck.SilverFish
{
	class Pen_EX1_014t : PenTemplate //bananas
	{

//    verleiht einem diener +1/+1.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
        {
            if (target.own)
            {
                if (!m.Ready)
                {
                    return 50;
                }
                if (m.HealthPoints == 1 && !m.DivineShield)
                {
                    return 10;
                }
            }
            else
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardName.biggamehunter || hc.card.name == CardName.shadowworddeath) return 0;
                }

               return 500;
            }
            return 0;
        }

	}
}