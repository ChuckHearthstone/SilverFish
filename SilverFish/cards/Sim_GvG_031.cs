using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_031 : SimTemplate //* Recycle
    {
        //   Shuffle an enemy minion into your opponent's deck.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionReturnToDeck(target, !ownplay);
		}
	}
}