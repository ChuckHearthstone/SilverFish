using Chuck.SilverFish;

namespace SilverFish.cards._01Basic._07Shaman
{
    /// <summary>
    /// Wrath of Air Totem
    /// 空气之怒图腾
    /// </summary>
	class Sim_CS2_052 : SimTemplate
	{
        /// <summary>
        /// Spell Damage +1
        /// 法术伤害+1
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
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