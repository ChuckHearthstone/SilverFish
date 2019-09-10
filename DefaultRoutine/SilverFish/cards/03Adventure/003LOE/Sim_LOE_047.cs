using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._003LOE
{
	class Sim_LOE_047 : SimTemplate //* Tomb Spider
	{
		//Battlecry: Discover a Beast.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardName.rivercrocolisk, own.own, true);
		}
	}
}