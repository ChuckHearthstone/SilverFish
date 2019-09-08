using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_593 : SimTemplate //nightblade
    {

        //    kampfschrei: /fügt dem feindlichen helden 3 schaden zu.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.minionGetDamageOrHeal(own.own ? p.enemyHero : p.ownHero, 3);
        }

    }
}