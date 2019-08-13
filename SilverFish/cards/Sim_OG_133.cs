using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_OG_133 : SimTemplate //* N'Zoth, the Corruptor
    {
        //Battlecry: Summon your Deathrattle minions that died this game.

        CardDB CardDBI = CardDB.Instance;
        CardDB.Card kid = null;

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int kids = 7 - p.ownMinions.Count;

            if (kids > 0)
            {
                foreach (KeyValuePair<CardDB.cardIDEnum, int> e in Probabilitymaker.Instance.ownCardsOut)
                {
                    kid = CardDBI.getCardDataFromID(e.Key);
                    if (kid.deathrattle)
                    {
                        for (int i = 0; i < e.Value; i++)
                        {
                            p.callKid(kid, own.zonepos, own.own);
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