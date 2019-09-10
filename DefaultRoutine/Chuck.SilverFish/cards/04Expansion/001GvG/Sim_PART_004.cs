using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_PART_004 : SimTemplate //Finicky Cloakfield
    {

        //   Give a friendly minion Stealth until your next turn.


        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            target.stealth = true;
            target.conceal = true;
        }


    }

}