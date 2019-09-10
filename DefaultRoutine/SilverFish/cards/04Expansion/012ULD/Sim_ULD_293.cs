using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Cloud Prince
    /// 云雾王子
    /// </summary>
    public class Sim_ULD_293 : SimTemplate
    {
        /// <summary>
        /// Battlecry: If you control a Secret, deal 6 damage.
        /// 战吼： 如果你控制一个奥秘，则造成6点伤害。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var damage = 6;
            if (p.ownSecretsIDList.Count >= 1)
            {
                p.minionGetDamageOrHeal(target, damage);
            }
        }
    }
}
