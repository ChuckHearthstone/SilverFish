using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Witchwood Apple
    /// 女巫森林苹果
    /// </summary>
    public class Sim_GIL_663 : SimTemplate
    {
        /// <summary>
        /// Add three 2/2 Treants to your hand.
        /// 将三个2/2的树人置入你的 手牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardIdEnum.GIL_663t, ownplay, true);
            p.drawACard(CardIdEnum.GIL_663t, ownplay, true);
            p.drawACard(CardIdEnum.GIL_663t, ownplay, true);
        }
    }
}
