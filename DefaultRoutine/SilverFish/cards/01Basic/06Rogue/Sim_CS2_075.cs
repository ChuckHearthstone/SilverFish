using HREngine.Bots;

namespace SilverFish.cards._01Basic._06Rogue
{
    class Sim_CS2_075 : SimTemplate //sinisterstrike
    {

        //    fügt dem feindlichen helden $3 schaden zu.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);

            p.minionGetDamageOrHeal(ownplay ? p.enemyHero : p.ownHero, dmg);

        }

    }
}