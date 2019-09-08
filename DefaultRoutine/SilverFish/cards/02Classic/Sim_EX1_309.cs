using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_309 : SimTemplate//Siphon Soul
    {
        //Vernichtet einen Diener. Stellt bei Eurem Helden #3 Leben wieder her.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetDestroyed(target);
            int heal = (ownplay) ? p.getSpellHeal(3) : p.getEnemySpellHeal(3);

            p.minionGetDamageOrHeal(ownplay ? p.ownHero : p.enemyHero, -heal);
        }

    }
}
