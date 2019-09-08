using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_207: SimTemplate //* Devour Mind
    {
        // Copy 3 cards in your opponent's deck and add them to your hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.CardName.unknown, ownplay, true);
            p.drawACard(CardDB.CardName.unknown, ownplay, true);
            p.drawACard(CardDB.CardName.unknown, ownplay, true);
        }
    }
}