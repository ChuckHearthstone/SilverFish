using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_039: SimTemplate //* Dark Conviction
    {
        // Set a minion's Attack and Health to 3.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionSetAngrToX(target, 3);
            p.minionSetLifetoX(target, 3);
        }
    }
}