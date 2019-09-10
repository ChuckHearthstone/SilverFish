using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._003LOE
{
	class Sim_LOE_076 : SimTemplate //* Sir Finley Mrrgglton
	{
		//Battlecry: Discover a new Basic Hero Power.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardName.unknown, own.own, true);
		}
	}
}