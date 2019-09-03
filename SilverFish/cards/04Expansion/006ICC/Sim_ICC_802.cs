using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_802: SimTemplate //* Spirit Lash
    {
        // Lifesteal. Deal 1 damage to all minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            int heal = 0;
            List<Minion> tmp = ownplay ? p.enemyMinions : p.ownMinions;
            foreach (Minion m in tmp) heal += m.HealthPoints;
            p.allMinionOfASideGetDamage(!ownplay, dmg);
            foreach (Minion m in tmp) heal -= m.HealthPoints;
            p.applySpellLifesteal(heal, ownplay);
        }
    }
}
