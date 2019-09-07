using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_854: SimTemplate //* Arfus
    {
        // Deathrattle: Add a random Death Knight card to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardName.unknown, m.own, true);
        }
    }
}