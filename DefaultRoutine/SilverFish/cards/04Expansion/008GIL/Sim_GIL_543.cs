using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Dark Possession
    /// 黑暗附体
    /// </summary>
    public class Sim_GIL_543 : SimTemplate
    {
        /// <summary>
        /// Deal 2 damage to a friendly character. Discover a Demon.
        /// 对一个友方角色造成2点伤害。发现一张恶魔牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
            p.drawACard(CardName.unknown, ownplay, true);
        }
    }
}
