using HREngine.Bots;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRMA04_2 : SimTemplate //* Magma Pulse
	{
		// Hero Power: Deal 1 damage to all minions.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getHeroPowerDamage(1) : p.getEnemyHeroPowerDamage(1);
			p.allMinionsGetDamage(dmg);
		}
	}
}