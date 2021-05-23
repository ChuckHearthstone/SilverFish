using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._009BOT
{
    /// <summary>
    /// Omega Assembly
    /// 欧米茄装配
    /// </summary>
    public class Sim_BOT_299 : SimTemplate
    {
        /// <summary>
        /// Discover a Mech. If you have 10 Mana Crystals, keep all 3 cards.
        /// 发现一张机械牌。如果你有十个法力水晶，保留全部三张牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardName.unknown, ownplay, true);

            if (ownplay && p.ownMaxMana == 10)
            {
                p.drawACard(CardName.unknown, ownplay, true);
                p.drawACard(CardName.unknown, ownplay, true);
                p.drawACard(CardName.unknown, ownplay, true);
            }

            if (ownplay && !p.enemyMaxMana == 10)
            {
                p.drawACard(CardName.unknown, ownplay, true);
            }
        }
    }
}
