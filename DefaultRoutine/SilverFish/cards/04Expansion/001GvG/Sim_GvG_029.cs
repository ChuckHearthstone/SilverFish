using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_029 : SimTemplate //* Ancestor's Call
    {

        //    Put a random minion from each player's hand into the battlefield.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            Handmanager.Handcard c = null;
            int sum = 10000;
            foreach (Handmanager.Handcard hc in p.owncards)
            {
                if (hc.card.type == CardType.Minion)
                {
                    int s = hc.card.Health + hc.card.Attack + ((hc.card.tank) ? 1 : 0) + ((hc.card.DivineShield) ? 1 : 0);
                    if (s < sum)
                    {
                        c = hc;
                        sum = s;
                    }
                }
            }
            if (sum < 9999)
            {
                p.CallKid(c.card, p.ownMinions.Count, true, false);
                p.removeCard(c);
                p.triggerCardsChanged(true);
            }

            if (p.enemyAnzCards >= 2)
            {
                p.CallKid(c.card, p.enemyMinions.Count, false, false);
                p.enemyAnzCards--;
                p.triggerCardsChanged(false);
            }
        }
    }
}