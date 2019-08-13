using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_946 : SimTemplate //* Gluttonous Ooze
	{
		//Battlecry: Destroy your opponent's weapon and gain Armor equal to its Attack.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			int num = p.enemyWeapon.Angr;
            if (!own.own) num = p.ownWeapon.Angr;
            p.lowerWeaponDurability(1000, !own.own);
            p.minionGetArmor(own.own ? p.ownHero : p.enemyHero, num);	
		}
	}
}