using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_809: SimTemplate //* Plague Scientist
    {
        // Combo: Give a friendly minion Poisonous.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.cardsPlayedThisTurn >= 1 && target != null && own.own)
            {
                target.poisonous = true;
            }
        }
    }
}