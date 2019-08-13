using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOE_016 : SimTemplate //* Rumbling Elemental
	{
		//After you play a Battlecry minion, deal 2 damage to a random enemy.
		
        public override void onMinionWasSummoned(Playfield p, Minion m, Minion summonedMinion)
        {
            if (summonedMinion.handcard.card.battlecry && summonedMinion.playedFromHand && summonedMinion.own == m.own && summonedMinion.entitiyID != m.entitiyID)
            {
                Minion target = null;

                if (m.own)
                {
                    target = p.getEnemyCharTargetForRandomSingleDamage(2);
                }
                else
                {
                    target = p.searchRandomMinion(p.ownMinions, searchmode.searchHighestAttack); //damage the Highest (pessimistic)
                    if (target == null) target = p.ownHero;
                }
                p.minionGetDamageOrHeal(target, 2, true);
            }
        }
    }
}