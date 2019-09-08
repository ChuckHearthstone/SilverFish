using HREngine.Bots;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_061 : SimTemplate //* The Curator
	{
		//Taunt. Battlecry: Draw a Beast, Dragon, and Murloc from your deck.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.CardName.unknown, own.own);
            p.drawACard(CardDB.CardName.unknown, own.own);
		}
	}
}