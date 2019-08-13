using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_907 : SimTemplate //* Ozruk
	{
		//Taunt. Battlecry: Gain +5 Health for each Elemental you played last turn.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own) p.minionGetBuffed(own, p.anzOwnElementalsLastTurn * 5, p.anzOwnElementalsLastTurn * 5);
		}
	}
}