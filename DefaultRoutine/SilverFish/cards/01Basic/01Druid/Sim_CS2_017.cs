using HREngine.Bots;

namespace SilverFish.cards._01Basic._01Druid
{
    /// <summary>
    /// Shapeshift
    /// 变形
    /// </summary>
	public class Sim_CS2_017 : SimTemplate
	{
        /// <summary>
        /// Hero Power +1 Attack this turn. +1 Armor.
        /// 英雄技能 本回合+1攻击力。  +1护甲值。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var hero = ownplay ? p.ownHero : p.enemyHero;
            p.minionGetTempBuff(hero, 1, 0);
            p.minionGetArmor(hero, 1);
        }
    }
}