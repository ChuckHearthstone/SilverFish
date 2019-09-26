using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._004KAR
{
    /// <summary>
    /// Arcane Anomaly
    /// 奥术畸体
    /// </summary>
	class Sim_KAR_036 : SimTemplate
	{
        /// <summary>
        /// Whenever you cast a spell, give this minion +1 Health.
        /// 每当你施放一个法术，该随从便获得 +1生命值。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="hc"></param>
        /// <param name="wasOwnCard"></param>
        /// <param name="triggerEffectMinion"></param>
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard && hc.card.type == CardType.SPELL)
            {
				p.minionGetBuffed(triggerEffectMinion, 0, 1);
            }
        }
	}
}