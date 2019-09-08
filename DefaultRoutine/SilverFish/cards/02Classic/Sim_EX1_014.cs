using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_014 : SimTemplate //kingmukla
	{

//    kampfschrei:/ gebt eurem gegner 2 bananen.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.CardName.bananas, !own.own, true);
            if (own.own)
            {
                p.enemycarddraw -= 1;
            }
            p.drawACard(CardDB.CardName.bananas, !own.own, true);
            if (own.own)
            {
                p.enemycarddraw -= 1;
            }
		}


	}
}