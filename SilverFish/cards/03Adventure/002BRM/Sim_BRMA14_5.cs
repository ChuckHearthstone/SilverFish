using HREngine.Bots;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRMA14_5 : SimTemplate //* 3/3 toxitron
	{
		// At the start of your turn, deal 1 damage to all other minions.

		public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
		{
		   if (triggerEffectMinion.own == turnStartOfOwner)
           {
               p.allMinionsGetDamage(1, triggerEffectMinion.entitiyID);
		   }
		}

	}
}