using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_131 : SimTemplate //* Twin Emperor Vek'lor
	{
		//Taunt Battlecry:If your C'Thun has at least 10 attack, summon another Emperor.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.OG_319);
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own && (p.anzOgOwnCThunAngrBonus + 6) > 9) p.callKid(kid, p.ownMinions.Count, own.own);
		}
	}
}