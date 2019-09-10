using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Sound the Bells!
    /// 敲响警钟
    /// </summary>
    public class Sim_GIL_145 : SimTemplate
    {
        /// <summary>
        /// Echo Give a minion +1/+2.
        /// 回响 使一个随从获得+1/+2。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 1, 2);

        }
    }
}
