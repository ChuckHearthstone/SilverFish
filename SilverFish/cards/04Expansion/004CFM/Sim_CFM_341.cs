using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_341 : SimTemplate //* Sergeant Sally
	{
		// Deathrattle: Deal damage equal to the minion's Attack to all enemy minions.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.allMinionOfASideGetDamage(!m.own, m.Attack);
        }
    }
}