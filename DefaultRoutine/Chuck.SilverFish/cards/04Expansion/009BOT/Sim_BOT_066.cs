using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._009BOT
{
    /// <summary>
    /// Mechanical Whelp
    /// 机械雏龙
    /// </summary>
    public class Sim_BOT_066 : SimTemplate
    {
        /// <summary>
        /// Deathrattle: Summon a 7/7 Mechanical Dragon.
        /// 亡语：召唤一个7/7的机械巨龙。   
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.BOT_066t);
            p.CallKid(kid, m.zonepos, m.own);
            p.CallKid(kid, m.zonepos + 1, m.own);
        }
    }
}