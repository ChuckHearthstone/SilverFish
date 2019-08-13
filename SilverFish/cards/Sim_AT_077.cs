using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_077 : SimTemplate //* Argent Lance
	{
		//Battlecry : Reveal a minion in each deck. If yours costs more, gain +1 durability.

        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_077);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(w, ownplay);
        }
	}
}