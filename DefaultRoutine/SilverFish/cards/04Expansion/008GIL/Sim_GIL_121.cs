using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Darkmire Moonkin
    /// 黑沼枭兽
    /// </summary>
    public class Sim_GIL_121 : SimTemplate
    {
        /// <summary>
        /// Spell Damage +2
        /// 法术伤害+2
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.spellpower += 2;
            }
            else
            {
                p.enemyspellpower += 2;
            }
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.spellpower -= 2;
            }
            else
            {
                p.enemyspellpower -= 2;
            }
        }
    }
}
