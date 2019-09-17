using System.Collections.Generic;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Ramkahen Roar
    /// 拉穆卡恒的咆哮
    /// </summary>
    public class Sim_ULD_155p : SimTemplate
    {
        /// <summary>
        /// Hero Power Give your minions +2 Attack.
        /// 英雄技能 使你的所有随从获得+2攻击力。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                p.minionGetBuffed(m, 2, 0);
            }
        }
    }
}