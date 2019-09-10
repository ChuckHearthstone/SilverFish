using System.Collections.Generic;
using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_136 : SimTemplate //* Redemption
    {
        //Secret: When one of your minions dies, return it to life with 1 Health.

        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            CardDB.Card kid = CardDB.Instance.getCardDataFromID(ownplay ? p.revivingOwnMinion : p.revivingEnemyMinion);
            List<Minion> tmp = ownplay ? p.ownMinions : p.enemyMinions;
            int pos = tmp.Count;

            p.CallKid(kid, pos, ownplay, true, true);
            
            if (tmp.Count >= 1)
            {
                Minion summonedMinion = tmp[pos];
                if (summonedMinion.handcard.card.cardIDenum == kid.cardIDenum)
                {
                    summonedMinion.HealthPoints = 1;
                    summonedMinion.wounded = false;
                    if (summonedMinion.HealthPoints < summonedMinion.maxHp) summonedMinion.wounded = true;
                }
            }
        }
    }
}