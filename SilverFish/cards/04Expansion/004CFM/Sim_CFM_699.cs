using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_699 : SimTemplate //* Seadevil Stinger
	{
		// Battlecry: The next Murloc you play this turn costs Health instead of Mana.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own) p.nextMurlocThisTurnCostHealth = true;
        }
    }
}