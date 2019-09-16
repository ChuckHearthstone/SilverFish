using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Hunter's Pack
    /// 猎人工具包
    /// </summary>
    public class Sim_ULD_429 : SimTemplate
    {
        /// <summary>
        /// Add a random Hunter Beast, Secret, and weapon to your hand.
        /// 随机将一张猎人野兽牌，奥秘牌和武器牌分别置入你的手牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            for (int i = 0; i < 3; i++)
            {
                p.drawACard(CardName.unknown, ownplay, true);
            }
        }
    }
}