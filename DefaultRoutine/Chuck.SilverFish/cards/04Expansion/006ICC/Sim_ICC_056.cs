using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_056: SimTemplate //* Cryostasis
    {
        // Give a minion +3/+3 and Freeze it.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 3, 3);
            p.minionGetFrozen(target);
        }
    }
}
