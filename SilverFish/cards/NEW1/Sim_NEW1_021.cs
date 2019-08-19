using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
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
                        p.evaluatePenality += (m.Hp * 2 + m.Angr * 2) * 2;
                    }
                }
                p.allMinionsGetDestroyed();
            }
        }
	}
}