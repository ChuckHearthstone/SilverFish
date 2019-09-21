using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._011DAL
{
    /// <summary>
    /// Marked Shot
    /// 标记射击
    /// </summary>
    public class Sim_DAL_371 : SimTemplate
    {
        /// <summary>
        /// Deal 4 damage to a minion. Discover a spell.
        /// 对一个随从造成4点伤害。发现一张法术牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            p.minionGetDamageOrHeal(target, dmg);
            p.drawACard(CardName.unknown, ownplay, true);
        }
    }
}