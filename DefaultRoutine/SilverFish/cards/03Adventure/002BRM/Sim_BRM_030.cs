using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRM_030 : SimTemplate //* Nefarian
	{
		// Battlecry: Add 2 random spells to your hand (from your opponent's class).
		
		public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
		{
            TAG_CLASS opponentHeroClass = (m.own) ? p.enemyHeroStartClass : p.ownHeroStartClass;

            switch (opponentHeroClass)
            {
                case TAG_CLASS.WARRIOR:
					p.drawACard(CardName.shieldblock, m.own, true);
					p.drawACard(CardName.shieldblock, m.own, true);
					break;
                case TAG_CLASS.WARLOCK:
					p.drawACard(CardName.baneofdoom, m.own, true);
					p.drawACard(CardName.baneofdoom, m.own, true);
                    break;
                case TAG_CLASS.ROGUE:
					p.drawACard(CardName.sprint, m.own, true);
					p.drawACard(CardName.sprint, m.own, true);
					break;
                case TAG_CLASS.SHAMAN:
					p.drawACard(CardName.farsight, m.own, true);
					p.drawACard(CardName.farsight, m.own, true);
					break;
                case TAG_CLASS.PRIEST:
					p.drawACard(CardName.thoughtsteal, m.own, true);
					p.drawACard(CardName.thoughtsteal, m.own, true);
					break;
                case TAG_CLASS.PALADIN:
					p.drawACard(CardName.hammerofwrath, m.own, true);
					p.drawACard(CardName.hammerofwrath, m.own, true);
					break;
                case TAG_CLASS.MAGE:
					p.drawACard(CardName.frostnova, m.own, true);
					p.drawACard(CardName.frostnova, m.own, true);
					break;
                case TAG_CLASS.HUNTER:
					p.drawACard(CardName.cobrashot, m.own, true);
					p.drawACard(CardName.cobrashot, m.own, true);
					break;
                case TAG_CLASS.DRUID:
					p.drawACard(CardName.wildgrowth, m.own, true);
					p.drawACard(CardName.wildgrowth, m.own, true);
                    break;
				//default:
			}
		}
	}
}