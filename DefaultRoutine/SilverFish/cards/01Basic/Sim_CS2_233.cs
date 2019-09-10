using Chuck.SilverFish;

namespace SilverFish.cards._01Basic
{
    class Sim_CS2_233 : SimTemplate //* Blade Flurry
    {
        //Destroy your weapon and deal its damage to all enemy minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int damage = (ownplay) ? p.getSpellDamageDamage(p.ownWeapon.Angr) : p.getEnemySpellDamageDamage(p.enemyWeapon.Angr);

            p.allMinionOfASideGetDamage(!ownplay, damage);
            //destroy own weapon
            p.lowerWeaponDurability(1000, true);
        }
    }
}
