using HREngine.Bots;

namespace SilverFish.cards._01Basic._00Neutral
{
    class Sim_NEW1_021 : SimTemplate //* Doomsayer
	{
        // At the start of your turn, destroy ALL minions.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (turnStartOfOwner == triggerEffectMinion.own)
            {
                foreach (Minion m in p.ownMinions)
                {
                    if (m.entitiyID == triggerEffectMinion.entitiyID) continue;
                    if (m.playedThisTurn || m.playedPrevTurn)
                    {
                        if (PenalityManager.Instance.ownSummonFromDeathrattle.ContainsKey(m.name)) continue;
                        p.evaluatePenality += (m.HealthPoints * 2 + m.Attack * 2) * 2;
                    }
                }
                p.allMinionsGetDestroyed();
            }
        }
	}
}