using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_208 : SimTemplate //* Stone Sentinel
	{
		//Battlecry: If you played an Elemental last turn, summon two 2/3 Elementals with Taunt.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.UNG_208t); //Rock Elemental

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			if (p.anzOwnElementalsLastTurn > 0 && own.own)
			{
                p.callKid(kid, own.zonepos - 1, own.own); //1st left
                p.callKid(kid, own.zonepos, own.own);
			}
        }
    }
}