using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._003LOE
{
	class Sim_LOE_019t : SimTemplate //* Map to the Golden Monkey
	{
		//Shuffle the Golden Monkey into your deck. Draw a card.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
			{
				p.ownDeckSize++;
				p.evaluatePenality -= 12;
			}
            else p.enemyDeckSize++;
			
			p.drawACard(CardName.unknown, ownplay);
		}
	}
}