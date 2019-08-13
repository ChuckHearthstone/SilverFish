using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_816 : SimTemplate //* Servant of Kalimos
	{
		//Battlecry: If you played an Elemental last turn Discover an Elemental.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.anzOwnElementalsLastTurn > 0 && own.own) p.drawACard(CardDB.cardName.hotspringguardian, own.own, true);
        }
    }
}