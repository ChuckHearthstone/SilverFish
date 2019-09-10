using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Militia Commander
    /// 民兵指挥官
    /// </summary>
    public class Sim_GIL_803 : SimTemplate
    {
        /// <summary>
        /// Rush Battlecry: Gain +3 Attack this turn.
        /// 突袭，战吼：在本回合获得+3攻击力。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.minionGetTempBuff(own, 3, 0);
        }
    }
}
