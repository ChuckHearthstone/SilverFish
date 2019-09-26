using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._01Basic._00Neutral
{
    /// <summary>
    /// Wild Pyromancer
    /// 狂野炎术师
    /// </summary>
	class Sim_NEW1_020 : SimTemplate
	{
        /// <summary>
        /// After you cast a spell, deal 1 damage to ALL minions.
        /// 在你施放一个法术后，对所有随从造成1点伤害。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="hc"></param>
        /// <param name="ownplay"></param>
        /// <param name="m"></param>
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool ownplay, Minion m)
        {
            if (m.own == ownplay && hc.card.type == CardType.SPELL)
            {
                p.allMinionsGetDamage(1);
            }
        }
	}
}