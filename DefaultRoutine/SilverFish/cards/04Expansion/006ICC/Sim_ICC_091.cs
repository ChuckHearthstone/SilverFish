using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_091: SimTemplate //* Dead Man's Hand
    {
        // Shuffle a copy of your hand into your deck.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay) p.ownDeckSize += p.owncards.Count;
            else p.enemyDeckSize += p.enemyAnzCards;
        }
    }
}