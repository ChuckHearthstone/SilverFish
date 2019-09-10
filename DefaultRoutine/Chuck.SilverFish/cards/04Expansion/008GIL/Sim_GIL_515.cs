using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Ratcatcher
    /// 捕鼠人
    /// </summary>
    public class Sim_GIL_515 : SimTemplate
    {
        /// <summary>
        /// Rush Battlecry: Destroy a friendly minion and gain its Attack and Health.
        /// 突袭，战吼：消灭一个友方随从，并获得其攻击力和生命值。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                int atkBuff = target.Attack;
                int hpBuff = target.HealthPoints;
                p.minionGetDestroyed(target);
                p.minionGetBuffed(own, atkBuff, hpBuff);
            }
        }
    }
}
