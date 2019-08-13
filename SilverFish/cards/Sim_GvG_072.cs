using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_072 : SimTemplate //* Shadowboxer
    {
        // Whenever a character is healed, deal 1 damage to a random enemy.  

        public override void onACharGotHealed(Playfield p, Minion triggerEffectMinion, int charsGotHealed)
        {
            Minion target = null;

            if (triggerEffectMinion.own)
            {
                target = p.getEnemyCharTargetForRandomSingleDamage(charsGotHealed);
            }
            else
            {
                target = p.searchRandomMinion(p.ownMinions, searchmode.searchHighestAttack); //damage the Highest (pessimistic)
                if (target == null) target = p.ownHero;
            }
            p.minionGetDamageOrHeal(target, charsGotHealed, true);
        }
    }
}