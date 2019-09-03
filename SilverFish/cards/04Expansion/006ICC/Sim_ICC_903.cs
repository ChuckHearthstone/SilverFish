using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_903: SimTemplate //* Sanguine Reveler
    {
        // Battlecry: Destroy a friendly minion and gain +2/+2.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetDestroyed(target);
                p.minionGetBuffed(own, 2, 2);
            }
        }
    }
}