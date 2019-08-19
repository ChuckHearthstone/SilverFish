using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_999t5 : SimTemplate //* Liquid Membrane
	{
		//Can't be targeted by spells or Hero Powers.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            target.cantBeTargetedBySpellsOrHeroPowers = true;
        }
    }
}