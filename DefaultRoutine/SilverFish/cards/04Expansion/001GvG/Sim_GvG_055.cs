using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_055 : SimTemplate //Screwjank Clunker
    {

        //   Battlecry&lt;/b&gt;: Give a friendly Mech +2/+2.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

            if (target == null) return;
            p.minionGetBuffed(target, 2, 2);
        }


    }

}