using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_833h: SimTemplate //* Icy Touch
    {
        // Hero Power: Deal 1 damage. If this kills a minion, summon a Water Elemental.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_033); //Water Elemental

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getHeroPowerDamage(1) : p.getEnemyHeroPowerDamage(1);
            p.minionGetDamageOrHeal(target, dmg);

            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            if (target.Hp <= 0) p.callKid(kid, place, ownplay);
		}
	}
}