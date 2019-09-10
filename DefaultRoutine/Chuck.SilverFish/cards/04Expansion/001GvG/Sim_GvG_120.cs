using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_120 : SimTemplate //Hemet Nesingwary
    {

        //   Battlecry: Destroy a Beast.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target == null) return;

            p.minionGetDestroyed(target);
        }



    }

}