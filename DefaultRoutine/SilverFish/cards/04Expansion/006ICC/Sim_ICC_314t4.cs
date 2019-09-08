using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_314t4 : SimTemplate //* Death Grip
    {
        // Steal a minion from your opponent's deck and add it to your hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                if (p.enemyDeckSize > 0)
                {
                    p.drawACard(CardName.unknown, ownplay, true);
                    p.enemyDeckSize--;
                }
            }
            else
            {
                if (p.ownDeckSize > 0)
                {
                    p.drawACard(CardName.unknown, ownplay, true);
                    p.ownDeckSize--;
                }
            }
        }
    }
}