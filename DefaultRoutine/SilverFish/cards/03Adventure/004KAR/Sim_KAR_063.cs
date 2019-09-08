using HREngine.Bots;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_063 : SimTemplate //* Spirit Claws
	{
		//Has +2 Attack while you have Spell Damage.

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardIdEnum.KAR_063);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
            if (ownplay)
            {
                if (p.spellpower > 0)
                {
                    p.minionGetBuffed(p.ownHero, 2, 0);
                    p.ownWeapon.Angr += 2;
                    p.ownSpiritclaws = true;
                }
            }
            else
            {
                if (p.enemyspellpower > 0)
                {
                    p.minionGetBuffed(p.enemyHero, 2, 0);
                    p.enemyWeapon.Angr += 2;
                    p.enemySpiritclaws = true;
                }
            }
        }
	}
}