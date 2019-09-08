using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Splintergraft
    /// 碎枝
    /// </summary>
    public class Sim_GIL_658 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Choose a friendly minion. Add a 10/10 copy to your hand that costs 10.
        /// 战吼：选择一个友方随从。将它的一张10/10复制置入你的手牌，其法力值消耗为10点。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null)
            {
                if (m.own)
                {
                    p.drawACard(target.handcard.card.name, m.own, true);
                    int i = p.owncards.Count - 1;
                    p.owncards[i].addattack = 10 - p.owncards[i].card.Attack;
                    p.owncards[i].addHp = 10 - p.owncards[i].card.Health;
                    p.owncards[i].manacost = 10;
                }
            }
        }
    }
}
