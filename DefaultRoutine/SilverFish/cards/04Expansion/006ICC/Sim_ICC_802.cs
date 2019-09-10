using System.Collections.Generic;
using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._006ICC
{
    /*先知维伦(Prophet Velen) will double the damage dealt with Spirit Lash
     then double the Health restored from the Lifesteal effect after the damage is dealt, 
     resulting in double damage and quadruple四倍 heal.*/

    /// <summary>
    /// https://hearthstone.gamepedia.com/Spirit_Lash
    /// Spirit Lash
    /// 灵魂鞭笞
    /// </summary>
    class Sim_ICC_802 : SimTemplate //* Spirit Lash
    {
        /// <summary>
        /// Lifesteal Deal 1 damage toall minions.
        /// 吸血 对所有随从造成 1点伤害。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            int heal = 0;
            List<Minion> tmp = ownplay ? p.enemyMinions : p.ownMinions;
            foreach (Minion m in tmp) heal += m.HealthPoints;
            p.allMinionOfASideGetDamage(!ownplay, dmg);
            foreach (Minion m in tmp) heal -= m.HealthPoints;
            p.applySpellLifesteal(heal, ownplay);
        }
    }
}
