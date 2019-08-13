using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Pen_OG_086 : PenTemplate //* Forbidden Flame
    {
        //Spend all your Mana. Deal that much damage to a minion.

        public override float getPlayPenalty(Playfield p, Handmanager.Handcard hc, Minion target, int choice, bool isLethal)
        {
            if (p.mana == 0) return 500;
            else return 20 / p.mana;
        }
    }
}