using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_042 : SimTemplate //* Neptulon
    {
        // Battlecry: Add 4 random Murlocs to your hand. Overload: (3)

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            for (int i = 0; i < 4; i++)
            {
                p.drawACard(CardName.murlocraider, m.own, true);
            }
            if (m.own) p.ueberladung += 3;
        }
    }
}