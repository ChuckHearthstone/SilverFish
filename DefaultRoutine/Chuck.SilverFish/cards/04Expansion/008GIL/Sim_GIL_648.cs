using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Chief Inspector
    /// 总督察
    /// </summary>
    public class Sim_GIL_648 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Destroy all enemy Secrets.
        /// 战吼：摧毁所有敌方奥秘。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own) p.enemySecretList.Clear();
            else p.ownSecretsIDList.Clear();
        }
    }
}
