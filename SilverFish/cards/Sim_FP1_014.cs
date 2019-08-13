using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_FP1_014 : SimTemplate //* stalagg
	{
        //todesröcheln:/ ruft thaddius herbei, wenn feugen in diesem duell bereits gestorben ist.

        CardDB.Card thaddius = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_014t);

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (p.feugenDead)
            {
                p.callKid(thaddius, m.zonepos - 1, m.own);
            }
        }
	}
}