using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_069 : SimTemplate //Antique Healbot
    {

        //   Battlecry: Restore 8 Health to your hero.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                int heal = p.getMinionHeal(8);
                p.minionGetDamageOrHeal(p.ownHero, -heal, true);
            }
            else
            {
                int heal = p.getEnemyMinionHeal(8);
                p.minionGetDamageOrHeal(p.enemyHero, -heal, true);
            }
        }

    }

}