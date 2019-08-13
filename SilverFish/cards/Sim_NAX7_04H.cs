using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NAX7_04H : SimTemplate //* 10/2 Massive Runeblade
	{
		//Deals double damage to heroes.
		//Handled in minionAttacksMinion()

		CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NAX7_04H);

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.equipWeapon(weapon, ownplay);
		}
	}
}