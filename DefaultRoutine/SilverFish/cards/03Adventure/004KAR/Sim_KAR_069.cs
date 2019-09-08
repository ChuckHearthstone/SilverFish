using HREngine.Bots;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_069 : SimTemplate //* Swashburglar
	{
		//Battlecry: Add a random class card to your hand (from your opponent's class).
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.CardName.unknown, own.own, true);
		}
	}
}