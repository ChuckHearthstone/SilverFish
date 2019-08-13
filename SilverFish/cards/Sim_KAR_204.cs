using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_KAR_204 : SimTemplate //* Onyx Bishop
	{
		//Battlecry: Summon a friendly minion that died this game.
				
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                if (p.OwnLastDiedMinion != CardDB.cardIDEnum.None)
                {
                    p.callKid(CardDB.Instance.getCardDataFromID(p.OwnLastDiedMinion), own.zonepos, own.own);
                }
            }
		}
	}
}