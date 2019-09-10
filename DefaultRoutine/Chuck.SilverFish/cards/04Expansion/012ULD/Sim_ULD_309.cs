using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Dwarven Archaeologist
    /// 矮人考古学家
    /// </summary>
    public class Sim_ULD_309 : SimTemplate
    {
        /// <summary>
        /// After you Discover a card, reduce its cost by (1).
        /// 在你发现一张卡牌后，使其法力值消耗降低（1）点。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardName.unknown, own.own, true);
            p.owncards[p.owncards.Count - 1].manacost -= 1;
        }
    }
}
