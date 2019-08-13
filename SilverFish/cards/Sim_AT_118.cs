using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_118 : SimTemplate //* Grand Crusader
	{
		//Battlecry: Add a random Paladin card to your hand.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
			p.drawACard(CardDB.cardName.unknown, m.own, true);
        }
    }
}