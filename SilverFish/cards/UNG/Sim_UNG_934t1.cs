using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_934t1 : SimTemplate //* Sulfuras
	{
		//Battlecry: Your Hero Power: becomes 'Deal 8 damage to a random enemy.'

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.UNG_934t1);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
            p.setNewHeroPower(CardDB.cardIDEnum.BRM_027p, ownplay); // DIE, INSECT!
        }
    }
}