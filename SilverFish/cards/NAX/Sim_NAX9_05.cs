using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NAX9_05 : SimTemplate //* Runeblade
	{
		//Has +3 Attack if the other Horsemen are dead.
		//Handled in Horsemen
		CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NAX9_05);

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.equipWeapon(weapon, ownplay);
			if (ownplay)
            {
				if (p.anzOwnHorsemen < 1)
				{
					p.ownWeapon.Angr += 3;
					p.minionGetBuffed(p.ownHero, 3, 0);
				}
            }
            else 
            {
				if (p.anzEnemyHorsemen < 1)
				{
					p.enemyWeapon.Angr += 3;
					p.minionGetBuffed(p.enemyHero, 3, 0);
				}
            }
		}
	}
}