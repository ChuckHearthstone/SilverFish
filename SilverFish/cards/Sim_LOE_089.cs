using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOE_089 : SimTemplate //* Wobbling Runts
	{
		//Deathrattle: Summon three 2/2 Runts.
        
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.LOE_089t), m.zonepos - 1, m.own); //Rascally Runt
            p.callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.LOE_089t2), m.zonepos, m.own); //Wily Runt
            p.callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.LOE_089t3), m.zonepos + 1, m.own); //Grumbly Runt
        }
	}
}