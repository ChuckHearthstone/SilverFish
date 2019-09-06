using HREngine.Bots;

namespace SilverFish.cards._03Adventure._001NAX
{
	class Sim_NAX7_03 : SimTemplate //* Unbalancing Strike
	{
		// Hero Power: Deal 3 damage.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			int dmg = (ownplay) ? p.getHeroPowerDamage(3) : p.getEnemyHeroPowerDamage(3);
            p.minionGetDamageOrHeal(target, dmg);
        }
	}
}