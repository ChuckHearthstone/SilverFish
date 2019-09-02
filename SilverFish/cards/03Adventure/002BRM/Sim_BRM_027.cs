using HREngine.Bots;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRM_027 : SimTemplate //* Majordomo Executus
	{
		//Deathrattle: Replace your hero with Ragnaros, the Firelord.
		        
		public override void onDeathrattle(Playfield p, Minion m)
        {
            p.setNewHeroPower(CardDB.cardIDEnum.BRM_027p, m.own); // DIE, INSECT!

			if (m.own)
            {
                p.ownHeroName = HeroEnum.ragnarosthefirelord;
                p.ownHero.HealthPoints = 8;
                p.ownHero.maxHp = 8;
            }
            else
            {
                p.enemyHeroName = HeroEnum.ragnarosthefirelord;
                p.enemyHero.HealthPoints = 8;
                p.enemyHero.maxHp = 8;
            }
        }
	}
}