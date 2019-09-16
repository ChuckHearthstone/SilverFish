namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Riftcleaver
    /// 裂隙屠夫 
    /// </summary>
    public class Sim_ULD_165 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Destroy a minion. Your hero takes damage equal to its Health.
        /// 战吼：消灭一个随从。你的英雄受到等同于该随从生命值的伤害。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetDamageOrHeal(own.own ? p.ownHero : p.enemyHero, target.HealthPoints);
                p.minionGetDestroyed(target);
            }
        }
    }
}