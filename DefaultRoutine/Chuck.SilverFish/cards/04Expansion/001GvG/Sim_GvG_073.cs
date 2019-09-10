using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_073 : SimTemplate //Cobra Shot
    {

        //   Deal $3 damage to a minion and the enemy hero.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);

            p.minionGetDamageOrHeal(target, dmg);

            if (ownplay) p.minionGetDamageOrHeal(p.enemyHero, dmg);
            else p.minionGetDamageOrHeal(p.ownHero, dmg);
        }


    }

}