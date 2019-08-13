using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_048 : SimTemplate //* Mark of Y'Shaarj
	{
		//Give a minion +2/+2. If it's a Beast, draw a card.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 2, 2);
			if ((TAG_RACE)target.handcard.card.race == TAG_RACE.PET) p.drawACard(CardDB.cardName.unknown, ownplay);
        }
    }
}