using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_051 : SimTemplate //Warbot
    {

        //   Enrage:&lt;/b&gt; +1 Attack.

        public override void onEnrageStart(Playfield p, Minion m)
        {
            p.minionGetBuffed(m, 1, 0);
        }

        public override void onEnrageStop(Playfield p, Minion m)
        {
            p.minionGetBuffed(m, -1, 0);
        }


    }

}