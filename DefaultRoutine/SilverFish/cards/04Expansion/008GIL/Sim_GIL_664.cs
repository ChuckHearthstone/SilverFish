using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Vex Crow
    /// 三眼乌鸦
    /// </summary>
    public class Sim_GIL_664 : SimTemplate
    {
        /// <summary>
        /// Whenever you cast a spell, summon a random 2-Cost minion.
        /// 每当你施放一个法术，随机召唤一个法力值消耗为2的 随从。
        /// </summary>
        /// </summary>
        /// <param name="p"></param>
        /// <param name="hc"></param>
        /// <param name="wasOwnCard"></param>
        /// <param name="triggerEffectMinion"></param>
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard)
            {
                if (hc.card.type == CardType.SPELL)
                {
                    int pos = (wasOwnCard) ? p.ownMinions.Count : p.enemyMinions.Count;
                    p.CallKid(p.getRandomCardForManaMinion(2), pos, wasOwnCard);
                }
            }
        }
    }
}
