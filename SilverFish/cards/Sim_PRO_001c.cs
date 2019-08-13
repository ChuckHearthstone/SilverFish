using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_PRO_001c : SimTemplate //* powerofthehorde
	{
        //Summon a random Horde Warrior.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_390);

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, pos, ownplay, false);
		}
	}
}