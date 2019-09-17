using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Dinotamer Brann
    /// 恐龙大师布莱恩
    /// </summary>
    public class Sim_ULD_156 : SimTemplate
    {
        /// <summary>
        /// Battlecry: If your deck has no duplicates, summon King Krush.
        /// 战吼：如果你的牌库里没有相同的牌，则召唤暴龙王克鲁什。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own && p.prozis.noDuplicates)
            {
                CardDB.Card krush = CardDB.Instance.getCardDataFromID(CardIdEnum.ULD_156t3);
                p.CallKid(krush, own.zonepos, own.own);
            }
        }
    }
}