using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._010TRL
{
    /// <summary>
    /// Flash of Light
    /// 圣光闪现 
    /// </summary>
    public class Sim_TRL_307 : SimTemplate
    {
        /// <summary>
        /// Restore 4 Health. Draw a card. 
        /// 恢复4点生命值。抽一张牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int heal = (ownplay) ? p.getSpellHeal(4) : p.getEnemySpellHeal(4);
            p.minionGetDamageOrHeal(target, -heal);
            p.drawACard(CardName.unknown, ownplay);
        }
    }
}