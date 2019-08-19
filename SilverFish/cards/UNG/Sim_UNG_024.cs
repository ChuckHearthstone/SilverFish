using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_024 : SimTemplate //* Mana Bind
	{
		//Secret: When your opponent casts a spell, add a copy to your hand that costs (0).

        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            p.drawACard(CardDB.cardName.unknown, ownplay, true);
        }
    }
}