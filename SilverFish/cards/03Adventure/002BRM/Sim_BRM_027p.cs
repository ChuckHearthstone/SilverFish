using HREngine.Bots;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRM_027p : SimTemplate //* DIE, INSECT!
	{
		// Hero Power: Deal 8 damage to a random enemy.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getHeroPowerDamage(8) : p.getEnemyHeroPowerDamage(8);
            if (ownplay)
            {
                target = p.getEnemyCharTargetForRandomSingleDamage(dmg);
            }
            else
            {
                target = p.searchRandomMinion(p.ownMinions, searchmode.searchHighestAttack); //damage the Highest (pessimistic)
                if (target == null) target = p.ownHero;
            }
            p.minionGetDamageOrHeal(target, dmg, true);
        }
	}
}