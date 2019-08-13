using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_034 : SimTemplate //* Poisoned Blade
	{
		//Your Hero Power gives this weapon +1 attack instead of replacing it.
		
        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_034);
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }

		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
				if(own) p.ownWeapon.Angr++;
				else p.enemyWeapon.Angr++; 
			}
        }		
	}
}