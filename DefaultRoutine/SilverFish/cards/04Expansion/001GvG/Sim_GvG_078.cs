using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_078 : SimTemplate //* Mechanical Yeti
    {

        //   Deathrattle: Give each player a Spare Part

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardName.armorplating, false, true);
            p.drawACard(CardName.unknown, true, true);
        }
    }
}