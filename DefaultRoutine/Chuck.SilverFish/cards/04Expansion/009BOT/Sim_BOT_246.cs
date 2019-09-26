namespace Chuck.SilverFish.cards._04Expansion._009BOT
{
    /// <summary>
    /// Beakered Lightning
    /// 瓶装闪电
    /// </summary>
    public class Sim_BOT_246 : SimTemplate
    {
        /// <summary>
        /// Deal 1 damage to all minions. Overload: (2)
        /// 对所有随从造成1点伤害。过载：（2）
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.allMinionsGetDamage(dmg);
            if (ownplay) p.ueberladung += 2;
        }
    }
}