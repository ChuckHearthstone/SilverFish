namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Kobold Sandtrooper
    /// 狗头人沙漠步兵
    /// </summary>
    public class Sim_ULD_184 : SimTemplate
    {
        /// <summary>
        /// Deathrattle: Deal 3 damage to the enemy hero.
        /// 亡语：对敌方英雄造成3点伤害。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.minionGetDamageOrHeal(m.own ? p.enemyHero : p.ownHero, 3);
        }
    }
}