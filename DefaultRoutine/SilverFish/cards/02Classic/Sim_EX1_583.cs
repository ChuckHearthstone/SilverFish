using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_583 : SimTemplate //priestessofelune
    {

        //    kampfschrei:/ stellt bei eurem helden 4 leben wieder her.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int heal = (own.own) ? p.getMinionHeal(4) : p.getEnemyMinionHeal(4);
            p.minionGetDamageOrHeal(own.own ? p.ownHero : p.enemyHero, -heal);
        }


    }
}