using Chuck.SilverFish;
using SilverFish.Enums;


namespace Chuck.SilverFish {
    /// <summary>
    /// Ethereal Lackey
    /// 虚灵跟班
    /// </summary>
    public class Sim_DAL_741 : SimTemplate {
        /// <summary>
        /// Battlecry: Discover a spell.
        /// 战吼：发现一张法术牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect (Playfield p, Minion own, Minion target, int choice) {
            p.drawACard (CardName.unknown, own.own, true);
        }
    }
}