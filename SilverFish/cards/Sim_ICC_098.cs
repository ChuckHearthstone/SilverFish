using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_098: SimTemplate //* Tomb Lurker
    {
        // Battlecry: Add a random Deathrattle minion that died this game to your hand.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            var temp = (own.own) ? Probabilitymaker.Instance.ownCardsOut : Probabilitymaker.Instance.enemyCardsOut;
            CardDB.Card c;
            bool found = false;
            foreach (var gi in temp)
            {
                c = CardDB.Instance.getCardDataFromID(gi.Key);
                if (c.deathrattle)
                {
                    p.drawACard(c.name, own.own, true);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                foreach (var gi in p.diedMinions)
                {
                    if (gi.own == own.own)
                    {
                        c = CardDB.Instance.getCardDataFromID(gi.cardid);
                        if (c.deathrattle)
                        {
                            p.drawACard(c.name, own.own, true);
                            break;
                        }
                    }
                }
            }
        }
    }
}