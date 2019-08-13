using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_117 : SimTemplate //* Master of Ceremonies
    {
		//Battlecry: If you have a minion with Spell Damage, gain +2/+2.
		
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp  = (own.own) ? p.ownMinions : p.enemyMinions;
            int gain = 0;
            foreach (Minion m in temp)
            {
                if (m.spellpower > 0) gain++;
            }
            if(gain>=1) p.minionGetBuffed(own, gain*2, gain*2);
        }
    }
}