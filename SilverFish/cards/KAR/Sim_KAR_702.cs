using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_KAR_702 : SimTemplate //* Menagerie Magician
	{
		//Battlecry: Give a random Beast, Dragon and Murloc +2/+2.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            if (temp.Count >= 1)
            {
                Minion Beast = null;
                Minion Dragon = null;
                Minion Murloc = null;
				
                foreach (Minion m in temp)
                {
                    switch ((TAG_RACE)m.handcard.card.race)
					{
						case TAG_RACE.PET:
							if (Beast == null) Beast = m;
							continue;
						case TAG_RACE.DRAGON:
							if (Dragon == null) Dragon = m;
							continue;
                        case TAG_RACE.MURLOC:
							if (Murloc == null) Murloc = m;
							continue;
					}
                }
				
				if (Beast != null) p.minionGetBuffed(Beast, 2, 2);
				if (Dragon != null) p.minionGetBuffed(Dragon, 2, 2);
				if (Murloc != null) p.minionGetBuffed(Murloc, 2, 2);
            }
		}
	}
}