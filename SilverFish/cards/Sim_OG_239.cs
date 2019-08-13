using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_239 : SimTemplate //* DOOM!
	{
		//Destroy all minions. Draw a card for each.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int anz = p.ownMinions.Count + p.enemyMinions.Count;
			p.allMinionsGetDestroyed();
            for (int i = 0; i < anz; i++)
            {
                p.drawACard(CardDB.cardName.unknown, ownplay);
            }
		}
	}
}