using System.Collections.Generic;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Emperor Wraps
    /// 帝王裹布
    /// </summary>
    public class Sim_ULD_431p : SimTemplate
    {
        /// <summary>
        /// Hero Power Summon a 2/2 copy of a friendly minion.
        /// 英雄技能 召唤一个友方随从的2/2的复制。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            int pos = temp.Count;
            if (pos < 7)
            {
                p.CallKid(target.handcard.card, pos, ownplay);
                temp[pos].setMinionToMinion(target);
                p.minionSetAngrToX(target, 2);
                p.minionSetLifetoX(target, 2);
            }
        }
    }
}