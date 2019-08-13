using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Pen_AT_094 : PenTemplate //flamejuggler
	{
		public override float getPlayPenalty(Playfield p, Handmanager.Handcard hc, Minion target, int choice, bool isLethal)
		{
            //small bonus for divineshield or 1 hp minions
            int pen = 0;
            foreach (Minion m in p.enemyMinions)
            {
                if (m.divineshild || m.Hp == 1)
                {
                    pen -= 2;
                }
                else
                {
                    pen += 1;
                }    
            }
            pen = Math.Min(3, pen);//minimize penalty
            pen = Math.Max(-5, pen);//don't let the bonus get out of hand
            return pen;
		}
	}
}
