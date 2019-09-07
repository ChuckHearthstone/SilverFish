using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_FP1_028 : PenTemplate //undertaker
	{

//    Whenever you summon a minion with Deathrattle, gain +1 Attack.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}