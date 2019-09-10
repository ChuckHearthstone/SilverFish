using Chuck.SilverFish;

namespace SilverFish.cards._01Basic._07Shaman
{
	class Sim_CS2_052 : SimTemplate //wrathofairtotem
	{

//    zauberschaden +1/
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