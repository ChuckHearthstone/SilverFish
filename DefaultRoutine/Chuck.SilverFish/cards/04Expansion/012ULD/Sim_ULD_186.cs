using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Pharaoh Cat
    /// 法老御猫
    /// </summary>
    public class Sim_ULD_186 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Add a random Reborn minion to your hand.
        /// 战吼：随机将一张复生随从牌置入你的手牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.drawACard(CardName.unknown, m.own, true);
        }
    }
}