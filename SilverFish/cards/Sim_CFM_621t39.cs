using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_621t39 : SimTemplate //* Ichor of Undeath
	{
		// Summon 3 friendly minions that died this game.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
			if (p.OwnLastDiedMinion != CardDB.cardIDEnum.None)
			{
				p.callKid(CardDB.Instance.getCardDataFromID(p.OwnLastDiedMinion), pos, ownplay, false); //presurmise - OwnLastDiedMinion also for enemy
				p.callKid(CardDB.Instance.getCardDataFromID(p.OwnLastDiedMinion), pos, ownplay);
				p.callKid(CardDB.Instance.getCardDataFromID(p.OwnLastDiedMinion), pos, ownplay);
			}
        }
    }
}