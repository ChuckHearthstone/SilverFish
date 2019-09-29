using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._012ULD._00Neutral._01Common
{
    /// <summary>
    /// Bug Collector
    /// 昆虫收藏家
    /// /// </summary>
    public class Sim_ULD_712 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Summon a 1/1 Locust with Rush.
        /// 战吼：召唤一只1/1并具有突袭的蝗虫。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.ULD_430t);

            p.CallKid(kid, own.zonepos, own.own);
        }
    }
}