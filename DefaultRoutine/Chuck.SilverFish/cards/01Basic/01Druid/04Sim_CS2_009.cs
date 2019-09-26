using Chuck.SilverFish;

namespace SilverFish.cards._01Basic._01Druid
{
    /// <summary>
    /// Mark of the Wild
    /// 野性印记
    /// </summary>
    class Sim_CS2_009 : SimTemplate
    {
        /// <summary>
        /// +2/+2 and Taunt.
        /// +2/+2并具有嘲讽。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 2, 2);
            if (!target.taunt)
            {
                target.taunt = true;
                if (target.own) p.anzOwnTaunt++;
                else p.anzEnemyTaunt++;
            }
        }
    }
}
