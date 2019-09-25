namespace Chuck.SilverFish.cards._04Expansion._010TRL
{
    /// <summary>
    /// Dragonmaw Scorcher
    /// 龙喉喷火者
    /// </summary>
    public class Sim_TRL_526 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Deal 1 damage to all other minions.
        /// 战吼：对所有其他随从造成1点伤害
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.allMinionsGetDamage(1, own.entitiyID);
        }
    }
}