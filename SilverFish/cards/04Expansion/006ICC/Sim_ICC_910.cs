using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_910: SimTemplate //* Spectral Pillager
    {
        // Combo: Deal damage equal to the number of other cards you've played this turn.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                if (p.cardsPlayedThisTurn > 0)
                {
                    if (target != null) p.minionGetDamageOrHeal(target, p.cardsPlayedThisTurn);
                }
            }
        }
    }
}