using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_BRM_027 : SimTemplate //* Majordomo Executus
	{
		//Deathrattle: Replace your hero with Ragnaros, the Firelord.
		        
		public override void onDeathrattle(Playfield p, Minion m)
        {
            p.setNewHeroPower(CardDB.cardIDEnum.BRM_027p, m.own); // DIE, INSECT!

			if (m.own)
            {
                p.ownHeroName = HeroEnum.ragnarosthefirelord;
                p.ownHero.Hp = 8;
                p.ownHero.maxHp = 8;
            }
            else
            {
                p.enemyHeroName = HeroEnum.ragnarosthefirelord;
                p.enemyHero.Hp = 8;
                p.enemyHero.maxHp = 8;
            }
        }
	}
}