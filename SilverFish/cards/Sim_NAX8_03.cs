using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NAX8_03 : SimTemplate //* Unrelenting Trainee
	{
//    Deathrattle:: Summon a Spectral Trainee for your opponent.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NAX8_03t); //Spectral Trainee
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            int place = (m.own) ? p.enemyMinions.Count : p.ownMinions.Count;
            p.callKid(kid, place, !m.own);
        }
	}
}