using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_132_ROGUEt : SimTemplate //* Poisoned Dagger
	{
        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_132_ROGUEt);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
	}
}