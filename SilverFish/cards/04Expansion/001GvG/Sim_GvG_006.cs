using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_006 : SimTemplate //Mechwarper
    {

        //    Your Mechs cost (1) less.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnMechwarper++;
            }
            else
            {
                p.anzEnemyMechwarper++;

            }

        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnMechwarper--;
            }
            else
            {
                p.anzEnemyMechwarper--;
            }
        }


    }

}