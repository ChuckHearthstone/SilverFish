using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Pen_OG_198 : PenTemplate //* Forbidden Healing
    {
        //Spend all your Mana. Heal for double the mana you spent.

        public override float getPlayPenalty(Playfield p, Handmanager.Handcard hc, Minion target, int choice, bool isLethal)
        {
            if (p.mana == 0) return 500;
            else return 150 / p.mana;
        }
    }
}