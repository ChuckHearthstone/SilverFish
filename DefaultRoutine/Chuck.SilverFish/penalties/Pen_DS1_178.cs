using System;
using System.Collections.Generic;
using System.Text;

namespace Chuck.SilverFish
{
	class Pen_DS1_178 : PenTemplate //tundrarhino
	{

//    eure wildtiere haben ansturm/.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}