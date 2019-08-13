using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Pen_OG_101 : PenTemplate //* Forbidden Shaping
    {
        //Spend all your Mana. Summon a random minion that costs that much.

        public override float getPlayPenalty(Playfield p, Handmanager.Handcard hc, Minion target, int choice, bool isLethal)
        {
            if (p.mana == 0) return 500;
            else return 30 / p.mana;
        }
    }
}