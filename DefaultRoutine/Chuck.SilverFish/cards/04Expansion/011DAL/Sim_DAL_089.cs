using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._011DAL
{
    /// <summary>
    ///  Spellbook Binder
    /// 魔法订书匠
    /// </summary>
    public class Sim_DAL_089 : SimTemplate
    {
        /// <summary>
        /// Battlecry: If you have Spell Damage, draw a card.
        /// 战吼：如果你拥有法术伤害，抽一张牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own && p.spellpower > 0)
            {
                p.drawACard(CardName.unknown, own.own);
            }
            if (!own.own && p.enemyspellpower > 0)
            {
                p.drawACard(CardName.unknown, own.own);
            }
        }
    }
}