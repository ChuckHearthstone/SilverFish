using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_065 : SimTemplate //* King's Defender
	{
		//Battlecry: If you have a minion with Taunt, gain +1 Durability.

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_065);

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.equipWeapon(weapon, ownplay);

            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.taunt)
                {
                    if (ownplay) p.ownWeapon.Durability++;
                    else p.enemyWeapon.Durability++;
                    break;
                }
            }
		}
	}
}