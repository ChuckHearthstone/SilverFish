using HREngine.Bots;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRM_024 : SimTemplate //* Drakonid Crusher
	{
		//	Battlecry: If your opponent has 15 or less Health, gain +3/+3.
	
        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            int heroHealth = m.own ? p.enemyHero.HealthPoints : p.ownHero.HealthPoints;
			if(heroHealth <= 15) p.minionGetBuffed(m, 3, 3);
        }
	}
}