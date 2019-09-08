using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_621t9 : SimTemplate //* Shadow Oil
	{
		// Add a random Demon to your hand.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
		    p.drawACard(CardIdEnum.CFM_621_m4, ownplay, true);
		}
	}
}