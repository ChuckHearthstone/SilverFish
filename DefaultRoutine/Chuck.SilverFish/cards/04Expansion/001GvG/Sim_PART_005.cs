using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_PART_005 : SimTemplate //* Emergency Coolant
    {
        //Freeze a minion. 

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetFrozen(target);
        }
    }
}