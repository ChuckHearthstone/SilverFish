using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_082 : SimTemplate //* Clockwork Gnome
    {

        //Deathrattle: Add a Spare Part card to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardName.unknown, m.own, true);
        }
    }
}