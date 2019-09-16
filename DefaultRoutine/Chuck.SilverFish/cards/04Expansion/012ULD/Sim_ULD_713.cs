using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Swarm of Locusts
    /// 飞蝗虫群
    /// </summary>
    public class Sim_ULD_713 : SimTemplate
    {
        /// <summary>
        /// Summon seven 1/1 Locusts with Rush.
        /// 召唤七只1/1并具有突袭的蝗虫。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            CardDB.Card locust = CardDB.Instance.getCardDataFromID(CardIdEnum.ULD_430t);
            if (ownplay)
            {
                for (int i = 0; i < 7; i++)
                {
                    int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                    p.CallKid(locust, pos, ownplay);
                }
            }
        }
    }
}