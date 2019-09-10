using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_057 : SimTemplate //Seal of Light
    {

        //   Restore #4 Health to your hero and gain +2 Attack this turn.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                int heal = p.getSpellHeal(4);
                p.minionGetDamageOrHeal(p.ownHero, -heal);
                p.minionGetTempBuff(p.ownHero, 2, 0);
            }
            else
            {
                int heal = p.getEnemySpellHeal(4);
                p.minionGetDamageOrHeal(p.enemyHero, -heal);
                p.minionGetTempBuff(p.enemyHero, 2, 0);
            }

        }


    }

}