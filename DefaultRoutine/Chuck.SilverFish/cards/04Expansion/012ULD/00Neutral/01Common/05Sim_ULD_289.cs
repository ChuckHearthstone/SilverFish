using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._012ULD._00Neutral._01Common
{
    /// <summary>
    /// Fishflinger
    /// 鱼人投手
    /// </summary>
    public class Sim_ULD_289 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Add a random Murloc to each player's hand.
        /// 战吼：将一张随机鱼人牌分别置入每个玩家的手牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardName.unknown, own.own, true);
            p.drawACard(CardName.unknown, !own.own, true);
        }
    }
}