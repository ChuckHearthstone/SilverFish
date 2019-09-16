using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Overflow
    /// 溢流
    /// </summary>
    public class Sim_ULD_273 : SimTemplate
    {
        /// <summary>
        /// Restore 5 Health to all characters. Draw 5 cards.
        /// 为所有角色恢复5点生命值。抽五张牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int heal = 5;
            foreach (Minion m in p.ownMinions)
            {
                p.minionGetDamageOrHeal(m, -heal);
            }
            foreach (Minion m in p.enemyMinions)
            {
                p.minionGetDamageOrHeal(m, -heal);
            }
            p.minionGetDamageOrHeal(p.enemyHero, -heal);
            p.minionGetDamageOrHeal(p.ownHero, -heal);

            for (int i = 0; i < 5; i++)
            {
                p.drawACard(CardName.unknown, ownplay);
            }
        }
    }
}