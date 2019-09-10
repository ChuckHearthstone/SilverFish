using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_838t : SimTemplate //* Frozen Champion
    {
        // Deathrattle: Add a random Legendary minion to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardName.unknown, m.own, true);
            p.drawACard(CardName.unknown, m.own, true);//bonus
        }
    }
}