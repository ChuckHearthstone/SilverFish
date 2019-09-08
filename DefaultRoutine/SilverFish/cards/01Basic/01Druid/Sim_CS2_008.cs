using HREngine.Bots;

namespace SilverFish.cards._01Basic._01Druid
{
    class Sim_CS2_008 : SimTemplate//moonfire
    {

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.minionGetDamageOrHeal(target, dmg);
            
        }

    }
}
