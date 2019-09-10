using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Ancient Mysteries
    /// 远古谜团
    /// </summary>
    public class Sim_ULD_726 : SimTemplate
    {
        /// <summary>
        /// Draw a Secret from your deck. It costs 0.
        /// 从你的牌库中抽一张奥秘牌。其法力值消耗为0点。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                var deck = p.prozis.turnDeck;
                foreach (var item in deck)
                {
                    var card = CardDB.Instance.getCardDataFromID(item.Key);
                    if (card.Secret)
                    {
                        p.drawACard(card.name, ownplay);
                        p.owncards[p.owncards.Count - 1].manacost = 0;
                        break;
                    }
                }
            }
            else
            {
                p.drawACard(CardName.unknown, ownplay);
            }
        }
    }
}
