using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_836: SimTemplate //* Breath of Sindragosa
    {
        // Deal 2 damage to a random enemy minion and Freeze it.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);

            target = null;
            if (ownplay)
            {
                target = p.getEnemyCharTargetForRandomSingleDamage(dmg, true);
            }
            else
            {
                target = p.searchRandomMinion(p.ownMinions, searchmode.searchHighestAttack); //damage the Highest (pessimistic)
            }
            if (target != null)
            {
                p.minionGetDamageOrHeal(target, dmg);
                p.minionGetFrozen(target);
            }
        }
    }
}