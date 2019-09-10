using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._01Basic._00Neutral
{
	class Sim_NEW1_016 : SimTemplate //captainsparrot
	{

//    kampfschrei:/ fügt eurer hand einen zufälligen piraten aus eurem deck hinzu.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardName.unknown, true, true);
		}


	}
}