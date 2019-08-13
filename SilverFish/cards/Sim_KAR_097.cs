using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_KAR_097 : SimTemplate //* Medivh, the Guardian
	{
		//Battlecry: Equip Atiesh, Greatstaff of the Guardian.
		
        CardDB.Card wcard = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.KAR_097t);//Atiesh

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.equipWeapon(wcard, own.own);
        }
    }
}
