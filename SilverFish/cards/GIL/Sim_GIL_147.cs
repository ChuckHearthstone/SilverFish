namespace HREngine.Bots
{
    /// <summary>
    /// Cinderstorm
    /// 燃烬风暴
    /// </summary>
    public class Sim_GIL_147 : SimTemplate
    {
        /// <summary>
        /// "LocStringEnUs": "Deal $5 damage randomly split among all enemies.",
        /// "LocStringZhCn": "造成$5点伤害，随机分配到所有敌人身上。",
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int times = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            p.allCharsOfASideGetRandomDamage(!ownplay, times);
        }
    }
}