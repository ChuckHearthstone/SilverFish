using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NAX10_02 : SimTemplate //* Hook
	{
		//Deathrattle: Put this weapon into your hand.

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NAX10_02);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
			p.drawACard(CardDB.cardIDEnum.NAX10_02, m.own, true);
        }
    }
}