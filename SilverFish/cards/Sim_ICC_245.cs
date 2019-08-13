using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_245: SimTemplate //* Blackguard
    {
        // Whenever your hero is healed, deal that much damage to a random enemy minion.

        public override void onACharGotHealed(Playfield p, Minion triggerEffectMinion, int charsGotHealed)
        {
            int dmg = charsGotHealed;
            Minion target = null;
            if (triggerEffectMinion.own) target = p.getEnemyCharTargetForRandomSingleDamage(dmg, true);
            else target = p.searchRandomMinion(p.ownMinions, searchmode.searchHighestAttack); //damage the Highest (pessimistic)
            if (target != null) p.minionGetDamageOrHeal(target, dmg);
        }
	}
}