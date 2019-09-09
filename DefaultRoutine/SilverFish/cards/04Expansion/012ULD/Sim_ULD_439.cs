using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Sandwasp Queen
    /// 沙漠蜂后
    /// </summary>
    public class Sim_ULD_439 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Add two 2/1 Sandwasps to your hand.
        /// 战吼：将两张2/1的“沙漠胡蜂”置入你的手牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardIdEnum.ULD_439t, own.own, true); //沙漠胡蜂 Sandwasp
            p.drawACard(CardIdEnum.ULD_439t, own.own, true);
        }
    }
}