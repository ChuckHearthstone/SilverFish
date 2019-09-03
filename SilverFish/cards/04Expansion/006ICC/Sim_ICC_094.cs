using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_094: SimTemplate //* Fallen Sun Cleric
    {
        // Battlecry: Give a friendly minion +1/+1.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null) p.minionGetBuffed(target, 1, 1);
        }
    }
}