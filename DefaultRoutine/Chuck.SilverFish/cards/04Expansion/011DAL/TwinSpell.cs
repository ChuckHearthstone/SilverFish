using System;

namespace Chuck.SilverFish.cards._04Expansion._011DAL
{
    public class TwinSpell : SimTemplate
    {
        public override void onCardWasPlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (!c.TwinSpell)
            {
                throw new Exception($"{typeof(TwinSpell)} can only be used by twin spell card.");
            }

            var twinSpellCopy = CardDB.Instance.GetCardByDbfId(c.TwinSpellCopyDbfId);
            var cardIdEnum = twinSpellCopy.cardIDenum;
            p.drawACard(cardIdEnum, wasOwnCard);
        }
    }
}
