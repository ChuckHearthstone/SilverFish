using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_132_PRIEST : SimTemplate //* Heal
	{
		//Hero Power. Restore 4 Health.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int heal = 4;
            if (ownplay)
            {
                if (p.anzOwnAuchenaiSoulpriest > 0 || p.embracetheshadow > 0) heal = -heal;
                if (p.doublepriest >= 1) heal *= (2 * p.doublepriest);
            }
            else
            {
                if (p.anzEnemyAuchenaiSoulpriest >= 1) heal = -heal;
                if (p.enemydoublepriest >= 1) heal *= (2 * p.enemydoublepriest);
            }
            p.minionGetDamageOrHeal(target, -heal);
		}
	}
}