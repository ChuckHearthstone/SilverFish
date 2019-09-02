using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_655 : SimTemplate //* Toxic Sewer Ooze
	{
		// Battlecry: Remove 1 Durability from your opponent's weapon.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.lowerWeaponDurability(1, !m.own);
        }
    }
}