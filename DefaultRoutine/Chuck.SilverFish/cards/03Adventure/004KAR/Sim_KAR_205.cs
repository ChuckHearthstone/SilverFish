using System.Collections.Generic;
using Chuck.SilverFish;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_205 : SimTemplate //* Silverware Golem
	{
		//If you discard this minion, summon it.

        public override bool onCardDicscard(Playfield p, Handmanager.Handcard hc, Minion own, int num, bool checkBonus)
        {
            if (checkBonus) return true;
			if (own != null) return false;
			
            bool ownplay = true;
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            p.CallKid(hc.card, temp.Count, ownplay, false);
            Minion m = temp[temp.Count - 1];
            if (m.name == hc.card.name && m.playedThisTurn)
            {
                m.entitiyID = hc.entity;
                m.Attack += hc.addattack;
                m.HealthPoints += hc.addHp;
            }
            return true;
        }
    }
}