using System;
using System.Collections.Generic;
using System.Text;
using SilverFish.Enums;

namespace HREngine.Bots
{
	class Pen_EX1_607 : PenTemplate //innerrage
	{

//    fügt einem diener $1 schaden zu. der diener erhält +2 angriff.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
            if (target.own)
            {
                if (m.HealthPoints == 1) return 500;
                if (!m.Ready)
                {
                    return 50;
                }
            }
            else
            {
                //if (m.handcard.card.type == CardDB.cardtype.MOB && p.ownMinions.Count == 0) return 0;
                //allow it if you have biggamehunter
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardName.biggamehunter || hc.card.name == CardName.shadowworddeath) return 0;
                }

                if (m.HealthPoints == 1)
                {
                    return 0;
                }

                if (!m.wounded && (m.Attack >= 4 || m.HealthPoints >= 5))
                {
                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if (hc.card.name == CardName.execute) return 0;
                    }
                }
                return base.getValueOfMinion(4, 5);
            }
            return 0;
		}

	}
}