using Chuck.SilverFish;

namespace SilverFish.cards._01Basic
{
    /// <summary>
    /// Ironbeak Owl
    /// 铁喙猫头鹰
    /// </summary>
	public class Sim_CS2_203 : SimTemplate
	{
        /// <summary>
        /// Battlecry: Silence aminion.
        /// 战吼： 沉默一个随从。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null)
            {
                p.minionGetSilenced(target);
            }
		}
	}
}