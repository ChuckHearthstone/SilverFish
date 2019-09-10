using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_PART_006 : SimTemplate //Reversing Switch
    {
        //   Swap a minion's Attack and Health.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionSwapAngrAndHP(target);
        }
    }
}