using System;
using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_089 : SimTemplate //arcanegolem
	{

//    ansturm/. kampfschrei:/ gebt eurem gegner 1 manakristall.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                p.enemyMaxMana = Math.Min(10, p.enemyMaxMana+1);
            }
            else
            {
                p.ownMaxMana = Math.Min(10, p.ownMaxMana + 1);
            }
		}


	}
}