using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_078 : SimTemplate //* Mechanical Yeti
    {

        //   Deathrattle: Give each player a Spare Part

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.CardName.armorplating, false, true);
            p.drawACard(CardDB.CardName.unknown, true, true);
        }
    }
}