using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._007LOOT
{
	class Sim_LOOT_998l : SimTemplate //* Wondrous Wand
	{
		//Draw 3 cards. They cost (0).
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardName.unknown, ownplay);
            p.drawACard(CardName.unknown, ownplay);
            p.drawACard(CardName.unknown, ownplay);
			if (ownplay) p.evaluatePenality -= 20;
		}
	}
}