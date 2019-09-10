using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._01Basic._08Warlock
{
	class Sim_CS2_056 : SimTemplate //lifetap
	{

//    heldenfähigkeit/\nzieht eine karte und erleidet 2 schaden.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardName.unknown, ownplay);

            int dmg = 2;
            if (ownplay)
            {
                if (p.doublepriest >= 1) dmg *= (2 * p.doublepriest);
                p.minionGetDamageOrHeal(p.ownHero, dmg);
            }
            else
            {
                if (p.enemydoublepriest >= 1) dmg *= (2 * p.enemydoublepriest);
                p.minionGetDamageOrHeal(p.enemyHero, dmg);
            }
        }


	}
}