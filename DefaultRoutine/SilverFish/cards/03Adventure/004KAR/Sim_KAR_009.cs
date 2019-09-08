using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_009 : SimTemplate //* Babbling Book
	{
		//Battlecry: Add a random Mage spell to your hand.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardName.frostbolt, own.own, true);
		}
	}
}