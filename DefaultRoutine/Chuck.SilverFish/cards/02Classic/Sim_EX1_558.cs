using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_558 : SimTemplate //harrisonjones
	{
//    kampfschrei:/ zerstört die waffe eures gegners. zieht ihrer haltbarkeit entsprechend karten.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                //this.owncarddraw += enemyWeaponDurability;
                for (int i = 0; i < p.enemyWeapon.Durability; i++)
                {
                    p.drawACard(CardName.unknown, true);
                }
                p.lowerWeaponDurability(1000, false);
            }
            else
            {
                for (int i = 0; i < p.enemyWeapon.Durability; i++)
                {
                    p.drawACard(CardName.unknown, false);
                }
                p.lowerWeaponDurability(1000, true);
            }
		}


	}
}