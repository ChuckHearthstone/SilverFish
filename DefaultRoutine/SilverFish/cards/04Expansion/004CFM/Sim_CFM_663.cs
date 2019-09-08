using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_663 : SimTemplate //* Kabal Trafficker
	{
		// At the end of your turn, add a random Demon to your hand.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                p.drawACard(CardName.malchezaarsimp, turnEndOfOwner, true);
            }
        }
    }
}