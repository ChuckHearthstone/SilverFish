using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_BRM_024 : SimTemplate //* Drakonid Crusher
	{
		//	Battlecry: If your opponent has 15 or less Health, gain +3/+3.
	
        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            int heroHealth = m.own ? p.enemyHero.Hp : p.ownHero.Hp;
			if(heroHealth <= 15) p.minionGetBuffed(m, 3, 3);
        }
	}
}