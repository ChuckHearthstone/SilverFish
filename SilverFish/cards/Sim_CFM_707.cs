using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_707 : SimTemplate //* Jade Lightning
	{
		// Deal 4 damage. Summon a Jade Golem.
        
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (target != null)
            {
                int dmg = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
                p.minionGetDamageOrHeal(target, dmg);
            }

            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(p.getNextJadeGolem(ownplay), pos, ownplay);
        }
    }
}