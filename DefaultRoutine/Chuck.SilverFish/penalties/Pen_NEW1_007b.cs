using System;
using System.Collections.Generic;
using System.Text;

namespace Chuck.SilverFish
{
	class Pen_NEW1_007b : PenTemplate //starfall
	{

//    fügt einem diener $5 schaden zu.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}