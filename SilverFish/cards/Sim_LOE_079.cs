using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOE_079 : SimTemplate //* Elise Starseeker
	{
		//Battlecry: Shuffle the 'Map to the Golden Monkey' into your deck.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
			{
				p.ownDeckSize++;
				p.evaluatePenality -= 6;
			}
            else p.enemyDeckSize++;
        }
    }
}