using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_409 : SimTemplate //* Upgrade!
	{
        // If you have a weapon, give it +1/+1. Otherwise equip a 1/3 weapon.

        CardDB.Card wcard = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_409t);//Heavy Axe

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                if (p.ownWeapon.Durability > 0)
                {
                    p.ownWeapon.Angr++;
                    p.ownWeapon.Durability++;
                    p.minionGetBuffed(p.ownHero, 1, 0);
                }
                else
                {
                    p.equipWeapon(wcard, true);
                }
            }
            else
            {
                if (p.enemyWeapon.Durability > 0)
                {
                    p.enemyWeapon.Angr++;
                    p.enemyWeapon.Durability++;
                    p.minionGetBuffed(p.enemyHero, 1, 0);
                }
                else
                {
                    p.equipWeapon(wcard, false);
                }
            }
		}
	}
}