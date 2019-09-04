using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Lord Godfrey
    /// 高弗雷勋爵
    /// </summary>
    public class Sim_GIL_825 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Deal 2 damage to all other minions. If any die, repeat this Battlecry.
        /// 战吼：对所有其他随从造成2点伤害。如果有随从死亡，则重复此战吼效果。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int dmg = (own.own) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            int count = p.tempTrigger.ownMinionsDied + p.tempTrigger.enemyMinionsDied;
            int nextcount = 0;
            bool repeat;
            do
            {
                repeat = false;
                p.allMinionsGetDamage(dmg);
                nextcount = p.tempTrigger.ownMinionsDied + p.tempTrigger.enemyMinionsDied;
                if (nextcount > count) repeat = true;
                count = nextcount;
                if (count == (p.ownMinions.Count + p.enemyMinions.Count)) break;
            }
            while (repeat);
        }
    }
}
