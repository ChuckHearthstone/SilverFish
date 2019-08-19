using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_070 : SimTemplate //* Tol'vir Stoneshaper
	{
		//Battlecry: If you played an Elemental last turn, gain Taunt and Divine Shield.


        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			if (p.anzOwnElementalsLastTurn > 0 && own.own)
			{
				own.divineshild = true;
				own.taunt = true;
                p.anzOwnTaunt++;
			}
        }
    }
}