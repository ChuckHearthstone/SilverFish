using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Garden Gnome
    /// 园艺侏儒 
    /// </summary>
    public class Sim_ULD_137 : SimTemplate
    {
        /// <summary>
        /// Battlecry: If you're holding a spell that costs (5) or more, summon two 2/2 Treants.
        /// 战吼：如果你的手牌中有法力值消耗大于或等于（5）的法术牌，便召唤两个2/2的树人。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.ULD_137t);

            if (own.own)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.cost >= 5 && hc.card.type == CardType.SPELL)
                    {
                        p.CallKid(kid, own.zonepos, own.own, false);
                        p.CallKid(kid, own.zonepos - 1, own.own);
                    }
                }
            }
        }
    }
}