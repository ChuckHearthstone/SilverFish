using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Swamp Dragon Egg
    /// 沼泽龙蛋
    /// </summary>
    public class Sim_GIL_816 : SimTemplate
    {
        /// <summary>
        /// Deathrattle: Add a random Dragon to your hand.
        /// 亡语：随机将一张龙牌置入你的手牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardName.faeriedragon, m.own, true);
        }
    }
}
