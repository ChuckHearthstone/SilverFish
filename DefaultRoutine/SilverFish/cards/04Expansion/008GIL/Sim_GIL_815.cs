using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Baleful Banker
    /// 恶毒的银行家
    /// </summary>
    public class Sim_GIL_815 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Choose a friendly minion. Shuffle a copy into your deck.
        /// 战吼：选择一个友方随从，将一个复制洗入你的牌库。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null)
            {
                if (m.own) p.ownDeckSize++;
                else p.enemyDeckSize++;
            }
        }
    }
}
