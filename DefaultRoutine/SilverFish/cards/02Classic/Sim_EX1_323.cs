using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_323 : SimTemplate //* Lord Jaraxxus
	{
        // Battlecry: Destroy your hero and replace it with Lord Jaraxxus.

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_323w);

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.equipWeapon(weapon, own.own);
            p.setNewHeroPower(CardDB.cardIDEnum.EX1_tk33, own.own); // INFERNO!

            if (own.own)
            {
                p.ownHeroName = HeroEnum.lordjaraxxus;
                p.ownHero.HealthPoints = own.HealthPoints;
                p.ownHero.maxHp = own.maxHp;
            }
            else 
            {
                p.enemyHeroName = HeroEnum.lordjaraxxus;
                p.enemyHero.HealthPoints = own.HealthPoints;
                p.enemyHero.maxHp = own.maxHp;
            }
		}
	}
}