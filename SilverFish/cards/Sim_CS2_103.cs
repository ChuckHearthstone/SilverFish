using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_CS2_103 : SimTemplate //* Charge
    {
        //Give a friendly minion Charge. It can't attack heroes this turn.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetCharge(target);
            target.cantAttackHeroes = true;
        }
	}
}