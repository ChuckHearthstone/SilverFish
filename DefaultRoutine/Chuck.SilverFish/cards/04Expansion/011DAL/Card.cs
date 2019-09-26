namespace Chuck.SilverFish
{
    public partial class CardDB
    {
        public partial class Card
        {
            /// <summary>
            /// https://hearthstone.gamepedia.com/Twinspell
            /// Twinspell is an ability that is introduced in the Rise of Shadows expansion.
            /// When a spell with Twinspell is cast, a copy of that spell without Twinspell will be added to the player's hand. 
            /// </summary>
            public bool TwinSpell { get; set; }

            /// <summary>
            /// DbfId of the Twinspell copy
            /// </summary>
            public int TwinSpellCopyDbfId { get; set; }
        }
    }
}
