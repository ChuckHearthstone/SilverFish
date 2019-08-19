using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_OG_118 : SimTemplate //* Renounce Darkness
    {
        //Replace your Hero Power and Warlock cards with another class's. The cards cost (1) less.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                foreach (Handmanager.Handcard hc in p.owncards) hc.manacost--;
            }
        }
    }
}