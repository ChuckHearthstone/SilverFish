using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRM_001 : SimTemplate //* Solemn Vigil
	{
		// Draw 2 cards. Costs (1) less for each minion that died this turn.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardName.unknown, ownplay);
            p.drawACard(CardName.unknown, ownplay);
		}
	}
}