using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._01Basic._00Neutral
{
	class Sim_Mekka1 : SimTemplate //homingchicken
	{

//    vernichtet zu beginn eures zuges diesen diener und zieht 3 karten.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (turnStartOfOwner == triggerEffectMinion.own)
            {
                p.minionGetDestroyed(triggerEffectMinion);
                p.drawACard(CardName.unknown, turnStartOfOwner);
                p.drawACard(CardName.unknown, turnStartOfOwner);
                p.drawACard(CardName.unknown, turnStartOfOwner);
            }
        }

	}
}