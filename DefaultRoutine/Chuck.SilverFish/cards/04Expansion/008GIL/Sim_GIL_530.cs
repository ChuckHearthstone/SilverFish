using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Murkspark Eel
    /// 阴燃电鳗
    /// </summary>
    public class Sim_GIL_530 : SimTemplate
    {
        /// <summary>
        /// Battlecry: If your deck has only even-Cost cards, deal 2 damage.
        /// 战吼： 如果你的牌库中只有法力值消耗为偶数的牌，造成2点伤害。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                int damage = 2;
                p.minionGetDamageOrHeal(target, damage);
                if (p.enemyMinions.Count == 0 && !p.isLethalCheck)
                {
                    p.evaluatePenality += 20;
                }
            }
        }
    }
}