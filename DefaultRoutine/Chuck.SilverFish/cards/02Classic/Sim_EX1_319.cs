using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_319 : SimTemplate //flameimp
    {

        //    kampfschrei:/ fügt eurem helden 3 schaden zu.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.minionGetDamageOrHeal(own.own ? p.ownHero : p.enemyHero, 3);
        }


    }
}