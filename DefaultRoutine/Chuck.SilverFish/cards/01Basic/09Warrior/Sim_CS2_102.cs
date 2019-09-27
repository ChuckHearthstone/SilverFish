using Chuck.SilverFish;

namespace SilverFish.cards._01Basic._09Warrior
{
    /// <summary>
    /// Armor Up!
    /// 全副武装！
    /// </summary>
	class Sim_CS2_102 : SimTemplate
	{
        /// <summary>
        /// Hero Power Gain 2 Armor.
        /// 英雄技能 获得2点护甲值。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                p.minionGetArmor(p.ownHero, 2);
            }
            else
            {
                p.minionGetArmor(p.enemyHero, 2);
            }
		}

	}
}