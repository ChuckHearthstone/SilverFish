using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_028t : SimTemplate //Gallywix's Coin
    {

        //    Gain 1 Mana Crystal this turn only.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.mana++;
        }


    }

}