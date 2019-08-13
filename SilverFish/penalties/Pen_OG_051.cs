using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Pen_OG_051 : PenTemplate //* Forbidden Ancient
    {
        //Battlecry: Spend all your Mana. Gain +1/+1 for each mana spent.

        public override float getPlayPenalty(Playfield p, Handmanager.Handcard hc, Minion target, int choice, bool isLethal)
        {
            if (p.mana == 0) return 500;
            else return 30 / p.mana;
        }
    }
}