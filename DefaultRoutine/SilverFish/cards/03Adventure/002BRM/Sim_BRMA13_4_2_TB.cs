using HREngine.Bots;

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
					p.drawACard(CardDB.CardName.shieldblock, ownplay, true);
					break;
                case TAG_CLASS.WARLOCK:
					p.drawACard(CardDB.CardName.baneofdoom, ownplay, true);
                    break;
                case TAG_CLASS.ROGUE:
					p.drawACard(CardDB.CardName.sprint, ownplay, true);
					break;
                case TAG_CLASS.SHAMAN:
					p.drawACard(CardDB.CardName.farsight, ownplay, true);
					break;
                case TAG_CLASS.PRIEST:
					p.drawACard(CardDB.CardName.thoughtsteal, ownplay, true);
					break;
                case TAG_CLASS.PALADIN:
					p.drawACard(CardDB.CardName.hammerofwrath, ownplay, true);
					break;
                case TAG_CLASS.MAGE:
					p.drawACard(CardDB.CardName.frostnova, ownplay, true);
					break;
                case TAG_CLASS.HUNTER:
					p.drawACard(CardDB.CardName.cobrashot, ownplay, true);
					break;
                case TAG_CLASS.DRUID:
					p.drawACard(CardDB.CardName.wildgrowth, ownplay, true);
                    break;
				//default:
			}
		}
	}
}