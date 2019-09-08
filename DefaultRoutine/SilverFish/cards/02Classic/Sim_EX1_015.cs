using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_015 : SimTemplate //noviceengineer
	{

//    kampfschrei:/ zieht eine karte.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.unknown, own.own);
		}


	}
}