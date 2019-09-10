using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_050 : SimTemplate //coldlightoracle
	{

//    kampfschrei:/ jeder spieler zieht 2 karten.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardName.unknown, true);
            p.drawACard(CardName.unknown, true);
            p.drawACard(CardName.unknown, false);
            p.drawACard(CardName.unknown, false);

		}


	}
}