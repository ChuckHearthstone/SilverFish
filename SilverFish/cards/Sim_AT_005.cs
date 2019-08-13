using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_005 : SimTemplate //* Polymorph: Boar
	{
		//Transform a minion into a 4/2 Boar with Charge.

        CardDB.Card boar = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_005t);//Boar 4/2

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionTransform(target, boar);
        }
    }
}