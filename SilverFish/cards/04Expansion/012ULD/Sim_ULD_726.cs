using HREngine.Bots;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Ancient Mysteries
    /// 远古谜团
    /// </summary>
    public class Sim_ULD_726 : SimTemplate
    {
        /// <summary>
        /// Draw a Secret from your deck. It costs 0.
        /// 从你的牌库中抽一张奥秘牌。其法力值消耗为0点。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.unknown, ownplay);
        }
    }
}
