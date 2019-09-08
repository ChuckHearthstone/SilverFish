using System;
using System.Collections.Generic;
using System.Text;
using SilverFish.Enums;

namespace HREngine.Bots
{
	class Pen_CS2_092 : PenTemplate //blessingofkings
	{

//    verleiht einem diener +4/+4. i&gt;(+4 angriff/+4 leben)/i&gt;
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
            if (target.own)
            {
                if (!m.Ready)
                {
                    return 50;
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