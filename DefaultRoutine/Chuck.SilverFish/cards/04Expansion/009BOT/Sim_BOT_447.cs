namespace Chuck.SilverFish.cards._04Expansion._009BOT
{
    /// <summary>
    /// Crystallizer
    /// 晶化师
    /// </summary>
    public class Sim_BOT_447 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Deal 5 damage to your hero. Gain 5 Armor.
        /// 战吼：对你的英雄造成5点伤害。获得5点护甲值。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            Minion targetHero = own.own ? p.ownHero : p.enemyHero;
            p.minionGetDamageOrHeal(targetHero, 5);
            p.minionGetArmor(targetHero, 5);

        }
    }
}