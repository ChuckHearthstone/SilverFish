using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_165a : SimTemplate //* Cat Form
	{
        //Charge

        CardDB.Card cat = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_165t1);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionTransform(target, cat);
        }
	}
}