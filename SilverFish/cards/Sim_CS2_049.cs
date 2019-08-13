using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_CS2_049 : SimTemplate //totemiccall
    {
        //    Summon a random basic totem.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_050);//searing
        CardDB.Card kid2 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_052);//spellpower
        CardDB.Card kid3heal = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_009);//healing
        CardDB.Card kid4taunt = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_051);//stoneclaw
        //CardDB.Card kid6 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_575);//mana tide

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<CardDB.cardIDEnum> availa = new List<CardDB.cardIDEnum>
            {
                CardDB.cardIDEnum.CS2_052,
                CardDB.cardIDEnum.CS2_051,
                CardDB.cardIDEnum.NEW1_009,
                CardDB.cardIDEnum.CS2_050
            };

            foreach (Minion m in (ownplay) ? p.ownMinions : p.enemyMinions)
                {
                    if (availa.Contains(m.handcard.card.cardIDenum))
                    {
                        availa.Remove(m.handcard.card.cardIDenum);
                    }
                }

            int posi = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;

            // if there is less than 2 basic totems already then assume non-basic mana tide to avoid being optimistic about the current board.
            /*if (availa.Count > 2)
            {
                p.callKid(kid6, posi, ownplay);
                return;
            }*/

            if (availa.Contains(CardDB.cardIDEnum.CS2_050))
            {
                p.callKid(kid, posi, ownplay);
                return;
            }

            if (availa.Contains( CardDB.cardIDEnum.NEW1_009))
            {
                p.callKid(kid3heal, posi, ownplay);
                return;
            }

            if (availa.Contains( CardDB.cardIDEnum.CS2_052))
            {
                p.callKid(kid2, posi, ownplay);
                return;
            }

            if (availa.Contains( CardDB.cardIDEnum.CS2_051))
            {
                p.callKid(kid4taunt, posi, ownplay);
                
                return;
            }
            
        }
    }

}