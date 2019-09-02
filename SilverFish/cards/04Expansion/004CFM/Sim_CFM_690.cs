using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_690 : SimTemplate //* Jade Shuriken
	{
        // Deal 2 damage. Combo: Summon a Jade Golem.
        
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);

            if (p.cardsPlayedThisTurn > 0)
            {
                int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                p.CallKid(p.getNextJadeGolem(ownplay), pos, ownplay);
            }
        }
    }
}