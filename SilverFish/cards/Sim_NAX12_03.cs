using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NAX12_03 : SimTemplate //* 1/5 Jaws
	{
		//Whenever a minion with Deathrattle dies, gain +2
		//Handled in triggerAMinionDied()
		
        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NAX12_03);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
    }
}