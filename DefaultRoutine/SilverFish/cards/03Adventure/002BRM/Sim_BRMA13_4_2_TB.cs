using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRMA13_4_2_TB : SimTemplate //* Wild Magic
	{
		// Hero Power: Put a random spell from your opponent's class into your hand.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            TAG_CLASS opponentHeroClass = ownplay ? p.enemyHeroStartClass : p.ownHeroStartClass;

            switch (opponentHeroClass)
            {
                case TAG_CLASS.WARRIOR:
					p.drawACard(CardName.shieldblock, ownplay, true);
					break;
                case TAG_CLASS.WARLOCK:
					p.drawACard(CardName.baneofdoom, ownplay, true);
                    break;
                case TAG_CLASS.ROGUE:
					p.drawACard(CardName.sprint, ownplay, true);
					break;
                case TAG_CLASS.SHAMAN:
					p.drawACard(CardName.farsight, ownplay, true);
					break;
                case TAG_CLASS.PRIEST:
					p.drawACard(CardName.thoughtsteal, ownplay, true);
					break;
                case TAG_CLASS.PALADIN:
					p.drawACard(CardName.hammerofwrath, ownplay, true);
					break;
                case TAG_CLASS.MAGE:
					p.drawACard(CardName.frostnova, ownplay, true);
					break;
                case TAG_CLASS.HUNTER:
					p.drawACard(CardName.cobrashot, ownplay, true);
					break;
                case TAG_CLASS.DRUID:
					p.drawACard(CardName.wildgrowth, ownplay, true);
                    break;
				//default:
			}
		}
	}
}