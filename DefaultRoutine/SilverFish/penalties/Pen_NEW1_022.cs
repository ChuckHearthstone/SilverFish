using System;
using System.Collections.Generic;
using System.Text;

namespace Chuck.SilverFish
{
	class Pen_NEW1_022 : PenTemplate //dreadcorsair
	{

//    spott./ kostet (1) weniger für jeden angriffspunkt eurer waffe.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}