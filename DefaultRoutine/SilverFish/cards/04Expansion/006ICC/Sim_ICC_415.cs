using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_415: SimTemplate //* Stitched Tracker
    {
        // Battlecry: Discover a copy of a minion in your deck.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardDB.CardName.unknown, own.own, true);
        }
    }
}