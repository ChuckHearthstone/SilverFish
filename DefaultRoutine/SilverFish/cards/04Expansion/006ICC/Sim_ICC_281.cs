using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_281: SimTemplate //* Forge of Souls
    {
        // Draw 2 weapons from your deck.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardName.fierywaraxe, ownplay);
            p.drawACard(CardName.unknown, ownplay);
        }
    }
}