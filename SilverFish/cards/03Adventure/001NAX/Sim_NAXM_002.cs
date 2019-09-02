using HREngine.Bots;

namespace SilverFish.cards._03Adventure._001NAX
{
	class Sim_NAXM_002 : SimTemplate //* Skeletal Smith
	{
		// Deathrattle: Destroy your opponent's weapon.
		
		public override void onDeathrattle(Playfield p, Minion m)
		{
            p.lowerWeaponDurability(1000, !m.own);
		}
	}
}