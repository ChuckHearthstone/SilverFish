using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Sandstorm Elemental
    /// 沙暴元素
    /// </summary>
    public class Sim_ULD_158 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Deal 1 damage to all enemy minions. Overload: (1)
        /// 战吼：对所有敌方随从造成1点伤害。过载：（1）
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.allMinionOfASideGetDamage(!own.own, 1);
            if (own.own) p.ueberladung++;
        }
    }
}