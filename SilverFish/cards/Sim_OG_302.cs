using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_302 : SimTemplate //* Usher of Souls
	{
		//Whenever a friendly minion dies, give your C'Thun +1/+1 (wherever it is).
		
        public override void onMinionDiedTrigger(Playfield p, Minion m, Minion diedMinion)
        {
            if (m.own)
            {
                p.anzOgOwnCThunHpBonus += 1;
                p.anzOgOwnCThunAngrBonus += 1;
            }
        }
	}
}