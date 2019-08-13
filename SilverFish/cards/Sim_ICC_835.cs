using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_835: SimTemplate //* Hadronox
    {
        // Deathrattle: Summon your taunt minions that died this game.

        CardDB cdb = CardDB.Instance;
        CardDB.Card kid = null;

        public override void onDeathrattle(Playfield p, Minion m)
        {
            int pos = m.own ? p.ownMinions.Count : p.enemyMinions.Count;
            int kids = 7 - pos;
            if (kids > 0)
            {
                foreach (KeyValuePair<CardDB.cardIDEnum, int> e in Probabilitymaker.Instance.ownCardsOut)
                {
                    kid = cdb.getCardDataFromID(e.Key);
                    if (kid.tank)
                    {
                        for (int i = 0; i < e.Value; i++)
                        {
                            p.callKid(kid, pos, m.own);
                            kids--;
                            if (kids < 1) break;
                        }
                        if (kids < 1) break;
                    }
                }
            }
        }
    }
}