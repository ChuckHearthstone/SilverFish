using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Splitting Festeroot
    /// 分裂腐树
    /// </summary>
    public class Sim_GIL_616 : SimTemplate
    {
        /// <summary>
        /// Deathrattle: Summon two 2/2 Splitting Saplings.
        /// 亡语：召唤两个2/2的分裂树苗。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            var card = CardDB.Instance.getCardDataFromID(CardIdEnum.GIL_616t);
            p.CallKid(card, m.zonepos - 1, m.own, true, true);
            p.CallKid(card, m.zonepos - 1, m.own, true, true);
        }
    }
}
