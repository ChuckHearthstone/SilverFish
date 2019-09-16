using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Desert Hare
    /// 沙漠野兔
    /// </summary>
    public class Sim_ULD_719 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Summon two 1/1 Desert Hares.
        /// 战吼：召唤两只1/1的沙漠野兔。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            CardDB.Card Hare = CardDB.Instance.getCardDataFromID(CardIdEnum.ULD_719);
            p.CallKid(Hare, own.zonepos - 1, own.own);
            p.CallKid(Hare, own.zonepos, own.own);
        }
    }
}