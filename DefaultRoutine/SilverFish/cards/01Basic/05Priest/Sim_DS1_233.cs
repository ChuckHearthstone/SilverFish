using HREngine.Bots;

namespace SilverFish.cards._01Basic._05Priest
{
    class Sim_DS1_233 : SimTemplate //mindblast
    {

        //    fügt dem feindlichen helden $5 schaden zu.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);

            p.minionGetDamageOrHeal(ownplay ? p.enemyHero : p.ownHero, dmg);
        }

    }
}