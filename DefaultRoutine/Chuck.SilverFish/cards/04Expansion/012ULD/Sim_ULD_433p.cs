using SilverFish.Enums;
using System;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Ascendant Scroll
    /// 升格卷轴 
    /// </summary>
    public class Sim_ULD_433p : SimTemplate
    {
        /// <summary>
        /// Hero Power Add a random Mage spell to your hand. It costs 2 less.
        /// 英雄技能 随机将一张法师法术牌置入你的手牌。该牌的法力值消耗减少2点。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardName.unknown, ownplay, true);
            p.owncards[p.owncards.Count - 1].manacost = Math.Max(p.owncards[p.owncards.Count - 1].manacost -= 2, 0);
        }
    }
}