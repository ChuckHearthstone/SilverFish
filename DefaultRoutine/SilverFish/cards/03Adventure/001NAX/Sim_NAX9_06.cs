using HREngine.Bots;

namespace SilverFish.cards._03Adventure._001NAX
{
	class Sim_NAX9_06 : SimTemplate //* Unholy Shadow
	{
		// Hero Power: Draw 2 cards.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardDB.CardName.unknown, ownplay);
            p.drawACard(CardDB.CardName.unknown, ownplay);
		}
	}
}