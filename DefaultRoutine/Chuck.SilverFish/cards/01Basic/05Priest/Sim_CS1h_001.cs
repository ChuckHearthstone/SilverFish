using Chuck.SilverFish;

namespace SilverFish.cards._01Basic._05Priest
{
    /// <summary>
    /// Lesser Heal
    /// 次级治疗术
    /// </summary>
	class Sim_CS1h_001 : SimTemplate
	{
        /// <summary>
        /// Hero Power Restore 2 Health.
        /// 英雄技能 恢复2点生命值。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int heal = 2;
            if (ownplay)
            {
                if (p.anzOwnAuchenaiSoulpriest > 0 || p.embracetheshadow > 0) heal = -heal;
                if (p.doublepriest >= 1) heal *= (2 * p.doublepriest);
            }
            else
            {
                if (p.anzEnemyAuchenaiSoulpriest >= 1) heal = -heal;
                if (p.enemydoublepriest >= 1) heal *= (2 * p.enemydoublepriest);
            }
            p.minionGetDamageOrHeal(target, -heal);
		}
	}
}