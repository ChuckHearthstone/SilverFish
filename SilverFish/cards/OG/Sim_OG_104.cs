using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_OG_104 : SimTemplate //* Embrace the Shadow
    {
        //This turn, your healing effects deal damage instead.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{			
            if (ownplay)
            {
                p.embracetheshadow++;
            }
		}
	}
}