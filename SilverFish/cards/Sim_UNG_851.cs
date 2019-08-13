using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_851 : SimTemplate //* Elise the Trailblazer
	{
		//Battlecry: Shuffle a sealed Un'Goro pack into your deck.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own) p.ownDeckSize++;
            else p.enemyDeckSize++;
        }
    }
}