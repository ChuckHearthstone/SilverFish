using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_204 : SimTemplate //* Professor Putricide
    {
        // After you play a Secret, put another random Hunter secret into play.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool ownplay, Minion m)
        {
            if (hc.card.Secret) p.evaluatePenality -= 9;
        }

    }
}