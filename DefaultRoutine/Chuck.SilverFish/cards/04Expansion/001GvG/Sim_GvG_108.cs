using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_108 : SimTemplate //Recombobulator
    {

        //   Battlecry: Transform a friendly minion into a random minion with the same Cost.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if(target == null) return;
            p.minionTransform(target, target.handcard.card);
        }

    }

}