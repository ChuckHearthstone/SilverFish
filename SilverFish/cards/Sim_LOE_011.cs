using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOE_011 : SimTemplate //* Reno Jackson
	{
		//Battlecry: If your deck contains no more than 1 of any card, fully heal your hero.
		
        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own && p.prozis.noDuplicates) p.minionGetDamageOrHeal(p.ownHero, p.ownHero.Hp - p.ownHero.maxHp);
        }
    }
}