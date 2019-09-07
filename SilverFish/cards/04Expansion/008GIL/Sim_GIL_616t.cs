using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Splitting Sapling
    /// 分裂树苗
    /// </summary>
    public class Sim_GIL_616t : SimTemplate
    {
        /// <summary>
        /// Deathrattle: Summon two 1/1 Woodchips.
        /// 亡语：召唤两个1/1的树枝。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            var card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.GIL_616t2);
            p.CallKid(card, m.zonepos - 1, m.own, true, true);
            p.CallKid(card, m.zonepos - 1, m.own, true, true);
        }
    }
}
