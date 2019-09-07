using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_027: SimTemplate //* Bone Drake
    {
        // Deathrattle: Add a random Dragon to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardName.faeriedragon, m.own, true);
        }
    }
}