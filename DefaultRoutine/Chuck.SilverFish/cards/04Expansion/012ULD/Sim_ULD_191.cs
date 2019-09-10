using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Beaming Sidekick
    /// 欢快的同伴
    /// </summary>
    public class Sim_ULD_191 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Give a friendly minion +2 Health.
        /// 战吼：使一个友方随从获得+2生命值。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null) p.minionGetBuffed(target, 0, 2);
        }
    }
}
