using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_072 : SimTemplate //* Stonehill Defender
	{
		//Taunt. Battlecry: Discover a Taunt minion.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.pompousthespian, own.own, true);
        }
    }
}