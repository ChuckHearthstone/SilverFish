using HREngine.Bots;

namespace HREngine.Bots
{
    /// <summary>
    /// Divine Hymn
    /// 神圣赞美诗
    /// </summary>
    public class Sim_GIL_661 : SimTemplate
    {
        /// <summary>
        /// "LocStringEnUs": "Restore #6 Health to all friendly characters.",
        /// "LocStringZhCn": "为所有友方角色恢复#6点生命值。",
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int heal = (own.own) ? p.getMinionHeal(6) : p.getEnemyMinionHeal(6);
            p.allCharsOfASideGetDamage(own.own, -heal);
        }
    }
}