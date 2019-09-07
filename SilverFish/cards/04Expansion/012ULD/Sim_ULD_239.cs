using HREngine.Bots;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Flame Ward
    /// 火焰结界
    /// </summary>
    public class Sim_ULD_239 : SimTemplate
    {
        /// <summary>
        /// Secret: After a minion attacks your hero, deal 3 damage to all enemy minions.
        /// 奥秘：在一个随从攻击你的英雄后，对所有敌方随从造成3点伤害。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="number"></param>
        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            int damage = ownplay ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.allMinionOfASideGetDamage(!ownplay, damage);
        }

    }

}