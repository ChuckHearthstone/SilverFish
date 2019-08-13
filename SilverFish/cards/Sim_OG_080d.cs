using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_080d : SimTemplate //* Briarthorn Toxin
	{
		//Give a minion +3 Attack.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 3, 0);
        }
	}
}