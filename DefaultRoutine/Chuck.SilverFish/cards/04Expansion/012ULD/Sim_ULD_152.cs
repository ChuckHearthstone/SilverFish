using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Pressure Plate
    /// 压感陷阱
    /// </summary>
    public class Sim_ULD_152 : SimTemplate
    {
        /// <summary>
        /// Secret: After your opponent casts a spell, destroy a random enemy minion.
        /// 奥秘：在你的对手施放一个法术后，随机消灭一个敌方随从。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="number"></param>
        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            Minion m = p.searchRandomMinion(ownplay ? p.enemyMinions : p.ownMinions, searchmode.searchLowestHP);
            if (m != null) p.minionGetDestroyed(m);
        }
    }
}