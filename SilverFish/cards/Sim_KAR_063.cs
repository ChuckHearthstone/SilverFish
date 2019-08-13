using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_KAR_063 : SimTemplate //* Spirit Claws
	{
		//Has +2 Attack while you have Spell Damage.

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.KAR_063);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
            if (ownplay)
            {
                if (p.spellpower > 0)
                {
                    p.minionGetBuffed(p.ownHero, 2, 0);
                    p.ownWeapon.Angr += 2;
                    p.ownSpiritclaws = true;
                }
            }
            else
            {
                if (p.enemyspellpower > 0)
                {
                    p.minionGetBuffed(p.enemyHero, 2, 0);
                    p.enemyWeapon.Angr += 2;
                    p.enemySpiritclaws = true;
                }
            }
        }
	}
}