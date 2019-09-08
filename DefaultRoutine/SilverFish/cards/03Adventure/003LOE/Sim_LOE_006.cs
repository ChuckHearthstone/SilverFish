using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._003LOE
{
	class Sim_LOE_006 : SimTemplate //* Museum Curator
	{
		//Battlecry: Discover a Deathrattle card.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardName.lepergnome, own.own, true);
		}
	}
}