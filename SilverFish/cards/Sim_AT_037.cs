using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_037 : SimTemplate //* Living Roots
	{
		//Choose One - Deal 2 damage; or Summon two 1/1 Saplings.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_037t); //Sapling
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (choice == 1 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                if (target != null)
                {
                    int damage = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
                    p.minionGetDamageOrHeal(target, damage);
                }
            }
            if (choice == 2 || (p.ownFandralStaghelm > 0 && ownplay))
            {
				int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
				p.callKid(kid, place, ownplay, false);
				p.callKid(kid, place, ownplay);
            }
        }
    }
}