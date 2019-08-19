using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_809 : SimTemplate //* Tanaris Hogchopper
	{
		// Battlecry: If your opponent's hand is empty, gain Charge.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            int anz = (m.own) ? p.enemyAnzCards : p.owncards.Count;
            if (anz < 1) p.minionGetCharge(m);
        }
    }
}