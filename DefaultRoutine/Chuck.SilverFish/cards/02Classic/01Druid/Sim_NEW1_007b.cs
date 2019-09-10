using Chuck.SilverFish;

namespace SilverFish.cards._02Classic._01Druid
{
    class Sim_NEW1_007b : SimTemplate //starfall choice left
    {

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            p.minionGetDamageOrHeal(target, dmg);
        }

    }
}