using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_855 : SimTemplate //* Defias Cleaner
	{
		// Battlecry: Silence a minion with Deathrattle.
        
        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null) p.minionGetSilenced(target);
        }
    }
}