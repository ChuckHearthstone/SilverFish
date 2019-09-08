using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Hagatha the Witch
    /// 女巫哈加莎
    /// </summary>
    public class Sim_GIL_504 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Deal 3 damage to all minions.
        /// 战吼：对所有随从造成3点伤害。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.setNewHeroPower(CardIdEnum.GIL_504h, ownplay); // 蛊惑(Bewitch)
            if (ownplay) p.ownHero.armor += 5;
            else p.enemyHero.armor += 5;
            int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.allMinionsGetDamage(dmg);
        }
    }
}
