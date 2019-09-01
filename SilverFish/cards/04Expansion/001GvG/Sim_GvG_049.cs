using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_049 : SimTemplate //* Gahz'rilla
    {
        // Whenever this minion takes damage, double its Attack.

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.anzGotDmg > 0)
            {
                int tmp = m.anzGotDmg;
                m.anzGotDmg = 0;
                p.minionGetBuffed(m, m.Attack * (2 ^ tmp) - m.Attack, 0);
            }
        }
    }
}