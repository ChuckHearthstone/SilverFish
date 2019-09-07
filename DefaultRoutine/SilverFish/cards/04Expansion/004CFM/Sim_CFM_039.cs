using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_039 : SimTemplate //* Street Trickster
	{
		// Spell Damage +1

        public override void onAuraStarts(Playfield p, Minion m)
        {
            if (m.own) p.spellpower++;
            else p.enemyspellpower++;
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.spellpower--;
            else p.enemyspellpower--;
        }
    }
}