using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Witch's Apprentice
    /// 女巫的学徒
    /// </summary>
    public class Sim_GIL_531 : SimTemplate
    {
        /// <summary>
        /// Taunt Battlecry: Add a random Shaman spell to your hand.
        /// 嘲讽，战吼：随机将一张萨满祭司法术牌置入你的手牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.unknown, own.own, true);
        }
    }
}