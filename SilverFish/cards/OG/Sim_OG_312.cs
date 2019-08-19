using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_312 : SimTemplate //* N'Zoth's First Mate
	{
		//Battlecry: Equip a 1/3 Rusty Hook.

        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.OG_058);

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.equipWeapon(w, own.own);
        }
    }
}
