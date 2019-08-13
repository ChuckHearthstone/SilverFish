using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_621t23 : SimTemplate //* Shadow Oil
	{
		// Add 2 random Demons to your hand.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
		    p.drawACard(CardDB.cardName.malchezaarsimp, ownplay, true);
		    p.drawACard(CardDB.cardIDEnum.CFM_621_m2, ownplay, true);
		}
	}
}