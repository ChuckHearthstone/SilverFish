using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_BRMA13_4H : SimTemplate //* Wild Magic
	{
		// Hero Power: Put a random spell from your opponent's class into your hand.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            TAG_CLASS opponentHeroClass = ownplay ? p.enemyHeroStartClass : p.ownHeroStartClass;

            switch (opponentHeroClass)
            {
                case TAG_CLASS.WARRIOR:
					p.drawACard(CardDB.cardName.shieldblock, ownplay, true);
					break;
                case TAG_CLASS.WARLOCK:
					p.drawACard(CardDB.cardName.baneofdoom, ownplay, true);
                    break;
                case TAG_CLASS.ROGUE:
					p.drawACard(CardDB.cardName.sprint, ownplay, true);
					break;
                case TAG_CLASS.SHAMAN:
					p.drawACard(CardDB.cardName.farsight, ownplay, true);
					break;
                case TAG_CLASS.PRIEST:
					p.drawACard(CardDB.cardName.thoughtsteal, ownplay, true);
					break;
                case TAG_CLASS.PALADIN:
					p.drawACard(CardDB.cardName.hammerofwrath, ownplay, true);
					break;
                case TAG_CLASS.MAGE:
					p.drawACard(CardDB.cardName.frostnova, ownplay, true);
					break;
                case TAG_CLASS.HUNTER:
					p.drawACard(CardDB.cardName.cobrashot, ownplay, true);
					break;
                case TAG_CLASS.DRUID:
					p.drawACard(CardDB.cardName.wildgrowth, ownplay, true);
                    break;
				//default:
			}
		}
	}
}