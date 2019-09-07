using HREngine.Bots;

namespace SilverFish.cards._03Adventure._003LOE
{
	class Sim_LOE_029 : SimTemplate //* Jeweled Scarab
	{
		//Battlecry: Discover a (3)-Cost card.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.spidertank, own.own, true);
		}
	}
}