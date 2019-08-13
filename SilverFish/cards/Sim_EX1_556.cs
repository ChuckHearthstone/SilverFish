using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_556 : SimTemplate //* harvestgolem
	{
        //Deathrattle: Summon a 2/1 Damaged Golem.

        CardDB.Card card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.skele21);

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(card, m.zonepos - 1, m.own);
        }
	}
}