namespace Chuck.SilverFish.cards._04Expansion._011DAL
{
    /// <summary>
    /// All twin spell cards should inherit this template, and invoke TriggerTwinSpell at the end onCardPlay
    /// </summary>
    public class TwinSpell : SimTemplate
    {
        public CardDB.Card Card { get; set; }

        public void TriggerTwinSpell(Playfield playField, bool own)
        {
            if (!Card.TwinSpell)
            {
                return;
            }

            var twinSpellCopy = CardDB.Instance.GetCardByDbfId(Card.TwinSpellCopyDbfId);
            var cardIdEnum = twinSpellCopy.cardIDenum;
            playField.drawACard(cardIdEnum, own);
        }
    }
}
