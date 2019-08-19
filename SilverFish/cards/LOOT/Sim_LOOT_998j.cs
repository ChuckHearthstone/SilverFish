using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOOT_998j : SimTemplate //* Zarog's Crown
	{
		//Discover a Legendary minion. Summon two copies of it.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            if (p.ownHeroHasDirectLethal()) p.callKid(CardDB.Instance.getCardData(CardDB.cardName.icehowl), pos, ownplay, false);
            else
			{
				p.callKid(CardDB.Instance.getCardData(CardDB.cardName.frostgiant), pos, ownplay, false);
				p.callKid(CardDB.Instance.getCardData(CardDB.cardName.frostgiant), pos, ownplay, true);
			}
        }
    }
}