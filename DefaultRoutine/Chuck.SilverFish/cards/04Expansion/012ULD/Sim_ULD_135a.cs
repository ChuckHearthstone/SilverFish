using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Befriend the Ancient
    /// 结识古树
    /// </summary>
    public class Sim_ULD_135a : SimTemplate
    {
        /// <summary>
        /// Summon a 6/6 Ancient with Taunt.
        /// 召唤一棵6/6并具有嘲讽的古树。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            CardDB.Card ancient = CardDB.Instance.getCardDataFromID(CardIdEnum.ULD_135at);
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(ancient, pos, ownplay, false);
        }
    }
}