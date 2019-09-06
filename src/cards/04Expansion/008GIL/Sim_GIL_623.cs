using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Witchwood Grizzly
    /// 女巫森林灰熊
    /// </summary>
    public class Sim_GIL_623 : SimTemplate
    {
        /// <summary>
        /// Taunt Battlecry: Lose 1 Health for each card in your opponent's hand.
        /// 嘲讽，战吼： 你的对手每有一张手牌，该随从便失去1点生命值。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int debuffHP = (own.own) ? p.enemyAnzCards : p.owncards.Count;
            p.minionGetBuffed(own, 0, 0 - debuffHP);
        }
    }
}
