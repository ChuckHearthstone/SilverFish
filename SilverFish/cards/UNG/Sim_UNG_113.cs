using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_113 : SimTemplate //* Bright-Eyed Scout
	{
		//Battlecry: Draw a card. Change its Cost to (5).

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.unknown, own.own);
                p.owncards[p.owncards.Count - 1].manacost = 5;
		}
	}
}