using HREngine.Bots;

namespace SilverFish.cards._01Basic
{
	class Sim_CS2_147 : SimTemplate //gnomishinventor
	{

//    kampfschrei:/ zieht eine karte.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.CardName.unknown, own.own);
		}


	}
}