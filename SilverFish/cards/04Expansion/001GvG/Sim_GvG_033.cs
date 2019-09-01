using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_033 : SimTemplate //* Tree of Life
    {

        //    Restore all characters to full Health.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			int heal = 1000;
            foreach (Minion m in p.ownMinions)
            {
                p.minionGetDamageOrHeal(m, -heal);
            }
            foreach (Minion m in p.enemyMinions)
            {
                p.minionGetDamageOrHeal(m, -heal);
            }

            p.minionGetDamageOrHeal(p.enemyHero, -heal);
            p.minionGetDamageOrHeal(p.ownHero, -heal);
        }


    }

}