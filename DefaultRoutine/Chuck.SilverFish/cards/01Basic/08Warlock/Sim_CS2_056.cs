using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._01Basic._08Warlock
{
    /// <summary>
    /// Life Tap
    /// 生命分流
    /// </summary>
	class Sim_CS2_056 : SimTemplate
	{
        /// <summary>
        /// Hero Power Draw a card and take 2 damage.
        /// 英雄技能 抽一张牌并受到2点伤害。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardName.unknown, ownplay);

            int dmg = 2;
            if (ownplay)
            {
                if (p.doublepriest >= 1)
                {
                    dmg *= (2 * p.doublepriest);
                }
                p.minionGetDamageOrHeal(p.ownHero, dmg);
            }
            else
            {
                if (p.enemydoublepriest >= 1)
                {
                    dmg *= (2 * p.enemydoublepriest);
                }
                p.minionGetDamageOrHeal(p.enemyHero, dmg);
            }
        }


	}
}