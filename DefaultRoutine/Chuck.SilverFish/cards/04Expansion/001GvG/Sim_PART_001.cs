using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_PART_001 : SimTemplate //Armor Plating
    {

        //   Give a minion +1 Health.


        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 0, 1);
        }


    }

}