using HREngine.Bots;

namespace SilverFish.cards._03Adventure._001NAX.FP1
{
	class Sim_FP1_027 : SimTemplate //stoneskingargoyle
	{

//    stellt zu beginn eures zuges das volle leben dieses dieners wieder her.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                int heal = (triggerEffectMinion.own) ? p.getMinionHeal(triggerEffectMinion.maxHp - triggerEffectMinion.HealthPoints) : p.getEnemyMinionHeal(triggerEffectMinion.maxHp - triggerEffectMinion.HealthPoints);
                p.minionGetDamageOrHeal(triggerEffectMinion, -heal);
            }
        }

	}
}