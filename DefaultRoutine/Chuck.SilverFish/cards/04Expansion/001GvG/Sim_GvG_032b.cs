using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_032b : SimTemplate //Grove Tender
    {

        //    Give each player a Mana Crystal.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

                p.drawACard(CardName.unknown, true);
                p.drawACard(CardName.unknown, false);
           
        }


    }

}