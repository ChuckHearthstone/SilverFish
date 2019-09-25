namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Weaponized Wasp
    /// 武装胡蜂
    /// </summary>
    public class Sim_ULD_170 : SimTemplate
    {
        /// <summary>
        /// Battlecry: If you control a Lackey, deal 3 damage.
        /// 战吼：如果你控制一个跟班，造成3点伤害。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetDamageOrHeal(target, 3);
            }
        }
    }
}