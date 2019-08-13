using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_132 : SimTemplate //* Justicar Trueheart
	{
		//Battlecry: Replace your starting Hero Power with a better one.
		
		public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
		{
            TAG_CLASS HeroStartClass = (m.own) ? p.ownHeroStartClass : p.enemyHeroStartClass;
			CardDB.cardIDEnum tmp = CardDB.cardIDEnum.None;

            switch (HeroStartClass)
            {
                case TAG_CLASS.WARRIOR:
					tmp = CardDB.cardIDEnum.AT_132_WARRIOR; //Tank Up!
					break;
                case TAG_CLASS.WARLOCK:
					tmp = CardDB.cardIDEnum.AT_132_WARLOCK; //Soul Tap
                    break;
                case TAG_CLASS.ROGUE:
					tmp = CardDB.cardIDEnum.AT_132_ROGUE; //Poisoned Daggers
					break;
                case TAG_CLASS.SHAMAN:
					tmp = CardDB.cardIDEnum.AT_132_SHAMAN; //Totemic Slam
					break;
                case TAG_CLASS.PRIEST:
					tmp = CardDB.cardIDEnum.AT_132_PRIEST; //Heal
					break;
                case TAG_CLASS.PALADIN:
					tmp = CardDB.cardIDEnum.AT_132_PALADIN; //The Silver Hand
					break;
                case TAG_CLASS.MAGE:
					tmp = CardDB.cardIDEnum.AT_132_MAGE; //Fireblast Rank 2
					break;
                case TAG_CLASS.HUNTER:
					tmp = CardDB.cardIDEnum.AT_132_HUNTER; //Ballista Shot
					break;
                case TAG_CLASS.DRUID:
					tmp = CardDB.cardIDEnum.AT_132_DRUID; //Dire Shapeshift
                    break;
				//default:
			}

            if (tmp != CardDB.cardIDEnum.None) p.setNewHeroPower(tmp, m.own);
		}
	}
}