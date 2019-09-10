using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_PART_002 : SimTemplate //Time Rewinder
    {

        //   Return a friendly minion to your hand.


        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionReturnToHand(target, target.own, 0);
        }


    }

}