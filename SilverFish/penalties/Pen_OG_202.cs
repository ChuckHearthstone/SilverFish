using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Pen_OG_202 : PenTemplate //* Mire Keeper
    {
        //Choose One - Summon a 2/2 Slime; or Gain an empty Mana Crystal.

        public override float getPlayPenalty(Playfield p, Handmanager.Handcard hc, Minion target, int choice, bool isLethal)
        {
            if (choice == 1)
            {
                if (p.ownMinions.Count > 5) return 18;
            }
            if (choice == 2)
            {
                if (p.ownMaxMana == 10) return 500;
                else if (p.ownMaxMana > 5) return p.ownMaxMana;
            }
            return 0;
        }
    }
}