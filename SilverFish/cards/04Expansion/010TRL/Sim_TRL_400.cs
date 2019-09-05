using HREngine.Bots;

namespace SilverFish.cards._04Expansion._010TRL
{
    /// <summary>
    /// Splitting Image
    /// 裂魂残像
    /// </summary>
    public class Sim_TRL_400 : SimTemplate
    {
        /// <summary>
        /// Secret: When one of your minions is attacked, summon a copy of it.
        /// 奥秘：当你的随从受到攻击时，召唤一个该随从的复制。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="number"></param>
        public override void onSecretPlay(Playfield p, bool ownplay, Minion target, int number)
        {
            int pos = target.zonepos;
            p.CallKid(target.handcard.card, pos + 1, ownplay);
            p.ownMinions[pos + 1].setMinionToMinion(target);
        }
    }
}
