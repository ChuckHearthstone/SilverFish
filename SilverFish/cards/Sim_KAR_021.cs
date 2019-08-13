using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_KAR_021 : SimTemplate //Wicked Witchdoctor
    {
        // Whenever you cast a spell, summon a random basic Totem.

        //CardDB.Card kid1 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_050);//searing
        //CardDB.Card kid2 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_052);//spellpower
        CardDB.Card kid3 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_009);//healing
        //CardDB.Card kid4 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_051);//taunt

        public override void onCardWasPlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion)
        {
            int pos = (wasOwnCard) ? p.ownMinions.Count : p.enemyMinions.Count;
            if (triggerEffectMinion.own == wasOwnCard && c.type == CardDB.cardtype.SPELL)
            {
                p.callKid(kid3, pos, wasOwnCard);
            }
        }
    }
}