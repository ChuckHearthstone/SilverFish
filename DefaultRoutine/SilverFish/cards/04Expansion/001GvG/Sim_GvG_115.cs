using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_115 : SimTemplate //Toshley
    {

        //   Battlecry Deathrattle: Add a Spare Part card to your hand.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardDB.CardName.armorplating, own.own, true);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.CardName.armorplating, m.own, true);
        }


    }

}