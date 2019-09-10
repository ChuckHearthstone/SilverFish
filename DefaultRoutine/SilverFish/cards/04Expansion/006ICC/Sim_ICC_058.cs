using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_058: SimTemplate //* Brrrloc
    {
        // Battlecry: Freeze an enemy.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null) p.minionGetFrozen(target);
        }
    }
}