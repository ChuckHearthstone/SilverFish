using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_082: SimTemplate //* Frozen Clone
    {
        // Secret: After your opponent plays a minion, add two copies of it to your hand.

        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            p.drawACard(CardName.unknown, ownplay, true);
            p.drawACard(CardName.unknown, ownplay, true);
        }
    }
}