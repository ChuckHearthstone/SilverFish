using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOE_021 : SimTemplate //* Dart Trap
	{
		//Secret: When an opposing Hero Power is used, deal 5 damage to a random enemy.

		public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            List<Minion> temp = (ownplay) ? p.enemyMinions : p.ownMinions;
			Minion target = null;
						
			if (temp.Count > 0) target = p.searchRandomMinion(temp, searchmode.searchHighAttackLowHP);
			if (target == null || ((ownplay) ? p.enemyHero : p.ownHero).Hp < 6) target = (ownplay) ? p.enemyHero : p.ownHero;
			p.minionGetDamageOrHeal(target, 5);
        }
    }
}