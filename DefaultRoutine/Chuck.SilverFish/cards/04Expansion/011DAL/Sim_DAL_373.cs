namespace Chuck.SilverFish.cards._04Expansion._011DAL
{
    /// <summary>
    /// Rapid Fire
    /// 急速射击
    /// </summary>
    public class Sim_DAL_373 : TwinSpell
    {
        /// <summary>
        /// Twinspell Deal 1 damage.
        /// 双生法术 造成1点伤害。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.minionGetDamageOrHeal(target, dmg);

            TriggerTwinSpell(p, ownplay);
        }
    }
    
    public class Sim_DAL_373ts : Sim_DAL_373
    {

    }
}