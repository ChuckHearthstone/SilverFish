using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Zap!
    /// 静电震击
    /// </summary>
    public class Sim_GIL_600 : SimTemplate
    {
        /// <summary>
        /// Deal $2 damage to a minion. Overload: 1
        /// 对一个随从造成$2点伤害。过载：1
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
            if (ownplay) p.ueberladung++;
        }
    }
}