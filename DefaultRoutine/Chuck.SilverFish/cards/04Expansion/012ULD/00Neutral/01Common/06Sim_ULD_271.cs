namespace Chuck.SilverFish.cards._04Expansion._012ULD._00Neutral._01Common
{
    /// <summary>
    /// Injured Tol'vir
    /// 受伤的托维尔人
    /// </summary>
    public class Sim_ULD_271 : SimTemplate
    {
        /// <summary>
        /// Taunt Battlecry: Deal 3 damage to this minion.
        /// 嘲讽，战吼：对该随从造成3点伤害。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.minionGetDamageOrHeal(own, 3);
        }
    }
}