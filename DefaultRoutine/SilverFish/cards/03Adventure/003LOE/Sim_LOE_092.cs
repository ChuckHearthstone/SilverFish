using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._003LOE
{
	class Sim_LOE_092 : SimTemplate //* Arch-Thief Rafaam
	{
		//Battlecry: Discover a powerful Artifact.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardName.lanternofpower, own.own, true);
		}
	}
}