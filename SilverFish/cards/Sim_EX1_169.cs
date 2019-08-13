using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_169 : SimTemplate //* Innervate
	{
        //Gain 1 Mana Crystal this turn only.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.mana = Math.Min(p.mana + 1, 10);
		}
	}
}