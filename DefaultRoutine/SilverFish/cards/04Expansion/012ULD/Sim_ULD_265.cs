using HREngine.Bots;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Embalming Ritual
    /// 防腐仪式 
    /// </summary>
    public class Sim_ULD_265 : SimTemplate
    {
        /// <summary>
        /// Give a minion Reborn.
        /// 使一个随从获得复生。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            target.Reborn = true;
        }
    }
}
