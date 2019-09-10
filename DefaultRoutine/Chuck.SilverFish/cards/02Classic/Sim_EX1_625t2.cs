using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_625t2 : SimTemplate //* Mind Shatter
	{
		//Hero Power: Deal 3 damage.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getHeroPowerDamage(3) : p.getEnemyHeroPowerDamage(3);
            p.minionGetDamageOrHeal(target, dmg);
		}
	}
}