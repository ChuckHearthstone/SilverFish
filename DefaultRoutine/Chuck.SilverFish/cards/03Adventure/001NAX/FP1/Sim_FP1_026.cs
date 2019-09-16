using System.Collections.Generic;
using Chuck.SilverFish;

namespace SilverFish.cards._03Adventure._001NAX.FP1
{
    /// <summary>
    /// Anub'ar Ambusher
    /// 阿努巴尔伏击者
    /// </summary>
	class Sim_FP1_026 : SimTemplate //anubarambusher
	{
        /// <summary>
        /// Deathrattle: Return a random friendly minion to your hand.
        /// 亡语： 随机将一个友方随从移回你的手牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            List<Minion> temp = new List<Minion>();

            if (m.own)
            {
                List<Minion> temp2 = new List<Minion>(p.ownMinions);
                temp2.Sort((a, b) => -a.Attack.CompareTo(b.Attack));
                temp.AddRange(temp2);
            }
            else
            {
                List<Minion> temp2 = new List<Minion>(p.enemyMinions);
                temp2.Sort((a, b) => a.Attack.CompareTo(b.Attack));
                temp.AddRange(temp2);
            }

            if (temp.Count >= 1)
            {
                if (m.own)
                {
                    var target = temp[0];
                    if (temp.Count >= 2 && !target.taunt && temp[1].taunt) target = temp[1];
                    p.minionReturnToHand(target, m.own, 0);
                }
                else
                {
                    var target = temp[0];
                    if (temp.Count >= 2 && target.taunt && !temp[1].taunt) target = temp[1];
                    p.minionReturnToHand(target, m.own, 0);
                }
            }
        }

	}
}