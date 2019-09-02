using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_308b : SimTemplate //* Forgotten Mana
	{
		// Refresh your Mana Crystals.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay) p.mana = p.ownMaxMana;
            else p.mana = p.enemyMaxMana;
        }
    }
}