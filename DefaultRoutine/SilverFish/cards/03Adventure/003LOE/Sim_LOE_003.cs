using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._003LOE
{
	class Sim_LOE_003 : SimTemplate //* Ethereal Conjurer
	{
		//Battlecry: Discover a spell.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardName.thecoin, own.own, true);
		}
	}
}