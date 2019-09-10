using System;
using System.Collections.Generic;
using System.Text;

namespace Chuck.SilverFish
{
	class Pen_NEW1_040 : PenTemplate //hogger
	{

//    ruft am ende eures zuges einen gnoll (2/2) mit spott/ herbei.
		public override int getPlayPenalty(Playfield p, Minion m, Minion target, int choice, bool isLethal)
		{
		return 0;
		}

	}
}