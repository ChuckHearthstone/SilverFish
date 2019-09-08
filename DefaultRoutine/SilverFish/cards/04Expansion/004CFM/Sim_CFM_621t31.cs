using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_621t31 : SimTemplate //* Shadow Oil
	{
		// Add 3 random Demons to your hand.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
		    p.drawACard(CardName.malchezaarsimp, ownplay, true);
		    p.drawACard(CardIdEnum.CFM_621_m2, ownplay, true);
		    p.drawACard(CardIdEnum.CFM_621_m4, ownplay, true);
		}
	}
}