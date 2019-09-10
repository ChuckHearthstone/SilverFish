using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_201: SimTemplate //* Roll the Bones
    {
        // Draw a card. If it has Deathrattle, cast this again.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardName.unknown, ownplay);
            p.drawACard(CardName.unknown, ownplay);
        }
    }
}