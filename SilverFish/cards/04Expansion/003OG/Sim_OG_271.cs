using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_271 : SimTemplate //* Scaled Nightmare
	{
		//At the start of your turn, double this minion's Attack.
		
		public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                p.minionGetBuffed(triggerEffectMinion, 2 * triggerEffectMinion.Attack, 0);
            }
        }
	}
}