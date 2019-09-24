namespace Chuck.SilverFish.cards._01Basic._05Priest
{
    /// <summary>
    /// Radiance
    /// 圣光闪耀
    /// </summary>
    class Sim_EX1_192 : SimTemplate
    {

        /// <summary>
        /// Restore 5 Health to your hero.
        /// 为你的英雄恢复5点生命值。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int heal = 5;
            if (ownplay)
            {
                target = p.ownHero;
                if (p.anzOwnAuchenaiSoulpriest > 0 || p.embracetheshadow > 0)
                {
                    heal = -heal;
                }

                if (p.doublepriest >= 1)
                {
                    heal *= (2 * p.doublepriest);
                }
            }
            else
            {
                target = p.enemyHero;
                if (p.anzEnemyAuchenaiSoulpriest >= 1)
                {
                    heal = -heal;
                }

                if (p.enemydoublepriest >= 1)
                {
                    heal *= (2 * p.enemydoublepriest);
                }
            }
            p.minionGetDamageOrHeal(target, -heal);
        }
    }
}
