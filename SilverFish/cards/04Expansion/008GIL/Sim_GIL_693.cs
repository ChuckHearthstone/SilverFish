using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Blood Witch
    /// 鲜血女巫
    /// </summary>
    public class Sim_GIL_693 : SimTemplate
    {
        /// <summary>
        /// "LocStringEnUs": "At the start of your turn, deal 1 damage to your hero.",
        /// "LocStringZhCn": "在你的回合开始时，对你的英雄造成 1点伤害。",
        /// </summary>
        /// <param name="p"></param>
        /// <param name="triggerEffectMinion"></param>
        /// <param name="turnStartOfOwner"></param>
        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                p.minionGetDamageOrHeal(own.own ? p.ownHero : p.enemyHero, 1);
            }
        }
    }
}
