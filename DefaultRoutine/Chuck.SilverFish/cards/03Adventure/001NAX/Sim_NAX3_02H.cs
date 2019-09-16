using System.Collections.Generic;
using Chuck.SilverFish;

namespace SilverFish.cards._03Adventure._001NAX
{
    /// <summary>
    /// Web Wrap
    /// 裹体之网
    /// </summary>
	class Sim_NAX3_02H : SimTemplate //* Web Wrap
	{
        /// <summary>
        /// Hero Power Return 2 random enemy minions to your opponent's hand.
        /// 英雄技能 随机将两个敌方随从移回对手的 手牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? new List<Minion>(p.enemyMinions) : new List<Minion>(p.ownMinions);
			
			if (temp.Count > 0)
			{
				if (ownplay) temp.Sort((a, b) => b.Attack.CompareTo(a.Attack));
				else temp.Sort((a, b) => a.Attack.CompareTo(b.Attack));
				
                target = temp[0];
				if (temp.Count > 1)
                {
                    var target2 = temp[1];
                    p.minionReturnToHand(target2, !ownplay, 0);
                }
                p.minionReturnToHand(target, !ownplay, 0);
			}
        }
	}
}