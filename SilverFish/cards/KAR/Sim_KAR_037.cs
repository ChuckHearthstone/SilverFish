using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_KAR_037 : SimTemplate //* Avian Watcher
	{
		//Battlecry: If you control a Secret, gain +1/+1 and Taunt.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			int num = (own.own) ? p.ownSecretsIDList.Count : p.enemySecretCount;
			if (num > 0)
			{
				p.minionGetBuffed(own, 1, 1);
				own.taunt = true;
			}
		}
	}
}