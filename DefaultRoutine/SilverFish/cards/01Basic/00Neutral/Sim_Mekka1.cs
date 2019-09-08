using HREngine.Bots;

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
                p.drawACard(CardDB.CardName.unknown, turnStartOfOwner);
                p.drawACard(CardDB.CardName.unknown, turnStartOfOwner);
                p.drawACard(CardDB.CardName.unknown, turnStartOfOwner);
            }
        }

	}
}