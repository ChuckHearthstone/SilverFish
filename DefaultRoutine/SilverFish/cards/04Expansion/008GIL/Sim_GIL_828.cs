using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Dire Frenzy
    /// 凶猛狂暴
    /// </summary>
    public class Sim_GIL_828 : SimTemplate
    {
        /// <summary>
        /// Give a Beast +3/+3. Shuffle 3 copies into your deck with +3/+3.
        /// 使一个野兽获得+3/+3。将它的三张复制洗入你的牌库，且这些复制都具有+3/+3。
        /// 未添加洗入牌库特效
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 3, 3);
        }
    }
}