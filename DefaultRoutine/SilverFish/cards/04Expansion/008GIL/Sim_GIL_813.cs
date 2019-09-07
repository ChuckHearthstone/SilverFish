using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Vivid Nightmare
    /// 鲜活梦魇
    /// </summary>
    public class Sim_GIL_813 : SimTemplate
    {
        /// <summary>
        /// Choose a friendly minion. Summon a copy of it with 1 Health remaining.
        /// 选择一个友方随从，召唤一个该随从的复制，且剩余生命值为1点。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = p.ownMinions.Count;
            if (pos < 7)
            {
                p.CallKid(target.handcard.card, pos, ownplay);
                p.ownMinions[pos].setMinionToMinion(target);
                target.HealthPoints = 1;
            }
        }
    }
}
