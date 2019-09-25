using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._009BOT
{
    /// <summary>
    /// SN1P-SN4P
    /// 大铡蟹
    /// </summary>
    public class Sim_BOT_700 : SimTemplate
    {
        /// <summary>
        /// Magnetic, Echo Deathrattle: Summon two 1/1 Microbots.
        /// 磁力，回响，亡语：召唤两个1/1的微型机器人。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.BOT_312t);
            p.CallKid(kid, m.zonepos, m.own);
            p.CallKid(kid, m.zonepos + 1, m.own);
        }
    }
}