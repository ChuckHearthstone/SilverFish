using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NAX9_05H : SimTemplate //* Runeblade
	{
		//Has +6 Attack if the other Horsemen are dead.
		//Handled in Horsemen
		CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NAX9_05H);

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.equipWeapon(weapon, ownplay);
			if (ownplay)
            {
				if (p.anzOwnHorsemen < 1)
				{
					p.ownWeapon.Angr += 6;
					p.minionGetBuffed(p.ownHero, 6, 0);
				}
            }
            else 
            {
				if (p.anzEnemyHorsemen < 1)
				{
					p.enemyWeapon.Angr += 6;
					p.minionGetBuffed(p.enemyHero, 6, 0);
				}
            }
		}
	}
}