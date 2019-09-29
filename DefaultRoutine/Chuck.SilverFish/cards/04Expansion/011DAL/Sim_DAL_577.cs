namespace Chuck.SilverFish.cards._04Expansion._011DAL
{
    /// <summary>
    /// Ray of Frost
    /// 霜冻射线
    /// </summary>
    public class Sim_DAL_577 : TwinSpell
    {
        /// <summary>
        /// Twinspell Freeze a minion. If it's already Frozen, deal 2 damage to it.
        /// 双生法术 冻结一个随从。如果该随从已被冻结，则对其造成2点伤害。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int damage = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            if (target.frozen)
            {
                p.minionGetDamageOrHeal(target, damage);
            }
            else
            {
                p.minionGetFrozen(target);
            }

            TriggerTwinSpell(p, ownplay);
        }
    }

    public class Sim_DAL_577ts : Sim_DAL_577
    {

    }
}