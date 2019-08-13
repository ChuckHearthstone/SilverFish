using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOE_026 : SimTemplate //* Anyfin Can Happen
	{
		//Summon 7 Murlocs that died this game.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            var temp = (ownplay) ? Probabilitymaker.Instance.ownCardsOut : Probabilitymaker.Instance.enemyCardsOut;
            if (place > 6) return;

            CardDB.Card c;
            foreach (var gi in temp)
            {
                c = CardDB.Instance.getCardDataFromID(gi.Key);
                if ((TAG_RACE)c.race == TAG_RACE.MURLOC)
                {
                    p.callKid(c, place, ownplay, false);
                    place++;
                    if (place > 6) break;
                    if (gi.Value > 1)
                    {
                        p.callKid(c, place, ownplay, false);
                        place++;
                        if (place > 6) break;
                    }
                }
            }
            if (place > 6) return;
            foreach (var gi in p.diedMinions)
            {
                if (gi.own == ownplay)
                {
                    c = CardDB.Instance.getCardDataFromID(gi.cardid);
                    if ((TAG_RACE)c.race == TAG_RACE.MURLOC)
                    {
                        p.callKid(c, place, ownplay, false);
                        place++;
                        if (place > 6) break;
                    }
                }
            }
        }
    }
}