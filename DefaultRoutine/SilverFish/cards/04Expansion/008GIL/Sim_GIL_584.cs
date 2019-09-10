using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Witchwood Piper
    /// 女巫森林吹笛人
    /// </summary>
    public class Sim_GIL_584 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Draw the lowest Cost minion from your deck.
        /// 战吼：从你的牌库中抽一张法力值消耗最低的随从牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardName.unknown, own.own);
        }
    }
}
