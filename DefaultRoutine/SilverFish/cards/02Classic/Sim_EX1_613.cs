using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_613 : SimTemplate//edwin van cleefe
    {
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

            if(own.own) p.minionGetBuffed(own, p.cardsPlayedThisTurn * 2, p.cardsPlayedThisTurn * 2);
            else p.minionGetBuffed(own, p.enemyAnzCards * 2, p.enemyAnzCards * 2);
        }

    }
}
