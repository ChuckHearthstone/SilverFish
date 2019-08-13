using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NEW1_031 : SimTemplate //* animalcompanion
	{
        //Summon a random Beast Companion.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_032);//misha
        
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int pos = (ownplay)?  p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, pos, ownplay, false);
		}

	}
}