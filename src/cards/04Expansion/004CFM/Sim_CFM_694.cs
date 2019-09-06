using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_694 : SimTemplate //* Shadow Sensei
	{
		// Battlecry: Give a Stealth minion +2/+2.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null) p.minionGetBuffed(target, 2, 2);
        }
    }
}