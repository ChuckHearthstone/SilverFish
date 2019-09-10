using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_132_SHAMANd : SimTemplate //* Wrath of Air Totem
	{
		//Spell Damage +1
		
		public override void  onAuraStarts(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.spellpower++;
            }
            else
            {
                p.enemyspellpower++;
            }
        }
		

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.spellpower--;
            }
            else
            {
                p.enemyspellpower--;
            }
        }

	}
}