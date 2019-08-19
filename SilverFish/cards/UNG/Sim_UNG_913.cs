using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_913 : SimTemplate //* Tol'vir Warden
	{
		//Battlecry: Draw two 1-Cost minions from your deck.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                        p.drawACard(CardDB.cardName.lepergnome, own.own);
                        p.drawACard(CardDB.cardName.lepergnome, own.own);
            }
            else p.enemyAnzCards++;
		}
	}
}