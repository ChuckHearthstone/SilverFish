using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_604 : SimTemplate //* Greater Healing Potion
	{
		// Restore 12 health to a friendly character.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int heal = (ownplay) ? p.getSpellHeal(12) : p.getEnemySpellHeal(12);
            p.minionGetDamageOrHeal(target, -heal);
        }
    }
}