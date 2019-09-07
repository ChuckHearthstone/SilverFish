using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_928 : SimTemplate //* Tar Creeper
	{
		//Taunt. Has +2 Attack during your opponent's turn.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                p.minionGetBuffed(triggerEffectMinion, 2, 0);
            }
        }

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                p.minionGetBuffed(triggerEffectMinion, -2, 0);
            }
        }
    }
}