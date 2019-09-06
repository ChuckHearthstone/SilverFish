using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_052 : SimTemplate //Crush
    {

        //   Destroy a minion. If you have a damaged minion, this costs (4) less.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetDestroyed(target);
        }


    }

}