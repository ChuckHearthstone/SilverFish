using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._009BOT
{
    /// <summary>
    /// Landscaping
    /// 植树造林
    /// </summary>
    public class Sim_BOT_420 : SimTemplate
    {
        /// <summary>
        /// Summon two 2/2 Treants.
        /// 召唤两个2/2的树人。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_158t);

            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, pos, ownplay);
            p.CallKid(kid, pos, ownplay);
        }
    }
}