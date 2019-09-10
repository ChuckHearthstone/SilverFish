using System;
using System.Collections.Generic;
using System.Text;
using SilverFish.Enums;

namespace Chuck.SilverFish
{
	class Pen_CS2_188 : PenTemplate //abusivesergeant
	{

//    kampfschrei:/ verleiht einem diener +2 angriff in diesem zug.
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
                if (m.handcard.card.type == CardType.Minion && p.ownMinions.Count == 0) return 0;
                //allow it if you have biggamehunter
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardName.biggamehunter ||hc.card.name == CardName.shadowworddeath ) return 0;
                }
                return 500;
            }
		return 0;
		}

	}
}