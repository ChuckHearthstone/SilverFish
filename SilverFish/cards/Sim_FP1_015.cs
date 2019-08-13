using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_FP1_015 : SimTemplate //* feugen
	{
        //Deathrattle: If Stalagg also died this game, summon Thaddius.

        CardDB.Card thaddius = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_014t);

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (p.stalaggDead)
            {
                p.callKid(thaddius, m.zonepos - 1, m.own);
            }
        }
	}
}