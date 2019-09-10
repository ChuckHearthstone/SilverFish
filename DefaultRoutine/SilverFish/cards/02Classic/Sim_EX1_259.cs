using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_259 : SimTemplate//Lightning Storm
    {
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.allMinionOfASideGetDamage(!ownplay, dmg);
            if (ownplay) p.ueberladung += 2;
        }

    }
}
