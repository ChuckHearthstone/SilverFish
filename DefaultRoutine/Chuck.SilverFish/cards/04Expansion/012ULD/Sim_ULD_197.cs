using System.Collections.Generic;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Quicksand Elemental
    /// 流沙元素
    /// </summary>
    public class Sim_ULD_197 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Give all enemy minions -2 Attack this turn.
        /// 战吼：在本回合中，使所有敌方随从获得-2攻击力。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.enemyMinions : p.ownMinions;
            foreach (Minion m in temp)
            {
                p.minionGetTempBuff(m, -2, 0);
            }
        }
    }
}