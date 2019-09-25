using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._009BOT
{
    /// <summary>
    /// Giggling Inventor 
    /// 欢乐的发明家
    /// </summary>
    public class Sim_BOT_270 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Summon two 1/2 Mechs with Taunt and Divine Shield.
        /// 战吼：召唤两个1/2并具有嘲讽和圣盾的机械。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.BOT_270t);
            p.CallKid(kid, own.zonepos - 1, own.own);
            p.CallKid(kid, own.zonepos + 1, own.own);
        }
    }
}