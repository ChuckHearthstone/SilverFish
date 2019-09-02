using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_335 : SimTemplate //* Dispatch Kodo
	{
        // Battlecry: Deal damage equal to this minion's Attack.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null) p.minionGetDamageOrHeal(target, m.Attack);
        }
	}
}