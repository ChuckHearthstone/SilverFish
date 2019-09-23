using Chuck.SilverFish;

namespace SilverFish.cards._01Basic._03Mage
{
    /// <summary>
    /// Fireblast
    /// 火焰冲击
    /// </summary>
	class Sim_CS2_034 : SimTemplate
    {
        protected virtual int Damage { get; set; } = 1;

        /// <summary>
        /// Hero Power Deal 1 damage.
        /// 英雄技能 造成1点伤害。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int damage = (ownplay) ? p.getHeroPowerDamage(Damage) : p.getEnemyHeroPowerDamage(Damage);
            p.minionGetDamageOrHeal(target, damage);
        }
	}

    class Sim_CS2_034_H1 : Sim_CS2_034
    {

    }

    class Sim_CS2_034_H2 : Sim_CS2_034
    {

    }

    /// <summary>
    /// Fireblast Rank 2
    /// 二级火焰冲击
    /// </summary>
    class Sim_CS2_034_H1_AT_132 : Sim_CS2_034
    {
        /// <summary>
        /// Hero Power Deal 2 damage.
        /// 英雄技能 造成2点伤害。
        /// </summary>
        protected override int Damage { get; set; } = 2;

    }

    class Sim_CS2_034_H2_AT_132 : Sim_CS2_034_H1_AT_132
    {

    }
}