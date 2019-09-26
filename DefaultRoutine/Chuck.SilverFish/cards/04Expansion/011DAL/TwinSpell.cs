using System;

namespace Chuck.SilverFish.cards._04Expansion._011DAL
{
    /// <summary>
    /// All twin spell cards should inherit this template, and invoke base.onCardPlay in onCardPlay
    /// </summary>
    public class TwinSpell : SimTemplate
    {
        public CardDB.Card Card { get; set; }

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (!Card.TwinSpell)
            {
                throw new Exception($"{typeof(TwinSpell)} can only be used by twin spell card.");
            }

            var twinSpellCopy = CardDB.Instance.GetCardByDbfId(Card.TwinSpellCopyDbfId);
            var cardIdEnum = twinSpellCopy.cardIDenum;
            p.drawACard(cardIdEnum, ownplay);
        }
    }
}
