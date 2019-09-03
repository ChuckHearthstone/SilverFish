using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Bewitched Guardian
    /// 失魂的守卫
    /// </summary>
    public class Sim_GIL_507 : SimTemplate
    {
        /// <summary>
        /// Taunt Battlecry: Gain +1 Health  for each card in your hand.
        /// 嘲讽，战吼： 你每有一张手牌，便获得+1生命值。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

            p.minionGetBuffed(own, 0, (own.own) ? p.owncards.Count : p.enemyAnzCards);
        }
    }
}
