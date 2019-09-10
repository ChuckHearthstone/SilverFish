using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_810 : SimTemplate //* Leatherclad Hogleader
	{
		// Battlecry: If your opponent has 6 or more cards in hand, gain Charge.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            int anz = (m.own) ? p.enemyAnzCards : p.owncards.Count;
            if (anz >= 6) p.minionGetCharge(m);
        }
    }
}