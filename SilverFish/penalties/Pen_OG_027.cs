using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Pen_OG_027 : PenTemplate //* Evolve
    {
        //Transform your minions into random minions that cost (1) more.

        public override float getPlayPenalty(Playfield p, Handmanager.Handcard hc, Minion target, int choice, bool isLethal)
        {
            int pen = 0;
            int boardcost = 0;
            int boardAngr = 0;
            int boardHp = 0;
            foreach (Minion m in p.ownMinions)
            {
                int cardcost = m.handcard.getManaCost(p);
                boardcost += (cardcost < 1000) ? cardcost : 1; // todo sepefeets - why are plchldr cards getting through?
                boardAngr += m.Angr;
                boardHp += m.Hp;
                if (m.Ready && m.Angr > 0) pen += 10;
            }

            pen += (p.ownMinions.Count < 3) ? 5 : 0;
            pen += 20 - boardcost;
            if (boardAngr > boardcost) pen += 10;
            if (boardHp > boardcost) pen += 5;
            return pen;
        }
    }
}