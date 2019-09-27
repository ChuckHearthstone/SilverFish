using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._010TRL
{
    /// <summary>
    /// Halazzi, the Lynx
    /// 哈尔拉兹，山猫之神 
    /// </summary>
    public class Sim_TRL_900 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Fill your hand with 1/1 Lynxes that have Rush.
        /// 战吼：将1/1并具有突袭的山猫置入你的手牌，直到你的手牌数量达到上限。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int hc = 10 - p.ownMinions.Count;
            
            for (int i = 0; i < hc; i++)
            {
                p.drawACard(CardIdEnum.TRL_348t, own.own, true);
            }
        }
    }
}