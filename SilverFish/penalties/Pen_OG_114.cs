using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Pen_OG_114 : PenTemplate //* Forbidden Ritual
    {
        //Spend all your Mana. Summon that many 1/1 Tentacles.

        public override float getPlayPenalty(Playfield p, Handmanager.Handcard hc, Minion target, int choice, bool isLethal)
        {
            if (p.mana == 0 || p.ownMinions.Count == 7) return 500;
            else
            {
                int pen = (10 / p.mana); //penalize low mana
                pen += 5 * (p.mana + p.ownMinions.Count - Math.Min(7, p.mana + p.ownMinions.Count)); //and overfilling board
                return pen;
            }
        }
    }
}