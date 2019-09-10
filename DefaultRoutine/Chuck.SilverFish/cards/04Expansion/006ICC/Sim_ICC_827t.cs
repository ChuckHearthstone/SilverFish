using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_827t : SimTemplate //* Shadow Reflection
    {
        //Each time you play a card, transform this into a copy of it.

        //handled

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Handmanager.Handcard triggerhc)
        {
            triggerhc.setHCtoHC(hc);
        }
    }
}