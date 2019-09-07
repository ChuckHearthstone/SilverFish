using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_823: SimTemplate //* Simulacrum
    {
        // Copy the lowest Cost minion in your hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                Handmanager.Handcard hcCopy = null;
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.type == CardDB.cardtype.MOB)
                    {
                        if (hcCopy == null) hcCopy = hc;
                        else
                        {
                            if (hcCopy.manacost > hc.manacost) hcCopy = hc;
                        }
                    }
                }
                if (hcCopy != null) p.drawACard(hcCopy.card.name, ownplay, true);
            }
        }
    }
}